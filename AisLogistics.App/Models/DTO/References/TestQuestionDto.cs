namespace AisLogistics.App.Models.DTO.References
{
    public class TestQuestionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public short QuestionType { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string DateAdd { get; set; }
    }
}
