using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceDocumentResultModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public Guid SDocumentsId { get; set; }
        public Guid? SServicesProcedureId { get; set; }
        public bool DocumentResult { get; set; }
        public string DocumentMethod { get; set; }
        public string DocumentPeriodProvider { get; set; }
        public string DocumentPeriodMfc { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
