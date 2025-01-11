using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class AutoHistory
    {
        public int Id { get; set; }
        public string RowId { get; set; }
        public string TableName { get; set; }
        public string Changed { get; set; }
        public DateTime? Created { get; set; }
        public int? Kind { get; set; }
    }
}
