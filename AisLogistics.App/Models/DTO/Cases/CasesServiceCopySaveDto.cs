using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models.DTO.Cases
{
    public class CasesServiceCopySaveDto
    {
        [Required]
        public Guid DserviceId { get; set; }
        [Required]
        public Guid TarrifId { get; set; }
        [Required]
        public int StageId { get; set; }
    }
}
