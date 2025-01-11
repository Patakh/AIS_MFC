namespace AisLogistics.API.Models.Dto
{
    public class SearchCustomerCaseDto
    {
        /// <summary>
        /// Id услуги
        /// </summary>
        public Guid dataServiceId { get; set; }

        /// <summary>
        /// Номер дела
        /// </summary>
        public string caseNumber { get; set; }

        /// <summary>
        /// Наименование услуги
        /// </summary>
        public string serviceName { get; set; }

        /// <summary>
        /// Дата занесения услуги
        /// </summary>
        public string caseDateAdd { get; set; }

        /// <summary>
        /// id статуса услуги
        /// </summary>
        public int caseStatusId { get; set; }
    }
}
