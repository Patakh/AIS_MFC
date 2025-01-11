using System;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class FtpModelDto
    {
        public Guid Id { get; set; }

        [Required]
        public string FtpServer { get; set; }
        [Required]
        public string FtpFolder { get; set; }
        [Required]
        public string FtpLogin { get; set; }
        [Required]
        public string FtpPassword { get; set; }


    }
}
