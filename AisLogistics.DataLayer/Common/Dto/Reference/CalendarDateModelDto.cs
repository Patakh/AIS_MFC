using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class CalendarDateModelDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int DateType { get; set; }

        public string EmployeesFioAdd { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
