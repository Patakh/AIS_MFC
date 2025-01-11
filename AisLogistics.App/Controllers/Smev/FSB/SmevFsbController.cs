using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.FK
{
    public class SmevFsbController : SmevBaseController
    {
        public SmevFsbController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Передача сведений о размере получаемой пенсии и других выплат, учитываемых при расчете совокупного дохода семьи (одиноко проживающего гражданина)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">3101</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFsbFamilyPayments(Guid serviceId, int smevId, FsbFamilyPaymentsRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestFsbFamilyPayments(request);
            return SmevResponse(response);
        }
    }
}