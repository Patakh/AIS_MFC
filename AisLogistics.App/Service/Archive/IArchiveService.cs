using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.Archive;

namespace AisLogistics.App.Service
{
    public interface IArchiveService
    {
        /// <summary>
        /// Список обращений
        /// </summary>
        /// <param name="searchData">данные для поиска</param>
        /// <param name="start">skip</param>
        /// <param name="length">take</param>
        /// <returns></returns>
        (List<CasesDto> Cases, int Count, int FilteredCount) GetCases(SearchArchiveCasesRequestData searchData, int start, int length);
        /// <summary>
        /// Обращение по id 
        /// </summary>
        /// <param name="id">id услуги</param>
        /// <returns></returns>
        Task<ArchiveCaseDetailsDto> GetCaseDetailsByIdAsync(string id);
        Task<FormFile?> DownloadServicesFileAsync(Guid id, DocumentType type);
        Task<CaseServiceBlankFile> GetServiceBlankFileByIdAsync(Guid id);
        Task<List<CaseServiceBlank>> GetServiceBlanksByCaseIdAsync(string id);
    }
}