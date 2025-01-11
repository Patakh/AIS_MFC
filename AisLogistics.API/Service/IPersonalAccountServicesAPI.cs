using AisLogistics.API.Models.Request.PersonalAccount;
using AisLogistics.API.Models.Responce;

namespace AisLogistics.API.Service
{
    public interface IPersonalAccountServicesAPI
    {
        public Task<CasesInfoResponse?> GetCasesInfo (string username);
        Task<List<CasesExecutioninfoResponse>?> GetCasesExecutionInfo(CasesExecutionInfoRequest request);
    }
}
