using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.FK
{
    public class SmevFsaController : SmevBaseController
    {
        public SmevFsaController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Предоставление сведений из Реестра аккредитованных лиц
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">3401</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFsaRosaccreditationRap(Guid serviceId, int smevId, FsaRosaccreditationRapRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.ApplicantName}");
            var response = SmevClient.RequestFsaRosaccreditationRap(request);
            return SmevResponse(response);
        }
    }
}