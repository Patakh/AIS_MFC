using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Template;
using AisLogistics.App.Service;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.App.ViewModels.Statistics;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers
{
    public class StatisticsController : AbstractController
    {
        private readonly ILogger<StatisticsController> _logger;
        private readonly IStatistics _statistics;
        private readonly int _pageSize;

        public StatisticsController(IReferencesService referencesService,
            IEmployeeManager employeeManager, ILogger<StatisticsController> logger, IStatistics statistics) : base(employeeManager)
        {
            _logger = logger;
            _statistics = statistics;
            _pageSize = 15;
        }

        [Breadcrumb("Аналитика", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> Index()
        {
            var statistics = await _statistics.GetAnaliticsAsync();

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Аналитика").SetInvisibleViewTitle()
                .AddModel(statistics);
            return View(modelBuilder);
        }

        public async Task<IActionResult> StatisticsGeneral()
        {
            var data = await _statistics.StatisticsGeneral();
            return PartialView("StatisticsGeneral/Index", data);
        }


        [HttpGet]
        public async Task<IActionResult> StatisticsGeneralGraphic(StatisticsViewRequestModel requestModel)
        {

            var data = requestModel.PeriodTypeId switch
            {
                1 => await _statistics.StatisticsGeneralGraphicTypeDay(requestModel),
                2 => await _statistics.StatisticsGeneralGraphicTypeYear(requestModel),
                _ => null
            };
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> StatisticsSmevGraphic(StatisticsViewRequestModel requestModel)
        {

            var data = requestModel.PeriodTypeId switch
            {
                1 => await _statistics.StatisticsSmevGraphicTypeDay(requestModel),
                2 => await _statistics.StatisticsSmevGraphicTypeYear(requestModel),
                _ => null
            };
            return Json(data);
        }


        public async Task<IActionResult?> PartialMfcDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsMfcData(request,additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialEmployeeDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsEmployeeData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialProviderDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsProviderData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialServiceDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsServiceData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialCustomerTypeDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsCustomerTypeData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialServiceTypeDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsServiceTypeData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialInteractionTypeDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsInteractionTypeData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialSmevDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsSmevData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialSmevMfcDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsSmevMfcData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult?> PartialSmevEmployeeDataJson(IDataTablesRequest request, StatisticsViewRequestModel additionalRequest)
        {
            (var statistics, int count) = await _statistics.StatisticsSmevEmployeeData(request, additionalRequest);

            var response = DataTablesResponse.Create(request, count, count, statistics);

            return new DataTablesJsonResult(response, true);
        }


        public async Task<IActionResult> StatisticsServicesGeneral()
        {
            var data = await _statistics.StatisticsServicesGeneral();
            return PartialView("StatisticsServicesGeneral/Index", data);
        }

        [HttpGet]
        public async Task<IActionResult> StatisticsServicesGeneralGraphic(StatisticsViewRequestModel requestModel)
        {

            var data = requestModel.PeriodTypeId switch
            {
                1 => await _statistics.StatisticsServicesGeneralGraphicTypeDay(requestModel),
                2 => await _statistics.StatisticsServicesGeneralGraphicTypeYear(requestModel),
                _ => null
            };
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> StatisticsServicesGeneralServiceType()
        {

            var response = await _statistics.StatisticsServicesGeneralServiceType();
            return Json(response);
        }
        [HttpGet]
        public async Task<IActionResult> StatisticsServicesGeneralCustomerType()
        {

            var response = await _statistics.StatisticsServicesGeneralCustomerType();
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> StatisticsServicesGeneralInteractionType()
        {
            var response = await _statistics.StatisticsServicesGeneralInteractionType();
            return Json(response);
        }
    }
}
