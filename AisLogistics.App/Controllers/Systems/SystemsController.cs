using AisLogistics.App.Data;
using AisLogistics.App.Service;
using AisLogistics.App.Service.Systems;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Systems
{
    public partial class SystemsController : AbstractController
    {
        private readonly ILogger<SystemsController> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IReferencesService _referencesService;
        private readonly ISystemsService _systemsService;
        private readonly IFilterManager _filterManager;
        private readonly IMapper _mapper;

        public SystemsController(ILogger<SystemsController> logger,
            RoleManager<ApplicationRole> roleManager,
            IEmployeeManager employeeManager,
            IReferencesService referenceService,
            ISystemsService systemsService,
            IMapper mapper,
            IConfiguration configuration,
            IFilterManager filterManager) : base(employeeManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _referencesService = referenceService;
            _systemsService = systemsService;
            _mapper = mapper;
            _configuration = configuration;
            _filterManager = filterManager;
        }

        [Breadcrumb("Система", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
