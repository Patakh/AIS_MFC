namespace AisLogistics.API.Models.Responce
{
    public class CasesInfoResponse
    {
        public string CaseId { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string EmployeesFioCurrent { get; set; }
        public string MfcName { get; set; }
        public string ServicesProviderName { get; set; }
        public string ServicesName { get; set; }
        public string StatusName { get; set; }
        public int StatusId { get; set; }
        public string CustomerFio { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateReglament { get; set; }
        public DateTime? DateFact { get; set; }
    }
}
