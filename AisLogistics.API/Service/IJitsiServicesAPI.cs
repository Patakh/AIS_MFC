using AisLogistics.API.Models.Dto;
using AisLogistics.API.Models.Request.Jitsi;
using AisLogistics.API.Models.Response.Jitsi;

namespace AisLogistics.API.Service
{
    public interface IJitsiServicesAPI
    {
        Task<SearchCustomerDto?> GetSearchCustomer(SearchCustomerRequest request);
        Task<List<SearchCustomerCaseDto>?> GetSearchCustomerCase(SearchCustomerCaseRequest request);
        Task<SaveCallResponse> SaveCallAsync(SaveCallRequest request);
    }
}
