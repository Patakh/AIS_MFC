namespace AisLogistics.App.ViewModels.References
{
    public class UploadInformationFilesModel
    {
        public Guid Id { get; set; }
        public string EmployeesFioAdd { get; set; }
        public IFormFileCollection? AddedFiles { get; set; }
    }
}
