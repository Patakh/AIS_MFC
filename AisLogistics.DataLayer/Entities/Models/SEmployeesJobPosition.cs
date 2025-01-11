using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник должностей
    /// </summary>
    public partial class SEmployeesJobPosition
    {
        public SEmployeesJobPosition()
        {
            APremia = new HashSet<APremium>();
            APremiumFines = new HashSet<APremiumFine>();
            APremiumSteps = new HashSet<APremiumStep>();
            AServiceSEmployeesJobPositionIdAddNavigations = new HashSet<AService>();
            AServiceSEmployeesJobPositionIdExecutionNavigations = new HashSet<AService>();
            AServicesCommentts = new HashSet<AServicesCommentt>();
            AServicesCustomerCalls = new HashSet<AServicesCustomersCall>();
            AServicesCustomerMessages = new HashSet<AServicesCustomersMessage>();
            AServicesCustomers = new HashSet<AServicesCustomer>();
            AServicesCustomersLegals = new HashSet<AServicesCustomersLegal>();
            AServicesFileResults = new HashSet<AServicesFileResult>();
            AServicesFiles = new HashSet<AServicesFile>();
            AServicesRoutesStageSEmployeesJobPositionIdAddNavigations = new HashSet<AServicesRoutesStage>();
            AServicesRoutesStageSEmployeesJobPositions = new HashSet<AServicesRoutesStage>();
            AServicesSmevRequests = new HashSet<AServicesSmevRequest>();
            DIasMkguInfomatUploads = new HashSet<DIasMkguInfomatUpload>();
            DIncomingCalls = new HashSet<DIncomingCall>();
            DPremiumFines = new HashSet<DPremiumFine>();
            DPremiumSteps = new HashSet<DPremiumStep>();
            DRatingInitialValues = new HashSet<DRatingInitialValue>();
            DServiceSEmployeesJobPositionIdAddNavigations = new HashSet<DService>();
            DServiceSEmployeesJobPositionIdExecutionNavigations = new HashSet<DService>();
            DServiceSEmployeesJobPositionIdCurrentNavigations = new HashSet<DService>();    
            DServicesAudits = new HashSet<DServicesAudit>();
            AServicesAudits = new HashSet<AServicesAudit>();
            DServicesCommentts = new HashSet<DServicesCommentt>();
            DServicesCustomerCalls = new HashSet<DServicesCustomersCall>();
            DServicesCustomerMessages = new HashSet<DServicesCustomersMessage>();
            DServicesCustomers = new HashSet<DServicesCustomer>();
            DServicesCustomersLegals = new HashSet<DServicesCustomersLegal>();
            DServicesFileResults = new HashSet<DServicesFileResult>();
            DServicesFiles = new HashSet<DServicesFile>();
            DServicesRoutesStageSEmployeesJobPositionIdAddNavigations = new HashSet<DServicesRoutesStage>();
            DServicesRoutesStageSEmployeesJobPositions = new HashSet<DServicesRoutesStage>();
            DServicesSmevRequests = new HashSet<DServicesSmevRequest>();
            SEmployeesCombinationJobs = new HashSet<SEmployeesCombinationJob>();
            SEmployeesJobPositionFines = new HashSet<SEmployeesJobPositionFine>();
            SEmployeesOfficesJoins = new HashSet<SEmployeesOfficesJoin>();
            SPremiumParametrsJobPositionJoins = new HashSet<SPremiumParametrsJobPositionJoin>();
            SRatingJobPositions = new HashSet<SRatingJobPosition>();
            STestDirectionJobs = new HashSet<STestDirectionJob>();
            DTestEmployees = new HashSet<DTestEmployee>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование должности
        /// </summary>
        public string JobPositionName { get; set; }
        /// <summary>
        /// Дата редактирования должности
        /// </summary>
        public DateTime EditDate { get; set; }
        /// <summary>
        /// Сотрудник редактировавший должность
        /// </summary>
        public string EditEmployeesFio { get; set; }
        /// <summary>
        /// Поле для сортировки в отчетах по зарплате
        /// </summary>
        public int? Sorting { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual ICollection<APremium> APremia { get; set; }
        public virtual ICollection<APremiumFine> APremiumFines { get; set; }
        public virtual ICollection<APremiumStep> APremiumSteps { get; set; }
        public virtual ICollection<AService> AServiceSEmployeesJobPositionIdAddNavigations { get; set; }
        public virtual ICollection<AService> AServiceSEmployeesJobPositionIdExecutionNavigations { get; set; }
        public virtual ICollection<AServicesCommentt> AServicesCommentts { get; set; }
        public virtual ICollection<AServicesCustomersCall> AServicesCustomerCalls { get; set; }
        public virtual ICollection<AServicesCustomersMessage> AServicesCustomerMessages { get; set; }
        public virtual ICollection<AServicesCustomer> AServicesCustomers { get; set; }
        public virtual ICollection<AServicesCustomersLegal> AServicesCustomersLegals { get; set; }
        public virtual ICollection<AServicesFileResult> AServicesFileResults { get; set; }
        public virtual ICollection<AServicesFile> AServicesFiles { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStageSEmployeesJobPositionIdAddNavigations { get; set; }
        public virtual ICollection<AServicesRoutesStage> AServicesRoutesStageSEmployeesJobPositions { get; set; }
        public virtual ICollection<AServicesSmevRequest> AServicesSmevRequests { get; set; }
        public virtual ICollection<DIasMkguInfomatUpload> DIasMkguInfomatUploads { get; set; }
        public virtual ICollection<DIncomingCall> DIncomingCalls { get; set; }
        public virtual ICollection<DPremiumFine> DPremiumFines { get; set; }
        public virtual ICollection<DPremiumStep> DPremiumSteps { get; set; }
        public virtual ICollection<DRatingInitialValue> DRatingInitialValues { get; set; }
        public virtual ICollection<DService> DServiceSEmployeesJobPositionIdAddNavigations { get; set; }
        public virtual ICollection<DService> DServiceSEmployeesJobPositionIdExecutionNavigations { get; set; }
        public virtual ICollection<DService> DServiceSEmployeesJobPositionIdCurrentNavigations { get; set; }
        public virtual ICollection<DServicesAudit> DServicesAudits { get; set; }
        public virtual ICollection<AServicesAudit> AServicesAudits { get; set; }
        public virtual ICollection<DServicesCommentt> DServicesCommentts { get; set; }
        public virtual ICollection<DServicesCustomersCall> DServicesCustomerCalls { get; set; }
        public virtual ICollection<DServicesCustomersMessage> DServicesCustomerMessages { get; set; }
        public virtual ICollection<DServicesCustomer> DServicesCustomers { get; set; }
        public virtual ICollection<DServicesCustomersLegal> DServicesCustomersLegals { get; set; }
        public virtual ICollection<DServicesFileResult> DServicesFileResults { get; set; }
        public virtual ICollection<DServicesFile> DServicesFiles { get; set; }
        public virtual ICollection<DServicesRoutesStage> DServicesRoutesStageSEmployeesJobPositionIdAddNavigations { get; set; }
        public virtual ICollection<DServicesRoutesStage> DServicesRoutesStageSEmployeesJobPositions { get; set; }
        public virtual ICollection<DServicesSmevRequest> DServicesSmevRequests { get; set; }
        public virtual ICollection<SEmployeesCombinationJob> SEmployeesCombinationJobs { get; set; }
        public virtual ICollection<SEmployeesJobPositionFine> SEmployeesJobPositionFines { get; set; }
        public virtual ICollection<SEmployeesOfficesJoin> SEmployeesOfficesJoins { get; set; }
        public virtual ICollection<SPremiumParametrsJobPositionJoin> SPremiumParametrsJobPositionJoins { get; set; }
        public virtual ICollection<SRatingJobPosition> SRatingJobPositions { get; set; }
        public virtual ICollection<STestDirectionJob> STestDirectionJobs { get; set; }
        public virtual ICollection<DTestEmployee> DTestEmployees { get; set; }
    }
}
