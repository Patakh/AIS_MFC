using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult> ServiceSmevCompleted(Guid id)
        {
            ViewBag.Id = id;
            var smevСompleted = await _caseService.GetSmevСompletedByServiceIdAsync(id);
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("СМЭВ запросы")
                .AddModel(smevСompleted);
            return PartialView("Details/Sidebar/_SidebarSmevCompleted", modelBuilder);
        }

        public IActionResult ServiceSmevCreate(Guid id)
        {
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.FULL)
                .AddModalViewPath("Details/Modals/_ModalSmevCreate")
                .AddModel(new SmevCreateResponseModel { ServiceId = id })
                .HideModalFooter();
            return ModalLayoutView(modelBuilder);
        }

        public async Task<IActionResult> GetServiceSmevActiveDataJson(IDataTablesRequest request, Guid serviceId)
        {
            var smevActive = await _caseService.GetSmevActiveByServiceId(serviceId, request.Search.Value, request.Start, request.Length);

            var response = DataTablesResponse.Create(request, smevActive.Item2, smevActive.Item3, smevActive.Item1);

            return new DataTablesJsonResult(response, true);
        }
    }
}
