using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.App.ViewModels.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Reference
{
    public partial class ReferenceController
    {
        [Breadcrumb("Информация", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult Information()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Информация").SetInvisibleViewTitle()
                .AddViewDescription("Информация")
                .AddTableMethodAction(Url.Action(nameof(GetInformationsDataJson)))
                .AddEditMethodAction(Url.Action(nameof(InformationChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(InformationRemove)));
            return View("Information/Index", modelBuilder);
        }

        public async Task<IActionResult> GetInformationsDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetInformations(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> InformationChangeModal(Guid? id, ActionType actionType)
        {
            ViewBag.InformationTypes = new SelectList(await _referencesService.GetInformationTypesAsync(), "Key", "Value");

            var offices = await _filterManager.GetOfficesReceptionCustomerDataJson(true);

            ViewBag.Offices = new SelectList(offices, nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName));

            //List<string> selectedOffices = await _referencesService.GetInformationOfficesAsyncV2(id);
            //var allOffices = await _referencesService.GetAllOfficesAsync();
            //if (selectedOffices.Count >= allOffices.Count)
            //{
            //    allOffices.Add(new OfficeDto() { Id = default(Guid), OfficeName = "Все" });
            //    selectedOffices.Clear();
            //    selectedOffices.Add(default(Guid));
            //}


            //ViewBag.Offices = allOffices.Select(x => new SelectListItem(x.OfficeName, x.Id.ToString(), selectedOffices.Contains(x.Id)));
            //new SelectList(await _referencesService.GetAllOfficesAsync(), nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new InformationModelDto() : await _referencesService.GetInformationDtoAsync(id))
                .AddModalTitle($"{(actionType == ActionType.Add ? "Добавление" : "Изменение")} информации")
                .AddModalViewPath($"~/Views/Reference/Information/{(actionType == ActionType.Add ? "_ModalAddInformation" : "_ModalChangeInformation")}.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task InformationSaveAsync(InformationModelDto input, ActionType actionType)
        {
            var employee = await _employeeManager.GetFullInfoAsync();
            if (employee is null)
            {
                ShowError(MessageDescription.Error);
                return;
            }

            input.EmployeesFioAdd = employee.Name;
            input.EmployeesJobPositionAdd = employee.Job.Name;

            if (actionType == ActionType.Add)
            {
                try
                {
                    await _referencesService.AddInformationAsync(input);
                    //var files = this.HttpContext.Request.Form.Files;

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
                    await _referencesService.UpdateInformationAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        [HttpPost]
        public async Task InformationRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveInfornmationAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        public async Task<IActionResult> GetInformationFilesJson(Guid id)
        {
            var results = await _referencesService.GetInformationFilesAsync(id);

            return Json(results);
        }

        public async Task<IActionResult> DownloadInformationFile(Guid id)
        {
            var file = await _referencesService.DownloadInformationFileAsync(id);
            if (file is null) return NotFound();

            return File(file.OpenReadStream(), file.ContentType, file.FileName);
        }

        public async Task<IActionResult> DownloadInformationFileThumbnail(Guid id)
        {
            var file = await _referencesService.DownloadInformationFileThumbnailAsync(id);
            if (file is null) return NotFound();

            return File(file.OpenReadStream(), file.ContentType, file.FileName);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<InformationFileResponseModel> InformationFileSaveAsync(UploadInformationFilesModel input)
        {
            var response = new InformationFileResponseModel();

            var employeeId = await _employeeManager.GetIdAsync();
            if (employeeId is null)
            {
                ShowError(MessageDescription.Error);
                return response.Error(MessageDescription.Error).Build();
            }

            var employeeName = await _employeeManager.GetNameAsync();

            input.EmployeesFioAdd = employeeName;

            response = await _referencesService.UploadInformationFilesAsync(input);

            return response;
        }

        [HttpPost]
        public async Task InformationFileRemoveAsync(Guid id)
        {
            try
            {
                await _referencesService.RemoveInformationFileAsync(id);
                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
