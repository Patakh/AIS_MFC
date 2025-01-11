namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceReasonDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }

        public string ReasonText { get; set; }

        /// <summary>
        /// 1 - Отказ в приеме документа. 2 - Отказ в предоставлении подуслуги 
        /// 3- Приостановка 
        /// </summary>
        public int ReasonType { get; set; }

        public string LegalAct { get; set; }
        public string Commentt { get; set; }
        /// <summary>
        /// Количество дней приостановки
        /// </summary>
        public int? CountDay { get; set; }
        //public int? SServicesWeekId { get; set; }
        public string? TypeName { get; set; }
    }
}
