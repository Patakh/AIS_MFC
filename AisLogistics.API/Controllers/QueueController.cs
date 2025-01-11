using AisLogistics.API.Models.Request;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AisLogistics.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IElectronicQueueServiceClientAPI _queue; 
        public QueueController(IElectronicQueueServiceClientAPI queue)
        {
            _queue = queue;
        }

        [HttpGet("offices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список офисов ЭО")]
        public async Task<ActionResult<List<OfficeQueueResponse>>> GetOffices()
        {
            var response = await _queue.GetOffices();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpGet("prerecord/times")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список времен для предварительной записи")]
        public async Task<ActionResult<List<TimePrerecordResponse>>> GetTimesForRrerecord([FromQuery] long OfficeId)
        {
            var response = await _queue.GetTimesForPrerecord(new TimePrerecordRequest {OfficeId = OfficeId, Date = DateTime.Now.ToShortDateString() });
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpPost("prerecord/append")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Добавление предварительной записи")]
        public async Task<ActionResult<AddPrerecordResponse>> AddRrerecord([FromBody]AddPrerecordRequest request)
        {
            var response = await _queue.AddPrerecord(request);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpPost("prerecord/cansel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Отмена предварительной записи")]
        public async Task<ActionResult<CanselPrerecordResponse>> CanselRrerecord([FromBody]CanselPrerecordRequest request)
        {
            var response = await _queue.CanselPrerecord(request);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
    }
}
