namespace AisLogistics.API.Models.Responce
{
    public class ServicesReasonsInfoResponse
    {
        public Guid Id { get; set; }

        public string ReasonText { get; set; }
        /// <summary>
        /// 1 - Отказ в приеме документа. 2 - Отказ в предоставлении подуслуги 
        /// 3- Приостановка 
        /// </summary>
        //public int ReasonType { get; set; }

        public string LegalAct { get; set; }

    }
}
