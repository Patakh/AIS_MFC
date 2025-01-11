using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Service
{
    public partial class SmevService : ISmevService
    {
        public RostransPassengersVehiclesResponseData RostransPassengersVehiclesRequestData(RostransPassengersVehiclesRequestData request)
        {
            return SmevClient.RequestRostransPassengersVehicles(request);
        }
    }
}
