using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.MinSvyazi
{
    public class SmevMinSvyaziController : SmevBaseController
    {
        public SmevMinSvyaziController (ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Направление электронных дубликатов документов заявителя В ЛК ЕПГУ
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1122</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> SendElectronicDuplicatesLk(Guid serviceId, int smevId, SendElectronicDuplicatesLkRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.UserFio.LastName} {request.UserFio.FirstName} {request.UserFio.SecondName}");
            var response = SmevClient.SendElectronicDuplicatesLk(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Отправка по инициативе МФЦ в ЕБС сообщений о событиях, связанных с отказом пользователя от сбора биометрии
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1131</param>
        /// <param name="request"></param>
        /// <param name="fio">ФИО</param> 
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestNbpRefuseBioChange(Guid serviceId, int smevId, NbpRefuseBioChangeRequestData request, FioType fio)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{fio.LastName} {fio.FirstName} {fio.SecondName}".Trim());
            var response = SmevClient.RequestNbpRefuseBioChange(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Запрос в ЕБС статуса отказа ФЛ от сбора биометрии
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1132</param>
        /// <param name="request"></param>
        /// <param name="fio">ФИО</param> 
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestNbpRefuseBioStatus(Guid serviceId, int smevId, NbpRefuseBioStatusRequestData request, FioType fio)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{fio.LastName} {fio.FirstName} {fio.SecondName}".Trim());
            var response = SmevClient.RequestNbpRefuseBioStatus(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Получение документов для выпуска УКЭП
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1133</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> GoskeyGetDocuments(Guid serviceId, int smevId, GoskeyGetDocumentRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Series} {request.Number}".Trim());
            var response = SmevClient.GoskeyGetDocuments(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Загрузка сканов документов для выпуска УКЭП
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1134</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> GoskeyPutDocuments(Guid serviceId, int smevId, GoskeyPutDocumentRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.WorkflowId}".Trim());
            var response = SmevClient.GoskeyPutDocuments(request);
            return SmevResponse(response);
        }
    }
}