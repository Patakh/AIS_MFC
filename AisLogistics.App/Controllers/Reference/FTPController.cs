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
        [Breadcrumb("FTP", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult FTP()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("FTP").SetInvisibleViewTitle()
                .AddViewDescription("Справочник FTP")
                .AddTableMethodAction(Url.Action(nameof(GetFTPDataJson)))
                .AddEditMethodAction(Url.Action(nameof(FTPChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(FTPRemove)));
            return View("FTP/Index", modelBuilder);
        }

        public async Task<IActionResult> GetFTPDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetFTP(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> FTPChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new FtpModelDto() : await _referencesService.GetFTPDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " FTP")
                .AddModalViewPath("~/Views/Reference/FTP/_ModalChangeFTP.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);

            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task FTPSaveAsync(FtpModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
                {
                    await _referencesService.AddFTPAsync(input);

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
                    await _referencesService.UpdateFTPAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }


        [HttpPost]
        public async Task FTPRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveFTPAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
