namespace AisLogistics.App.Models.DTO.ReestrUnclaimedDocuments
{
    public class ReestrUnclaimedDocumentsDto
    {
        public Guid Id { get; set; }
        public long ReestrNumber { get; set; }
        public string DateAdd { get; set; }
        public string ProviderName { get; set; }
        public string DepartementName { get; set; }
        public string ServiceName { get; set; }
        public int CountService { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string JobPositionsName { get; set; }
    }
}
