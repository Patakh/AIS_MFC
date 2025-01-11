using AisLogistics.App.Models;
using AisLogistics.App.Service;
using AisLogistics.App.ViewModels.Home;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using SmartBreadcrumbs.Attributes;
using System.Diagnostics;

namespace AisLogistics.App.Controllers
{
    [Authorize]
    public class HomeController : AbstractController
    {
        private readonly IInformationManager _informationManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IReferencesService _referencesService;
        public HomeController(IInformationManager informationManager, ILogger<HomeController> logger, IReferencesService referencesService)
        {
            _informationManager = informationManager;
            _logger = logger;
            _referencesService = referencesService;
        }

        [DefaultBreadcrumb("Главная")]
        public async Task<ActionResult> Index()
        {
            //HomeViewModel model = new HomeViewModel();
            //model.Information = await _informationManager.GetInformationListAsync(5);
            //model.Notes = await _informationManager.GetNotesListAsync();

            var modelBuilder = new ViewModelBuilder()
                    .AddViewTitle("Главная")
                    .AddModel(new HomeViewModel())
                    .AddTableMethodAction(Url.Action(nameof(GetEmployeeRatingDataJson)));

            return View(modelBuilder);
        }

        public async Task<IActionResult> GetInformationDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filterCount) = await _informationManager.GetEmployeeInformationAsync(request);

            var response = DataTablesResponse.Create(request, totalCount, filterCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> GetEmployeeRatingDataJson(IDataTablesRequest request, int typeId)
        {
          var responseData = await _informationManager.GetEmployeeRatingAsync(request, typeId);

            var response = DataTablesResponse.Create(request, 1, 1, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> GetOfficeRatingDataJson(IDataTablesRequest request, int typeId)
        {
            var responseData = await _informationManager.GetOfficeRatingAsync(request, typeId);

            var response = DataTablesResponse.Create(request, 1, 1, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> GetNotesDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filterCount) = await _informationManager.GetEmployeeNotesAsync(request);

            var response = DataTablesResponse.Create(request, totalCount, filterCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> InformationDetailsModal(Guid id)
        {
            var model = await _informationManager.GetInformationDetailssAsync(id);
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.LARGE)
                .AddModalViewPath("Modals/_ModalInformation")
                .AddModalTitle($"{ model.Type} от {model.DateAdd.ToString("D")}")
                .AddModel(model)
                .HideSubmitButton();

            return ModalLayoutView(modelBuilder);
        }

        public async Task<IActionResult> RatingDetailsModal()
        {
            var mfc = await _referencesService.GetAllOfficesTypeMfcAndTospAsync();
            ViewBag.Mfc = mfc == null ? "" : string.Join("", mfc.Select(x => $"<option value=\"{x.Id}\">{x.OfficeName}</option>"));

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.LARGE)
                .AddModalViewPath("Modals/_ModalRatinig")
                .AddModalTitle($"Топ сотрудников за {DateTime.Now.AddDays(-1):Y}")
                .HideSubmitButton();

            return ModalLayoutView(modelBuilder);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}