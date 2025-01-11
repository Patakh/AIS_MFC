using System.Text;
using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.MinTrud
{
    public class SmevFsspController : SmevBaseController
    {
        public SmevFsspController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
           : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Заявление о наличии исполнительных производств в банке данных
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1303</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestIpExistInteractive(Guid serviceId, int smevId, GetIpExistInteractiveRequestData[] request, List<string> ServiceCode, List<string> DepartmentId)
        {
            List<string> requestErrors = new();
            GetIpExistInteractiveResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.DebtorFlData?.Fio.LastName} {item.DebtorFlData?.Fio.FirstName} {item.DebtorFlData?.Fio.SecondName}".Trim());
                var response = SmevClient.RequestIpExistInteractive(item);
                if (response.Fault != null)
                {
                    requestErrors.Add($"Запрос #{i}: {response.Fault.ErrorText}");
                }
                else
                {
                    requestSucceeded = response;
                }
            }

            if (requestErrors.Any())
            {
                return SmevResponse(new SmevResponseData
                {
                    Fault = new SmevFault
                    {
                        ErrorText = string.Join("\n", requestErrors)
                    }
                });
            }
            return SmevResponse(requestSucceeded);
        }

        /// <summary>
        /// Заявление о предоставлении информации о ходе исполнительного производства из банка данных - 1304
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1304</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestIpSideInteractive(Guid serviceId, int smevId, GetIpSideInteractiveRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.DebtorFlData?.Fio.LastName} {request.DebtorFlData?.Fio.FirstName} {request.DebtorFlData?.Fio.SecondName}".Trim());
            var response = SmevClient.RequestIpSideInteractive(request);
            return SmevResponse(response);
        }
    }
}
