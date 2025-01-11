namespace AisLogistics.API.Models.Responce
{
    public class IasMkguQuestionResponse
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<IasMkguAnswer> Answer { get; set; }
    }

    public class IasMkguAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int? AnswerRating { get; set; }
    }

}
