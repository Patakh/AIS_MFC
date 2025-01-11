using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.App.ViewModels.Systems.Automatics;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Sentry;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Systems
{
    public partial class SystemsController
    {
        [Breadcrumb("Автоматика", FromAction = nameof(Index), FromController = typeof(SystemsController))]
        public IActionResult Automatics()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Автоматика")
                .AddViewDescription("Автоматика")
                .AddTableMethodAction(Url.Action(nameof(GetAutomaticOperrationDataJson)));

            return View("Automatics/Index", modelBuilder);
        }

        public async Task<IActionResult> GetAutomaticOperrationDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _systemsService.GetAutomaticsOperations(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> GetAutomaticLogsDataJson(IDataTablesRequest request, SearchAutomaticLogsRequestData requestData)
        {

            (var responseData, int totalCount, int filteredCount) = await _systemsService.GetAutomaticsOperationLogs(request, requestData);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }
    }
}
