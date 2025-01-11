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
    // Файлы
    public partial class ReferenceController
    {
        public async Task<IActionResult> ServiceFiles(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Файлы")
                .SetElementName(nameof(ServiceFiles))
                .AddTableMethodAction(Url.Action(nameof(GetServiceFilesDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceFilesChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceFileRemove)));

            return PartialView("Services/Details/Files", modelBuilder);
        }

        public async Task<IActionResult> GetServiceFilesDataJson(IDataTablesRequest request, Guid id)
        {
            var srch = request.Search.Value;
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceFiles(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceFilesChangeModal(Guid? id, Guid serviceId, ActionType actionType)
        {
            var procedures = await _referencesService.GetAllServiceProceduresAsync(serviceId);

            ViewBag.Procedures = new SelectList(procedures, nameof(ServicesProcedureDto.Id), nameof(ServicesProcedureDto.ProcedureName));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new ServiceFileModelDto() { SServicesId = serviceId } : await _referencesService.GetServiceFileAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " файла услуги")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceFile.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task ServiceFileRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceFileAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceFileSaveAsync(ServiceFileModelDto input, ActionType actionType)
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
                    await _referencesService.AddServiceFileAsync(input);

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

                        await _referencesService.UpdateServiceFileAsync(input);
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

        public async Task<IActionResult> ServiceFileDownload(Guid id)
        {
            try
            {
                var file = await _referencesService.GetServiceFileAsync(id);
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
