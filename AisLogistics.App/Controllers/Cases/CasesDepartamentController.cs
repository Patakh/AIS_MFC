using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult> ServiceDepartamentAddModal(Guid id, Guid officeid, Guid? departamentId)
        {
            var offices = await _referencesService.GetOfficesProvidersDepartement(new List<Guid> { officeid });

            var request = new ServiceDepartamentsDto() { ServiceId = id };
            if (departamentId is not null) request.DepartamentId = departamentId.Value;

            ViewBag.Offices = new SelectList(offices, "Id", "OfficeName");

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalViewPath("Details/Modals/_ModalDepartamentAdd")
                .AddModalTitle("Добавление отдела")
                .AddModel(request);

            if (offices is null || offices.Count==0) modelBuilder.HideSubmitButton();

            return ModalLayoutView(modelBuilder);
        }

        public async Task ServiceDepartamentSave(ServiceDepartamentsDto request)
        {
            try { 
                await _caseService.AddServiceDepartamentAsync(request);
                ShowSuccess("Отдел добавлен");
            }
            catch
            {
                ShowError("Добавления отдела невозможно");
            }
        }
    }
}
