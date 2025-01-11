namespace AisLogistics.App.Models.DTO.References
{
    public class MdmDto
    {
        public Guid Id { get; set; }
        public string ProcedureName { get; set; }
        public string ServiceName { get; set; }
        public bool IsMdm { get; set; }
        public string FrguTargetId { get; set; }
    }
}
