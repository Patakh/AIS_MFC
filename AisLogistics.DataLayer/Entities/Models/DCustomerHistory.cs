using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class DCustomerHistory
    {
        public Guid Id { get; set; }
        public Guid DCustomersId { get; set; }
        public string OfficeName { get; set; }
        public string EmployeeName { get; set; }
        public string ServiceName { get; set; }
        public string CaseNumber { get; set; }
        public string ProviderName { get; set; }
        public string DepartmentName { get; set; }
        public string StatusName { get; set; }
        public string StageName { get; set; }
        public DateTime DateReception { get; set; }
        public DateTime DateClose { get; set; }

        public virtual DCustomer DCustomers { get; set; }
    }
}
