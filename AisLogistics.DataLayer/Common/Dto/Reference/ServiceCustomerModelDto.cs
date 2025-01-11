using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceCustomerModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public int SServicesCustomerTypeId { get; set; }

        /// <summary>
        /// Перечень представителей
        /// </summary>
        public string RepresentativeList { get; set; }

        /// <summary>
        /// Документ подтверждающий право представителя
        /// </summary>
        public string RepresentativeDocument { get; set; }

        /// <summary>
        /// Требование к документу права представителя
        /// </summary>
        public string RepresentativeSpecification { get; set; }

        /// <summary>
        /// Возможность подачи заявления представителем
        /// </summary>
        public bool Representative { get; set; }

        public string EmployeesFioAdd { get; set; }
        public Guid SEmployeesIdAdd { get; set; }
    }
}
