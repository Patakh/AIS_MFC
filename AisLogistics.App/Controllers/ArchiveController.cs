using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Service;
using AisLogistics.App.ViewModels.Archive;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers
{
    [Authorize]
    public class ArchiveController : AbstractController
    {
        private readonly IArchiveService _archiveService;
        private readonly IReferencesService _referencesService;

        public ArchiveController(IArchiveService archiveService, IReferencesService referencesService, IEmployeeManager employeeManager) : base(employeeManager)
        {
            _archiveService = archiveService;
            _referencesService = referencesService;
        }

        [Breadcrumb("Архив обращений", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> Index()
        {
            var offices = await _referencesService.GetAllOfficesAsync();
            var services = await _referencesService.GetServicesAll();

            var model = new SearchArchiveCasesResponseData()
            {
                OfficesList = new SelectList(offices, nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName)),
                ServicesList = new SelectList(services.Select(s => new ServicesDto { Id = s.Id, ServiceName = s.ServiceName.Length > 200 ? s.ServiceName[..200] + "..." : s.ServiceName }), nameof(ServicesDto.Id), nameof(ServicesDto.ServiceName)),
            };
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Архив обращений")
                .SetElementName("archive-cases-datatable")
                .AddModel(model)
                .AddTableMethodAction(Url.Action(nameof(GetArchiveCasesDataJson)));
            return View(modelBuilder);
        }

        [HttpGet]
        public async Task<IActionResult> GetServicesForProviderDataJson(List<Guid> providersId)
        {
            var services = await _referencesService.GetServicesForProviders(providersId);
            return Json(services.Select(s => new { s.Id, ServiceName = s.ServiceName.Length > 200 ? s.ServiceName[..200] + "..." : s.ServiceName }));
        }

        public IActionResult GetArchiveCasesDataJson(IDataTablesRequest request, SearchArchiveCasesRequestData additionalRequest)
        {
            var archiveCases = _archiveService.GetCases(additionalRequest, request.Start, request.Length);

            var response = DataTablesResponse.Create(request, archiveCases.Count, archiveCases.FilteredCount, archiveCases.Cases);

            return new DataTablesJsonResult(response, true);
        }

        [Breadcrumb("ViewData.Title", FromAction = nameof(Index), FromController = typeof(ArchiveController))]
        public async Task<IActionResult> Details(string id)
        {
            var caseDetails = await _archiveService.GetCaseDetailsByIdAsync(id);
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle(id)
                .AddModel(caseDetails);
            return View("Details/Index", modelBuilder);
        }

        public async Task<IActionResult> DownloadFile(Guid id, DocumentType type)
        {
            var file = await _archiveService.DownloadServicesFileAsync(id, type);
            if (file is null) return NotFound();
            return File(file.OpenReadStream(), file.ContentType, file.FileName);
        }
    }
}
