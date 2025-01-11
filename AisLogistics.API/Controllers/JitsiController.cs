using AisLogistics.API.Models.Request.Jitsi;
using AisLogistics.API.Service;
using AisLogistics.DataLayer.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AisLogistics.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JitsiController : ControllerBase
    {
        private readonly IJitsiServicesAPI _jitsiServiceAPI;
        private readonly IFtpService _ftpService;
        public JitsiController(IJitsiServicesAPI jitsiServiceAPI, IFtpService ftpService)
        {
            _jitsiServiceAPI = jitsiServiceAPI;
            _ftpService = ftpService;
        }
        [HttpGet("SearchCustomer/{phone_number}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Поиск заявителя по номеру телефона", Description = "Номер телефона. Формат: 79999999999")]
        public async Task<ActionResult<SearchCustomerResponse?>> SearchCustomer(string phone_number)
        {
            var request = new SearchCustomerRequest();
            request.PhoneNumber = phone_number;
            var data = await _jitsiServiceAPI.GetSearchCustomer(request);
            if (data is null) return NotFound("Данные не найдены");
            return new SearchCustomerResponse { Customers = data };
        }
        [HttpGet("SearchCustomerCase/{phone_number}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Поиск услуг по номеру телефона", Description = "Номер телефона. Формат: 79999999999")]
        public async Task<ActionResult<SearchCustomerCaseResponse>?> SearchCustomerCase(string phone_number)
        {
            var request = new SearchCustomerCaseRequest();
            request.PhoneNumber = phone_number;
            var data = await _jitsiServiceAPI.GetSearchCustomerCase(request);
            if (data is null) return NotFound("Данные не найдены");
            return new SearchCustomerCaseResponse { Cases = data };
        }

        [HttpPost("SaveCallV3")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Запись звонка")]
        public async Task<IActionResult> SaveCallV3([FromBody] SaveCallRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ErrorDescription.InvalidInputParameters);
            };

            var responce = await _jitsiServiceAPI.SaveCallAsync(request);
            return responce.Success ? Ok() : Problem("Ошибка при сохранение");
        }

    }
}
