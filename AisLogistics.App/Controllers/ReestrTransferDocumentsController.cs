using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.ReestrTransferDocuments;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.Service;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.App.ViewModels.ReestrTransferDocuments;
using AisLogistics.DataLayer.Utils;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers
{
    public class ReestrTransferDocumentsController : AbstractController
    {
        private readonly IReestrTransferDocuments _caseReestr;
        private readonly ILogger<ReestrTransferDocumentsController> _logger;
        private readonly IReferencesService _referencesService;
        private readonly IConfiguration _configuration;
        private readonly ICaseService _caseService;
        private readonly IFilterManager _filterManager;
        public ReestrTransferDocumentsController(IReestrTransferDocuments caseReest, IReferencesService referencesService,
            IEmployeeManager employeeManager, ILogger<ReestrTransferDocumentsController> logger, 
            IConfiguration configuration, ICaseService caseService, IFilterManager filterManager) : base(employeeManager)
        {
            _caseReestr = caseReest;
            _logger = logger;
            _referencesService = referencesService;
            _configuration = configuration;
            _caseService = caseService;
            _filterManager = filterManager;
        }
        [Breadcrumb("Реестр передачи документов", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> Index()
        {
             
            var officeId = await _employeeManager.GetOfficeAsync();
            var officesReceptionCustomer = await _filterManager.GetOfficesReceptionCustomerDataJson(true);
            ViewBag.OfficesReceptionCustomer = officesReceptionCustomer == null ? "" : string.Join("", officesReceptionCustomer.Select(x => $"<option value=\"{x.Id}\" {(x.Id == officeId.ToString() ? "selected" : string.Empty)}>{x.OfficeName}</option>"));
            //ViewBag.CasesAllView = (User.IsInRole("Администратор") || User.IsInRole("Ведущий менеджер"));

            var modelBuilder = new ViewModelBuilder()
                    .AddViewTitle("Реестр")
                    .AddTableMethodAction(Url.Action(nameof(GetEmployeeReestrTransferDocumentsDataJson)));
            return View(modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeReestrTransferDocumentsDataJson(IDataTablesRequest request, string officeId)
        {
            //if (officeId == null)
            //{
            //    officeId = await _employeeManager.GetOfficeAsync();
            //}
            var receptionOfficeData = await _filterManager.GetOfficesIdForReceptionCustomer(new List<string> { officeId}, false,false);

            (var responseData, int totalCount, int filteredCount) =await _caseReestr.GetReestrTransferDocuments(request, receptionOfficeData.OfficesId);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }
        [HttpGet]
        public async Task<ActionResult> GetServicesForProviderDataJson(List<Guid> providersId)
        {
            var services = await _referencesService.GetServicesForProviders(providersId);
            var departament = await _referencesService.GetOfficesProvidersDepartement(providersId);

            var model = new SearchTransferDocumentsResponceData()
            {
                OfficesList = new SelectList(departament, nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName)),
                ServicesList = new SelectList(services.Select(s => new ServicesDto { Id = s.Id, ServiceName = s.ServiceName.Length > 200 ? s.ServiceName[..200] + "..." : s.ServiceName }), nameof(ServicesDto.Id), nameof(ServicesDto.ServiceName))
            };

           return Json(model);
        }
        public async Task<IActionResult> TransferDocumentsChangeModalAdd()
        {
            var employee = await _employeeManager.GetFullInfoAsync();
            var providers = await _referencesService.GetOfficesProvidersAll();
            ViewBag.Providers = new SelectList(providers, nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName));

            var model = new ModalViewModelBuilder()
                .AddModalTitle(employee.Office.Name)
                .AddModalViewPath("~/Views/ReestrTransferDocuments/_ModalAddTransferDocument.cshtml")
                .AddModalType(ModalType.EXTRA)
                .HideModalFooter();
            return ModalLayoutView(model);
        }

        public async Task<IActionResult> TransferDocumentsChangeModalView(Guid id)
        {
            (var responseData, int Number) = await _caseReestr.GetReestrTransferDocument(id);

            ViewBag.Number = Number;
            ViewBag.Id = id;

            return PartialView("_TableViewTransferDocument", responseData);
        }

        public async Task<IActionResult> TransferDocumentsTable(Guid providerId, Guid? departamentId, Guid serviceId)
        {
            var id = await _employeeManager.GetIdAsync();
            var officeId = await _employeeManager.GetOfficeAsync();

            var request = new SearchTransferDocumentsRequestData
            {
                ServiceId = serviceId,
                ProvidersId = providerId,
                DepartamentId = departamentId
            };
            var model = await _caseReestr.GetCasesTransferDocuments(officeId, request);

            return PartialView("_TableAddTransferDocument", model);
        }

        public async Task<ActionResult<TransferDocumentsSaveResponce?>> TransferDocumentsSave(TransferDocumentsSaveRequest request)
        {
            var employee = await _employeeManager.GetFullInfoAsync();
            var result = await _caseReestr.CasesTransferDocumentsSave(request, employee);       
            return result;
        }

        public async Task<ActionResult<string>> TransferDocumentsPrint(Guid id)
        {
            try
            {
                var employeeName = await _employeeManager.GetNameAsync();
                var file = await _referencesService.SystemFiles(5);
                if (file is null) return NotFound();

                var connection = _configuration.GetConnectionString("DefaultConnection");
                var content = await _caseReestr.CasesTransferDocumentsPrint(file, id, connection, employeeName, BlankActionType.Pdf);

                return Convert.ToBase64String(content);
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
                return NotFound();
            }
        }

        public async Task<IActionResult> TransferDocumentsDownload(Guid id)
        {
            try
            {
                var employeeName = await _employeeManager.GetNameAsync();
                var file = await _referencesService.SystemFiles(5);
                if (file is null) return NotFound();

                var connection = _configuration.GetConnectionString("DefaultConnection");
                var content = await _caseReestr.CasesTransferDocumentsPrint(file, id, connection, employeeName, BlankActionType.Word);

                return File(content, MimeTypeMap.GetMimeType(".docx"), "Реестр.docx");

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return NotFound();
            }
        }

        public async Task<IActionResult> TransferDocumentsChangeModalEdit(Guid id)
        {
            var responce = await _caseReestr.GetReestrTransferDocuments(id);

            var model = new ModalViewModelBuilder()
                .AddModalViewPath("~/Views/ReestrTransferDocuments/_ModalEditTransferDocument.cshtml")
                .AddModalType(ModalType.SMALL)
                .AddModel(responce)
                .AddModalTitle("Редактирование");
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task TransferDocumentsEditSave(ReestrTransferDocumentsDto request)
        {
            var responce = await _caseReestr.EditReestrTransferDocuments(request);
            if (responce) ShowSuccess("Успешно");
            else ShowError("Невозможно");
        }

        public IActionResult CasesCommentsChangeModalAdd()
        {
            var model = new ModalViewModelBuilder()
                .AddModalViewPath("~/Views/ReestrTransferDocuments/_PartialAddCommentsCases.cshtml")
                .AddModalType(ModalType.LARGE)
                .AddModalTitle("Примечание")
                .HideModalFooter();
            return ModalLayoutView(model);
        }

        public async Task<IActionResult> CasesCommentsSave(TransferDocumentsCommentsSaveRequest request)
        {
            if(request == null) return NotFound();
            if (request.CaseId == null || request.CaseId.Count == 0) return NotFound("Обращения не выбраны");
            if (string.IsNullOrEmpty(request.Text)) return NotFound("Текст не должен быть пустым");

            var employee = await _employeeManager.GetFullInfoAsync();
            var result = await _caseReestr.CasesTransferDocumentsCommentsSave(request, employee);

            return result ? Ok() : NotFound();
        }

        public async Task<IActionResult> ServiceStageAddModal(List<Guid> id)
        {
            var officeId = await _employeeManager.GetOfficeAsync();
            var employeeId = await _employeeManager.GetIdAsync();

            var stageModelAdd = new StageAddDto
            {
                OfficeId = officeId.Value,
                EmployeeId = employeeId.Value,
                ServiceId = id
            };

            stageModelAdd.Stages.AddRange(User.HasClaim(AccessKeyNames.DataCaseServiceAllStage, AccessKeyValues.Add)
                ? await _caseService.GetStagesNextAllAsync(id)
                : await _caseService.GetStagesNextByServiceIdAsync(id));

            ViewBag.Offices = new SelectList(await _referencesService.GetAllOfficesTypeMfcAndTospAsync(), "Id", "OfficeName", officeId);

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalViewPath("~/Views/ReestrTransferDocuments/_PartialServiceStageModalAdd.cshtml")
                .AddModalTitle("Добавление этапа")
                .AddModel(stageModelAdd);

            if (stageModelAdd.Stages.Any() == false) modelBuilder.HideSubmitButton();

            return ModalLayoutView(modelBuilder);
        }
    }
}
