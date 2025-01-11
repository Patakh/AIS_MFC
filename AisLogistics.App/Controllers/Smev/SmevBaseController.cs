using AisLogistics.App.Models;
using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Utils;
using GarService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;
using System.ServiceModel;

namespace AisLogistics.App.Controllers.Smev
{
    [Authorize]
    [ServiceContract]
    public partial class SmevBaseController : AbstractController
    {
        protected readonly ISmevService _smevService;
        protected readonly ICaseService _caseService;
        protected readonly IGarService _garService;

        public SmevBaseController(ICaseService caseService, ISmevService smevService, IGarService garService,
            IOptions<SmevSettings> smevOptions)
        {
            _caseService = caseService;
            _smevService = smevService;
            _garService = garService;
            SmevClient.Init(smevOptions.Value.SmevConnection, smevOptions.Value.AuthCode);
        }

        #region Details
        public IActionResult? GetSmevDetailsModal(Guid id)
        {
            var response = _smevService.GetSmevResponse(id);
            if (response.ResponseStatus.IsError)
            {
                ShowError(response.ResponseStatus.Message ?? "Произошла неизвестная ошибка");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    response.ResponseStatus.Message ?? "Произошла неизвестная ошибка");
            }

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalTitle("Информация о СМЭВ запросе")
                .AddModalType(ModalType.FULL)
                .AddModel(response)
                .HideSubmitButton()
                .AddModalViewPath("~/Views/Cases/Details/Modals/_ModalSmevDetails.cshtml");
            return ModalLayoutView(modelBuilder);
        }

        public IActionResult? GetArchiveSmevDetailsModal(Guid id)
        {
            var response = _smevService.GetArchiveSmevResponse(id);
            if (response.ResponseStatus.IsError)
            {
                ShowError(response.ResponseStatus.Message ?? "Произошла неизвестная ошибка");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    response.ResponseStatus.Message ?? "Произошла неизвестная ошибка");
            }

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalTitle("Информация о СМЭВ запросе")
                .AddModalType(ModalType.FULL)
                .AddModel(response)
                .HideSubmitButton()
                .AddModalViewPath("~/Views/Archive/Details/Modals/_ModalSmevDetails.cshtml");
            return ModalLayoutView(modelBuilder);
        }

        public async Task<IActionResult> DownloadFile(Guid id, DocumentType type)
        {
            var file = await _caseService.DownloadServicesFileAsync(id, type);
            if (file is null) return NotFound();
            return File(file.OpenReadStream(), file.ContentType, file.FileName);
        }

        public async Task<IActionResult> GetSmevForm(SmevCreateResponseModel model)
        {
            model.AddApplicants(await _caseService.GetApplicantsByServiceId(model.ServiceId));
            return PartialView(_smevService.GetSmevFormById(model.SmevId), model);
        }
        #endregion

        #region Dictonary
        /// <summary>
        /// Получение справочника
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public JsonResult SmevGetDictionary(DictionaryType type)
        {
            try
            {
                return Json(_smevService.SmevGetDictionary(type));
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }
        #endregion

        #region Поиск адресов в КЛАДР

        /// <summary>
        /// Поиск адреса в КЛАДР
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult KladrSearchAddress(string request)
        {
            try
            {
                return Json(_smevService.KladrSearchAddress(request));
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        #endregion

        #region Поиск адресов в ГАР

        /// <summary>
        /// Поиск адреса в ГАР
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GarSearchAddressExtended(GarFullTextSearchRequestData request)
        {
            try
            {
                return Json(_garService.SearchAddressExtended(request));
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        #endregion

        #region Attachments

        /// <summary>
        /// Запрос скачивание XML-логов запроса
        /// </summary>
        /// <param name="id">Индетификатор СМЭВ запроса услуги</param>>
        /// <returns></returns>
        public async Task<IActionResult> Smev_SaveXml(Guid id)
        {
            return File(await _smevService.SmevSaveXml(id), MimeTypeMap.GetMimeType(".zip"), $"{id}.zip");
        }

        /// <summary>
        /// Запрос скачивание документов прикрепленных к запросу
        /// </summary>
        /// <param name="id">Индетификатор СМЭВ запроса услуги</param>>
        /// <returns></returns>
        public async Task<IActionResult> Smev_SaveRequestAttachments(Guid id)
        {
            return File(await _smevService.SmevSaveRequestAttachments(id), MimeTypeMap.GetMimeType(".zip"), "RequestAttachments.zip");
        }

        /// <summary>
        /// Запрос скачивание вложений прикрепленных к ответу
        /// </summary>
        /// <param name="id">Индетификатор СМЭВ запроса услуги</param>>
        /// <returns></returns>
        public async Task<IActionResult> Smev_SaveResponseAttachments(Guid id)
        {
            return File(await _smevService.SmevSaveResponseAttachments(id), MimeTypeMap.GetMimeType(".zip"), "RequestAttachments.zip");
        }

        /// <summary>
        /// Запрос скачивание дополнительных форм прикрепленных к ответу
        /// </summary>
        /// <param name="id">Индетификатор СМЭВ запроса услуги</param>>
        /// <returns></returns>
        public async Task<IActionResult> Smev_SaveResponseAttachmentsForms(Guid id)
        {
            return File(await _smevService.SmevSaveResponseAttachmentsForms(id), MimeTypeMap.GetMimeType(".zip"), "ResponseAttachmentsDopForms.zip");
        }

        #endregion

        #region Utils

        [NonAction]
        protected ActionResult<string> SmevResponse<T>(T response) where T : SmevResponseData
        {
            if (response.ResponseReports is null || response.ResponseReports.Length == 0)
                return BadRequest(response.Fault?.ErrorText);

            return response.ResponseReports
                .Where(w => w.ReportType == ResponseReportType.Full)
                .Select(s => "data:application/pdf;base64," + Convert.ToBase64String(s.PdfDocument))
                .First();
        }

        #endregion
    }
}