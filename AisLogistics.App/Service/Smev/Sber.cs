using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Service
{
    public partial class SmevService : ISmevService
    {
        public SberHybridInitiatePaymentResponseData SberHybridInitiatePayment(SberHybridInitiatePaymentRequestData request)
        {
            return SmevClient.SberHybridInitiatePayment(request);
        }

        public SberHybridGetQuittanceResponseData SberHybridGetQuittance(SberHybridGetQuittanceRequestData request)
        {
            return SmevClient.SberHybridGetQuittance(request);
        }
    }
}
