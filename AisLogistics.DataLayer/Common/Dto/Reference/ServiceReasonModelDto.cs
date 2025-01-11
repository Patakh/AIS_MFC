using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceReasonModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public string ReasonText { get; set; }
        public int ReasonType { get; set; }
        public string LegalAct { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string Commentt { get; set; }

        public int? CountDay { get; set; }
        public int? SServicesWeekId { get; set; }
    }
}
