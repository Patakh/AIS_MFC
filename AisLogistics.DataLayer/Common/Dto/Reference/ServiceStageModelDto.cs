using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceStageModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public Guid ParentId { get; set; }

        /// <summary>
        /// Нужно для обновления DataTable
        /// </summary>
        public Guid PrevParentId { get; set; }

        public int SRoutesStageId { get; set; }
        public string Commentt { get; set; }
        public string EmployeesFioAdd { get; set; }
        public Guid SEmployeesIdAdd { get; set; }
        
    }
}
