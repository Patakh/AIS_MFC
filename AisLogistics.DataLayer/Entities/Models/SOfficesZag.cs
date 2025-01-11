using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список отделений ЗАГС
    /// </summary>
    public partial class SOfficesZag
    {
        public Guid SOfficesId { get; set; }
        public string ZagsCode { get; set; }
        public string ZagsName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool? IsRemove { get; set; }
        public int Id { get; set; }

        public virtual SOffice SOffices { get; set; }
    }
}
