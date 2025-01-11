using GarService;

namespace AisLogistics.App.Service
{
    public interface IGarService
    {
        GarFullTextSearchExtendedResponseData SearchAddressExtended(GarFullTextSearchRequestData request);
    }
}
