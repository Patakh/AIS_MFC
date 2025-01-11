using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Utils;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Reference
{
    // Бланки
    public partial class ReferenceController
    {
        public async Task<IActionResult> ServiceBlancs(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Бланки")
                .SetElementName(nameof(ServiceBlancs))
                .AddTableMethodAction(Url.Action(nameof(GetServiceBlancsDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceBlancsChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceBlancRemove)));


            return PartialView("Services/Details/Blancs", modelBuilder);
        }

        public async Task<IActionResult> GetServiceBlancsDataJson(IDataTablesRequest request, Guid id)
        {
            var srch = request.Search.Value;
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceBlancs(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceBlancsChangeModal(Guid? id, Guid serviceId, ActionType actionType)
        {
            var procedures = await _referencesService.GetAllServiceProceduresAsync(serviceId);

            ViewBag.Procedures = new SelectList(procedures, nameof(ServicesProcedureDto.Id), nameof(ServicesProcedureDto.ProcedureName));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new ServiceBlancModelDto() { SServicesId = serviceId } : await _referencesService.GetServiceBlancsAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " бланка услуги")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceBlank.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task ServiceBlancRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceBlancsAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceBlancSaveAsync(ServiceBlancModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                if (input.AddedFile is null)
                    throw new InvalidOperationException("Выберите файл");

                var employeeId = await _employeeManager.GetIdAsync();

                if (employeeId is null)
                {
                    ShowError(MessageDescription.Error);
                    return;
                }

                var employeeName = await _employeeManager.GetNameAsync();
                input.FileSize = input.AddedFile.Length;
                input.FileName = Path.GetFileNameWithoutExtension(input.AddedFile.FileName);
                input.FileExpansion = Path.GetExtension(input.AddedFile.FileName);
                input.EmployeesFioAdd = employeeName;

                try
                {
                    await _referencesService.AddServiceBlancsAsync(input);

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
                    if (input.AddedFile is not null)
                    {
                        input.FileSize = input.AddedFile.Length;
                        input.FileName = Path.GetFileNameWithoutExtension(input.AddedFile.FileName);
                        input.FileExpansion = Path.GetExtension(input.AddedFile.FileName);

                        await _referencesService.UpdateServiceBlancsAsync(input);
                        ShowSuccess(MessageDescription.EditSuccess);
                    }

                    else throw new InvalidOperationException("Выберите файл");

                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        public async Task<IActionResult> ServiceBlancDownload(Guid id)
        {
            try
            {
                var file = await _referencesService.GetServiceBlancsAsync(id);
                if (file is null)
                {
                    ShowError("Файл не найден");
                    return NotFound();

                }

                return File(file.File, MimeTypeMap.GetMimeType(file.FileExpansion), $"{file.FileName}{file.FileExpansion}");
            }

            catch (Exception ex)
            {
                ShowError(ex.Message);
                return NotFound();
            }
        }
    }
}
