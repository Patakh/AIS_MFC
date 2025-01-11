namespace AisLogistics.App.ViewModels.Systems.Test
{
    public class EmployeesTestSaveRequestModel
    {
        public string TestName { get; set; }
        public int CountQuestions { get; set; }
        public short TestTime { get; set; }
        public DateTime DateStartTest { get; set; }
        public TimeSpan TimeStartTest { get; set; }
        public List<Guid> TestDirectionId { get; set; }
        public List<int> TestEmployeeJobsId { get; set; }
        public List<EmployeeQuestion> EmployeeQuestion { get; set; }
    }

    public class EmployeeQuestion
    {
        public Guid Id { get; set; }
        public Guid OfficeId { get; set; }
        public int JobPositionId { get; set; }
        public List<QuestionInfo> Question { get; set; }
        public string EmployeeName { get; set; }
        public string JobPositionName { get; set; }
        public string OfficeName { get; set; }
    }

    public class QuestionInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
