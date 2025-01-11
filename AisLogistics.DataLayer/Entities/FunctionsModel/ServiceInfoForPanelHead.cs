using System.ComponentModel.DataAnnotations.Schema;

namespace AisLogistics.DataLayer.Entities.FunctionsModel
{
    public class ServiceInfoForPanelHead
    {
        [Column("out_name")]
        public string Name { get; set; }
        [Column("out_received_count")]
        public int ReceivedCount { get; set; }
        [Column("out_consultation_count")]
        public int ConsultationCount { get; set; }
        [Column("out_issued_count")]
        public int IssuedCount { get; set; }
    }
}
