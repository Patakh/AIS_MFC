using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceModelDto
    {
        public Guid Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string ServiceNameSmall { get; set; }
        [Required]
        public string ServiceMnemo { get; set; }
        public int ServicePosition { get; set; }
        public string TimeStorage { get; set; }
        public string Hashtag { get; set; }
        public string LegalAct { get; set; }
        public bool IsReportSelect { get; set; }
        public bool IsTariffEdit { get; set; }
        public bool IasMkgu { get; set; }
        public bool IsPlan { get; set; } = false;
        public bool IsIssueAuthority { get; set; } = false;
        public bool IsMessage { get; set; } = false;
        public string ServiceDescription { get; set; }
        public string EmployeesFioAdd { get; set; }
        public Guid SEmployeesIdAdd { get; set; }
        [Required]
        public int SServicesTypeId { get; set; }
        [Required]
        public int SServicesInteractionId { get; set; }
        public string SServicesTypeName { get; set; }
        public string SServicesInteractionName { get; set; }
        public Guid SOfficesId { get; set; }
        public string OfficeName { get; set; }
        public string FrguServiceId { get; set; }
        public string FrguName { get; set; }
        public bool IsUploadingSite { get; set; }
        public string ServiceNameSite { get; set; }
        public List<string> HashtagId { get; set; } = new List<string>();
        public List<Guid> LivingSituationId { get; set; } = new List<Guid>();
        public List<ServiceLivingSituationDto> ServiceLivingSituation { get; set; }
    }


}
