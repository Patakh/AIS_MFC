namespace AisLogistics.App.Models.DTO.Services
{
    public class ActiveServiceTariffDto
    {
        public Guid Id { get; internal set; }
        public Guid ServiceCustomerId { get; internal set; }
        public int CustomerTypeId { get; internal set; }
        public string CustomerTypeName { get; internal set; }
        public string TariffTypeName { get; internal set; }
        public string WeekTypeName { get; internal set; }
        public int CountDayProcessing { get; internal set; }
        public int CountDayExecuting { get; internal set; }
        public int CountDayReturn { get; internal set; }
        public decimal TariffMfc { get; internal set; }
        public decimal TariffOiv { get; internal set; }
        public string Comment { get; internal set; }
        public int WeekTypeId { get; set; }
    }
}
