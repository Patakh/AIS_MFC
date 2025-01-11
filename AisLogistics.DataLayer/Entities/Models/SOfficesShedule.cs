using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class SOfficesShedule
    {
        public Guid Id { get; set; }
        public Guid SOfficesId { get; set; }
        public int DayType { get; set; }
        public int SDaysWeekId { get; set; }
        public TimeSpan? WorkStart { get; set; }
        public TimeSpan? WorkStop { get; set; }
        public TimeSpan? DinnerStart { get; set; }
        public TimeSpan? DinnerStop { get; set; }
        public string EmployeesFioAdd { get; set; }
        public DateTime DateAdd { get; set; }

        public SOffice SOffice { get; set; }
        public SDaysWeek SDaysWeek { get; set; }
    }
}

