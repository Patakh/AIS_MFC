using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceCustomerTariffModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesCustomerId { get; set; }
        public Guid? SServicesProcedureId { get; set; }
        public int SServicesTariffTypeId { get; set; }
        public int SServicesWeekId { get; set; }
        public int CountDayProcessing { get; set; }
        public int CountDayExecution { get; set; }
        public int CountDayReturn { get; set; }
        public decimal Tariff { get; set; }
        public decimal TariffMfc { get; set; }
        public string Commentt { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
