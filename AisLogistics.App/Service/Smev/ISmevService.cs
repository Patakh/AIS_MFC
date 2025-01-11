using AisLogistics.App.ViewModels.Cases;
using AisLogistics.DataLayer.Common.Dto.Case;
using SmevRouter;

namespace AisLogistics.App.Service
{
    public interface ISmevService
    {
        #region Details
        string GetSmevFormById(int id);
        SmevDetailsResponseModel GetSmevResponse(Guid id);
        SmevDetailsResponseModel GetArchiveSmevResponse(Guid id);
        Task<string> CreateNewSmevRequestAsync(Guid servicesId, int smevId, string comment, string idRef = null);
        #endregion

        #region Dictonary
        DictionaryResponseData SmevGetDictionary(DictionaryType type);
        #endregion

        #region Поиск адресов в КЛАДР 
        KladrSearchResponse KladrSearchAddress(string request);
        #endregion

        #region Attachments
        Task<byte[]> SmevSaveXml(Guid id);
        Task<byte[]> SmevSaveRequestAttachments(Guid id);
        Task<byte[]> SmevSaveResponseAttachments(Guid id);
        Task<byte[]> SmevSaveResponseAttachmentsForms(Guid id);
        #endregion

        #region Customer
        Task GetCustomerSnils(Guid dServiceId, CustomerModelDto customer);
        Task GetCustomerInn(Guid dServiceId, CustomerModelDto customer);
        #endregion

        #region Rostransnadzor
        RostransPassengersVehiclesResponseData RostransPassengersVehiclesRequestData(RostransPassengersVehiclesRequestData request);
        #endregion

        #region Sber
        SberHybridInitiatePaymentResponseData SberHybridInitiatePayment(SberHybridInitiatePaymentRequestData request);
        SberHybridGetQuittanceResponseData SberHybridGetQuittance(SberHybridGetQuittanceRequestData request);
        #endregion
    }
}
