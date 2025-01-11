namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeeTestStartDto
    {
        public Guid EmployeeTestId { get; set; }    
        public string Name { get; set; }
        public int Number { get; set; }
        public short CountQuestions { get; set; }
        public short CountTestTime { get; set; }
        public List<string> Directions { get;set; } 
        public bool IsActive { get; set; }
    }
}
