using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AisLogistics.DataLayer.Entities.Models;

namespace AisLogistics.DataLayer.Concrete
{
    public partial class AisLogisticsContext : DbContext
    {
        public AisLogisticsContext()
        {
        }

        public AisLogisticsContext(DbContextOptions<AisLogisticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ACase> ACases { get; set; }
        public virtual DbSet<ACasesView> ACasesViews { get; set; }
        public virtual DbSet<APremium> APremia { get; set; }
        public virtual DbSet<APremiumFine> APremiumFines { get; set; }
        public virtual DbSet<APremiumStep> APremiumSteps { get; set; }
        public virtual DbSet<AService> AServices { get; set; }
        public virtual DbSet<AServicesAudit> AServicesAudits { get; set; }
        public virtual DbSet<AServicesCommentt> AServicesCommentts { get; set; }
        public virtual DbSet<AServicesCommenttEmployee> AServicesCommenttEmployees { get; set; }
        public virtual DbSet<AServicesCoverLetter> AServicesCoverLetters { get; set; }
        public virtual DbSet<AServicesCustomer> AServicesCustomers { get; set; }
        public virtual DbSet<AServicesCustomersCall> AServicesCustomersCalls { get; set; }
        public virtual DbSet<AServicesCustomersMessage> AServicesCustomersMessages { get; set; }
        public virtual DbSet<AServicesCustomersGisgmp> AServicesCustomersGisgmps { get; set; }
        public virtual DbSet<AServicesCustomersLegal> AServicesCustomersLegals { get; set; }
        public virtual DbSet<AServicesCustomersLegalGisgmp> AServicesCustomersLegalGisgmps { get; set; }
        public virtual DbSet<AServicesDocument> AServicesDocuments { get; set; }
        public virtual DbSet<AServicesDocumentsResult> AServicesDocumentsResults { get; set; }
        public virtual DbSet<AServicesFile> AServicesFiles { get; set; }
        public virtual DbSet<AServicesFileResult> AServicesFileResults { get; set; }
        public virtual DbSet<AServicesPayment> AServicesPayments { get; set; }
        public virtual DbSet<AServicesRoutesStage> AServicesRoutesStages { get; set; }
        public virtual DbSet<AServicesSmevLog> AServicesSmevLogs { get; set; }
        public virtual DbSet<AServicesSmevRequest> AServicesSmevRequests { get; set; }
        public virtual DbSet<AServicesSmevRequestStatus> AServicesSmevRequestStatuses { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<AutoHistory> AutoHistories { get; set; }
        public virtual DbSet<DAcquiring> DAcquirings { get; set; }
        public virtual DbSet<DAisOpvAnketStatus> DAisOpvAnketStatuses { get; set; }
        public virtual DbSet<DAisOpvChat> DAisOpvChats { get; set; }
        public virtual DbSet<DAlertEmployee> DAlertEmployees { get; set; }
        public virtual DbSet<DCase> DCases { get; set; }
        public virtual DbSet<DCasesFavorite> DCasesFavorites { get; set; }
        public virtual DbSet<DCasesView> DCasesViews { get; set; }
        public virtual DbSet<DElkOrder> DElkOrders { get; set; }
        public virtual DbSet<DElkStatusChange> DElkStatusChanges { get; set; }
        public virtual DbSet<DEmployeesIasMkguOfficesWebsite> DEmployeesIasMkguOfficesWebsites { get; set; }
        public virtual DbSet<DEmployeesServicesFavorite> DEmployeesServicesFavorites { get; set; }
        public virtual DbSet<DEpguDocumentsLoad> DEpguDocumentsLoads { get; set; }
        public virtual DbSet<DEpguDocumentsResponse> DEpguDocumentsResponses { get; set; }
        public virtual DbSet<DFsspUpload> DFsspUploads { get; set; }
        public virtual DbSet<DIasMkguInfomatAnswer> DIasMkguInfomatAnswers { get; set; }
        public virtual DbSet<DIasMkguInfomatAnswerCommentt> DIasMkguInfomatAnswerCommentts { get; set; }
        public virtual DbSet<DIasMkguInfomatLogUpload> DIasMkguInfomatLogUploads { get; set; }
        public virtual DbSet<DIasMkguInfomatUpload> DIasMkguInfomatUploads { get; set; }
        public virtual DbSet<DIasMkguProviderLoad> DIasMkguProviderLoads { get; set; }
        public virtual DbSet<DIasMkguRatingLoad> DIasMkguRatingLoads { get; set; }
        public virtual DbSet<DIasMkguRatingLogLoad> DIasMkguRatingLogLoads { get; set; }
        public virtual DbSet<DIasMkguSmsLogUpload> DIasMkguSmsLogUploads { get; set; }
        public virtual DbSet<DIasMkguSmsUpload> DIasMkguSmsUploads { get; set; }
        public virtual DbSet<DIncomingCall> DIncomingCalls { get; set; }
        public virtual DbSet<DIndicatorsValue> DIndicatorsValues { get; set; }
        public virtual DbSet<DInformation> DInformations { get; set; }
        public virtual DbSet<DInformationFile> DInformationFiles { get; set; }
        public virtual DbSet<DInformationRecipient> DInformationRecipients { get; set; }
        public virtual DbSet<DMdmObjectsAttributesUpload> DMdmObjectsAttributesUploads { get; set; }
        public virtual DbSet<DMdmObjectsLogUpload> DMdmObjectsLogUploads { get; set; }
        public virtual DbSet<DMdmObjectsUpload> DMdmObjectsUploads { get; set; }
        public virtual DbSet<DNote> DNotes { get; set; }
        public virtual DbSet<DAutomaticLog> DAutomaticLogs { get; set; }
        public virtual DbSet<DPremiumFine> DPremiumFines { get; set; }
        public virtual DbSet<DPremiumStep> DPremiumSteps { get; set; }
        public virtual DbSet<DQueueAvgTime> DQueueAvgTimes { get; set; }
        public virtual DbSet<DRatingEmployeesAll> DRatingEmployeesAlls { get; set; }
        public virtual DbSet<DRatingEmployeesDay> DRatingEmployeesDays { get; set; }
        public virtual DbSet<DRatingEmployeesMonth> DRatingEmployeesMonths { get; set; }
        public virtual DbSet<DRatingEmployeesYear> DRatingEmployeesYears { get; set; }
        public virtual DbSet<DRatingInitialValue> DRatingInitialValues { get; set; }
        public virtual DbSet<DRatingOfficesAll> DRatingOfficesAlls { get; set; }
        public virtual DbSet<DRatingOfficesDay> DRatingOfficesDays { get; set; }
        public virtual DbSet<DRatingOfficesMonth> DRatingOfficesMonths { get; set; }
        public virtual DbSet<DRatingOfficesYear> DRatingOfficesYears { get; set; }
        public virtual DbSet<DSalaryRecalculationLog> DSalaryRecalculationLogs { get; set; }
        public virtual DbSet<DService> DServices { get; set; }
        public virtual DbSet<DReestr> DReestrs { get; set; }
        public virtual DbSet<DReestrService> DReestrServices { get; set; }
        public virtual DbSet<DReestrUnclaimed> DReestrUnclaimeds { get; set; }
        public virtual DbSet<DReestrUnclaimedService> DReestrUnclaimedServices { get; set; }
        public virtual DbSet<DServicesAudit> DServicesAudits { get; set; }
        public virtual DbSet<DServicesCommentt> DServicesCommentts { get; set; }
        public virtual DbSet<DServicesCommenttEmployee> DServicesCommenttEmployees { get; set; }
        public virtual DbSet<DServicesCoverLetter> DServicesCoverLetters { get; set; }
        public virtual DbSet<DServicesCustomer> DServicesCustomers { get; set; }
        public virtual DbSet<DCustomer> DCustomers { get; set; }
        public virtual DbSet<DCustomerHistory> DCustomerHistories { get; set; }
        public virtual DbSet<DServicesCustomersCall> DServicesCustomersCalls { get; set; }
        public virtual DbSet<DServicesCustomersMessage> DServicesCustomersMessages { get; set; }
        public virtual DbSet<DServicesCustomersGisgmp> DServicesCustomersGisgmps { get; set; }
        public virtual DbSet<DServicesCustomersLegal> DServicesCustomersLegals { get; set; }
        public virtual DbSet<DServicesCustomersLegalGisgmp> DServicesCustomersLegalGisgmps { get; set; }
        public virtual DbSet<DServicesDocument> DServicesDocuments { get; set; }
        public virtual DbSet<DServicesDocumentsResult> DServicesDocumentsResults { get; set; }
        public virtual DbSet<DServicesFile> DServicesFiles { get; set; }
        public virtual DbSet<DServicesFileResult> DServicesFileResults { get; set; }
        public virtual DbSet<DServicesPayment> DServicesPayments { get; set; }
        public virtual DbSet<DServicesRoutesStage> DServicesRoutesStages { get; set; }
        public virtual DbSet<DServicesSmevLog> DServicesSmevLogs { get; set; }
        public virtual DbSet<DServicesSmevRequest> DServicesSmevRequests { get; set; }
        public virtual DbSet<DServicesSmevRequestStatus> DServicesSmevRequestStatuses { get; set; }
        public virtual DbSet<DSmsPollRegion> DSmsPollRegions { get; set; }
        public virtual DbSet<DStepCancel> DStepCancels { get; set; }
        public virtual DbSet<DStepRecalculationLog> DStepRecalculationLogs { get; set; }
        public virtual DbSet<DZagsBirth> DZagsBirths { get; set; }
        public virtual DbSet<DZagsDeath> DZagsDeaths { get; set; }
        public virtual DbSet<DZagsDivorce> DZagsDivorces { get; set; }
        public virtual DbSet<DZagsMarriage> DZagsMarriages { get; set; }
        public virtual DbSet<DZagsNameChange> DZagsNameChanges { get; set; }
        public virtual DbSet<DZagsPaternity> DZagsPaternities { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<SAlertCustomer> SAlertCustomers { get; set; }
        public virtual DbSet<SAlertEmployee> SAlertEmployees { get; set; }
        public virtual DbSet<SAutomatic> SAutomatics { get; set; }
        public virtual DbSet<SCalendar> SCalendars { get; set; }
        public virtual DbSet<SDaysWeek> SDaysWeeks { get; set; }
        public virtual DbSet<SDocument> SDocuments { get; set; }
        public virtual DbSet<SDocumentsCode> SDocumentsCodes { get; set; }
        public virtual DbSet<SDocumentsIdentity> SDocumentsIdentities { get; set; }
        public virtual DbSet<SDocumentsSmevRequestJoin> SDocumentsSmevRequestJoins { get; set; }
        public virtual DbSet<SEmployee> SEmployees { get; set; }
        public virtual DbSet<SEmployeesActive> SEmployeesActives { get; set; }
        public virtual DbSet<SEmployeesAuthorizationLog> SEmployeesAuthorizationLogs { get; set; }
        public virtual DbSet<SEmployeesCombinationJob> SEmployeesCombinationJobs { get; set; }
        public virtual DbSet<SEmployeesCoverLetter> SEmployeesCoverLetters { get; set; }
        public virtual DbSet<SEmployeesExecution> SEmployeesExecutions { get; set; }
        public virtual DbSet<SEmployeesFile> SEmployeesFiles { get; set; }
        public virtual DbSet<SEmployeesFileFolder> SEmployeesFileFolders { get; set; }
        public virtual DbSet<SEmployeesJobPosition> SEmployeesJobPositions { get; set; }
        public virtual DbSet<SEmployeesJobPositionFine> SEmployeesJobPositionFines { get; set; }
        public virtual DbSet<SEmployeesOfficesJoin> SEmployeesOfficesJoins { get; set; }
        public virtual DbSet<SOfficesAuthorization> SOfficesAuthorizations { get; set; }
        public virtual DbSet<SEmployeesRolesExecutor> SEmployeesRolesExecutors { get; set; }
        public virtual DbSet<SEmployeesStatus> SEmployeesStatuses { get; set; }
        public virtual DbSet<SEmployeesStatusJoin> SEmployeesStatusJoins { get; set; }
        public virtual DbSet<SEmployeesTemplate> SEmployeesTemplates { get; set; }
        public virtual DbSet<SEmployeesWorkingTime> SEmployeesWorkingTimes { get; set; }
        public virtual DbSet<SEmployeesWorkingTimeJoin> SEmployeesWorkingTimeJoins { get; set; }
        public virtual DbSet<SForm> SForms { get; set; }
        public virtual DbSet<SReport> SReports { get; set; }
        public virtual DbSet<SReportGroup> SReportGroups { get; set; }
        public virtual DbSet<SFtp> SFtps { get; set; }
        public virtual DbSet<SFtpVipnet> SFtpVipnets { get; set; }
        public virtual DbSet<SStateTask> SStateTasks { get; set; }
        public virtual DbSet<SHashtag> SHashtags { get; set; }
        public virtual DbSet<SHealthCamp> SHealthCamps { get; set; }
        public virtual DbSet<SIasMkguCategory> SIasMkguCategories { get; set; }
        public virtual DbSet<SIasMkguIndicator> SIasMkguIndicators { get; set; }
        public virtual DbSet<SIasMkguQuestion> SIasMkguQuestions { get; set; }
        public virtual DbSet<SIasMkguQuestionAnswer> SIasMkguQuestionAnswers { get; set; }
        public virtual DbSet<SIndicator> SIndicators { get; set; }
        public virtual DbSet<SIndicatorsField> SIndicatorsFields { get; set; }
        public virtual DbSet<SIndicatorsGroup> SIndicatorsGroups { get; set; }
        public virtual DbSet<SIndicatorsSubgroup> SIndicatorsSubgroups { get; set; }
        public virtual DbSet<SInformationType> SInformationTypes { get; set; }
        public virtual DbSet<SMdmObjectAttribute> SMdmObjectAttributes { get; set; }
        public virtual DbSet<SMdmObjectType> SMdmObjectTypes { get; set; }
        public virtual DbSet<SOffice> SOffices { get; set; }
        public virtual DbSet<SOfficesPlan> SOfficesPlans { get; set; }
        public virtual DbSet<SOfficesType> SOfficesTypes { get; set; }
        public virtual DbSet<SOfficesShedule> SOfficesShedules { get; set; }
        public virtual DbSet<SOfficesZag> SOfficesZags { get; set; }
        public virtual DbSet<SOfficesAcquiring> SOfficesAcquirings { get; set; }
        public virtual DbSet<SRecipientPayment> SRecipientPayments { get; set; }
        public virtual DbSet<SAutomaticOperation> SAutomaticOperations { get; set; }
        public virtual DbSet<SPfrDepartment> SPfrDepartments { get; set; }
        public virtual DbSet<SPremiumParametr> SPremiumParametrs { get; set; }
        public virtual DbSet<SPremiumParametrsJobPositionJoin> SPremiumParametrsJobPositionJoins { get; set; }
        public virtual DbSet<SPremiumService> SPremiumServices { get; set; }
        public virtual DbSet<SPremiumStep> SPremiumSteps { get; set; }
        public virtual DbSet<SRatingJobPosition> SRatingJobPositions { get; set; }
        public virtual DbSet<SRole> SRoles { get; set; }
        public virtual DbSet<SRolesExecutor> SRolesExecutors { get; set; }
        public virtual DbSet<SRoutesStage> SRoutesStages { get; set; }
        public virtual DbSet<SService> SServices { get; set; }
        public virtual DbSet<SServicesActive> SServicesActives { get; set; }
        public virtual DbSet<SServicesCustomer> SServicesCustomers { get; set; }
        public virtual DbSet<SServicesCustomerTariff> SServicesCustomerTariffs { get; set; }
        public virtual DbSet<SServicesCustomerType> SServicesCustomerTypes { get; set; }
        public virtual DbSet<SServicesDocument> SServicesDocuments { get; set; }
        public virtual DbSet<SServicesDocumentsResult> SServicesDocumentsResults { get; set; }
        public virtual DbSet<SServicesFile> SServicesFiles { get; set; }
        public virtual DbSet<SServicesForm> SServicesForms { get; set; }
        public virtual DbSet<SServicesLivingSituation> SServicesLivingSituations { get; set; }
        public virtual DbSet<SServicesLivingSituationJoin> SServicesLivingSituationJoins { get; set; }
        public virtual DbSet<SServicesProcedure> SServicesProcedures { get; set; }
        public virtual DbSet<SServicesReason> SServicesReasons { get; set; }
        public virtual DbSet<SServicesRoutesStage> SServicesRoutesStages { get; set; }
        public virtual DbSet<SServicesRoutesStageRole> SServicesRoutesStageRoles { get; set; }
        public virtual DbSet<SServicesSmevRequestJoin> SServicesSmevRequestJoins { get; set; }
        public virtual DbSet<SServicesStatus> SServicesStatuses { get; set; }
        public virtual DbSet<SServicesTariffType> SServicesTariffTypes { get; set; }
        public virtual DbSet<SServicesType> SServicesTypes { get; set; }
        public virtual DbSet<SServicesInteraction> SServicesInteractions { get; set; }
        public virtual DbSet<SServicesTypeQuality> SServicesTypeQualities { get; set; }
        public virtual DbSet<SServicesTypeQualityJoin> SServicesTypeQualityJoins { get; set; }
        public virtual DbSet<SServicesWayGet> SServicesWayGets { get; set; }
        public virtual DbSet<SServicesWayGetJoin> SServicesWayGetJoins { get; set; }
        public virtual DbSet<SServicesWeek> SServicesWeeks { get; set; }
        public virtual DbSet<SSetting> SSettings { get; set; }
        public virtual DbSet<SSmev> SSmevs { get; set; }
        public virtual DbSet<SFnsSoun> SFnsSouns { get; set; }
        public virtual DbSet<SSmevClassFnsReg> SSmevClassFnsRegs { get; set; }
        public virtual DbSet<SSmevClassOkopf> SSmevClassOkopfs { get; set; }
        public virtual DbSet<SSmevClassOkpd> SSmevClassOkpds { get; set; }
        public virtual DbSet<SSmevClassOkved> SSmevClassOkveds { get; set; }
        public virtual DbSet<SSmevClassOszn> SSmevClassOszns { get; set; }
        public virtual DbSet<SSmevClassUik> SSmevClassUiks { get; set; }
        public virtual DbSet<SSmevClassZag> SSmevClassZags { get; set; }
        public virtual DbSet<SBanks> SBanks { get; set; }
        public virtual DbSet<SSmevRequest> SSmevRequests { get; set; }
        public virtual DbSet<SSmevSystemAccess> SSmevSystemAccesses { get; set; }
        public virtual DbSet<SSmevTypeRequest> SSmevTypeRequests { get; set; }
        public virtual DbSet<SWarning> SWarnings { get; set; }
        public virtual DbSet<STestAnswer> STestAnswers { get; set; }
        public virtual DbSet<STestDirection> STestDirections { get; set; }
        public virtual DbSet<STestDirectionJob> STestDirectionJobs { get; set; }
        public virtual DbSet<STestDirectionQuestion> STestDirectionQuestions { get; set; }
        public virtual DbSet<STestQuestion> STestQuestions { get; set; }
        public virtual DbSet<DTest> DTests { get; set; }
        public virtual DbSet<DTestAnswerEmployee> DTestAnswers { get; set; }
        public virtual DbSet<DTestDirection> DTestDirections { get; set; }
        public virtual DbSet<DTestEmployee> DTestEmployees { get; set; }
        public virtual DbSet<DTestQuestionsEmployee> DTestQuestionsEmployees { get; set; }

        public object AsNoTracking()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("directory", "dblink")
                .HasPostgresExtension("directory", "pldbgapi")
                .HasPostgresExtension("directory", "uuid-ossp")
                .HasPostgresExtension("pg_catalog", "adminpack");

            modelBuilder.Entity<ACase>(entity =>
            {
                entity.ToTable("a_cases", "archive");

                entity.HasComment("Архивные номера дел");

                entity.HasIndex(e => e.Id, "a_cases_pkey").IsUnique();

                entity.HasIndex(e => e.Id, "a_cases_id_idx1");

                entity.HasIndex(e => e.Year, "a_cases_id_idx2");

                entity.HasIndex(e => e.SOfficesIdAdd, "a_cases_id_idx3");

                entity.HasIndex(e => e.CustomerPhone1, "a_cases_id_idx4");

                entity.HasIndex(e => e.CustomerPhone2, "a_cases_id_idx5");

                entity.HasIndex(e => e.CustomerEmail, "a_cases_id_idx6");

                entity.HasIndex(e => new { e.DocumentSerial, e.DocumentNumber }, "a_cases_id_idx7");

                entity.HasIndex(e => e.CustomerInn, "a_cases_id_idx8");

                entity.HasIndex(e => e.CustomerSnils, "a_cases_id_idx9");

                entity.HasIndex(e => e.SServicesCustomerTypeId, "a_cases_id_idx10");

                entity.HasIndex(e => e.SServicesStatusId, "a_cases_id_idx11");

                entity.Property(e => e.Id)
                    .HasMaxLength(70)
                    .HasColumnName("id")
                    .HasComment("Номер дела");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(500)
                    .HasColumnName("customer_address")
                    .HasComment("Адрес");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(70)
                    .HasColumnName("customer_email")
                    .HasComment("Почта");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name")
                    .HasComment("Заявитель");

                entity.Property(e => e.CustomerPhone1)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_1")
                    .HasComment("Телефон 1");

                entity.Property(e => e.CustomerPhone2)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_2")
                    .HasComment("Телефон 2");

                entity.Property(e => e.CustomerInn)
                    .HasMaxLength(30)
                    .HasColumnName("customer_inn")
                    .HasComment("ИНН");

                entity.Property(e => e.CustomerSnils)
                    .HasMaxLength(30)
                    .HasColumnName("customer_snils")
                    .HasComment("снилс");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DocumentBirthDate)
                    .HasColumnName("document_birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .HasColumnName("document_number")
                    .HasComment("Номер документа");

                entity.Property(e => e.DocumentSerial)
                    .HasMaxLength(10)
                    .HasColumnName("document_serial")
                    .HasComment("Серия документа");

                entity.Property(e => e.EmployeeNameAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employee_name_add")
                    .HasComment("Сотрудник принявший услугу");

                entity.Property(e => e.EmployeeNameExecution)
                    .HasMaxLength(70)
                    .HasColumnName("employee_name_execution")
                    .HasComment("Сотрудник исполнивший услугу");

                entity.Property(e => e.OfficeNameAdd)
                    .HasMaxLength(255)
                    .HasColumnName("office_name_add")
                    .HasComment("Место приема услуги");

                entity.Property(e => e.OfficeNameProvider)
                    .HasMaxLength(255)
                    .HasColumnName("office_name_provider")
                    .HasComment("Поставщик услуги");

                entity.Property(e => e.SOfficesIdAdd)
                    .HasColumnName("s_offices_id_add")
                    .HasComment("Место приема услуги");

                entity.Property(e => e.SServicesCustomerTypeId)
                   .HasColumnName("s_services_customer_type_id")
                   .HasComment("Тип");

                entity.Property(e => e.SServicesStatusId)
                   .HasColumnName("s_services_status_id")
                   .HasComment("Статус");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(1500)
                    .HasColumnName("service_name")
                    .HasComment("Услуга");

                entity.Property(e => e.SmsRating)
                    .HasColumnName("sms_rating")
                    .HasComment("Оценка полученая по СМС с таблицы d_poll_region_sms");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(30)
                    .HasColumnName("status_name")
                    .HasComment("Статус");

                entity.Property(e => e.TicketQueue)
                    .HasMaxLength(10)
                    .HasColumnName("ticket_queue")
                    .HasComment("Номер талона электронной очереди");

                entity.Property(e => e.Year)
                    .HasColumnName("year_")
                    .HasComment("Год приема");
            });

            modelBuilder.Entity<ACasesView>(entity =>
            {
                entity.ToTable("a_cases_view", "archive");

                entity.HasComment("История просмотров обращений");

                entity.HasIndex(e => e.Id, "a_cases_view_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.ACasesId, "a_cases_view_idx2");

                entity.HasIndex(e => e.SEmployeesId, "a_cases_view_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Обращение");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления");

                entity.Property(e => e.EmployeesName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_name")
                    .HasComment("Сотрудник");

                entity.Property(e => e.JobPositionName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("job_position_name")
                    .HasComment("Должность");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Организация");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");
            });

            modelBuilder.Entity<APremium>(entity =>
            {
                entity.ToTable("a_premium", "salary");

                entity.HasComment("Зарплата сотрудников");

                entity.HasIndex(e => e.Id, "a_premium_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "a_premium_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "a_premium_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SOfficesId, "a_premium_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AvgTimeQueuePremium)
                    .HasPrecision(32)
                    .HasColumnName("avg_time_queue_premium")
                    .HasComment("Премия за среднее время ожидания в минутах");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления данных");

                entity.Property(e => e.DefaultPremium)
                    .HasPrecision(15, 2)
                    .HasColumnName("default_premium")
                    .HasComment("Установленная надбавка");

                entity.Property(e => e.EmployeesPremium)
                    .HasPrecision(15, 2)
                    .HasColumnName("employees_premium")
                    .HasComment("Итоговая зарплата без штрафов");

                entity.Property(e => e.EmployeesPremiumIasMkgu)
                    .HasPrecision(15, 2)
                    .HasColumnName("employees_premium_ias_mkgu")
                    .HasComment("Интенсивность за ИАС МКГУ с сайта");

                entity.Property(e => e.EmployeesPremiumIasMkguOur)
                    .HasPrecision(15, 2)
                    .HasColumnName("employees_premium_ias_mkgu_our")
                    .HasComment("Интенсивность за ИАС МКГУ наш");

                entity.Property(e => e.EmployeesPremiumQueue)
                    .HasPrecision(15, 2)
                    .HasColumnName("employees_premium_queue")
                    .HasComment("Интенсивность за электронную очередь");

                entity.Property(e => e.EmployeesPremiumTotal)
                    .HasPrecision(15, 2)
                    .HasColumnName("employees_premium_total")
                    .HasComment("Итоговая зарплата с учетом штрафов");

                entity.Property(e => e.EmployeesSalary)
                    .HasPrecision(15, 2)
                    .HasColumnName("employees_salary")
                    .HasComment("Оклад сотрудника за день");

                entity.Property(e => e.EmployeesStake)
                    .HasPrecision(15, 2)
                    .HasColumnName("employees_stake")
                    .HasComment("Ставка сотрудника");

                entity.Property(e => e.FineCountDays)
                    .HasColumnName("fine_count_days")
                    .HasComment("Количество просроченных дней");

                entity.Property(e => e.FineSum)
                    .HasPrecision(15, 2)
                    .HasColumnName("fine_sum")
                    .HasComment("Сумма штрафа");

                entity.Property(e => e.JobType)
                    .HasColumnName("job_type_")
                    .HasComment("Тип работы. 1 - Основная работа, 2 - Совмещение");

                entity.Property(e => e.PeriodCountDay)
                    .HasColumnName("period_count_day")
                    .HasComment("Количество рабочих дней в периоде");

                entity.Property(e => e.PeriodDate)
                    .HasColumnName("period_date")
                    .HasComment("День");

                entity.Property(e => e.PeriodMonth)
                    .HasColumnName("period_month")
                    .HasComment("Месяц");

                entity.Property(e => e.PeriodYear)
                    .HasColumnName("period_year")
                    .HasComment("Год");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Cвязь с должностью");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Cвязь с филиалом");

                entity.Property(e => e.StepPremium)
                    .HasPrecision(15, 2)
                    .HasColumnName("step_premium")
                    .HasComment("Премия за собственные действия");

                entity.Property(e => e.StepPremiumOther)
                    .HasPrecision(15, 2)
                    .HasColumnName("step_premium_other")
                    .HasComment("Премия за чужие действия");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.APremia)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.APremia)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.APremia)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_offices_id_fkey");
            });

            modelBuilder.Entity<APremiumFine>(entity =>
            {
                entity.ToTable("a_premium_fine", "salary");

                entity.HasComment("Штрафы сотрудников");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.APremiumId)
                    .HasColumnName("a_premium_id")
                    .HasComment("Связь с зарплатой сотрудника");

                entity.Property(e => e.CountDayFine)
                    .HasColumnName("count_day_fine")
                    .HasComment("Количество просроченных дней");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер дела");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Связь с текущим делом");

                entity.Property(e => e.FineDate)
                    .HasColumnName("fine_date")
                    .HasComment("Дата штрафа");

                entity.Property(e => e.FinePercent)
                    .HasPrecision(15, 2)
                    .HasColumnName("fine_percent")
                    .HasComment("Процент штрафа");

                entity.Property(e => e.FineSum)
                    .HasPrecision(15, 2)
                    .HasColumnName("fine_sum")
                    .HasComment("Сумма штрафа");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Cвязь с должностью");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.Property(e => e.SRoutesStageId)
                    .HasColumnName("s_routes_stage_id")
                    .HasComment("Связь с этапом");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с услугой");

                entity.HasOne(d => d.APremium)
                    .WithMany(p => p.APremiumFines)
                    .HasForeignKey(d => d.APremiumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_a_premium_id_fkey");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.APremiumFines)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_d_cases_id_fkey");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.APremiumFines)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("a_premium_fine_d_services_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.APremiumFines)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.APremiumFines)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.APremiumFines)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_offices_id_fkey");

                entity.HasOne(d => d.SRoutesStage)
                    .WithMany(p => p.APremiumFines)
                    .HasForeignKey(d => d.SRoutesStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_s_routes_stage_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.APremiumFines)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_s_services_sub_id_fkey");
            });

            modelBuilder.Entity<APremiumStep>(entity =>
            {
                entity.ToTable("a_premium_step", "salary");

                entity.HasComment("Архив совершенных действий сотрудников");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер дела");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.Property(e => e.SPremiumStepId)
                    .HasColumnName("s_premium_step_id")
                    .HasComment("Связь с действием");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.StepDate)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("step_date")
                    .HasComment("Дата и время действия совершенного сотрудником");

                entity.Property(e => e.StepPremium)
                    .HasPrecision(15, 2)
                    .HasColumnName("step_premium")
                    .HasComment("Сумма за совершенное действие");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.APremiumSteps)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.APremiumSteps)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.APremiumSteps)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.APremiumSteps)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_offices_id_fkey");

                entity.HasOne(d => d.SPremiumStep)
                    .WithMany(p => p.APremiumSteps)
                    .HasForeignKey(d => d.SPremiumStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_step_s_premium_step_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.APremiumSteps)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_s_services_id_fkey");
            });

            modelBuilder.Entity<AService>(entity =>
            {
                entity.ToTable("a_services", "archive");

                entity.HasComment("Архивные услуги");

                entity.HasIndex(e => e.Id, "a_services_idx1");

                entity.HasIndex(e => e.SOfficesIdProvider, "a_services_idx2");

                entity.HasIndex(e => e.SServicesId, "a_services_idx4");

                entity.HasIndex(e => e.SServicesProcedureId, "a_services_idx5");

                entity.HasIndex(e => e.ACasesId, "a_services_idx6");

                entity.HasIndex(e => e.SServicesWeekId, "a_services_s_services_sub_week_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с делом");

                entity.Property(e => e.AServicesDocumentIdParent)
                    .HasColumnName("a_services_document_id_parent")
                    .HasComment("Связь с головным документом");

                entity.Property(e => e.AServicesIdParent)
                    .HasColumnName("a_services_id_parent")
                    .HasComment("Связь с головной услугой");

                entity.Property(e => e.CountDayExecution)
                    .HasColumnName("count_day_execution")
                    .HasComment("Колв-во дней на исполнение услуги(ОИВ) по регламенту");

                entity.Property(e => e.CountDayProcessing)
                    .HasColumnName("count_day_processing")
                    .HasComment("Количество дней на обработку");

                entity.Property(e => e.CountDayReturn)
                    .HasColumnName("count_day_return")
                    .HasComment("Количество дней на возврат от исполнителя услуги");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Дата внесения услуги");

                entity.Property(e => e.DateFact)
                    .HasColumnName("date_fact")
                    .HasComment("Дата фактического завершения услуги");

                entity.Property(e => e.DateReg)
                    .HasColumnName("date_reg")
                    .HasComment("Дата планового заврешения услуги с учетом выше стоящих услуг");

                entity.Property(e => e.ExtraInfo)
                    .HasColumnName("extra_info")
                    .HasComment("Дополнительная информация");

                entity.Property(e => e.FrguName)
                    .HasMaxLength(300)
                    .HasColumnName("frgu_name")
                    .HasComment("ФРГУ наименование");

                entity.Property(e => e.FrguProviderId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_provider_id")
                    .HasComment("ID Поставщика ФРГУ");

                entity.Property(e => e.FrguServiceId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_service_id")
                    .HasComment("ID услуги ФРГУ");

                entity.Property(e => e.FrguServiceSubId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_service_sub_id")
                    .HasComment("id подуслуги ФРГУ");

                entity.Property(e => e.FrguTargetId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_target_id")
                    .HasComment("ID цели из ФРГУ");

                entity.Property(e => e.IasMkgu)
                    .HasColumnName("ias_mkgu")
                    .HasComment("Участие услуги в ИАС МКГУ");

                entity.Property(e => e.NumberCopies)
                    .HasColumnName("number_copies")
                    .HasComment("Номер копии сопроводительного письма");

                entity.Property(e => e.ReportSelect)
                    .HasColumnName("report_select")
                    .HasComment("Видимость в отчетах");

                entity.Property(e => e.SEmployeesIdAdd)
                    .HasColumnName("s_employees_id_add")
                    .HasComment("Связь с сотрудником принявшим услугу");

                entity.Property(e => e.SEmployeesIdExecution)
                    .HasColumnName("s_employees_id_execution")
                    .HasComment("Связь с сотрудником, исполнившим услугу");

                entity.Property(e => e.SEmployeesJobPositionIdAdd)
                    .HasColumnName("s_employees_job_position_id_add")
                    .HasComment("Связь  с должностью сотрудника принявшего услугу");

                entity.Property(e => e.SEmployeesJobPositionIdExecution)
                    .HasColumnName("s_employees_job_position_id_execution")
                    .HasComment("Связь с должностью сотрудника исполнившего услугу");

                entity.Property(e => e.SOfficesIdAdd)
                    .HasColumnName("s_offices_id_add")
                    .HasComment("Связь с филиалом в котором принята услуга");

                entity.Property(e => e.SOfficesIdExecution)
                    .HasColumnName("s_offices_id_execution")
                    .HasComment("Связь с филиалом в котором исполнили услугу");

                entity.Property(e => e.SOfficesIdProvider)
                    .HasColumnName("s_offices_id_provider")
                    .HasComment("Поставщик услуги");

                entity.Property(e => e.SServicesCustomerTypeId)
                    .HasColumnName("s_services_customer_type_id")
                    .HasComment("Связь с типом получателя");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с подуслугой");

                entity.Property(e => e.SServicesProcedureId)
                    .HasColumnName("s_services_procedure_id")
                    .HasComment("Процедура");

                entity.Property(e => e.SServicesStatusId)
                    .HasColumnName("s_services_status_id")
                    .HasComment("Статус услуги");

                entity.Property(e => e.SServicesTariffTypeId)
                    .HasColumnName("s_services_tariff_type_id")
                    .HasComment("Связь с государственной пошлиной");

                entity.Property(e => e.SServicesWeekId)
                    .HasColumnName("s_services_week_id")
                    .HasComment("Тип дня");

                entity.Property(e => e.TariffEdit)
                    .HasColumnName("tariff_edit")
                    .HasComment("Возможность редактирования государственной пошлины");

                entity.Property(e => e.TariffMfc)
                    .HasPrecision(15, 2)
                    .HasColumnName("tariff_mfc")
                    .HasComment("Тариф для МФЦ");

                entity.Property(e => e.TariffState)
                    .HasPrecision(15, 2)
                    .HasColumnName("tariff_state")
                    .HasComment("Государственная пошлина");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServices)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_a_cases_id_fkey");

                entity.HasOne(d => d.SEmployeesIdAddNavigation)
                    .WithMany(p => p.AServiceSEmployeesIdAddNavigations)
                    .HasForeignKey(d => d.SEmployeesIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_employees_id_add_fkey");

                entity.HasOne(d => d.SEmployeesIdExecutionNavigation)
                    .WithMany(p => p.AServiceSEmployeesIdExecutionNavigations)
                    .HasForeignKey(d => d.SEmployeesIdExecution)
                    .HasConstraintName("a_services_s_employees_id_execution_fkey");

                entity.HasOne(d => d.SEmployeesJobPositionIdAddNavigation)
                    .WithMany(p => p.AServiceSEmployeesJobPositionIdAddNavigations)
                    .HasForeignKey(d => d.SEmployeesJobPositionIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_employees_job_position_id_add_fkey");

                entity.HasOne(d => d.SEmployeesJobPositionIdExecutionNavigation)
                    .WithMany(p => p.AServiceSEmployeesJobPositionIdExecutionNavigations)
                    .HasForeignKey(d => d.SEmployeesJobPositionIdExecution)
                    .HasConstraintName("a_services_s_employees_job_position_id_execution_fkey");

                entity.HasOne(d => d.SOfficesIdAddNavigation)
                    .WithMany(p => p.AServiceSOfficesIdAddNavigations)
                    .HasForeignKey(d => d.SOfficesIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_offices_id_add_fkey");

                entity.HasOne(d => d.SOfficesIdExecutionNavigation)
                    .WithMany(p => p.AServiceSOfficesIdExecutionNavigations)
                    .HasForeignKey(d => d.SOfficesIdExecution)
                    .HasConstraintName("a_services_s_offices_id_execution_fkey");

                entity.HasOne(d => d.SOfficesIdProviderNavigation)
                    .WithMany(p => p.AServiceSOfficesIdProviderNavigations)
                    .HasForeignKey(d => d.SOfficesIdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_offices_id_provider_fkey");

                entity.HasOne(d => d.SServicesCustomerType)
                    .WithMany(p => p.AServices)
                    .HasForeignKey(d => d.SServicesCustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_services_sub_customer_type_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.AServices)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_services_sub_id_fkey");

                entity.HasOne(d => d.SServicesStatus)
                    .WithMany(p => p.AServices)
                    .HasForeignKey(d => d.SServicesStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_services_status_id_fkey");

                entity.HasOne(d => d.SServicesTariffType)
                    .WithMany(p => p.AServices)
                    .HasForeignKey(d => d.SServicesTariffTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_services_sub_tariff_type_id_fkey");

                entity.HasOne(d => d.SServicesWeek)
                    .WithMany(p => p.AServices)
                    .HasForeignKey(d => d.SServicesWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_s_services_sub_week_id_fkey");
            });

            modelBuilder.Entity<AServicesAudit>(entity =>
            {
                entity.ToTable("a_services_audit", "archive");

                entity.HasComment("Изменения");

                entity.HasIndex(e => e.Id, "a_services_audit_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Changed)
                    .HasColumnType("json")
                    .HasColumnName("changed");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Обращение");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Услуга");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время");

                entity.Property(e => e.SEmployeesId).HasColumnName("s_employees_id");

                entity.Property(e => e.SEmployeesJobPositionId).HasColumnName("s_employees_job_position_id");

                entity.Property(e => e.SOfficesId).HasColumnName("s_offices_id");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesAudits)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("a_services_audit_fk");

                entity.HasOne(d => d.AServices)
                    .WithMany(p => p.AServicesAudits)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("a_services_audit_fk_1");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesAudits)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_audit_fk_2");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesAudits)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_audit_fk_3");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesAudits)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_audit_fk_4");
            });

            modelBuilder.Entity<AServicesCommentt>(entity =>
            {
                entity.ToTable("a_services_commentt", "archive");

                entity.HasComment("Список комментариев к архивным услугам");

                entity.HasIndex(e => e.ACasesId, "a_services_commentt_a_cases_id_idx");

                entity.HasIndex(e => e.Id, "a_services_commentt_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.Commentt)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления записи");

                entity.Property(e => e.IsPublicCommentt)
                    .HasColumnName("is_public_commentt")
                    .HasComment("Публичность примечания");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.IsUnicast)
                    .HasColumnName("is_unicast")
                    .HasComment("Наличие получателя");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность сотрудника добавившего запись");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал сотрудника добавившего запись");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesCommentts)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_commentt_a_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesCommentts)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_commentt_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesCommentts)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_commentt_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesCommentts)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_commentt_s_offices_id_fkey");
            });

            modelBuilder.Entity<AServicesCommenttEmployee>(entity =>
            {
                entity.ToTable("a_services_commentt_employees", "archive");

                entity.HasComment("Таблица адресатов комментариев");

                entity.HasIndex(e => e.AServicesCommenttId, "a_services_commentt_employees_a_services_commentt_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "a_services_commentt_employees_s_employees_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("первичный ключ");

                entity.Property(e => e.AServicesCommenttId)
                    .HasColumnName("a_services_commentt_id")
                    .HasComment("Связь с комментарием");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник, которому адресован комментарий ");

                entity.HasOne(d => d.AServicesCommentt)
                    .WithMany(p => p.AServicesCommenttEmployees)
                    .HasForeignKey(d => d.AServicesCommenttId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_commentt_employees_a_services_commentt_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesCommenttEmployees)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_commentt_employees_s_employees_id_fkey");
            });

            modelBuilder.Entity<AServicesCoverLetter>(entity =>
            {
                entity.ToTable("a_services_cover_letter", "archive");

                entity.HasComment("Таблица хранения сопроводительных писем прикрепленных к услуге");

                entity.HasIndex(e => e.Id, "a_services_cover_letter_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "a_services_cover_letter_s_employees_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .HasMaxLength(252)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Время добавление записи");

                entity.Property(e => e.JsonData)
                    .IsRequired()
                    .HasColumnType("jsonb")
                    .HasColumnName("json_data")
                    .HasComment("Содержание сопроводительного письма");

                entity.Property(e => e.NumberCoverLetter)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("number_cover_letter")
                    .HasComment("Код письма");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesCoverLetters)
                    .HasForeignKey(d => d.ACasesId)
                    .HasConstraintName("a_services_cover_letter_a_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesCoverLetters)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_cover_letter_s_employees_id_fkey");
            });

            modelBuilder.Entity<AServicesCustomer>(entity =>
            {
                entity.ToTable("a_services_customers", "archive");

                entity.HasComment("Список заявителей(физ лиц) по услуге");

                entity.HasIndex(e => e.ACasesId, "a_services_customers_a_cases_id_idx");

                entity.HasIndex(e => e.Id, "a_services_customers_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Номер дела заявителя");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(500)
                    .HasColumnName("customer_address")
                    .HasComment("Адрес регистрации");

                entity.Property(e => e.CustomerAddressDetail)
                    .HasColumnType("jsonb")
                    .HasColumnName("customer_address_detail")
                    .HasComment("Адрес детальный");

                entity.Property(e => e.CustomerAddressResidence)
                    .HasMaxLength(255)
                    .HasColumnName("customer_address_residence")
                    .HasComment("Адрес проживания");

                entity.Property(e => e.CustomerAddressTemp)
                    .HasMaxLength(500)
                    .HasColumnName("customer_address_temp")
                    .HasComment("Адрес регистрации временный");

                entity.Property(e => e.CustomerCodeRegion)
                    .HasMaxLength(3)
                    .HasColumnName("customer_code_region")
                    .HasComment("КОД региона");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(70)
                    .HasColumnName("customer_email")
                    .HasComment("Электронная почта заявителя");

                entity.Property(e => e.CustomerGender)
                    .HasColumnName("customer_gender")
                    .HasComment("Пол заявителя (1 - мужской, 2 - женский)");

                entity.Property(e => e.CustomerInn)
                    .HasMaxLength(30)
                    .HasColumnName("customer_inn")
                    .HasComment("ИНН");

                entity.Property(e => e.CustomerOkato)
                    .HasMaxLength(30)
                    .HasColumnName("customer_okato")
                    .HasComment("ОКАТО");

                entity.Property(e => e.CustomerOktmo)
                    .HasMaxLength(30)
                    .HasColumnName("customer_oktmo")
                    .HasComment("ОКТМО");

                entity.Property(e => e.CustomerPhone1)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_1")
                    .HasComment("Номер телефона 1");

                entity.Property(e => e.CustomerPhone2)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_2")
                    .HasComment("Номер телефона 2");

                entity.Property(e => e.CustomerSnils)
                    .HasMaxLength(20)
                    .HasColumnName("customer_snils")
                    .HasComment("СНИЛС Заявителя");

                entity.Property(e => e.CustomerType)
                    .HasColumnName("customer_type")
                    .HasComment("Тип заявителя (1 - Заявитель, 2 - Представитель)");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateTempRegistration)
                    .HasColumnName("date_temp_registration")
                    .HasComment("Дата временной регистрации");

                entity.Property(e => e.DocumentBirthDate)
                    .HasColumnName("document_birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.DocumentBirthPlace)
                    .HasMaxLength(255)
                    .HasColumnName("document_birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(30)
                    .HasColumnName("document_code")
                    .HasComment("Код документа");

                entity.Property(e => e.DocumentIssueBody)
                    .HasMaxLength(255)
                    .HasColumnName("document_issue_body")
                    .HasComment("Наименование отделения, выдавшего паспорт");

                entity.Property(e => e.DocumentIssueDate)
                    .HasColumnName("document_issue_date")
                    .HasComment("Дата выдачи паспорта");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .HasColumnName("document_number")
                    .HasComment("Номер документа");

                entity.Property(e => e.DocumentSerial)
                    .HasMaxLength(10)
                    .HasColumnName("document_serial")
                    .HasComment("Серия документа");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .HasComment("Имя");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.PollIasMkgu)
                    .HasColumnName("poll_ias_mkgu")
                    .HasComment("Согласие на участие ИАС МКГУ (0 - отказ, 1 - СМС, 2 - Через теминал)");

                entity.Property(e => e.PollRegionSms)
                    .HasColumnName("poll_region_sms")
                    .HasComment("Согласие на участие в региональном опросе");

                entity.Property(e => e.SAlertCustomerId)
                    .HasColumnName("s_alert_customer_id")
                    .HasComment("Способ оповещения, связь со справочником оповещений");

                entity.Property(e => e.SDocumentsIdentityId)
                    .HasColumnName("s_documents_identity_id")
                    .HasComment("Связь со справочником документов, удостоверяющих личность заявителя");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник, добавивший заявителя");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность сотрудника добавившего заявителя");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал сотрудника, добавившего заявителя");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("second_name")
                    .HasComment("Отчество");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesCustomers)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_a_cases_id_fkey");

                entity.HasOne(d => d.SAlertCustomer)
                    .WithMany(p => p.AServicesCustomers)
                    .HasForeignKey(d => d.SAlertCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_s_alert_customer_id_fkey");

                entity.HasOne(d => d.SDocumentsIdentity)
                    .WithMany(p => p.AServicesCustomers)
                    .HasForeignKey(d => d.SDocumentsIdentityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_s_documents_identity_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesCustomers)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesCustomers)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesCustomers)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_s_offices_id_fkey");
            });

            modelBuilder.Entity<AServicesCustomersCall>(entity =>
            {
                entity.ToTable("a_services_customers_call", "archive");

                entity.HasComment("Звонки заявителям");

                entity.HasIndex(e => e.ACasesId, "a_services_customer_call_a_cases_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "a_services_customer_call_s_employees_id_idx");

                entity.HasIndex(e => e.SFtpId, "a_services_customer_call_s_ftp_id_idx");

                entity.HasIndex(e => e.SOfficesId, "a_services_customer_call_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.AudioFormat)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("audio_format")
                    .HasComment("Формат звонка");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customer_name")
                    .HasComment("Заявитель");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone")
                    .HasComment("Номер телефона");

                entity.Property(e => e.DateCall)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_call")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время звонка");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника");

                entity.Property(e => e.SFtpId)
                    .HasColumnName("s_ftp_id")
                    .HasComment("Cвязь с FTP сервером");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.Property(e => e.SaveFtp)
                    .HasColumnName("save_ftp")
                    .HasComment("признак сохранения на FTP");

                entity.Property(e => e.TimeTalk)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("time_talk")
                    .HasDefaultValueSql("'00:00:00'::character varying")
                    .HasComment("Время разговора");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesCustomersCalls)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_call_a_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesCustomerCalls)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_call_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesCustomerCalls)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_call_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SFtp)
                    .WithMany(p => p.AServicesCustomerCalls)
                    .HasForeignKey(d => d.SFtpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_call_s_ftp_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesCustomerCalls)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_call_s_offices_id_fkey");
            });

            modelBuilder.Entity<AServicesCustomersMessage>(entity =>
            {
                entity.ToTable("a_services_customers_message", "archive");

                entity.HasComment("Сообщения заявителям");

                entity.HasIndex(e => e.ACasesId, "a_services_customer_message_a_cases_id_idx");

                entity.HasIndex(e => e.Id, "a_services_customer_message_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "a_services_customer_message_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SOfficesId, "a_services_customer_message_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Cвязь сномером дела");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customer_name")
                    .HasComment("Заявитель");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone")
                    .HasComment("номер телефона");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время сообщения");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом сотрудника");

                entity.Property(e => e.SmsId)
                    .HasColumnName("sms_id")
                    .HasComment("Идентефикатор СМС соответствующий идентефкатору из базы СМС сервиса");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("Статус СМС так же из базы СМС сервиса");

                entity.Property(e => e.TextMessage)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("text_message")
                    .HasComment("Текст сообщения");

                entity.Property(e => e.EnqueueDate)
                   .HasColumnType("timestamp(6) without time zone")
                   .HasColumnName("enqueue_date")
                   .HasComment("Дата и время помещения в очередь для отправки");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesCustomersMessages)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_message_a_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesCustomerMessages)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_message_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesCustomerMessages)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_message_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesCustomerMessages)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customer_message_s_offices_id_fkey");
            });

            modelBuilder.Entity<AServicesCustomersGisgmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("a_services_customers_gisgmp", "archive");

                entity.HasComment("Информация по задолженности с сервиса ГИС ГМП ");

                entity.HasIndex(e => e.Id, "a_services_customers_gisgmp_id_idx");

                entity.Property(e => e.AServicesCustomersId)
                    .HasColumnName("a_services_customers_id")
                    .HasComment("Связь с заявителем");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.GisgmpDebt)
                    .HasPrecision(15, 2)
                    .HasColumnName("gisgmp_debt")
                    .HasComment("Задолженность с сервиса ГИС ГМП");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником добавившим запись");

                entity.HasOne(d => d.AServicesCustomers)
                    .WithMany()
                    .HasForeignKey(d => d.AServicesCustomersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_gisgmp_a_services_customer_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany()
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_gisgmp_s_employees_id_fkey");
            });

            modelBuilder.Entity<AServicesCustomersLegal>(entity =>
            {
                entity.ToTable("a_services_customers_legal", "archive");

                entity.HasComment("Перечень юридических лиц к услуге");

                entity.HasIndex(e => e.ACasesId, "a_services_customers_legal_a_cases_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "a_services_customers_legal_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "a_services_customers_legal_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SOfficesId, "a_services_customers_legal_s_offices_id_idx");

                entity.HasIndex(e => e.SServicesCustomerTypeId, "a_services_customers_legal_s_services_sub_customer_type_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Номер дела");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("customer_address")
                    .HasComment("Адрес");

                entity.Property(e => e.CustomerAddressDetail)
                    .HasColumnType("jsonb")
                    .HasColumnName("customer_address_detail")
                    .HasComment("Адрес детальный");

                entity.Property(e => e.CustomerCodeRegion)
                    .HasMaxLength(3)
                    .HasColumnName("customer_code_region")
                    .HasComment("КОД региона");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(70)
                    .HasColumnName("customer_email")
                    .HasComment("Электронная почта заявителя");

                entity.Property(e => e.CustomerInn)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("customer_inn")
                    .HasComment("ИНН организации");

                entity.Property(e => e.CustomerKpp)
                    .HasMaxLength(20)
                    .HasColumnName("customer_kpp")
                    .HasComment("КПП юридического лица");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("customer_name")
                    .HasComment("Наименование");

                entity.Property(e => e.CustomerOgrn)
                    .HasMaxLength(20)
                    .HasColumnName("customer_ogrn")
                    .HasComment("ОГРН юридического лица");

                entity.Property(e => e.CustomerOkato)
                    .HasMaxLength(30)
                    .HasColumnName("customer_okato")
                    .HasComment("ОКАТО");

                entity.Property(e => e.CustomerOktmo)
                    .HasMaxLength(30)
                    .HasColumnName("customer_oktmo")
                    .HasComment("ОКТМО");

                entity.Property(e => e.CustomerPhone1)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_1")
                    .HasComment("Номер телефона 1");

                entity.Property(e => e.CustomerPhone2)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_2")
                    .HasComment("Номер телефона 2");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.HeadFirstName)
                    .HasMaxLength(70)
                    .HasColumnName("head_first_name")
                    .HasComment("Имя");

                entity.Property(e => e.HeadLastName)
                    .HasMaxLength(70)
                    .HasColumnName("head_last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.HeadName)
                    .HasMaxLength(100)
                    .HasColumnName("head_name")
                    .HasComment("ФИО руководителя");

                entity.Property(e => e.HeadPosition)
                    .HasMaxLength(255)
                    .HasColumnName("head_position")
                    .HasComment("Должность руководителя");

                entity.Property(e => e.HeadSecondName)
                    .HasMaxLength(70)
                    .HasColumnName("head_second_name")
                    .HasComment("Отчество");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником добавившим запись");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника, добавившего запись");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.Property(e => e.SServicesCustomerTypeId)
                    .HasColumnName("s_services_customer_type_id")
                    .HasComment("Связь с типами юридических лиц");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesCustomersLegals)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_legal_a_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesCustomersLegals)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_legal_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesCustomersLegals)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_legal_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesCustomersLegals)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_legal_s_offices_id_fkey");

                entity.HasOne(d => d.SServicesCustomerType)
                    .WithMany(p => p.AServicesCustomersLegals)
                    .HasForeignKey(d => d.SServicesCustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_legal_s_services_sub_customer_type_id_fkey");
            });

            modelBuilder.Entity<AServicesCustomersLegalGisgmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("a_services_customers_legal_gisgmp", "archive");

                entity.HasComment("Информация по задолженности с сервиса ГИС ГМП ");

                entity.HasIndex(e => e.Id, "a_services_customers_legal_gisgmp_id_idx");

                entity.Property(e => e.AServicesCustomersLegalId)
                    .HasColumnName("a_services_customers_legal_id")
                    .HasComment("Связь с заявителем юр лицо");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.GisgmpDebt)
                    .HasPrecision(15, 2)
                    .HasColumnName("gisgmp_debt")
                    .HasComment("Задолженность с сервиса ГИС ГМП");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником добавившим запись");

                entity.HasOne(d => d.AServicesCustomersLegal)
                    .WithMany()
                    .HasForeignKey(d => d.AServicesCustomersLegalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_legal_gi_a_services_customers_legal_i_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany()
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_customers_legal_gisgmp_s_employees_id_fkey");
            });

            modelBuilder.Entity<AServicesDocument>(entity =>
            {
                entity.ToTable("a_services_documents", "archive");

                entity.HasComment("Список документов к услуге");

                entity.HasIndex(e => e.ACasesId, "a_services_documents_a_cases_id_idx");

                entity.HasIndex(e => e.AServicesId, "a_services_documents_a_services_id_idx");

                entity.HasIndex(e => e.SDocumentsId, "a_services_documents_s_documents_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.AServicesId)
                    .HasColumnName("a_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.DocumentCount)
                    .HasColumnName("document_count")
                    .HasComment("Количество копий");

                entity.Property(e => e.DocumentNeeds)
                    .HasColumnName("document_needs")
                    .HasComment("Обязательный - 0, Не обязательный документ - 1,  При наличии - 2");

                entity.Property(e => e.DocumentType)
                    .HasColumnName("document_type")
                    .HasComment("Тип документа (0 - оригинал, 1 - копия)");

                entity.Property(e => e.IsCheck)
                    .HasColumnName("is_check")
                    .HasComment("Отметка о предоставлении документа заявителем");

                entity.Property(e => e.SDocumentsId)
                    .HasColumnName("s_documents_id")
                    .HasComment("Связь с документом");

                entity.Property(e => e.CountCopy)
                   .HasColumnName("count_copy")
                   .HasComment("Кол-во копий");

                entity.Property(e => e.CountOriginal)
                    .HasColumnName("count_original")
                    .HasComment("Кол-во оригиналов");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesDocuments)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_documents_a_cases_id_fkey");

                entity.HasOne(d => d.AServices)
                    .WithMany(p => p.AServicesDocuments)
                    .HasForeignKey(d => d.AServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_documents_a_services_id_fkey");

                entity.HasOne(d => d.SDocuments)
                    .WithMany(p => p.AServicesDocuments)
                    .HasForeignKey(d => d.SDocumentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_documents_s_documents_id_fkey");
            });

            modelBuilder.Entity<AServicesDocumentsResult>(entity =>
            {
                entity.ToTable("a_services_documents_result", "archive");

                entity.HasComment("Список документов результатов к услуге");

                entity.HasIndex(e => e.ACasesId, "a_services_documents_result_a_cases_id_idx");

                entity.HasIndex(e => e.AServicesId, "a_services_documents_result_a_services_id_idx");

                entity.HasIndex(e => e.SDocumentsId, "a_services_documents_result_s_documents_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.AServicesId)
                    .HasColumnName("a_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.DocumentMethod)
                    .HasColumnName("document_method")
                    .HasComment("Способы получения документа");

                entity.Property(e => e.DocumentPeriodMfc)
                    .HasMaxLength(30)
                    .HasColumnName("document_period_mfc")
                    .HasComment("Срок хранения в МФЦ");

                entity.Property(e => e.DocumentPeriodProvider)
                    .HasMaxLength(30)
                    .HasColumnName("document_period_provider")
                    .HasComment("Срок хранения в органе власти");

                entity.Property(e => e.DocumentResult)
                    .HasColumnName("document_result")
                    .HasComment("Результат положительный или отрицательный");

                entity.Property(e => e.SDocumentsId)
                    .HasColumnName("s_documents_id")
                    .HasComment("Связь со справочником документов");

                entity.Property(e => e.CountCopy)
                   .HasColumnName("count_copy")
                   .HasComment("Кол-во копий");

                entity.Property(e => e.CountOriginal)
                    .HasColumnName("count_original")
                    .HasComment("Кол-во оригиналов");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesDocumentsResults)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_documents_result_a_cases_id_fkey");

                entity.HasOne(d => d.AServices)
                    .WithMany(p => p.AServicesDocumentsResults)
                    .HasForeignKey(d => d.AServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_documents_result_a_services_id_fkey");

                entity.HasOne(d => d.SDocuments)
                    .WithMany(p => p.AServicesDocumentsResults)
                    .HasForeignKey(d => d.SDocumentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_documents_result_s_documents_id_fkey");
            });

            modelBuilder.Entity<AServicesFile>(entity =>
            {
                entity.ToTable("a_services_file", "archive");

                entity.HasComment("Ссылки на электронные образы документов к услугам");

                entity.HasIndex(e => e.ACasesId, "a_services_file_a_cases_id_idx");

                entity.HasIndex(e => e.AServicesDocumentsId, "a_services_file_a_services_documents_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "a_services_file_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "a_services_file_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SFtpId, "a_services_file_s_ftp_id_idx");

                entity.HasIndex(e => e.SOfficesId, "a_services_file_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.AServicesDocumentsId)
                    .HasColumnName("a_services_documents_id")
                    .HasComment("Cвязь документом");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудник добавившего запись");

                entity.Property(e => e.FileExtention)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("file_extention")
                    .HasComment("Расширение файла");

                entity.Property(e => e.FileFlag)
                    .HasColumnName("file_flag")
                    .HasDefaultValueSql("1")
                    .HasComment("0 - Файл присутствует на FTP, 1 - Файл отсутствует на FTP");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("file_name")
                    .HasComment("Имя файла");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер файла");

                entity.Property(e => e.IsPaid)
                    .IsRequired()
                    .HasColumnName("is_paid")
                    .HasDefaultValueSql("true")
                    .HasComment("Признак оплачиваемости файла");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником добавившим файл");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника добавившего файл");

                entity.Property(e => e.SFtpId)
                    .HasColumnName("s_ftp_id")
                    .HasComment("Cвязь с FTP сервером где храняться файлы");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалов в котором добавлен файл");

                entity.Property(e => e.TypeAddFile)
                    .HasColumnName("type_add_file")
                    .HasComment("Тип получения файла. 1 - Сканирование, 2 - С рабочего стола, 3 - С архива");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesFiles)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_a_cases_id_fkey");

                entity.HasOne(d => d.AServicesDocuments)
                    .WithMany(p => p.AServicesFiles)
                    .HasForeignKey(d => d.AServicesDocumentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_a_services_documents_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesFiles)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesFiles)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SFtp)
                    .WithMany(p => p.AServicesFiles)
                    .HasForeignKey(d => d.SFtpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_s_ftp_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesFiles)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_s_offices_id_fkey");
            });

            modelBuilder.Entity<AServicesFileResult>(entity =>
            {
                entity.ToTable("a_services_file_result", "archive");

                entity.HasComment("Список файлов с результатами услуги");

                entity.HasIndex(e => e.ACasesId, "a_services_file_result_a_cases_id_idx");

                entity.HasIndex(e => e.AServicesDocumentResultId, "a_services_file_result_a_services_document_result_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "a_services_file_result_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "a_services_file_result_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SFtpId, "a_services_file_result_s_ftp_id_idx");

                entity.HasIndex(e => e.SOfficesId, "a_services_file_result_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.AServicesDocumentResultId)
                    .HasColumnName("a_services_document_result_id")
                    .HasComment("Документ результата к услуге");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Дата внесения услуги");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудник добавившего запись");

                entity.Property(e => e.FileExtention)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("file_extention")
                    .HasComment("Расширение файла");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("file_name")
                    .HasComment("Имя файла");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер файла");

                entity.Property(e => e.IsPaid)
                    .IsRequired()
                    .HasColumnName("is_paid")
                    .HasDefaultValueSql("true")
                    .HasComment("Признак оплачиваемости файла");

                entity.Property(e => e.IsSavedFtp)
                    .HasColumnName("is_saved_ftp")
                    .HasComment("Сохранность на FTP");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником добавившим запись");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника, добавившего запись");

                entity.Property(e => e.SFtpId)
                    .HasColumnName("s_ftp_id")
                    .HasComment("Cвязь с FTP сервером где храняться файлы");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом сотрудника, добавившего запись");

                entity.Property(e => e.TypeAddFile)
                    .HasColumnName("type_add_file")
                    .HasComment("Тип добавления файла (1 - Сканирование, 2 - C рабочего стола, 3 - с архива)");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesFileResults)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_result_a_cases_id_fkey");

                entity.HasOne(d => d.AServicesDocumentResult)
                    .WithMany(p => p.AServicesFileResults)
                    .HasForeignKey(d => d.AServicesDocumentResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_result_a_services_document_result_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesFileResults)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_result_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesFileResults)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_result_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SFtp)
                    .WithMany(p => p.AServicesFileResults)
                    .HasForeignKey(d => d.SFtpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_result_s_ftp_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesFileResults)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_file_result_s_offices_id_fkey");
            });

            modelBuilder.Entity<AServicesPayment>(entity =>
            {
                entity.ToTable("a_services_payment", "archive");

                entity.HasComment("Оплата по услугам");

                entity.HasIndex(e => e.ACasesId, "a_services_payment_a_cases_id_idx");

                entity.HasIndex(e => e.AServicesCustomerId, "a_services_payment_a_services_customer_id_idx");

                entity.HasIndex(e => e.AServicesId, "a_services_payment_a_services_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "a_services_payment_s_employees_id_idx");

                entity.HasIndex(e => e.SOfficesId, "a_services_payment_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.AServicesCustomerId)
                    .HasColumnName("a_services_customer_id")
                    .HasComment("Связь с заявителем");

                entity.Property(e => e.AServicesId)
                    .HasColumnName("a_services_id")
                    .HasComment("Cвязь с услугой");

                entity.Property(e => e.CustomerFirstName)
                    .HasMaxLength(70)
                    .HasColumnName("customer_first_name")
                    .HasComment("Имя плательщика");

                entity.Property(e => e.CustomerInn)
                    .HasMaxLength(30)
                    .HasColumnName("customer_inn")
                    .HasComment("ИНН плательщика");

                entity.Property(e => e.CustomerLastName)
                    .HasMaxLength(70)
                    .HasColumnName("customer_last_name")
                    .HasComment("Фамилия плательщика");

                entity.Property(e => e.CustomerMiddleName)
                    .HasMaxLength(70)
                    .HasColumnName("customer_middle_name")
                    .HasComment("Отчество плательщика");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name")
                    .HasComment("ФИО заявителя");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(20)
                    .HasColumnName("customer_phone")
                    .HasComment("Телефон в плательщика");

                entity.Property(e => e.CustomerSnils)
                    .HasMaxLength(30)
                    .HasColumnName("customer_snils")
                    .HasComment("СНИЛС плательщика");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(10)
                    .HasColumnName("document_code")
                    .HasComment("код документа плательщика,\r\r\n«01» – паспорт гражданина РФ;\r\r\n«02» – свидетельство органов ЗАГС о рождении гражданина;\r\r\n«03» – паспорт моряка;\r\r\n«04» – удостоверение личности военнослужащего;\r\r\n«05» – военный билет военнослужащего;\r\r\n«06» – временное удостоверение личности гражданина РФ;\r\r\n«07» – справка об освобождении из мест лишения свободы;\r\r\n«08» – паспорт иностранного гражданина;\r\r\n«09» – вид на жительство;\r\r\n«10» – разрешение на временное проживание;\r\r\n«11» – удостоверение беженца;\r\r\n«12» – миграционная карта;");

                entity.Property(e => e.DocumentInfo)
                    .HasMaxLength(255)
                    .HasColumnName("document_info")
                    .HasComment("Код документа серия и номер???(Серия и номер паспорта есть выше)");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .HasColumnName("document_number")
                    .HasComment("Номер паспорта плательщика");

                entity.Property(e => e.DocumentSerial)
                    .HasMaxLength(10)
                    .HasColumnName("document_serial")
                    .HasComment("Cерия паспорта плательщика");

                entity.Property(e => e.PaymentAddress)
                    .HasMaxLength(255)
                    .HasColumnName("payment_address")
                    .HasComment("Адрес плательщика");

                entity.Property(e => e.PaymentAgent)
                    .HasColumnName("payment_agent")
                    .HasDefaultValueSql("1")
                    .HasComment("Платежный агент (1 - Чекастер, 2 -  Сотас)");

                entity.Property(e => e.PaymentBankName)
                    .HasMaxLength(100)
                    .HasColumnName("payment_bank_name")
                    .HasComment("Наименование банка");

                entity.Property(e => e.PaymentBik)
                    .HasMaxLength(20)
                    .HasColumnName("payment_bik")
                    .HasComment("БИК");

                entity.Property(e => e.PaymentCustomer)
                    .HasMaxLength(350)
                    .HasColumnName("payment_customer")
                    .HasComment("Получатель платежа (Название органа исполнительной власти)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("payment_date")
                    .HasComment("Дата оплаты по платежу");

                entity.Property(e => e.PaymentDateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("payment_date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.PaymentInn)
                    .HasMaxLength(30)
                    .HasColumnName("payment_inn")
                    .HasComment("ИНН");

                entity.Property(e => e.PaymentKbk)
                    .HasMaxLength(30)
                    .HasColumnName("payment_kbk")
                    .HasComment("КБК");

                entity.Property(e => e.PaymentKpp)
                    .HasMaxLength(30)
                    .HasColumnName("payment_kpp")
                    .HasComment("КПП");

                entity.Property(e => e.PaymentKs)
                    .HasMaxLength(30)
                    .HasColumnName("payment_ks")
                    .HasComment("Кореспондентский счет");

                entity.Property(e => e.PaymentNumber)
                    .HasColumnName("payment_number")
                    .HasComment("Номер платежа");

                entity.Property(e => e.PaymentOktmo)
                    .HasMaxLength(30)
                    .HasColumnName("payment_oktmo")
                    .HasComment("ОКТМО");

                entity.Property(e => e.PaymentOsmpId)
                    .HasMaxLength(20)
                    .HasColumnName("payment_osmp_id")
                    .HasComment("Идентификатор платежа");

                entity.Property(e => e.PaymentPrvTxn)
                    .HasColumnName("payment_prv_txn")
                    .HasDefaultValueSql("0")
                    .HasComment("Идентификатор платежа");

                entity.Property(e => e.PaymentPurpose)
                    .HasMaxLength(1500)
                    .HasColumnName("payment_purpose")
                    .HasComment("Назначение платежа (Название услуги)");

                entity.Property(e => e.PaymentRs)
                    .HasMaxLength(30)
                    .HasColumnName("payment_rs")
                    .HasComment("Расчетный счет");

                entity.Property(e => e.PaymentSign)
                    .HasColumnName("payment_sign")
                    .HasDefaultValueSql("false")
                    .HasComment("Признак оплаты");

                entity.Property(e => e.PaymentValue)
                    .HasPrecision(15, 2)
                    .HasColumnName("payment_value")
                    .HasComment("Сумма платежа");

                entity.Property(e => e.PersonalAccount)
                    .HasMaxLength(20)
                    .HasColumnName("personal_account")
                    .HasComment("Лицевой счет");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с офисом");

                entity.Property(e => e.TerminalId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("terminal_id")
                    .HasComment("id услуги в  териминале");

                entity.Property(e => e.Uin)
                    .HasMaxLength(40)
                    .HasColumnName("uin")
                    .HasComment("УИН");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesPayments)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_payment_a_cases_id_fkey");

                entity.HasOne(d => d.AServicesCustomer)
                    .WithMany(p => p.AServicesPayments)
                    .HasForeignKey(d => d.AServicesCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_payment_a_services_customer_id_fkey");

                entity.HasOne(d => d.AServices)
                    .WithMany(p => p.AServicesPayments)
                    .HasForeignKey(d => d.AServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_payment_a_services_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesPayments)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_payment_s_employees_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesPayments)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_payment_s_offices_id_fkey");
            });

            modelBuilder.Entity<AServicesRoutesStage>(entity =>
            {
                entity.ToTable("a_services_routes_stage", "archive");

                entity.HasComment("Этапы по архивным услугам");

                entity.HasIndex(e => e.ACasesId, "a_services_routes_stage_a_cases_id_idx");

                entity.HasIndex(e => e.AServicesId, "a_services_routes_stage_a_services_id_idx");

                entity.HasIndex(e => e.Id, "a_services_routes_stage_id_idx");

                //entity.HasIndex(e => e.SServicesRoutesStageId, "a_services_routes_stage_s_services_sub_routes_stage_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Номер дела");

                entity.Property(e => e.AServicesId)
                    .HasColumnName("a_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.AServicesIdParent)
                    .HasColumnName("a_services_id_parent")
                    .HasComment("Связь с головной услугой");

                entity.Property(e => e.CountDayExecution)
                    .HasColumnName("count_day_execution")
                    .HasComment("Количество дней на исполнение этапа");

                entity.Property(e => e.CountDayFact)
                    .HasColumnName("count_day_fact")
                    .HasComment("Фактическое затраченное время на исполнение этапа");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Дата начала этапа");

                entity.Property(e => e.DateFact)
                    .HasColumnName("date_fact")
                    .HasComment("Фактическая дата окончания этапа");

                entity.Property(e => e.DateReg)
                    .HasColumnName("date_reg")
                    .HasComment("Регламентная дата окончания этапа");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник который перевел этап");

                entity.Property(e => e.PassAutomatically)
                    .HasColumnName("pass_automatically")
                    .HasComment("Передача сотруднику была автоматически или в ручную");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник на которого перевели этап");

                entity.Property(e => e.SEmployeesIdAdd)
                    .HasColumnName("s_employees_id_add")
                    .HasComment("Связь с сотрудником передавшим этап");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника получившего этап");

                entity.Property(e => e.SEmployeesJobPositionIdAdd)
                    .HasColumnName("s_employees_job_position_id_add")
                    .HasComment("Связь с должностью сотрудника добавившего этап");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом сотрудника добавившего этап");

                entity.Property(e => e.SRoutesStageId)
                    .HasColumnName("s_routes_stage_id")
                    .HasComment("Этап");
/*
                entity.Property(e => e.SServicesRoutesStageId)
                    .HasColumnName("s_services_routes_stage_id")
                    .HasComment("Связь со справочником этапов к услуге");*/

                entity.Property(e => e.TimeFact)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_fact")
                    .HasComment("Фактическое время окончания этапа");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesRoutesStages)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_a_cases_id_fkey");

                entity.HasOne(d => d.AServices)
                    .WithMany(p => p.AServicesRoutesStages)
                    .HasForeignKey(d => d.AServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_a_services_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesRoutesStageSEmployees)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesIdAddNavigation)
                    .WithMany(p => p.AServicesRoutesStageSEmployeesIdAddNavigations)
                    .HasForeignKey(d => d.SEmployeesIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_s_employees_id_add_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesRoutesStageSEmployeesJobPositions)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPositionIdAddNavigation)
                    .WithMany(p => p.AServicesRoutesStageSEmployeesJobPositionIdAddNavigations)
                    .HasForeignKey(d => d.SEmployeesJobPositionIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_s_employees_job_position_id_add_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesRoutesStages)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_s_offices_id_fkey");

                entity.HasOne(d => d.SRoutesStage)
                    .WithMany(p => p.AServicesRoutesStages)
                    .HasForeignKey(d => d.SRoutesStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_s_routes_stage_id_fkey");

           /*     entity.HasOne(d => d.SServicesRoutesStage)
                    .WithMany(p => p.AServicesRoutesStages)
                    .HasForeignKey(d => d.SServicesRoutesStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_routes_stage_s_services_sub_routes_stage_id_fkey");*/
            });

            modelBuilder.Entity<AServicesSmevLog>(entity =>
            {
                entity.ToTable("a_services_smev_log", "archive");

                entity.HasComment("Лог сервиса СМЭВ");

                entity.HasIndex(e => e.AServicesSmevRequestId, "a_services_smev_log_a_smev_services_request_id_idx");

                entity.HasIndex(e => e.Id, "a_services_smev_log_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AServicesSmevRequestId)
                    .HasColumnName("a_services_smev_request_id")
                    .HasComment("Связь с запросом");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время лога");

                entity.Property(e => e.LogText)
                    .HasColumnName("log_text")
                    .HasComment("Текст лога");

                entity.Property(e => e.LogType)
                    .HasColumnName("log_type")
                    .HasComment("Тип лога");

                entity.HasOne(d => d.AServicesSmevRequest)
                    .WithMany(p => p.AServicesSmevLogs)
                    .HasForeignKey(d => d.AServicesSmevRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_smev_log_a_smev_services_request_id_fkey");
            });

            modelBuilder.Entity<AServicesSmevRequest>(entity =>
            {
                entity.ToTable("a_services_smev_request", "archive");

                entity.HasComment("Таблица запросов  СМЭВ");

                entity.HasIndex(e => e.ACasesId, "a_services_smev_request_a_cases_id_idx");

                entity.HasIndex(e => e.AServicesId, "a_services_smev_request_a_services_id_idx");

                entity.HasIndex(e => e.DateRequest, "a_services_smev_request_idx1");

                entity.HasIndex(e => e.SEmployeesId, "a_services_smev_request_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "a_services_smev_request_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SOfficesId, "a_services_smev_request_s_offices_id_idx");

                entity.HasIndex(e => e.SServicesWeekId, "a_services_smev_request_s_services_sub_week_id_idx");

                entity.HasIndex(e => e.SSmevRequestId, "a_services_smev_request_s_smev_request_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ACasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("a_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.AServicesId)
                    .HasColumnName("a_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(500)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.CountDayExecution)
                    .HasColumnName("count_day_execution")
                    .HasComment("Кол-во дней на исполнение запроса");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateFact)
                    .HasColumnName("date_fact")
                    .HasComment("Дата ответа - фактическая");

                entity.Property(e => e.DateReg)
                    .HasColumnName("date_reg")
                    .HasComment("Дата ответа - регламентная");

                entity.Property(e => e.DateRequest)
                    .HasColumnName("date_request")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата запроса");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудника добавившего запись");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(70)
                    .HasColumnName("message_id")
                    .HasComment("ID сообщения");

                entity.Property(e => e.MessageIdProvider)
                    .HasMaxLength(70)
                    .HasColumnName("message_id_provider")
                    .HasComment("ID органа исполнительной власти");

                entity.Property(e => e.Repeat)
                    .HasColumnName("repeat")
                    .HasComment("Является ли запрос повторным?");

                entity.Property(e => e.RequestHtml)
                    .HasColumnName("request_html")
                    .HasComment("Сериализованный XML, описывающий HTML отчет для запроса.");

                entity.Property(e => e.RequestIdRef)
                    .HasMaxLength(70)
                    .HasColumnName("request_id_ref")
                    .HasComment("ID запроса для повторного запроса сведений");

                entity.Property(e => e.ResponseFileName)
                    .HasMaxLength(255)
                    .HasColumnName("response_file_name")
                    .HasComment("Наименование файла хранящего ответ");

                entity.Property(e => e.ResponseHtml)
                    .HasColumnName("response_html")
                    .HasComment("Сериализованный XML, описывающий HTML отчет для окончательного ответа.");

                entity.Property(e => e.ResponseHtmlInt)
                    .HasColumnName("response_html_int")
                    .HasComment("Сериализованный XML, описывающий HTML отчет для промежуточного ответа, полученного после выполнения первой фазы асинхронного запроса.");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником отправившим запрос");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом сотрудника");

              /*  entity.Property(e => e.SOfficesRemoteWorkplaceId)
                    .HasColumnName("s_offices_remote_workplace_id")
                    .HasComment("Удаленное рабочее место");*/

                entity.Property(e => e.SServicesWeekId)
                    .HasColumnName("s_services_week_id")
                    .HasComment("Тип отсчета дней для запроса");

                entity.Property(e => e.SSmevRequestId)
                    .HasColumnName("s_smev_request_id")
                    .HasComment("Связь с запросом СМЭВ");

                entity.Property(e => e.TimeFact)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_fact")
                    .HasComment("Время ответа - фактическое");

                entity.Property(e => e.TimeRequest)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_request")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время запроса");

                entity.HasOne(d => d.ACases)
                    .WithMany(p => p.AServicesSmevRequests)
                    .HasForeignKey(d => d.ACasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_smev_request_a_cases_id_fkey");

                entity.HasOne(d => d.AServices)
                    .WithMany(p => p.AServicesSmevRequests)
                    .HasForeignKey(d => d.AServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_smev_request_a_services_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.AServicesSmevRequests)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_smev_request_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.AServicesSmevRequests)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_smev_request_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.AServicesSmevRequests)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_smev_request_s_offices_id_fkey");

                entity.HasOne(d => d.SServicesWeek)
                    .WithMany(p => p.AServicesSmevRequests)
                    .HasForeignKey(d => d.SServicesWeekId)
                    .HasConstraintName("a_services_smev_request_s_services_sub_week_id_fkey");

                entity.HasOne(d => d.SSmevRequest)
                    .WithMany(p => p.AServicesSmevRequests)
                    .HasForeignKey(d => d.SSmevRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_smev_request_s_smev_request_id_fkey");
            });

            modelBuilder.Entity<AServicesSmevRequestStatus>(entity =>
            {
                entity.ToTable("a_services_smev_request_status", "archive");

                entity.HasComment("Таблица запросов результата для асинхронных сервисев ");

                entity.HasIndex(e => e.AServicesSmevRequestId, "a_services_smev_request_status_a_smev_services_request_id_idx");

                entity.HasIndex(e => e.Id, "a_services_smev_request_status_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AServicesSmevRequestId)
                    .HasColumnName("a_services_smev_request_id")
                    .HasComment("Связь с запросом СМЭВ");

                entity.Property(e => e.DateRequest)
                    .HasColumnName("date_request")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата запроса");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(70)
                    .HasColumnName("message_id")
                    .HasComment("ID сообщения");

                entity.Property(e => e.RequestIdRef)
                    .HasMaxLength(70)
                    .HasColumnName("request_id_ref")
                    .HasComment("ID запроса для повторного запроса сведений");

                entity.Property(e => e.TimeRequest)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_request")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время запроса");

                entity.HasOne(d => d.AServicesSmevRequest)
                    .WithMany(p => p.AServicesSmevRequestStatuses)
                    .HasForeignKey(d => d.AServicesSmevRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_services_smev_request_status_a_smev_services_request_id_fkey");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AutoHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AutoHistory");

                entity.Property(e => e.Changed)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Id).HasDefaultValueSql("1");

                entity.Property(e => e.RowId)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<DAcquiring>(entity =>
            {
                entity.ToTable("d_acquiring", "core");

                entity.HasComment("Информация по платежам. Сбер Гибрид");

                entity.HasIndex(e => e.DServicesCustomersId, "d_acquiring_idx1");

                entity.HasIndex(e => e.DServicesId, "d_acquiring_idx2");

                entity.HasIndex(e => e.DateAdd, "d_acquiring_idx3");

                entity.HasIndex(e => e.SEmployeesId, "d_acquiring_idx4");

                entity.HasIndex(e => e.SOfficesId, "d_acquiring_idx5");

                entity.HasIndex(e => e.Stage, "d_acquiring_idx6");

                entity.HasIndex(e => new {e.Stage, e.Status}, "d_acquiring_idx7");

                entity.HasIndex(e => e.Id, "d_acquiring_pkey").IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Он же order_id в документации к API");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Ссылка на услугу");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер обращения");

                entity.Property(e => e.DServicesCustomersId)
                    .HasColumnName("d_services_customers_id")
                    .HasComment("Ссылка на заявителя");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Ссылка на сотрудника сделавщий запрос");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.Summ)
                    .HasPrecision(15, 2)
                    .HasColumnName("summ")
                    .HasComment("Сумма к оплате, в рублях");

                entity.Property(e => e.IsMirCard)
                    .HasColumnName("is_mir_card")
                    .HasComment("Карта МИР и все остальные");

                entity.Property(e => e.Stage)
                    .HasColumnName("stage")
                    .HasComment("Этап выполнения метода, где:\r\n0 - Новая запись\r\n1 - PreparationV2\r\n2 - Verification\r\n3 - PrecheckV2\r\n4 - Execution\r\n5 - VerificationV2\r\n6 - Check\r\n7 - Validation");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("Текущий статус:\r\nIN_WORK\r\nAWAIT\r\nSUCCESS\r\nFAILED\r\nUNKNOWN");

                entity.Property(e => e.StatusDescription)
                    .HasColumnName("status_description")
                    .HasComment("Описание статуса");

                entity.Property(e => e.IpWindow)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ip_window")
                    .HasComment("ip адрес окна откуда пришел запрос");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Ссылка на МФЦ");

                entity.Property(e => e.Uin)
                   .HasColumnName("uin")
                   .HasComment("УИН ГИСГМП");

                entity.Property(e => e.SRecipientPaymentId)
                   .HasColumnName("s_recipient_payment_id")
                   .HasComment("Ссылка на получателя платежа\r\nЕСЛИ ССЫЛКА ПУСТАЯ ЗНАЧИТ РЕКВИЗИТЫ ПОЛУЧАТЕЛЯ ПОЛУЧИЛИ ЧЕРЕЗ УИН");

                entity.Property(e => e.TypePaymet)
                    .HasColumnName("type_paymet")
                    .HasComment("Тип платежа: \r\n1 - Госпошлина \r\n2 - Часть платы МФЦ");
            });

            modelBuilder.Entity<DAisOpvAnketStatus>(entity =>
            {
                entity.ToTable("d_ais_opv_anket_status", "services");

                entity.HasComment("Статусы анкет по приему заявлений о выдаче заграничного паспорта, содержащего электронный носитель информации");

                entity.HasIndex(e => new { e.AnketStatus, e.DServicesSmevRequestId }, "d_ais_opv_anket_status_anket_status_d_services_smev_request_idx");

                entity.HasIndex(e => new { e.AnketStatus, e.RegistrationNumber }, "d_ais_opv_anket_status_anket_status_registration_number_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()");

                entity.Property(e => e.AnketStatus)
                    .HasColumnName("anket_status")
                    .HasComment("Код статуса анкеты:\r\n1 - Подана\r\n2 - Оправлена в МВД\r\n3 - Принята\r\n4 - Возврат\r\n5 - Не допущена\r\n6 - Документ изготовлен\r\n7 - Документ доставлен\r\n8 - В процессе отзыва\r\n9 - Отозвано\r\n10 - Выдача в МВД\r\n11 - Документ выдан\r\n12 - Анкета удалена\r\n13 - Госпошлина не оплачена\r\n14 - Нет биометрии");

                entity.Property(e => e.AnketStatusComment)
                    .HasMaxLength(4096)
                    .HasColumnName("anket_status_comment")
                    .HasComment("Комментарий к статусу анкеты");

                entity.Property(e => e.AnketStatusDatetime)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("anket_status_datetime")
                    .HasComment("Дата и время статуса анкеты");

                entity.Property(e => e.AnketStatusName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("anket_status_name")
                    .HasComment("Текcт статуса анкеты");

                entity.Property(e => e.AnketType)
                    .HasColumnName("anket_type")
                    .HasComment("Тип анкеты:\r\n1 - Взрослая\r\n2 - Детская");

                entity.Property(e => e.DServicesSmevRequestId)
                    .HasColumnName("d_services_smev_request_id")
                    .HasComment("Идентификатор запроса, посредством которого отправлена анкета в СМЭВ");

                entity.Property(e => e.DocumentNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("document_number")
                    .HasComment("Номер документа заявителя");

                entity.Property(e => e.DocumentSeries)
                    .HasMaxLength(10)
                    .HasColumnName("document_series")
                    .HasComment("Серия документа заявителя");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("first_name")
                    .HasComment("Имя заявителя");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия заявителя");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("patronymic")
                    .HasComment("Отчество заявителя");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("registration_number")
                    .HasComment("Двадцатипятизначный регистрационный номер анкеты");

                entity.HasOne(d => d.DServicesSmevRequest)
                    .WithMany(p => p.DAisOpvAnketStatuses)
                    .HasForeignKey(d => d.DServicesSmevRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ais_opv_anket_status_d_services_smev_request_id_fkey");
            });

            modelBuilder.Entity<DAisOpvChat>(entity =>
            {
                entity.ToTable("d_ais_opv_chat", "services");

                entity.HasComment("Таблица для хранения чата с АИС ОПВ");

                entity.HasIndex(e => new { e.ChatDirection, e.ReceivedOrSentTime, e.OutcomingMessageInvalid }, "d_ais_opv_chat_chat_direction_received_or_sent_time_outcomi_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()");

                entity.Property(e => e.ChatDirection)
                    .HasColumnName("chat_direction")
                    .HasComment("Направление сообщения:\r\n1 - входящее\r\n2 - исходящее");

                entity.Property(e => e.ChatMessage)
                    .IsRequired()
                    .HasMaxLength(4096)
                    .HasColumnName("chat_message")
                    .HasComment("Сообщение в чате");

                entity.Property(e => e.DServicesSmevRequestId)
                    .HasColumnName("d_services_smev_request_id")
                    .HasComment("Идентификатор запроса, посредством которого отправлена анкета в СМЭВ");

                entity.Property(e => e.OutcomingMessageInvalid)
                    .HasColumnName("outcoming_message_invalid")
                    .HasComment("Признак, что исходящее сообщение не валидно");

                entity.Property(e => e.ReceivedOrSentTime)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("received_or_sent_time")
                    .HasComment("Дата и время получения или отправки сообщения");

                entity.Property(e => e.Sender)
                    .HasMaxLength(255)
                    .HasColumnName("sender")
                    .HasDefaultValueSql("'МВД'::character varying")
                    .HasComment("Отправитель");

                entity.HasOne(d => d.DServicesSmevRequest)
                    .WithMany(p => p.DAisOpvChats)
                    .HasForeignKey(d => d.DServicesSmevRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ais_opv_chat_d_services_smev_request_id_fkey");
            });

            modelBuilder.Entity<DAlertEmployee>(entity =>
            {
                entity.ToTable("d_alert_employees", "core");

                entity.HasComment("Таблица уведомлений сотрудников");

                entity.HasIndex(e => e.Id, "d_alert_employees_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.DServicesId, "d_alert_employees_idx2");

                entity.HasIndex(e => e.DCasesId, "d_alert_employees_idx3");

                entity.HasIndex(e => e.SAlertEmployeeId, "d_alert_employees_idx4");

                entity.HasIndex(e => e.DServicesCommenttId, "d_alert_employees_idx5");

                entity.HasIndex(e => e.DServicesSmevRequestId, "d_alert_employees_idx6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DServicesCommenttId)
                    .HasColumnName("d_services_commentt_id")
                    .HasComment("Связь с комментарием");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Связь с услугой , data_services id");

                entity.Property(e => e.DServicesSmevRequestId)
                    .HasColumnName("d_services_smev_request_id")
                    .HasComment("Связь с запросом СМЭВ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.IsRead)
                    .HasColumnName("is_read");

                entity.Property(e => e.SAlertEmployeeId)
                    .HasColumnName("s_alert_employee_id")
                    .HasComment("Тип уведомления");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DAlertEmployees)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_employees_alert_d_cases_id_fkey");

                entity.HasOne(d => d.DServicesCommentt)
                    .WithMany(p => p.DAlertEmployees)
                    .HasForeignKey(d => d.DServicesCommenttId)
                    .HasConstraintName("d_employees_alert_d_services_commentt_id_fkey");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DAlertEmployees)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_employees_alert_d_services_id_fkey");

                entity.HasOne(d => d.DServicesSmevRequest)
                    .WithMany(p => p.DAlertEmployees)
                    .HasForeignKey(d => d.DServicesSmevRequestId)
                    .HasConstraintName("d_alert_employees_d_services_smev_request_id_fkey");

                entity.HasOne(d => d.SAlertEmployee)
                    .WithMany(p => p.DAlertEmployees)
                    .HasForeignKey(d => d.SAlertEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_alert_employees_s_alert_employee_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DAlertEmployees)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_employees_alert_s_employees_id_fkey");
            });

            modelBuilder.Entity<DCase>(entity =>
            {
                entity.ToTable("d_cases", "core");

                entity.HasComment("Список текущих обращений");

                entity.HasIndex(e => e.Id, "d_cases_id_idx");

                entity.Property(e => e.Id)
                    .HasMaxLength(70)
                    .HasColumnName("id")
                    .HasComment("Номер дела");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.SmsRating)
                    .HasColumnName("sms_rating")
                    .HasComment("Оценка полученая по СМС с таблицы d_poll_region_sms");

                entity.Property(e => e.TicketQueue)
                    .HasMaxLength(10)
                    .HasColumnName("ticket_queue")
                    .HasComment("Номер талона электронной очереди");
            });

            modelBuilder.Entity<DCasesFavorite>(entity =>
            {
                entity.ToTable("d_cases_favorites", "core");

                entity.HasComment("Избранные обращения по сотрудникам");

                entity.HasIndex(e => e.Id, "d_cases_favorites_id_idx")
                    .IsUnique();

                entity.HasIndex(e => e.DCasesId, "d_cases_favorites_id_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_cases_favorites_id_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Cвязь с делом");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления в избранное");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DCasesFavorites)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_cases_favorites_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DCasesFavorites)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_cases_favorites_s_employees_id_fkey");
            });

            modelBuilder.Entity<DCasesView>(entity =>
            {
                entity.ToTable("d_cases_view", "core");

                entity.HasComment("История просмотров обращений");

                entity.HasIndex(e => e.Id, "d_cases_view_idx1");

                entity.HasIndex(e => e.DCasesId, "d_cases_view_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_cases_view_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Обращение");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время");

                entity.Property(e => e.EmployeesName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_name")
                    .HasComment("Сотрудник");

                entity.Property(e => e.JobPositionName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("job_position_name")
                    .HasComment("Должность");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Организация");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DCasesViews)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_cases_view_fk1");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DCasesViews)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_cases_view_fk2");
            });

            modelBuilder.Entity<DElkOrder>(entity =>
            {
                entity.ToTable("d_elk_order", "services");

                entity.HasComment("Данные заявления для отправки в ЕЛК(Единый личный кабинет).");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AisOrderId)
                    .HasColumnName("ais_order_id")
                    .HasDefaultValueSql("nextval('core.d_elk_order_seq_id'::regclass)")
                    .HasComment("Идентификатор, который передается в CaseNumber, генерируется из триггера.");

                entity.Property(e => e.CustomerFirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("customer_first_name")
                    .HasComment("Имя заявителя (сотрудника юридического лица)");

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("customer_last_name")
                    .HasComment("Фамилия заявителя (сотрудника юридического лица)");

                entity.Property(e => e.CustomerMiddleName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_middle_name")
                    .HasComment("Отчество заявителя (сотрудника юридического лица) - необязательно");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время создания записи");

                entity.Property(e => e.DateSent)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_sent")
                    .HasComment("Дата и время отправки на сервис");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasComment("Примечание");

                entity.Property(e => e.Eservicecode)
                    .HasMaxLength(255)
                    .HasColumnName("eservicecode")
                    .HasComment("Идентификатор интерактивной формы на ЕПГУ");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(40)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор сообщения СМЭВ 3");

                entity.Property(e => e.Ogrn)
                    .HasMaxLength(255)
                    .HasColumnName("ogrn")
                    .HasComment("ОГРН юридического лица или ОГРНИП индивидуального предпринимателя - обязательно для для UserType = LEGAL или SOLE_PROPRIETOR");

                entity.Property(e => e.OrderComment)
                    .HasMaxLength(255)
                    .HasColumnName("order_comment")
                    .HasComment("данные для регистрации услуги в ЕЛК для клиента");

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .HasComment("Уникальный идентификатор заявления на ЕПГУ");

                entity.Property(e => e.RequestIdRef)
                    .HasMaxLength(50)
                    .HasColumnName("request_id_ref")
                    .HasComment("Идентификатор цепочки сообщений, полученный от СМЭВ.");

                entity.Property(e => e.RequestXml)
                    .HasColumnName("request_xml")
                    .HasComment("XML запроса");

                entity.Property(e => e.ResponseXml)
                    .HasColumnName("response_xml")
                    .HasComment("XML ответа");

                entity.Property(e => e.Responsecode)
                    .HasMaxLength(255)
                    .HasColumnName("responsecode")
                    .HasComment("Код результата выполнения");

                entity.Property(e => e.ResponsecodeDescription)
                    .HasMaxLength(255)
                    .HasColumnName("responsecode_description")
                    .HasComment("Описание кода результата выполнения");

                entity.Property(e => e.ServiceOkato)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("service_okato")
                    .HasComment("Местоположение заявителя по ОКАТО");

                entity.Property(e => e.Servicetargetcode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("servicetargetcode")
                    .HasComment("Идентификатор цели обращения услуги в ФРГУ");

                entity.Property(e => e.Snils)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("snils")
                    .HasComment("СНИЛС заявителя (сотрудника юридического лица) или логин заявителя");

                entity.Property(e => e.Usertype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("usertype")
                    .HasDefaultValueSql("'person'::character varying")
                    .HasComment("Тип пользователя:\r\r\nPERSON – физическое лицо, \r\r\nLEGAL – юридическое лицо,\r\r\nSOLE_PROPRIETOR – индивидуальный предприниматель,\r\r\nFOREIGNER – иностранный гражданин");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DElkOrders)
                    .HasForeignKey(d => d.DServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_elk_order_d_services_id_fkey");
            });

            modelBuilder.Entity<DElkStatusChange>(entity =>
            {
                entity.ToTable("d_elk_status_change", "services");

                entity.HasComment("Статусы заявления в ЕЛК(Единый личный кабинет)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasComment("Адрес ОИВ. Обязательно, если «action» = «ADD» или «UPDATE». Включая офис, кабинет.");

                entity.Property(e => e.Cancelallowed)
                    .HasColumnName("cancelallowed")
                    .HasComment("Возможность запроса Заявителем отмены заявления. По умолчанию cancelAllowed=false. Если cancelAllowed=true, то в карточке заявления отображается кнопка «Отменить заявление».");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("данные для изменения статуса уже созданной услуги в ЕЛК");

                entity.Property(e => e.DElkOrderId)
                    .HasColumnName("d_elk_order_id")
                    .HasComment("Cвязь с data_elk_order_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время создания записи");

                entity.Property(e => e.DateSent)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_sent")
                    .HasComment("Дата и время отправки на сервис");

                entity.Property(e => e.Eventauthor)
                    .HasMaxLength(255)
                    .HasColumnName("eventauthor")
                    .HasComment("Автор, Выводится в заявлении в поле «Автор» вкладки «История рассмотрения заявления» (необязательно)");

                entity.Property(e => e.Eventcomment)
                    .HasMaxLength(255)
                    .HasColumnName("eventcomment")
                    .HasComment("Комментарий к событию, выводится в заявлении в поле «Комментарий» вкладки «История рассмотрения заявления» (необязательно)");

                entity.Property(e => e.Eventdate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("eventdate")
                    .HasComment("Дата и время события. Если не указано, то на ЕПГУ будет выводиться системная дата получения события. (необязательно)");

                entity.Property(e => e.Infocode)
                    .HasMaxLength(255)
                    .HasColumnName("infocode")
                    .HasComment("Код информационного сообщения");

                entity.Property(e => e.InviteAction)
                    .HasMaxLength(255)
                    .HasColumnName("invite_action")
                    .HasComment("Действие: ADD - Добавление, UPDATE - Изменение, CANCEL - Отмена.");

                entity.Property(e => e.Invitecode)
                    .HasMaxLength(255)
                    .HasColumnName("invitecode")
                    .HasComment("Код приглашения в ИС ведомства, используется в дальнейшем для изменения или удаления приглашения");

                entity.Property(e => e.Inviteenddate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("inviteenddate")
                    .HasComment("Дата и время окончания (необязательно)");

                entity.Property(e => e.Invitestartdate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("invitestartdate")
                    .HasComment("Дата и время начала. Обязательно, если «action» = «ADD» или «UPDATE».");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(40)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор сообщения СМЭВ 3");

                entity.Property(e => e.Mode)
                    .HasColumnName("mode")
                    .HasComment("Тип события:\r\r\n1 = Изменение статуса\r\r\n2 = Ожидает оплаты\r\r\n3 = Оплачено\r\r\n4 = Информационное сообщение\r\r\n5 = Текстовое сообщение\r\r\n6 = Приглашение на прием");

                entity.Property(e => e.Orgname)
                    .HasMaxLength(255)
                    .HasColumnName("orgname")
                    .HasComment("Наименование ОИВ. Обязательно, если «action» = «ADD» или «UPDATE». Наименование отделения, офиса.");

                entity.Property(e => e.Paymentdescription)
                    .HasMaxLength(255)
                    .HasColumnName("paymentdescription")
                    .HasComment("Назначение платежа, для status=«W» должно быть хотя бы одно начисление. Выводится в заявлении в поле «Наименования платежа» вкладки «Счета к оплате».");

                entity.Property(e => e.Paymentsource)
                    .HasMaxLength(255)
                    .HasColumnName("paymentsource")
                    .HasComment("Источник начисления, для status=«W» должно быть хотя бы одно начисление, для ФК указывается значение «FK».");

                entity.Property(e => e.Paymentuin)
                    .HasMaxLength(255)
                    .HasColumnName("paymentuin")
                    .HasComment("Уникальный идентификатор начисления, для status=«W» должно быть хотя бы одно начисление.");

                entity.Property(e => e.RequestXml)
                    .HasColumnName("request_xml")
                    .HasComment("XML запроса");

                entity.Property(e => e.ResponseXml)
                    .HasColumnName("response_xml")
                    .HasComment("XML ответа");

                entity.Property(e => e.Responsecode)
                    .HasMaxLength(255)
                    .HasColumnName("responsecode")
                    .HasComment("Код результата выполнения");

                entity.Property(e => e.ResponsecodeDescription)
                    .HasMaxLength(255)
                    .HasColumnName("responsecode_description")
                    .HasComment("Описание кода результата выполнения");

                entity.Property(e => e.Sendmessageallowed)
                    .HasColumnName("sendmessageallowed")
                    .HasComment("Возможность посылки Заявителем текстовых сообщений в ИС государственного органа (ведомства). По умолчанию sendMessageAllowed=false.");

                entity.Property(e => e.Statusorgcode)
                    .HasMaxLength(255)
                    .HasColumnName("statusorgcode")
                    .HasComment("Код статуса заявления, используемый в ИС государственного органа (ведомства)");

                entity.Property(e => e.Statustechcode)
                    .HasColumnName("statustechcode")
                    .HasComment("Технологический код статуса на ЕПГУ, перечень технологических кодов приведен в приложении");

                entity.HasOne(d => d.DElkOrder)
                    .WithMany(p => p.DElkStatusChanges)
                    .HasForeignKey(d => d.DElkOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_elk_status_change_d_elk_order_id_fkey");
            });

            modelBuilder.Entity<DEmployeesIasMkguOfficesWebsite>(entity =>
            {
                entity.ToTable("d_employees_ias_mkgu_offices_website", "services");

                entity.HasComment("Оценки с сайта ИАС МКГУ");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время занесения записи");

                entity.Property(e => e.DateRating)
                    .HasColumnName("date_rating")
                    .HasComment("Дата выставления оценки");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудника добавившего запись");

                entity.Property(e => e.IasMkguRating)
                    .HasPrecision(15, 2)
                    .HasColumnName("ias_mkgu_rating")
                    .HasComment("Оценка с сайта");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DEmployeesIasMkguOfficesWebsites)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_offices_website_s_offices_id_fkey");
            });

            modelBuilder.Entity<DEmployeesServicesFavorite>(entity =>
            {
                entity.ToTable("d_employees_services_favorites", "core");

                entity.HasComment("Таблица для хранения избранных услуг для сотрудника, которые он сам для себя определил , для удобства при добавлении нового обращения");

                entity.HasIndex(e => e.Id, "d_employees_services_favorites_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "d_employees_services_favorites_s_employees_id_idx");

                entity.HasIndex(e => e.SServicesId, "d_employees_services_favorites_s_services_sub_id_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Подуслуга");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DEmployeesServicesFavorites)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_employees_services_favorites_s_employees_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.DEmployeesServicesFavorites)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_employees_services_favorites_s_services_sub_id_fkey");
            });

            modelBuilder.Entity<DEpguDocumentsLoad>(entity =>
            {
                entity.ToTable("d_epgu_documents_load", "services");

                entity.HasComment("Таблица для получения данных из системы ЕОС Дело");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ApplicantLegalAddress)
                    .HasMaxLength(1000)
                    .HasColumnName("applicant_legal_address")
                    .HasComment("Адрес юридический (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalChiefFio)
                    .HasMaxLength(300)
                    .HasColumnName("applicant_legal_chief_fio")
                    .HasComment("ФИО руководителя (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalEmail)
                    .HasMaxLength(110)
                    .HasColumnName("applicant_legal_email")
                    .HasComment("Адрес электронной почты (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalFactAddress)
                    .HasMaxLength(1000)
                    .HasColumnName("applicant_legal_fact_address")
                    .HasComment("Адрес почтовый (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalForm)
                    .HasMaxLength(200)
                    .HasColumnName("applicant_legal_form")
                    .HasComment("Организационно-правовая формая (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalFullname)
                    .HasMaxLength(200)
                    .HasColumnName("applicant_legal_fullname")
                    .HasComment("Полное фирменное наименование (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalInn)
                    .HasMaxLength(20)
                    .HasColumnName("applicant_legal_inn")
                    .HasComment("ИНН (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalKpp)
                    .HasMaxLength(9)
                    .HasColumnName("applicant_legal_kpp")
                    .HasComment("КПП (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalName)
                    .HasMaxLength(200)
                    .HasColumnName("applicant_legal_name")
                    .HasComment("Сокращенное фирменное наименование (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalOgrn)
                    .HasMaxLength(20)
                    .HasColumnName("applicant_legal_ogrn")
                    .HasComment("ОГРН (юридическое лицо)");

                entity.Property(e => e.ApplicantLegalPhone)
                    .HasMaxLength(10)
                    .HasColumnName("applicant_legal_phone")
                    .HasComment("Контактный телефон (юридическое лицо)");

                entity.Property(e => e.ApplicantPhysBirthdate)
                    .HasColumnName("applicant_phys_birthdate")
                    .HasComment("Дата рождения заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysBirthplace)
                    .HasMaxLength(500)
                    .HasColumnName("applicant_phys_birthplace")
                    .HasComment("Место рождения заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysEmail)
                    .HasMaxLength(110)
                    .HasColumnName("applicant_phys_email")
                    .HasComment("Email заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysFio)
                    .HasMaxLength(300)
                    .HasColumnName("applicant_phys_fio")
                    .HasComment("ФИО заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysIdentityDate)
                    .HasColumnName("applicant_phys_identity_date")
                    .HasComment("Дата выдачи документа заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysIdentityIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("applicant_phys_identity_issuer")
                    .HasComment("Орган выдачи документа заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysIdentityIssuerCode)
                    .HasMaxLength(7)
                    .HasColumnName("applicant_phys_identity_issuer_code")
                    .HasComment("Код подразделения органа выдачи документа заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysIdentityNumber)
                    .HasMaxLength(10)
                    .HasColumnName("applicant_phys_identity_number")
                    .HasComment("Номер документа заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysIdentitySeries)
                    .HasMaxLength(10)
                    .HasColumnName("applicant_phys_identity_series")
                    .HasComment("Серия документа заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysIdentityType)
                    .HasColumnName("applicant_phys_identity_type")
                    .HasComment("Тип документа заявителя (физическое лицо) (1 - паспорт РФ, 2 - иностранный паспорт, 3 - вид на жительство)");

                entity.Property(e => e.ApplicantPhysLivingAddress)
                    .HasMaxLength(1000)
                    .HasColumnName("applicant_phys_living_address")
                    .HasComment("Адрес проживания заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysPhone)
                    .HasMaxLength(10)
                    .HasColumnName("applicant_phys_phone")
                    .HasComment("Контактный телефон (физическое лицо)");

                entity.Property(e => e.ApplicantPhysRegAddress)
                    .HasMaxLength(1000)
                    .HasColumnName("applicant_phys_reg_address")
                    .HasComment("Адрес регистрации заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantPhysSnils)
                    .HasMaxLength(20)
                    .HasColumnName("applicant_phys_snils")
                    .HasComment("СНИЛС заявителя (физическое лицо)");

                entity.Property(e => e.ApplicantType)
                    .HasColumnName("applicant_type")
                    .HasComment("Тип заявителя (1 - физическое лицо, 2 - юридическое лицо)");

                entity.Property(e => e.AttachedToMfcData)
                    .HasColumnName("attached_to_mfc_data")
                    .HasComment("Флаг, что вложения данных запроса прикреплены к делу и отправлены на FTP МФЦ.");

                entity.Property(e => e.AttachmentCount)
                    .HasColumnName("attachment_count")
                    .HasComment("Количество вложений в принятом пакете документов");

                entity.Property(e => e.DCasesId)
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Cвязь с номером обращения, data_services_info id");

                entity.Property(e => e.DateCreated)
                    .HasPrecision(6)
                    .HasColumnName("date_created")
                    .HasComment("Дата и время получения данных из запроса");

                entity.Property(e => e.ElkStage)
                    .HasColumnName("elk_stage")
                    .HasComment("Статус отправки в ЕЛК:\r\n0 - Приглашение на прием не отправлено;\r\n1 - Приглашение на прием отправлено;\r\n2 - Требуется отправить статус \"Исполнено\";\r\n3 - Статус \"Исполнено\" отправлен.\r\n");

                entity.Property(e => e.EpguOrderId)
                    .HasColumnName("epgu_order_id")
                    .HasComment("Идентификатор зявления на ЕПГУ, для изменения статуса заявления или приглашениия на прием через сервис ЕЛК");

                entity.Property(e => e.OriginalMessageId)
                    .HasColumnName("original_message_id")
                    .HasComment("Начальный идентификатор MessageId запроса");

                entity.Property(e => e.PortalMfcId)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("portal_mfc_id")
                    .HasComment("Идентификатор МФЦ из справочника ПГУ");

                entity.Property(e => e.SSmevSystemAccessId)
                    .HasColumnName("s_smev_system_access_id")
                    .HasComment("Связь со справочником spr_smev_system_access -> id, идентифицирует систему, от которой пришел запрос");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(500)
                    .HasColumnName("service_name")
                    .HasComment("Наименование услуги в АИС Дело, по которой пришли документы");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("Код результата оказания услуги, принятого ведомством (1 - Исполнено, 2 - Отказ)");

                entity.Property(e => e.StatusComment)
                    .HasMaxLength(500)
                    .HasColumnName("status_comment")
                    .HasComment("Комментарий к коду результата, принятого ведомством");

                entity.Property(e => e.TestMode)
                    .IsRequired()
                    .HasColumnName("test_mode")
                    .HasDefaultValueSql("true")
                    .HasComment("Флаг, что запрос сделан в тестовом режиме (эмулятор)");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DEpguDocumentsLoads)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_epgu_documents_load_d_cases_id_fkey");

                entity.HasOne(d => d.SSmevSystemAccess)
                    .WithMany(p => p.DEpguDocumentsLoads)
                    .HasForeignKey(d => d.SSmevSystemAccessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_epgu_documents_load_s_smev_system_access_id_fkey");
            });

            modelBuilder.Entity<DEpguDocumentsResponse>(entity =>
            {
                entity.ToTable("d_epgu_documents_response", "services");

                entity.HasComment("Таблица для хранения ответов для системы ЕОС Дело");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DEpguDocumentsLoadId)
                    .HasColumnName("d_epgu_documents_load_id")
                    .HasComment("Связь с таблицей data_epgu_documents_load -> id");

                entity.Property(e => e.DateAckConfirmed)
                    .HasPrecision(6)
                    .HasColumnName("date_ack_confirmed")
                    .HasComment("Дата и время, когда пришло подтверждение получения ответа от системы Дело");

                entity.Property(e => e.DateCreated)
                    .HasPrecision(6)
                    .HasColumnName("date_created")
                    .HasComment("Дата и время создания ответа");

                entity.Property(e => e.DateResponseRequested)
                    .HasPrecision(6)
                    .HasColumnName("date_response_requested")
                    .HasComment("Дата и время, когда ответ ушел в систему Дело");

                entity.Property(e => e.MessageId)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор MessageId ответа");

                entity.Property(e => e.SSmevSystemAccessId)
                    .HasColumnName("s_smev_system_access_id")
                    .HasComment("Связь со справочником spr_smev_system_access -> id, идентифицирует систему, от которой пришел запрос");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("Статус в ответе (0 - Успешно зарегистрировано в МФЦ, 1 - Ошибка регистрации в МФЦ)");

                entity.Property(e => e.StatusComment)
                    .HasMaxLength(500)
                    .HasColumnName("status_comment")
                    .HasComment("Комментарий к статусу в ответе");

                entity.Property(e => e.TestMode)
                    .HasColumnName("test_mode")
                    .HasComment("Флаг, что это ответ на запрос, сделаный в тестовом режиме (эмулятор).");

                entity.HasOne(d => d.DEpguDocumentsLoad)
                    .WithMany(p => p.DEpguDocumentsResponses)
                    .HasForeignKey(d => d.DEpguDocumentsLoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_epgu_documents_response_d_epgu_documents_load_id_fkey");

                entity.HasOne(d => d.SSmevSystemAccess)
                    .WithMany(p => p.DEpguDocumentsResponses)
                    .HasForeignKey(d => d.SSmevSystemAccessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_epgu_documents_response_s_smev_system_access_id_fkey");
            });

            modelBuilder.Entity<DFsspUpload>(entity =>
            {
                entity.ToTable("d_fssp_upload", "services");

                entity.HasComment("Выгрузка для ФССП");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(255)
                    .HasColumnName("customer_address")
                    .HasComment("Адрес заявителя");

                entity.Property(e => e.CustomerContragentName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_contragent_name")
                    .HasComment("Наименовние фирмы/организации");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(70)
                    .HasColumnName("customer_email")
                    .HasComment("Электронная почта заявителя");

                entity.Property(e => e.CustomerInn)
                    .HasMaxLength(255)
                    .HasColumnName("customer_inn")
                    .HasComment("ИНН");

                entity.Property(e => e.CustomerKpp)
                    .HasMaxLength(255)
                    .HasColumnName("customer_kpp")
                    .HasComment("КПП");

                entity.Property(e => e.CustomerLastName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_last_name")
                    .HasComment("Фамилия заявителя");

                entity.Property(e => e.CustomerMiddleName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_middle_name")
                    .HasComment("Отчество заявителя");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name")
                    .HasComment("Имя заявителя");

                entity.Property(e => e.CustomerPhone1)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_1")
                    .HasComment("Телефон 1");

                entity.Property(e => e.CustomerPhone2)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_2")
                    .HasComment("Телефон 2");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DateAddRecord)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add_record")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateSend)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("date_send")
                    .HasComment("Дата и время отправки");

                entity.Property(e => e.DocumentBirthDate)
                    .HasColumnName("document_birth_date")
                    .HasComment("Дата рождения заявителя");

                entity.Property(e => e.IpNumbers)
                    .HasMaxLength(2000)
                    .HasColumnName("ip_numbers")
                    .HasComment("Номера исполнительных производств");

                entity.Property(e => e.OfficeName)
                    .HasMaxLength(100)
                    .HasColumnName("office_name")
                    .HasComment("Наименование филиала");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DFsspUploads)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_fssp_upload_d_cases_id_fkey");
            });

            modelBuilder.Entity<DIasMkguInfomatAnswer>(entity =>
            {
                entity.ToTable("d_ias_mkgu_infomat_answer", "services");

                entity.HasComment("Ответы на вопросы  ИАС МКГУ через теминал");

                entity.HasIndex(e => e.Id, "d_ias_mkgu_infomat_answer_idx1");

                entity.HasIndex(e => e.DCasesId, "d_ias_mkgu_infomat_answer_idx2");

                entity.HasIndex(e => e.SIasMkguQuestionId, "d_ias_mkgu_infomat_answer_idx3");

                entity.HasIndex(e => e.SIasMkguQuestionAnswerId, "d_ias_mkgu_infomat_answer_idx4");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Cвязь с номером дела");

                entity.Property(e => e.DateAnswer)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_answer")
                    .HasComment("Дата и время ответа");

                entity.Property(e => e.SIasMkguQuestionAnswerId)
                    .HasColumnName("s_ias_mkgu_question_answer_id")
                    .HasComment("Связь с ответом");

                entity.Property(e => e.SIasMkguQuestionId)
                    .HasColumnName("s_ias_mkgu_question_id")
                    .HasComment("Связь с вопросом");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DIasMkguInfomatAnswers)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_infomat_answer_d_cases_id_fkey");

                entity.HasOne(d => d.SIasMkguQuestionAnswer)
                    .WithMany(p => p.DIasMkguInfomatAnswers)
                    .HasForeignKey(d => d.SIasMkguQuestionAnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_infomat_answer_s_ias_mkgu_question_answer_id_fkey");

                entity.HasOne(d => d.SIasMkguQuestion)
                    .WithMany(p => p.DIasMkguInfomatAnswers)
                    .HasForeignKey(d => d.SIasMkguQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_infomat_answer_s_ias_mkgu_question_id_fkey");
            });

            modelBuilder.Entity<DIasMkguInfomatAnswerCommentt>(entity =>
            {
                entity.ToTable("d_ias_mkgu_infomat_answer_commentt", "services");

                entity.HasComment("Комментарии к ответам ИАС мкгу через инфомат");

                entity.HasIndex(e => e.Id, "d_ias_mkgu_infomat_answer_commentt_idx1");

                entity.HasIndex(e => e.DCasesId, "d_ias_mkgu_infomat_answer_commentt_idx2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CommenttAnswer)
                    .HasColumnName("commentt_answer")
                    .HasComment("Комментарий");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Cвязь с номером дела");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DIasMkguInfomatAnswerCommentts)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_infomat_answer_commentt_d_cases_id_fkey");
            });

            modelBuilder.Entity<DIasMkguInfomatLogUpload>(entity =>
            {
                entity.ToTable("d_ias_mkgu_infomat_log_upload", "services");

                entity.HasComment("Лог отправки данных по Инфомат оценкам ИАС МКГУ");

                entity.HasIndex(e => e.Id, "d_ias_mkgu_infomat_log_upload_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateSend)
                    .HasColumnName("date_send")
                    .HasComment("Дата отправки");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(40)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор запроса СМЭВ 3");

                entity.Property(e => e.PackedId)
                    .HasMaxLength(30)
                    .HasColumnName("packed_id")
                    .HasComment("ID пакета");

                entity.Property(e => e.RequestXml)
                    .HasColumnName("request_xml")
                    .HasComment("Запрос XML");

                entity.Property(e => e.ResponseXml)
                    .HasColumnName("response_xml")
                    .HasComment("Ответ XML");
            });

            modelBuilder.Entity<DIasMkguInfomatUpload>(entity =>
            {
                entity.ToTable("d_ias_mkgu_infomat_upload", "services");

                entity.HasComment("Данный об отправке пакетов в ИАС МКГУ оценных через инфомат");

                entity.HasIndex(e => e.Id, "d_ias_mkgu_infomat_upload_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.DCasesId, "d_ias_mkgu_infomat_upload_idx2");

                entity.HasIndex(e => e.FrguProviderId, "d_ias_mkgu_infomat_upload_idx3");

                entity.HasIndex(e => e.FrguServiceId, "d_ias_mkgu_infomat_upload_idx4");

                entity.HasIndex(e => e.FrguTargetId, "d_ias_mkgu_infomat_upload_idx5");

                entity.HasIndex(e => e.FrguProcedureId, "d_ias_mkgu_infomat_upload_idx6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DateAdd)
                    .HasColumnName("date_add")
                    .HasComment("Дата добавления записи");

                entity.Property(e => e.DateEnterFact)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_enter_fact")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата фактического добавления записи");

                entity.Property(e => e.EmployeesInfo)
                    .HasMaxLength(70)
                    .HasColumnName("employees_info")
                    .HasComment("Информация о сотруднике принявшем услугу");

                entity.Property(e => e.FrguProcedureId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_procedure_id")
                    .HasComment("Идентификатор процедуры ФРГУ");

                entity.Property(e => e.FrguProviderId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("frgu_provider_id")
                    .HasComment("фргу, id  органа власти");

                entity.Property(e => e.FrguServiceId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("frgu_service_id")
                    .HasComment("фргу, id услуги");

                entity.Property(e => e.FrguTargetId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_target_id")
                    .HasComment("фргу, id цели");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(40)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор запроса СМЭВ 3");

                entity.Property(e => e.OfficeVendorId)
                    .HasColumnName("office_vendor_id")
                    .HasComment("vendor id филиала");

                entity.Property(e => e.Okato)
                    .HasMaxLength(30)
                    .HasColumnName("okato")
                    .HasComment("окато Дагестана");

                entity.Property(e => e.PackedId)
                    .HasMaxLength(30)
                    .HasColumnName("packed_id")
                    .HasComment("id пакета с фргу");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником принявшем услугу");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Cвязь с должностью сотрудника принявшего услугу");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с офисом в котором принята услуга");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("nextval('core.d_ias_mkgu_upload_infomat_user_id_seq'::regclass)")
                    .HasComment("Внутренний идетификатор пользователя ИАС МКГУ");

                entity.Property(e => e.UserMail)
                    .HasMaxLength(30)
                    .HasColumnName("user_mail")
                    .HasComment("Электронная почта пользователя");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DIasMkguInfomatUploads)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_infoman_upload_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DIasMkguInfomatUploads)
                    .HasForeignKey(d => d.SEmployeesId)
                    .HasConstraintName("d_ias_mkgu_infoman_upload_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DIasMkguInfomatUploads)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .HasConstraintName("d_ias_mkgu_infoman_upload_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DIasMkguInfomatUploads)
                    .HasForeignKey(d => d.SOfficesId)
                    .HasConstraintName("d_ias_mkgu_infoman_upload_s_offices_id_fkey");
            });

            modelBuilder.Entity<DIasMkguProviderLoad>(entity =>
            {
                entity.HasKey(e => e.FrguProviderId)
                    .HasName("d_ias_mkgu_provider_load_pkey");

                entity.ToTable("d_ias_mkgu_provider_load", "services");

                entity.HasComment("Cписок поставщиков загруженных с ИАС МКГУ");

                entity.HasIndex(e => e.FrguProviderId, "d_ias_mkgu_provider_load_idx1");

                entity.Property(e => e.FrguProviderId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_provider_id")
                    .HasComment("ID органа власти из фргу");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasComment("дата последнего обновления");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(500)
                    .HasColumnName("provider_name")
                    .HasComment("наименование поставщика");
            });

            modelBuilder.Entity<DIasMkguRatingLoad>(entity =>
            {
                entity.ToTable("d_ias_mkgu_rating_load", "services");

                entity.HasComment("Оценки загруженные из ИАС МКГУ");

                entity.HasIndex(e => e.Id, "d_ias_mkgu_rating_load_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.FrguProviderId, "d_ias_mkgu_rating_load_idx2");

                entity.HasIndex(e => e.FrguServiceId, "d_ias_mkgu_rating_load_idx3");

                entity.HasIndex(e => e.SIasMkguIndicatorId, "d_ias_mkgu_rating_load_idx4");

                entity.HasIndex(e => e.SIasMkguCategoryId, "d_ias_mkgu_rating_load_idx5");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("created_date")
                    .HasComment("Дата и время создания оценки");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и вреемя добавления записи");

                entity.Property(e => e.FrguProviderId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("frgu_provider_id")
                    .HasComment("ID фргу органа власти");

                entity.Property(e => e.FrguServiceId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("frgu_service_id")
                    .HasComment("ID фргу услуги");

                entity.Property(e => e.PositivePercent)
                    .HasColumnName("positive_percent")
                    .HasComment("Процент удовлетворенности");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Значение оценки");

                entity.Property(e => e.SIasMkguCategoryId)
                    .HasColumnName("s_ias_mkgu_category_id")
                    .HasComment("Связь с источником оценок");

                entity.Property(e => e.SIasMkguIndicatorId)
                    .HasColumnName("s_ias_mkgu_indicator_id")
                    .HasComment("Связь с индекатором критерия");

                entity.HasOne(d => d.SIasMkguCategory)
                    .WithMany(p => p.DIasMkguRatingLoads)
                    .HasForeignKey(d => d.SIasMkguCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_rating_load_s_ias_mkgu_category_id_fkey");

                entity.HasOne(d => d.SIasMkguIndicator)
                    .WithMany(p => p.DIasMkguRatingLoads)
                    .HasForeignKey(d => d.SIasMkguIndicatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_rating_load_s_ias_mkgu_indicator_id_fkey");
            });

            modelBuilder.Entity<DIasMkguRatingLogLoad>(entity =>
            {
                entity.ToTable("d_ias_mkgu_rating_log_load", "services");

                entity.HasComment("Логи оценок, загруженных из ИАС МКГУ");

                entity.HasIndex(e => e.Id, "d_ias_mkgu_rating_log_load_idx1");

                entity.HasIndex(e => e.FrguProviderId, "d_ias_mkgu_rating_log_load_idx2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasComment("Дата конца периода оценок");

                entity.Property(e => e.FrguProviderId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("frgu_provider_id")
                    .HasComment("ID органа власти из ФРГУ");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(40)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор запроса СМЭВ 3");

                entity.Property(e => e.RequestXml)
                    .HasColumnName("request_xml")
                    .HasComment("Запрос XML");

                entity.Property(e => e.ResponseXml)
                    .HasColumnName("response_xml")
                    .HasComment("Ответ XML");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasComment("Дата начала периода оценок");
            });

            modelBuilder.Entity<DIasMkguSmsLogUpload>(entity =>
            {
                entity.ToTable("d_ias_mkgu_sms_log_upload", "services");

                entity.HasComment("Лог отправки данных по СМС оценкам ИАС МКГУ");

                entity.HasIndex(e => e.Id, "d_ias_mkgu_sms_log_upload_idx1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateSend)
                    .HasColumnName("date_send")
                    .HasComment("дата отправки");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(40)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор запроса СМЭВ 3");

                entity.Property(e => e.PackedId)
                    .HasMaxLength(30)
                    .HasColumnName("packed_id")
                    .HasComment("id пакета");

                entity.Property(e => e.RequestXml)
                    .HasColumnName("request_xml")
                    .HasComment("запрос XML");

                entity.Property(e => e.ResponseXml)
                    .HasColumnName("response_xml")
                    .HasComment("ответ XML");
            });

            modelBuilder.Entity<DIasMkguSmsUpload>(entity =>
            {
                entity.ToTable("d_ias_mkgu_sms_upload", "services");

                entity.HasComment("Данный об отправке пакетов в ИАС МКГУ на СМС опрос");

                entity.HasIndex(e => e.Id, "d_ias_mkgu_sms_upload_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.DCasesId, "d_ias_mkgu_sms_upload_idx2");

                entity.HasIndex(e => e.FrguProviderId, "d_ias_mkgu_sms_upload_idx3");

                entity.HasIndex(e => e.FrguServiceId, "d_ias_mkgu_sms_upload_idx4");

                entity.HasIndex(e => e.FrguTargetId, "d_ias_mkgu_sms_upload_idx5");

                entity.HasIndex(e => e.FrguProcedureId, "d_ias_mkgu_sms_upload_idx6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(70)
                    .HasColumnName("customer_email")
                    .HasComment("Эл. почта заявителя");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone")
                    .HasComment("Номер телефона заявителя");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата фактического добавления записи");

                entity.Property(e => e.FrguProcedureId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_procedure_id")
                    .HasComment("Идентификатор процедуры ФРГУ");

                entity.Property(e => e.FrguProviderId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("frgu_provider_id")
                    .HasComment("ФРГУ, id  органа власти");

                entity.Property(e => e.FrguServiceId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("frgu_service_id")
                    .HasComment("ФРГУ, id услуги");

                entity.Property(e => e.FrguTargetId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_target_id")
                    .HasComment("ФРГУ, id цели");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(40)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор запроса СМЭВ 3");

                entity.Property(e => e.OfficeVendorId)
                    .HasColumnName("office_vendor_id")
                    .HasComment("vendor id филиала");

                entity.Property(e => e.Okato)
                    .HasMaxLength(30)
                    .HasColumnName("okato")
                    .HasComment("Окато Дагестана");

                entity.Property(e => e.PackedId)
                    .HasMaxLength(30)
                    .HasColumnName("packed_id")
                    .HasComment("ID пакета с фргу");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Cвязь с филиалом");

                entity.Property(e => e.ServicesDateFinish)
                    .HasColumnName("services_date_finish")
                    .HasComment("Дата оказания услуги");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DIasMkguSmsUploads)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_sms_upload_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DIasMkguSmsUploads)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_sms_upload_s_employees_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DIasMkguSmsUploads)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_ias_mkgu_sms_upload_s_offices_id_fkey");
            });

            modelBuilder.Entity<DIncomingCall>(entity =>
            {
                entity.ToTable("d_incoming_call", "core");

                entity.HasComment("Входящие звонки");

                entity.HasIndex(e => e.Id, "d_incoming_call_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "d_incoming_call_s_employees_id_idx");

                entity.HasIndex(e => e.SFtpId, "d_incoming_call_s_ftp_id_idx");

                entity.HasIndex(e => e.SOfficesId, "d_incoming_call_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AudioFormat)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("audio_format")
                    .HasComment("Формат звонка");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasColumnName("customer_name")
                    .HasComment("Заявитель");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone")
                    .HasComment("Номер телефона");

                entity.Property(e => e.DateCall)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_call")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время звонка");

                entity.Property(e => e.IsSavedFtp)
                    .HasColumnName("is_saved_ftp")
                    .HasComment("Признак сохранения на FTP");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник, добавивший заявителя");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность сотрудника добавившего заявителя");

                entity.Property(e => e.SFtpId)
                    .HasColumnName("s_ftp_id")
                    .HasComment("Cвязь с FTP сервером");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал сотрудника, добавившего заявителя");

                entity.Property(e => e.TimeTalk)
                    .HasMaxLength(10)
                    .HasColumnName("time_talk")
                    .HasComment("Время разговора");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DIncomingCalls)
                    .HasForeignKey(d => d.SEmployeesId)
                    .HasConstraintName("d_incoming_call_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DIncomingCalls)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .HasConstraintName("d_incoming_call_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SFtp)
                    .WithMany(p => p.DIncomingCalls)
                    .HasForeignKey(d => d.SFtpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_incoming_call_s_ftp_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DIncomingCalls)
                    .HasForeignKey(d => d.SOfficesId)
                    .HasConstraintName("d_incoming_call_s_offices_id_fkey");
            });

            modelBuilder.Entity<DIndicatorsValue>(entity =>
            {
                entity.ToTable("d_indicators_value", "reports");

                entity.HasComment("Значения показателей для отчетов");

                entity.HasIndex(e => e.Id, "d_indicators_value_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SSmevRequestId, "d_indicators_value_idx10");

                entity.HasIndex(e => e.SRoutesStageId, "d_indicators_value_idx11");

                entity.HasIndex(e => e.SServicesStatusId, "d_indicators_value_idx12");

                entity.HasIndex(e => e.Month, "d_indicators_value_idx13");

                entity.HasIndex(e => e.Quarter, "d_indicators_value_idx14");

                entity.HasIndex(e => e.HalfYear, "d_indicators_value_idx15");

                entity.HasIndex(e => e.Year, "d_indicators_value_idx16");

                entity.HasIndex(e => e.IndicatorDate, "d_indicators_value_idx17");

                entity.HasIndex(e => e.SIndicatorsId, "d_indicators_value_idx18");

                entity.HasIndex(e => e.SOfficesId, "d_indicators_value_idx2");

                entity.HasIndex(e => e.SOfficesIdProvider, "d_indicators_value_idx20");

                entity.HasIndex(e => e.SServicesCustomerTypeId, "d_indicators_value_idx24");

                entity.HasIndex(e => e.SSmevId, "d_indicators_value_idx25");

                entity.HasIndex(e => e.SServicesProcedureId, "d_indicators_value_idx26");

                entity.HasIndex(e => e.SOfficesRemoteWorkplaceId, "d_indicators_value_idx3");

                entity.HasIndex(e => e.SEmployeesId, "d_indicators_value_idx4");

                entity.HasIndex(e => e.SEmplyeesJobPositionId, "d_indicators_value_idx5");

                entity.HasIndex(e => e.SServicesId, "d_indicators_value_idx7");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.HalfYear)
                    .HasColumnName("half_year_")
                    .HasComment("Полугодие");

                entity.Property(e => e.IndicatorDate)
                    .HasColumnName("indicator_date")
                    .HasComment("Дата значения показателя");

                entity.Property(e => e.IndicatorValue)
                    .HasPrecision(15, 2)
                    .HasColumnName("indicator_value")
                    .HasComment("Значение показателя");

                entity.Property(e => e.Month)
                    .HasColumnName("month_")
                    .HasComment("Месяц");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter_")
                    .HasComment("Квартал");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SEmplyeesJobPositionId)
                    .HasColumnName("s_emplyees_job_position_id")
                    .HasComment("Должность");

                entity.Property(e => e.SIndicatorsId)
                    .HasColumnName("s_indicators_id")
                    .HasComment("Показатель");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал/Организация");

                entity.Property(e => e.SOfficesIdProvider)
                    .HasColumnName("s_offices_id_provider")
                    .HasComment("Поставщик услуги");

                entity.Property(e => e.SOfficesRemoteWorkplaceId)
                    .HasColumnName("s_offices_remote_workplace_id")
                    .HasComment("Удаленное рабочее место(ТОСП)");

                entity.Property(e => e.SRoutesStageId)
                    .HasColumnName("s_routes_stage_id")
                    .HasComment("Этап");

                entity.Property(e => e.SServicesCustomerTypeId)
                    .HasColumnName("s_services_customer_type_id")
                    .HasComment("Тип получателя");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Услуга");

                entity.Property(e => e.SServicesProcedureId)
                    .HasColumnName("s_services_procedure_id")
                    .HasComment("Процедура");

                entity.Property(e => e.SServicesStatusId)
                    .HasColumnName("s_services_status_id")
                    .HasComment("Статус услуги");

                entity.Property(e => e.SSmevId)
                    .HasColumnName("s_smev_id")
                    .HasComment("Сервис СМЭВ");

                entity.Property(e => e.SSmevRequestId)
                    .HasColumnName("s_smev_request_id")
                    .HasComment("Запрос СМЭВ");

                entity.Property(e => e.Year)
                    .HasColumnName("year_")
                    .HasComment("Год");

                entity.Property(e => e.SServicesTypeId)
                    .HasColumnName("s_services_type_id")
                    .HasComment("Тип услуги");

                entity.Property(e => e.SServicesInteractionId)
                    .HasColumnName("s_services_interaction_id")
                    .HasComment("Вид взаимодействия");

                entity.HasOne(d => d.SIndicators)
                    .WithMany(p => p.DIndicatorsValues)
                    .HasForeignKey(d => d.SIndicatorsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_indicators_value_fk1");
            });

            modelBuilder.Entity<DInformation>(entity =>
            {
                entity.ToTable("d_information", "core");

                entity.HasComment("Информация для сотрудников, пользователей системы");

                entity.HasIndex(e => e.Id, "d_information_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SInformationTypeId, "d_information_idx2");

                entity.HasIndex(e => e.DateStart, "d_information_idx3");

                entity.HasIndex(e => e.DateStop, "d_information_idx4");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала отображения");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник");

                entity.Property(e => e.EmployeesJobPositionAdd)
                  .IsRequired()
                  .HasMaxLength(70)
                  .HasColumnName("employees_job_position_add")
                  .HasComment("Должность сотрудника");

                entity.Property(e => e.InformationText)
                    .IsRequired()
                    .HasColumnName("information_text")
                    .HasComment("Текст");

                entity.Property(e => e.InformationTopic)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("information_topic")
                    .HasComment("Информационная тема");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.SInformationTypeId)
                    .HasColumnName("s_information_type_id")
                    .HasComment("Тип информации");

                entity.HasOne(d => d.SInformationType)
                    .WithMany(p => p.DInformations)
                    .HasForeignKey(d => d.SInformationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_information_fk1");
            });

            modelBuilder.Entity<DInformationFile>(entity =>
            {
                entity.ToTable("d_information_file", "core");

                entity.HasComment("Файлы к информации");

                entity.HasIndex(e => e.Id, "d_information_file_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.DInformationId, "d_information_file_idx2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DInformationId)
                    .HasColumnName("d_information_id")
                    .HasComment("Информация");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Кто добавил ");

                entity.Property(e => e.FileExtention)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("file_extention")
                    .HasComment("Расширение");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("file_name")
                    .HasComment("Наименование");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер");

                entity.Property(e => e.File)
                    .HasColumnName("file_")
                    .HasComment("Файл");

                entity.HasOne(d => d.DInformation)
                    .WithMany(p => p.DInformationFiles)
                    .HasForeignKey(d => d.DInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_information_file_fk1");
            });

            modelBuilder.Entity<DInformationRecipient>(entity =>
            {
                entity.ToTable("d_information_recipient", "core");

                entity.HasComment("Получатели информации, Филиалы");

                entity.HasIndex(e => e.Id, "d_information_recipient_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.DInformationId, "d_information_recipient_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_information_recipient_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DInformationId)
                    .HasColumnName("d_information_id")
                    .HasComment("связь с инфо");

                entity.Property(e => e.DateAdd)
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("дата и время добавления записи");

                entity.Property(e => e.DateFamiliarization)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_familiarization")
                    .HasComment("Дата ознакомления");

                entity.Property(e => e.EmployeesFio)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio")
                    .HasComment("ФИО сотрудника получателя");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("кто добавил запись");

                entity.Property(e => e.JobPositionName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("job_position_name")
                    .HasComment("Должность");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.HasOne(d => d.DInformation)
                    .WithMany(p => p.DInformationRecipients)
                    .HasForeignKey(d => d.DInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_information_recipient_fk1");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DInformationRecipients)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_information_recipient_fk2");
            });

            modelBuilder.Entity<DMdmObjectsAttributesUpload>(entity =>
            {
                entity.ToTable("d_mdm_objects_attributes_upload", "services");

                entity.HasComment("Таблица для передачи аттрибутов объектов в МДМ.");

                entity.HasIndex(e => e.Id, "d_mdm_objects_attributes_upload_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.DMdmObjectsUploadId, "d_mdm_objects_attributes_upload_idx2");

                entity.HasIndex(e => e.SMdmObjectAttributeId, "d_mdm_objects_attributes_upload_idx3");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("nextval('services.d_mdm_objects_attributes_upload_id_seq'::regclass)")
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DMdmObjectsUploadId)
                    .HasColumnName("d_mdm_objects_upload_id")
                    .HasComment("Идентификатор объекта МДМ, связь с таблицей data_mdm_objects_upload -> id");

                entity.Property(e => e.MdmAttributeValue)
                    .HasMaxLength(150)
                    .HasColumnName("mdm_attribute_value")
                    .HasComment("Значение аттрибута объекта МДМ.");

                entity.Property(e => e.SMdmObjectAttributeId)
                    .HasColumnName("s_mdm_object_attribute_id")
                    .HasComment("Идентификатор типа аттрибута объекта МДМ, связь с таблицей spr_mdm_object_attribute -> id");

                entity.HasOne(d => d.DMdmObjectsUploads)
                    .WithMany(p => p.DMdmObjectsAttributesUploads)
                    .HasForeignKey(d => d.DMdmObjectsUploadId)
                    .HasConstraintName("d_mdm_objects_attributes_upload_fk");
                
                entity.HasOne(d => d.SMdmObjectAttributes)
                  .WithMany(p => p.DMdmObjectsAttributesUploads)
                  .HasForeignKey(d => d.SMdmObjectAttributeId)
                  .HasConstraintName("d_mdm_objects_attributes_upload_fk_1");
            });

            modelBuilder.Entity<DMdmObjectsLogUpload>(entity =>
            {
                entity.ToTable("d_mdm_objects_log_upload", "services");

                entity.HasComment("Таблица для хранения логов отправки данных в МДМ");

                entity.HasIndex(e => e.Id, "d_mdm_objects_log_upload_idx1");

                entity.HasIndex(e => e.MessageId, "d_mdm_objects_log_upload_idx2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.MessageId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("message_id")
                    .HasComment("Идентификатор сообщения СМЭВ 3");

                entity.Property(e => e.RequestXml)
                    .IsRequired()
                    .HasColumnName("request_xml")
                    .HasComment("XML запроса");

                entity.Property(e => e.ResponseXml)
                    .HasColumnName("response_xml")
                    .HasComment("XML ответа");
            });

            modelBuilder.Entity<DMdmObjectsUpload>(entity =>
            {
                entity.ToTable("d_mdm_objects_upload", "services");

                entity.HasComment("Таблица для выгрузки данных в МДМ.");

                entity.HasIndex(e => e.Id, "d_mdm_objects_upload_idx1");

                entity.HasIndex(e => e.SOfficesIdMdm, "d_mdm_objects_upload_idx2");

                entity.HasIndex(e => e.SMdmObjectTypeId, "d_mdm_objects_upload_idx3");

                entity.HasIndex(e => e.ObjectIsSent, "d_mdm_objects_upload_idx4");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("nextval('services.d_mdm_objects_upload_id_seq'::regclass)")
                    .HasColumnName("id")
                    .HasComment("Первичный ключ, не uuid потому что важен порядок следования объектов.");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("created_date")
                    .HasComment("Дата и время создания объекта.");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(70)
                    .HasColumnName("message_id")
                    .HasComment("ID сообщения СМЭВ 3");

                entity.Property(e => e.ObjectInvalid)
                    .HasColumnName("object_invalid")
                    .HasComment("true, если атрибуты объекты не полные.");

                entity.Property(e => e.ObjectIsSent)
                    .HasColumnName("object_is_sent")
                    .HasComment("Флаг, отправлен ли объект в МДМ.");

                entity.Property(e => e.SMdmObjectTypeId)
                    .HasColumnName("s_mdm_object_type_id")
                    .HasComment("Идентификатор типа объекта МДМ, связь с spr_mdm_object_type -> id");

                entity.Property(e => e.SOfficesIdMdm)
                    .HasColumnName("s_offices_id_mdm")
                    .HasComment("Идентификатор филиала МФЦ в МДМ");

                entity.Property(e => e.SentDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("sent_date")
                    .HasComment("Дата и время отправки объекта в МДМ");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Идентификатор филиала МФЦ в МДМ");
            });

            modelBuilder.Entity<DNote>(entity =>
            {
                entity.ToTable("d_notes", "core");

                entity.HasComment("Заметки сотрудников");

                entity.HasIndex(e => e.Id, "d_notes_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesId, "d_notes_idx2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер обращения");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateReminder)
                    .HasColumnName("date_reminder")
                    .HasComment("Дата для напоминания");

                entity.Property(e => e.IsViewed)
                    .HasColumnName("is_viewed")
                    .HasComment("Статус просмотра");

                entity.Property(e => e.NoteText)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("note_text")
                    .HasComment("Текст заметки");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DNotes)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_notes_fk1");
            });

            modelBuilder.Entity<DAutomaticLog>(entity =>
            {
                entity.ToTable("d_automatic_log", "services");

                entity.HasComment("Лог запуска автоматических операций");

                entity.HasIndex(e => e.Id, "d_automatic_log_pkey")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "d_automatic_log_idx1");

                entity.HasIndex(e => e.SAutomaticOperationId, "d_automatic_log_idx2");

                entity.HasIndex(e => e.DateStart, "d_automatic_log_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateStart)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_start")
                    .HasComment("Дата начала");

                entity.Property(e => e.TimeStart)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_start")
                    .HasComment("Время запуска");

                entity.Property(e => e.SAutomaticOperationId)
                    .HasColumnName("s_automatic_operation_id")
                    .HasComment("Операция");

                entity.HasOne(d => d.SAutomaticOperation)
                    .WithMany(p => p.DAutomaticLogs)
                    .HasForeignKey(d => d.SAutomaticOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_automatic_log_fk1");
            });

            modelBuilder.Entity<DPremiumFine>(entity =>
            {
                entity.ToTable("d_premium_fine", "salary");

                entity.HasComment("Штрафы сотрудников");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.CountDayFine)
                    .HasColumnName("count_day_fine")
                    .HasComment("Количество просроченных дней");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер дела");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.FineDate)
                    .HasColumnName("fine_date")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата штрафа");

                entity.Property(e => e.FinePercent)
                    .HasPrecision(15, 2)
                    .HasColumnName("fine_percent")
                    .HasComment("Процент штрафа");

                entity.Property(e => e.FineSum)
                    .HasPrecision(15, 2)
                    .HasColumnName("fine_sum")
                    .HasComment("Cумма штрафа");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Cвязь с должностью");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.Property(e => e.SRoutesStageId)
                    .HasColumnName("s_routes_stage_id")
                    .HasComment("Связь с этапом");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с услугой");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DPremiumFines)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DPremiumFines)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DPremiumFines)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DPremiumFines)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_offices_id_fkey");

                entity.HasOne(d => d.SRoutesStage)
                    .WithMany(p => p.DPremiumFines)
                    .HasForeignKey(d => d.SRoutesStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_premium_fine_s_routes_stage_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.DPremiumFines)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_s_services_sub_id_fkey");
            });

            modelBuilder.Entity<DPremiumStep>(entity =>
            {
                entity.ToTable("d_premium_step", "salary");

                entity.HasComment("Действия совершенные сотрудниками");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DCasesId)
                    .HasColumnType("character varying")
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер дела");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Связь с услугой из текущих ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Cвязь с должностью");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал сотрудника");

                entity.Property(e => e.SPremiumStepId)
                    .HasColumnName("s_premium_step_id")
                    .HasComment("Связь с действием");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с подуслугой");

                entity.Property(e => e.StepDate)
                    .HasColumnName("step_date")
                    .HasComment("Дата совершения действия");

                entity.Property(e => e.StepPremium)
                    .HasPrecision(15, 2)
                    .HasColumnName("step_premium")
                    .HasComment("Сумма за совершенное действие");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DPremiumSteps)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("a_premium_fine_d_cases_id_fkey");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DPremiumSteps)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_premium_step_d_services_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DPremiumSteps)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DPremiumSteps)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DPremiumSteps)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_s_offices_id_fkey");

                entity.HasOne(d => d.SPremiumStep)
                    .WithMany(p => p.DPremiumSteps)
                    .HasForeignKey(d => d.SPremiumStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_premium_step_s_premium_step_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.DPremiumSteps)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_premium_fine_s_services_sub_id_fkey");
            });

            modelBuilder.Entity<DQueueAvgTime>(entity =>
            {
                entity.ToTable("d_queue_avg_time", "core");

                entity.HasComment("Среднее время ожидание в очереди ");

                entity.HasIndex(e => e.SOfficesId, "d_queue_avg_time_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AvgTime)
                    .HasPrecision(15, 2)
                    .HasColumnName("avg_time")
                    .HasComment("Среднее время очереди");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateRegistration)
                    .HasColumnName("date_registration")
                    .HasComment("Дата регистрации значения");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DQueueAvgTimes)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_queue_avg_time_s_offices_id_fkey");
            });

            modelBuilder.Entity<DRatingEmployeesAll>(entity =>
            {
                entity.ToTable("d_rating_employees_all", "reports");

                entity.HasComment("Рейтинг по сотрудникам весь период");

                entity.HasIndex(e => e.Id, "d_rating_employees_all_pkey")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesJobPositionId, "d_rating_employees_all_idx2_copy1");

                entity.HasIndex(e => e.SEmployeesId, "d_rating_employees_all_idx3_copy1");

                entity.HasIndex(e => e.SOfficesId, "d_rating_employees_all_idx4_copy1");

                entity.HasIndex(e => e.RatingDate, "d_rating_employees_all_idx5_copy1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employee_name")
                    .HasComment("Сотрудник");

                entity.Property(e => e.JobPositionName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("job_position_name")
                    .HasComment("Должность");

                entity.Property(e => e.ReceivedCount)
                    .HasColumnName("received_count")
                    .HasComment("Принято");

                entity.Property(e => e.ConsultationCount)
                    .HasColumnName("consultation_count")
                    .HasComment("Консультации");

                entity.Property(e => e.IssuedCount)
                   .HasColumnName("issued_count")
                   .HasComment("Выдано");

                entity.Property(e => e.ExecutedCount)
                   .HasColumnName("executed_count")
                   .HasComment("Исполненные услуги");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasComment("Дата");

                entity.Property(e => e.RatingMoving)
                    .HasColumnName("rating_moving")
                    .HasComment("перемещение по позиции -1 вниз 0 на месте 1 вверх");

                entity.Property(e => e.RatingPosition)
                    .HasColumnName("rating_position")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");
            });

            modelBuilder.Entity<DRatingEmployeesDay>(entity =>
            {
                entity.ToTable("d_rating_employees_day", "reports");

                entity.HasComment("Рейтинг по сотрудникам  по дням");

                entity.HasIndex(e => e.Id, "d_rating_employees_day_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesJobPositionId, "d_rating_employees_day_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_rating_employees_day_idx3");

                entity.HasIndex(e => e.SOfficesId, "d_rating_employees_day_idx4");

                entity.HasIndex(e => e.RatingDate, "d_rating_employees_day_idx5");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employee_name")
                    .HasComment("Сотрудник");

                entity.Property(e => e.JobPositionName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("job_position_name")
                    .HasComment("Должность");

                entity.Property(e => e.ReceivedCount)
                    .HasColumnName("received_count")
                    .HasComment("Принято");

                entity.Property(e => e.ConsultationCount)
                    .HasColumnName("consultation_count")
                    .HasComment("Консультации");

                entity.Property(e => e.IssuedCount)
                   .HasColumnName("issued_count")
                   .HasComment("Выдано");

                entity.Property(e => e.ExecutedCount)
                   .HasColumnName("executed_count")
                   .HasComment("Исполненные услуги");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasComment("Дата");

                entity.Property(e => e.RatingMoving)
                    .HasColumnName("rating_moving")
                    .HasComment("перемещение по позиции -1 вниз 0 на месте 1 вверх");

                entity.Property(e => e.RatingPosition)
                    .HasColumnName("rating_position")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");
            });

            modelBuilder.Entity<DRatingEmployeesMonth>(entity =>
            {
                entity.ToTable("d_rating_employees_month", "reports");

                entity.HasComment("Рейтинг по сотрудникам  за месяц.");

                entity.HasIndex(e => e.Id, "d_rating_employees_month_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesJobPositionId, "d_rating_employees_month_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_rating_employees_month_idx3");

                entity.HasIndex(e => e.SOfficesId, "d_rating_employees_month_idx4");

                entity.HasIndex(e => e.Month, "d_rating_employees_month_idx5");

                entity.HasIndex(e => e.Year, "d_rating_employees_month_idx6");

                entity.HasIndex(e => e.RatingDate, "d_rating_employees_month_idx7");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employee_name")
                    .HasComment("Сотрудник");

                entity.Property(e => e.JobPositionName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("job_position_name")
                    .HasComment("Должность");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasComment("Дата");

                entity.Property(e => e.ReceivedCount)
                    .HasColumnName("received_count")
                    .HasComment("Принято");

                entity.Property(e => e.ConsultationCount)
                    .HasColumnName("consultation_count")
                    .HasComment("Консультации");

                entity.Property(e => e.IssuedCount)
                   .HasColumnName("issued_count")
                   .HasComment("Выдано");

                entity.Property(e => e.ExecutedCount)
                   .HasColumnName("executed_count")
                   .HasComment("Исполненные услуги");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.RatingMoving)
                    .HasColumnName("rating_moving")
                    .HasComment("перемещение по позиции -1 вниз 0 на месте 1 вверх");

                entity.Property(e => e.RatingPosition)
                    .HasColumnName("rating_position")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");

                entity.Property(e => e.Month)
                    .HasColumnName("month_")
                    .HasComment("Месяц");

                entity.Property(e => e.Year)
                    .HasColumnName("year_")
                    .HasComment("Год");
            });

            modelBuilder.Entity<DRatingEmployeesYear>(entity =>
            {
                entity.ToTable("d_rating_employees_year", "reports");

                entity.HasComment("Рейтинг по сотрудникам  за год. ");

                entity.HasIndex(e => e.Id, "d_rating_employees_year_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesJobPositionId, "d_rating_employees_year_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_rating_employees_year_idx3");

                entity.HasIndex(e => e.SOfficesId, "d_rating_employees_year_idx4");

                entity.HasIndex(e => e.Year, "d_rating_employees_year_idx5");

                entity.HasIndex(e => e.RatingDate, "d_rating_employees_year_idx6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employee_name")
                    .HasComment("Сотрудник");

                entity.Property(e => e.JobPositionName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("job_position_name")
                    .HasComment("Должность");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.ReceivedCount)
                   .HasColumnName("received_count")
                   .HasComment("Принято");

                entity.Property(e => e.ConsultationCount)
                    .HasColumnName("consultation_count")
                    .HasComment("Консультации");

                entity.Property(e => e.IssuedCount)
                   .HasColumnName("issued_count")
                   .HasComment("Выдано");

                entity.Property(e => e.ExecutedCount)
                   .HasColumnName("executed_count")
                   .HasComment("Исполненные услуги");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasComment("Дата");

                entity.Property(e => e.RatingMoving)
                    .HasColumnName("rating_moving")
                    .HasComment("перемещение по позиции -1 вниз 0 на месте 1 вверх");

                entity.Property(e => e.RatingPosition)
                    .HasColumnName("rating_position")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");

                entity.Property(e => e.Year)
                    .HasColumnName("year_")
                    .HasComment("Год");
            });

            modelBuilder.Entity<DRatingInitialValue>(entity =>
            {
                entity.ToTable("d_rating_initial_values", "reports");

                entity.HasComment("Данные по принятым, исполненным , и выполненным этапам по сотрудникам для рейтинга");

                entity.HasIndex(e => e.Id, "d_rating_initial_values_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesJobPositionId, "d_rating_initial_values_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_rating_initial_values_idx3");

                entity.HasIndex(e => e.SOfficesId, "d_rating_initial_values_idx4");

                entity.HasIndex(e => e.ValueDate, "d_rating_initial_values_idx5");

                entity.HasIndex(e => e.Month, "d_rating_initial_values_idx6");

                entity.HasIndex(e => e.Year, "d_rating_initial_values_idx7");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CountExecution)
                    .HasColumnName("count_execution")
                    .HasComment("Кол-во исполненых услуг");

                entity.Property(e => e.CountReceived)
                    .HasColumnName("count_received")
                    .HasComment("Кол-во принятых услуг");

                entity.Property(e => e.CountRoutesStage)
                    .HasColumnName("count_routes_stage")
                    .HasComment("Кол-во выполненых этапов");

                entity.Property(e => e.CountRoutesStageOverdue)
                    .HasColumnName("count_routes_stage_overdue")
                    .HasComment("Кол-во выполненых этапов с просрочкой");

                entity.Property(e => e.Month)
                    .HasColumnName("month_")
                    .HasComment("Месяц");

                entity.Property(e => e.PercentRoutesStageOverdue)
                    .HasPrecision(15, 2)
                    .HasColumnName("percent_routes_stage_overdue")
                    .HasComment("Процент просроченных этапов");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность сотрудника");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Офис");

                entity.Property(e => e.ValueDate)
                    .HasColumnName("value_date")
                    .HasComment("Дата значения");

                entity.Property(e => e.Year)
                    .HasColumnName("year_")
                    .HasComment("Год");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DRatingInitialValues)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_rating_initial_values_fk1");
            });

            modelBuilder.Entity<DRatingOfficesAll>(entity =>
            {
                entity.ToTable("d_rating_offices_all", "reports");

                entity.HasComment("Рейтинг филиалов весь период");

                entity.HasIndex(e => e.Id, "d_rating_offices_all_pkey")
                    .IsUnique();

                entity.HasIndex(e => e.RatingDate, "d_rating_offices_all_idx6_copy1");

                entity.HasIndex(e => e.SOfficesId, "d_rating_offices_all_idx4_copy1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.ReceivedCount)
                  .HasColumnName("received_count")
                  .HasComment("Принято");

                entity.Property(e => e.ConsultationCount)
                    .HasColumnName("consultation_count")
                    .HasComment("Консультации");

                entity.Property(e => e.IssuedCount)
                   .HasColumnName("issued_count")
                   .HasComment("Выдано");

                entity.Property(e => e.ExecutedCount)
                   .HasColumnName("executed_count")
                   .HasComment("Исполненные услуги");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasComment("Дата");

                entity.Property(e => e.RatingMoving)
                    .HasColumnName("rating_moving")
                    .HasComment("перемещение по позиции -1 вниз 0 на месте 1 вверх");

                entity.Property(e => e.RatingPosition)
                    .HasColumnName("rating_position")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");
            });

            modelBuilder.Entity<DRatingOfficesDay>(entity =>
            {
                entity.ToTable("d_rating_offices_day", "reports");

                entity.HasComment("Рейтинг филиалов по дням");

                entity.HasIndex(e => e.Id, "d_rating_offices_day_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.RatingDate, "d_rating_offices_day_idx3");

                entity.HasIndex(e => e.SOfficesId, "d_rating_offices_day_idx4");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.ReceivedCount)
                  .HasColumnName("received_count")
                  .HasComment("Принято");

                entity.Property(e => e.ConsultationCount)
                    .HasColumnName("consultation_count")
                    .HasComment("Консультации");

                entity.Property(e => e.IssuedCount)
                   .HasColumnName("issued_count")
                   .HasComment("Выдано");

                entity.Property(e => e.ExecutedCount)
                   .HasColumnName("executed_count")
                   .HasComment("Исполненные услуги");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasComment("Дата");

                entity.Property(e => e.RatingMoving)
                    .HasColumnName("rating_moving")
                    .HasComment("перемещение по позиции -1 вниз 0 на месте 1 вверх");

                entity.Property(e => e.RatingPosition)
                    .HasColumnName("rating_position")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");
            });

            modelBuilder.Entity<DRatingOfficesMonth>(entity =>
            {
                entity.ToTable("d_rating_offices_month", "reports");

                entity.HasComment("Рейтинг по  филиалам за месяц.");

                entity.HasIndex(e => e.Id, "d_rating_offices_month_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SOfficesId, "d_rating_offices_month_idx4");

                entity.HasIndex(e => e.Month, "d_rating_offices_month_idx5");

                entity.HasIndex(e => e.Year, "d_rating_offices_month_idx6");

                entity.HasIndex(e => e.RatingDate, "d_rating_offices_month_idx7");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Month)
                    .HasColumnName("month_")
                    .HasComment("Месяц");

                entity.Property(e => e.OfficesName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.ReceivedCount)
                  .HasColumnName("received_count")
                  .HasComment("Принято");

                entity.Property(e => e.ConsultationCount)
                    .HasColumnName("consultation_count")
                    .HasComment("Консультации");

                entity.Property(e => e.IssuedCount)
                   .HasColumnName("issued_count")
                   .HasComment("Выдано");

                entity.Property(e => e.ExecutedCount)
                   .HasColumnName("executed_count")
                   .HasComment("Исполненные услуги");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasComment("Дата");

                entity.Property(e => e.RatingMoving)
                    .HasColumnName("rating_moving")
                    .HasComment("перемещение по позиции -1 вниз 0 на месте 1 вверх");

                entity.Property(e => e.RatingPosition)
                    .HasColumnName("rating_position")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");

                entity.Property(e => e.Year)
                    .HasColumnName("year_")
                    .HasComment("Год");
            });

            modelBuilder.Entity<DRatingOfficesYear>(entity =>
            {
                entity.ToTable("d_rating_offices_year", "reports");

                entity.HasComment("Рейтинг по сотрудникам  за год. ");

                entity.HasIndex(e => e.Id, "d_rating_offices_year_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SOfficesId, "d_rating_offices_year_idx4");

                entity.HasIndex(e => e.Year, "d_rating_offices_year_idx5");

                entity.HasIndex(e => e.RatingDate, "d_rating_offices_year_idx6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ReceivedCount)
                  .HasColumnName("received_count")
                  .HasComment("Принято");

                entity.Property(e => e.ConsultationCount)
                    .HasColumnName("consultation_count")
                    .HasComment("Консультации");

                entity.Property(e => e.IssuedCount)
                   .HasColumnName("issued_count")
                   .HasComment("Выдано");

                entity.Property(e => e.ExecutedCount)
                   .HasColumnName("executed_count")
                   .HasComment("Исполненные услуги");

                entity.Property(e => e.RatingValue)
                    .HasColumnName("rating_value")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.OfficesName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Филиал");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasComment("Дата");

                entity.Property(e => e.RatingMoving)
                    .HasColumnName("rating_moving")
                    .HasComment("перемещение по позиции -1 вниз 0 на месте 1 вверх");

                entity.Property(e => e.RatingPosition)
                    .HasColumnName("rating_position")
                    .HasComment("Позиция по рейтингу ");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");

                entity.Property(e => e.Year)
                    .HasColumnName("year_")
                    .HasComment("Год");
            });

            modelBuilder.Entity<DSalaryRecalculationLog>(entity =>
            {
                entity.ToTable("d_salary_recalculation_log", "salary");

                entity.HasComment("Таблица хранения времени запуска перерасчета зарплат");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.DateStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_start")
                    .HasComment("Дата начала");

                entity.Property(e => e.DateStop)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DSalaryRecalculationLogs)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_salary_recalculation_log_s_employees_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DSalaryRecalculationLogs)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_salary_recalculation_log_s_offices_id_fkey");
            });

            modelBuilder.Entity<DService>(entity =>
            {
                entity.ToTable("d_services", "core");

                entity.HasComment("Таблица текущих услуг");

                entity.HasIndex(e => e.DCasesId, "d_services_idx1");

                entity.HasIndex(e => e.Id, "d_services_idx2");

                entity.HasIndex(e => e.SOfficesIdProvider, "d_services_idx3");

                entity.HasIndex(e => e.SServicesProcedureId, "d_services_idx4");

                entity.HasIndex(e => e.SServicesWeekId, "d_services_idx5");

                entity.HasIndex(e => e.SServicesId, "d_services_idx6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("первичный ключ");

                entity.Property(e => e.CountDayExecution)
                    .HasColumnName("count_day_execution")
                    .HasComment("Колв-во дней на исполнение услуги(ОИВ) по регламенту");

                entity.Property(e => e.CountDayProcessing)
                    .HasColumnName("count_day_processing")
                    .HasComment("Количество дней на обработку");

                entity.Property(e => e.CountDayReturn)
                    .HasColumnName("count_day_return")
                    .HasComment("Количество дней на возврат от исполнителя услуги");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с делом");

                entity.Property(e => e.DServicesDocumentIdParent)
                    .HasColumnName("d_services_document_id_parent")
                    .HasComment("Связь с головным документом");

                entity.Property(e => e.DServicesIdParent)
                    .HasColumnName("d_services_id_parent")
                    .HasComment("Связь с головной услугой");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Дата внесения услуги");

                entity.Property(e => e.DateFact)
                    .HasColumnName("date_fact")
                    .HasComment("Дата фактического завершения услуги");

                entity.Property(e => e.DateReg)
                    .HasColumnName("date_reg")
                    .HasComment("Дата планового заврешения услуги с учетом выше стоящих услуг");

                entity.Property(e => e.ExtraInfo)
                    //.HasColumnType("jsonb")
                    .HasColumnName("extra_info")
                    .HasComment("Дополнительная информация");

                entity.Property(e => e.FrguName)
                    .HasMaxLength(1500)
                    .HasColumnName("frgu_name")
                    .HasComment("наименование из ФРГУ");

                entity.Property(e => e.FrguProviderId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_provider_id")
                    .HasComment("ID Поставщика ФРГУ");

                entity.Property(e => e.FrguServiceId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_service_id")
                    .HasComment("ID услуги ФРГУ");

                entity.Property(e => e.FrguServiceSubId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_service_sub_id")
                    .HasComment("id подуслуги из ФРГУ");

                entity.Property(e => e.FrguTargetId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_target_id")
                    .HasComment("ID цели из ФРГУ");

                entity.Property(e => e.IasMkgu)
                    .HasColumnName("ias_mkgu")
                    .HasComment("Участие услуги в ИАС МКГУ");

                entity.Property(e => e.NumberCopies)
                    .HasColumnName("number_copies")
                    .HasComment("Номер копии сопроводительного письма");

                entity.Property(e => e.IsReportSelect)
                    .HasColumnName("is_report_select")
                    .HasComment("Видимость в отчетах");

                entity.Property(e => e.IsPlan)
                    .HasColumnName("is_plan")
                    .HasComment("Учитывать в плане(Госзадание)");

                entity.Property(e => e.SEmployeesIdAdd)
                    .HasColumnName("s_employees_id_add")
                    .HasComment("Связь с сотрудником принявшим услугу");

                entity.Property(e => e.SEmployeesIdExecution)
                    .HasColumnName("s_employees_id_execution")
                    .HasComment("Связь с сотрудником, исполнившим услугу");

                entity.Property(e => e.SEmployeesJobPositionIdAdd)
                    .HasColumnName("s_employees_job_position_id_add")
                    .HasComment("Связь  с должностью сотрудника принявшего услугу");

                entity.Property(e => e.SEmployeesJobPositionIdExecution)
                    .HasColumnName("s_employees_job_position_id_execution")
                    .HasComment("Связь с должностью сотрудника исполнившего услугу");

                entity.Property(e => e.SOfficesIdAdd)
                    .HasColumnName("s_offices_id_add")
                    .HasComment("Связь с филиалом в котором принята услуга");

                entity.Property(e => e.SOfficesIdExecution)
                    .HasColumnName("s_offices_id_execution")
                    .HasComment("Связь с филиалом в котором исполнили услугу");

                entity.Property(e => e.SOfficesIdProvider)
                    .HasColumnName("s_offices_id_provider")
                    .HasComment("Поставщик услуги");

                entity.Property(e => e.SOfficesIdProviderDepartament)
                    .HasColumnName("s_offices_id_provider_department")
                    .HasComment("Отдел");

                entity.Property(e => e.SServicesCustomerTypeId)
                    .HasColumnName("s_services_customer_type_id")
                    .HasComment("Связь с типом получателя");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с подуслугой");

                entity.Property(e => e.SServicesProcedureId)
                    .HasColumnName("s_services_procedure_id")
                    .HasComment("Процедура");

                entity.Property(e => e.SServicesStatusId)
                    .HasColumnName("s_services_status_id")
                    .HasComment("Статус услуги");

                entity.Property(e => e.SServicesTariffTypeId)
                    .HasColumnName("s_services_tariff_type_id")
                    .HasComment("Связь с государственной пошлиной");

                entity.Property(e => e.SServicesWeekId)
                    .HasColumnName("s_services_week_id")
                    .HasComment("Тип дня");

                entity.Property(e => e.TariffEdit)
                    .HasColumnName("tariff_edit")
                    .HasComment("Возможность редактирования государственной пошлины");

                entity.Property(e => e.TariffMfc)
                    .HasPrecision(15, 2)
                    .HasColumnName("tariff_mfc")
                    .HasComment("Тариф для МФЦ");

                entity.Property(e => e.TariffState)
                    .HasPrecision(15, 2)
                    .HasColumnName("tariff_state")
                    .HasComment("Государственная пошлина");

                entity.Property(e => e.SServicesTypeId)
                   .HasColumnName("s_services_type_id")
                   .HasComment("Тип услуги");

                entity.Property(e => e.SServicesInteractionId)
                   .HasColumnName("s_services_interaction_id")
                   .HasComment("Способ взаимодействия");

                entity.Property(e => e.IsIssueAuthority)
                    .HasColumnName("is_issue_authority")
                    .HasComment("Выдача в ОИВ");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customer_name")
                    .HasComment("Заявитель");

                entity.Property(e => e.CustomerPhone1)
                    .HasColumnName("customer_phone_1")
                    .HasComment("Номер телефона 1");

                entity.Property(e => e.CustomerPhone2)
                    .HasColumnName("customer_phone_2")
                    .HasComment("Номер телефона 2");

                entity.Property(e => e.CustomerAddress)
                    .HasColumnName("customer_address")
                    .HasComment("Адрес");

                entity.Property(e => e.SearchString)
                    .HasColumnName("search_string")
                    .HasComment("Поисковая строка");

                entity.Property(e => e.SRoutesStageIdCurrent)
                    .HasColumnName("s_routes_stage_id_current")
                    .HasComment("Текущий этап");

                entity.Property(e => e.SEmployeesIdCurrent)
                    .HasColumnName("s_employees_id_current")
                    .HasComment("Текущий сотрудник");

                entity.Property(e => e.SEmployeesJobPositionIdCurrent)
                    .HasColumnName("s_employees_job_position_id_current")
                    .HasComment("Текущая должность");

                entity.Property(e => e.SOfficesIdCurrent)
                    .HasColumnName("s_offices_id_current")
                    .HasComment("Текущая организация");

                entity.Property(e => e.RoutesStageDateRegCurrent)
                    .HasColumnName("routes_stage_date_reg_current")
                    .HasComment("Регламентная дата окончания тек этапа");

                entity.Property(e => e.FrguProviderIdDepartment)
                    .HasColumnName("frgu_provider_id_department")
                    .HasComment("ID Поставщика ФРГУ Отдела");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployeesIdAddNavigation)
                    .WithMany(p => p.DServiceSEmployeesIdAddNavigations)
                    .HasForeignKey(d => d.SEmployeesIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_employees_id_added_fkey");

                entity.HasOne(d => d.SEmployeesIdExecutionNavigation)
                    .WithMany(p => p.DServiceSEmployeesIdExecutionNavigations)
                    .HasForeignKey(d => d.SEmployeesIdExecution)
                    .HasConstraintName("d_services_s_employees_id_execution_fkey");

                entity.HasOne(d => d.SEmployeesIdCurrentNavigation)
                    .WithMany(p => p.DServiceSEmployeesIdCurrentNavigations)
                    .HasForeignKey(d => d.SEmployeesIdCurrent)
                    .HasConstraintName("d_services_fk19");

                entity.HasOne(d => d.SEmployeesJobPositionIdAddNavigation)
                    .WithMany(p => p.DServiceSEmployeesJobPositionIdAddNavigations)
                    .HasForeignKey(d => d.SEmployeesJobPositionIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_employees_job_position_id_added_fkey");

                entity.HasOne(d => d.SEmployeesJobPositionIdExecutionNavigation)
                    .WithMany(p => p.DServiceSEmployeesJobPositionIdExecutionNavigations)
                    .HasForeignKey(d => d.SEmployeesJobPositionIdExecution)
                    .HasConstraintName("d_services_s_employees_job_position_id_execution_fkey");

                entity.HasOne(d => d.SEmployeesJobPositionIdCurrentNavigation)
                    .WithMany(p => p.DServiceSEmployeesJobPositionIdCurrentNavigations)
                    .HasForeignKey(d => d.SEmployeesJobPositionIdCurrent)
                    .HasConstraintName("d_services_fk17");

                entity.HasOne(d => d.SOfficesIdAddNavigation)
                    .WithMany(p => p.DServiceSOfficesIdAddNavigations)
                    .HasForeignKey(d => d.SOfficesIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_offices_id_added_fkey");

                entity.HasOne(d => d.SOfficesIdExecutionNavigation)
                    .WithMany(p => p.DServiceSOfficesIdExecutionNavigations)
                    .HasForeignKey(d => d.SOfficesIdExecution)
                    .HasConstraintName("d_services_s_offices_id_execution_fkey");

                entity.HasOne(d => d.SOfficesIdCurrentNavigation)
                    .WithMany(p => p.DServiceSOfficesIdCurrentNavigations)
                    .HasForeignKey(d => d.SOfficesIdCurrent)
                    .HasConstraintName("d_services_fk18");

                entity.HasOne(d => d.SOfficesIdProviderNavigation)
                    .WithMany(p => p.DServiceSOfficesIdProviderNavigations)
                    .HasForeignKey(d => d.SOfficesIdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_offices_id_provider_fkey");

                entity.HasOne(d => d.SOfficesIdProviderDepartamentNavigation)
                    .WithMany(p => p.DServiceSOfficesIdProviderDepartamentNavigation)
                    .HasForeignKey(d => d.SOfficesIdProviderDepartament)
                    .HasConstraintName("d_services_fk");

                entity.HasOne(d => d.SServicesCustomerType)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.SServicesCustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_services_sub_customer_type_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_services_sub_id_fkey");

                entity.HasOne(d => d.SServicesStatus)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.SServicesStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_services_status_id_fkey");

                entity.HasOne(d => d.SServicesTariffType)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.SServicesTariffTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_services_sub_tariff_type_id_fkey");

                entity.HasOne(d => d.SServicesWeek)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.SServicesWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_services_sub_week_id_fkey");

                entity.HasOne(d => d.SServicesProcedure)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.SServicesProcedureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_s_services_procedure_id_fkey");

                entity.HasOne(d => d.SServicesType)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.SServicesTypeId)
                    .HasConstraintName("d_services_fk14");

                entity.HasOne(d => d.SServicesInteraction)
                    .WithMany(p => p.DServices)
                    .HasForeignKey(d => d.SServicesInteractionId)
                    .HasConstraintName("d_services_fk15");

                entity.HasOne(d => d.SRoutesStage)
                    .WithMany(p => p.DServicesRoutesStagesCurrent)
                    .HasForeignKey(d => d.SRoutesStageIdCurrent)
                    .HasConstraintName("d_services_fk16");
            });

            modelBuilder.Entity<DServicesAudit>(entity =>
            {
                entity.ToTable("d_services_audit", "core");

                entity.HasComment("Изменения");

                entity.HasIndex(e => new { e.Id, e.DCasesId, e.DServicesId }, "d_services_audit_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Changed)
                    .HasColumnType("json")
                    .HasColumnName("changed")
                    .HasComment("изменение");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Обращение");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Услуга");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("дата и время");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("сотрудник");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("должность");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("организация");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesAudits)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_audit_fk");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DServicesAudits)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_services_audit_fk_1");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesAudits)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_audit_fk_2");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesAudits)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_audit_fk_3");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesAudits)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_audit_fk_4");
            });

            modelBuilder.Entity<DServicesCommentt>(entity =>
            {
                entity.ToTable("d_services_commentt", "core");

                entity.HasComment("Список комментариев к услугам");

                entity.HasIndex(e => e.DCasesId, "d_services_commentt_d_cases_id_idx");

                entity.HasIndex(e => e.Id, "d_services_commentt_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления записи");

                entity.Property(e => e.IsPublicCommentt)
                    .HasColumnName("is_public_commentt")
                    .HasComment("Публичность примечания");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.IsUnicast)
                    .HasColumnName("is_unicast")
                    .HasComment("Наличие получателя");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность сотрудника добавившего запись");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал сотрудника добавившего запись");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesCommentts)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_commentt_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesCommentts)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_commentt_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesCommentts)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_commentt_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesCommentts)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_commentt_s_offices_id_fkey");
            });

            modelBuilder.Entity<DServicesCommenttEmployee>(entity =>
            {
                entity.ToTable("d_services_commentt_employees", "core");

                entity.HasComment("Таблица адресатов комментариев");

                entity.HasIndex(e => e.Id, "d_services_commentt_employees_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.DServicesCommenttId, "d_services_commentt_employees_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_services_commentt_employees_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("первичный ключ");

                entity.Property(e => e.DServicesCommenttId)
                    .HasColumnName("d_services_commentt_id")
                    .HasComment("Связь с комментарием");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник, которому адресован комментарий ");

                entity.HasOne(d => d.DServicesCommentt)
                    .WithMany(p => p.DServicesCommenttEmployees)
                    .HasForeignKey(d => d.DServicesCommenttId)
                    .HasConstraintName("d_services_commentt_employees_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesCommenttEmployees)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_commentt_customer_s_employees_id_fkey");
            });

            modelBuilder.Entity<DServicesCoverLetter>(entity =>
            {
                entity.ToTable("d_services_cover_letter", "core");

                entity.HasComment("Таблица хранения сопроводительных писем прикрепленных к услуге");

                entity.HasIndex(e => e.Id, "d_services_cover_letter_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_services_cover_letter_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .HasMaxLength(252)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Время добавление записи");

                entity.Property(e => e.JsonData)
                    .IsRequired()
                    .HasColumnType("jsonb")
                    .HasColumnName("json_data")
                    .HasComment("Содержание сопроводительного письма");

                entity.Property(e => e.NumberCoverLetter)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("number_cover_letter")
                    .HasComment("Код письма");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesCoverLetters)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_cover_letter_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesCoverLetters)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_cover_letter_s_employees_id_fkey");
            });

            modelBuilder.Entity<DServicesCustomer>(entity =>
            {
                entity.ToTable("d_services_customers", "core");

                entity.HasComment("Список заявителей(физ лиц) по услуге");

                entity.HasIndex(e => e.DCasesId, "d_services_customers_d_cases_id_idx");

                entity.HasIndex(e => e.Id, "d_services_customers_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(500)
                    .HasColumnName("customer_address")
                    .HasComment("Адрес регистрации");

                entity.Property(e => e.CustomerAddressDetail)
                    .HasColumnType("jsonb")
                    .HasColumnName("customer_address_detail")
                    .HasComment("Адрес регистрации детальный");

                entity.Property(e => e.CustomerAddressResidence)
                    .HasMaxLength(255)
                    .HasColumnName("customer_address_residence")
                    .HasComment("Адрес проживания");

                entity.Property(e => e.CustomerAddressTemp)
                    .HasMaxLength(500)
                    .HasColumnName("customer_address_temp")
                    .HasComment("Адрес регистрации временный");

                entity.Property(e => e.CustomerCodeRegion)
                    .HasMaxLength(3)
                    .HasColumnName("customer_code_region")
                    .HasComment("КОД региона");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(70)
                    .HasColumnName("customer_email")
                    .HasComment("Электронная почта заявителя");

                entity.Property(e => e.CustomerGender)
                    .HasColumnName("customer_gender")
                    .HasComment("Пол заявителя (1 - мужской, 2 - женский)");

                entity.Property(e => e.CustomerInn)
                    .HasMaxLength(30)
                    .HasColumnName("customer_inn")
                    .HasComment("ИНН");

                entity.Property(e => e.CustomerOkato)
                    .HasMaxLength(30)
                    .HasColumnName("customer_okato")
                    .HasComment("ОКАТО");

                entity.Property(e => e.CustomerOktmo)
                    .HasMaxLength(30)
                    .HasColumnName("customer_oktmo")
                    .HasComment("ОКТМО");

                entity.Property(e => e.CustomerPhone1)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_1")
                    .HasComment("Номер телефона 1");

                entity.Property(e => e.CustomerPhone2)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_2")
                    .HasComment("Номер телефона 2");

                entity.Property(e => e.CustomerSnils)
                    .HasMaxLength(20)
                    .HasColumnName("customer_snils")
                    .HasComment("СНИЛС Заявителя");

                entity.Property(e => e.CustomerType)
                    .HasColumnName("customer_type")
                    .HasComment("Тип заявителя (1 - Заявитель, 2 - Представитель)");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер дела заявителя");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateTempRegistration)
                    .HasColumnName("date_temp_registration")
                    .HasComment("Дата временной регистрации");

                entity.Property(e => e.DocumentBirthDate)
                    .HasColumnName("document_birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.DocumentBirthPlace)
                    .HasMaxLength(255)
                    .HasColumnName("document_birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(30)
                    .HasColumnName("document_code")
                    .HasComment("Код документа");

                entity.Property(e => e.DocumentIssueBody)
                    .HasMaxLength(255)
                    .HasColumnName("document_issue_body")
                    .HasComment("Наименование отделения, выдавшего паспорт");

                entity.Property(e => e.DocumentIssueDate)
                    .HasColumnName("document_issue_date")
                    .HasComment("Дата выдачи паспорта");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .HasColumnName("document_number")
                    .HasComment("Номер документа");

                entity.Property(e => e.DocumentSerial)
                    .HasMaxLength(10)
                    .HasColumnName("document_serial")
                    .HasComment("Серия документа");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .HasComment("Имя");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.PollIasMkgu)
                    .HasColumnName("poll_ias_mkgu")
                    .HasComment("Согласие на участие ИАС МКГУ (0 - отказ, 1 - СМС, 2 - Через теминал)");

                entity.Property(e => e.PollRegionSms)
                    .HasColumnName("poll_region_sms")
                    .HasComment("Согласие на участие в региональном опросе");

                entity.Property(e => e.SAlertCustomerId)
                    .HasColumnName("s_alert_customer_id")
                    .HasComment("Способ оповещения, связь со справочником оповещений");

                entity.Property(e => e.SDocumentsIdentityId)
                    .HasColumnName("s_documents_identity_id")
                    .HasComment("Связь со справочником документов, удостоверяющих личность заявителя");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник, добавивший заявителя");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность сотрудника добавившего заявителя");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал сотрудника, добавившего заявителя");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(255)
                    .HasColumnName("second_name")
                    .HasComment("Отчество");

                entity.Property(e => e.NumberProcuration)
                    .HasMaxLength(30)
                    .HasColumnName("number_procuration")
                    .HasComment("Номер доверенности");

                entity.Property(e => e.NameProcuration)
                   .HasMaxLength(100)
                   .HasColumnName("name_procuration")
                   .HasComment("Наименование доверенности");

                entity.Property(e => e.IssueBodyProcuration)
                   .HasMaxLength(255)
                   .HasColumnName("issue_body_procuration")
                   .HasComment("Кто выдал доверенность");

                entity.Property(e => e.IssueDateProcuration)
                   .HasColumnName("issue_date_procuration")
                   .HasComment("Дата выдачи доверенности");

                entity.Property(e => e.PeriodProcuration)
                   .HasMaxLength(30)
                   .HasColumnName("period_procuration")
                   .HasComment("Срок действия доверености");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesCustomers)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_customers_d_cases_id_fkey");

                entity.HasOne(d => d.SAlertCustomer)
                    .WithMany(p => p.DServicesCustomers)
                    .HasForeignKey(d => d.SAlertCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_s_alert_id_fkey");

                entity.HasOne(d => d.SDocumentsIdentity)
                    .WithMany(p => p.DServicesCustomers)
                    .HasForeignKey(d => d.SDocumentsIdentityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_s_documents_identity_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesCustomers)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesCustomers)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesCustomers)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_s_offices_id_fkey");
            });

            modelBuilder.Entity<DCustomer>(entity =>
            {
                entity.ToTable("d_customers", "core");

                entity.HasComment("Список заявителей(физ лиц) по услуге");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(500)
                    .HasColumnName("customer_address")
                    .HasComment("Адрес регистрации");

                entity.Property(e => e.CustomerAddressDetail)
                    .HasColumnType("jsonb")
                    .HasColumnName("customer_address_detail")
                    .HasComment("Адрес регистрации детальный");

                entity.Property(e => e.CustomerAddressResidence)
                    .HasMaxLength(255)
                    .HasColumnName("customer_address_residence")
                    .HasComment("Адрес проживания");

                entity.Property(e => e.CustomerAddressTemp)
                    .HasMaxLength(500)
                    .HasColumnName("customer_address_temp")
                    .HasComment("Адрес регистрации временный");

                entity.Property(e => e.CustomerCodeRegion)
                    .HasMaxLength(3)
                    .HasColumnName("customer_code_region")
                    .HasComment("КОД региона");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(70)
                    .HasColumnName("customer_email")
                    .HasComment("Электронная почта заявителя");

                entity.Property(e => e.CustomerGender)
                    .HasColumnName("customer_gender")
                    .HasComment("Пол заявителя (1 - мужской, 2 - женский)");

                entity.Property(e => e.CustomerInn)
                    .HasMaxLength(30)
                    .HasColumnName("customer_inn")
                    .HasComment("ИНН");

                entity.Property(e => e.CustomerOkato)
                    .HasMaxLength(30)
                    .HasColumnName("customer_okato")
                    .HasComment("ОКАТО");

                entity.Property(e => e.CustomerOktmo)
                    .HasMaxLength(30)
                    .HasColumnName("customer_oktmo")
                    .HasComment("ОКТМО");

                entity.Property(e => e.CustomerPhone1)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_1")
                    .HasComment("Номер телефона 1");

                entity.Property(e => e.CustomerPhone2)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_2")
                    .HasComment("Номер телефона 2");

                entity.Property(e => e.CustomerSnils)
                    .HasMaxLength(20)
                    .HasColumnName("customer_snils")
                    .HasComment("СНИЛС Заявителя");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateTempRegistration)
                    .HasColumnName("date_temp_registration")
                    .HasComment("Дата временной регистрации");

                entity.Property(e => e.DocumentBirthDate)
                    .HasColumnName("document_birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.DocumentBirthPlace)
                    .HasMaxLength(255)
                    .HasColumnName("document_birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(30)
                    .HasColumnName("document_code")
                    .HasComment("Код документа");

                entity.Property(e => e.DocumentIssueBody)
                    .HasMaxLength(255)
                    .HasColumnName("document_issue_body")
                    .HasComment("Наименование отделения, выдавшего паспорт");

                entity.Property(e => e.DocumentIssueDate)
                    .HasColumnName("document_issue_date")
                    .HasComment("Дата выдачи паспорта");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .HasColumnName("document_number")
                    .HasComment("Номер документа");

                entity.Property(e => e.DocumentSerial)
                    .HasMaxLength(10)
                    .HasColumnName("document_serial")
                    .HasComment("Серия документа");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .HasComment("Имя");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.SDocumentsIdentityId)
                    .HasColumnName("s_documents_identity_id")
                    .HasComment("Связь со справочником документов, удостоверяющих личность заявителя");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(255)
                    .HasColumnName("second_name")
                    .HasComment("Отчество");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.HasOne(d => d.SDocumentsIdentity)
                    .WithMany(p => p.DCustomers)
                    .HasForeignKey(d => d.SDocumentsIdentityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_s_documents_identity_id_fkey");
            });

            modelBuilder.Entity<DCustomerHistory>(entity =>
            {
                entity.ToTable("d_customers_history", "core");

                entity.HasComment("История обращений с предыдущей системы");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCustomersId)
                    .HasColumnName("d_customers_id")
                    .HasComment("Заявитель");

                entity.Property(e => e.OfficeName)
                    .HasColumnName("office_name")
                    .HasComment("Место приема");

                entity.Property(e => e.EmployeeName)
                   .HasColumnName("employee_name")
                   .HasComment("Кто принял");

                entity.Property(e => e.DateReception)
                   .HasColumnName("date_reception")
                   .HasComment("Дата приема");

                entity.Property(e => e.ServiceName)
                 .HasColumnName("service_name")
                 .HasComment("Услуга");

                entity.Property(e => e.CaseNumber)
                 .HasColumnName("case_number")
                 .HasComment("Номер обращения");

                entity.Property(e => e.ProviderName)
                 .HasColumnName("provider_name")
                 .HasComment("Поставщик");

                entity.Property(e => e.DepartmentName)
                 .HasColumnName("department_name")
                 .HasComment("Отдел");

                entity.Property(e => e.StatusName)
                 .HasColumnName("status_name")
                 .HasComment("Статус");

                entity.Property(e => e.StageName)
                .HasColumnName("stage_name")
                .HasComment("Этап");

                entity.Property(e => e.DateClose)
               .HasColumnName("date_close")
               .HasComment("Дата завершения");

                //entity.HasOne(d => d.DCustomers)
                //    .WithMany(p => p.DCustomerHistorys)
                //    .HasForeignKey(d => d.DCustomersId)
                //    .HasConstraintName("d_services_customers_s_documents_identity_id_fkey");
            });


            modelBuilder.Entity<DServicesCustomersCall>(entity =>
            {
                entity.ToTable("d_services_customers_call", "core");

                entity.HasComment("Звонки заявителям");

                entity.HasIndex(e => e.DCasesId, "d_services_customer_call_d_cases_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "d_services_customer_call_s_employees_id_idx");

                entity.HasIndex(e => e.SFtpId, "d_services_customer_call_s_ftp_id_idx");

                entity.HasIndex(e => e.SOfficesId, "d_services_customer_call_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AudioFormat)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("audio_format")
                    .HasComment("Формат звонка");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customer_name")
                    .HasComment("Заявитель");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone")
                    .HasComment("Номер телефона");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DateCall)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_call")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время звонка");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника");

                entity.Property(e => e.SFtpId)
                    .HasColumnName("s_ftp_id")
                    .HasComment("Cвязь с FTP сервером");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.Property(e => e.SaveFtp)
                    .HasColumnName("save_ftp")
                    .HasComment("признак сохранения на FTP");

                entity.Property(e => e.TimeTalk)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("time_talk")
                    .HasDefaultValueSql("'00:00:00'::character varying")
                    .HasComment("Время разговора");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesCustomersCalls)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_customer_call_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesCustomerCalls)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customer_call_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesCustomerCalls)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customer_call_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SFtp)
                    .WithMany(p => p.DServicesCustomerCalls)
                    .HasForeignKey(d => d.SFtpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customer_call_s_ftp_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesCustomerCalls)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customer_call_s_offices_id_fkey");
            });

            modelBuilder.Entity<DServicesCustomersMessage>(entity =>
            {
                entity.ToTable("d_services_customers_message", "core");

                entity.HasComment("Сообщения заявителям");

                entity.HasIndex(e => e.DCasesId, "d_services_customer_message_d_cases_id_idx");

                entity.HasIndex(e => e.Id, "d_services_customer_message_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customer_name")
                    .HasComment("Заявитель");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone")
                    .HasComment("номер телефона");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Cвязь сномером дела");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время сообщения");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом сотрудника");

                entity.Property(e => e.SmsId)
                    .HasColumnName("sms_id")
                    .HasComment("Идентефикатор СМС соответствующий идентефкатору из базы СМС сервиса");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("Статус СМС так же из базы СМС сервиса");

                entity.Property(e => e.TextMessage)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("text_message")
                    .HasComment("Текст сообщения");

                entity.Property(e => e.EnqueueDate)
                   .HasColumnType("timestamp(6) without time zone")
                   .HasColumnName("enqueue_date")
                   .HasComment("Дата и время помещения в очередь для отправки");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesCustomersMessages)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_customer_message_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesCustomerMessages)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customer_message_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesCustomerMessages)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customer_message_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesCustomerMessages)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customer_message_s_offices_id_fkey");
            });

            modelBuilder.Entity<DServicesCustomersGisgmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("d_services_customers_gisgmp", "core");

                entity.HasComment("Информация по задолженности с сервиса ГИС ГМП ");

                entity.HasIndex(e => e.Id, "d_customers_gisgmp_id_idx");

                entity.Property(e => e.DServicesCustomersId)
                    .HasColumnName("d_services_customers_id")
                    .HasComment("Связь с заявителем");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.GisgmpDebt)
                    .HasPrecision(15, 2)
                    .HasColumnName("gisgmp_debt")
                    .HasComment("задолженность с сервиса ГИС ГМП");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником добавившим запись");

                entity.HasOne(d => d.DServicesCustomers)
                    .WithMany()
                    .HasForeignKey(d => d.DServicesCustomersId)
                    .HasConstraintName("d_services_customers_gisgmp_d_services_customers_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany()
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_gisgmp_s_employees_id_fkey");
            });

            modelBuilder.Entity<DServicesCustomersLegal>(entity =>
            {
                entity.ToTable("d_services_customers_legal", "core");

                entity.HasComment("Перечень юридических лиц к услуге");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("customer_address")
                    .HasComment("Адрес");

                entity.Property(e => e.CustomerAddressDetail)
                    .HasColumnType("jsonb")
                    .HasColumnName("customer_address_detail")
                    .HasComment("Адрес детальный");

                entity.Property(e => e.CustomerCodeRegion)
                    .HasMaxLength(3)
                    .HasColumnName("customer_code_region")
                    .HasComment("КОД региона");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(70)
                    .HasColumnName("customer_email")
                    .HasComment("Электронная почта заявителя");

                entity.Property(e => e.CustomerInn)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("customer_inn")
                    .HasComment("инн организации");

                entity.Property(e => e.CustomerKpp)
                    .HasMaxLength(20)
                    .HasColumnName("customer_kpp")
                    .HasComment("КПП юридического лица");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("customer_name")
                    .HasComment("Наименование");

                entity.Property(e => e.CustomerOgrn)
                    .HasMaxLength(20)
                    .HasColumnName("customer_ogrn")
                    .HasComment("ОГРН юридического лица");

                entity.Property(e => e.CustomerOkato)
                    .HasMaxLength(30)
                    .HasColumnName("customer_okato")
                    .HasComment("ОКАТО");

                entity.Property(e => e.CustomerOktmo)
                    .HasMaxLength(30)
                    .HasColumnName("customer_oktmo")
                    .HasComment("ОКТМО");

                entity.Property(e => e.CustomerPhone1)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_1")
                    .HasComment("Номер телефона 1");

                entity.Property(e => e.CustomerPhone2)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone_2")
                    .HasComment("Номер телефона 2");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер дела");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.HeadFirstName)
                    .HasMaxLength(70)
                    .HasColumnName("head_first_name")
                    .HasComment("Имя");

                entity.Property(e => e.HeadLastName)
                    .HasMaxLength(70)
                    .HasColumnName("head_last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.HeadPosition)
                    .HasMaxLength(255)
                    .HasColumnName("head_position")
                    .HasComment("Должность руководителя");

                entity.Property(e => e.HeadSecondName)
                    .HasMaxLength(70)
                    .HasColumnName("head_second_name")
                    .HasComment("Отчество");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником добавившим запись");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника, добавившего запись");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.Property(e => e.SServicesCustomerTypeId)
                    .HasColumnName("s_services_customer_type_id")
                    .HasComment("Связь с типами юридических лиц");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesCustomersLegals)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_customers_legal_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesCustomersLegals)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_legal_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesCustomersLegals)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_legal_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesCustomersLegals)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_legal_s_offices_id_fkey");

                entity.HasOne(d => d.SServicesCustomerType)
                    .WithMany(p => p.DServicesCustomersLegals)
                    .HasForeignKey(d => d.SServicesCustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_legal_s_services_sub_customer_type_id_fke");
            });

            modelBuilder.Entity<DServicesCustomersLegalGisgmp>(entity =>
            {
                entity.ToTable("d_services_customers_legal_gisgmp", "core");

                entity.HasComment("Информация по задолженности с сервиса ГИС ГМП ");

                entity.HasIndex(e => e.Id, "d_services_customers_legal_gisgmp_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DServicesCustomersLegalId)
                    .HasColumnName("d_services_customers_legal_id")
                    .HasComment("Связь с заявителем юр лицо");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.GisgmpDebt)
                    .HasPrecision(15, 2)
                    .HasColumnName("gisgmp_debt")
                    .HasComment("Задолженность с сервиса ГИС ГМП");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником добавившим запись");

                entity.HasOne(d => d.DServicesCustomersLegal)
                    .WithMany(p => p.DServicesCustomersLegalGisgmps)
                    .HasForeignKey(d => d.DServicesCustomersLegalId)
                    .HasConstraintName("d_services_customers_legal_gi_d_services_customers_legal_i_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesCustomersLegalGisgmps)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_customers_legal_gisgmp_s_employees_id_fkey");
            });

            modelBuilder.Entity<DServicesDocument>(entity =>
            {
                entity.ToTable("d_services_documents", "core");

                entity.HasComment("Список документов к услуге");

                entity.HasIndex(e => e.Id, "d_services_documents_pkey").IsUnique();
                entity.HasIndex(e => e.Id, "d_services_documents_idx1").IsUnique();
                entity.HasIndex(e => e.DCasesId, "d_services_documents_idx2");
                entity.HasIndex(e => e.DServicesId, "d_services_documents_idx3");
                entity.HasIndex(e => e.SDocumentsId, "d_services_documents_idx4");

                entity.HasIndex(e => e.Id, "d_services_documents_pkey");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.DocumentCount)
                    .HasColumnName("document_count")
                    .HasComment("Количество копий");
                
                entity.Property(e => e.CountCopy)
                    .HasColumnName("count_copy")
                    .HasComment("Кол-во копий");
                
                entity.Property(e => e.CountOriginal)
                    .HasColumnName("count_original")
                    .HasComment("Кол-во оригиналов");

                entity.Property(e => e.DocumentNeeds)
                    .HasColumnName("document_needs")
                    .HasComment("Обязательный - 0, Не обязательный документ - 1,  При наличии - 2");

                entity.Property(e => e.DocumentType)
                    .HasColumnName("document_type")
                    .HasComment("Тип документа (0 - оригинал, 1 - копия)");

                entity.Property(e => e.IsCheck)
                    .HasColumnName("is_check")
                    .HasComment("Отметка о предоставлении документа заявителем");

                entity.Property(e => e.IsIssued)
                   .HasColumnName("is_issued")
                   .HasComment("Отметка о выдаче документа");

                entity.Property(e => e.SDocumentsId)
                    .HasColumnName("s_documents_id")
                    .HasComment("Связь с документом");

                entity.Property(e => e.Commentt)
                    .HasColumnName("commentt")
                    .HasComment("Описание");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Кто добавил");

                entity.Property(e => e.DateAdd)
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления");

                entity.Property(e => e.SEmployeesId)
                   .HasColumnName("s_employees_id")
                   .HasComment("Cвязь с сотрудником добавившим файл");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesDocuments)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_documents_d_cases_id_fkey");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DServicesDocuments)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_services_documents_d_services_id_fkey");

                entity.HasOne(d => d.SDocuments)
                    .WithMany(p => p.DServicesDocuments)
                    .HasForeignKey(d => d.SDocumentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_documents_s_documents_id_fkey");

                entity.HasOne(d => d.SEmployees)
                   .WithMany(p => p.DServicesDocuments)
                   .HasForeignKey(d => d.SEmployeesId)
                   .HasConstraintName("a_services_documents_s_employees_fk");

            });

            modelBuilder.Entity<DServicesDocumentsResult>(entity =>
            {
                entity.ToTable("d_services_documents_result", "core");

                entity.HasComment("Список документов результатов к услуге");

                entity.HasIndex(e => e.Id, "d_services_documents_result_pkey").IsUnique();
                entity.HasIndex(e => e.Id, "d_services_documents_result_idx1");
                entity.HasIndex(e => e.DServicesId, "d_services_documents_result_idx2");
                entity.HasIndex(e => e.DCasesId, "d_services_documents_result_idx3");
                entity.HasIndex(e => e.SDocumentsId, "d_services_documents_result_idx4");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.DocumentMethod)
                    .HasColumnName("document_method")
                    .HasComment("Способы получения документа");

                entity.Property(e => e.DocumentPeriodMfc)
                    .HasMaxLength(30)
                    .HasColumnName("document_period_mfc")
                    .HasComment("Срок хранения в МФЦ");

                entity.Property(e => e.DocumentPeriodProvider)
                    .HasMaxLength(30)
                    .HasColumnName("document_period_provider")
                    .HasComment("Срок хранения в органе власти");

                entity.Property(e => e.DocumentResult)
                    .HasColumnName("document_result")
                    .HasComment("Результат положительный или отрицательный");

                entity.Property(e => e.SDocumentsId)
                    .HasColumnName("s_documents_id")
                    .HasComment("Связь со справочником документов");

                entity.Property(e => e.IsIssued)
                   .HasColumnName("is_issued")
                   .HasComment("Отметка о выдаче документа");

                entity.Property(e => e.CountCopy)
                    .HasColumnName("count_copy")
                    .HasComment("Кол-во копий");

                entity.Property(e => e.CountOriginal)
                    .HasColumnName("count_original")
                    .HasComment("Кол-во оригиналов");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesDocumentsResults)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_documents_result_d_cases_id_fkey");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DServicesDocumentsResults)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_services_documents_result_d_services_id_fkey");

                entity.HasOne(d => d.SDocuments)
                    .WithMany(p => p.DServicesDocumentsResults)
                    .HasForeignKey(d => d.SDocumentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_documents_result_s_services_sub_result_document_fkey");
            });

            modelBuilder.Entity<DServicesFile>(entity =>
            {
                entity.ToTable("d_services_file", "core");

                entity.HasComment("Ссылки на электронные образы документов к услугам");

                entity.HasIndex(e => e.DCasesId, "d_services_file_d_cases_id_idx");

                entity.HasIndex(e => e.DServicesDocumentsId, "d_services_file_d_services_documents_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "d_services_file_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "d_services_file_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SFtpId, "d_services_file_s_ftp_id_idx");

                entity.HasIndex(e => e.SOfficesId, "d_services_file_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DServicesDocumentsId)
                    .HasColumnName("d_services_documents_id")
                    .HasComment("Cвязь документом");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудник добавившего запись");

                entity.Property(e => e.FileExtention)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("file_extention")
                    .HasComment("Расширение файла");

                entity.Property(e => e.FileFlag)
                    .HasColumnName("file_flag")
                    .HasDefaultValueSql("1")
                    .HasComment("0 - Файл присутствует на FTP, 1 - Файл отсутствует на FTP");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("file_name")
                    .HasComment("Имя файла");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер файла");

                entity.Property(e => e.IsPaid)
                    .IsRequired()
                    .HasColumnName("is_paid")
                    .HasDefaultValueSql("true")
                    .HasComment("Признак оплачиваемости файла");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Cвязь с сотрудником добавившим файл");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника добавившего файл");

                entity.Property(e => e.SFtpId)
                    .HasColumnName("s_ftp_id")
                    .HasComment("Cвязь с FTP сервером где храняться файлы");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалов в котором добавлен файл");

                entity.Property(e => e.TypeAddFile)
                    .HasColumnName("type_add_file")
                    .HasComment("Тип получения файла. 1 - Сканирование, 2 - С рабочего стола, 3 - С архива");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesFiles)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_file_d_cases_id_fkey");

                entity.HasOne(d => d.DServicesDocuments)
                    .WithMany(p => p.DServicesFiles)
                    .HasForeignKey(d => d.DServicesDocumentsId)
                    .HasConstraintName("d_services_file_d_services_documents_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesFiles)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_file_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesFiles)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_file_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SFtp)
                    .WithMany(p => p.DServicesFiles)
                    .HasForeignKey(d => d.SFtpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_file_s_ftp_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesFiles)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_file_s_offices_id_fkey");
            });

            modelBuilder.Entity<DServicesFileResult>(entity =>
            {
                entity.ToTable("d_services_file_result", "core");

                entity.HasComment("Список файлов с результатами услуги");

                entity.HasIndex(e => e.DCasesId, "d_services_file_result_d_cases_id_idx");

                entity.HasIndex(e => e.DServicesDocumentResultId, "d_services_file_result_d_services_document_result_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "d_services_file_result_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "d_services_file_result_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SFtpId, "d_services_file_result_s_ftp_id_idx");

                entity.HasIndex(e => e.SOfficesId, "d_services_file_result_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DServicesDocumentResultId)
                    .HasColumnName("d_services_document_result_id")
                    .HasComment("Документ результата к услуге");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Дата внесения услуги");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудник добавившего запись");

                entity.Property(e => e.FileExtention)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("file_extention")
                    .HasComment("Расширение файла");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("file_name")
                    .HasComment("Имя файла");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер файла");

                entity.Property(e => e.IsPaid)
                    .IsRequired()
                    .HasColumnName("is_paid")
                    .HasDefaultValueSql("true")
                    .HasComment("Признак оплачиваемости файла");

                entity.Property(e => e.IsSavedFtp)
                    .HasColumnName("is_saved_ftp")
                    .HasComment("Сохранность на FTP");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником добавившим запись");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника, добавившего запись");

                entity.Property(e => e.SFtpId)
                    .HasColumnName("s_ftp_id")
                    .HasComment("Cвязь с FTP сервером где храняться файлы");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом сотрудника, добавившего запись");

                entity.Property(e => e.TypeAddFile)
                    .HasColumnName("type_add_file")
                    .HasComment("Тип добавления файла (1 - Сканирование, 2 - C рабочего стола, 3 - с архива)");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesFileResults)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_file_result_d_cases_id_fkey");

                entity.HasOne(d => d.DServicesDocumentResult)
                    .WithMany(p => p.DServicesFileResults)
                    .HasForeignKey(d => d.DServicesDocumentResultId)
                    .HasConstraintName("d_services_file_result_d_services_document_result_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesFileResults)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_file_result_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesFileResults)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_file_result_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SFtp)
                    .WithMany(p => p.DServicesFileResults)
                    .HasForeignKey(d => d.SFtpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_file_result_s_ftp_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesFileResults)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_file_result_s_offices_id_fkey");
            });

            modelBuilder.Entity<DServicesPayment>(entity =>
            {
                entity.ToTable("d_services_payment", "core");

                entity.HasComment("Оплата по услугам");

                entity.HasIndex(e => e.Id, "d_services_payment_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.DServicesId, "d_services_payment_idx2");

                entity.HasIndex(e => e.SOfficesId, "d_services_payment_idx3");

                entity.HasIndex(e => e.SEmployeesId, "d_services_payment_idx4");

                entity.HasIndex(e => e.DCasesId, "d_services_payment_idx5");

                entity.HasIndex(e => e.DServicesCustomerId, "d_services_payment_idx6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CustomerFirstName)
                    .HasMaxLength(70)
                    .HasColumnName("customer_first_name")
                    .HasComment("Имя плательщика");

                entity.Property(e => e.CustomerInn)
                    .HasMaxLength(30)
                    .HasColumnName("customer_inn")
                    .HasComment("ИНН плательщика");

                entity.Property(e => e.CustomerLastName)
                    .HasMaxLength(70)
                    .HasColumnName("customer_last_name")
                    .HasComment("Фамилия плательщика");

                entity.Property(e => e.CustomerMiddleName)
                    .HasMaxLength(70)
                    .HasColumnName("customer_middle_name")
                    .HasComment("Отчество плательщика");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name")
                    .HasComment("Наименование заявителя");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(20)
                    .HasColumnName("customer_phone")
                    .HasComment("Телефон в плательщика");

                entity.Property(e => e.CustomerSnils)
                    .HasMaxLength(30)
                    .HasColumnName("customer_snils")
                    .HasComment("СНИЛС плательщика");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с обращением");

                entity.Property(e => e.DServicesCustomerId)
                    .HasColumnName("d_services_customer_id")
                    .HasComment("Связь с заявителем");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Cвязь с услугой");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(10)
                    .HasColumnName("document_code")
                    .HasComment("код документа плательщика,\r\r\n«01» – паспорт гражданина РФ;\r\r\n«02» – свидетельство органов ЗАГС о рождении гражданина;\r\r\n«03» – паспорт моряка;\r\r\n«04» – удостоверение личности военнослужащего;\r\r\n«05» – военный билет военнослужащего;\r\r\n«06» – временное удостоверение личности гражданина РФ;\r\r\n«07» – справка об освобождении из мест лишения свободы;\r\r\n«08» – паспорт иностранного гражданина;\r\r\n«09» – вид на жительство;\r\r\n«10» – разрешение на временное проживание;\r\r\n«11» – удостоверение беженца;\r\r\n«12» – миграционная карта;");

                entity.Property(e => e.DocumentInfo)
                    .HasMaxLength(255)
                    .HasColumnName("document_info")
                    .HasComment("Код документа серия и номер???(Серия и номер паспорта есть выше)");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .HasColumnName("document_number")
                    .HasComment("Номер паспорта плательщика");

                entity.Property(e => e.DocumentSerial)
                    .HasMaxLength(10)
                    .HasColumnName("document_serial")
                    .HasComment("Cерия паспорта плательщика");

                entity.Property(e => e.PaymentAddress)
                    .HasMaxLength(255)
                    .HasColumnName("payment_address")
                    .HasComment("Адрес плательщика");

                entity.Property(e => e.PaymentAgent)
                    .HasColumnName("payment_agent")
                    .HasDefaultValueSql("1")
                    .HasComment("Платежный агент (1 - Чекастер, 2 -  Сотас)");

                entity.Property(e => e.PaymentBankName)
                    .HasMaxLength(100)
                    .HasColumnName("payment_bank_name")
                    .HasComment("Наименование банка");

                entity.Property(e => e.PaymentBik)
                    .HasMaxLength(20)
                    .HasColumnName("payment_bik")
                    .HasComment("БИК");

                entity.Property(e => e.PaymentCustomer)
                    .HasMaxLength(350)
                    .HasColumnName("payment_customer")
                    .HasComment("Получатель платежа (Название органа исполнительной власти)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("payment_date")
                    .HasComment("Дата оплаты по платежу");

                entity.Property(e => e.PaymentDateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("payment_date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.PaymentInn)
                    .HasMaxLength(30)
                    .HasColumnName("payment_inn")
                    .HasComment("ИНН");

                entity.Property(e => e.PaymentKbk)
                    .HasMaxLength(30)
                    .HasColumnName("payment_kbk")
                    .HasComment("КБК");

                entity.Property(e => e.PaymentKpp)
                    .HasMaxLength(30)
                    .HasColumnName("payment_kpp")
                    .HasComment("КПП");

                entity.Property(e => e.PaymentKs)
                    .HasMaxLength(30)
                    .HasColumnName("payment_ks")
                    .HasComment("Кореспондентский счет");

                entity.Property(e => e.PaymentNumber)
                    .HasColumnName("payment_number")
                    .HasComment("Номер платежа");

                entity.Property(e => e.PaymentOktmo)
                    .HasMaxLength(30)
                    .HasColumnName("payment_oktmo")
                    .HasComment("ОКТМО");

                entity.Property(e => e.PaymentOsmpId)
                    .HasMaxLength(20)
                    .HasColumnName("payment_osmp_id")
                    .HasComment("Идентификатор платежа");

                entity.Property(e => e.PaymentPrvTxn)
                    .HasColumnName("payment_prv_txn")
                    .HasDefaultValueSql("0")
                    .HasComment("Идентификатор платежа");

                entity.Property(e => e.PaymentPurpose)
                    .HasMaxLength(1500)
                    .HasColumnName("payment_purpose")
                    .HasComment("Назначение платежа (Название услуги)");

                entity.Property(e => e.PaymentRs)
                    .HasMaxLength(30)
                    .HasColumnName("payment_rs")
                    .HasComment("Расчетный счет");

                entity.Property(e => e.PaymentSign)
                    .HasColumnName("payment_sign")
                    .HasDefaultValueSql("false")
                    .HasComment("Признак оплаты");

                entity.Property(e => e.PaymentValue)
                    .HasPrecision(15, 2)
                    .HasColumnName("payment_value")
                    .HasComment("Сумма платежа");

                entity.Property(e => e.PersonalAccount)
                    .HasMaxLength(20)
                    .HasColumnName("personal_account")
                    .HasComment("Лицевой счет");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с офисом");

                entity.Property(e => e.TerminalId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("terminal_id")
                    .HasComment("id услуги в  териминале");

                entity.Property(e => e.Uin)
                    .HasMaxLength(40)
                    .HasColumnName("uin")
                    .HasComment("УИН");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesPayments)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_payment_d_cases_id_fkey");

                entity.HasOne(d => d.DServicesCustomer)
                    .WithMany(p => p.DServicesPayments)
                    .HasForeignKey(d => d.DServicesCustomerId)
                    .HasConstraintName("d_services_payment_d_services_customer_id_fkey");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DServicesPayments)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_services_payment_d_services_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesPayments)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_payment_s_employees_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesPayments)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_payment_s_offices_id_fkey");
            });

            modelBuilder.Entity<DServicesRoutesStage>(entity =>
            {
                entity.ToTable("d_services_routes_stage", "core");

                entity.HasComment("Этапы по услугам");

                entity.HasIndex(e => e.DCasesId, "d_services_routes_stage_d_cases_id_idx");

                entity.HasIndex(e => e.DServicesId, "d_services_routes_stage_d_services_id_idx");

                entity.HasIndex(e => e.Id, "d_services_routes_stage_id_idx")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesId, "d_services_routes_stage_idx1");

                entity.HasIndex(e => e.SOfficesId, "d_services_routes_stage_idx2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CountDayExecution)
                    .HasColumnName("count_day_execution")
                    .HasComment("Количество дней на исполнение этапа");

                entity.Property(e => e.CountDayFact)
                    .HasColumnName("count_day_fact")
                    .HasComment("Фактическое затраченное время на исполнение этапа");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер дела");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.DServicesIdParent)
                    .HasColumnName("d_services_id_parent")
                    .HasComment("Связь с головной услугой");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Дата начала этапа");

                entity.Property(e => e.DateFact)
                    .HasColumnName("date_fact")
                    .HasComment("Фактическая дата окончания этапа");

                entity.Property(e => e.DateReg)
                    .HasColumnName("date_reg")
                    .HasComment("Регламентная дата окончания этапа");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник который перевел этап");

                entity.Property(e => e.PassAutomatically)
                    .HasColumnName("pass_automatically")
                    .HasComment("Передача сотруднику была автоматически или в ручную");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник на которого перевели этап");

                entity.Property(e => e.SEmployeesIdAdd)
                    .HasColumnName("s_employees_id_add")
                    .HasComment("Связь с сотрудником передавшим этап");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника получившего этап");

                entity.Property(e => e.SEmployeesJobPositionIdAdd)
                    .HasColumnName("s_employees_job_position_id_add")
                    .HasComment("Связь с должностью сотрудника добавившего этап");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом сотрудника добавившего этап");

                entity.Property(e => e.SRoutesStageId)
                    .HasColumnName("s_routes_stage_id")
                    .HasComment("Этап");

                entity.Property(e => e.TimeFact)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_fact")
                    .HasComment("Фактическое время окончания этапа");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesRoutesStages)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_routes_stage_d_cases_id_fkey");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DServicesRoutesStages)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_services_routes_stage_d_services_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesRoutesStageSEmployees)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_routes_stage_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesIdAddNavigation)
                    .WithMany(p => p.DServicesRoutesStageSEmployeesIdAddNavigations)
                    .HasForeignKey(d => d.SEmployeesIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_routes_stage_s_employees_id_add_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesRoutesStageSEmployeesJobPositions)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_routes_stage_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPositionIdAddNavigation)
                    .WithMany(p => p.DServicesRoutesStageSEmployeesJobPositionIdAddNavigations)
                    .HasForeignKey(d => d.SEmployeesJobPositionIdAdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_routes_stage_s_employees_job_position_id_add_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesRoutesStages)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_routes_stage_s_offices_id_fkey");

                entity.HasOne(d => d.SRoutesStage)
                    .WithMany(p => p.DServicesRoutesStages)
                    .HasForeignKey(d => d.SRoutesStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_routes_stage_s_routes_stage_id_fkey");
            });

            modelBuilder.Entity<DServicesSmevLog>(entity =>
            {
                entity.ToTable("d_services_smev_log", "core");

                entity.HasComment("Лог сервиса СМЭВ");

                entity.HasIndex(e => e.DServicesSmevRequestId, "d_services_smev_log_d_smev_services_request_id_idx");

                entity.HasIndex(e => e.Id, "d_services_smev_log_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DServicesSmevRequestId)
                    .HasColumnName("d_services_smev_request_id")
                    .HasComment("Связь с запросом");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время лога");

                entity.Property(e => e.LogText)
                    .HasColumnName("log_text")
                    .HasComment("текст лога");

                entity.Property(e => e.LogType)
                    .HasColumnName("log_type")
                    .HasComment("тип лога");

                entity.Property(e => e.SprSmevRequestId).HasColumnName("spr_smev_request_id");
            });

            modelBuilder.Entity<DServicesSmevRequest>(entity =>
            {
                entity.ToTable("d_services_smev_request", "core");

                entity.HasComment("Таблица запросов  СМЭВ");

                entity.HasIndex(e => e.Id, "d_services_smev_request_pkey").IsUnique();
                entity.HasIndex(e => e.Id, "d_services_smev_request_idx1");
                entity.HasIndex(e => e.DServicesId, "d_services_smev_request_idx2");
                entity.HasIndex(e => e.DCasesId, "d_services_smev_request_idx3");
                entity.HasIndex(e => e.SSmevRequestId, "d_services_smev_request_idx4");
                entity.HasIndex(e => e.SEmployeesId, "d_services_smev_request_idx5");
                entity.HasIndex(e => e.SOfficesId, "d_services_smev_request_idx6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(500)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.CountDayExecution)
                    .HasColumnName("count_day_execution")
                    .HasComment("Кол-во дней на исполнение запроса");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DServicesId)
                    .HasColumnName("d_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateFact)
                    .HasColumnName("date_fact")
                    .HasComment("Дата ответа - фактическая");

                entity.Property(e => e.DateReg)
                    .HasColumnName("date_reg")
                    .HasComment("Дата ответа - регламентная");

                entity.Property(e => e.DateRequest)
                    .HasColumnName("date_request")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата запроса");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудника добавившего запись");

                entity.Property(e => e.EmployeeFioRead)
                    .HasMaxLength(255)
                    .HasColumnName("employee_fio_read")
                    .HasComment("Сотрудник прочитавший");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(70)
                    .HasColumnName("message_id")
                    .HasComment("ID сообщения");

                entity.Property(e => e.MessageIdProvider)
                    .HasMaxLength(70)
                    .HasColumnName("message_id_provider")
                    .HasComment("ID органа исполнительной власти");

                entity.Property(e => e.Repeat)
                    .HasColumnName("repeat")
                    .HasComment("Является ли запрос повторным?");

                entity.Property(e => e.RequestHtml)
                    .HasColumnName("request_html")
                    .HasComment("Сериализованный XML, описывающий HTML отчет для запроса.");

                entity.Property(e => e.RequestIdRef)
                    .HasMaxLength(70)
                    .HasColumnName("request_id_ref")
                    .HasComment("ID запроса для повторного запроса сведений");

                entity.Property(e => e.ResponseFileName)
                    .HasMaxLength(255)
                    .HasColumnName("response_file_name")
                    .HasComment("Наименование файла хранящего ответ");

                entity.Property(e => e.ResponseHtml)
                    .HasColumnName("response_html")
                    .HasComment("Сериализованный XML, описывающий HTML отчет для окончательного ответа.");

                entity.Property(e => e.ResponseHtmlInt)
                    .HasColumnName("response_html_int")
                    .HasComment("Сериализованный XML, описывающий HTML отчет для промежуточного ответа, полученного после выполнения первой фазы асинхронного запроса.");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником отправившим запрос");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью сотрудника");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом сотрудника");

                entity.Property(e => e.SServicesWeekId)
                    .HasColumnName("s_services_week_id")
                    .HasComment("Тип отсчета дней для запроса");

                entity.Property(e => e.SSmevRequestId)
                    .HasColumnName("s_smev_request_id")
                    .HasComment("Связь с запросом СМЭВ");

                entity.Property(e => e.TimeFact)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_fact")
                    .HasComment("Время ответа - фактическое");

                entity.Property(e => e.TimeRequest)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_request")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время запроса");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DServicesSmevRequests)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_services_smev_request_d_cases_id_fkey");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DServicesSmevRequests)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_services_smev_request_d_services_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DServicesSmevRequests)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_smev_request_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DServicesSmevRequests)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_smev_request_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DServicesSmevRequests)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_smev_request_s_offices_id_fkey");

                entity.HasOne(d => d.SServicesWeek)
                    .WithMany(p => p.DServicesSmevRequests)
                    .HasForeignKey(d => d.SServicesWeekId)
                    .HasConstraintName("d_services_smev_request_s_services_sub_week_id_fkey");

                entity.HasOne(d => d.SSmevRequest)
                    .WithMany(p => p.DServicesSmevRequests)
                    .HasForeignKey(d => d.SSmevRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_services_smev_request_s_smev_request_id_fkey");
            });

            modelBuilder.Entity<DServicesSmevRequestStatus>(entity =>
            {
                entity.ToTable("d_services_smev_request_status", "core");

                entity.HasComment("Таблица запросов результата для асинхронных сервисев ");

                entity.HasIndex(e => e.DServicesSmevRequestId, "d_services_smev_request_status_d_smev_services_request_id_idx");

                entity.HasIndex(e => e.Id, "d_services_smev_request_status_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DServicesSmevRequestId)
                    .HasColumnName("d_services_smev_request_id")
                    .HasComment("Связь с запросом СМЭВ");

                entity.Property(e => e.DateRequest)
                    .HasColumnName("date_request")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата запроса");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(70)
                    .HasColumnName("message_id")
                    .HasComment("ID сообщения");

                entity.Property(e => e.RequestIdRef)
                    .HasMaxLength(70)
                    .HasColumnName("request_id_ref")
                    .HasComment("ID запроса для повторного запроса сведений");

                entity.Property(e => e.TimeRequest)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time_request")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время запроса");

                entity.HasOne(d => d.DServicesSmevRequest)
                    .WithMany(p => p.DServicesSmevRequestStatuses)
                    .HasForeignKey(d => d.DServicesSmevRequestId)
                    .HasConstraintName("d_services_smev_request_status_d_smev_services_request_id_fkey");
            });

            modelBuilder.Entity<DSmsPollRegion>(entity =>
            {
                entity.ToTable("d_sms_poll_region", "services");

                entity.HasComment("Данные СМС опроса МФЦ");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CustomerFirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customer_first_name")
                    .HasComment("Имя заявителя");

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customer_last_name")
                    .HasComment("Фамилия заявителя");

                entity.Property(e => e.CustomerMiddleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customer_middle_name")
                    .HasComment("Отчество заявителя");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(30)
                    .HasColumnName("customer_phone")
                    .HasComment("Номер телефона");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("d_cases_id")
                    .HasComment("Связь с номером дела");

                entity.Property(e => e.DateAddRecord)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add_record")
                    .HasDefaultValueSql("now()")
                    .HasComment("дата и время добавления записи");

                entity.Property(e => e.DateAnswer)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_answer")
                    .HasComment("Дата получения СМС ответа");

                entity.Property(e => e.DateSend)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_send")
                    .HasComment("Дата отправки СМС");

                entity.Property(e => e.EmployeeFio)
                    .HasColumnName("employee_fio")
                    .HasComment("ФИО сотрудника");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.Property(e => e.ServiceSubName)
                    .HasColumnName("service_sub_name")
                    .HasComment("название услуги");

                entity.Property(e => e.SmsRating)
                    .HasColumnName("sms_rating")
                    .HasComment("Оценка из СМС");

                entity.Property(e => e.SmsStatus)
                    .HasColumnName("sms_status")
                    .HasDefaultValueSql("1")
                    .HasComment("Статус отправки СМС\r\r\n1 Ожидание отправки\r\r\n2 Отправленно\r\r\n3 Принят ответ\r\r\n4 Ошибка");

                entity.Property(e => e.SmsTextAnswer)
                    .HasMaxLength(100)
                    .HasColumnName("sms_text_answer")
                    .HasComment("Текст полученного  СМС ответа");

                entity.Property(e => e.SmsTextSend)
                    .HasMaxLength(100)
                    .HasColumnName("sms_text_send")
                    .HasDefaultValueSql("'МФЦ РД. Просим оценить работу оператора от 1 до 5.'::character varying")
                    .HasComment("Текст отправленного СМС");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DSmsPollRegions)
                    .HasForeignKey(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_sms_poll_region_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DSmsPollRegions)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_sms_poll_region_s_employees_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DSmsPollRegions)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_sms_poll_region_s_offices_id_fkey");
            });

            modelBuilder.Entity<DReestr>(entity =>
            {
                entity.ToTable("d_reestr", "core");

                entity.HasComment("Реестр");

                entity.HasIndex(e => e.ReestrNumber, "d_reestr_idx2");

                entity.HasIndex(e => e.SEmployeesId, "d_reestr_idx3");

                entity.HasIndex(e => e.SOfficesId, "d_reestr_idx4");

                entity.HasIndex(e => e.SServicesIdProviderId, "d_reestr_idx5");

                entity.HasIndex(e => e.SServicesId, "d_reestr_idx6");

                entity.HasIndex(e => e.Id, "d_reestr_pkey").IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Ключ");

                entity.Property(e => e.ReestrNumber)
                    .HasColumnName("reestr_number")
                    .HasDefaultValueSql("nextval('core.reestr_number_seq'::regclass)")
                    .HasComment("Номер");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("timestamp")
                    .HasColumnName("date_create")
                    .HasComment("Дата и время формирования");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Организация(МФЦ), кто формировал реестр");

                entity.Property(e => e.SServicesIdProviderId)
                    .HasColumnName("s_services_provider_id")
                    .HasComment("Поставщик услуги");

                entity.Property(e => e.SServicesIdProviderDepartament)
                    .HasColumnName("s_services_provider_id_department")
                    .HasComment("Отдел поставщика");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Услуга");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DReestrs)
                    .HasForeignKey(d => d.SEmployeesId)
                    .HasConstraintName("d_reestr_fk1");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DReestrs)
                    .HasForeignKey(d => d.SOfficesId)
                    .HasConstraintName("d_reestr_fk2");

                entity.HasOne(d => d.SServicesIdProviderNavigation)
                   .WithMany(p => p.DReestrsNavigations)
                   .HasForeignKey(d => d.SServicesIdProviderId)
                   .HasConstraintName("d_reestr_fk3");

                entity.HasOne(d => d.SServices)
                   .WithMany(p => p.DReestrs)
                   .HasForeignKey(d => d.SServicesId)
                   .HasConstraintName("d_reestr_fk4");

                entity.HasOne(d => d.SServicesIdProviderDepartamentNavigation)
                   .WithMany(p => p.DReestrsDepartamentNavigations)
                   .HasForeignKey(d => d.SServicesIdProviderDepartament)
                   .HasConstraintName("d_reestr_fk5");
            });

            modelBuilder.Entity<DReestrService>(entity =>
            {
                entity.ToTable("d_reestr_services", "core");

                entity.HasComment("Услуги к реестру");

                entity.HasIndex(e => e.Id, "d_reestr_services_pkey").IsUnique();

                entity.HasIndex(e => e.DReestrId, "d_reestr_services_idx2"); 

                entity.HasIndex(e => e.DServicesId, "d_reestr_services_idx3");

                entity.HasIndex(e => e.DCasesId, "d_reestr_services_idx4");

                entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("directory.uuid_generate_v4()")
                .HasComment("Ключ");

                entity.Property(e => e.DReestrId)
                .HasColumnName("d_reestr_id")
                .HasComment("Реестр");

                entity.Property(e => e.DServicesId)
                .HasColumnName("d_services_id")
                .HasComment("Услуга");

                entity.Property(e => e.DCasesId)
                   .IsRequired()
                   .HasMaxLength(70)
                   .HasColumnName("d_cases_id")
                   .HasComment("Обращение");

                entity.Property(e => e.CustomerName)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("customer_name")
                   .HasComment("Заявитель");

                entity.Property(e => e.CustomerAddress)
                   .HasMaxLength(500)
                   .HasColumnName("customer_address")
                   .HasComment("Адрес");
                
                entity.Property(e => e.CustomerPhone1)
                   .HasMaxLength(20)
                   .HasColumnName("customer_phone_1")
                   .HasComment("Номер телефона 1");
               
                entity.Property(e => e.CustomerPhone2)
                   .HasMaxLength(20)
                   .HasColumnName("customer_phone_2")
                   .HasComment("Номер телефона 2");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DReestrServices)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_reestr_services_fk");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DReestrServices)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_reestr_services_fk_1");

                entity.HasOne(d => d.DReestr)
                   .WithMany(p => p.DReestrServices)
                   .HasForeignKey(d => d.DReestrId)
                   .HasConstraintName("d_reestr_services_fk_2");
            });

            modelBuilder.Entity<DReestrUnclaimed>(entity =>
            {
                entity.ToTable("d_reestr_unclaimed", "core");

                entity.HasComment("Реестр");

                entity.HasIndex(e => e.ReestrNumber, "d_reestr_unclaimed_idx1");

                entity.HasIndex(e => e.SEmployeesId, "d_reestr_unclaimed_idx2");

                entity.HasIndex(e => e.SOfficesId, "d_reestr_unclaimed_idx3");

                entity.HasIndex(e => e.SServicesIdProviderId, "d_reestr_unclaimed_idx4");

                entity.HasIndex(e => e.SServicesId, "d_reestr_unclaimed_idx5");

                entity.HasIndex(e => e.Id, "d_reestr_unclaimed_pkey").IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Ключ");

                entity.Property(e => e.ReestrNumber)
                    .HasColumnName("reestr_number")
                    .HasDefaultValueSql("nextval('core.reestr_unclaimed_number_seq'::regclass)")
                    .HasComment("Номер");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("timestamp")
                    .HasColumnName("date_create")
                    .HasComment("Дата и время формирования");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Организация(МФЦ), кто формировал реестр");

                entity.Property(e => e.SServicesIdProviderId)
                    .HasColumnName("s_services_provider_id")
                    .HasComment("Поставщик услуги");

                entity.Property(e => e.SServicesIdProviderDepartament)
                    .HasColumnName("s_services_provider_id_department")
                    .HasComment("Отдел поставщика");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Услуга");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DReestrUnclaimeds)
                    .HasForeignKey(d => d.SEmployeesId)
                    .HasConstraintName("d_reestr_unclaimed_s_employees_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DReestrUnclaimeds)
                    .HasForeignKey(d => d.SOfficesId)
                    .HasConstraintName("d_reestr_unclaimed_s_offices_id_fkey");

                entity.HasOne(d => d.SServicesIdProviderNavigation)
                   .WithMany(p => p.DReestrUnclaimedsNavigations)
                   .HasForeignKey(d => d.SServicesIdProviderId)
                   .HasConstraintName("d_reestr_unclaimed_s_services_provider_id_fkey");

                entity.HasOne(d => d.SServices)
                   .WithMany(p => p.DReestrUnclaimeds)
                   .HasForeignKey(d => d.SServicesId)
                   .HasConstraintName("d_reestr_unclaimed_s_services_id_fkey");

                entity.HasOne(d => d.SServicesIdProviderDepartamentNavigation)
                   .WithMany(p => p.DReestrUnclaimedsDepartamentNavigations)
                   .HasForeignKey(d => d.SServicesIdProviderDepartament)
                   .HasConstraintName("d_reestr_unclaimed_s_services_provider_id_department_fkey");
            });

            modelBuilder.Entity<DReestrUnclaimedService>(entity =>
            {
                entity.ToTable("d_reestr_unclaimed_services", "core");

                entity.HasComment("Услуги к реестру невостребованных");

                entity.HasIndex(e => e.Id, "d_reestr_services_unclaimed_pkey").IsUnique();

                entity.HasIndex(e => e.DReestrId, "d_reestr_services_unclaimed_idx1");

                entity.HasIndex(e => e.DServicesId, "d_reestr_services_unclaimed_idx2");

                entity.HasIndex(e => e.DCasesId, "d_reestr_services_unclaimed_idx3");

                entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("directory.uuid_generate_v4()")
                .HasComment("Ключ");

                entity.Property(e => e.DReestrId)
                .HasColumnName("d_reestr_id")
                .HasComment("Реестр");

                entity.Property(e => e.DServicesId)
                .HasColumnName("d_services_id")
                .HasComment("Услуга");

                entity.Property(e => e.DCasesId)
                   .IsRequired()
                   .HasMaxLength(70)
                   .HasColumnName("d_cases_id")
                   .HasComment("Обращение");

                entity.Property(e => e.CustomerName)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("customer_name")
                   .HasComment("Заявитель");

                entity.Property(e => e.CustomerAddress)
                   .HasMaxLength(500)
                   .HasColumnName("customer_address")
                   .HasComment("Адрес");

                entity.Property(e => e.CustomerPhone1)
                   .HasMaxLength(20)
                   .HasColumnName("customer_phone_1")
                   .HasComment("Номер телефона 1");

                entity.Property(e => e.CustomerPhone2)
                   .HasMaxLength(20)
                   .HasColumnName("customer_phone_2")
                   .HasComment("Номер телефона 2");

                entity.HasOne(d => d.DServices)
                    .WithMany(p => p.DReestrUnclaimedServices)
                    .HasForeignKey(d => d.DServicesId)
                    .HasConstraintName("d_reestr_services_fk");

                entity.HasOne(d => d.DCases)
                    .WithMany(p => p.DReestrUnclaimedServices)
                    .HasForeignKey(d => d.DCasesId)
                    .HasConstraintName("d_reestr_services_fk_1");

                entity.HasOne(d => d.DReestrUnclaimed)
                   .WithMany(p => p.DReestrUnclaimedServices)
                   .HasForeignKey(d => d.DReestrId)
                   .HasConstraintName("d_reestr_services_unclaimed_d_reestr_id_fkey");
            });


            modelBuilder.Entity<DStepCancel>(entity =>
            {
                entity.ToTable("d_step_cancel", "core");

                entity.HasComment("Таблица отмененных действий сотрудников\r\r\nИспользуется для перерасчета");

                entity.HasIndex(e => e.DCasesId, "d_step_cancel_d_cases_id_idx")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "d_step_cancel_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "d_step_cancel_id_idx2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CommentCancel)
                    .HasMaxLength(255)
                    .HasColumnName("comment_cancel")
                    .HasComment("Комментарий при отмене");

                entity.Property(e => e.DCasesId)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("d_cases_id")
                    .HasComment("Номер обращения");

                entity.Property(e => e.DateCanсel)
                    .HasColumnName("date_canсel")
                    .HasComment("Дата отмены действия");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником отменившим действие");

                entity.Property(e => e.StepId)
                    .HasColumnName("step_id")
                    .HasComment("ID отмененного действия ");

                entity.Property(e => e.TableType)
                    .HasColumnName("table_type")
                    .HasComment("Тип таблицы, в которой отменено действие");

                entity.HasOne(d => d.DCases)
                    .WithOne(p => p.DStepCancel)
                    .HasForeignKey<DStepCancel>(d => d.DCasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_step_cancel_d_cases_id_fkey");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DStepCancels)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_step_cancel_s_employees_id_fkey");
            });

            modelBuilder.Entity<DStepRecalculationLog>(entity =>
            {
                entity.ToTable("d_step_recalculation_log", "salary");

                entity.HasComment("Таблица хранения времени запуска перерасчета действий\r\r\n");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.DateStart)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_start")
                    .HasComment("Дата начала");

                entity.Property(e => e.DateStop)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с филиалом");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.DStepRecalculationLogs)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_step_recalculation_log_s_employees_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.DStepRecalculationLogs)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("d_step_recalculation_log_s_offices_id_fkey");
            });

            modelBuilder.Entity<DZagsBirth>(entity =>
            {
                entity.ToTable("d_zags_birth", "zags");

                entity.HasComment("Данные пр рождаемости с ЗАГС");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ActCodeUpdate)
                    .HasMaxLength(4)
                    .HasColumnName("act_code_update")
                    .HasComment("Код/Наименование вида записей ");

                entity.Property(e => e.ActDate)
                    .HasColumnName("act_date")
                    .HasComment("Дата составления записи акта о рождении");

                entity.Property(e => e.ActDateUpdate)
                    .HasColumnName("act_date_update")
                    .HasComment("Дата внесения исправления и изменения в запись акта гражданского состояния или дата внесения отметки  \r\r\n	о восстановлении или об аннулировании записи акта гражданского состояния");

                entity.Property(e => e.ActNumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("act_number")
                    .HasComment("Номер записи акта о рождении");

                entity.Property(e => e.ActStatus)
                    .HasMaxLength(2)
                    .HasColumnName("act_status")
                    .HasComment("Код статуса");

                entity.Property(e => e.ActStatusDate)
                    .HasColumnName("act_status_date")
                    .HasComment("Дата начала действия статуса");

                entity.Property(e => e.ActTextUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("act_text_update")
                    .HasComment("Содержание внесенного исправления или изменения");

                entity.Property(e => e.ActVersionDate)
                    .HasColumnName("act_version_date")
                    .HasComment("Дата версии записи");

                entity.Property(e => e.ActVersionNumber)
                    .HasMaxLength(3)
                    .HasColumnName("act_version_number")
                    .HasComment("Номер версии записи");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .HasComment("Адрес места жительства");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .HasColumnName("birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(500)
                    .HasColumnName("birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.BodyWeight)
                    .HasMaxLength(5)
                    .HasColumnName("body_weight")
                    .HasComment("Масса тела ребенка при рождении (в граммах)");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country")
                    .HasComment("Гражданство (страна)");

                entity.Property(e => e.DateDocumentBirth)
                    .HasColumnName("date_document_birth")
                    .HasComment("Дата выдачи свидетельства о рождении");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(2)
                    .HasColumnName("document_code")
                    .HasComment("Наименование документа, удостоверяющего личность");

                entity.Property(e => e.DocumentConfirmBirthCode)
                    .HasMaxLength(5)
                    .HasColumnName("document_confirm_birth_code")
                    .HasComment("Документ, подтверждающий рождение (код)");

                entity.Property(e => e.DocumentConfirmBirthDate)
                    .HasColumnName("document_confirm_birth_date")
                    .HasComment("Документ, подтверждающий рождение (дата выдачи)");

                entity.Property(e => e.DocumentConfirmBirthIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_confirm_birth_issuer")
                    .HasComment("Кем выдан документ, подтверждающий факт рождения");

                entity.Property(e => e.DocumentConfirmBirthSerialNumber)
                    .HasMaxLength(25)
                    .HasColumnName("document_confirm_birth_serial_number")
                    .HasComment("Документ, подтверждающий рождение (серия и номер)");

                entity.Property(e => e.DocumentDate)
                    .HasColumnName("document_date")
                    .HasComment("Дата выдачи документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDateUpdate)
                    .HasColumnName("document_date_update")
                    .HasComment("Дата составления АГС / Выдачи документа");

                entity.Property(e => e.DocumentIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer")
                    .HasComment("Наименование органа, выдавшего документ, удостоверяющий личность");

                entity.Property(e => e.DocumentIssuerUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer_update")
                    .HasComment("ЗАГС / кем выдан документ");

                entity.Property(e => e.DocumentNameUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_name_update")
                    .HasComment("Наименование АГС/документа");

                entity.Property(e => e.DocumentSerialNumber)
                    .HasMaxLength(25)
                    .HasColumnName("document_serial_number")
                    .HasComment("Серия и номер документа, удостоверяющего личность");

                entity.Property(e => e.DocumentSerialNumberUpdate)
                    .HasMaxLength(20)
                    .HasColumnName("document_serial_number_update")
                    .HasComment("Номер АГС / Серия и номер документа");

                entity.Property(e => e.EducationCode)
                    .HasMaxLength(2)
                    .HasColumnName("education_code")
                    .HasComment("Образование (код)");

                entity.Property(e => e.EmploymentCode)
                    .HasMaxLength(2)
                    .HasColumnName("employment_code")
                    .HasComment("Занятость (код)");

                entity.Property(e => e.Fio)
                    .HasMaxLength(255)
                    .HasColumnName("fio")
                    .HasComment("ФИО");

                entity.Property(e => e.Gender)
                    .HasMaxLength(3)
                    .HasColumnName("gender")
                    .HasComment("Пол");

                entity.Property(e => e.IsLiveBorn)
                    .HasColumnName("is_live_born")
                    .HasDefaultValueSql("true")
                    .HasComment("Живорожденный");

                entity.Property(e => e.NationalityCode)
                    .HasMaxLength(3)
                    .HasColumnName("nationality_code")
                    .HasComment("Национальность (код)");

                entity.Property(e => e.NumberDocumentBirth)
                    .HasMaxLength(8)
                    .HasColumnName("number_document_birth")
                    .HasComment("Номер свидетельства о рождении");

                entity.Property(e => e.SerialDocumentBirth)
                    .HasMaxLength(8)
                    .HasColumnName("serial_document_birth")
                    .HasComment("Серия свидетельства о рождении");

                entity.Property(e => e.ZagsCode)
                    .HasMaxLength(8)
                    .HasColumnName("zags_code")
                    .HasComment("Код/Наименование органа ЗАГС");
            });

            modelBuilder.Entity<DZagsDeath>(entity =>
            {
                entity.ToTable("d_zags_death", "zags");

                entity.HasComment("Данные по смертности с ЗАГС");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ActCodeUpdate)
                    .HasMaxLength(4)
                    .HasColumnName("act_code_update")
                    .HasComment("Код/Наименование вида записей ");

                entity.Property(e => e.ActDate)
                    .HasColumnName("act_date")
                    .HasComment("Дата составления записи акта о смерти");

                entity.Property(e => e.ActDateUpdate)
                    .HasColumnName("act_date_update")
                    .HasComment("Дата внесения исправления и изменения в запись акта гражданского состояния или дата внесения отметки  \r\r\n	о восстановлении или об аннулировании записи акта гражданского состояния");

                entity.Property(e => e.ActNumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("act_number")
                    .HasComment("Номер записи акта о смерти");

                entity.Property(e => e.ActStatus)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("act_status")
                    .HasComment("Статус (код/наименование) записи акта");

                entity.Property(e => e.ActTextUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("act_text_update")
                    .HasComment("Содержание внесенного исправления или изменения");

                entity.Property(e => e.ActVersionDate)
                    .HasColumnName("act_version_date")
                    .HasComment("Дата версии записи");

                entity.Property(e => e.ActVersionNumber)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("act_version_number")
                    .HasComment("Номер версии записи");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .HasComment("Адрес места жительства");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .HasColumnName("birth_date")
                    .HasComment("Дата рождения (может быть без Дня и/или месяца)");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(500)
                    .HasColumnName("birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country")
                    .HasComment("Гражданство (страна)");

                entity.Property(e => e.DateDocumentDeath)
                    .HasColumnName("date_document_death")
                    .HasComment("Дата выдачи свидетельства о смерти");

                entity.Property(e => e.DeathCause)
                    .HasMaxLength(750)
                    .HasColumnName("death_cause")
                    .HasComment("Причины смерти");

                entity.Property(e => e.DeathCircumstancesCode)
                    .HasMaxLength(2)
                    .HasColumnName("death_circumstances_code")
                    .HasComment("Обстоятельства смерти");

                entity.Property(e => e.DeathDate)
                    .HasMaxLength(10)
                    .HasColumnName("death_date")
                    .HasComment("Дата смерти (может быть без Дня и/или месяца)");

                entity.Property(e => e.DeathPlace)
                    .HasMaxLength(500)
                    .HasColumnName("death_place")
                    .HasComment("Место смерти");

                entity.Property(e => e.DeathPlaceCode)
                    .HasMaxLength(2)
                    .HasColumnName("death_place_code")
                    .HasComment("Место наступления смерти (код)");

                entity.Property(e => e.DeathTime)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("death_time")
                    .HasComment("Время Смерти");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(2)
                    .HasColumnName("document_code")
                    .HasComment("Наименование документа, удостоверяющего личность");

                entity.Property(e => e.DocumentConfirmDeathCode)
                    .HasMaxLength(5)
                    .HasColumnName("document_confirm_death_code")
                    .HasComment("Код документа, подтверждающего факт смерти");

                entity.Property(e => e.DocumentConfirmDeathDate)
                    .HasColumnName("document_confirm_death_date")
                    .HasComment("Дата документа, подтверждающего факт смерти");

                entity.Property(e => e.DocumentConfirmDeathIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_confirm_death_issuer")
                    .HasComment("Кем выдан документ, подтверждающий факт смерти");

                entity.Property(e => e.DocumentConfirmDeathSerialNumber)
                    .HasMaxLength(25)
                    .HasColumnName("document_confirm_death_serial_number")
                    .HasComment("Серия и номер документа, подтверждающего факт смерти");

                entity.Property(e => e.DocumentDate)
                    .HasColumnName("document_date")
                    .HasComment("Дата выдачи документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDateUpdate)
                    .HasColumnName("document_date_update")
                    .HasComment("Дата составления");

                entity.Property(e => e.DocumentIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer")
                    .HasComment("Наименование органа, выдавшего документ, удостоверяющий личность");

                entity.Property(e => e.DocumentIssuerUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer_update")
                    .HasComment("Кем выдан");

                entity.Property(e => e.DocumentNameUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_name_update")
                    .HasComment("Наименование АГС/документа");

                entity.Property(e => e.DocumentSerialNumber)
                    .HasMaxLength(25)
                    .HasColumnName("document_serial_number")
                    .HasComment("Серия и номер документа, удостоверяющего личность");

                entity.Property(e => e.DocumentSerialNumberUpdate)
                    .HasMaxLength(20)
                    .HasColumnName("document_serial_number_update")
                    .HasComment("Серия документа исправившего");

                entity.Property(e => e.EducationCode)
                    .HasMaxLength(2)
                    .HasColumnName("education_code")
                    .HasComment("Образование");

                entity.Property(e => e.EmploymentCode)
                    .HasMaxLength(2)
                    .HasColumnName("employment_code")
                    .HasComment("Занятость");

                entity.Property(e => e.Fio)
                    .HasMaxLength(255)
                    .HasColumnName("fio")
                    .HasComment("ФИО");

                entity.Property(e => e.Gender)
                    .HasMaxLength(3)
                    .HasColumnName("gender")
                    .HasComment("Пол");

                entity.Property(e => e.IsDeath)
                    .HasColumnName("is_death")
                    .HasComment("Признак умершего лица, личность которого не установлена");

                entity.Property(e => e.MaritalStatusCode)
                    .HasMaxLength(2)
                    .HasColumnName("marital_status_code")
                    .HasComment("Семейное положение");

                entity.Property(e => e.NationalityCode)
                    .HasMaxLength(3)
                    .HasColumnName("nationality_code")
                    .HasComment("Национальность");

                entity.Property(e => e.NumberDocumentDeath)
                    .HasMaxLength(20)
                    .HasColumnName("number_document_death")
                    .HasComment("Номер Свидетельства");

                entity.Property(e => e.SerialDocumentDeath)
                    .HasMaxLength(20)
                    .HasColumnName("serial_document_death")
                    .HasComment("Серия Свидетельства");

                entity.Property(e => e.SetCauseDeathBasic)
                    .HasMaxLength(2)
                    .HasColumnName("set_cause_death_basic")
                    .HasComment("Основание, послужившее для установления причины смерти");

                entity.Property(e => e.SetCauseDeathPersonCode)
                    .HasMaxLength(2)
                    .HasColumnName("set_cause_death_person_code")
                    .HasComment("Лицо, установившее причину смерти (код)");

                entity.Property(e => e.SetCauseDeathPersonFio)
                    .HasMaxLength(255)
                    .HasColumnName("set_cause_death_person_fio")
                    .HasComment("ФИО врача, установившего причину смерти");

                entity.Property(e => e.ZagsCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("zags_code")
                    .HasComment("Код/Наименование органа ЗАГС");
            });

            modelBuilder.Entity<DZagsDivorce>(entity =>
            {
                entity.ToTable("d_zags_divorce", "zags");

                entity.HasComment("Данные по расторжению брака");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ActCodeUpdate)
                    .HasMaxLength(4)
                    .HasColumnName("act_code_update")
                    .HasComment("Код/Наименование вида записей ");

                entity.Property(e => e.ActDate)
                    .HasColumnName("act_date")
                    .HasComment("Дата составления записи акта о заключении брака");

                entity.Property(e => e.ActDateUpdate)
                    .HasColumnName("act_date_update")
                    .HasComment("Дата внесения исправления и изменения в запись акта гражданского состояния или дата внесения отметки  \r\r\n	о восстановлении или об аннулировании записи акта гражданского состояния");

                entity.Property(e => e.ActNumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("act_number")
                    .HasComment("Номер записи акта о заключении брака");

                entity.Property(e => e.ActStatus)
                    .HasMaxLength(2)
                    .HasColumnName("act_status")
                    .HasComment("Код статуса");

                entity.Property(e => e.ActStatusDate)
                    .HasColumnName("act_status_date")
                    .HasComment("Дата начала действия статуса");

                entity.Property(e => e.ActTextUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("act_text_update")
                    .HasComment("Содержание внесенного исправления или изменения");

                entity.Property(e => e.ActVersionDate)
                    .HasColumnName("act_version_date")
                    .HasComment("Дата версии записи");

                entity.Property(e => e.ActVersionNumber)
                    .HasMaxLength(3)
                    .HasColumnName("act_version_number")
                    .HasComment("Номер версии записи");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .HasComment("Адрес места жительства");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .HasColumnName("birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(500)
                    .HasColumnName("birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country")
                    .HasComment("Гражданство (страна)");

                entity.Property(e => e.DateDocumentDivorce)
                    .HasColumnName("date_document_divorce")
                    .HasComment("Дата выдачи свидетельства о расторжении брака");

                entity.Property(e => e.DivorceDate)
                    .HasColumnName("divorce_date")
                    .HasComment("Дата прекращения брака");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(2)
                    .HasColumnName("document_code")
                    .HasComment("Наименование документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDate)
                    .HasColumnName("document_date")
                    .HasComment("Дата выдачи документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDateUpdate)
                    .HasColumnName("document_date_update")
                    .HasComment("Дата составления АГС / Выдачи документа");

                entity.Property(e => e.DocumentIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer")
                    .HasComment("Наименование органа, выдавшего документ, удостоверяющий личность");

                entity.Property(e => e.DocumentIssuerUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer_update")
                    .HasComment("ЗАГС / кем выдан документ");

                entity.Property(e => e.DocumentNameUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_name_update")
                    .HasComment("Наименование АГС/документа");

                entity.Property(e => e.DocumentSerialNumber)
                    .HasMaxLength(25)
                    .HasColumnName("document_serial_number")
                    .HasComment("Серия и номер документа, удостоверяющего личность");

                entity.Property(e => e.DocumentSerialNumberUpdate)
                    .HasMaxLength(20)
                    .HasColumnName("document_serial_number_update")
                    .HasComment("Номер АГС / Серия и номер документа");

                entity.Property(e => e.Fio)
                    .HasMaxLength(255)
                    .HasColumnName("fio")
                    .HasComment("ФИО");

                entity.Property(e => e.Gender)
                    .HasMaxLength(3)
                    .HasColumnName("gender")
                    .HasComment("Пол");

                entity.Property(e => e.LastNameOld)
                    .HasMaxLength(60)
                    .HasColumnName("last_name_old")
                    .HasComment("Фамилия до расторжения брака");

                entity.Property(e => e.NationalityCode)
                    .HasMaxLength(3)
                    .HasColumnName("nationality_code")
                    .HasComment("Национальность (код)");

                entity.Property(e => e.NumberDocumentDivorce)
                    .HasMaxLength(8)
                    .HasColumnName("number_document_divorce")
                    .HasComment("Номер свидетельства о расторжении брака");

                entity.Property(e => e.SerialDocumentDivorce)
                    .HasMaxLength(8)
                    .HasColumnName("serial_document_divorce")
                    .HasComment("Серия свидетельства о расторжении брака");

                entity.Property(e => e.ZagsCode)
                    .HasMaxLength(8)
                    .HasColumnName("zags_code")
                    .HasComment("Код/Наименование органа ЗАГС");
            });

            modelBuilder.Entity<DZagsMarriage>(entity =>
            {
                entity.ToTable("d_zags_marriage", "zags");

                entity.HasComment("Данные по бракам с ЗАГС");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ActCodeUpdate)
                    .HasMaxLength(4)
                    .HasColumnName("act_code_update")
                    .HasComment("Код/Наименование вида записей ");

                entity.Property(e => e.ActDate)
                    .HasColumnName("act_date")
                    .HasComment("Дата составления записи акта о заключении брака");

                entity.Property(e => e.ActDateUpdate)
                    .HasColumnName("act_date_update")
                    .HasComment("Дата внесения исправления и изменения в запись акта гражданского состояния или дата внесения отметки  \r\r\n	о восстановлении или об аннулировании записи акта гражданского состояния");

                entity.Property(e => e.ActNumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("act_number")
                    .HasComment("Номер записи акта о заключении брака");

                entity.Property(e => e.ActStatus)
                    .HasMaxLength(2)
                    .HasColumnName("act_status")
                    .HasComment("Код статуса");

                entity.Property(e => e.ActStatusDate)
                    .HasColumnName("act_status_date")
                    .HasComment("Дата начала действия статуса");

                entity.Property(e => e.ActTextUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("act_text_update")
                    .HasComment("Содержание внесенного исправления или изменения");

                entity.Property(e => e.ActVersionDate)
                    .HasColumnName("act_version_date")
                    .HasComment("Дата версии записи");

                entity.Property(e => e.ActVersionNumber)
                    .HasMaxLength(3)
                    .HasColumnName("act_version_number")
                    .HasComment("Номер версии записи");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .HasComment("Адрес места жительства");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .HasColumnName("birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(500)
                    .HasColumnName("birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country")
                    .HasComment("Гражданство (страна)");

                entity.Property(e => e.DateDocumentMarriage)
                    .HasColumnName("date_document_marriage")
                    .HasComment("Дата выдачи свидетельства о заключении брака");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(2)
                    .HasColumnName("document_code")
                    .HasComment("Наименование документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDate)
                    .HasColumnName("document_date")
                    .HasComment("Дата выдачи документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDateUpdate)
                    .HasColumnName("document_date_update")
                    .HasComment("Дата составления АГС / Выдачи документа");

                entity.Property(e => e.DocumentIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer")
                    .HasComment("Наименование органа, выдавшего документ, удостоверяющий личность");

                entity.Property(e => e.DocumentIssuerUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer_update")
                    .HasComment("ЗАГС / кем выдан документ");

                entity.Property(e => e.DocumentNameUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_name_update")
                    .HasComment("Наименование АГС/документа");

                entity.Property(e => e.DocumentSerialNumber)
                    .HasMaxLength(25)
                    .HasColumnName("document_serial_number")
                    .HasComment("Серия и номер документа, удостоверяющего личность");

                entity.Property(e => e.DocumentSerialNumberUpdate)
                    .HasMaxLength(20)
                    .HasColumnName("document_serial_number_update")
                    .HasComment("Номер АГС / Серия и номер документа");

                entity.Property(e => e.Fio)
                    .HasMaxLength(255)
                    .HasColumnName("fio")
                    .HasComment("ФИО");

                entity.Property(e => e.Gender)
                    .HasMaxLength(3)
                    .HasColumnName("gender")
                    .HasComment("Пол");

                entity.Property(e => e.LastNameOld)
                    .HasMaxLength(60)
                    .HasColumnName("last_name_old")
                    .HasComment("Фамилия до заключения брака");

                entity.Property(e => e.MarriageDate)
                    .HasColumnName("marriage_date")
                    .HasComment("Дата заключения брака");

                entity.Property(e => e.NationalityCode)
                    .HasMaxLength(3)
                    .HasColumnName("nationality_code")
                    .HasComment("Национальность (код)");

                entity.Property(e => e.NumberDocumentMarriage)
                    .HasMaxLength(8)
                    .HasColumnName("number_document_marriage")
                    .HasComment("Номер свидетельства о заключении брака");

                entity.Property(e => e.SerialDocumentMarriage)
                    .HasMaxLength(8)
                    .HasColumnName("serial_document_marriage")
                    .HasComment("Серия свидетельства о заключении брака");

                entity.Property(e => e.ZagsCode)
                    .HasMaxLength(8)
                    .HasColumnName("zags_code")
                    .HasComment("Код/Наименование органа ЗАГС");
            });

            modelBuilder.Entity<DZagsNameChange>(entity =>
            {
                entity.ToTable("d_zags_name_change", "zags");

                entity.HasComment("Данные по смене ФИО по ЗАГС");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ActCodeUpdate)
                    .HasMaxLength(4)
                    .HasColumnName("act_code_update")
                    .HasComment("Код/Наименование вида записей ");

                entity.Property(e => e.ActDate)
                    .HasColumnName("act_date")
                    .HasComment("Дата составления записи акта о смерти");

                entity.Property(e => e.ActDateBirth)
                    .HasColumnName("act_date_birth")
                    .HasComment("Дата составления записи акта о рождении");

                entity.Property(e => e.ActDateUpdate)
                    .HasColumnName("act_date_update")
                    .HasComment("Дата внесения исправления и изменения в запись акта гражданского состояния или дата внесения отметки  \r\r\n	о восстановлении или об аннулировании записи акта гражданского состояния");

                entity.Property(e => e.ActNameBirth)
                    .HasMaxLength(100)
                    .HasColumnName("act_name_birth")
                    .HasComment("Наименование типа акта гражданского состояния");

                entity.Property(e => e.ActNumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("act_number")
                    .HasComment("Номер записи акта о смерти");

                entity.Property(e => e.ActNumberBirth)
                    .HasMaxLength(22)
                    .HasColumnName("act_number_birth")
                    .HasComment("Номер записи акта о рождении");

                entity.Property(e => e.ActStatus)
                    .HasMaxLength(2)
                    .HasColumnName("act_status")
                    .HasComment("Код статуса");

                entity.Property(e => e.ActStatusDate)
                    .HasColumnName("act_status_date")
                    .HasComment("Дата начала действия статуса");

                entity.Property(e => e.ActTextUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("act_text_update")
                    .HasComment("Содержание внесенного исправления или изменения");

                entity.Property(e => e.ActVersionDate)
                    .HasColumnName("act_version_date")
                    .HasComment("Дата версии записи");

                entity.Property(e => e.ActVersionNumber)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("act_version_number")
                    .HasComment("Номер версии записи");

                entity.Property(e => e.ActZagsCodeBirth)
                    .HasMaxLength(8)
                    .HasColumnName("act_zags_code_birth")
                    .HasComment("Код ЗАГС, в котором была произведена регистрация рождения");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .HasComment("Адрес места жительства");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .HasColumnName("birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(500)
                    .HasColumnName("birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country")
                    .HasComment("Гражданство (страна)");

                entity.Property(e => e.DateDocumentNameChange)
                    .HasColumnName("date_document_name_change")
                    .HasComment("Дата выдачи свидетельства о заключении брака");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(255)
                    .HasColumnName("document_code")
                    .HasComment("Наименование документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDate)
                    .HasColumnName("document_date")
                    .HasComment("Дата выдачи документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDateUpdate)
                    .HasColumnName("document_date_update")
                    .HasComment("Дата составления АГС / Выдачи документа");

                entity.Property(e => e.DocumentIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer")
                    .HasComment("Наименование органа, выдавшего документ, удостоверяющий личность");

                entity.Property(e => e.DocumentIssuerUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer_update")
                    .HasComment("ЗАГС / кем выдан документ");

                entity.Property(e => e.DocumentNameUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_name_update")
                    .HasComment("Наименование АГС/документа");

                entity.Property(e => e.DocumentSerialNumber)
                    .HasMaxLength(20)
                    .HasColumnName("document_serial_number")
                    .HasComment("Серия и номер документа, удостоверяющего личность");

                entity.Property(e => e.DocumentSerialNumberUpdate)
                    .HasMaxLength(20)
                    .HasColumnName("document_serial_number_update")
                    .HasComment("Номер АГС / Серия и номер документа");

                entity.Property(e => e.Fio)
                    .HasMaxLength(255)
                    .HasColumnName("fio")
                    .HasComment("ФИО");

                entity.Property(e => e.FioOld)
                    .HasMaxLength(255)
                    .HasColumnName("fio_old")
                    .HasComment("ФИО до перемены имени");

                entity.Property(e => e.NationalityCode)
                    .HasMaxLength(3)
                    .HasColumnName("nationality_code")
                    .HasComment("Национальность (код)");

                entity.Property(e => e.NumberDocumentNameChange)
                    .HasMaxLength(8)
                    .HasColumnName("number_document_name_change")
                    .HasComment("Номер свидетельства о заключении брака");

                entity.Property(e => e.SerialDocumentNameChange)
                    .HasMaxLength(8)
                    .HasColumnName("serial_document_name_change")
                    .HasComment("Серия свидетельства о заключении брака");

                entity.Property(e => e.ZagsCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("zags_code")
                    .HasComment("Код/Наименование органа ЗАГС");
            });

            modelBuilder.Entity<DZagsPaternity>(entity =>
            {
                entity.ToTable("d_zags_paternity", "zags");

                entity.HasComment("Данные по установлению отцовства по ЗАГС");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ActCodeUpdate)
                    .HasMaxLength(4)
                    .HasColumnName("act_code_update")
                    .HasComment("Код/Наименование вида записей ");

                entity.Property(e => e.ActDate)
                    .HasColumnName("act_date")
                    .HasComment("Дата составления записи акта о рождении");

                entity.Property(e => e.ActDateBirth)
                    .HasColumnName("act_date_birth")
                    .HasComment("Дата составления записи акта о рождении");

                entity.Property(e => e.ActDateUpdate)
                    .HasColumnName("act_date_update")
                    .HasComment("Дата внесения исправления и изменения в запись акта гражданского состояния или дата внесения отметки  \r\r\n	о восстановлении или об аннулировании записи акта гражданского состояния");

                entity.Property(e => e.ActNameBirth)
                    .HasMaxLength(100)
                    .HasColumnName("act_name_birth")
                    .HasComment("Наименование типа акта гражданского состояния");

                entity.Property(e => e.ActNumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("act_number")
                    .HasComment("Номер записи акта о рождении");

                entity.Property(e => e.ActNumberBirth)
                    .HasMaxLength(22)
                    .HasColumnName("act_number_birth")
                    .HasComment("Номер записи акта о рождении");

                entity.Property(e => e.ActStatus)
                    .HasMaxLength(2)
                    .HasColumnName("act_status")
                    .HasComment("Код статуса");

                entity.Property(e => e.ActStatusDate)
                    .HasColumnName("act_status_date")
                    .HasComment("Дата начала действия статуса");

                entity.Property(e => e.ActTextUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("act_text_update")
                    .HasComment("Содержание внесенного исправления или изменения");

                entity.Property(e => e.ActVersionDate)
                    .HasColumnName("act_version_date")
                    .HasComment("Дата версии записи");

                entity.Property(e => e.ActVersionNumber)
                    .HasMaxLength(3)
                    .HasColumnName("act_version_number")
                    .HasComment("Номер версии записи");

                entity.Property(e => e.ActZagsCodeBirth)
                    .HasMaxLength(8)
                    .HasColumnName("act_zags_code_birth")
                    .HasComment("Код ЗАГС, в котором была произведена регистрация рождения");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .HasComment("Адрес места жительства");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .HasColumnName("birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(500)
                    .HasColumnName("birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country")
                    .HasComment("Гражданство (страна)");

                entity.Property(e => e.DateDocumentPaternity)
                    .HasColumnName("date_document_paternity")
                    .HasComment("Дата выдачи свидетельства об установлении отцовства");

                entity.Property(e => e.DocumentBasicCode)
                    .HasMaxLength(5)
                    .HasColumnName("document_basic_code")
                    .HasComment("Код вида документа, являющегося основанием для установления отцовства");

                entity.Property(e => e.DocumentBasicDate)
                    .HasColumnName("document_basic_date")
                    .HasComment("Дата выдачи документа, являющегося основанием для установления отцовства");

                entity.Property(e => e.DocumentBasicIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_basic_issuer")
                    .HasComment("Кем выдан документ, являющийся основанием для установления отцовства");

                entity.Property(e => e.DocumentBasicSerialNumber)
                    .HasMaxLength(25)
                    .HasColumnName("document_basic_serial_number")
                    .HasComment("Серия и номер документа, являющегося основанием для установления отцовства");

                entity.Property(e => e.DocumentCode)
                    .HasMaxLength(2)
                    .HasColumnName("document_code")
                    .HasComment("Наименование документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDate)
                    .HasColumnName("document_date")
                    .HasComment("Дата выдачи документа, удостоверяющего личность");

                entity.Property(e => e.DocumentDateUpdate)
                    .HasColumnName("document_date_update")
                    .HasComment("Дата составления АГС / Выдачи документа");

                entity.Property(e => e.DocumentIssuer)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer")
                    .HasComment("Наименование органа, выдавшего документ, удостоверяющий личность");

                entity.Property(e => e.DocumentIssuerUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_issuer_update")
                    .HasComment("ЗАГС / кем выдан документ");

                entity.Property(e => e.DocumentNameUpdate)
                    .HasMaxLength(255)
                    .HasColumnName("document_name_update")
                    .HasComment("Наименование АГС/документа");

                entity.Property(e => e.DocumentSerialNumber)
                    .HasMaxLength(25)
                    .HasColumnName("document_serial_number")
                    .HasComment("Серия и номер документа, удостоверяющего личность");

                entity.Property(e => e.DocumentSerialNumberUpdate)
                    .HasMaxLength(20)
                    .HasColumnName("document_serial_number_update")
                    .HasComment("Номер АГС / Серия и номер документа");

                entity.Property(e => e.Fio)
                    .HasMaxLength(255)
                    .HasColumnName("fio")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("ФИО");

                entity.Property(e => e.FioOld)
                    .HasMaxLength(255)
                    .HasColumnName("fio_old")
                    .HasComment("ФИО ребенка до установления отцовства");

                entity.Property(e => e.Gender)
                    .HasMaxLength(3)
                    .HasColumnName("gender")
                    .HasComment("Пол");

                entity.Property(e => e.NationalityCode)
                    .HasMaxLength(3)
                    .HasColumnName("nationality_code")
                    .HasComment("Национальность (код)");

                entity.Property(e => e.NumberDocumentPaternity)
                    .HasMaxLength(8)
                    .HasColumnName("number_document_paternity")
                    .HasComment("Номер свидетельства об установлении отцовства");

                entity.Property(e => e.SerialDocumentPaternity)
                    .HasMaxLength(8)
                    .HasColumnName("serial_document_paternity")
                    .HasComment("Серия свидетельства об установлении отцовства");

                entity.Property(e => e.ZagsCode)
                    .HasMaxLength(8)
                    .HasColumnName("zags_code")
                    .HasComment("Код/Наименование органа ЗАГС");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("refresh_tokens", "directory");

                entity.HasIndex(e => e.Id, "refresh_tokens_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "refresh_tokens_s_employees_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ExpireTime)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("expire_time")
                    .HasComment("Дата и время до которой действителен токен обновления");

                entity.Property(e => e.RefreshToken1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("refresh_token")
                    .HasComment("Токен обновления");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Идентификатор сотрудника");

                entity.Property(e => e.Used)
                    .HasColumnName("used")
                    .HasComment("Статус токена: использован или нет");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("refresh_tokens_s_employees_id_fkey");
            });

            modelBuilder.Entity<SAlertCustomer>(entity =>
            {
                entity.ToTable("s_alert_customer", "directory");

                entity.HasComment("Способы оповещения заявителей по услуге");

                entity.HasIndex(e => e.Id, "s_alert_customer_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AlertName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("alert_name")
                    .HasComment("Наименование способа оповещения");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");
            });

            modelBuilder.Entity<SAlertEmployee>(entity =>
            {
                entity.ToTable("s_alert_employees", "directory");

                entity.HasComment("Уведомления сотрудникам");

                entity.HasIndex(e => e.Id, "s_alert_employees_idx1_copy1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AlertName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("alert_name")
                    .HasComment("Уведомление");
            });

            modelBuilder.Entity<SAutomatic>(entity =>
            {
                entity.ToTable("s_automatic", "directory");

                entity.HasComment("Операции для автоматического выполнения");

                entity.HasIndex(e => e.Id, "s_automatic_idx1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AutomaticName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("automatic_name")
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<SCalendar>(entity =>
            {
                entity.ToTable("s_calendar", "directory");

                entity.HasComment("Календарь рабочих и выходных дней");

                entity.HasIndex(e => e.Id, "s_calendar_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_calendar_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Date)
                    .HasColumnName("date_")
                    .HasComment("Дата");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время внесения изменений");

                entity.Property(e => e.DateType)
                    .HasColumnName("date_type")
                    .HasComment("Тип дня (Выходной - 0, Рабочий день - 1, 2 Праздничный)");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");
            });

            modelBuilder.Entity<SDocument>(entity =>
            {
                entity.ToTable("s_documents", "directory");

                entity.HasComment("Справочник документов необходимых для оказания услуги");

                entity.HasIndex(e => e.Id, "s_documents_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления документа");

                entity.Property(e => e.DocumentDescription)
                    .HasColumnName("document_description")
                    .HasComment("Описание документа");

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .HasColumnName("document_name")
                    .HasComment("Наименование документа");

                entity.Property(e => e.DocumentSpecification)
                    .HasMaxLength(2500)
                    .HasColumnName("document_specification")
                    .HasComment("Требование к документу");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудник добавившего запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");
            });

            modelBuilder.Entity<SDocumentsCode>(entity =>
            {
                entity.ToTable("s_documents_code", "directory");

                entity.HasComment("Коды подразделений выдавших документы");

                entity.HasIndex(e => e.Id, "s_documents_code_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_document_code'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания названия документа");

                entity.Property(e => e.DocumentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("document_code")
                    .HasComment("Код документа");

                entity.Property(e => e.DocumentIssueBody)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("document_issue_body")
                    .HasComment("Кто выдал документ");

                entity.Property(e => e.IdUuid).HasColumnName("id_uuid");
            });

            modelBuilder.Entity<SDocumentsIdentity>(entity =>
            {
                entity.ToTable("s_documents_identity", "directory");

                entity.HasComment("Cписок документов удостоверяющих личность");

                entity.HasIndex(e => e.Id, "s_documents_identity_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("ID\\Код документа");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("document_name")
                    .HasComment("Наименование документа");

                entity.Property(e => e.DocumentNameSmall)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("document_name_small")
                    .HasComment("Краткое наименование документа");
            });

            modelBuilder.Entity<SDocumentsSmevRequestJoin>(entity =>
            {
                entity.ToTable("s_documents_smev_request_join", "directory");

                entity.HasComment("Справочник отношений запросов СМЭВ к документам");

                entity.HasIndex(e => e.Id, "s_documents_smev_request_join_id_idx");

                entity.HasIndex(e => e.SDocumentsId, "s_documents_smev_request_join_s_documents_id_idx");

                entity.HasIndex(e => e.SSmevRequestId, "s_documents_smev_request_join_s_smev_request_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата добавления");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Кто добавил");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SDocumentsId)
                    .HasColumnName("s_documents_id")
                    .HasComment("Связь с документом");

                entity.Property(e => e.SSmevRequestId)
                    .HasColumnName("s_smev_request_id")
                    .HasComment("Связь с запросом СМЭВ");

                entity.HasOne(d => d.SDocuments)
                    .WithMany(p => p.SDocumentsSmevRequestJoins)
                    .HasForeignKey(d => d.SDocumentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_documents_smev_request_join_s_documents_id_fkey");

                entity.HasOne(d => d.SSmevRequest)
                    .WithMany(p => p.SDocumentsSmevRequestJoins)
                    .HasForeignKey(d => d.SSmevRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_documents_smev_request_join_s_smev_request_id_fkey");
            });

            modelBuilder.Entity<SEmployee>(entity =>
            {
                entity.ToTable("s_employees", "directory");

                entity.HasComment("Справочник сотрудников");

                entity.HasIndex(e => e.EmployeeName, "s_employees_employee_last_name_idx");

                entity.HasIndex(e => e.Id, "s_employees_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AspNetUserId).HasComment("Связь с пользователем");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeeCertificateNumber)
                    .HasMaxLength(50)
                    .HasColumnName("employee_certificate_number")
                    .HasComment("Номер сертификата");

                entity.Property(e => e.EmployeeDocBirthDate)
                    .HasColumnName("employee_doc_birth_date")
                    .HasComment("Дата рождения");

                entity.Property(e => e.EmployeeDocBirthPlace)
                    .HasMaxLength(255)
                    .HasColumnName("employee_doc_birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.EmployeeDocCode)
                    .HasMaxLength(30)
                    .HasColumnName("employee_doc_code")
                    .HasComment("Код документа");

                entity.Property(e => e.EmployeeDocIssueDate)
                    .HasColumnName("employee_doc_issue_date")
                    .HasComment("Дата выдачи паспорта");

                entity.Property(e => e.EmployeeDocIssuePlace)
                    .HasMaxLength(255)
                    .HasColumnName("employee_doc_issue_place")
                    .HasComment("Кем выдан");

                entity.Property(e => e.EmployeeDocNumber)
                    .HasMaxLength(20)
                    .HasColumnName("employee_doc_number")
                    .HasComment("Номер паспорта");

                entity.Property(e => e.EmployeeDocSerial)
                    .HasMaxLength(20)
                    .HasColumnName("employee_doc_serial")
                    .HasComment("Серия паспорта");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(70)
                    .HasColumnName("employee_email")
                    .HasComment("Электронная почта сотрудника");

                entity.Property(e => e.EmployeeInn)
                    .HasMaxLength(30)
                    .HasColumnName("employee_inn")
                    .HasComment("ИНН - Идентификационный номер налогоплательщика");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employee_name")
                    .HasComment("ФИО сотрудника");

                entity.Property(e => e.EmployeePersonalNumber)
                    .HasMaxLength(10)
                    .HasColumnName("employee_personal_number")
                    .HasComment("Табельный номер");

                entity.Property(e => e.EmployeePhone)
                    .HasMaxLength(30)
                    .HasColumnName("employee_phone")
                    .HasComment("Номер телефона сотрудника");

                entity.Property(e => e.EmployeeSnils)
                    .HasMaxLength(30)
                    .HasColumnName("employee_snils")
                    .HasComment("СНИЛС - Страховой номер индивидуального лицевого счёта");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.SEmployees)
                    .HasForeignKey(d => d.AspNetUserId)
                    .HasConstraintName("s_employees_fk_aspnetusers_id");
            });

            modelBuilder.Entity<SEmployeesActive>(entity =>
            {
                entity.ToTable("s_employees_active", "directory");

                entity.HasComment("Включение\\Выключение учетной записи сотрудника");

                entity.HasIndex(e => e.DateStart, "s_employees_active_active_date_start_idx");

                entity.HasIndex(e => e.DateStop, "s_employees_active_active_date_stop_idx");

                entity.HasIndex(e => e.Id, "s_employees_active_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "s_employees_active_s_employees_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления статуса");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала действия статуса");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания действия статуса");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesActives)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_active_s_employees_id_fkey");
            });

            modelBuilder.Entity<SEmployeesAuthorizationLog>(entity =>
            {
                entity.ToTable("s_employees_authorization_log", "directory");

                entity.HasComment("Справочник авторзаций сотрудников");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.LogInBrowserName)
                    .HasMaxLength(255)
                    .HasColumnName("log_in_browser_name")
                    .HasComment("Наименование браузера");

                entity.Property(e => e.LogInBrowserVersion)
                    .HasMaxLength(20)
                    .HasColumnName("log_in_browser_version")
                    .HasComment("Версия браузера");

                entity.Property(e => e.LogInDate)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("log_in_date")
                    .HasComment("Дата авторизации");

                entity.Property(e => e.LogInIp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("log_in_ip")
                    .HasComment("IP адрес с которого совершена авторизация");

                entity.Property(e => e.LogInProvider)
                    .HasMaxLength(255)
                    .HasColumnName("log_in_provider")
                    .HasComment("Провайдер");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с офисом");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesAuthorizationLogs)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_authorization_log_s_employees_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.SEmployeesAuthorizationLogs)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_authorization_log_fk");
            });

            modelBuilder.Entity<SEmployeesCombinationJob>(entity =>
            {
                entity.ToTable("s_employees_combination_job", "directory");

                entity.HasComment("Справочник должностей совмещаемых сотрудником");

                entity.HasIndex(e => e.Id, "s_employees_combination_job_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала действия должности");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания действия должности");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудника добавившего запись");

                entity.Property(e => e.EmployeeIntensity)
                    .HasPrecision(15, 2)
                    .HasColumnName("employee_intensity")
                    .HasComment("Интенсивность");

                entity.Property(e => e.EmployeeRate)
                    .HasPrecision(15, 2)
                    .HasColumnName("employee_rate")
                    .HasComment("Ставка");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesCombinationJobs)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_combination_job_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.SEmployeesCombinationJobs)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_combination_job_s_employees_job_position_id_fkey");
            });

            modelBuilder.Entity<SEmployeesCoverLetter>(entity =>
            {
                entity.ToTable("s_employees_cover_letter", "directory");

                entity.HasComment("Сопроводительные письма сотрудника. Шаблоны");

                entity.HasIndex(e => e.Id, "s_employees_cover_letter_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "s_employees_cover_letter_s_employees_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудника");

                entity.Property(e => e.JsonData)
                    .HasColumnType("jsonb")
                    .HasColumnName("json_data")
                    .HasComment("Информация для письма");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь со справочником сотрудников");

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("template_name")
                    .HasComment("Шаблон письма");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesCoverLetters)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_cover_letter_s_employees_id_fkey");
            });

            modelBuilder.Entity<SEmployeesExecution>(entity =>
            {
                entity.ToTable("s_employees_execution", "directory");

                entity.HasComment("Справочник статусов возможности исполнения дел для сотрудников");

                entity.HasIndex(e => e.Id, "s_employees_execution_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "s_employees_execution_s_employees_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");
/*
                entity.Property(e => e.IsExecution)
                    .HasColumnName("is_execution")
                    .HasComment("Возможность исполнения услуг");*/

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesExecutions)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_execution_s_employees_id_fkey");
            });

            modelBuilder.Entity<SEmployeesFile>(entity =>
            {
                entity.ToTable("s_employees_file", "directory");

                entity.HasComment("Справочник файлов сотрудника");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("file_extension")
                    .HasComment("Расширение файла");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("file_name")
                    .HasComment("Наименование файла");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер файла");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesFileFolderId)
                    .HasColumnName("s_employees_file_folder_id")
                    .HasComment("Связь с папкой");

                entity.HasOne(d => d.SEmployeesFileFolder)
                    .WithMany(p => p.SEmployeesFiles)
                    .HasForeignKey(d => d.SEmployeesFileFolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_file_s_employees_file_folder_id_fkey");
            });

            modelBuilder.Entity<SEmployeesFileFolder>(entity =>
            {
                entity.ToTable("s_employees_file_folder", "directory");

                entity.HasComment("Справочник папок сотрудников для файлов");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления папки");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.FolderName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("folder_name")
                    .HasComment("Наименование папки");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesFileFolders)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_file_folder_s_employees_id_fkey");
            });

            modelBuilder.Entity<SEmployeesJobPosition>(entity =>
            {
                entity.ToTable("s_employees_job_position", "directory");

                entity.HasComment("Справочник должностей");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_employees_job_position_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.EditDate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("edit_date")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата редактирования должности");

                entity.Property(e => e.EditEmployeesFio)
                    .HasMaxLength(70)
                    .HasColumnName("edit_employees_fio")
                    .HasComment("Сотрудник редактировавший должность");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.JobPositionName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("job_position_name")
                    .HasComment("Наименование должности");

                entity.Property(e => e.Sorting)
                    .HasColumnName("sorting_")
                    .HasComment("Поле для сортировки в отчетах по зарплате");
            });

            modelBuilder.Entity<SEmployeesJobPositionFine>(entity =>
            {
                entity.ToTable("s_employees_job_position_fine", "directory");

                entity.HasComment("Справочник штрафов в отношении должностей");

                entity.HasIndex(e => e.Id, "s_employees_job_position_fine_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "s_employees_job_position_fine_s_employees_job_position_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала действия штрафа");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания действия штрафа");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.FineSum)
                    .HasPrecision(15, 2)
                    .HasColumnName("fine_sum")
                    .HasComment("Сумма штрафа");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.SEmployeesJobPositionFines)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_job_position_fine_s_employees_job_position_id_fkey");
            });

            modelBuilder.Entity<SEmployeesOfficesJoin>(entity =>
            {
                entity.ToTable("s_employees_offices_join", "directory");

                entity.HasComment("Справочник отношений сотрудника к офису");

                entity.HasIndex(e => e.DateStart, "s_employees_offices_join_date_start_idx");

                entity.HasIndex(e => e.DateStop, "s_employees_offices_join_date_stop_idx");

                entity.HasIndex(e => e.Id, "s_employees_offices_join_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "s_employees_offices_join_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "s_employees_offices_join_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.SOfficesId, "s_employees_offices_join_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала действия");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания действия");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.EmployeeIntensity)
                    .HasPrecision(15, 2)
                    .HasColumnName("employee_intensity")
                    .HasComment("Интенсивность");

                entity.Property(e => e.EmployeeRate)
                    .HasPrecision(15, 2)
                    .HasColumnName("employee_rate")
                    .HasComment("Ставка");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с офисом");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesOfficesJoins)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_offices_join_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.SEmployeesOfficesJoins)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_offices_join_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.SEmployeesOfficesJoins)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_offices_join_s_offices_id_fkey");
            });

            modelBuilder.Entity<SOfficesAuthorization>(entity =>
            {
                entity.ToTable("s_offices_authorization", "directory");

                entity.HasComment("Таблица выбора офисов для авторизации");

                entity.HasIndex(e => e.DateStart, "s_offices_authorization_date_start_idx");

                entity.HasIndex(e => e.DateStop, "s_offices_authorization_date_stop_idx");

                entity.HasIndex(e => e.IsRemove, "s_offices_authorization_is_remove_idx");

                entity.HasIndex(e => e.Id, "s_offices_authorization_pk").IsUnique();

                entity.HasIndex(e => e.SEmployeesId, "s_offices_authorization_s_employees_id_idx");

                entity.HasIndex(e => e.SOfficesId, "s_offices_authorization_s_offices_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала действия");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания действия");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Связь с офисом");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SOfficesAuthorizations)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_offices_authorization_fk1");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.SOfficesAuthorizations)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_offices_authorization_fk");
            });

            modelBuilder.Entity<SEmployeesRolesExecutor>(entity =>
            {
                entity.ToTable("s_employees_roles_executor", "directory");

                entity.HasComment("Роли исполнителя у сотрудника");

                entity.HasIndex(e => e.Id, "s_employees_roles_executor_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesId, "s_employees_roles_executor_idx2");

                entity.HasIndex(e => e.SRolesExecutorId, "s_employees_roles_executor_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавлния записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Кто добавил");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудник");

                entity.Property(e => e.SRolesExecutorId)
                    .HasColumnName("s_roles_executor_id")
                    .HasComment("Роль исполнителя");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesRolesExecutors)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_roles_executor_fk1");

                entity.HasOne(d => d.SRolesExecutor)
                    .WithMany(p => p.SEmployeesRolesExecutors)
                    .HasForeignKey(d => d.SRolesExecutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_roles_executor_fk2");
            });

            modelBuilder.Entity<SEmployeesStatus>(entity =>
            {
                entity.ToTable("s_employees_status", "directory");

                entity.HasComment("Справочник статусов сотрудников");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_employees_status_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("status_name")
                    .HasComment("Наименование статуса");
            });

            modelBuilder.Entity<SEmployeesStatusJoin>(entity =>
            {
                entity.ToTable("s_employees_status_join", "directory");

                entity.HasComment("Справочник отношений статусов к сотрудникам");

                entity.HasIndex(e => e.DateStart, "s_employees_status_join_date_start_idx");

                entity.HasIndex(e => e.DateStop, "s_employees_status_join_date_stop_idx");

                entity.HasIndex(e => e.Id, "s_employees_status_join_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "s_employees_status_join_s_employees_id_idx");

                entity.HasIndex(e => e.SEmployeesStatusId, "s_employees_status_join_s_employees_status_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала работы статуса");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончания работы статуса");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с cотрудником");

                entity.Property(e => e.SEmployeesStatusId)
                    .HasColumnName("s_employees_status_id")
                    .HasComment("Cвязь со статусом");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesStatusJoins)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_status_join_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesStatus)
                    .WithMany(p => p.SEmployeesStatusJoins)
                    .HasForeignKey(d => d.SEmployeesStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_status_join_s_employees_status_id_fkey");
            });

            modelBuilder.Entity<SEmployeesTemplate>(entity =>
            {
                entity.ToTable("s_employees_template", "directory");

                entity.HasComment("Справочник шаблонов  примечаний сотрудников");

                entity.HasIndex(e => e.Id, "s_employees_template_id_idx");

                entity.HasIndex(e => e.SEmployeesId, "s_employees_template_s_employees_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SortField)
                    .HasColumnName("sort_field")
                    .HasComment("Поле для сортировки");

                entity.Property(e => e.TemplateText)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("template_text")
                    .HasComment("Текст шаблона");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesTemplates)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_template_s_employees_id_fkey");
            });

            modelBuilder.Entity<SEmployeesWorkingTime>(entity =>
            {
                entity.ToTable("s_employees_working_time", "directory");

                entity.HasComment("Справочник статусов для табеля");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_employees_working_time_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.StatusMnemo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("status_mnemo")
                    .HasComment("Мнемоника статуса");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status_name")
                    .HasComment("Наименование статуса");
            });

            modelBuilder.Entity<SEmployeesWorkingTimeJoin>(entity =>
            {
                entity.ToTable("s_employees_working_time_join", "directory");

                entity.HasComment("Справочник статусов для табеля сотрудников");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.Date)
                    .HasColumnName("date_")
                    .HasComment("Дата статуса");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Связь с сотрудником");

                entity.Property(e => e.SEmployeesOfficesJoinId)
                    .HasColumnName("s_employees_offices_join_id")
                    .HasComment("Связь с отношением филиала к сотруднику");

                entity.Property(e => e.SEmployeesWorkingTimeId)
                    .HasColumnName("s_employees_working_time_id")
                    .HasComment("Связь со статусом рабочего времени");

                entity.HasOne(d => d.SEmployees)
                    .WithMany(p => p.SEmployeesWorkingTimeJoins)
                    .HasForeignKey(d => d.SEmployeesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_working_time_join_s_employees_id_fkey");

                entity.HasOne(d => d.SEmployeesOfficesJoin)
                    .WithMany(p => p.SEmployeesWorkingTimeJoins)
                    .HasForeignKey(d => d.SEmployeesOfficesJoinId)
                    .HasConstraintName("s_employees_working_time_join_s_employees_offices_join_id_fkey");

                entity.HasOne(d => d.SEmployeesWorkingTime)
                    .WithMany(p => p.SEmployeesWorkingTimeJoins)
                    .HasForeignKey(d => d.SEmployeesWorkingTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_employees_working_time_join_s_employees_working_time_id_fkey");
            });

            modelBuilder.Entity<SReport>(entity =>
            {
                entity.ToTable("s_report", "directory");

                entity.HasComment("Список отчетов");

                entity.HasIndex(e => e.Id, "s_report_pk").IsUnique();
                entity.HasIndex(e => e.ReportName, "s_report_report_name_idx");
                entity.HasIndex(e => e.SReportGroupId, "s_report_s_report_group_id_idx");
                entity.HasIndex(e => e.ReportOrder, "s_report_report_order_idx");
                entity.HasIndex(e => e.IsActive, "s_report_is_active_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ReportName)
                    .IsRequired()
                    .HasColumnName("report_name")
                    .HasComment("Наименование отчета");

                entity.Property(e => e.SReportGroupId)
                    .HasColumnName("s_report_group_id")
                    .HasComment("Связь с отчетом группы");

                entity.Property(e => e.ReportFile)
                    .HasColumnName("report_file")
                    .HasComment("Шаблон (FastReport)");

                entity.Property(e => e.ReportPath)
                    .IsRequired()
                    .HasColumnName("report_path")
                    .HasComment("Путь к файлу в АИС");

                entity.Property(e => e.ReportOrder)
                    .HasColumnName("report_order")
                    .HasComment("Сортировка по важности");

                entity.Property(e => e.ReportFunction)
                    .IsRequired()
                    .HasColumnName("report_function")
                    .HasComment("Функция");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasComment("Описание");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasComment("Активность отчета");

                entity.HasOne(d => d.SReportGroups)
                    .WithMany(p => p.SReports)
                    .HasForeignKey(d => d.SReportGroupId)
                    .HasConstraintName("s_report_fk");
            });

            modelBuilder.Entity<SReportGroup>(entity =>
            {
                entity.ToTable("s_report_group", "directory");

                entity.HasComment("Список групп для отчетов");

                entity.HasIndex(e => e.Id, "s_report_group_pk").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasComment("Наименование группы");
            });

            modelBuilder.Entity<SForm>(entity =>
            {
                entity.ToTable("s_form", "directory");

                entity.HasComment("Бланки отчетов");

                entity.HasIndex(e => e.Id, "s_file_pkey").IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Ключ");

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("form_name")
                    .HasComment("наименование");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("комментарий");

                entity.Property(e => e.File)
                      .HasColumnName("file_")
                      .HasComment("Файл");
            });


            modelBuilder.Entity<SFtp>(entity =>
            {
                entity.ToTable("s_ftp", "directory");

                entity.HasComment("Справочник FTP серверов");

                entity.HasIndex(e => e.Id, "s_ftp_id_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.FtpFolder)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_folder")
                    .HasComment("Папка FTP сервера");

                entity.Property(e => e.FtpLogin)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_login")
                    .HasComment("Логин FTP сервера");

                entity.Property(e => e.FtpPassword)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_password")
                    .HasComment("Пароль FTP сервера");

                entity.Property(e => e.FtpServer)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_server")
                    .HasComment("Адрес FTP сервера");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");
            });

            modelBuilder.Entity<SFtpVipnet>(entity =>
            {
                entity.ToTable("s_ftp_vipnet", "directory");

                entity.HasComment("Таблица FTP адресов Vipnet");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.FtpIn)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_in")
                    .HasComment("Папка для входящих");

                entity.Property(e => e.FtpOut)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_out")
                    .HasComment("Папка для исходящих");

                entity.Property(e => e.FtpPass)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_pass")
                    .HasComment("Пароль");

                entity.Property(e => e.FtpServer)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_server")
                    .HasComment("FTP сервер");

                entity.Property(e => e.FtpUnc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_unc")
                    .HasComment("Папка для неизвестных");

                entity.Property(e => e.FtpUser)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ftp_user")
                    .HasComment("Имя пользователя");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.ProviderName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("provider_name")
                    .HasComment("Наименование провайдера");
            });

            modelBuilder.Entity<SHashtag>(entity =>
            {
                entity.ToTable("s_hashtag", "directory");

                entity.HasComment("Справочник хэштегов");

                entity.HasIndex(e => e.Id, "s_hashtag_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_hashtag_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.HashtagName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("hashtag_name")
                    .HasComment("Наименование хештага");

                entity.Property(e => e.IsHashtagVisible)
                    .HasColumnName("is_hashtag_visible")
                    .HasComment("Видимость хештега на форме \"Новое обращение\"");
            });

            modelBuilder.Entity<SHealthCamp>(entity =>
            {
                entity.ToTable("s_health_camps", "smev");

                entity.HasComment("Справочник оздоровительных учреждений для запросов через МинОбр VipNet");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CampId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("camp_id")
                    .HasComment("Идентификатор оздоровительного учреждения для випнета");

                entity.Property(e => e.CampName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("camp_name")
                    .HasComment("Наименование оздоровительного учреждения");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.Shift1)
                    .HasColumnName("shift_1")
                    .HasComment("Разрешена ли запись на 1 смену");

                entity.Property(e => e.Shift2)
                    .HasColumnName("shift_2")
                    .HasComment("Разрешена ли запись на 2 смену");

                entity.Property(e => e.Shift3)
                    .HasColumnName("shift_3")
                    .HasComment("Разрешена ли запись на 3 смену");
            });

            modelBuilder.Entity<SIasMkguCategory>(entity =>
            {
                entity.ToTable("s_ias_mkgu_category", "services");

                entity.HasComment("Источники оценок ИАС МКГУ");

                entity.HasIndex(e => e.Id, "s_ias_mkgu_category_idx1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("category_name")
                    .HasComment("Наименование категории");
            });

            modelBuilder.Entity<SIasMkguIndicator>(entity =>
            {
                entity.ToTable("s_ias_mkgu_indicator", "services");

                entity.HasComment("Идентификатор оцениваемого критерия (показателя) ИАС МКГУ");

                entity.HasIndex(e => e.Id, "s_ias_mkgu_indicator_idx1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.IndicatorName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("indicator_name")
                    .HasComment("Наименование индикатора");
            });

            modelBuilder.Entity<SIasMkguQuestion>(entity =>
            {
                entity.ToTable("s_ias_mkgu_question", "services");

                entity.HasComment("Вопросы ИАС МКГУ для терминала");

                entity.HasIndex(e => e.Id, "s_ias_mkgu_question_idx1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("question")
                    .HasComment("Вопрос");
            });

            modelBuilder.Entity<SIasMkguQuestionAnswer>(entity =>
            {
                entity.ToTable("s_ias_mkgu_question_answer", "services");

                entity.HasComment("Варианты ответов на вопросы ИАС МКГУ для терминалов");

                entity.HasIndex(e => e.Id, "s_ias_mkgu_question_answer_idx1");

                entity.HasIndex(e => e.SIasMkguQuestionId, "s_ias_mkgu_question_answer_idx2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Answer)
                    .HasMaxLength(255)
                    .HasColumnName("answer")
                    .HasComment("Полный ответ");

                entity.Property(e => e.AnswerRating)
                    .HasColumnName("answer_rating")
                    .HasComment("Оценка по 5-ти бальной шкале");

                entity.Property(e => e.AnswerSmall)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("answer_small")
                    .HasComment("Короткий ответ");

                entity.Property(e => e.SIasMkguQuestionId)
                    .HasColumnName("s_ias_mkgu_question_id")
                    .HasComment("Связь со справочником вопросов");

                entity.HasOne(d => d.SIasMkguQuestion)
                    .WithMany(p => p.SIasMkguQuestionAnswers)
                    .HasForeignKey(d => d.SIasMkguQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_ias_mkgu_question_answer_s_ias_mkgu_question_id_fkey");
            });

            modelBuilder.Entity<SIndicator>(entity =>
            {
                entity.ToTable("s_indicators", "reports");

                entity.HasComment("Показатели для отчетов");

                entity.HasIndex(e => e.Id, "s_indicators_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.IndicatorName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("indicator_name")
                    .HasComment("Наименование показателя");
            });

            modelBuilder.Entity<SIndicatorsField>(entity =>
            {
                entity.ToTable("s_indicators_field", "reports");

                entity.HasComment("Поля для фильтрации и группировки в отчетах");

                entity.HasIndex(e => e.Id, "s_indicators_field_idx1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первияный ключ");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("field_name")
                    .HasComment("Наименование поля");
            });

            modelBuilder.Entity<SIndicatorsGroup>(entity =>
            {
                entity.ToTable("s_indicators_group", "reports");

                entity.HasComment("Группы показателей");

                entity.HasIndex(e => e.Id, "s_indicators_group_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("group_name")
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<SIndicatorsSubgroup>(entity =>
            {
                entity.ToTable("s_indicators_subgroup", "reports");

                entity.HasComment("Подгруппы показателей");

                entity.HasIndex(e => e.Id, "s_indicators_subgroup_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SIndicatorGroupId, "s_indicators_subgroup_idx2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.SIndicatorGroupId)
                    .HasColumnName("s_indicator_group_id")
                    .HasComment("Группа");

                entity.Property(e => e.SubgroupName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("subgroup_name")
                    .HasComment("Наименование");

                entity.HasOne(d => d.SIndicatorGroup)
                    .WithMany(p => p.InverseSIndicatorGroup)
                    .HasForeignKey(d => d.SIndicatorGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_indicators_subgroup_fk1");
            });

            modelBuilder.Entity<SInformationType>(entity =>
            {
                entity.ToTable("s_information_type", "directory");

                entity.HasComment("Типы информации");

                entity.HasIndex(e => e.Id, "s_information_type_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("type_name")
                    .HasComment("Наименование ");
            });

            modelBuilder.Entity<SMdmObjectAttribute>(entity =>
            {
                entity.ToTable("s_mdm_object_attribute", "services");

                entity.HasComment("Справочник аттрибутов объектов для отправки в МДМ.");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Идентификатор аттрибута.");

                entity.Property(e => e.IsObjectUuid)
                    .HasColumnName("is_object_uuid")
                    .HasComment("Является ли значение аттрибута UUID его объекта.");

                entity.Property(e => e.ObjectAttributeMnemo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("object_attribute_mnemo")
                    .HasComment("Мнемоника аттрибута объекта МДМ.");

                entity.Property(e => e.ObjectAttributeName)
                    .HasMaxLength(500)
                    .HasColumnName("object_attribute_name")
                    .HasComment("Наименовение аттрибута объекта МДМ.");

                entity.Property(e => e.ObjectAttributeRegex)
                    .HasMaxLength(150)
                    .HasColumnName("object_attribute_regex")
                    .HasComment("Правило проверки значения аттрибута по Regex.");

                entity.Property(e => e.SMdmObjectTypeV2Id)
                    .HasColumnName("s_mdm_object_type_id")
                    .HasComment("Ссылка на тип объекта МДМ, которому принадлежит аттрибут.");
            });

            modelBuilder.Entity<SMdmObjectType>(entity =>
            {
                entity.ToTable("s_mdm_object_type", "services");

                entity.HasComment("Справочник типов объектов, передаваемых в МДМ.");

                entity.HasIndex(e => e.ObjectTypeMnemo, "s_mdm_object_type_copy1_object_type_mnemo_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ, идентификатор типа объекта.");

                entity.Property(e => e.ObjectTypeMnemo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("object_type_mnemo")
                    .HasComment("Мнемоника типа объекта МДМ.");

                entity.Property(e => e.ObjectTypeName)
                    .HasMaxLength(200)
                    .HasColumnName("object_type_name")
                    .HasComment("Наименование типа объекта МДМ.");
            });

            modelBuilder.Entity<SOffice>(entity =>
            {
                entity.ToTable("s_offices", "directory");

                entity.HasComment("Справочник филиалов ");

                entity.HasIndex(e => e.Id, "s_offices_id_idx");

                entity.HasIndex(e => e.SOfficesTypeId, "s_offices_idx2");

                entity.HasIndex(e => e.SFtpId, "s_offices_s_ftp_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.EsiaOperatorSnils)
                    .HasMaxLength(20)
                    .HasColumnName("esia_operator_snils")
                    .HasComment("СНИЛС директора МФЦ для запросов ЕСИА");

                entity.Property(e => e.FileExtension)
                    .HasMaxLength(10)
                    .HasColumnName("file_extension")
                    .HasComment("Расширение файла");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .HasColumnName("file_name")
                    .HasComment("Наименование файла");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер файла");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.MdmUid)
                    .HasColumnName("mdm_uid")
                    .HasComment("uuid филиала в системе МДМ");

                entity.Property(e => e.MegalabsLogin)
                    .HasMaxLength(40)
                    .HasColumnName("megalabs_login")
                    .HasComment("Логин для шлюза смс рассылки");

                entity.Property(e => e.MegalabsPassword)
                    .HasMaxLength(40)
                    .HasColumnName("megalabs_password")
                    .HasComment("Пароль для шлюза смс рассылки");

                entity.Property(e => e.MegalabsSender)
                    .HasMaxLength(40)
                    .HasColumnName("megalabs_sender")
                    .HasComment("Имя отправителя СМС для Мегалабс");

                entity.Property(e => e.OfficeAdress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_adress")
                    .HasComment("Адрес филиала");

                entity.Property(e => e.OfficeCallServer)
                    .HasMaxLength(30)
                    .HasColumnName("office_call_server")
                    .HasComment("Сервер call центра");

                entity.Property(e => e.OfficeCikId)
                    .HasMaxLength(20)
                    .HasColumnName("office_cik_id")
                    .HasComment("Идентификатор МФЦ в ЦИК (для ВС \"Вид сведений для приема через ЕПГУ и МФЦ заявлений о включении избирателя в список избирателей по месту нахождения в день голосования на выборах в Российской Федерации\"");

                entity.Property(e => e.OfficeCikName)
                    .HasMaxLength(200)
                    .HasColumnName("office_cik_name")
                    .HasComment("Наименование МФЦ для ЦИК");

                entity.Property(e => e.OfficeCountPopulation)
                    .HasColumnName("office_count_population")
                    .HasComment("Количество населения на территории офиса");

                entity.Property(e => e.OfficeEmail)
                    .HasMaxLength(70)
                    .HasColumnName("office_email")
                    .HasComment("Официальная почта филиала");

                entity.Property(e => e.OfficeEmailLogin)
                    .HasMaxLength(70)
                    .HasColumnName("office_email_login")
                    .HasComment("Логин почты филиала");

                entity.Property(e => e.OfficeEmailPass)
                    .HasMaxLength(30)
                    .HasColumnName("office_email_pass")
                    .HasComment("Пароль почты филиала");

                entity.Property(e => e.OfficeEmailPort)
                    .HasMaxLength(30)
                    .HasColumnName("office_email_port")
                    .HasComment("Порт почты филиала");

                entity.Property(e => e.OfficeEmailServer)
                    .HasMaxLength(30)
                    .HasColumnName("office_email_server")
                    .HasComment("Сервер почты филиала");

                entity.Property(e => e.OfficeEpguId)
                    .HasMaxLength(20)
                    .HasColumnName("office_epgu_id")
                    .HasComment("Идентификатор МФЦ на ЕПГУ (интеграция с системой ЭОС Дело)");

                entity.Property(e => e.OfficeEsiaCentrId)
                    .HasMaxLength(30)
                    .HasColumnName("office_esia_centr_id")
                    .HasComment("ЕСИА центр ID");

                entity.Property(e => e.OfficeFrguName)
                    .HasMaxLength(300)
                    .HasColumnName("office_frgu_name")
                    .HasComment("Наименование в ФРГУ");

                entity.Property(e => e.OfficeFrguProviderId)
                    .HasMaxLength(30)
                    .HasColumnName("office_frgu_provider_id")
                    .HasComment("Идентификатор филиала ФРГУ");

                entity.Property(e => e.OfficeHeadName)
                    .HasMaxLength(255)
                    .HasColumnName("office_head_name")
                    .HasComment("ФИО руководителя");

                entity.Property(e => e.OfficeInn)
                    .HasMaxLength(30)
                    .HasColumnName("office_inn")
                    .HasComment("ИНН филиала - Идентификационный номер налогоплательщика");

                entity.Property(e => e.OfficeKpp)
                    .HasMaxLength(30)
                    .HasColumnName("office_kpp")
                    .HasComment("КПП филиала - Код причины постановки на учет");

                entity.Property(e => e.OfficeLatitude)
                    .HasMaxLength(255)
                    .HasColumnName("office_latitude")
                    .HasComment("Географическая широта филиала");

                entity.Property(e => e.OfficeLongitude)
                    .HasMaxLength(255)
                    .HasColumnName("office_longitude")
                    .HasComment("Географическая долгота филиала");

                entity.Property(e => e.OfficeMnemo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("office_mnemo")
                    .HasComment("Мнемоника филиала");

                entity.Property(e => e.OfficeMvdOpvId)
                    .HasMaxLength(20)
                    .HasColumnName("office_mvd_opv_id")
                    .HasComment("Идентификатор для загранпаспортов");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("office_name")
                    .HasComment("Наименование филиала");

                entity.Property(e => e.OfficeNameSmall)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("office_name_small")
                    .HasComment("Краткое наименование филиала");

                entity.Property(e => e.OfficeNum)
                    .HasMaxLength(10)
                    .HasColumnName("office_num")
                    .HasComment("Номер для ВипНет ПФР");

                entity.Property(e => e.OfficeOgrn)
                    .HasMaxLength(30)
                    .HasColumnName("office_ogrn")
                    .HasComment("ОГРН филиала - Основной государственный регистрационный номер");

                entity.Property(e => e.OfficeOkato)
                    .HasMaxLength(30)
                    .HasColumnName("office_okato")
                    .HasComment("ОКАТО филиала - Общероссийский классификатор объектов административно-территориального деления");

                entity.Property(e => e.OfficeOktmo)
                    .HasMaxLength(30)
                    .HasColumnName("office_oktmo")
                    .HasComment("ОКТМО филиала - Общероссийский классификатор территорий муниципальных образований");

                entity.Property(e => e.OfficePhoneNumber)
                    .HasMaxLength(30)
                    .HasColumnName("office_phone_number")
                    .HasComment("Номер телефона филиала");

                entity.Property(e => e.OfficeSkype)
                    .HasMaxLength(50)
                    .HasColumnName("office_skype")
                    .HasComment("Адрес Skype для бесплатной удаленной консультации");

                entity.Property(e => e.OfficeVendorId)
                    .HasColumnName("office_vendor_id")
                    .HasComment("Номер филиала для ИАС МКГУ(Информационно-аналитическая система мониторинга качества государственных услуг)");

                entity.Property(e => e.OfficeWebsite)
                    .HasMaxLength(70)
                    .HasColumnName("office_website")
                    .HasComment("Адрес сайта филиала");

                entity.Property(e => e.QueueId)
                    .HasMaxLength(32)
                    .HasColumnName("queue_id")
                    .HasComment("ID  электронной очереди");

                entity.Property(e => e.SFtpId)
                    .HasColumnName("s_ftp_id")
                    .HasComment("Связь с FTP сервером");

                entity.Property(e => e.SOfficesTypeId)
                    .HasColumnName("s_offices_type_id")
                    .HasComment("Тип");

                entity.Property(e => e.SendMdm)
                    .HasColumnName("is_mdm")
                    .HasComment("Отправка в МДМ");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasComment("Головная организация");

                entity.Property(e => e.ReceiveWindowsCount)
                    .HasColumnName("receive_windows_count")
                    .HasComment("Количество окон приема");

                entity.Property(e => e.IsReceptionCustomer)
                   .HasColumnName("is_reception_customer")
                   .HasComment("Ведет прием от заявителя");

                entity.Property(e => e.IsProviderService)
                   .HasColumnName("is_provider_service")
                   .HasComment("Орган предоставляющий услугу");

                entity.Property(e => e.OfficeSquare)
                   .HasPrecision(15, 2)
                   .HasColumnName("office_square")
                   .HasComment("Площадь");

                entity.Property(e => e.OfficeImage)
                    .HasColumnName("office_image")
                    .HasComment("Фото");

                entity.HasOne(d => d.SFtp)
                    .WithMany(p => p.SOffices)
                    .HasForeignKey(d => d.SFtpId)
                    .HasConstraintName("s_offices_s_ftp_id_fkey");

                entity.HasOne(d => d.SOfficesType)
                    .WithMany(p => p.SOffices)
                    .HasForeignKey(d => d.SOfficesTypeId)
                    .HasConstraintName("s_offices_s_offices_type_id_fkey");
            });

            modelBuilder.Entity<SOfficesPlan>(entity =>
            {
                entity.ToTable("s_offices_plan", "reports");

                entity.HasComment("План по  услугам для филиалов");

                entity.HasIndex(e => e.Id, "s_offices_plan_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SOfficesId, "s_offices_plan_idx2");

                entity.HasIndex(e => e.Year, "s_offices_plan_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Кто добавил запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.PlanMonth)
                    .HasColumnName("plan_month")
                    .HasComment("План на месяц");

                entity.Property(e => e.PlanYear)
                    .HasColumnName("plan_year")
                    .HasComment("План на год");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Филиал");

                entity.Property(e => e.Year)
                    .HasColumnName("year_")
                    .HasComment("Год");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.SOfficesPlans)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_offices_plan_fk1");
            });

            modelBuilder.Entity<SOfficesType>(entity =>
            {
                entity.ToTable("s_offices_type", "directory");

                entity.HasComment("Справочник типов филиалов/организаций");

                entity.HasIndex(e => e.Id, "s_offices_type_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("type_name")
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<SOfficesZag>(entity =>
            {
                entity.ToTable("s_offices_zags", "directory");

                entity.HasComment("Список отделений ЗАГС");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.IsRemove)
                    .IsRequired()
                    .HasColumnName("is_remove")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .HasColumnName("phone");

                entity.Property(e => e.SOfficesId).HasColumnName("s_offices_id");

                entity.Property(e => e.ZagsCode)
                    .HasMaxLength(8)
                    .HasColumnName("zags_code");

                entity.Property(e => e.ZagsName)
                    .HasMaxLength(500)
                    .HasColumnName("zags_name");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.SOfficesZags)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_offices_zags_s_offices_id_fkey");
            });

            modelBuilder.Entity<SOfficesAcquiring>(entity =>
            {
                entity.ToTable("s_offices_acquiring", "directory");

                entity.HasComment("Терминалы оплаты");

                entity.HasIndex(e => e.Id, "s_offices_acquiring_pkey").IsUnique();

                entity.HasIndex(e => e.Id, "s_offices_acquiring_idx1");

                entity.HasIndex(e => e.SOfficesId, "s_offices_acquiring_idx2");

                entity.HasIndex(e => e.IpAddress, "s_offices_acquiring_idx3");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasDefaultValueSql("directory.uuid_generate_v4()")
                   .HasComment("Первичный ключ");

                entity.Property(e => e.AcquiringName)
                    .HasMaxLength(20)
                    .IsRequired()
                    .HasColumnName("acquiring_name");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(255)
                    .IsRequired()
                    .HasColumnName("ip_address");

                entity.Property(e => e.SOfficesId)
                   .HasColumnName("s_offices_id")
                   .HasComment("Организация");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.SOfficeAcquirings)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_offices_acquiring_fk1");
            });

            modelBuilder.Entity<SOfficesShedule>(entity =>
            {
                entity.ToTable("s_offices_schedule", "directory");

                entity.HasComment("График работы");

                entity.HasIndex(e => e.Id, "s_offices_schedule_pk").IsUnique();

                entity.HasIndex(e => e.SOfficesId, "s_offices_schedule_s_offices_id_idx");

                entity.HasIndex(e => e.SDaysWeekId, "s_offices_schedule_s_weekend_id_idx");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasDefaultValueSql("directory.uuid_generate_v4()")
                   .HasComment("Первичный ключ");

                entity.Property(e => e.SOfficesId)
                   .HasColumnName("s_offices_id")
                   .HasComment("Организация");

                entity.Property(e => e.SDaysWeekId)
                  .HasColumnName("s_days_week_id")
                  .HasComment("Дни нидели");

                entity.Property(e => e.DayType)
                   .HasColumnName("day_type")
                   .HasComment("Тип дня (1-рабочий,2-выходной)");

                entity.Property(e => e.EmployeesFioAdd)
                  .HasMaxLength(70)
                  .HasColumnName("employees_fio_add")
                  .HasComment("ФИО сотрудника добавившего запись");

                entity.Property(e => e.WorkStart)
                   .HasColumnName("work_start")
                   .HasComment("Время начала");

                entity.Property(e => e.WorkStop)
                   .HasColumnName("work_stop")
                   .HasComment("Время окончание");

                entity.Property(e => e.DinnerStart)
                   .HasColumnName("dinner_start")
                   .HasComment("Время начала обеда");

                entity.Property(e => e.DinnerStop)
                   .HasColumnName("dinner_stop")
                   .HasComment("Время окончание обеда");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления записи");

                entity.HasOne(d => d.SOffice)
                    .WithMany(p => p.SOfficesShedules)
                    .HasForeignKey(d => d.SOfficesId)
                    .HasConstraintName("s_offices_schedule_fk");

                entity.HasOne(d => d.SDaysWeek)
                    .WithMany(p => p.SOfficesShedules)
                    .HasForeignKey(d => d.SDaysWeekId)
                    .HasConstraintName("s_offices_schedule_s_days_week_fk");
            });

            modelBuilder.Entity<SRecipientPayment>(entity =>
            {
                entity.ToTable("s_recipient_payment", "directory");

                entity.HasComment("Получатели госпошлин");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasDefaultValueSql("directory.uuid_generate_v4()")
                   .HasComment("Первичный ключ");

                entity.Property(e => e.SOfficesId)
                   .HasColumnName("s_office_id")
                   .HasComment("Организация");

                entity.Property(e => e.SOfficesIdMfc)
                  .HasColumnName("s_offices_id_mfc")
                  .HasComment("МФЦ");

                entity.Property(e => e.OfficeInn)
                    .HasMaxLength(20)
                    .IsRequired()
                    .HasColumnName("office_inn");

                entity.Property(e => e.OfficeBik)
                    .HasMaxLength(20)
                    .IsRequired()
                    .HasColumnName("office_bik");

                entity.Property(e => e.OfficeKpp)
                    .HasMaxLength(20)
                    .IsRequired()
                    .HasColumnName("office_kpp");

                entity.Property(e => e.OfficeOktmo)
                    .HasMaxLength(20)
                    .IsRequired()
                    .HasColumnName("office_oktmo");

                entity.Property(e => e.OfficeRs)
                    .HasMaxLength(30)
                    .IsRequired()
                    .HasColumnName("office_rs");

                entity.Property(e => e.OfficeBankName)
                    .HasMaxLength(100)
                    .IsRequired()
                    .HasColumnName("office_bank_name");

                entity.Property(e => e.OfficeKs)
                    .HasMaxLength(30)
                    .IsRequired()
                    .HasColumnName("office_ks");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(70)
                    .IsRequired()
                    .HasColumnName("purpose");

                entity.Property(e => e.OfficeBeneficiaryName)
                    .IsRequired()
                    .HasColumnName("office_beneficiary_name");

            });

            modelBuilder.Entity<SAutomaticOperation>(entity =>
            {
                entity.ToTable("s_automatic_operation", "services");

                entity.HasComment("Авто операции");

                entity.HasIndex(e => e.Id, "s_automatic_operation_pkey")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "s_automatic_operation_idx1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.OperationName)
                   .IsRequired()
                   .HasMaxLength(70)
                   .HasColumnName("operation_name")
                   .HasComment("Наименование операции");

                //entity.Property(e => e.FunctionName)
                //    .HasMaxLength(70)
                //    .HasColumnName("function_name")
                //    .HasComment("Функция");


                //entity.Property(e => e.SIndicatorsId)
                //    .HasColumnName("s_indicators_id")
                //    .HasComment("Показатель");
            });

            modelBuilder.Entity<SPfrDepartment>(entity =>
            {
                entity.ToTable("s_pfr_department", "smev");

                entity.HasComment("Мнемоники территориальных подразделений Пенсионного фонда ");

                entity.HasIndex(e => e.Id, "s_pfr_department_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("комментарий");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DckNumber)
                    .HasColumnName("dck_number")
                    .HasDefaultValueSql("1")
                    .HasComment("Номер пачки для интеграции с ПФР");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("ФИО сотрудника добавившего запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.Okato)
                    .HasMaxLength(11)
                    .HasColumnName("okato")
                    .HasComment("ОКАТО");

                entity.Property(e => e.Oktmo)
                    .HasMaxLength(11)
                    .HasColumnName("oktmo")
                    .HasComment("ОКТМО");

                entity.Property(e => e.PfrMnemo)
                    .HasMaxLength(10)
                    .HasColumnName("pfr_mnemo")
                    .HasComment("Мнемоника отделения");

                entity.Property(e => e.PfrName)
                    .HasMaxLength(100)
                    .HasColumnName("pfr_name")
                    .HasComment("Наименование отделения");
            });

            modelBuilder.Entity<SPremiumParametr>(entity =>
            {
                entity.ToTable("s_premium_parametrs", "salary");

                entity.HasComment("Таблица параметров к зарплате");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('salary.s_premium_parametrs_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ParametrName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("parametr_name")
                    .HasComment("Наименование параметра");
            });

            modelBuilder.Entity<SPremiumParametrsJobPositionJoin>(entity =>
            {
                entity.ToTable("s_premium_parametrs_job_position_join", "salary");

                entity.HasComment("Таблица параметров зарплаты к должностям");

                entity.HasIndex(e => e.SEmployeesJobPositionId, "s_premium_parametrs_job_positio_s_employees_job_position_id_idx");

                entity.HasIndex(e => e.Id, "s_premium_parametrs_job_position_join_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.ParametrDateStart)
                    .HasColumnName("parametr_date_start")
                    .HasComment("Дата начала действия параметра");

                entity.Property(e => e.ParametrDateStop)
                    .HasColumnName("parametr_date_stop")
                    .HasComment("Дата окончания действия параметра");

                entity.Property(e => e.ParametrValue)
                    .HasPrecision(15, 2)
                    .HasColumnName("parametr_value")
                    .HasComment("Значение параметра");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Связь с должностью");

                entity.Property(e => e.SPremiumParametrsId)
                    .HasColumnName("s_premium_parametrs_id")
                    .HasComment("Связь с параметром к зарплате");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.SPremiumParametrsJobPositionJoins)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_premium_parametrs_job_positi_s_employees_job_position_id_fkey");

                entity.HasOne(d => d.SPremiumParametrs)
                    .WithMany(p => p.SPremiumParametrsJobPositionJoins)
                    .HasForeignKey(d => d.SPremiumParametrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_premium_parametrs_job_position_jo_s_premium_parametrs_id_fkey");
            });

            modelBuilder.Entity<SPremiumService>(entity =>
            {
                entity.ToTable("s_premium_services", "salary");

                entity.HasComment("Справочник продолжительности действий сотрудников в минутах");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SPremiumStepId)
                    .HasColumnName("s_premium_step_id")
                    .HasComment("Связь с действием");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с услугой");

                entity.Property(e => e.StepDateStart)
                    .HasColumnName("step_date_start")
                    .HasComment("Дата начала действия");

                entity.Property(e => e.StepDateStop)
                    .HasColumnName("step_date_stop")
                    .HasComment("Дата окончания дейсвия ");

                entity.Property(e => e.StepDuration)
                    .HasColumnName("step_duration")
                    .HasComment("Продолжительность действия в секундах");

                entity.HasOne(d => d.SPremiumStep)
                    .WithMany(p => p.SPremiumServices)
                    .HasForeignKey(d => d.SPremiumStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_premium_services_sub_s_premium_step_id_fkey");
            });

            modelBuilder.Entity<SPremiumStep>(entity =>
            {
                entity.ToTable("s_premium_step", "salary");

                entity.HasComment("Справочник действий для расчета заработной платы");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("step_name")
                    .HasComment("Наименование активности");
            });

            modelBuilder.Entity<SRatingJobPosition>(entity =>
            {
                entity.ToTable("s_rating_job_position", "reports");

                entity.HasComment("Список должностей учавствующих в рейтинге ");

                entity.HasIndex(e => e.Id, "s_rating_job_position_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SEmployeesJobPositionId, "s_rating_job_position_idx2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.SRatingJobPositions)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_rating_job_position_fk1");
            });

            modelBuilder.Entity<SRole>(entity =>
            {
                entity.ToTable("s_roles", "directory");

                entity.HasComment("Справочник ролей");

                entity.HasIndex(e => e.Id, "s_roles_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("description")
                    .HasComment("Описание");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("role_name")
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<SRolesExecutor>(entity =>
            {
                entity.ToTable("s_roles_executor", "directory");

                entity.HasComment("Роли исполнителей ");

                entity.HasIndex(e => e.Id, "s_roles_executor_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .HasComment("Описание");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Кто добавил запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("role_name")
                    .HasComment("Наименование роли");
            });

            modelBuilder.Entity<SRoutesStage>(entity =>
            {
                entity.ToTable("s_routes_stage", "directory");

                entity.HasComment("Этапы к услугам");

                entity.HasIndex(e => e.Id, "s_routes_stage_id_idx");

                entity.HasIndex(e => e.SServicesStatusId, "s_routes_stage_s_services_status_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DayExcution)
                    .HasColumnName("day_excution")
                    .HasComment("Количество дней на исполнение по умолчанию");

                entity.Property(e => e.SServicesStatusId)
                    .HasColumnName("s_services_status_id")
                    .HasComment("Статус");

                entity.Property(e => e.StageName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("stage_name")
                    .HasComment("Наименование этапа");

                entity.HasOne(d => d.SServicesStatus)
                    .WithMany(p => p.SRoutesStages)
                    .HasForeignKey(d => d.SServicesStatusId)
                    .HasConstraintName("s_routes_stage_s_services_status_id_fkey");
            });

            modelBuilder.Entity<SService>(entity =>
            {
                entity.ToTable("s_services", "directory");

                entity.HasComment("Справочник подуслуг");

                entity.HasIndex(e => e.Id, "s_services_sub_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(1500)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasDefaultValueSql("1")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.Hashtag)
                    .HasMaxLength(255)
                    .HasColumnName("hashtag_")
                    .HasComment("Хэштеги");

                entity.Property(e => e.IasMkgu)
                    .HasColumnName("ias_mkgu")
                    .HasComment("Участие услуги в ИАС МКГУ");

                entity.Property(e => e.IsPlan)
                    .HasColumnName("is_plan")
                    .HasComment("Учитывать в плане");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.IsReportSelect)
                    .HasColumnName("is_report_select")
                    .HasComment("Вывод в отчетах. ");

                entity.Property(e => e.IsTariffEdit)
                    .HasColumnName("is_tariff_edit")
                    .HasComment("Возможность редактирования тарифа");

                entity.Property(e => e.LegalAct)
                    .HasMaxLength(1500)
                    .HasColumnName("legal_act")
                    .HasComment("Реквизиты НПА");

                entity.Property(e => e.ServiceDescription)
                    .HasColumnName("service_description")
                    .HasComment("Описание подуслуги");

                entity.Property(e => e.ServiceMnemo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("service_mnemo")
                    .HasComment("Мнемоника услуги");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(1500)
                    .HasColumnName("service_name")
                    .HasComment("Наименование услуги");

                entity.Property(e => e.ServiceNameSmall)
                    .IsRequired()
                    .HasMaxLength(1500)
                    .HasColumnName("service_name_small")
                    .HasComment("Краткое наименование услуги");

                entity.Property(e => e.ServicePosition)
                    .HasColumnName("service_position")
                    .HasComment("Расположение услуги, 0 - Универсальная, 1- Только как Главная, 2- Только как Подуслуга");

                entity.Property(e => e.SServicesInteractionId)
                   .HasColumnName("s_services_interaction_id")
                   .HasComment("Способ взаимодействия");

                entity.Property(e => e.SServicesTypeId)
                    .HasColumnName("s_services_type_id")
                    .HasComment("Тип услуги");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Организация, поставщик");

                entity.Property(e => e.FrguServiceId)
                   .HasMaxLength(30)
                   .HasColumnName("frgu_service_id")
                   .HasComment("Индетификатор ФРГУ");

                entity.Property(e => e.FrguName)
                   .HasMaxLength(10)
                   .HasColumnName("frgu_name")
                   .HasComment("Наименование ФРГУ");

                entity.Property(e => e.IsIssueAuthority)
                    .HasColumnName("is_issue_authority")
                    .HasComment("Выдача в ОИВ");

                entity.Property(e => e.TimeStorage)
                    .HasColumnName("time_storage")
                    .HasComment("Срок хранения услуги в МФЦ");

                entity.Property(e => e.IsMessage)
                    .HasColumnName("is_message")
                    .HasComment("Отправка СМС заявителю");

                entity.Property(e => e.IsUploadingSite)
                    .HasColumnName("is_uploading_site")
                    .HasComment("Выгрузка для сайта");

                entity.Property(e => e.ServiceNameSite)
                    .HasMaxLength(500)
                    .HasColumnName("service_name_site")
                    .HasComment("Наименование для сайта");

                entity.HasOne(d => d.SServicesInteraction)
                      .WithMany(p => p.SServices)
                      .HasForeignKey(d => d.SServicesInteractionId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("s_services_fk1");

                entity.HasOne(d => d.SServicesType)
                    .WithMany(p => p.SServices)
                    .HasForeignKey(d => d.SServicesTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_fk2");

                entity.HasOne(d => d.SOffice)
                    .WithMany(p => p.SServices)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_fk3");


            });

            modelBuilder.Entity<SServicesActive>(entity =>
            {
                entity.ToTable("s_services_active", "directory");

                entity.HasComment("Справочник активности подуслуг");

                entity.HasIndex(e => e.Id, "s_services_active_id_idx");

                entity.HasIndex(e => e.SServicesId, "s_services_sub_active_s_services_sub_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата завершения");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Cвязь  с подуслугой");

                entity.Property(e => e.SOfficesId)
                   .HasColumnName("s_offices_id")
                   .HasComment("Организация");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesActives)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_active_s_services_sub_id_fkey");

                entity.HasOne(d => d.SOffices)
                    .WithMany(p => p.SServicesActives)
                    .HasForeignKey(d => d.SOfficesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_active_fk2");
            });

            modelBuilder.Entity<SServicesCustomer>(entity =>
            {
                entity.ToTable("s_services_customer", "directory");

                entity.HasComment("Справочник типов заявителей к подуслугам");

                entity.HasIndex(e => e.Id, "s_services_sub_customer_id_idx");

                entity.HasIndex(e => e.SServicesCustomerTypeId, "s_services_sub_customer_s_services_sub_customer_type_id_idx");

                entity.HasIndex(e => e.SServicesId, "s_services_sub_customer_s_services_sub_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.Representative)
                    .HasColumnName("representative")
                    .HasComment("Возможность подачи заявления представителем");

                entity.Property(e => e.RepresentativeDocument)
                    .HasMaxLength(3000)
                    .HasColumnName("representative_document")
                    .HasComment("Документ подтверждающий право представителя");

                entity.Property(e => e.RepresentativeList)
                    .HasMaxLength(5000)
                    .HasColumnName("representative_list")
                    .HasComment("Перечень представителей");

                entity.Property(e => e.RepresentativeSpecification)
                    .HasMaxLength(5000)
                    .HasColumnName("representative_specification")
                    .HasComment("Требование к документу права представителя");

                entity.Property(e => e.SServicesCustomerTypeId)
                    .HasColumnName("s_services_customer_type_id")
                    .HasComment("Связь с типом получателей");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с подуслугой");

                entity.HasOne(d => d.SServicesCustomerType)
                    .WithMany(p => p.SServicesCustomers)
                    .HasForeignKey(d => d.SServicesCustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_customer_s_services_sub_customer_type_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesCustomers)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_customer_s_services_sub_id_fkey");
            });

            modelBuilder.Entity<SServicesCustomerTariff>(entity =>
            {
                entity.ToTable("s_services_customer_tariff", "directory");

                entity.HasComment("Справочник тарифов к подуслугам заявителей");

                entity.HasIndex(e => e.Id, "s_services_customer_tariff_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SServicesCustomerId, "s_services_customer_tariff_idx2");

                entity.HasIndex(e => e.SServicesProcedureId, "s_services_customer_tariff_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(1000)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.CountDayExecution)
                    .HasColumnName("count_day_execution")
                    .HasComment("Количество дней на исполнение в органе власти");

                entity.Property(e => e.CountDayProcessing)
                    .HasColumnName("count_day_processing")
                    .HasComment("Количество дней на обработку");

                entity.Property(e => e.CountDayReturn)
                    .HasColumnName("count_day_return")
                    .HasComment("Количество дней на возврат документов с органа власти");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.SServicesCustomerId)
                    .HasColumnName("s_services_customer_id")
                    .HasComment("Cвязь с получателем услуги");

                entity.Property(e => e.SServicesProcedureId)
                    .HasColumnName("s_services_procedure_id")
                    .HasComment("Процедура");

                entity.Property(e => e.SServicesTariffTypeId)
                    .HasColumnName("s_services_tariff_type_id")
                    .HasComment("Связь с типом тарифа");

                entity.Property(e => e.SServicesWeekId)
                    .HasColumnName("s_services_week_id")
                    .HasComment("Тип отсчета дней");

                entity.Property(e => e.Tariff)
                    .HasPrecision(15, 2)
                    .HasColumnName("tariff_")
                    .HasComment("Тариф государственной пошлины");

                entity.Property(e => e.TariffMfc)
                    .HasPrecision(15, 2)
                    .HasColumnName("tariff_mfc")
                    .HasComment("Тариф для МФЦ");

                entity.HasOne(d => d.SServicesCustomer)
                    .WithMany(p => p.SServicesCustomerTariffs)
                    .HasForeignKey(d => d.SServicesCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_customer_tariff_s_services_sub_customer_id_fkey");

                entity.HasOne(d => d.SServicesTariffType)
                    .WithMany(p => p.SServicesCustomerTariffs)
                    .HasForeignKey(d => d.SServicesTariffTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_customer_tarif_s_services_sub_tariff_type_i_fkey");

                entity.HasOne(d => d.SServicesWeek)
                    .WithMany(p => p.SServicesCustomerTariffs)
                    .HasForeignKey(d => d.SServicesWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_customer_tariff_s_services_sub_week_id_fkey");

                entity.HasOne(d => d.SServicesProcedure)
                  .WithMany(p => p.SServicesCustomerTariffs)
                  .HasForeignKey(d => d.SServicesProcedureId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("s_services_customer_tariff_fk");
            });

            modelBuilder.Entity<SServicesCustomerType>(entity =>
            {
                entity.ToTable("s_services_customer_type", "directory");

                entity.HasComment("Cправочник типов заявителей");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_services_sub_customer_type_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.IdParent)
                    .HasColumnName("id_parent")
                    .HasComment("Cвязь с ролительским id");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("type_name")
                    .HasComment("наименование получателя");
            });

            modelBuilder.Entity<SServicesDocument>(entity =>
            {
                entity.ToTable("s_services_documents", "directory");

                entity.HasComment("Справочник документов заявителей");

                entity.HasIndex(e => e.Id, "s_services_documents_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SDocumentsId, "s_services_documents_idx2");

                entity.HasIndex(e => e.SServicesId, "s_services_documents_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DocumentCount)
                    .HasColumnName("document_count")
                    .HasComment("Количество копий документа");

                entity.Property(e => e.DocumentNeeds)
                    .HasColumnName("document_needs")
                    .HasComment("Необходимость документа. Обязательный - 0, Не обязательный документ - 1, При наличии - 2.");

                entity.Property(e => e.DocumentType)
                    .HasColumnName("document_type")
                    .HasComment("Тип документа. Оригинал - 0, Копия - 1");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SDocumentsId)
                    .HasColumnName("s_documents_id")
                    .HasComment("Связь с документами");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с подуслугой");

                entity.Property(e => e.SServicesProcedureId)
                     .HasColumnName("s_services_procedure_id")
                     .HasComment("Процедура");

                entity.Property(e => e.IsUploadingSite)
                    .HasColumnName("is_uploading_site")
                    .HasComment("Выгрузка для сайта");

                entity.HasOne(d => d.SDocuments)
                    .WithMany(p => p.SServicesDocuments)
                    .HasForeignKey(d => d.SDocumentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_documents_customer_s_documents_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesDocuments)
                    .HasForeignKey(d => d.SServicesId)
                    .HasConstraintName("s_services_sub_documents_s_services_sub_id_fkey");

                entity.HasOne(d => d.SServicesProcedures)
                  .WithMany(p => p.SServicesDocuments)
                  .HasForeignKey(d => d.SServicesProcedureId)
                  .HasConstraintName("s_services_documents_fk");

            });

            modelBuilder.Entity<SServicesDocumentsResult>(entity =>
            {
                entity.ToTable("s_services_documents_result", "directory");

                entity.HasComment("Справочник результатов подуслуги");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.DocumentMethod)
                    .IsRequired()
                    .HasColumnName("document_method")
                    .HasComment("Способы получения документа");

                entity.Property(e => e.DocumentPeriodMfc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("document_period_mfc")
                    .HasComment("Срок хранения в мфц");

                entity.Property(e => e.DocumentPeriodProvider)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("document_period_provider")
                    .HasComment("Срок хранения в органе власти");

                entity.Property(e => e.DocumentResult)
                    .HasColumnName("document_result")
                    .HasComment("Результат положительный или отрицательный");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SDocumentsId)
                    .HasColumnName("s_documents_id")
                    .HasComment("Связь со справочником документов");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь со справочником подуслуг");

                entity.Property(e => e.SServicesProcedureId)
                   .HasColumnName("s_services_procedure_id")
                   .HasComment("Процедура");

                entity.HasOne(d => d.SDocuments)
                    .WithMany(p => p.SServicesDocumentsResults)
                    .HasForeignKey(d => d.SDocumentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_documents_result_s_documents_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesDocumentsResults)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_documents_result_s_services_sub_id_fkey");

                entity.HasOne(d => d.SServicesProcedures)
                 .WithMany(p => p.SServicesDocumentsResults)
                 .HasForeignKey(d => d.SServicesProcedureId)
                 .HasConstraintName("s_services_documents_result_fk");

            });

            modelBuilder.Entity<SServicesFile>(entity =>
            {
                entity.ToTable("s_services_file", "directory");

                entity.HasComment("Справочник файлов и бланков");

                entity.HasIndex(e => e.Id, "s_services_sub_file_id_idx")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "s_services_sub_file_id_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.File)
                    .HasColumnName("file_")
                    .HasComment("Файл");

                entity.Property(e => e.FileExpansion)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("file_expansion")
                    .HasComment("Расширение");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("file_name")
                    .HasComment("Наименование файла");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Услуга");

                entity.Property(e => e.SServicesProcedureId)
                    .HasColumnName("s_services_procedure_id")
                    .HasComment("Процедура");

                entity.Property(e => e.IsDownload)
                    .HasColumnName("is_download")
                    .HasComment("не выгружать");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesFiles)
                    .HasForeignKey(d => d.SServicesId)
                    .HasConstraintName("s_services_file_fk");

                entity.HasOne(d => d.SServicesProcedure)
                    .WithMany(p => p.SServicesFiles)
                    .HasForeignKey(d => d.SServicesProcedureId)
                    .HasConstraintName("s_services_file_fk_1");
            });

            modelBuilder.Entity<SServicesForm>(entity =>
            {
                entity.ToTable("s_services_form", "directory");

                entity.HasComment("Бланки к услуге");

                entity.HasIndex(e => e.Id, "s_services_form_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "s_services_form_idx2")
                    .IsUnique();

                entity.HasIndex(e => e.SServicesId, "s_services_form_pkey");
  
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.File)
                    .HasColumnName("file_")
                    .HasComment("Файл");

                entity.Property(e => e.FileExpansion)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("file_expansion")
                    .HasComment("Расширение");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("file_name")
                    .HasComment("Наименование файла");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasComment("Размер");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Услуга");

                entity.Property(e => e.SServicesProcedureId)
                    .HasColumnName("s_services_procedure_id")
                    .HasComment("Процедура");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesForms)
                    .HasForeignKey(d => d.SServicesId)
                    .HasConstraintName("s_services_form_fk1");

                entity.HasOne(d => d.SServicesProcedure)
                    .WithMany(p => p.SServicesForms)
                    .HasForeignKey(d => d.SServicesProcedureId)
                    .HasConstraintName("s_services_form_fk");
            });



            modelBuilder.Entity<SServicesLivingSituation>(entity =>
            {
                entity.ToTable("s_services_living_situation", "directory");

                entity.HasComment("Справочник услуг по жизненным ситуациям");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SituationName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("situation_name")
                    .HasComment("Наименование ситуации");
            });

            modelBuilder.Entity<SServicesLivingSituationJoin>(entity =>
            {
                entity.ToTable("s_services_living_situation_join", "directory");

                entity.HasComment("Справочник отношений жизненных ситуаций с подуслугам");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с подуслугой");

                entity.Property(e => e.SServicesLivingSituationsId)
                    .HasColumnName("s_services_living_situations_id")
                    .HasComment("Связь с жизненной ситуацией");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesLivingSituationJoins)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_living_situation_join_s_services_sub_id_fkey");

                entity.HasOne(d => d.SServicesLivingSituations)
                    .WithMany(p => p.SServicesLivingSituationJoins)
                    .HasForeignKey(d => d.SServicesLivingSituationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_living_situati_s_services_sub_living_situat_fkey");
            });

            modelBuilder.Entity<SServicesProcedure>(entity =>
            {
                entity.ToTable("s_services_procedure", "directory");

                entity.HasComment("Процедуры к услуге.");

                entity.HasIndex(e => e.Id, "s_services_procedure_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SServicesId, "s_services_procedure_idx2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник");

                entity.Property(e => e.ExtraFormPath)
                    .HasMaxLength(255)
                    .HasColumnName("extra_form_path")
                    .HasComment("Путь к доп форме");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.ProcedureActive)
                    .HasColumnName("procedure_active")
                    .HasComment("Активность");

                entity.Property(e => e.ProcedureName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("procedure_name")
                    .HasComment("Наименование процедуры");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Услуга");

                entity.Property(e => e.FrguTargetId)
                    .HasMaxLength(30)
                    .HasColumnName("frgu_target_id")
                    .HasComment("Индетификатор Цели ФРГУ");

                entity.Property(e => e.IsMdm)
                    .HasColumnName("is_mdm")
                    .HasComment("Отправлять в ИС МДМ или нет");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesProcedures)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_procedure_fk1");
            });

            modelBuilder.Entity<SServicesReason>(entity =>
            {
                entity.ToTable("s_services_reason", "directory");

                entity.HasComment("Справочник оснований для отказа и приостановки по услуге");

                entity.HasIndex(e => e.Id, "s_services_sub_reason_id_idx");

                entity.HasIndex(e => e.SServicesId, "s_services_sub_reason_s_services_sub_id_idx");

                entity.HasIndex(e => e.SServicesWeekId, "s_services_sub_reason_s_services_sub_week_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(1000)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.CountDay)
                    .HasColumnName("count_day")
                    .HasComment("Количество дней приостановки");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.LegalAct)
                    .HasMaxLength(5000)
                    .HasColumnName("legal_act")
                    .HasComment("Нормативно правовой акт");

                entity.Property(e => e.ReasonText)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .HasColumnName("reason_text")
                    .HasComment("Текст");

                entity.Property(e => e.ReasonType)
                    .HasColumnName("reason_type")
                    .HasComment("1 - Отказ в приеме документа. 2 - Отказ в предоставлении подуслуги \r\n3- Приостановка ");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь со спрвочником подуслуг");

                entity.Property(e => e.SServicesWeekId)
                    .HasColumnName("s_services_week_id")
                    .HasComment("Тип расчета дней");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesReasons)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_reason_s_services_sub_id_fkey");

                entity.HasOne(d => d.SServicesWeek)
                    .WithMany(p => p.SServicesReasons)
                    .HasForeignKey(d => d.SServicesWeekId)
                    .HasConstraintName("s_services_sub_reason_s_services_sub_week_id_fkey");
            });

            modelBuilder.Entity<SServicesRoutesStage>(entity =>
            {
                entity.ToTable("s_services_routes_stage", "directory");

                entity.HasComment("Этапы к услуге");

                entity.HasIndex(e => e.Id, "s_services_sub_routes_stage_id_idx");

                entity.HasIndex(e => e.ParentId, "s_services_sub_routes_stage_parent_id_idx");

                entity.HasIndex(e => e.SRoutesStageId, "s_services_sub_routes_stage_s_routes_stage_id_idx");

                entity.HasIndex(e => e.SServicesId, "s_services_sub_routes_stage_s_services_sub_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasDefaultValueSql("directory.uuid_nil()")
                    .HasComment("ID родительской записи");

                entity.Property(e => e.SRoutesStageId)
                    .HasColumnName("s_routes_stage_id")
                    .HasComment("Этап");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Услуга");

                entity.HasOne(d => d.SRoutesStage)
                    .WithMany(p => p.SServicesRoutesStages)
                    .HasForeignKey(d => d.SRoutesStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_routes_stage_s_routes_stage_id_fkey");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesRoutesStages)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_routes_stage_s_services_sub_id_fkey");
            });

            modelBuilder.Entity<SServicesRoutesStageRole>(entity =>
            {
                entity.ToTable("s_services_routes_stage_role", "directory");

                entity.HasComment("Роли исполнителей к услугам");

                entity.HasIndex(e => e.SServicesRoutesStageId, "s_services_sub_routes_stage_role_idx2");

                entity.HasIndex(e => e.SRolesExecutorId, "s_services_sub_routes_stage_role_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.SRolesExecutorId)
                    .HasColumnName("s_roles_executor_id")
                    .HasComment("Роль исполнителя");

                entity.Property(e => e.SServicesRoutesStageId)
                    .HasColumnName("s_services_routes_stage_id")
                    .HasComment("Этап с услугой");

                entity.HasOne(d => d.SRolesExecutor)
                    .WithMany(p => p.SServicesRoutesStageRoles)
                    .HasForeignKey(d => d.SRolesExecutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_routes_stage_role_fk2");

                entity.HasOne(d => d.SServicesRoutesStage)
                    .WithMany(p => p.SServicesRoutesStageRoles)
                    .HasForeignKey(d => d.SServicesRoutesStageId)
                    .HasConstraintName("s_services_sub_routes_stage_role_fk1");
            });

            modelBuilder.Entity<SServicesSmevRequestJoin>(entity =>
            {
                entity.ToTable("s_services_smev_request_join", "directory");

                entity.HasComment("Справочник отношений СМЭВ запроса к услуге");

                entity.HasIndex(e => e.Id, "s_services_sub_smev_request_join_id_idx");

                entity.HasIndex(e => e.SServicesId, "s_services_sub_smev_request_join_s_services_sub_id_idx");

                entity.HasIndex(e => e.SSmevRequestId, "s_services_sub_smev_request_join_s_smev_request_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь с подуслугой");

                entity.Property(e => e.SSmevRequestId)
                    .HasColumnName("s_smev_request_id")
                    .HasComment("Связь с запросом СМЭВ");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesSmevRequestJoins)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_smev_request_join_s_services_sub_id_fkey");

                entity.HasOne(d => d.SSmevRequest)
                    .WithMany(p => p.SServicesSmevRequestJoins)
                    .HasForeignKey(d => d.SSmevRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_smev_request_join_s_smev_request_id_fkey");
            });

            modelBuilder.Entity<SServicesStatus>(entity =>
            {
                entity.ToTable("s_services_status", "directory");

                entity.HasComment("Таблица статусов к услуге");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment(" Первичный ключ");

                entity.Property(e => e.IsDatefact)
                    .HasColumnName("is_datefact")
                    .HasComment("Завершение услуги");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("status_name")
                    .HasComment("Наименование статуса");
            });

            modelBuilder.Entity<SServicesTariffType>(entity =>
            {
                entity.ToTable("s_services_tariff_type", "directory");

                entity.HasComment("Справочник типов тарифов");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.TariffTypeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("tariff_type_name")
                    .HasComment("Наименование типа трифа");
            });

            modelBuilder.Entity<SServicesType>(entity =>
            {
                entity.ToTable("s_services_type", "directory");

                entity.HasComment("Справочник типов услуг");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_services_type_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("type_name")
                    .HasComment("Наименование типа услуги");
            });

            modelBuilder.Entity<SServicesInteraction>(entity =>
            {
                entity.ToTable("s_services_interaction", "directory");

                entity.HasComment("Способы взаимодействия");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.InteractionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("interaction_name")
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<SServicesTypeQuality>(entity =>
            {
                entity.ToTable("s_services_type_quality", "directory");

                entity.HasComment("Способы оценки качества предоставления услуг");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("type_name")
                    .HasComment("Тип оценки качества услуг");
            });

            modelBuilder.Entity<SServicesTypeQualityJoin>(entity =>
            {
                entity.ToTable("s_services_type_quality_join", "directory");

                entity.HasComment("Справочник отношений способов оценки качества услуг к услугам");

                entity.HasIndex(e => e.Id, "s_services_type_quality_join_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SServicesId, "s_services_type_quality_join_idx2");

                entity.HasIndex(e => e.SServicesTypeQualityId, "s_services_type_quality_join_idx3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь со справочником подуслуг");

                entity.Property(e => e.SServicesTypeQualityId)
                    .HasColumnName("s_services_type_quality_id")
                    .HasComment("Связь с типом оценки качества");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesTypeQualityJoins)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_type_quality_join_s_services_sub_id_fkey");

                entity.HasOne(d => d.SServicesTypeQuality)
                    .WithMany(p => p.SServicesTypeQualityJoins)
                    .HasForeignKey(d => d.SServicesTypeQualityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_type_quality_j_s_services_sub_type_quality__fkey");
            });

            modelBuilder.Entity<SServicesWayGet>(entity =>
            {
                entity.ToTable("s_services_way_get", "directory");

                entity.HasComment("Справочник способов получения услуг");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.NameWay)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name_way")
                    .HasComment("Наименование способа");
            });

            modelBuilder.Entity<SServicesWayGetJoin>(entity =>
            {
                entity.ToTable("s_services_way_get_join", "directory");

                entity.HasComment("Справочник получения  к услугам");

                entity.HasIndex(e => e.Id, "s_services_way_get_join_idx1")
                    .IsUnique();

                entity.HasIndex(e => e.SServicesId, "s_services_way_get_join_idx2");

                entity.HasIndex(e => e.WayType, "s_services_way_get_join_idx3");

                entity.HasIndex(e => e.SServicesWayGetId, "s_services_way_get_join_idx4");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата и время добавления записи");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.SServicesId)
                    .HasColumnName("s_services_id")
                    .HasComment("Связь со справочником подуслуг");

                entity.Property(e => e.SServicesWayGetId)
                    .HasColumnName("s_services_way_get_id")
                    .HasComment("Связь со способом получения услуги");

                entity.Property(e => e.WayType)
                    .HasColumnName("way_type")
                    .HasComment("Тип способа. 1 - Способ обращения для получения услуги.\r\n2 - Способ получения результата. ");

                entity.HasOne(d => d.SServices)
                    .WithMany(p => p.SServicesWayGetJoins)
                    .HasForeignKey(d => d.SServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_way_get_join_s_services_sub_id_fkey");

                entity.HasOne(d => d.SServicesWayGet)
                    .WithMany(p => p.SServicesWayGetJoins)
                    .HasForeignKey(d => d.SServicesWayGetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_services_sub_way_get_join_s_services_sub_way_get_id_fkey");
            });

            modelBuilder.Entity<SServicesWeek>(entity =>
            {
                entity.ToTable("s_services_week", "directory");

                entity.HasComment("Таблица типов расчета дней");

                entity.HasIndex(e => e.Id, "s_services_sub_week_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(255)
                    .HasColumnName("type_name")
                    .HasComment("Наименование типа");
            });

            modelBuilder.Entity<SSetting>(entity =>
            {
                entity.ToTable("s_settings", "directory");

                entity.HasComment("Справочник настроек системы");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментраий");

                entity.Property(e => e.ParamName)
                    .HasMaxLength(70)
                    .HasColumnName("param_name")
                    .HasComment("Наименование параметра");

                entity.Property(e => e.ParamValue)
                    .HasMaxLength(255)
                    .HasColumnName("param_value")
                    .HasComment("Значение параметра");
            });

            modelBuilder.Entity<SSmev>(entity =>
            {
                entity.ToTable("s_smev", "smev");

                entity.HasComment("Справочник сервисов СМЭВ (Систе́ма межве́домственного электро́нного взаимоде́йствия)");

                entity.HasIndex(e => e.Id, "s_smev_idx1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.IsSmev3)
                    .HasColumnName("is_smev3")
                    .HasComment("СМЭВ 3 запрос или нет");

                entity.Property(e => e.ProviderCode)
                    .HasMaxLength(30)
                    .HasColumnName("provider_code")
                    .HasComment("Код органа исполнительной власти, используется в запросе");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(100)
                    .HasColumnName("provider_name")
                    .HasComment("Наименование оператора ИС");

                entity.Property(e => e.ProviderUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("provider_url")
                    .HasComment("Адрес сервиса СМЭВ");

                entity.Property(e => e.SmevDescription)
                    .HasColumnName("smev_description")
                    .HasComment("Описание сервиса");

                entity.Property(e => e.SmevMnemo)
                    .HasMaxLength(30)
                    .HasColumnName("smev_mnemo")
                    .HasComment("Сид сервиса");

                entity.Property(e => e.SmevName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("smev_name")
                    .HasComment("Наименование сервиса СМЭВ");

                entity.Property(e => e.SmevProvider)
                    .HasMaxLength(150)
                    .HasColumnName("smev_provider")
                    .HasComment("Наименование организации  владельца ");
            });

            modelBuilder.Entity<SFnsSoun>(entity =>
            {
                entity.ToTable("s_smev_class_fns_soun", "smev");

                entity.HasComment("");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("code")
                    .HasComment("Код налогового органа");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name")
                    .HasComment("Наименование налогового органа");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("address")
                    .HasComment("Адрес налогового органа");
            });

            modelBuilder.Entity<SSmevClassFnsReg>(entity =>
            {
                entity.ToTable("s_smev_class_fns_reg", "smev");

                entity.HasComment("Справочник отделений ФНС (общероссийский классификатор организационно-правовых форм), осуществляющих государственную регистрацию.");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("code")
                    .HasComment("Код налогового органа или его территориального участка (подразделения), осуществляющего регистрацию");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("name")
                    .HasComment("Сокращенное наименование РО");
            });

            modelBuilder.Entity<SSmevClassOkopf>(entity =>
            {
                entity.ToTable("s_smev_class_okopf", "smev");

                entity.HasComment("Справочник ОКОПФ (Общероссийский классификатор организационно-правовых форм)");

                entity.HasIndex(e => e.Code, "spr_smev_class_okopf_idx");

                entity.HasIndex(e => e.ParentId, "spr_smev_class_okopf_parent_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("code")
                    .HasComment("Код элемента справочника");

                entity.Property(e => e.Description)
                    .HasMaxLength(5000)
                    .HasColumnName("description")
                    .HasComment("Описание элемента справочника");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasComment("Наименование элемента справочника");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasComment("ID родительской записи");
            });

            modelBuilder.Entity<SSmevClassOkpd>(entity =>
            {
                entity.ToTable("s_smev_class_okpd", "smev");

                entity.HasComment("Справочник ОКПД (Общероссийский классификатор продукции по видам экономической деятельности)");

                entity.HasIndex(e => e.Code, "spr_smev_class_okpd2_idx");

                entity.HasIndex(e => e.ParentId, "spr_smev_class_okpd2_parent_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("code")
                    .HasComment("Код элемента справочника");

                entity.Property(e => e.Description)
                    .HasMaxLength(5000)
                    .HasColumnName("description")
                    .HasComment("Описание элемента справочника");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasComment("Наименование элемента справочника");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasComment("ID родительской записи");
            });

            modelBuilder.Entity<SSmevClassOkved>(entity =>
            {
                entity.ToTable("s_smev_class_okved", "smev");

                entity.HasComment("Справочник ОКВЭД-2 (Общероссийский Классификатор Видов Экономической Деятельности)");

                entity.HasIndex(e => e.Code, "spr_smev_class_okved2_idx");

                entity.HasIndex(e => e.ParentId, "spr_smev_class_okved2_parent_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("code")
                    .HasComment("Код элемента справочника");

                entity.Property(e => e.Description)
                    .HasMaxLength(10000)
                    .HasColumnName("description")
                    .HasComment("Описание элемента справочника");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasComment("Наименование элемента справочника");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasComment("ID родительской записи");
            });

            modelBuilder.Entity<SSmevClassOszn>(entity =>
            {
                entity.ToTable("s_smev_class_oszn", "smev");

                entity.HasComment("Справочник осзн для минтруда");

                entity.HasIndex(e => e.Id, "s_smev_class_oszn_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.OsznAddress)
                    .HasMaxLength(255)
                    .HasColumnName("oszn_address")
                    .HasComment("Адрес ОСЗН");

                entity.Property(e => e.OsznCode)
                    .HasColumnName("oszn_code")
                    .HasComment("Код осзн");

                entity.Property(e => e.OsznName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("oszn_name")
                    .HasComment("Наименование ОСЗН");

                entity.Property(e => e.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("service_code")
                    .HasComment("Идентификатор цели услуги");
            });

            modelBuilder.Entity<SSmevClassUik>(entity =>
            {
                entity.ToTable("s_smev_class_uik", "smev");

                entity.HasComment("Справочник избирательных участков для СМЭВ (Система межведомственного электронного взаимодействия)");

                entity.HasIndex(e => e.CountryCode, "spr_smev_class_uik_idx1");

                entity.HasIndex(e => e.RegionCode, "spr_smev_class_uik_idx2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .HasColumnName("address")
                    .HasComment("Адрес избирательного участка");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(10)
                    .HasColumnName("country_code")
                    .HasComment("Код страны избирательного участка");

                entity.Property(e => e.Phone)
                    .HasMaxLength(120)
                    .HasColumnName("phone")
                    .HasComment("Телефон избирательного участка");

                entity.Property(e => e.RegionCode)
                    .HasMaxLength(10)
                    .HasColumnName("region_code")
                    .HasComment("Код региона избирательного участка");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(100)
                    .HasColumnName("region_name")
                    .HasComment("Наименование региона избирательного участка");

                entity.Property(e => e.UikNumber)
                    .HasMaxLength(10)
                    .HasColumnName("uik_number")
                    .HasComment("Код избирательного участка");
            });

            modelBuilder.Entity<SSmevClassZag>(entity =>
            {
                entity.ToTable("s_smev_class_zags", "smev");

                entity.HasComment("Справочники для ЗАГС");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasComment("Адрес фактического расположения");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .HasColumnName("code")
                    .HasComment("Код органа ЗАГС");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Наименование органа ЗАГС");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .HasColumnName("phone")
                    .HasComment("Контактный телефон справочной службы");
            });

            modelBuilder.Entity<SBanks>(entity =>
            {
                entity.ToTable("s_banks", "smev");

                entity.HasComment("Справочники банков");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Наименование банка");

                entity.Property(e => e.Bik)
                    .HasMaxLength(9)
                    .HasColumnName("bik")
                    .HasComment("БИК");

                entity.Property(e => e.Inn)
                    .HasMaxLength(10)
                    .HasColumnName("inn")
                    .HasComment("ИНН");
            });

            modelBuilder.Entity<SSmevRequest>(entity =>
            {
                entity.ToTable("s_smev_request", "smev");

                entity.HasComment("Справочник запросов к сервисам СМЭВ (Систе́ма межве́домственного электро́нного взаимоде́йствия)");

                entity.HasIndex(e => e.Id, "s_smev_request_idx2")
                    .IsUnique();

                entity.HasIndex(e => e.SServicesWeekId, "s_smev_request_s_services_sub_week_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.ActionPath)
                    .HasColumnType("character varying")
                    .HasColumnName("action_path")
                    .HasComment("Путь к методу");

                entity.Property(e => e.CountDayExecution)
                    .HasColumnName("count_day_execution")
                    .HasComment("Количество дней на выполнение запроса");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления записи");

                entity.Property(e => e.IsRequestActive)
                    .IsRequired()
                    .HasColumnName("is_request_active")
                    .HasDefaultValueSql("true")
                    .HasComment("Активность запроса");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path")
                    .HasComment("Путь к сервису");

                entity.Property(e => e.RequestName)
                    .IsRequired()
                    .HasMaxLength(350)
                    .HasColumnName("request_name")
                    .HasComment("Наименование запроса");

                entity.Property(e => e.SServicesWeekId)
                    .HasColumnName("s_services_week_id")
                    .HasComment("Тип отсчета дней");

                entity.Property(e => e.SSmevId)
                    .HasColumnName("s_smev_id")
                    .HasComment("Сервис СМЭВ");

                entity.Property(e => e.SSmevTypeRequestId)
                    .HasColumnName("s_smev_type_request_id")
                    .HasComment("Связь с типом запроса СМЭВ");

                entity.Property(e => e.ServiceOrFunctionCode)
                    .HasMaxLength(20)
                    .HasColumnName("service_or_function_code")
                    .HasComment("Реестровый номер услуги. При наличии  - цель оказания государственной услуги. Из справочника Услуги ЕПГУ / ФРГУ. Заполняется в блоке атрибутов бизнес процесса СМЭВ 3.");

                entity.HasOne(d => d.SServicesWeek)
                    .WithMany(p => p.SSmevRequests)
                    .HasForeignKey(d => d.SServicesWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_smev_request_s_services_sub_week_id_fkey");

                entity.HasOne(d => d.SSmev)
                    .WithMany(p => p.SSmevRequests)
                    .HasForeignKey(d => d.SSmevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_smev_request_s_smev_id_fkey");

                entity.HasOne(d => d.SSmevTypeRequest)
                    .WithMany(p => p.SSmevRequests)
                    .HasForeignKey(d => d.SSmevTypeRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_smev_request_s_smev_type_request_id_fkey");
            });

            modelBuilder.Entity<SSmevSystemAccess>(entity =>
            {
                entity.ToTable("s_smev_system_access", "smev");

                entity.HasComment("Cправочник систем СМЭВ 3 для доступа к эмулятору СМЭВ 3 на сервисе");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Certificate)
                    .HasColumnName("certificate")
                    .HasComment("Открытая часть сертификата");

                entity.Property(e => e.ProductionAccess)
                    .HasColumnName("production_access")
                    .HasComment("Разрешить продуктивный доступ");

                entity.Property(e => e.SmevMnemonic)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("smev_mnemonic")
                    .HasComment("Мнемоника системы");

                entity.Property(e => e.SmevName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("smev_name")
                    .HasComment("Наименовение системы");

                entity.Property(e => e.TestAccess)
                    .HasColumnName("test_access")
                    .HasComment("Разрешить тестовый доступ");
            });

            modelBuilder.Entity<SSmevTypeRequest>(entity =>
            {
                entity.ToTable("s_smev_type_request", "smev");

                entity.HasComment("Справочник типов запросов СМЭВ (Систе́ма межве́домственного электро́нного взаимоде́йствия)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('directory.s_smev_type_request_seq'::regclass)")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.Commentt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("type_name")
                    .HasComment("Наименование типа СМЭВ");
            });

            modelBuilder.Entity<SStateTask>(entity =>
            {
                entity.ToTable("s_state_task", "directory");

                entity.HasComment("Госзадание");

                entity.HasIndex(e => e.Id, "d_state_task_pkey").IsUnique();

                entity.HasIndex(e => e.YearTask, "s_state_task_idx1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.CountService)
                    .HasColumnName("count_service")
                    .HasComment("Количество услуг");

                entity.Property(e => e.YearTask)
                    .HasColumnName("year_task")
                    .HasComment("Год");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Кто добавил");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления");
            });

            modelBuilder.Entity<SWarning>(entity =>
            {
                entity.ToTable("s_warnings", "directory");

                entity.HasComment("Уведомления сотрудникам");

                entity.HasIndex(e => e.Id, "s_warnings_idx1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AlertName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("alert_name")
                    .HasComment("Текст уведомления");

                entity.Property(e => e.Commentt)
                    .HasMaxLength(255)
                    .HasColumnName("commentt")
                    .HasComment("Комментарий к записи");
            });

            modelBuilder.Entity<SDaysWeek>(entity =>
            {
                entity.ToTable("s_days_week", "directory");

                entity.HasComment("Дни недели");

                entity.HasIndex(e => e.Id, "s_weekend_pk").IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("day_name")
                    .HasComment("Наименование");

                entity.Property(e => e.DaySmallName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("day_small_name")
                    .HasComment("Краткое название");
            });

            modelBuilder.Entity<STestDirection>(entity =>
            {
                entity.ToTable("s_test_direction", "directory");

                entity.HasComment("Направление к тесту");

                entity.HasIndex(e => e.Id, "s_test_direction_pk").IsUnique();
                entity.HasIndex(e => e.IsRemove, "s_test_direction_is_remove_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DirectionName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("direction_name")
                    .HasComment("Кто добавил");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления записи");
            });

            modelBuilder.Entity<STestQuestion>(entity =>
            {
                entity.ToTable("s_test_question", "directory");

                entity.HasComment("Вопросы к тесту");

                entity.HasIndex(e => e.Id, "s_test_question_pk").IsUnique();
                entity.HasIndex(e => e.IsActive, "s_test_question_is_active_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.QuestionName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("question_name")
                    .HasComment("Вопрос");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasComment("Активность");

                entity.Property(e => e.QuestionType)
                    .HasColumnName("question_type")
                    .HasComment("1,2. Один ответ или несколько");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления записи");
            });

            modelBuilder.Entity<STestDirectionQuestion>(entity =>
            {
                entity.ToTable("s_test_direction_question", "directory");

                entity.HasComment("Направление и вопросы");

                entity.HasIndex(e => e.Id, "s_test_question_pk").IsUnique();
                entity.HasIndex(e => e.STestDirectionId, "s_test_direction_question_s_test_direction_id_idx");
                entity.HasIndex(e => e.STestQuestionId, "s_test_direction_question_s_test_question_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.STestQuestionId)
                    .HasColumnName("s_test_question_id")
                    .HasComment("Вопросы");

                entity.Property(e => e.STestDirectionId)
                    .HasColumnName("s_test_direction_id")
                    .HasComment("Направление");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления записи");

                entity.HasOne(d => d.STestQuestion)
                    .WithMany(p => p.STestDirectionQuestions)
                    .HasForeignKey(d => d.STestQuestionId)
                    .HasConstraintName("s_test_direction_question_fk_1");

                entity.HasOne(d => d.STestDirection)
                   .WithMany(p => p.STestDirectionQuestions)
                   .HasForeignKey(d => d.STestDirectionId)
                   .HasConstraintName("s_test_direction_question_fk");
            });

            modelBuilder.Entity<STestAnswer>(entity =>
            {
                entity.ToTable("s_test_answers", "directory");

                entity.HasComment("Ответы к тесту");

                entity.HasIndex(e => e.Id, "s_test_answers_pk").IsUnique();
                entity.HasIndex(e => e.IsRemove, "s_test_answers_is_remove_idx");
                entity.HasIndex(e => e.STestQuestionId, "s_test_answers_s_test_question_id_idx");


                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AnswerName)
                     .IsRequired()
                     .HasMaxLength(500)
                     .HasColumnName("answer_name")
                     .HasComment("Ответ");

                entity.Property(e => e.IsRight)
                     .HasColumnName("is_right")
                     .HasComment("Правильность");

                entity.Property(e => e.STestQuestionId)
                    .HasColumnName("s_test_question_id")
                    .HasComment("Вопрос");

                entity.Property(e => e.IsRemove)
                    .HasColumnName("is_remove")
                    .HasComment("Признак удаления");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления записи");

                entity.HasOne(d => d.STestQuestion)
                    .WithMany(p => p.STestAnswers)
                    .HasForeignKey(d => d.STestQuestionId)
                    .HasConstraintName("s_test_answers_fk");
            });

            modelBuilder.Entity<STestDirectionJob>(entity =>
            {
                entity.ToTable("s_test_direction_job", "directory");

                entity.HasComment("Направление и должности");

                entity.HasIndex(e => e.Id, "s_test_direction_job").IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность сотрудника");

                entity.Property(e => e.STestDirectionId)
                    .HasColumnName("s_test_direction_id")
                    .HasComment("Направление");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления записи");

                entity.HasOne(d => d.STestDirection)
                   .WithMany(p => p.STestDirectionJobs)
                   .HasForeignKey(d => d.STestDirectionId)
                   .HasConstraintName("s_test_direction_job_fk");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.STestDirectionJobs)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .HasConstraintName("s_test_direction_job_fk_1");
            });

            modelBuilder.Entity<DTest>(entity =>
            {
                entity.ToTable("d_test", "directory");

                entity.HasComment("Тест");

                entity.HasIndex(e => e.Id, "d_test_pk").IsUnique();
                entity.HasIndex(e => e.Id, "d_test_is_active_idx");
                entity.HasIndex(e => e.Id, "d_test_test_number_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("test_name")
                    .HasComment("Наименование");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasComment("Активность");

                entity.Property(e => e.CountQuestions)
                    .HasColumnName("count_questions")
                    .HasComment("Количество вопросов");

                entity.Property(e => e.TestNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("test_number")
                    .HasComment("Номер");

                entity.Property(e => e.TestTime)
                    .HasColumnName("test_time")
                    .HasComment("Время на тест(в минутах)");

                entity.Property(e => e.DateStartTest)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_start_test")
                    .HasComment("Дата и время начала теста");

                entity.Property(e => e.EmployeesFioAdd)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("employees_fio_add")
                    .HasComment("Сотрудник добавивший запись");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_add")
                    .HasComment("Дата и время добавления записи");
            });


            modelBuilder.Entity<DTestDirection>(entity =>
            {
                entity.ToTable("d_test_directions", "directory");

                entity.HasComment("Направления к тесту");

                entity.HasIndex(e => e.Id, "d_directions_test_pk").IsUnique();
                entity.HasIndex(e => e.DTestId, "d_test_directions_d_test_id_idx");
                entity.HasIndex(e => e.STestDirectionId, "d_test_directions_s_test_direction_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.DTestId)
                    .HasColumnName("d_test_id")
                    .HasComment("Тест");

                entity.Property(e => e.STestDirectionId)
                    .HasColumnName("s_test_direction_id")
                    .HasComment("Направления");

                entity.HasOne(d => d.DTest)
                    .WithMany(p => p.DTestDirections)
                    .HasForeignKey(d => d.DTestId)
                    .HasConstraintName("d_directions_test_fk");

                entity.HasOne(d => d.STestDirection)
                    .WithMany(p => p.DTestDirections)
                    .HasForeignKey(d => d.STestDirectionId)
                    .HasConstraintName("d_directions_test_fk_1");
            });

            modelBuilder.Entity<DTestEmployee>(entity =>
            {
                entity.ToTable("d_test_employees", "directory");

                entity.HasComment("Сотрудники к тесту");

                entity.HasIndex(e => e.Id, "d_test_employees_pk").IsUnique();
                entity.HasIndex(e => e.DTestId, "d_test_employees_d_test_id_idx");
                entity.HasIndex(e => e.SEmployeesId, "d_test_employees_s_employees_id_idx");
                entity.HasIndex(e => e.SOfficesId, "d_test_employees_s_offices_id_idx");
                entity.HasIndex(e => e.SEmployeesJobPositionId, "d_test_employees_s_employees_job_position_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.EmployeesName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("employees_name")
                    .HasComment("ФИО сотрудника");

                entity.Property(e => e.OfficesName)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("offices_name")
                   .HasComment("Наименование офиса");

                entity.Property(e => e.JobPositionsName)
                   .IsRequired()
                   .HasMaxLength(70)
                   .HasColumnName("job_positions_name")
                   .HasComment("Должность");

                entity.Property(e => e.DTestId)
                    .HasColumnName("d_test_id")
                    .HasComment("Тест");

                entity.Property(e => e.SEmployeesId)
                    .HasColumnName("s_employees_id")
                    .HasComment("Сотрудники");

                entity.Property(e => e.SOfficesId)
                    .HasColumnName("s_offices_id")
                    .HasComment("Офис (МФЦ)");

                entity.Property(e => e.SEmployeesJobPositionId)
                    .HasColumnName("s_employees_job_position_id")
                    .HasComment("Должность");

                entity.Property(e => e.NumberQuestionsAnswered)
                    .HasColumnName("number_questions_answered")
                    .HasComment("Количество отвечаных вопров ");

                entity.Property(e => e.NumberCorrectQuestions)
                    .HasColumnName("number_correct_questions")
                    .HasComment("Количество правильных ответов");

                entity.Property(e => e.NumberIncorrectQuestions)
                    .HasColumnName("number_incorrect_questions")
                    .HasComment("Количествот не правильных вопросов");

                entity.Property(e => e.PercentResult)
                    .HasColumnName("percent_result")
                    .HasComment("Процент результат");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasComment("Дата начала теста");

                entity.Property(e => e.DateStop)
                    .HasColumnName("date_stop")
                    .HasComment("Дата окончание теста");

                entity.Property(e => e.TestTime)
                    .HasColumnName("test_time")
                    .HasComment("Остаточное время");

                entity.HasOne(d => d.DTest)
                    .WithMany(p => p.DTestEmployees)
                    .HasForeignKey(d => d.DTestId)
                    .HasConstraintName("d_test_employees_fk");

                entity.HasOne(d => d.SEmployee)
                    .WithMany(p => p.DTestEmployees)
                    .HasForeignKey(d => d.SEmployeesId)
                    .HasConstraintName("d_test_employees_fk_2");
                
                entity.HasOne(d => d.SOffice)
                    .WithMany(p => p.DTestEmployees)
                    .HasForeignKey(d => d.SOfficesId)
                    .HasConstraintName("d_test_employees_fk_3");

                entity.HasOne(d => d.SEmployeesJobPosition)
                    .WithMany(p => p.DTestEmployees)
                    .HasForeignKey(d => d.SEmployeesJobPositionId)
                    .HasConstraintName("d_test_employees_fk_4");
            });

            modelBuilder.Entity<DTestQuestionsEmployee>(entity =>
            {
                entity.ToTable("d_test_questions_employees", "directory");

                entity.HasComment("Вопросы к сотруднику");

                entity.HasIndex(e => e.Id, "d_test_questions_employees_pk").IsUnique();
                entity.HasIndex(e => e.DTestEmployeesId, "d_test_questions_employees_d_test_employees_id_idx");
                entity.HasIndex(e => e.STestQuestionId, "d_test_questions_employees_s_test_question_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.QuestionName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("question_name")
                    .HasComment("Вопрос");

                entity.Property(e => e.DTestEmployeesId)
                    .HasColumnName("d_test_employees_id")
                    .HasComment("Вопросы к сотруднику");

                entity.Property(e => e.STestQuestionId)
                    .HasColumnName("s_test_question_id")
                    .HasComment("Вопрос");

                entity.HasOne(d => d.DTestEmployee)
                    .WithMany(p => p.DTestQuestionsEmployees)
                    .HasForeignKey(d => d.DTestEmployeesId)
                    .HasConstraintName("d_test_questions_employees_fk_1");

                entity.HasOne(d => d.STestQuestion)
                    .WithMany(p => p.DTestQuestionsEmployees)
                    .HasForeignKey(d => d.STestQuestionId)
                    .HasConstraintName("d_test_questions_employees_fk");
            });

            modelBuilder.Entity<DTestAnswerEmployee>(entity =>
            {
                entity.ToTable("d_test_answers_employees", "directory");

                entity.HasComment("Ответы сотрудника");

                entity.HasIndex(e => e.Id, "d_test_answers_pk").IsUnique();
                entity.HasIndex(e => e.STestAnswersId, "d_test_answers_s_test_answers_id_idx");
                entity.HasIndex(e => e.DTestQuestionsEmployeesId, "d_test_answers_d_test_questions_employees_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("directory.uuid_generate_v4()")
                    .HasComment("Первичный ключ");

                entity.Property(e => e.AnswerName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("answers_name")
                    .HasComment("Наименование ответа");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ip_address")
                    .HasComment("IP Адрес");

                entity.Property(e => e.STestAnswersId)
                    .HasColumnName("s_test_answers_id")
                    .HasComment("Ответы Справочника");

                entity.Property(e => e.DTestQuestionsEmployeesId)
                    .HasColumnName("d_test_questions_employees_id")
                    .HasComment("Вопросы к сотрудником");

                entity.Property(e => e.IsTruth)
                    .HasColumnName("is_truth")
                    .HasComment("Правильность");

                entity.Property(e => e.IsResponseEmployees)
                    .HasColumnName("is_response_employees")
                    .HasComment("Правильность");

                entity.Property(e => e.DateTimeAnswer)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("date_time_answer")
                    .HasComment("Дата и время ответа");

                entity.HasOne(d => d.STestAnswer)
                    .WithMany(p => p.DTestAnswerEmployees)
                    .HasForeignKey(d => d.STestAnswersId)
                    .HasConstraintName("d_test_answers_fk");

                entity.HasOne(d => d.DTestQuestionsEmployee)
                    .WithMany(p => p.DTestAnswerEmployees)
                    .HasForeignKey(d => d.DTestQuestionsEmployeesId)
                    .HasConstraintName("d_test_answers_fk_1");
            });

            modelBuilder.HasSequence("d_cik_seq_id", "directory");

            modelBuilder.HasSequence("d_elk_order_seq_id", "core").IsCyclic();

            modelBuilder.HasSequence("d_fssp_doc_seq_id", "directory");

            modelBuilder.HasSequence("d_gibdd_fism_seq_id", "directory");

            modelBuilder.HasSequence("d_ias_mkgu_upload_infomat_user_id_seq", "core").IsCyclic();

            modelBuilder.HasSequence("d_mdm_objects_attributes_upload_id_seq", "core").IsCyclic();

            modelBuilder.HasSequence("d_mdm_objects_attributes_upload_seq", "services").IsCyclic();

            modelBuilder.HasSequence("d_msp_corp_seq_id", "directory");

            modelBuilder.HasSequence("d_mvd_ais_opv_seq_daily", "directory");

            modelBuilder.HasSequence("d_offices_pfr_fri_order_seq_id", "directory");

            modelBuilder.HasSequence("d_offices_pfr_order_seq_id", "directory");

            modelBuilder.HasSequence("d_ppo_territoria_seq_id", "directory");

            modelBuilder.HasSequence("d_sovm_passport_rf_seq_id", "directory");

            modelBuilder.HasSequence("d_test_seq", "core")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_calendar_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_document_code", "directory");

            modelBuilder.HasSequence("s_documents_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_documents_smev_request_join_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_employees_active_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_employees_authorization_log_seq", "directory")
                .HasMax(999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_employees_execution_seq", "directory")
                .HasMax(99999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_employees_file_folder_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_employees_file_seq", "directory")
                .HasMax(9999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_employees_job_position_fine_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_employees_job_position_salary_seq", "directory");

            modelBuilder.HasSequence("s_employees_job_position_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_employees_office_join_seq", "directory")
                .HasMax(999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_employees_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_employees_status_join_seq", "directory")
                .HasMax(99999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_employees_status_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_employees_template_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_employees_working_time_join_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_employees_working_time_seq", "directory")
                .HasMax(99999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_forms_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_ftp_join_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_ftp_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_group_parametrs_join_seq", "directory")
                .HasMax(9999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_group_parametrs_seq", "directory")
                .HasMax(999999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_hashtag_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_minobr_camp_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_office_provider_join_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_office_queue_join_seq", "directory")
                .HasMax(9999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_office_remote_workplace_seq", "directory")
                .HasMax(999999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_office_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_parametrs_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_premium_parametrs_seq", "salary").IsCyclic();

            modelBuilder.HasSequence("s_provider_customer_payment_seq", "directory")
                .HasMax(9999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_provider_department_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_provider_seq", "directory")
                .HasMax(99999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_forms_seq", "directory")
                .HasMax(9999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_seq", "directory")
                .HasMax(999999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_active_seq", "directory")
                .HasMax(99999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_commercial_seq", "directory")
                .HasMax(9999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_customer_seq", "directory")
                .HasMax(999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_customer_type_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_documents_customer_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_failure_doc_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_failure_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_file_folder_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_file_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_group_parametrs_join_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_hashtag_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_living_situation_join_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_living_situation_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_premium_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_result_documents_seq", "directory")
                .HasMax(99999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_smev_request_join_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_stop_seq", "directory")
                .HasMax(999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_tariff_seq", "directory")
                .HasMax(999999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_type_quality_join_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_type_quality_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_way_get_join_seq", "directory")
                .HasMax(999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_services_sub_way_get_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_sub_week_seq", "directory").IsCyclic();

            modelBuilder.HasSequence("s_services_type_seq", "directory")
                .HasMax(999999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_smev_class_fms_seq", "directory")
                .HasMax(999999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_smev_request_seq", "directory")
                .HasMax(9999999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_smev_seq", "smev").IsCyclic();

            modelBuilder.HasSequence("s_smev_type_request_seq", "directory")
                .HasMax(99999999999999)
                .IsCyclic();

            modelBuilder.HasSequence("s_standarts_files_seq", "directory");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
