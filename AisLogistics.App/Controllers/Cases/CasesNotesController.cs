using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.ModelBuilder;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult> ServiceNotesChangeModal(string caseid, Guid? id, ActionType actionType)
        {
            var NotesModelAdd = new NotesAddDto
            {
                DCaseId = caseid
            };

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalViewPath("Details/Modals/_ModalNotesAdd")
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " заметки")
                .AddModel(actionType == ActionType.Add ? NotesModelAdd : await _caseService.GetServiceNoteAsync(id.Value))
                .AddActionType(actionType);

            return ModalLayoutView(modelBuilder);
        }


        [HttpPost]
        public async Task ServiceNotesSave(NotesAddSaveDto request, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                var employeeId = await _employeeManager.GetIdAsync();
                request.EmployeeId = employeeId.Value;
                var responce = await _caseService.AddServiceNotesAsync(request);
                if (responce) ShowSuccess("Заметка добавлена");
                else ShowError("Добавление заметки невозможно");
            }
            else
            {
                var responce = await _caseService.EditServiceNotesAsync(request);
                if (responce) ShowSuccess("Заметка изменена");
                else ShowError("Изменение заметки невозможно");
            }
        }

        [HttpPost]
        public async Task ServiceNotesDelete(Guid id)
        {
            var responсe = await _caseService.DeleteServiceNotesAsync(id);

            if (responсe) ShowSuccess("Заметка удалена");
            else ShowError("Удаление заметки невозможно");
        }

    }
}
