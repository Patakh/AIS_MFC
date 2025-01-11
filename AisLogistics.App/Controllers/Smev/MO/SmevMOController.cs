using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.MO
{
    public class SmevMOController : SmevBaseController
    {
        public SmevMOController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Сведения о размере получаемой пенсии военнослужащих
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">2803</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMinoPensionAmount(Guid serviceId, int smevId, MinoPensionAmountRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}".Trim());
            var response = SmevClient.RequestMinoPensionAmount(request);
            return SmevResponse(response);
        }
    }
}