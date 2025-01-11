namespace AisLogistics.App.Models.DTO.Statistics
{
    public class StatisticsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SStatisticsGroupId { get; set; }
        public string SStatisticsGroupName { get; set; }
        public int Order { get; set; }
        public string Path { get; set; }
    }
}
