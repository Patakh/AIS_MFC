namespace AisLogistics.App.Models.DTO.Systems
{
    public class TestEmployeesQuestionModelDto
    {
        public Guid QuestionId { get; set; }
        public string QuestionName { get; set; }
        public short Percent { get; set; }
        public List<TestEmployeesQuestionAnswer> Answers { get; set; }
    }

    public class TestEmployeesQuestionAnswer
    {
        public Guid AnswerId { get; set; }
        public string AnswerName { get; set; }
        public bool IsTruth { get; set; }
        public bool IsAnswer { get; set; }
    }


}
