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
        public async Task<IActionResult> ServiceQualityTypes(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("Способы оценки")
                .SetElementName(nameof(ServiceQualityTypes))
                .AddTableMethodAction(Url.Action(nameof(GetServiceQualitiesDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceQualitiesChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceQualityTypeRemove)));

            return PartialView("Services/Details/Qualities", modelBuilder);
        }

        public async Task<IActionResult> GetServiceQualitiesDataJson(IDataTablesRequest request, Guid id)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceQualityTypes(request, id);
            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);
            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceQualitiesChangeModal(Guid? id, Guid serviceId, ActionType actionType)
        {
            var qualityTypes = await _referencesService.GetAllQualityTypesAsync();

            //исключить уже добавленных
            var added = _referencesService.GetAllServiceQualityTypes(serviceId);
            if (id is null)
            {
                // добавление
                qualityTypes.RemoveAll(x => added.Where(x => x.SServicesId == serviceId).Select(a => a.SServicesTypeQualityId).ToArray().Contains(x.Id));
            }
            else
            {
                // измениние
                qualityTypes.RemoveAll(x => added.Where(x => x.Id != id && x.SServicesId == serviceId).Select(a => a.SServicesTypeQualityId).ToArray().Contains(x.Id));
            }
            // *****************************************************
            ViewBag.QualityTypes = new SelectList(qualityTypes, nameof(QualityTypeDto.Id), nameof(QualityTypeDto.TypeName));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new ServiceQualityTypeModelDto() { SServicesId = serviceId } : await _referencesService.GetServiceQualityTypeDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " способы оценки")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceQyalityType.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task ServiceQualityTypeRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceQualityTypeAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceQualityTypeSaveAsync(ServiceQualityTypeModelDto input, ActionType actionType)
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
                    await _referencesService.AddServiceQualityTypeAsync(input);

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
                    await _referencesService.UpdateServiceQualityTypeAsync(input);
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
