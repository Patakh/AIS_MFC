

using System.Text.Json.Serialization;

namespace AisLogistics.App.Models.DTO.References
{
    public class OfficeDto
    {
        public Guid Id { get; set; }
        public string OfficeName { get; set; }
        public int OfficeTypeId { get; set; }
        public string OfficeTypeName { get; set; }
        public bool Selected { get; set; } = false;
    }

    public class OfficeParentsDto : OfficeDto
    {
        public Guid? ParentOfficeId { get; set; }
        public string ParentOfficeName { get; set; }
        public int CountChild {get; set; }
    }

    public class OfficeQueueDto
    {
        public string Id { get; set; }
        public string OfficeName { get; set; }
    }

    public class OfficeSpsDto
    {
        public int Id { get; set; }
        [JsonPropertyName("office_name")]
        public string OfficeName { get; set; }
    }

}
