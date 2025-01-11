using System;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class EmployeeActivityModelDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateStop { get; set; }
        public string Commentt { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
