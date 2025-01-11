using AisLogistics.API.Models.Request;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Service;
using AisLogistics.DataLayer.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AisLogistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IASMKGUController : ControllerBase
    {
        private readonly IReferencesServiceAPI _referencesServiceAPI;
        private readonly IIasMkguQuestionServiceAPI _iasMkguQuestionServiceAPI;
        public IASMKGUController(IReferencesServiceAPI referencesServiceAPI, IIasMkguQuestionServiceAPI iasMkguQuestionServiceAPI)
        {
            _iasMkguQuestionServiceAPI = iasMkguQuestionServiceAPI;
            _referencesServiceAPI = referencesServiceAPI;
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<IasMkguQuestionResponse>>?> GetIasMkguQuestion()
        {
            var response = await _iasMkguQuestionServiceAPI.GetAllIasMkguQuestionAsync();
            if (response is null) return Problem("Ошибка при выполнение запроса");
            return response;
        }
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostIasMkguQuestionAnswer(SaveIasMkguQuestionRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ErrorDescription.InvalidInputParameters);
            };

            var responce  = await _iasMkguQuestionServiceAPI.SaveIasMkguInformatAnswerAsync(request);
            return responce.Success ? Ok() : Problem("Ошибка при сохранение");
        }
    }
}
