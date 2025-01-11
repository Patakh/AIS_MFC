using AisLogistics.API.Models.Dto;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Models.Responce.References;

namespace AisLogistics.API.Service
{
    public interface IReferencesServiceAPI
    {
        Task<List<ServiceInfoResponse>?> GetServiceInfo();
        Task<List<ServiceOfficeInfoResponse>?> GetServiceOfficeInfo(int periodId);
        Task<List<ServiceStaticDataMfcResponse>?> GetServiceStaticDataMfc();
        Task<List<ServiceStateTaskInfoResponse>?> GetServiceStateTaskInfo();
        Task<List<MfcListInfoResponse>?> GetMfcListInfo();
        Task<List<MfcShedulesInfoResponse>?> GetMfcShedulesInfo(Guid Id);
        Task<List<MfcServicesCountResponse>?> GetMfcServicesCountInfo(Guid Id);
        Task<List<ProvidersInfoResponse>?> GetProvidersListInfo();
        Task<List<ServicesRecipientsInfoResponse>?> GetRecipientsListInfo();
        Task<List<LivingSituationInfoResponse>?> GetLivingSituationsListInfo();
        Task<List<ServicesTypeInfoResponse>?> GetServicesTypeListInfo();
        Task<List<ServicesListInfoResponse>?> GetServicesListInfo();
        Task<List<ServicesPopularInfoResponse>?> GetServicesPopularListInfo();
        Task<ServicesInfoResponse?> GetServicesInfo(Guid Id);
        Task<List<LivingSituationInfoResponse>?> GetServicesLivingSituationsInfo(Guid Id);
        Task<List<ServicesRecipientsInfoResponse>?> GetServicesRecipientsInfo(Guid Id);
        Task<List<ServicesDocumentsInfoResponse>?> GetServicesDocumentsInfo(Guid Id);
        Task<List<ServicesDocumentResultsInfoResponse>?> GetServicesDocumentResultsInfo(Guid Id);
        Task<List<ServicesTariffsInfoResponse>?> GetServicesTariffsInfo(Guid Id);
        Task<List<ServicesWaysGetsInfoResponse>?> GetServicesWaysGetsInfo(Guid Id);
        Task<List<ServicesReasonsInfoResponse>?> GetServicesReasonsInfo(Guid Id);
        Task<List<ServicesFilesInfoResponse>?> GetServicesFilesInfo(Guid Id);
        Task<FileDownLoanDto?> GetServicesFileDownLoad(Guid Id);
    }
}
