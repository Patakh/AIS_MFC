using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class InformationModelDto
    {
        public Guid Id { get; set; }

        [Required]
        public int SInformationTypeId { get; set; }

        [Required]
        public string InformationText { get; set; }

        [Required]
        public string InformationTopic { get; set; }
        public string EmployeesFioAdd { get; set; }
        public string EmployeesJobPositionAdd { get; set; }

        [Required]
        public DateTime DateStart { get; set; }
        public DateTime? DateStop { get; set; }

        public List<string> Offices { get; set; }
        public ICollection<IFormFile> AddedFiles { get; set; }
    }
}
