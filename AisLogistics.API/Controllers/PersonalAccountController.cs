using AisLogistics.API.Models.Request.PersonalAccount;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AisLogistics.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PersonalAccountController : ControllerBase
    {

        private readonly IPersonalAccountServicesAPI _personalAccountServicesAPI;
        public PersonalAccountController(IPersonalAccountServicesAPI personalAccountServicesAPI)
        {
            _personalAccountServicesAPI = personalAccountServicesAPI;
        }
        [HttpGet("{id}/info")]
        [SwaggerOperation(
            Summary = "Информация по делу, ",
            Description = "caseId = Номер обращения, " +
            "EmployeesFioAdd = ФИО сотрудника принявшего дело, " +
            "employeeFioCurrent = ФИО сотрудника, " +
            "mfcName = Наименование МФЦ, " +
            "servicesProviderName = Наименование поставщика услуги, " +
            "servicesName = Наименование услуги, " +
            "statusName = Статус обращения, " +
            "statusId = Индетификатор статуса, " +
            "customerFio = ФИО заявителя, " +
            "customerAddress = Адрес заявителя, " +
            "dateAdd = Дата принятия обращения, " +
            "dateReglament = Регламентная дата обращения, " +
            "dateFact = Фактическая дата обращения, "
            )
        ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CasesInfoResponse?>> GetCasesInfo([FromRoute] string id)
        {
            var data = await _personalAccountServicesAPI.GetCasesInfo(id);
            if (data is null) return NotFound("Данные не найдены");
            return data;
        }

        [HttpGet("execution")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Услуги на исполнение")]
        public async Task<ActionResult<List<CasesExecutioninfoResponse>>> GetCasesExecutionListInfo([FromQuery] CasesExecutionInfoRequest request)
        {
            var response = await _personalAccountServicesAPI.GetCasesExecutionInfo(request);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
    }
}
