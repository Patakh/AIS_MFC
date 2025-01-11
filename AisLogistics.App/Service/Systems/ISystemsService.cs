using AisLogistics.App.Models.DTO.Automatics;
using AisLogistics.App.Models.DTO.Systems;
using AisLogistics.App.ViewModels.Systems.Automatics;
using AisLogistics.App.ViewModels.Systems.Test;
using AisLogistics.DataLayer.Common.Dto.Systems;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Service.Systems
{
    public interface ISystemsService
    {
        Task<(List<Models.DTO.Systems.TestModelDto>, int, int)> GetTest(IDataTablesRequest request);
        Task<List<TestEmployeesModelDto>> GetTestEmployees(Guid Id);
        Task<byte[]?> GetTestEmployeesPrint(byte[] content, Guid id, string connection);
        Task<List<TestEmployeesQuestionModelDto>> GetTestEmployeesQuestionAndAnswer(Guid Id);
        Task<List<EmployeesQuestionResponseModel>?> GetEmployeesQuestionList(EmployeesQuestionRequestModel requestModel);
        Task<EmployeesQuestionResponseModel?> GetRefreshEmployeesQuestion(EmployeesQuestioRefreshRequestModel requestModel);
        Task<bool> EmployeesTestSave(EmployeesTestSaveRequestModel requestModel);


        Task<(List<TerminalDto>, int, int)> GetTerminal(IDataTablesRequest request);
        Task<TerminalModelDto?> GetTerminalDtoAsync(Guid? Id);
        Task AddTerminalAsync(TerminalModelDto model);
        Task UpdateTerminalAsync(TerminalModelDto model);
        Task RemoveTerminalAsync(Guid Id, string comment);


        Task<(List<AutomaticsDto>, int, int)> GetAutomaticsOperations(IDataTablesRequest request);
        Task<(List<AutomaticsLogsDto>, int, int)> GetAutomaticsOperationLogs(IDataTablesRequest request, SearchAutomaticLogsRequestData requestData);


        Task<(List<RoleDto>, int, int)> GetRoles(IDataTablesRequest request);
    }
}
