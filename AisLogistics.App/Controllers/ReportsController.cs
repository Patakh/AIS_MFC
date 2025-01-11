using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.Service;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.App.ViewModels.Reports;
using AisLogistics.DataLayer.Utils;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using SmartBreadcrumbs.Attributes;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace AisLogistics.App.Controllers
{
    public class ReportsController : AbstractController
    {
        private readonly ILogger<ReportsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IReports _reports;
        private readonly IFilterManager _filterManager; 
        private readonly IReferencesService _referencesService;

        public ReportsController(IReferencesService referencesService, IFilterManager filterManager, IEmployeeManager employeeManager,
            ILogger<ReportsController> logger, IConfiguration configuration, IReports reports) : base(employeeManager)
        {
            _logger = logger;
            _filterManager = filterManager;
            _configuration = configuration;
            _reports = reports;
            _referencesService = referencesService;
        }

        [Breadcrumb("Отчеты", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> Index()
        {
            var repots = await _reports.GetReportsAsync();

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Отчеты").SetInvisibleViewTitle()
                .AddModel(new ReportNavViewRequestModel { Reports = repots, NavId = string.Empty });
            return View("Index", modelBuilder);
        }

        [Breadcrumb("Отчеты", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> MainReport(string navId, string urlAction)
        {
            ViewBag.Url = urlAction;
            ViewBag.NavId = navId;
            var repots = await _reports.GetReportsAsync();
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Отчеты").SetInvisibleViewTitle()
                .AddModel(new ReportNavViewRequestModel { Reports = repots, NavId = navId, Url = urlAction });
            return View("Main", modelBuilder);
        }

        public IActionResult ReportPage(string navId, string urlAction)
        {
            return PartialView($"{urlAction}/Page", navId);
        }

        public async Task<IActionResult?> ReportData(ReportViewRequestModel requestModel)
        {
            try
            {
                var report = await _reports.GetReportAsync(requestModel.Id);
                if (report == null) { ShowError(MessageDescription.Error); return NotFound(); }
                ReportViewResponseModel responseModel = new ReportViewResponseModel()
                {
                    DataList = await _reports.GetDataReport(requestModel, report.Function)
                };

                if (responseModel.DataList == null) { ShowError(MessageDescription.Error); return NotFound(); }

                return PartialView($"{report.Path}/Report", responseModel);
            }
            catch
            {
                ShowError(MessageDescription.Error);
                return null;
            }
        }


        public async Task<ActionResult?> ReportDataPrint(ReportViewRequestModel requestModel)
        {
            try
            {
                var report = await _reports.GetReportAsync(requestModel.Id);
                if (report == null) { ShowError(MessageDescription.Error); return null; }

                var data = await _reports.GetDataReport(requestModel, report.Function);
                if (data == null) { ShowError(MessageDescription.Error); return null; }

                var connection = _configuration.GetConnectionString("DefaultConnection");
                var employee = await _employeeManager.GetNameAsync();

                var strm = await _reports.ReportDataPrepare(report.File, data, requestModel, BlankActionType.Pdf, connection, employee);
                if (strm == null)
                {
                    ShowError(MessageDescription.Error);
                    return null;
                }

                return Json(Convert.ToBase64String(strm.ToArray()));

            }
            catch (Exception e)
            {
                ShowError(MessageDescription.Error);
                return null;
            }
        }

        public async Task<ActionResult?> ReportDataDownLoad(ReportViewRequestModel requestModel)
        {
            try
            {
                var report = await _reports.GetReportAsync(requestModel.Id);
                if (report == null) { ShowError(MessageDescription.Error); return null; }

                var data = await _reports.GetDataReport(requestModel, report.Function);
                if (data == null) { ShowError(MessageDescription.Error); return null; }

                var connection = _configuration.GetConnectionString("DefaultConnection");
                var employee = await _employeeManager.GetNameAsync();

                var strm = await _reports.ReportDataPrepare(report.File, data, requestModel, BlankActionType.Exel, connection, employee);
                if (strm == null)
                {
                    ShowError(MessageDescription.Error);
                    return null;
                }

                return File(strm.ToArray(), MimeTypeMap.GetMimeType(".xlsx"), "Отчет.xlsx");

            }
            catch (Exception e)
            {
                ShowError(MessageDescription.Error);
                return null;
            }
        }
    }
}
