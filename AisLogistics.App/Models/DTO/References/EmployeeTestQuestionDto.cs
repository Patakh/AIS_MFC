namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeeTestQuestionDto
    {
        public Guid EmployeeId { get; set; }
        public Guid EmployeeTestId { get;set; }
        public short? Percent { get; set; }
        public Question? Question { get; set; }
    }

    public class Question
    {
        public Guid? EmployeeQuestionId { get; set; }
        public string QuestionName { get; set; }
        public int QuestionType { get; set; }
        public long TestTime { get; set; }
        public int QuestionNumber { get; set; }
        public int QuestionCount { get; set; }
        public List<EmployeeTestAnswer> Answers { get; set; }
    }

    public class EmployeeTestAnswer
    {
        public Guid AnswerId { get; set; }
        public string AnswerName { get; set; }
        public bool IsTruth { get; set; }
    }
}
