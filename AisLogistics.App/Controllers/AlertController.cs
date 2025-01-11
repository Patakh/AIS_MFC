using AisLogistics.App.Controllers.Queue;
using AisLogistics.App.Hubs;
using AisLogistics.App.Service.Queue;
using AisLogistics.App.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using AisLogistics.App.Models.DTO.Alert;

namespace AisLogistics.App.Controllers
{
    public class AlertController : AbstractController
    {
        private readonly IReferencesService _referencesService;
        private readonly ILogger<AlertController> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;

        public AlertController(IReferencesService referencesService, 
            IEmployeeManager employeeManager, ILogger<AlertController> logger, IHubContext<NotificationHub> hubContext) : base(employeeManager)
        {
            _referencesService = referencesService;
            _logger = logger;
            _hubContext = hubContext;
        }
        [AllowAnonymous]
        public async Task signalRAlerts(Guid id)
        {
            var Id = await _referencesService.GetEmployeeAspNetUserId(id);

            if (Id.HasValue)
            {
                await _hubContext.Clients.User(Id.Value.ToString()).SendAsync("Alert", true);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task NewTicketQueue([FromBody] NewTicketQueueDto request)
        {
            try
            {
                var mfc_id = await _referencesService.GetOfficeForQueueAsync(request.OfficeId);
                if (mfc_id != null)
                {
                    var employees = await _referencesService.GetEmployeesForQueueAsync(mfc_id.Id);
                    if (employees is not null and { Count: > 0 })
                    {
                        var users = employees.Select(s => s.Id.ToString()).ToList();
                        await _hubContext.Clients.Users(users).SendAsync("Queue", request.TiketId);
                    }
                }
            }
            catch
            {

            }
        }


    }
}
