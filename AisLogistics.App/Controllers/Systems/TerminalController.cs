using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Systems;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Systems
{
    public partial class SystemsController
    {
        [Breadcrumb("Терминалы", FromAction = nameof(Index), FromController = typeof(SystemsController))]
        public IActionResult Terminals()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Терминалы").SetInvisibleViewTitle()
                .AddViewDescription("Терминалы оплаты")
                .AddTableMethodAction(Url.Action(nameof(GetTerminalsDataJson)))
                .AddEditMethodAction(Url.Action(nameof(TerminalChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(TerminalRemove)));
            return View("Terminals/Index", modelBuilder);
        }

        public async Task<IActionResult> GetTerminalsDataJson(IDataTablesRequest request)
        {

            (var responseData, int totalCount, int filteredCount) = await _systemsService.GetTerminal(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> TerminalChangeModal(Guid id, ActionType actionType)
        {
            ViewBag.Offices = new SelectList(await _filterManager.GetOfficesReceptionAllCustomerDataJson(false,false), nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName));

            var model = new ModalViewModelBuilder()
                 .AddModel(actionType == ActionType.Add ? new TerminalModelDto() : await _systemsService.GetTerminalDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " терминала")
                .AddModalViewPath("~/Views/Systems/Terminals/_ModalChangeTerminal.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        public async Task TermianlSaveAsync(TerminalModelDto model, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
                {
                    await _systemsService.AddTerminalAsync(model);
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
                    await _systemsService.UpdateTerminalAsync(model);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        [HttpPost]
        public async Task TerminalRemove(Guid id, string comment)
        {
            try
            {
                await _systemsService.RemoveTerminalAsync(id, comment);
                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

    }
}
