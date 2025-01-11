using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceActivityModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public string Commentt { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateStop { get; set; }
        public string EmployeesFioAdd { get; set; }
        public Guid SEmployeesIdAdd { get; set; }
        public List<string> OffisesId { get; set; }
    }
}
