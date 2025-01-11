using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.ReestrTransferDocuments;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.ViewModels.ReestrTransferDocuments;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Service
{
    public interface IReestrTransferDocuments
    {
        /// <summary>
        /// Список обращений
        /// </summary>
        /// <param name="employeeId">id сотрудника</param>
        /// <returns></returns>
        Task<(List<ReestrTransferDocumentsDto>, int, int)> GetReestrTransferDocuments(IDataTablesRequest request, List<Guid> officeId);
        Task<List<ReestrTransferDocumentsDto>> GetReestrTransferDocumentsV2(Guid? employeeId);
        Task<ReestrTransferDocumentsDto?> GetReestrTransferDocuments(Guid? id);
        Task<bool> EditReestrTransferDocuments(ReestrTransferDocumentsDto request);
        Task<List<CasesTransferDocumentDto>> GetCasesTransferDocuments(Guid? officeId, SearchTransferDocumentsRequestData requestData);
        Task<(List<ReestrCasesTransferDocumentsDTO>, int)> GetReestrTransferDocument(Guid id);
        Task<TransferDocumentsSaveResponce?> CasesTransferDocumentsSave(TransferDocumentsSaveRequest request, EmployeeInfo employee);
        Task<bool> CasesTransferDocumentsCommentsSave(TransferDocumentsCommentsSaveRequest request, EmployeeInfo employee);
        Task<byte[]> CasesTransferDocumentsPrint(byte[] content, Guid id, string connection, string employeeName, BlankActionType type);
    }
}
