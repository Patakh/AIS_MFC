namespace AisLogistics.App.Models.DTO.References
{
    public class ServicesRoutesStageDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public int SRoutesStageId { get; set; }
        public string Commentt { get; set; }
        public Guid ParentId { get; set; }
        public string StageName { get; set; }
        public bool HasChildren { get; set; }

        public List<ServicesRoutesStageRoleDto> RoutesStageRoles { get; set; }
    }
}
