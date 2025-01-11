using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.Rosobrnadzor
{
    public class SmevRosobrnadzorController : SmevBaseController
    {
        public SmevRosobrnadzorController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Предоставление сведений о конкретной лицензии в виде выписки из реестра лицензий на
        /// осуществление образовательной деятельности либо справки об отсутствии запрашиваемых сведений в РЛОД
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">3201</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRlodInfo(Guid serviceId, int smevId, GetRlodInfoRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Inn ?? request.Ogrn}");
            var response = SmevClient.RequestRlodInfo(request);
            return SmevResponse(response);
        }
    }
}