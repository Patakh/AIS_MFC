using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        [Breadcrumb("Файлы", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult ServicesFiles()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Файлы")
                .SetInvisibleViewTitle()
                .AddViewDescription("Справочник файлов")
                .AddTableMethodAction(Url.Action(nameof(GetFilesDataJson)))
                .AddEditMethodAction(Url.Action(nameof(ServicesFileChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServicesFileRemove)));
            return View("ServicesFiles/Index", modelBuilder);
        }

        public async Task<IActionResult> GetFilesDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetReferencesServicesFiles(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServicesFileChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add
                    ? new ReferencesServicesFileModelDto()
                    : await _referencesService.GetReferencesServicesFileDtoAsync(id))
                .AddModalTitle($"{(actionType == ActionType.Add ? "Добавление" : "Изменение")} файла")
                .AddModalViewPath("~/Views/Reference/ServicesFiles/_ModalChangeServiceFile.cshtml")
                .AddActionType(ActionType.Add)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServicesFileSaveAsync(ReferencesServicesFileModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
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
                    input.SEmployeesIdAdd = (Guid)employeeId;
                    input.EmployeesFioAdd = employeeName;

                    await _referencesService.AddReferencesServicesFileAsync(input);
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
                    if (input.AddedFile != null)
                    {
                        input.FileSize = input.AddedFile.Length;
                        input.FileName = Path.GetFileNameWithoutExtension(input.AddedFile.FileName);
                        input.FileExpansion = Path.GetExtension(input.AddedFile.FileName);
                    }
                    await _referencesService.UpdateReferencesServicesFileAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }

            }

        }

        [HttpPost]
        public async Task ServicesFileRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveReferencesServicesFileAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
