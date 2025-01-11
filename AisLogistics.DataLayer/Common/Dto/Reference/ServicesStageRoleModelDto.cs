using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServicesStageRoleModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesRoutesStageId { get; set; }
        public Guid SRolesExecutorId { get; set; }
        public string EmployeesFioAdd { get; set; }

        /// <summary>
        /// Нужно для обновления DataTable
        /// </summary>
        public Guid ParentId { get; set; }
    }
}
