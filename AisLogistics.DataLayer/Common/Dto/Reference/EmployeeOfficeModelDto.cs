using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class EmployeeOfficeModelDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public List<string> OfficesId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateStop { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
