using AisLogistics.App.Data;
using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Core.IConfiguration;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AisLogistics.App.Service.Systems
{
    public partial class SystemsService : ISystemsService
    {
        private readonly ILogger<SystemsService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AisLogisticsContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private IEmployeeManager _employeeManager;
        private readonly IReferencesService _referencesService;
        private readonly IIdentityService<IdentityUserDto, ApplicationUser, ApplicationRole, Guid> _identityService;
        private readonly IMapper _mapper;

        public SystemsService(ILogger<SystemsService> logger,
            IUnitOfWork unitOfWork,
            AisLogisticsContext context,
            RoleManager<ApplicationRole> roleManager,
            IEmployeeManager employeeManager,
            IIdentityService<IdentityUserDto, ApplicationUser, ApplicationRole, Guid> identityService,
            IReferencesService referenceService,
            IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _context = context;
            _roleManager = roleManager;
            _referencesService = referenceService;
            _identityService = identityService;
            _mapper = mapper;
            _employeeManager = employeeManager;
        }
    }
}
