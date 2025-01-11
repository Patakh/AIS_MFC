namespace AisLogistics.App.Models.DTO.References
{
    public class InformationFileDto
    {
        public Guid Id { get; set; }
        public Guid DInformationId { get; set; }
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public int FileSize { get; set; }
        //public DateTime DateAdd { get; set; }
        //public string EmployeesFioAdd { get; set; }
    }
}
