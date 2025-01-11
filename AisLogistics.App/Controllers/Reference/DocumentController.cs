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
        [Breadcrumb("Документы", FromAction = nameof(Index), FromController = typeof(ReferenceController))]
        public IActionResult Documents()
        {
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Документы").SetInvisibleViewTitle()
                .AddViewDescription("Справочник документов необходимых для оказания услуги")
                .AddTableMethodAction(Url.Action(nameof(GetDocumentsDataJson)))
                .AddEditMethodAction(Url.Action(nameof(DocumentChangeModal)))
                .AddRemoveMethodAction(Url.Action(nameof(DocumentRemove)));
            return View("Documents/Index", modelBuilder);
        }

        public async Task<IActionResult> GetDocumentsDataJson(IDataTablesRequest request)
        {
            (var responseData, int totalCount, int filteredCount) = await _referencesService.GetDocuments(request);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> DocumentChangeModal(Guid? id, ActionType actionType)
        {
            var model = new ModalViewModelBuilder()
                .AddModel(actionType == ActionType.Add ? new DocumentModelDto() : await _referencesService.GetDocumentsDtoAsync(id))
                .AddModalTitle((actionType == ActionType.Add ? "Добавление" : "Изменение") + " документа")
                .AddModalViewPath("~/Views/Reference/Documents/_ModalChangeDocument.cshtml")
                .AddActionType(actionType)
                .AddModalType(ModalType.LARGE);
            return ModalLayoutView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task DocumentSaveAsync(DocumentModelDto input, ActionType actionType)
        {
            if (actionType == ActionType.Add)
            {
                try
                {
                    await _referencesService.AddDocumentAsync(input);
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
                    await _referencesService.UpdateDocumentAsync(input);
                    ShowSuccess(MessageDescription.EditSuccess);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task DocumentRemove(Guid id, string comment)
        {
            try
            {
                await _referencesService.RemoveDocumentAsync(id, comment);

                ShowSuccess(MessageDescription.RemoveSuccess);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
