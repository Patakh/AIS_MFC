using AisLogistics.DataLayer.Entities.Models;

namespace AisLogistics.App.Models.DTO.Information
{
    public class Information
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string EmployeeFio { get; set; }
        public string EmployeeJob { get; set; }
        public DateTime DateAdd { get; set; }
        public string DateAddToString { get; set; }
    }
    public class EmployeeInformationDto : Information
    {
        public DateTime? DateStop { get; set; }
        public DateTime DateStart { get; set; }
        public bool IsRemove { get; set; }
        public bool IsAttachment { get; set; }
        public bool ForMe { get; set; }
    }
    public class InformationDetails : Information
    {
        public List<FileDto> Files { get; set; }
    }

    public class FileDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileExtensions { get; set; }
        public int FileSize { get; set; }
    }

    public class EmployeeWarningDto
    {
        public EmployeeWarningDto()
        {
            Expired = new List<StageInfo>();
            Lastday = new List<StageInfo>();
            LessThreeDays = new List<StageInfo>();

        }
       public List<StageInfo>  Expired { get; set;}
       public List<StageInfo> Lastday { get; set;}
       public List<StageInfo> LessThreeDays { get; set;}

    }

    public class RatingDto
    {
        public bool IsSkip { get; set; }
        public EmployeeRatingDto Employee { get; set; }
        public OfficeRatingDto Office { get; set; }
    }

    public class EmployeeRatingDto
    {
        public int PositionId { get; set; }
        public int PositionMovingId { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Guid OfficessId { get; set; }
        public string OfficesName { get; set; }
        public int EmployeePoint { get; set; }
        public int ReceivedCount { get; set; }
        public int IssuedCount { get; set; }
        public int ConsultationCount { get; set; }
    }

    public class OfficeRatingDto
    {
        public int PositionId { get; set; }
        public int PositionMovingId { get; set; }
        public Guid OfficessId { get; set; }
        public string OfficesName { get; set; }
        public int EmployeePoint { get; set; }
        public int ReceivedCount { get; set; }
        public int IssuedCount { get; set; }
        public int ConsultationCount { get; set; }
    }



    public class EmployeeNotesDto
    {
        public Guid Id { get; set; }
        public string DCasesId { get; set; }
        public string NoteText { get; set; }
        public Guid SEmployeesId { get; set; }
        public DateTime? DateReminder { get; set; }
        public DateTime DateAdd { get; set; }
        public bool? IsViewed { get; set; }
        public string ApplicantName { get; set; }
    }

    public class StageInfo
    {
        public string CaseId { get; set; }
        public string ApplicantName { get; set; }
        public string ServiceName { get; set; }
        public string StageName { get; set; }
    }

}
