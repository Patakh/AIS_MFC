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
        public async Task<IActionResult> ServiceSmev(Guid id)
        {
            var serviceNameSmall = await _referencesService.GetServiceAnyAsync(id);
            if (serviceNameSmall is false) return NotFound();
            ViewData["Id"] = id;

            var modelBuilder = new ViewModelBuilder()
                .AddViewDescription("СМЭВ")
                .SetElementName(nameof(ServiceSmev))
                .AddTableMethodAction(Url.Action(nameof(GetServiceSmevDataJson), new { id = id }))
                .AddEditMethodAction(Url.Action(nameof(ServiceSmevChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(ServiceSmevRemove)));

            return PartialView("Services/Details/Smev", modelBuilder);
        }

        public async Task<IActionResult> GetServiceSmevDataJson(IDataTablesRequest request, Guid id)
        {

            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetServiceSmevRequests(request, id);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> ServiceSmevChangeModal(Guid? id, Guid serviceId, ActionType actionType)
        {
            var smevRequests = await _referencesService.GetAllSmevRequestsAsync();

            //исключить уже добавленных
            var added = _referencesService.GetAllServiceSmevRequests(serviceId);
            if (id is null)
            {
                // добавление
                smevRequests.RemoveAll(x => added.Where(x => x.SServicesId == serviceId).Select(o => o.SSmevRequestId).ToArray().Contains(x.Id));
            }
            else
            {
                // измениние
                smevRequests.RemoveAll(x => added.Where(x => x.Id != id && x.SServicesId == serviceId).Select(o => o.SSmevRequestId).ToArray().Contains(x.Id));
                if (smevRequests.Count == 0)
                {
                    //smevRequests.Add(added.FirstOrDefault(x => x.Id == id) switch
                    //{
                    //    ServiceSmevDto currentItem => new SmevRequestDto { Id = currentItem.SSmevRequestId, RequestName = currentItem.RequestName },
                    //    _ => throw new Exception()
                    //});
                    var currentItem = added.FirstOrDefault(x => x.Id == id);
                    smevRequests.Add(new ServiceSmevRequestDto { Id = currentItem.SSmevRequestId, RequestName = currentItem.RequestName });
                }
            }
            // ***************************************************
            ViewBag.SmevRequests = new SelectList(smevRequests, nameof(ServiceSmevRequestDto.Id), nameof(ServiceSmevRequestDto.RequestName));

            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new ServiceSmevRequestModelDto() { SServicesId = serviceId } : await _referencesService.GetServiceSmevRequestAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " запроса СМЭВ")
                .AddModalViewPath("~/Views/Reference/Services/Details/Modals/_ModalChangeServiceSmev.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task ServiceSmevRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveServiceSmevRequestAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceSmevSaveAsync(ServiceSmevRequestModelDto input, ActionType actionType)
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
                    await _referencesService.AddServiceSmevRequestAsync(input);

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
                    await _referencesService.UpdateServiceSmevRequestAsync(input);
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
