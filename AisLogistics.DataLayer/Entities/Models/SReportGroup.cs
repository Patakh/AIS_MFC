using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class SReportGroup
    {
        public SReportGroup()
        {
            SReports = new HashSet<SReport>();
        }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование группы
        /// </summary>
        public string GroupName { get; set; }
        public virtual ICollection<SReport> SReports { get; set; }
    }
}
