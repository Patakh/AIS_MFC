using AisLogistics.DataLayer.Common.Dto.Case;
using AisLogistics.DataLayer.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.ViewModels.Cases
{
    public class CreateCaseRequestModel
    {
        [Required]
        public Guid ServiceId { get; set; }
        [Required]
        public Guid ProcedureId { get; set; }
        [Required]
        public Guid TariffId { get; set; }
        [Required]
        public int StageId { get; set; }
        public string AdditionalData { get; set; }
        public CustomerServiceModelDto? Customer { get; set; }
        public CustomerServiceModelDto? Representative { get; set; }
        public DServicesCustomersLegal? CustomerLegal { get; set; }
        public bool IsGetCustomerSnils { get; set; }
        public bool IsGetCustomerInn { get; set; }
        public bool IsGetRepresentativeSnils { get; set; }
        public bool IsGetRepresentativeInn { get; set; }
        public string? Tiket { get; set; }
    }
    public class CreateCaseLegalRequestModel : CreateCaseRequestModel
    {
        public DServicesCustomersLegal CustomerLegal { get; set; }
    }

}
