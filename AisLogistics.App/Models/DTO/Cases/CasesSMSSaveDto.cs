namespace AisLogistics.App.Models.DTO.Cases
{

    public class CasesSMSAddDto
    {
        public string CasesId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
    }
    public class CasesSMSSaveDto
    {
        public string CasesId {get; set;} 
        public string Text {get; set; }
        public string CustomerName { get; set;}
        public string CustomerPhone { get; set;}
    }
}
