using System.ComponentModel.DataAnnotations.Schema;

namespace AisLogistics.DataLayer.Entities.FunctionsModel
{
    public class ServiceStateTaskInfoForPanelHead
    {
        [Column("out_state_task_count")]
        public int StateTaskCount { get; set; }
        [Column("out_executed_count")]
        public int ExecutedCount { get; set; }
        [Column("out_executed_percent")]
        public decimal ExecutedPercent { get; set; }
        [Column("out_forecast_count")]
        public int Forecastcount { get; set; }
        [Column("out_forecast_percent")]
        public decimal Forecastpercent { get; set; }
    }
}
