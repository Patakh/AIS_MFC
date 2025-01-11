namespace AisLogistics.App.ViewModels.Systems.Test
{
    public class EmployeesQuestionRequestModel
    {
        public List<Guid> TestDirectionId { get; set; }
        public List<Guid> TestEmployeesId { get; set; }
        public List<int> TestEmployeeJobsId { get; set; }
        public Guid TestOfficesId { get; set; }
        public int CountQuestions { get; set; }
    }

    public class EmployeesQuestioRefreshRequestModel
    {
        public List<Guid> TestDirectionId { get; set; }
        public Guid TestEmployeeId { get; set; }
        public List<int> TestEmployeeJobsId { get; set; }
        public Guid TestOfficesId { get; set; }
        public int CountQuestions { get; set; }
    }

}
