using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class SDaysWeek
    {
        public SDaysWeek()
        {
            SOfficesShedules = new HashSet<SOfficesShedule>();
        }
        public int Id { get; set; }
        public string DayName { get; set; }
        public string DaySmallName { get; set; }
        public ICollection<SOfficesShedule> SOfficesShedules { get; set; }
    }
}
