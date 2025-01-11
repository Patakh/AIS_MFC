using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public class SOfficesAcquiring
    {
        public Guid Id { get; set; }
        public string AcquiringName { get; set; }
        public string IpAddress { get; set; }
        public Guid SOfficesId { get;set; }
        public bool IsRemove { get; set; }

        public SOffice SOffices { get; set; }
    }
}
