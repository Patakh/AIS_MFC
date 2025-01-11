using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.Identity.Applicant;
using AisLogistics.App.Models.DTO.ReestrTransferDocuments;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ReestrTransferDocuments;
using AisLogistics.DataLayer.Common.Dto.Case;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Service
{
    public interface ICaseService
    {
        /// <summary>
        /// Список обращений
        /// </summary>
        /// <param name="employeeId">id сотрудника</param>
        /// <returns></returns>
        Task<(List<CasesDto>, int, int)> GetCases(IDataTablesRequest request, SearchCasesRequestData additionalRequest);
        Task<CasesServiceCopyDto?> CasesServiceCopy(Guid Id);
        Task<CasesServiceCopyDto?> CasesServiceCopy(string Id);
        Task<string?> CasesServiceCopySave(CasesServiceCopySaveDto request);
        Task<(List<CasesDto>, int, int)> GetIssueCases(IDataTablesRequest request, SearchCasesRequestData additionalRequest);
        Task<(List<CasesReestrSmevDto>, int, int)> GetCasesReestrSmev(IDataTablesRequest request, SearchCasesRequestData additionalRequest);
        Task<List<CasesIncomingDocumentDto>> GetCasesIncomingDocuments(Guid? officeId, SearchIncomingDocumentsRequestData requestData);


        /// <summary>
        /// Услуги по id обращения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<CasesDto?> GetServicesByCaseIdAsync(string id);
        Task<CaseServiceDto?> GetCasesServicesAsync(Guid id);
        Task<CaseServiceDto?> GetCasesServicesParentAsync(string id);

        Task ViewCaseAsync(string id);
        Task SetCaseFavoriteAsync(string id);
        Task RemoveCaseFavoriteAsync(string id);
        Task SetServiceFavoriteAsync(Guid id);
        Task RemoveServiceFavoriteAsync(Guid id);
        /// <summary>
        /// Список активных услуг для Физ.лиц
        /// </summary>
        /// <param name="searchData">данные для поиска</param>
        /// <param name="start">skip</param>
        /// <param name="length">take</param>
        /// <returns></returns>
        Task<(List<ActiveServicesDto>, int, int)> GetActiveServices(SearchCasesRequestData searchData, int start,
            int length);


        /// <summary>
        /// Процедуры услуги
        /// </summary>
        /// <param name="serviceId">id услуги</param>
        /// <returns></returns>
        Task<List<ActiveServiceProcedureDto>> GetServiceProcedures(Guid serviceId);
        /// <summary>
        /// Тарифы услуги
        /// </summary>
        /// <param name="procedureId">id процедуры</param>
        /// <returns></returns>
        Task<List<ActiveServiceTariffDto>> GetServiceTariff(Guid procedureId, int? type);
        /// <summary>
        /// Поставщики услуг
        /// </summary>
        /// <param name="serviceId">id услуги</param>
        /// <returns></returns>
        Task<List<ActiveServiceProviderDto>> GetServiceProvidersAll();
        /// <summary>
        /// Создание услуги
        /// </summary>
        /// <param name="requestModel">Модель услуги</param>
        /// <returns></returns>
        Task<CreateCaseResponseModel> CreateCaseAsync(CreateCaseRequestModel requestModel);
        /// <summary>
        /// Список выполненных СМЭВ запросов по id услуги
        /// </summary>
        /// <param name="id">Id услуги</param>
        /// <returns></returns>
        /// 
        Task<List<CaseServiceSmevСompletedDto>> GetSmevСompletedByServiceIdAsync(Guid id);
        Task<List<CaseServicePaymentsСompletedDto>> GetPaymentsСompletedByServiceIdAsync(Guid id);
        Task<ServicePaymentsInfo?> GetPaymentsInfoServiceIdAsync(Guid id);
        Task<Guid?> AddServicePaymentAsync(ServicePaymentsRequestModelAddDto request);
        bool IsCheckServicePaymentAsync(Guid Id);

        /// <summary>
        /// Список возможных СМЭВ запросов, для добавления нового запроса в услугу
        /// </summary>
        /// <param name="id">Id услуги</param>
        /// <param name="search">строка поиска</param>
        /// <param name="start">skip</param>
        /// <param name="length">take</param>
        /// <returns></returns>
        Task<(List<CaseServiceSmevActiveDto>, int, int)> GetSmevActiveByServiceId(Guid id, string search, int start, int length);

        Task<List<ApplicantAdditionalDto>> GetApplicantsByServiceId(Guid id);

        Task<List<CaseServiceStageDto>> GetStagesByServiceIdAsync(Guid id);
        Task<List<StageDto>> GetStagesNextAllAsync(List<Guid> id);
        Task<List<StageDto>> GetStagesNextByServiceIdAsync(List<Guid> id);
        Task<List<EmployeesDtO>?> GetStagesNextEmployessByServiceIdAsync(ServiceStageNextEmployessDto request);

        Task<bool> AddServiceStageAsync(ServiceStageSaveDto request);
        Task<(bool, int)> AddServiceStageUnclaimedAsync(ServiceStageSaveDto request);

        Task<NotesAddDto?> GetServiceNoteAsync(Guid id);
        Task<bool> AddServiceNotesAsync(NotesAddSaveDto request);
        Task<bool> EditServiceNotesAsync(NotesAddSaveDto request);
        Task<bool> DeleteServiceNotesAsync(Guid id);

        Task AddServiceDepartamentAsync(ServiceDepartamentsDto model);

        Task<List<CaseServiceDocumentsDto>> GetDocumentsByServiceIdAsync(Guid id);
        Task<List<CaseServiceDocumentsDto>> GetDocumentsByServiceIdAsync(string id);
        Task<List<CaseServiceDocumentsDto>> GetDocumentsIssuanceByServiceIdAsync(string id);
        Task<List<CaseServiceDocumentsResultsDto>> GetDocumentsResultsByServiceIdAsync(Guid id);
        Task<CaseServiceDocumentsDto?> GetServiceDocumentsIdAsync(Guid id);
        Task<bool> UploadServicesDocumentsIsCheckAsync(Guid id, bool isCheck);
        Task<bool> UploadServicesDocumentsIsCheckAsync(List<DocumentsPrintDto> doc);
        Task<bool> UploadServicesDocumentsIssuanceIsCheckAsync(List<DocumentsPrintDto> doc);
        Task<ServiceFileResponseModel> UploadServicesFileAsync(Guid id, DocumentFileAddType fileAddType, IFormFile file);
        Task<ServiceFileResponseModel> UploadServicesFilesAsync(Guid id, DocumentFileAddType fileAddType, IFormFileCollection files);
        Task<ServiceFileResponseModel> RemoveServicesFileAsync(Guid id);
        Task<ServiceFileResponseModel> UploadServicesFileResultAsync(Guid id, DocumentFileAddType fileAddType, IFormFile file);
        Task<ServiceFileResponseModel> RemoveServicesFileResultAsync(Guid id);
        Task<FormFile?> DownloadServicesFileAsync(Guid id, DocumentType type);

        Task DocumentServiceAddSave(List<ServiceDocumentsDto> request);
        Task DocumentServiceAddSave(ServiceDocumentsDto request);
        Task DocumentServiceAddNewNameSave(ServiceDocumentNewNameDto request);

        Task<CaseServiceBlankFile> GetServiceBlankByIdAsync(Guid id);

        Task<CaseServiceBlankFile> GetServiceFileByIdAsync(Guid id);
        Task<List<CaseCommentsDto>> GetCommentsByCaseIdAsync(string id);
        Task<CaseNotificationsDto> GetNotificationsByCaseIdAsync(string id);
        Task<bool> SaveSMSCaseAsync(CasesSMSSaveDto request, EmployeeInfo employee);
        Task<string> AddNotificationsByCaseIdAsync(string caseid, Guid customerId, string tel);
        Task<CaseCommentsDto> AddCommentAsync(string id, string comment, Guid[] employeesId);
        Task<List<CaseAuditDto>> GetServiceAuditByCaseIdAsync(string id);

        Task<(Guid ServiceId, string? FormPath)> GetAdditionalFormByCaseIdAsync(Guid id);
        Task<T?> GetAdditionalDataByServiceIdAsync<T>(Guid id);
        Task SaveAdditionalData(Guid id, string data, Dictionary<string, string> search);

        Task<List<CaseServiceBlank>?> GetServiceBlanksByCaseIdAsync(Guid id);
        Task<List<CaseServiceBlank>?> GetServiceFilesByCaseIdAsync(Guid id);


        Task<CustomerModelDto?> GetCustomerByDocumentSerialAndNumberAsync(string serial, string number); //TODO переделать
        Task<LegalsDto?> GetLegalByInnAsync(string inn); //TODO переделать
        Task<List<ApplicantDto>> GetCustomersByCaseNumberAsync(string caseId);
        Task<CustomerServiceModelDto?> GetCustomerByIdAsync(Guid id); //TODO переделать
        Task<DServicesCustomersLegal?> GetCustomerLegalByIdAsync(Guid id); //TODO переделать

        Task<CaseCustomerResponseModel> UpdateCustomerAsync(CustomerServiceModelDto request); //TODO переделать
        Task<CaseCustomerResponseModel> UpdateCustomerLegalAsync(DServicesCustomersLegal customer); //TODO переделать


        byte[] GetBlancFastReportFileAsync(byte[] content, Guid serviceId, BlankActionType blankActionType);
        byte[]? GetBlancDocxFileAsync(byte[] content, Guid serviceId);
        Task<byte[]> GetPrintProcessingPersonalData(string caseId, BlankActionType type);
        Task<byte[]> GetPrintConsultationService(string caseId, BlankActionType type);
        Task<byte[]> GetPrintAcceptDocuments(string caseId, BlankActionType type, List<DocumentsPrintDto> doc);
        Task<byte[]> GetPrintIssuanceDocuments(string caseId, BlankActionType type, List<DocumentsPrintDto> doc);
    }
}