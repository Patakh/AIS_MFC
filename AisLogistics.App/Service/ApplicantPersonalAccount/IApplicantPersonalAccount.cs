using AisLogistics.App.Models.DTO.ApplicantPersonalAccount;
using AisLogistics.App.ViewModels.ApplicantPersonalAccount;
using AisLogistics.DataLayer.Common.Dto.Case;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Service.ApplicantPersonalAccount
{
    public interface IApplicantPersonalAccount
    {
        Task<(List<ReestrApplicantDto>, int, int)> GetReestrApplicants(IDataTablesRequest request, SearchApplicantsRequestData search);
        Task<(List<ReestrApplicantCasesDto>, int, int)> GetApplicantCases(IDataTablesRequest request, SearchApplicantCasesRequestData search);
        Task<(List<ReestrApplicantCasesArchiveDto>, int, int)> GetApplicantCasesArchive(IDataTablesRequest request, SearchApplicantCasesArchiveRequestData search);
        Task<(List<ReestrApplicantCasesHistoryDto>, int, int)> GetApplicantCasesHistory(IDataTablesRequest request, SearchApplicantCasesHistoryRequestData search);
        Task<CustomerModelDto?> GetApplicantModelDto(Guid Id);
    }
}
