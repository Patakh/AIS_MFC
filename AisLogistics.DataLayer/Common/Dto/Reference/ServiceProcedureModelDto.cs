using System;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceProcedureModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public string ProcedureName { get; set; }
        public bool ProcedureActive { get; set; }
        public string FrguTargetId { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string ExtraFormPath { get; set; }
        public bool IsMdm { get; set; }
    }
}
