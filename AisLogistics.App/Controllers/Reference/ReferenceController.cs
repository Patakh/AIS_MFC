using AisLogistics.App.Data;
using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.App.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Reference
{
    [Authorize]
    public partial class ReferenceController : AbstractController
    {
        private readonly ILogger<ReferenceController> _logger;
        private readonly IIdentityService<IdentityUserDto, ApplicationUser, ApplicationRole, Guid> _identityService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IReferencesService _referencesService;
        private readonly IMapper _mapper;
        private readonly IFilterManager _filterManager;   

        public ReferenceController(ILogger<ReferenceController> logger,
            IIdentityService<IdentityUserDto, ApplicationUser, ApplicationRole, Guid> identityService,
            RoleManager<ApplicationRole> roleManager,
            IEmployeeManager employeeManager,
            IReferencesService referenceService,
            IMapper mapper,
            IFilterManager filterManager) : base(employeeManager)
        {
            _logger = logger;
            _identityService = identityService;
            _roleManager = roleManager;
            _referencesService = referenceService;
            _mapper = mapper;
            _filterManager = filterManager;
        }

        [Breadcrumb("Справочники", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
