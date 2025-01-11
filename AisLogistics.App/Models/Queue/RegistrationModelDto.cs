using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.Queue
{
    public class RegistrationModelDto
    {
        public List<SelectListItem> MFC { get; set; }
    }

    public class GetDatePreRegistrationModelDto : RegistrationModelDto
    {
        public GetDatePreRegistrationModelDto()
        {
            MFC = new List<SelectListItem>();
            Date = new List<PreRegistratonList>();
            StartTime = new List<PreRegistratonList>();
            StopTime = new List<PreRegistratonList>();
        }
        public List<PreRegistratonList> Date { get; set; }
        public List<PreRegistratonList> StartTime { get; set; }
        public List<PreRegistratonList> StopTime { get; set; }
    }

    public class PreRegistratonList
    {
        public int idx { get; set; }
        public string value { get; set; }
        public string key { get; set; }
    }

    public class GetDatePreRegistetionResponceData
    {
        public string date { get; set; }
        public string date_format { get; set; }
        public List<string> time { get; set; }

    }

    public class PreRegistrationRequestModel
    {
        public int office_id { get; set; }
        public int service_id { get; set; }
        public DateTime date { get; set; }
        public DateTime start_time { get; set; }
        public DateTime stop_time { get; set; }
        public string full_name { get; set; }
        public string phone_number { get; set; }
    }
    public class AddPreRegistrationRequestModel : PreRegistrationRequestModel
    {
        public int queue_id { get; set; }
    }

    public class AddPreRegistrationResponceModel
    {
        public string code { get; set; }
    }

    public class PreRegistrationCancelRequestModel
    {
        public DateTime date { get; set; }
        public int code { get; set; }

    }
    public class AddCancelPreRegistrationRequestModel : PreRegistrationCancelRequestModel
    {
        public int queue_id { get; set; }
    }


}
