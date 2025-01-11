namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceCustomerTariffDto
    {
        public Guid Id { get; set; }
        public Guid SServicesCustomerId { get; set; }
        public int SServicesTariffTypeId { get; set; }

        /// <summary>
        /// получатель
        /// </summary>
        public string CustomerTypeName { get; set; }
        public string TariffTypeName { get; set; }

        /// <summary>
        /// Тип отсчета дней
        /// </summary>
        public string WeekTypeName { get; set; }
        public int CountDayProcessing { get; set; }
        public int CountDayExecution { get; set; }
        public int CountDayReturn { get; set; }
        public decimal Tariff { get; set; }
        public decimal TariffMfc { get; set; }
        public string Commentt { get; set; }

        public string SServicesProcedureName { get; set; }
    }
}
