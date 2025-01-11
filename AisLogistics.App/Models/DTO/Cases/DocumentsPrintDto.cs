namespace AisLogistics.App.Models.DTO.Cases
{
    public class DocumentsPrintDto
    {
        public Guid Id { get; set; }    
        public bool IsChecked { get; set; }
        public int CountCopy { get; set; }
        public int CountOriginal { get; set; }
    }
}
