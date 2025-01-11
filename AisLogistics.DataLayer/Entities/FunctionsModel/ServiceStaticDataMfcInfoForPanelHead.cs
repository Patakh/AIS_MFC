using System.ComponentModel.DataAnnotations.Schema;

namespace AisLogistics.DataLayer.Entities.FunctionsModel
{
    public class ServiceStaticDataMfcInfoForPanelHead
    {
        [Column("out_name")]
        public string Name { get; set; }
        [Column("out_value")]
        public int Value { get; set; }
    }
}
