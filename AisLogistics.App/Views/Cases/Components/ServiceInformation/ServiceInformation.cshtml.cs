using AisLogistics.App.Models.DTO.Services;

namespace AisLogistics.App.Views.Cases.Components.ServiceInformation
{
    public class ServiceInformation : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<CaseServiceDto> CaseServiceDto)
        {
            return await Task.Run(()=>View("~/Views/Cases/Components/ServiceInformation/ServiceInformation.cshtml", CaseServiceDto));
        }
    }
}
