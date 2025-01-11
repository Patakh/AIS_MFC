namespace AisLogistics.App.ViewModels.Systems.Test
{
    public class EmployeesQuestionResponseModel
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int JobPositionId { get; set; }
        public string JobPositionName { get; set; } 
        public Guid OfficeId { get; set; }
        public string OfficeName { get; set; }
        public List<EmployeesQuestion> EmployeesQuestionsInfo { get; set; } 
    }

    public class EmployeesQuestion
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
