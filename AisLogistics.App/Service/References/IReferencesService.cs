using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Models.DTO.Template;
using AisLogistics.App.ViewModels.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Service
{
    public interface IReferencesService
    {
        #region Документы
        Task<(List<DocumentsDto>, int, int)> GetDocuments(IDataTablesRequest request);
        Task<DocumentModelDto?> GetDocumentsDtoAsync(Guid? Id);
        Task AddDocumentAsync(DocumentModelDto model);
        Task UpdateDocumentAsync(DocumentModelDto model);
        Task RemoveDocumentAsync(Guid Id, string comment);
        Task<List<DocumentsDto>> GetAllDocumentsAsync();

        #endregion

        #region Офисы

        /// <summary>
        /// Поучить список офисов
        /// </summary>
        /// <param name="request">Запрос</param>
        Task<(List<OfficeParentsDto>, int, int)> GetOffices(IDataTablesRequest request, int type);
        Task<(List<OfficeTypeDto>, int, int)> GetOfficesType(IDataTablesRequest request);
        Task<List<OfficeParentsDto>> GetOfficesParentAllAsync();
        Task<List<OfficeDto>> GetTospForMfcDtoAsync(Guid id);
        Task<List<OfficeDto>> GetActiveEmployeeOfficesDtoAsync(Guid id);
        Task<OfficeDto?> GetActiveEmployeeOfficeDtoAsync(Guid id);
        Task<List<OfficeDto>> GetAllOfficesAsync();
        Task<List<OfficeDto>> GetAllOfficesTypeAsync(int? type);
        Task<List<OfficeDto>> GetAllOfficesTypeMfcAsync();
        Task<List<OfficeDto>> GetAllOfficesTypeMfcAndTospAsync();
        Task<List<OfficeDto>?> GetAuthorizationOfficesAsync(Guid aspNetUserIdid );
        Task<List<OfficeDto>> GetAllOfficesTypeMfcAndTospAsync(List<Guid> id);
        Task<List<OfficeDto>> GetOfficesProvidersAll();
        Task<List<OfficeDto>> GetOfficesProvidersAll(List<Guid> id);
        Task<List<OfficeDto>> GetOfficesProvidersDepartement(Guid id);
        Task<List<OfficeDto>> GetOfficesProvidersDepartement(List<Guid> id);
        Task<OfficeDto> GetOfficeForQueueAsync(int queueId);
        Task<List<EmployeeInfo>> GetEmployeesForQueueAsync(Guid officeId);
        Task<List<OfficeQueueDto>> GetOfficesQueueAsync();

        Task<OfficeModelDto> GetOfficeModelDtoAsync(Guid? Id);
        Task<OfficeDto?> GetOfficeDtoAsync(Guid Id);
        Task<OfficeSpsDto?> GetSpsOfficeDtoAsync(int Id);
        Task<Dictionary<string, string>> GetOfficeTypesAsync();
        Task AddOfficeAsync(OfficeModelDto model);
        Task UpdateOfficeAsync(OfficeModelDto model);
        Task RemoveOfficeAsync(Guid id, string comment);
        Task<List<OfficeDto>> GetEmployeesForMfc(List<Guid> offices);
        Task<List<OfficeDto>> GetEmployeesForMfc(Guid officeId, List<int> jobsId);
        Task<List<EmployeeJobDto>> GetEmployeesForMfcV2(Guid officeId, List<int> jobsId);
        Task<List<EmployeeJobDto>> GetEmployeesForMfcV2(List<Guid> employeeId);

        #endregion 

        #region Роли исполнителя

        /// <summary>
        /// Поучить список ролей исполнителя
        /// </summary>
        /// <param name="request">Запрос</param>
        Task<(List<RoleExecutorDto>, int, int)> GetRolesExecutor(IDataTablesRequest request);
        Task<RoleExecutorModelDto> GetRolesExecutorModelDtoAsync(Guid? id);
        Task AddRoleExecutorAsync(RoleExecutorModelDto model);
        Task UpdateRoleExecutorAsync(RoleExecutorModelDto model);
        Task RemoveRolesExecutorAsync(Guid id, string comment);

        #endregion

        #region Календарь

        Task<IEnumerable<FullCalendarDateEventDto>> GetHolidaysAsync(DateTime dateStart, DateTime dateEnd);
        Task<IEnumerable<FullCalendarDateEventDto>> GetCalendarDatesAsync(DateTime dateStart, DateTime dateEnd);
        Task<CalendarDateModelDto> GetCalendarDateAsync(DateTime dateCalendar);
        Task UpdateCalendarDateAsync(CalendarDateModelDto model);
        Task RemoveCalendarDateAsync(int id, string comment);

        #endregion

        #region Файлы

        /// <summary>
        /// Поучить список файлов
        /// </summary>
        /// <param name="request">Запрос</param>
        Task<(List<ReferencesServicesFileDto>, int, int)> GetReferencesServicesFiles(IDataTablesRequest request);
        Task RemoveReferencesServicesFileAsync(Guid Id, string comment);

        /// <summary>
        /// Добавить файл
        /// </summary>
        Task AddReferencesServicesFileAsync(ReferencesServicesFileModelDto model);

        /// <summary>
        /// Модель для редактирования файла
        /// </summary>
        Task<ReferencesServicesFileModelDto> GetReferencesServicesFileDtoAsync(Guid? Id);

        /// <summary>
        /// Обновить файл
        /// </summary>
        Task UpdateReferencesServicesFileAsync(ReferencesServicesFileModelDto model);

        #endregion

        #region Услуги

        /// <summary>
        /// Поучить список услуг
        /// </summary>
        Task<(List<ServicesDto>, int, int)> GetServices(IDataTablesRequest request, Guid officeId, string search);
        Task<List<ServicesDto>> GetServicesAll();
        Task<List<ServicesDto>> GetServicesAll(List<Guid> id);
        Task<List<ServicesDto>> GetServicesForProviders(List<Guid> provides);
        Task<ServiceModelDto?> GetServiceDtoAsync(Guid? Id);
        Task<bool> GetServiceAnyAsync(Guid? Id);
        Task<string?> GetServiceNameSmallAsync(Guid? Id);
        Task AddServiceAsync(ServiceModelDto model);
        Task UpdateServiceAsync(ServiceModelDto model);
        Task RemoveServiceAsync(Guid Id, string comment);
        Task CopyServiceAsync(Guid Id, string EmployeeFio);
        Task<List<SelectListDto<int>>> GetServiceTypesAll();
        Task<List<SelectListDto<int>>> GetServiceInteractionsAll();
        Task<List<SelectListDto<Guid>>> GetServiceLivingSituationAll();
        Task<List<SelectListDto<int>>> GetServiceHashtagAll();


        /// <summary>
        /// Поучить список получателей услуги
        /// </summary>
        Task<(List<ServiceCustomerDto>, int, int)> GetServiceCustomers(IDataTablesRequest request, Guid serviceId);
        List<ServiceCustomerTypeDto> GetServiceCustomerTypes(Func<SServicesCustomerType, bool> searchPredicate);
        Task<List<ServiceCustomerTypeDto>> GetServiceCustomerTypes();
        Task<List<ServiceCustomerTypeDto>> GetServiceCustomerMainTypes();
        Task RemoveServiceCustomerAsync(Guid Id, string comment);
        Task UpdateServiceCustomerAsync(ServiceCustomerModelDto model);
        Task AddServiceCustomerAsync(ServiceCustomerModelDto model);
        Task<ServiceCustomerModelDto> GetServiceCustomerDtoAsync(Guid? Id);
        Task<List<ServiceCustomerDto>> GetAllServiceCustomersAsync(Guid serviceId);

        /// <summary>
        /// Поучить список документов услуги
        /// </summary>
        Task<(List<ServiceDocumentDto>, int, int)> GetServiceDocuments(IDataTablesRequest request, Guid serviceId);
        Task<List<ServiceDocumentDto>> GetAllServiceDocumentsAsync(Guid serviceId);
        Task<ServiceDocumentModelDto> GetServiceDocumentDtoAsync(Guid? Id);
        Task AddServiceDocumentAsync(ServiceDocumentModelDto model);
        Task UpdateServiceDocumentAsync(ServiceDocumentModelDto model);
        Task RemoveServiceDocumentAsync(Guid Id, string comment);

        /// <summary>
        /// Поучить список Результаты
        /// </summary>
        Task<(List<ServiceDocumentResultDto>, int, int)> GetServiceDocumentsResults(IDataTablesRequest request, Guid serviceId);
        Task<ServiceDocumentResultModelDto> GetServiceDocumentResultDtoAsync(Guid? Id);
        Task<List<ServiceDocumentResultDto>> GetAllServiceDocumentsResults(Guid serviceId);
        Task AddServiceDocumentResultAsync(ServiceDocumentResultModelDto model);
        Task UpdateServiceDocumentResultAsync(ServiceDocumentResultModelDto model);
        Task RemoveServiceDocumentResultAsync(Guid Id, string comment);

        /// <summary>
        /// Поучить список запросов СМЭВ услуги
        /// </summary>
        Task<(List<ServiceSmevDto>, int, int)> GetServiceSmevRequests(IDataTablesRequest request, Guid serviceId);
        Task<List<ServiceSmevRequestDto>> GetAllSmevRequestsAsync();
        List<ServiceSmevDto> GetAllServiceSmevRequests(Guid serviceId);
        Task<ServiceSmevRequestModelDto> GetServiceSmevRequestAsync(Guid? Id);
        Task RemoveServiceSmevRequestAsync(Guid Id, string comment);
        Task AddServiceSmevRequestAsync(ServiceSmevRequestModelDto model);
        Task UpdateServiceSmevRequestAsync(ServiceSmevRequestModelDto model);

        /// <summary>
        /// Поучить список запросов тарифов
        /// </summary>
        Task<(List<ServiceCustomerTariffDto>, int, int)> GetServiceCustomerTariffs(IDataTablesRequest request, Guid serviceId);
        Task<ServiceCustomerTariffModelDto> GetServiceCustomerTariffAsync(Guid? Id);
        List<ServiceCustomerTariffDto> GetAllServiceCustomerTariffs(Guid serviceId);
        Task UpdateServiceCustomerTariffAsync(ServiceCustomerTariffModelDto model);
        Task AddServiceCustomerTariffAsync(ServiceCustomerTariffModelDto model);
        Task RemoveServiceCustomerTariffAsync(Guid Id, string comment);
        Task<List<ServiceTariffTypeDto>> GetAllServiceTariffTypesAsync();
        Task<Dictionary<string, string>> GetAllServiceWeekTypesAsync();

        /// <summary>
        /// Поучить список файлов услуги
        /// </summary>
        Task<(List<ServiceFileDto>, int, int)> GetServiceFiles(IDataTablesRequest request, Guid serviceId);
        Task<List<ServiceFileDto>> GetAllServiceFiles(Guid serviceId);
        Task<ServiceFileModelDto> GetServiceFileAsync(Guid? Id);
        Task RemoveServiceFileAsync(Guid Id, string comment);
        Task AddServiceFileAsync(ServiceFileModelDto model);
        Task UpdateServiceFileAsync(ServiceFileModelDto model);

        /// <summary>
        /// Поучить список бланков услуги
        /// </summary>
        Task<(List<ServiceBlankDto>, int, int)> GetServiceBlancs(IDataTablesRequest request, Guid serviceId);
        Task<List<ServiceBlankDto>> GetAllServiceBlancs(Guid serviceId);
        Task<ServiceBlancModelDto> GetServiceBlancsAsync(Guid? Id);
        Task RemoveServiceBlancsAsync(Guid Id, string comment);
        Task AddServiceBlancsAsync(ServiceBlancModelDto model);
        Task UpdateServiceBlancsAsync(ServiceBlancModelDto model);

        /// <summary>
        /// Поучить список способов обращений услуги
        /// </summary>
        Task<(List<ServiceWayGetDto>, int, int)> GetServiceWaysGet(IDataTablesRequest request, Guid serviceId, int wt);
        Task<List<WayGetDto>> GetAllServiceWaysGetAsync();
        Task<List<ServiceWayGetDto>> GetAllServiceWaysGet(Guid serviceId, int wayType);
        Task<ServiceWayGetModelDto> GetServiceWayGetAsync(Guid? Id);
        Task RemoveServiceWayGetAsync(Guid Id, string comment);
        Task AddServiceWayGetAsync(ServiceWayGetModelDto model);
        Task UpdateServiceWayGetAsync(ServiceWayGetModelDto model);

        /// <summary>
        /// Поучить список оснований услуги
        /// </summary>
        Task<(List<ServiceReasonDto>, int, int)> GetServiceReasons(IDataTablesRequest request, Guid serviceId, int rt);
        Task<ServiceReasonModelDto> GetServiceReasonAsync(Guid? Id);
        Task RemoveServiceReasonAsync(Guid Id, string comment);
        Task AddServiceReasonAsync(ServiceReasonModelDto model);
        Task UpdateServiceReasonAsync(ServiceReasonModelDto model);

        /// <summary>
        /// Поучить список способа оценки
        /// </summary>
        Task<(List<ServiceQualityTypeDto>, int, int)> GetServiceQualityTypes(IDataTablesRequest request, Guid serviceId);
        List<ServiceQualityTypeDto> GetAllServiceQualityTypes(Guid serviceId);
        Task<List<QualityTypeDto>> GetAllQualityTypesAsync();
        Task<ServiceQualityTypeModelDto> GetServiceQualityTypeDtoAsync(Guid? Id);
        Task RemoveServiceQualityTypeAsync(Guid Id, string comment);
        Task AddServiceQualityTypeAsync(ServiceQualityTypeModelDto model);
        Task UpdateServiceQualityTypeAsync(ServiceQualityTypeModelDto model);

        /// <summary>
        /// Поучить список активности услуги
        /// </summary>
        Task<(List<ServiceActivityDto>, int, int)> GetServiceActivitiesAsync(IDataTablesRequest request, Guid serviceId, Guid officeId);
        Task<(List<ServiceActivityOfficeDto>,int,int)> GetServiceActivitiesOfficesAsync(IDataTablesRequest request, Guid serviceId);
        Task<ServiceActivityModelDto> GetLastServiceActivityDtoAsync(Guid serviceId);
        Task RemoveServiceActivityAsync(Guid id, bool isRemove, string comment);
        Task RemoveServiceActivityAsync(Guid serviceId, List<Guid> officesId, string comment);
        Task AddServiceActivityAsync(ServiceActivityModelDto model);

        /// <summary>
        /// Поучить список процедур услуги
        /// </summary>
        Task<(List<ServicesProcedureDto>, int, int)> GetServiceProceduresAsync(IDataTablesRequest request, Guid serviceId);
        Task<List<ServicesProcedureDto>> GetAllServiceProceduresAsync(Guid serviceId);
        Task<ServiceProcedureModelDto> GetServiceProcedureDtoAsync(Guid? Id);
        Task RemoveServiceProcedureAsync(Guid Id, string comment);
        Task AddServiceProcedureAsync(ServiceProcedureModelDto model);
        Task UpdateServiceProcedureAsync(ServiceProcedureModelDto model);

        /// <summary>
        /// Получить список этапов услуги
        /// </summary>
        Task<(List<ServicesRoutesStageDto>, int, int)> GetServiceStages(IDataTablesRequest request, Guid serviceId, Guid parentId);
        Task<(List<ServicesRoutesStageRoleDto>, int, int)> GetServiceStageRoles(IDataTablesRequest request, Guid id);
        Task<ServiceStageModelDto> GetServiceStageDtoAsync(Guid? Id);
        Task<List<ServicesRoutesStageDto>> GetServiceStagesAsync(Guid serviceId, Guid parentId);
        Task AddServiceStageAsync(ServiceStageModelDto model);
        Task UpdateServiceStageAsync(ServiceStageModelDto model);
        Task RemoveServiceStageAsync(Guid Id, string comment);
        Task<List<RoleExecutorDto>> GetServiceStageRolesAsync(Guid Id);
        Task AddServiceStageRoleAsync(ServicesStageRoleModelDto model);
        Task RemoveServiceStageRoleAsync(Guid Id, string comment);

        #endregion

        #region СМЭВ

        /// <summary>
        /// Поучить список сервисов СМЭВ
        /// </summary>
        /// <param name="request">Запрос</param>
        Task<(List<SmevServiceDto>, int, int)> GetSmevServices(IDataTablesRequest request);
        Task<SmevServiceModelDto> GetSmevServiceModelDtoAsync(Guid? Id);
        Task RemoveSmevServiceAsync(Guid Id, string comment);
        Task AddSmevServiceAsync(SmevServiceModelDto model);
        Task UpdateSmevServiceAsync(SmevServiceModelDto model);

        /// <summary>
        /// Поучить список запросов СМЭВ
        /// </summary>
        /// <param name="request">Запрос</param>
        Task<(List<SmevRequestDto>, int, int)> GetSmevRequests(IDataTablesRequest request);
        Task<SmevRequestModelDto> GetSmevRequestModelDtoAsync(int? Id);
        Task<List<SmevRequestDto>> GetAllSmevRequestAsync(List<int> id);
        Task<List<SmevServiceDto>> GetAllSmevServicesAsync();
        Task<List<SmevServiceDto>> GetAllSmevServicesAsync(List<Guid> id);
        Task<List<SelectListDto<string>>> GetAllSmevProvidersAsync();
        Task<List<SmevRequestDto>> GetSmevRequestBySmevService(List<Guid> id);
        Task RemoveSmevRequestAsync(int Id, string comment);
        Task AddSmevRequestAsync(SmevRequestModelDto model);
        Task UpdateSmevRequestAsync(SmevRequestModelDto model);
        
        Task<List<SmevReferenceServiceDto>> GetServicesForSmevAsync(int id);
        Task<bool> AddServicesForSmevAsync(AddSmevReferenceServiceDto request);
        Task<bool> DeleteServicesForSmevAsync(Guid id);

        #endregion

        #region Сотрудники
        Task<(List<EmployeesOfficesJoinDto>, int, int)> GetReferencesEmployees(IDataTablesRequest request, Guid officeId, string search);
        Task<List<EmployeesOfficesJoinDto>> GetReferencesActiveEmployees(List<Guid> officesId);
        Task<List<EmployeesOfficesJoinDto>> GetReferencesAllEmployees();
        Task<EmployeeModelDto> GetEmployeeDtoAsync(Guid? Id);
        Task<List<EmployeeModelDto>> GetEmployeesDtoAsync(List<Guid> Id);
        Task<List<EmployeeModelDto>> GetEmployeesDtoAsync();
        Task<bool> GetEmployeeAnyAsync(Guid? Id);
        Task<Guid> AddEmployeeAsync(EmployeeModelDto model);
        Task<Guid> AddEmployeeWithLinkedDataAsync(EmployeeAddModelDto model);
        Task UpdateEmployeeAsync(EmployeeModelDto model);
        Task EmployeePasswordChange(EmployeePasswordChangeDto password);
        Task<Guid?> GetEmployeeAspNetUserId(Guid Id);


        /// <summary>
        /// Получить должности и офисы сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        Task<(List<EmployeeJobDto>, int, int)> GetEmployeeJobs(IDataTablesRequest request, Guid id);
        Task<EmployeeJobModelDto> GetEmployeeJobDtoAsync(Guid? Id);
        Task<List<EmployeesJobDto>> GetAllJobsAsync();
        Task<EmployeeJobModelDto> GetLastEmployeesJobDtoAsync(Guid employeeId);
        Task AddEmployeeJobAsync(EmployeeJobModelDto model);
        Task RemoveEmployeeJobAsync(Guid id, bool isRemove, string comment);

        /// <summary>
        /// Получить статусы сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        Task<(List<EmployeeStatusDto>, int, int)> GetEmployeeStatuses(IDataTablesRequest request, Guid id);
        Task<Dictionary<string, string>> GetAllEmployeeStatusesAsync();
        Task<EmployeeStatusModelDto> GetLastEmployeeStatusDtoAsync(Guid employeeId);
        Task RemoveEmployeeStatusAsync(Guid id, bool isRemove, string comment);
        Task AddEmployeeStatusAsync(EmployeeStatusModelDto model);

        /// <summary>
        /// Получить тесты сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        Task<(List<EmployeeTestDto>, int, int)> GetEmployeeTest(IDataTablesRequest request, Guid id);
        Task<EmployeeTestStartDto?> GetEmployeeTestStart(Guid id);
        Task<EmployeeTestQuestionDto?> GetEmployeeTestQuestion(Guid id);
        Task EmployeeTestAnswersSave(EmployeesTestAnswerDto request);


        /// <summary>
        /// Получить исполнения сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        Task<(List<EmployeeExecutionDto>, int, int)> GetEmployeeExecutions(IDataTablesRequest request, Guid id);
        Task<EmployeeExecutionModelDto> GetLastEmployeeExectionDtoAsync(Guid employeeId);
        Task<EmployeeExecutionModelDto> GetEmployeeExectionDtoAsync(Guid id);
        Task<bool> GetIsEmployeeExectionAsync(Guid employeeId);
        Task AddEmployeeExecutionAsync(EmployeeExecutionModelDto model);
        Task RemoveEmployeeExecutionAsync(Guid id, bool isRemove, string comment);

        /// <summary>
        /// Получить роли исполнения сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        Task<(List<EmployeeExecutorRoleDto>, int, int)> GetEmployeeExecutorRoles(IDataTablesRequest request, Guid id);
        Task<List<RoleExecutorDto>> GetAllRolesExecutorAsync();
        Task<List<EmployeeExecutorRoleDto>> GetAllEmployeeExecutorRolesAsync(Guid id);
        Task RemoveEmployeeExecutorRoleAsync(Guid Id, string comment);
        Task AddEmployeeExecutorRoleAsync(EmployeeRoleExecutorModelDto model);

        /// <summary>
        /// Получить историю авторизации
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        Task<(List<EmployeeHistoryDto>, int, int)> GetEmployeeHistory(IDataTablesRequest request, Guid id);


        /// <summary>
        /// Получить офисы авторизации
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        Task<(List<EmployeeOfficeDto>, int, int)> GetEmployeeOffices(IDataTablesRequest request, Guid id);
        Task RemoveEmployeeOfficeAsync(Guid id, bool isRemove, string comment);
        Task AddEmployeeOfficesAsync(EmployeeOfficeModelDto model);


        /// <summary>
        /// Получить активности сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        Task<(List<EmployeeActivityDto>, int, int)> GetEmployeeActivities(IDataTablesRequest request, Guid id);
        Task<EmployeeActivityModelDto> GetLastEmployeeActivityDtoAsync(Guid employeeId);
        Task<EmployeeActivityModelDto> GetEmployeeActivityDtoAsync(Guid id);
        Task<bool> GetIsEmployeeActivityAsync(Guid employeeId);
        Task RemoveEmployeeActivityAsync(Guid id, bool isRemove, string comment);
        Task AddEmployeeActivityAsync(EmployeeActivityModelDto model);
        #endregion

        #region Информация

        /// <summary>
        /// Получить список "Информация"
        /// </summary>
        Task<(List<InformationDto>, int, int)> GetInformations(IDataTablesRequest request);

        /// <summary>
        /// Типы информации
        /// </summary>
        Task<Dictionary<string, string>> GetInformationTypesAsync();

        /// <summary>
        /// Добавить информацию
        /// </summary>
        Task AddInformationAsync(InformationModelDto model);

        /// <summary>
        /// Пометить на удаление информацию
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        Task RemoveInfornmationAsync(Guid Id, string comment);

        /// <summary>
        /// Скачать информационный файл
        /// </summary>
        /// <param name="Id">Id записи</param>
        Task<FormFile> DownloadInformationFileAsync(Guid Id);

        /// <summary>
        /// Получить файлы информации
        /// </summary>
        /// <param name="InformationId">Id информации</param>
        Task<List<InformationFileDto>> GetInformationFilesAsync(Guid InformationId);

        /// <summary>
        /// Модель для редактирования информации
        /// </summary>
        Task<InformationModelDto> GetInformationDtoAsync(Guid? Id);

        /// <summary>
        /// Получить офисы, связанные с информацией
        /// </summary>
        /// <param name="InformationId">Id информации</param>
        Task<List<Guid>> GetInformationOfficesAsync(Guid? InformationId);

        Task<List<string>> GetInformationOfficesAsyncV2(Guid? InformationId);

        /// <summary>
        /// Удалить информационный файл
        /// </summary>
        /// <param name="Id">Id файла(записи)</param>
        Task RemoveInformationFileAsync(Guid Id);

        /// <summary>
        /// Обновить информацию
        /// </summary>
        Task UpdateInformationAsync(InformationModelDto model);

        /// <summary>
        /// Добавить файлы к информации
        /// </summary>
        Task<InformationFileResponseModel> UploadInformationFilesAsync(UploadInformationFilesModel model);

        /// <summary>
        /// Скачать превью информационного файла
        /// </summary>
        /// <param name="Id">Id записи</param>
        Task<FormFile> DownloadInformationFileThumbnailAsync(Guid Id);

        #endregion

        #region FTP

        /// <summary>
        /// Получить список "FTP"
        /// </summary>
        Task<(List<FTPDto>, int, int)> GetFTP(IDataTablesRequest request);

        /// <summary>
        /// Получить  FTP
        /// </summary>
        Task<FtpModelDto?> GetFTPDtoAsync(Guid? Id);

        /// <summary>
        /// Получить список всех  FTP
        /// </summary>
        Task<List<FtpModelDto>> GetFTPAllAsync();

        /// <summary>
        /// Добавить FTP
        /// </summary>
        Task AddFTPAsync(FtpModelDto model);

        /// <summary>
        /// Обновить FTP
        /// </summary>
        Task UpdateFTPAsync(FtpModelDto model);

        /// <summary>
        /// Пометить на удаление FTP
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        Task RemoveFTPAsync(Guid Id, string comment);

        #endregion

        #region Этапы

        /// <summary>
        /// Получить список "FTP"
        /// </summary>
        Task<(List<RoutesStageDto>, int, int)> GetRoutesStage(IDataTablesRequest request);

        /// <summary>
        /// Получить  FTP
        /// </summary>
        Task<RoutesStageModelDto?> GetRoutesStageDtoAsync(int? Id);

        /// <summary>
        /// Получить список всех  FTP
        /// </summary>
        Task<List<RoutesStageModelDto>> GetRoutesStageAllAsync();

        /// <summary>
        /// Добавить FTP
        /// </summary>
        Task AddRoutesStageAsync(RoutesStageModelDto model);

        /// <summary>
        /// Обновить FTP
        /// </summary>
        Task UpdateRoutesStageAsync(RoutesStageModelDto model);

        Task<List<ServicesStatusDto>> GetStatusesAllAsync();

        #endregion

        #region Жизненные ситуации

        /// <summary>
        /// Получить список ""жизненныt ситуации"
        /// </summary>
        Task<(List<LivingSituationsDto>, int, int)> GetLivingSituation(IDataTablesRequest request);

        /// <summary>
        /// Получить  "жизненныt ситуации"
        /// </summary>
        Task<LivingSituationModelDto> GetLivingSituationDtoAsync(Guid? Id);

        /// <summary>
        /// Добавить "жизненныt ситуации"
        /// </summary>
        Task AddLivingSituationAsync(LivingSituationModelDto model);

        /// <summary>
        /// Обновить "жизненныt ситуации"
        /// </summary>
        Task UpdateLivingSituationAsync(LivingSituationModelDto model);

        /// <summary>
        /// Пометить на удаление "жизненныt ситуации"
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        Task RemoveLivingSituationAsync(Guid Id, string comment);

        #endregion

        #region Гос задние

        /// <summary>
        /// Получить список гос задание
        /// </summary>
        Task<(List<StateTasksDto>, int, int)> GetStateTask(IDataTablesRequest request);

        /// <summary>
        /// Получить гос задание
        /// </summary>
        Task<StateTaskDto?> GetStateTaskDtoAsync(Guid? Id);

        /// <summary>
        /// Добавить гос задание
        /// </summary>
        Task AddStateTaskAsync(StateTaskDto model, string EmployeesFioAdd);

        /// <summary>
        /// Обновить гос задание
        /// </summary>
        Task UpdateStateTaskAsync(StateTaskDto model);

        /// <summary>
        /// Пометить на удаление гос задание
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <param name="comment">Причина удаления</param>
        Task RemoveStateTaskAsync(Guid Id, string comment);

        #endregion

        #region Системные

        Task<byte[]?> SystemFiles(int type);
        Task<List<SelectListDto<string>>> GetTerminalsByOffice(Guid? officeId);
        Task<List<SelectListDto<Guid>>> GetRecipientPaymentByProviders(Guid providerId, Guid? officeId);

        //Task<List<DataBaseDictonaryDto>> DataBaseDictonary(DataBaseDictonaryType type);


        #endregion

        #region Тестирование

        Task<(List<TestDirectionDto>, int, int)> GetDirections(IDataTablesRequest request);
        Task<List<TestDirectionDto>> GetAllDirectionsAsync();
        Task<List<TestDirectionDto>> GetAllDirectionsAsync(List<int> jobsId);
        Task<TestDirectionModelDto?> GetDirectionsDtoAsync(Guid? Id);
        Task AddDirectionsAsync(TestDirectionModelDto model);
        Task UpdateDirectionsAsync(TestDirectionModelDto model);
        Task RemoveDirectionsAsync(Guid Id, string comment);


        Task<(List<TestQuestionDto>, int, int)> GetQuestions(IDataTablesRequest request);
        Task<List<TestQuestionDto>> GetAllQuestionsAsync();
        Task<TestQuestionsModelDto?> GetQuestionsDtoAsync(Guid? Id);
        Task AddQuestionsAsync(TestQuestionsModelDto model);
        Task UpdateQuestionsAsync(TestQuestionsModelDto model);
        Task RemoveQuestionsAsync(Guid Id, string comment);

        #endregion

        #region Mdm

        /// <summary>
        /// Получить список "FTP"
        /// </summary>
        Task<(List<MdmDto>, int, int)> GetMdm(IDataTablesRequest request);

        /// <summary>
        /// Получить  FTP
        /// </summary>
        Task<MdmModelDto?> GetMdmDtoAsync(Guid? Id);
        /// <summary>
        /// Обновить FTP
        /// </summary>
        Task UpdateMdmAsync(MdmModelDto model);
        #endregion
    }
}