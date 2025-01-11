namespace AisLogistics.App.Models.DTO.Reporpts
{
    public class ReportsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SReportGroupId { get; set; }
        public string SReportGroupName { get; set; }
        public int Order { get; set; }
        public string Path { get; set; }
        public string Function { get; set; } 
        public byte[] File { get; set; }
    }
}
