namespace AisLogistics.App.Models.DTO.References
{
    public class SmevRequestDto
    {
        public int Id { get; set; }
        public Guid SSmevId { get; set; }
        public string SmevName { get; set; }
        public string RequestName { get; set; }
        public string RequestTypeName { get; set; }
        public int CountDayExecution { get; set; }
        public string WeekDayName { get; set; }
        public string Path { get; set; }
        public string ServiceOrFunctionCode { get; set; }
    }
}
