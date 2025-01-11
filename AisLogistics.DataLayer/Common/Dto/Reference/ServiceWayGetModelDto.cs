using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceWayGetModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public int SServicesWayGetId { get; set; }

        /// <summary>
        /// Тип способа. 1 - Способ обращения для получения услуги.
        /// 2 - Способ получения результата. 
        /// </summary>
        public int WayType { get; set; }

        public string EmployeesFioAdd { get; set; }
    }
}
