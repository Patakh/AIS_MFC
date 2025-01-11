using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.FK
{
    public class SmevFkController : SmevBaseController
    {
        public SmevFkController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Предоставление необходимой для уплаты информации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1203</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestExportCharge(Guid serviceId, int smevId, FkExportChargeRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.PayerOtherData?.InnFl ?? request.PayerOtherData?.Snils}");
            var response = SmevClient.RequestExportCharge(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление информации об уплате
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1204</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestExportPayment(Guid serviceId, int smevId, FKExportPaymentRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.PayerOtherData?.InnFl ?? request.PayerOtherData?.Snils}");
            var response = SmevClient.RequestExportPayment(request);
            return SmevResponse(response);
        }
        /// <summary>
        /// Предоставление информации о результатах квитирования
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1205</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestExportQuittanc(Guid serviceId, int smevId, FkExportQuittanceRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.SupplierBillId[0]}");
            var response = SmevClient.RequestExportQuittance(request);
            return SmevResponse(response);
        }
    }
}