using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class EmployeeExecutionModelDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public bool IsExecution { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateStop { get; set; }
        public string Commentt { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
