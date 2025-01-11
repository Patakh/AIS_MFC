using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.ReestrUnclaimedDocuments;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.ViewModels.ReestrUnclaimedDocuments;
using DataTables.AspNet.Core;


namespace AisLogistics.App.Service
{
    public interface IReestrUnclaimedDocuments
    {
        /// <summary>
        /// Список обращений
        /// </summary>
        /// <param name="employeeId">id сотрудника</param>
        /// <returns></returns>
        Task<(List<ReestrUnclaimedDocumentsDto>, int, int)> GetReestrUnclaimedDocuments(IDataTablesRequest request, List<Guid> officeId);
        Task<List<ReestrUnclaimedDocumentsDto>> GetReestrUnclaimedDocumentsV2(Guid? employeeId);
        Task<(List<ReestrCasesUnclaimedDocumentsDTO>, int, int)> GetReestrUnclaimedDocument(IDataTablesRequest request, SearchCasesUnclaimedDocumentsRequestData search);
        Task<ReestrUnclaimedDocumentsDto?> GetReestrUnclaimedDocuments(Guid? id);
        Task<bool> EditReestrUnclaimedDocuments(ReestrUnclaimedDocumentsDto request);
        Task<List<CasesUnclaimedDocumentDto>> GetCasesUnclaimedDocuments(Guid? employeeId, SearchUnclaimedDocumentsRequestData requestData);
        Task<(List<ReestrCasesUnclaimedDocumentsDTO>, int)> GetReestrUnclaimedDocument(Guid id);
        Task<UnclaimedDocumentsSaveResponce?> CasesUnclaimedDocumentsSave(UnclaimedDocumentsSaveRequest request, EmployeeInfo employee);
        Task<bool> CasesUnclaimedDocumentsCommentsSave(UnclaimedDocumentsCommentsSaveRequest request, EmployeeInfo employee);
        Task<byte[]> CasesUnclaimedDocumentsPrint(byte[] content, Guid id, string connection, string employeeName, BlankActionType type);
    }
}
