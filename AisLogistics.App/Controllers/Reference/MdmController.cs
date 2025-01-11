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
        [Breadcrumb("МДМ", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult Mdm()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("МДМ").SetInvisibleViewTitle()
                .AddViewDescription("МДМ")
                .AddTableMethodAction(Url.Action(nameof(GetMdmDataJson)))
                .AddEditMethodAction(Url.Action(nameof(MdmChangeModal)));
            return View("Mdm/Index", modelBuilder);
        }

        public async Task<IActionResult> GetMdmDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetMdm(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> MdmChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new MdmModelDto() : await _referencesService.GetMdmDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " МДМ")
                .AddModalViewPath("~/Views/Reference/Mdm/_ModalChangeMdm.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);

            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task MdmSaveAsync(MdmModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Edit)
            {
                try
                {
                    await _referencesService.UpdateMdmAsync(input);

                    ShowSuccess(MessageDescription.AddSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }
    }
}

