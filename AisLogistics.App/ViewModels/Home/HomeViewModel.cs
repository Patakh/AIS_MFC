using AisLogistics.App.Models.DTO.Information;

namespace AisLogistics.App.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<EmployeeInformationDto>? Information { get;set; }
        public List<EmployeeNotesDto>? Notes {  get;set; } 
    }
}
