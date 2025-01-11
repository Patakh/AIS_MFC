using AisLogistics.App.Service;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace AisLogistics.App.Views.Shared.Components.QueuePartial
{
    [Authorize]
    public class QueuePartial : ViewComponent
    {
        private readonly ILogger<QueuePartial> _logger;
        private readonly IEmployeeManager _employeeManager;
        private int debugMfcId = 1; // 
        private string debugIp = "192.168.124.42"; //

        public QueuePartial(IEmployeeManager employeeManager, ILogger<QueuePartial> logger)
        {
            _employeeManager = employeeManager;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var queueId = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync();
            if (User.Identity?.IsAuthenticated == true && queueId != 0) return View("QueuePartial");
            return Content(string.Empty);
        }
    }
}
