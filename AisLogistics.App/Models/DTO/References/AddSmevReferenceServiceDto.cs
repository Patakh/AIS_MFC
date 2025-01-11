namespace AisLogistics.App.Models.DTO.References
{
    public class AddSmevReferenceServiceDto
    {
        public AddSmevReferenceServiceDto() 
        {
            ServiceId = new List<Guid>();
        }
        public int SmevId { get; set; }
        public List<Guid> ServiceId { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}
