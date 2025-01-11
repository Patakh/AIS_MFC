using Microsoft.AspNetCore.Http;
using System;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ReferencesServicesFileModelDto
    {
        public Guid Id { get; set; }
        public int SServicesFileTypeId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileExpansion { get; set; }
        public string Commentt { get; set; }
        public Guid SEmployeesIdAdd { get; set; }
        public string EmployeesFioAdd { get; set; }
        public IFormFile AddedFile { get; set; }
    }
}
