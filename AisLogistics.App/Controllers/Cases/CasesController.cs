using AisLogistics.App.Hubs;
using AisLogistics.App.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace AisLogistics.App.Controllers.Cases
{
    [Authorize]
    public partial class CasesController : AbstractController
    {
        private readonly ICaseService _caseService;
        private readonly IReferencesService _referencesService;
        private readonly ISmevService _smevService;
        private readonly IFilterManager _filterManager;
        private readonly IConfiguration _configuration;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<CasesController> _logger;

        public CasesController(ICaseService caseService, IReferencesService referencesService, ISmevService smevService,
            IEmployeeManager employeeManager, IConfiguration configuration, 
            IHubContext<NotificationHub> hubContext, ILogger<CasesController> logger, IFilterManager filterManager) : base(employeeManager)
        {
            _caseService = caseService;
            _referencesService = referencesService;
            _smevService = smevService;
            _configuration = configuration;
            _hubContext = hubContext;
            _logger = logger;
            _filterManager = filterManager;
        }

        #region SignalR
        [AllowAnonymous]
        public async Task signalRAlerts(Guid id)
        {
            var Id = await _referencesService.GetEmployeeAspNetUserId(id);

            if (Id.HasValue)
            {
                await _hubContext.Clients.User(Id.Value.ToString()).SendAsync("Alert", true);
            }

        }

        #endregion
    }
}
