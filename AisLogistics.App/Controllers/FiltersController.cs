using AisLogistics.App.Service;

namespace AisLogistics.App.Controllers
{
    public class FiltersController : AbstractController
    {
        private readonly ILogger<FiltersController> _logger;
        private readonly IFilterManager _filterManager;

        public FiltersController(IFilterManager filterManager, IEmployeeManager employeeManager,
            ILogger<FiltersController> logger) : base(employeeManager)
        {
            _logger = logger;
            _filterManager = filterManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetProvidersDataJson()
        {
            return Json(await _filterManager.GetProvidersDataJson());
        }

        public async Task<ActionResult> GetServicesForProviderDataJson(List<Guid> providersId)
        {
            return Json(await _filterManager.GetServicesForProviderDataJson(providersId));
        }

        [HttpGet]
        public async Task<ActionResult> GetReceptionOfficeDataJson(bool isAll)
        {
            return Json(await _filterManager.GetOfficesReceptionCustomerDataJson(isAll));
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployeesForReceptionOfficeDataJson(List<Guid> employeeId)
        {
            return Json(await _filterManager.GetEmployeesForReceptionOfficeDataJson(employeeId));
        }

        [HttpGet]
        public async Task<ActionResult> GetSmevServicesDataJson()
        {
            return Json(await _filterManager.GetSmevServicesDataJson());
        }

        [HttpGet]
        public async Task<ActionResult> GetRequestForSmevServicesDataJson(List<Guid> smevId)
        {
            return Json(await _filterManager.GetRequestForSmevServicesDataJson(smevId));
        }

        [HttpGet]
        public async Task<ActionResult> GetServiceCustomerTypeDataJson()
        {
            return Json(await _filterManager.GetServiceCustomerTypeDataJson(true));
        }
        [HttpGet]
        public async Task<ActionResult> GetServiceTypeDataJson()
        {
            return Json(await _filterManager.GetServiceTypeDataJson());
        }
        [HttpGet]
        public async Task<ActionResult> GetServiceInteractionTypeDataJson()
        {
            return Json(await _filterManager.GetServiceInteractionTypeDataJson());
        }
        [HttpGet]
        public async Task<ActionResult> GetSpsMfcDataJson()
        {
            return Json(await _filterManager.GetSpsMfcDataJson());
        }
    }
}
