using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceSmevRequestModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public int SSmevRequestId { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
