using AisLogistics.App.Models;
using AisLogistics.App.Service;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers
{
    public class ReestrSentMessageController : AbstractController
    {
        private readonly IReestrSentMessage _caseReestr;
        private readonly ILogger<ReestrSentMessageController> _logger;
        private readonly IReferencesService _referencesService;
        public ReestrSentMessageController(IReestrSentMessage caseReest, IReferencesService referencesService,
            IEmployeeManager employeeManager, ILogger<ReestrSentMessageController> logger) : base(employeeManager)
        {
            _caseReestr = caseReest;
            _logger = logger;
            _referencesService = referencesService;
        }
        [Breadcrumb("Реестр отправленных смс", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> Index()
        {
            //var mfc = await _referencesService.GetAllOfficesTypeMfcAndTospAsync();
            //var officeId = await _employeeManager.GetOfficeAsync();
            //ViewBag.Mfc = mfc == null ? "" : string.Join("", mfc.Select(x => $"<option value=\"{x.Id}\" {(x.Id == officeId ? "selected" : string.Empty)}>{x.OfficeName}</option>"));
            //ViewBag.CasesAllView = User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View);

            var model = new SearchCasesResponseData();

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Реестр отправленных смс")
                 .SetElementName("reest-sentMessage-datatable")
                .AddModel(model)
                .AddTableMethodAction(Url.Action(nameof(GetReestrSentMessageDataJson)));
            return View(modelBuilder);
        }

        public async Task<IActionResult> GetReestrSentMessageDataJson(IDataTablesRequest request)
        {

            (var responseData, int totalCount, int filteredCount) = await _caseReestr.GetReestrSentMessageDocuments(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }
    }
}
