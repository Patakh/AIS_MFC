namespace AisLogistics.App.Models.DTO.References
{
    public class RoutesStageDto
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public int Days { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public string Commentt { get; set; }
    }
}
