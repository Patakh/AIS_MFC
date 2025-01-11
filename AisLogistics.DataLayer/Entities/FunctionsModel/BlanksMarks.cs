using System.ComponentModel.DataAnnotations.Schema;

namespace AisLogistics.DataLayer.Entities.FunctionsModel
{
    public class BlanksMarks
    {
        [Column("out_name")]
        public string Name { get; set; }
        [Column("out_value")]
        public string Value { get; set; }
    }
}
