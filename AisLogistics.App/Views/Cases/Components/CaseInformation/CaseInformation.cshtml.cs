using AisLogistics.App.Models.DTO.Services;

namespace AisLogistics.App.Views.Cases.Components.CaseInformation
{
    public class CaseInformation : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CasesMainDto caseDto)
        {
            return await Task.Run(()=>View("~/Views/Cases/Components/CaseInformation/CaseInformation.cshtml", caseDto));
        }
    }
}
