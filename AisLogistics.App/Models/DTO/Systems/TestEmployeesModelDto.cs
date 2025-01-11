namespace AisLogistics.App.Models.DTO.Systems
{
    public class TestEmployeesModelDto
    {
        public Guid Id { get;set; } 
        public string EmployeesName { get; set; }
        public string OfficesName { get; set; }
        public string JobPositionsName { get; set; }
        public short? PercentResult { get; set; }
        public short? NumberCorrectQuestions { get; set; }
        public short? NumberIncorrectQuestions { get; set; }
        public short? NumberQuestionsAnswered { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public string Color()
        {
            var result = PercentResult switch
            {
                <50 => "bg-danger",
                >=50 and <75 => "bg-warning",
                >=75 and <85 => "bg-info",
                >= 85 => "bg-success",
                _ => "bg-secondary"
            };
                
            return result;
        }
    }
}
