using AisLogistics.App.Settings;
using GarService;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;

namespace AisLogistics.App.Service
{
    public class GarService : IGarService
    {
        public GarService(IOptions<SmevSettings> smevOptions)
        {
            GarClient.Init(smevOptions.Value.GarConnection, smevOptions.Value.AuthCode);
        }

        public GarFullTextSearchExtendedResponseData SearchAddressExtended(GarFullTextSearchRequestData request)
        {
            return GarClient.FullTextSearchExtended(request);
        }
    }
}
