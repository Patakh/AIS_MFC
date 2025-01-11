using AisLogistics.App.Models.DTO.Services;

namespace AisLogistics.App.Models.DTO.Cases
{
    public class CasesReestrSmevDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CaseId { get; set; }
        public string DateCreate { get; set; }
        public string DateResponseFact { get; set; }
        public string DateResponseReg { get; set; }
        public int Status { get; set; }
        public EmployeeDto EmployeeAdd { get; set; }
        public string Description { get; set; }
        public CaseServiceDto Service { get; set; }
        public ApplicantDto Applicant { get; set; }
        public string Provider { get; set; }
        public string SmevService { get; set; }
        public string Comment { get; set; }
    }
}
