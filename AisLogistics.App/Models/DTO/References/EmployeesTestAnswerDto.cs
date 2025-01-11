namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeesTestAnswerDto
    {
        public Guid EmployeeTestId { get; set; }
        public Guid EmployeeTestQuestionId { get; set; }
        public int QuestionCount { get; set; }
        public int QuestionType { get; set; }   
        public string TestTime { get; set; }
        public List<Answer> Answers { get; set;} 

    }

    public class Answer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsTruth { get; set; }
        public bool IsResponse { get; set; }
    }
}
