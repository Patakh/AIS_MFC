using AisLogistics.API.Models.Responce;
using AisLogistics.API.Models.Responce.References;
using AisLogistics.API.Service;
using AisLogistics.DataLayer.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AisLogistics.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IReferencesServiceAPI _referencesServiceAPI;
        public ReferenceController(IReferencesServiceAPI referencesServiceAPI)
        {
            _referencesServiceAPI = referencesServiceAPI;
        }

        [HttpGet("providers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список поставщиков")]
        public async Task<ActionResult<List<ProvidersInfoResponse>>> GetProvidersListInfo()
        {
            var response = await _referencesServiceAPI.GetProvidersListInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("mfc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список мфц")]
        public async Task<ActionResult<List<MfcListInfoResponse>>> GetMfcListInfo()
        {
            var response = await _referencesServiceAPI.GetMfcListInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpGet("mfc/{Id}/shedules")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "График работы")]
        public async Task<ActionResult<List<MfcShedulesInfoResponse>>> GetMfcShedulesInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetMfcShedulesInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpGet("mfc/{Id}/services/count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Количество услуг по мфц")]
        public async Task<ActionResult<List<MfcServicesCountResponse>>> GetMfcServicesCountInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetMfcServicesCountInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("livingSituation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список жизненных ситуации")]
        public async Task<ActionResult<List<LivingSituationInfoResponse>>> GetLivingSituationsListInfo()
        {
            var response = await _referencesServiceAPI.GetLivingSituationsListInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("recipients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список получателей")]
        public async Task<ActionResult<List<ServicesRecipientsInfoResponse>>> GetRecipientsListInfo()
        {
            var response = await _referencesServiceAPI.GetRecipientsListInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("servicesType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список типов услуг")]
        public async Task<ActionResult<List<ServicesTypeInfoResponse>>> GetServicesTypeListInfo()
        {
            var response = await _referencesServiceAPI.GetServicesTypeListInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список услуг")]
        public async Task<ActionResult<List<ServicesListInfoResponse>>> GetServicesListInfo()
        {
            var response = await _referencesServiceAPI.GetServicesListInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/popular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список популярных услуг")]
        public async Task<ActionResult<List<ServicesPopularInfoResponse>>> GetServicesPopularListInfo()
        {
            var response = await _referencesServiceAPI.GetServicesPopularListInfo();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Информация об услуге")]
        public async Task<ActionResult<ServicesInfoResponse?>> GetServicesInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/livingSituation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список жизненных ситуаций к услуге")]
        public async Task<ActionResult<List<LivingSituationInfoResponse>>> GetServicesLivingSituationsInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesLivingSituationsInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/recipients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список получателей к услуге")]
        public async Task<ActionResult<List<ServicesRecipientsInfoResponse>>> GetServicesRecipientsInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesRecipientsInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/documents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список документов к услуге")]
        public async Task<ActionResult<List<ServicesDocumentsInfoResponse>>> GetServicesDocumentsInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesDocumentsInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/documentResults")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список результатов к услуге")]
        public async Task<ActionResult<List<ServicesDocumentResultsInfoResponse>>> GetServicesDocumentResultsInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesDocumentResultsInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/tariffs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список тарифов к услуге")]
        public async Task<ActionResult<List<ServicesTariffsInfoResponse>>> GetServicesTariffsInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesTariffsInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/reasons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список оснаваний к услуге")]
        public async Task<ActionResult<List<ServicesReasonsInfoResponse>>> GetServicesReasonsInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesReasonsInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/waysGets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список способов обращения к услуге")]
        public async Task<ActionResult<List<ServicesWaysGetsInfoResponse>>> GetServicesWaysGetsInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesWaysGetsInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/{Id}/files")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Список файлов к услуге")]
        public async Task<ActionResult<List<ServicesFilesInfoResponse>>> GetServicesFilesInfo([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesFilesInfo(Id);
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }

        [HttpGet("services/files/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Загрузка файла")]
        public async Task<IActionResult> GetServicesFilesDownload([FromRoute] Guid Id)
        {
            var response = await _referencesServiceAPI.GetServicesFileDownLoad(Id);
            if (response is null) return Problem("Ошибка загрузки файла.");
            return File(response.Content, MimeTypeMap.GetMimeType(response.Extensions), $"{response.Name}{response.Extensions}");
        }
    }
}
