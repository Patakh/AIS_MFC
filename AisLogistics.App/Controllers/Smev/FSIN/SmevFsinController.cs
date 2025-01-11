using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.FSIN
{
    public class SmevFsinController : SmevBaseController
    {
        public SmevFsinController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Сведения о нахождении граждан в исправительном учреждении
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">2701</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFsinPenitentiary(Guid serviceId, int smevId, FsinPenitentiaryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestFsinPenitentiary(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Сведения о размере выплат пенсионерам, состоящим на учете в отделе пенсионного обслуживания ФСИН России
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">2702</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFsinPaymentsPensioners(Guid serviceId, int smevId, FsinPaymentsPensionersRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestFsinPaymentsPensioners(request);
            return SmevResponse(response);
        }
    }
}