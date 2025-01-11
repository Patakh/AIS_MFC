namespace AisLogistics.App.Models.DTO.References
{
    public class ServicesProcedureDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public string ProcedureName { get; set; }
        public string ExtraFormPath { get; set; }
        public string FrguTargetId { get; set; }
        public string EmployeesFioAdd { get; set; }
        public bool ProcedureActive { get; set; }
        public string DateAdd { get; set; }
        public bool IsMdm { get; set; }
    }
}
