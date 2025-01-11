namespace AisLogistics.App.Models.DTO.Systems
{
    public class TestModelDto
    {
        public Guid Id { get; set; }    
        public int Number { get; set; }
        public string Name { get; set; }
        public short CountQuestions { get; set; }
        public short CountTime { get; set; }
        public int CountDirections { get; set; }
        public List<string> Directions { get; set; }    
        public int CountEmployees { get; set; }
        public int CountDoneEmployees { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string DateAdd { get; set; }

    }
}
