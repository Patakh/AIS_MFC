using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        public async Task<IActionResult> ServiceDocuments(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var procedures = await _referencesService.GetAllServiceProceduresAsync(id);
            string proceduresOptions = procedures == null ? "" : string.Join("", procedures.Select(x => $"<option value=\"{x.Id}\">{x.ProcedureName}</option>"));

            var modelBuilder = new ViewModelBuilder()
                .AddModel(proceduresOptions)
                .AddViewDescription("Документы")
                .SetElementName(nameof(ServiceDocuments))
                .AddTableMethodAction(Url.Action(nameof(GetServiceDocumentsDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceDocumentChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceDocumentRemove)));

            return PartialView("Services/Details/Documents", modelBuilder);
        }

        public async Task<IActionResult> GetServiceDocumentsDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceDocuments(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceDocumentChangeModal(Guid? id, Guid serviceId, ActionType actionType)
        {
            var procedure = await _referencesService.GetAllServiceProceduresAsync(serviceId);

            var documents = await _referencesService.GetAllDocumentsAsync();

            //исключить уже добавленных
            var added = await _referencesService.GetAllServiceDocumentsAsync(serviceId);
            if (id is null)
            {
                // добавление
                documents.RemoveAll(x => added.Where(x => x.SServicesId == serviceId).Select(o => o.SDocumentsId).ToArray().Contains(x.Id));
            }
            else
            {
                // измениние
                documents.RemoveAll(x => added.Where(x => x.Id != id && x.SServicesId == serviceId).Select(o => o.SDocumentsId).ToArray().Contains(x.Id));
            }

            // ***************************************************
            ViewBag.Procedure = new SelectList(procedure, nameof(ServicesProcedureDto.Id), nameof(ServicesProcedureDto.ProcedureName));
            ViewBag.Documents = new SelectList(documents, nameof(DocumentsDto.Id), nameof(DocumentsDto.Name));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new ServiceDocumentModelDto() { SServicesId = serviceId } : await _referencesService.GetServiceDocumentDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " документа")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceDocument.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task ServiceDocumentRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceDocumentAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceDocumentSaveAsync(ServiceDocumentModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                var employeeId = await _employeeManager.GetIdAsync();

                if (employeeId is null)
                {
                    ShowError(MessageDescription.Error);
                    return;
                }

                var employeeName = await _employeeManager.GetNameAsync();
                input.EmployeesFioAdd = employeeName;

                try
                {
                    await _referencesService.AddServiceDocumentAsync(input);

                    ShowSuccess(MessageDescription.AddSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
            else
            {
                try
                {
                    await _referencesService.UpdateServiceDocumentAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }
    }
}
