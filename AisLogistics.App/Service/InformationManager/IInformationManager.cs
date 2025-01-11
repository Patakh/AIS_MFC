using AisLogistics.App.Models.DTO.Information;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Service
{
    public interface IInformationManager
    {
        Task<List<EmployeeInformationDto>> GetInformationListAsync(int count);
        Task<InformationDetails?> GetInformationDetailssAsync(Guid id);
        Task<EmployeeWarningDto> GetWarningRousteStageListAsync();
        Task<List<EmployeeNotesDto>> GetNotesListAsync();
        Task<(List<EmployeeInformationDto>,int,int)> GetEmployeeInformationAsync(IDataTablesRequest? request);
        Task<List<RatingDto>> GetEmployeeRatingAsync(IDataTablesRequest? request, int typeId);
        Task<List<RatingDto>> GetOfficeRatingAsync(IDataTablesRequest? request, int typeId);
        Task<(List<EmployeeNotesDto>, int, int)> GetEmployeeNotesAsync(IDataTablesRequest? request);
        
    }
}
