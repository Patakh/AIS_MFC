using AisLogistics.App.Service;
using AisLogistics.App.Service.ApplicantPersonalAccount;
using AisLogistics.App.ViewModels.ApplicantPersonalAccount;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Sentry;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers
{
    public class ApplicantPersonalAccountController : AbstractController
    {
        private readonly ILogger<ApplicantPersonalAccountController> _logger;
        private readonly IApplicantPersonalAccount _applicantPersonalAccount;
        private readonly IReferencesService _referencesService;
        private readonly IConfiguration _configuration;
        private readonly ICaseService _caseService;
        private readonly IFilterManager _filterManager;

        public ApplicantPersonalAccountController(IApplicantPersonalAccount applicantPersonalAccount, IReferencesService referencesService,
            IEmployeeManager employeeManager, IConfiguration configuration, ICaseService caseService,
            IFilterManager filterManager, ILogger<ApplicantPersonalAccountController> logger) : base(employeeManager)
        {
            _applicantPersonalAccount = applicantPersonalAccount;
            _logger = logger;
            _referencesService = referencesService;
            _configuration = configuration;
            _caseService = caseService;
            _filterManager = filterManager;
        }
        [Breadcrumb("Личный кабинет заявителя", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            var modelBuilder = new ViewModelBuilder()
                    .AddViewTitle("Реестр")
                    .AddTableMethodAction(Url.Action(nameof(GetReestrApplicantsDataJson)));
            return View(modelBuilder);
        }

        public async Task<IActionResult> GetReestrApplicantsDataJson(IDataTablesRequest request, SearchApplicantsRequestData additional)
        {
            (var responseData, int totalCount, int filteredCount) = await _applicantPersonalAccount.GetReestrApplicants(request, additional);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ApplicantDetails(Guid Id)
        {
            var model = await _applicantPersonalAccount.GetApplicantModelDto(Id);

            var modelBuilder = new ViewModelBuilder()
                    .AddViewTitle("Общая информация")
                    .AddViewDescription("Общая информация")
                    .AddModel(model);
            return PartialView("_PartialApplicantDetails", modelBuilder);
        }

        public IActionResult ApplicantCases(Guid Id)
        {
            var modelBuilder = new ViewModelBuilder()
                    .AddViewTitle("Текущие обращения")
                    .AddViewDescription("Текущие обращения")
                    .AddModel(new SearchApplicantCasesRequestData { Id = Id })
                    .SetElementName(nameof(ApplicantCases))
                    .AddTableMethodAction(Url.Action(nameof(GetApplicantCasesDataJson), new SearchApplicantCasesRequestData { Id = Id }));
            return PartialView("_PartialApplicantCases", modelBuilder);
        }

        public async Task<IActionResult> GetApplicantCasesDataJson(IDataTablesRequest request, SearchApplicantCasesRequestData additional)
        {
            (var responseData, int totalCount, int filteredCount) = await _applicantPersonalAccount.GetApplicantCases(request, additional);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public IActionResult ApplicantCasesArchive(Guid Id)
        {
            var modelBuilder = new ViewModelBuilder()
                    .AddViewTitle("Архив обращений")
                    .AddViewDescription("Архив обращений")
                    .AddModel(new SearchApplicantCasesArchiveRequestData { Id = Id })
                    .SetElementName(nameof(ApplicantCasesArchive))
                    .AddTableMethodAction(Url.Action(nameof(GetApplicantCasesArchiveDataJson), new SearchApplicantCasesArchiveRequestData { Id = Id }));
            return PartialView("_PartialApplicantCasesArchive", modelBuilder);
        }

        public async Task<IActionResult> GetApplicantCasesArchiveDataJson(IDataTablesRequest request, SearchApplicantCasesArchiveRequestData additional)
        {
            (var responseData, int totalCount, int filteredCount) = await _applicantPersonalAccount.GetApplicantCasesArchive(request, additional);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public IActionResult ApplicantCasesHistory(Guid Id)
        {
            var modelBuilder = new ViewModelBuilder()
                    .AddViewTitle("История обращения")
                    .AddViewDescription("История обращения")
                    .SetElementName(nameof(ApplicantCasesHistory))
                    .AddModel(new SearchApplicantCasesHistoryRequestData { Id = Id })
                    .AddTableMethodAction(Url.Action(nameof(GetApplicantCasesHsitoryDataJson), new SearchApplicantCasesHistoryRequestData { Id = Id }));
            return PartialView("_PartialApplicantCasesHistory", modelBuilder);
        }

        public async Task<IActionResult> GetApplicantCasesHsitoryDataJson(IDataTablesRequest request, SearchApplicantCasesHistoryRequestData additional)
        {
            (var responseData, int totalCount, int filteredCount) = await _applicantPersonalAccount.GetApplicantCasesHistory(request, additional);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

    }
}
