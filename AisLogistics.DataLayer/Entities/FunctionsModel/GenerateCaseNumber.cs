using System.ComponentModel.DataAnnotations.Schema;

namespace AisLogistics.DataLayer.Entities.FunctionsModel
{
    public class GenerateCaseNumber
    {
        [Column("nextval")]
        public long Number { get; set; }
    }
}
