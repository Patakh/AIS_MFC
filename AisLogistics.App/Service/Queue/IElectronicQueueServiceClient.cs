using AisLogistics.App.Models.Queue;
using QueueReference;

namespace AisLogistics.App.Service.Queue
{
    public interface IElectronicQueueServiceClient
    {
        Task<ListAbonDelayResponseClient> ListAbonDelay(ListAbonDelayRequest requestData);
        Task<ListAbonInQueueResponseClient> ListAbonInQueue(ListAbonInQueueRequest requestData);
        Task<ListAbonRedirectResponseClient> ListAbonRedirect(ListAbonRedirectRequest requestData);
        Task<ListWindowResponseClient> ListWindow(ListWindowRequest requestData);
        Task<RedirectAbonResponse> AbonRedirect(RedirectAbonRequest requestData);
        Task<DelayAbonResponse> DelayAbon(DelayAbonRequest requestData);
        Task<NextAbonRedirectResponse> NextAbonRedirect(NextAbonRedirectRequest requestData);
        Task<NextAbonDelayResponse> NextAbonDelay(NextAbonDelayRequest requestData);
        Task<NextAbonResponse> NextAbon(NextAbonRequest requestData);
        Task<NextAbonResponseClient> NextAbonVIP(NextAbonVIPRequest requestData);
        Task<NumAbonOnWindowResponseClient> NumAbonOnWindow(CountAbonRequestClient requestData);
        Task<CountAbonResponseClient> CountAbon(CountAbonRequestClient requestData);
        Task<FGIS_MDMResponse> FgisMdm(FGIS_MDMRequest requestData);
    }
}
