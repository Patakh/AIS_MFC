using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Template;
using AisLogistics.App.ViewModels.Filter;
using System.Threading.Tasks;

namespace AisLogistics.App.Service
{
    public interface IFilterManager
    {
        Task<List<OfficeDto>> GetProvidersDataJson();
        Task<List<ServicesDto>> GetServicesForProviderDataJson(List<Guid> providersId);
        Task<List<FilterOfficeModel>> GetOfficesReceptionCustomerDataJson(bool isAll);
        Task<List<FilterOfficeModel>> GetOfficesReceptionAllCustomerDataJson(bool isAll, bool isGroup);
        Task<List<FilterOfficeModel>> GetOfficesReceptionDepartamentCustomerDataJson(bool isAll);
        Task<List<FilterOfficeModel>> GetOfficesReceptionEmployeeCustomerDataJson(bool isAll);
        Task<List<OfficeDto>> GetEmployeesForReceptionOfficeDataJson(List<Guid> officesId);
        Task<List<SmevServiceDto>> GetSmevServicesDataJson();
        Task<List<SmevRequestDto>> GetRequestForSmevServicesDataJson(List<Guid> smevServicesId);
        Task<List<ServiceCustomerTypeDto>> GetServiceCustomerTypeDataJson(bool isAll);
        Task<List<SelectListDto<int>>> GetServiceTypeDataJson();
        Task<List<SelectListDto<int>>> GetServiceInteractionTypeDataJson();
        Task<List<SelectListDto<int>>> GetServiceStatusDataJson();
        Task<List<SelectListDto<int>>> GetServiceRouteStagesDataJson();
        Task<List<SelectListDto<int>>> GetServiceHashtagDataJson();
        Task<List<OfficeSpsDto>> GetSpsMfcDataJson();
        Task<FilterOfficeResponseModel> GetOfficesAllIdForReceptionCustomer(List<string> office, bool isAllOfficeId, bool isAddOfficeName);
        Task<FilterOfficeResponseModel> GetOfficesDepartamentIdForReceptionCustomer(List<string> office, bool isAllOfficeId, bool isAddOfficeName);
        Task<FilterOfficeResponseModel> GetOfficesEmployeeIdForReceptionCustomer(List<string> office, bool isAllOfficeId, bool isAddOfficeName);
        Task<FilterOfficeResponseModel> GetOfficesIdForReceptionCustomer(List<string> office, bool isAllOfficeId, bool isAddOfficeName);
    }
}
