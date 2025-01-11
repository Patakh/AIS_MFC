using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Concrete;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace AisLogistics.App.Service
{
    public partial class ReferencesService : IReferencesService
    {
        private readonly AisLogisticsContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly SpsSettings _spsSettings;
        private readonly IEmployeeManager _employeeManager;
        private readonly IFilterManager _filterManager;

        public ReferencesService(AisLogisticsContext context, IMapper mapper, IWebHostEnvironment environment, 
            IOptions<SpsSettings> spsOptions, IEmployeeManager employeeManager, IFilterManager filterManager)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
            _spsSettings = spsOptions.Value;
            _employeeManager = employeeManager;
            _filterManager = filterManager;
        }
    }
}
