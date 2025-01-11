using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class EmployeeRoleExecutorModelDto
    {
        public Guid Id { get; set; }
        public Guid SEmployeesId { get; set; }
        public Guid SRolesExecutorId { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
