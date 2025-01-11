using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServiceFileModelDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public string Commentt { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileExpansion { get; set; }
        public string EmployeesFioAdd { get; set; }
        public Guid? SServicesProcedureId { get; set; }
        public IFormFile AddedFile { get; set; }
        public byte[] File { get; set; }
        public bool IsDownLoad { get; set; }
    }
}
