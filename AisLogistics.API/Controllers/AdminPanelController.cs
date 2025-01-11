using AisLogistics.API.Models.Request.Queue;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace AisLogistics.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {
        private readonly IElectronicQueueServiceClientAPI _queue;
        private readonly IReferencesServiceAPI _referencesServiceAPI;
        public AdminPanelController(IElectronicQueueServiceClientAPI queue, IReferencesServiceAPI referencesServiceAPI)
        {
            _queue = queue;
            _referencesServiceAPI = referencesServiceAPI;
        }
        [HttpGet("queue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QueueInfoResponse>> GetQueueInfo([FromQuery] QueueInfoRequest request)
        {
            var response = await _queue.GetQueueInfo(request);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("queueOffice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<QueueOfficeInfoResponse>>> GetQueueOfficeInfo([FromQuery] QueueOfficeInfoRequest request)
        {
            var response = await _queue.GetQueueOfficeInfo(request);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("service")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ServiceInfoResponse>>> GetServiceInfo()
        {
            var response = await _referencesServiceAPI.GetServiceInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpGet("servicesOffice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ServiceOfficeInfoResponse>>> GetServiceOfficeInfo(int periodId)
        {
            var response = await _referencesServiceAPI.GetServiceOfficeInfo(periodId);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpGet("static")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ServiceStaticDataMfcResponse>>> GetServiceStaticDataMfcInfo()
        {
            var response = await _referencesServiceAPI.GetServiceStaticDataMfc();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpGet("stateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ServiceStateTaskInfoResponse>>> GetServiceStateTaskInfo()
        {
            var response = await _referencesServiceAPI.GetServiceStateTaskInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
    }
}
