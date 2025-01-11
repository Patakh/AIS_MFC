using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Entities.Models;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.Rospotrebnadzor
{
    public class SmevRospotrebnadzorController : SmevBaseController
    {

        public SmevRospotrebnadzorController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {

        }

        /// <summary>
        /// Прием уведомлений о начале осуществления отдельных видов предпринимательской деятельности
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">608</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestSendNotice3(Guid serviceId, int smevId, SendNotice3RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.IpFio.FirstName} {request.IpFio.FirstName} {request.IpFio.SecondName}");
            var response = SmevClient.RequestRnNotice3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Получение справки о соответствии (несоответствии) жилых помещений (зданий) требованиям
        /// санитарного законодательства при оформлении опеки или попечительства
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">610</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRnOpeka3(Guid serviceId, int smevId, SendOpeka3RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestRnOpeka3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Получение сведений из санитарно-эпидемиологических заключений о соответствии (несоответствии) 
        /// видов деятельности (работ, услуг) требованиям гос. санитарно-эпидемиологических правил и нормативов
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">611</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRnSezm3(Guid serviceId, int smevId, SendSezm3RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Inn ?? request.Ogrn}");
            var response = SmevClient.RequestRnSezm3(request);
            return SmevResponse(response);
        }

    }
}