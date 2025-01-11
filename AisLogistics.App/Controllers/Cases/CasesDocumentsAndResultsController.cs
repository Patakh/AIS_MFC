using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sentry;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        #region Document

        public async Task<IActionResult> ServiceDocuments(Guid id)
        {
            ViewBag.Id = id;
            var documents = await _caseService.GetDocumentsByServiceIdAsync(id);
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Документы")
                .AddModel(documents);
            return PartialView("Details/Sidebar/_SidebarDocuments", modelBuilder);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceDocumentsJson(Guid id)
        {
            var documents = await _caseService.GetDocumentsByServiceIdAsync(id);
            return Json(documents);
        }

        public async Task<IActionResult> ServiceDocumentAddModal(Guid id, Guid documentId, DocumentFileAddType fileAddType)
        {
            var model = new CaseServicesDocumentAddModalDto(id, documentId, fileAddType);
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.LARGE)
                .AddModalViewPath("Details/Modals/_ModalDocumentAdd")
                .AddModalTitle("Добавление документа")
                .AddModel(model);

            if (fileAddType == DocumentFileAddType.Desktop)
                modelBuilder.HideSubmitButton();

            return await Task.Run(()=>ModalLayoutView(modelBuilder));
        }

        [HttpPost]
        public async Task<bool> ServiceDocumentIsCheckSave(Guid documentId, bool isCheck)
        {
            return await _caseService.UploadServicesDocumentsIsCheckAsync(documentId, isCheck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ServiceFileResponseModel> ServiceDocumentSave(Guid documentId, DocumentFileAddType fileAddType, IFormFile file)
        {
            return await _caseService.UploadServicesFileAsync(documentId, fileAddType, file);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ServiceFileResponseModel> ServiceDocumentsSave(Guid documentId, DocumentFileAddType fileAddType, IFormFileCollection files)
        {
            return await _caseService.UploadServicesFilesAsync(documentId, fileAddType, files);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ServiceFileResponseModel> ServiceDocumentRemove(Guid id)
        {
            var response = await _caseService.RemoveServicesFileAsync(id);
            if (response.ResponseStatus.IsSuccess) ShowSuccess("Запись удалена");
            else ShowError("Ошибка");

            return response;
        }

        public async Task<IActionResult> DownloadFileCase(Guid id, Models.DocumentType type)
        {
            var file = await _caseService.DownloadServicesFileAsync(id, type);
            if (file is null) return NotFound();
            return File(file.OpenReadStream(), file.ContentType, file.FileName);
        }


        public async Task ServiceDocumentRefresh(Guid serviceId)
        {
            try
            {
                var service = await _caseService.GetCasesServicesAsync(serviceId);
                if (service is null) throw new InvalidOperationException();
                var documentsService = await _caseService.GetDocumentsByServiceIdAsync(serviceId);
                var documentsReference = await _referencesService.GetAllServiceDocumentsAsync(service.ServiceId);
                documentsReference.RemoveAll(r=> documentsService.Any(a=>a.DocumentId==r.SDocumentsId));
                var documents = new List<ServiceDocumentsDto>();
                var date = DateTime.Now;
                documentsReference.ForEach(f =>
                {
                    documents.Add(new ServiceDocumentsDto
                    {
                        ServiceId = serviceId,
                        CasesId = service.CaseId,
                        DocumentId = f.SDocumentsId,
                        DocumentCount = f.DocumentCount,
                        DocumentNeeds = f.DocumentNeeds,
                        DocumentType = f.DocumentType,  
                        DateAdd = date,
                    });
                });

                await _caseService.DocumentServiceAddSave(documents);
                ShowSuccess("Документы обновлены");
            }
            catch (Exception ex)
            {
                ShowError("Обновление документов невозможно");
            }

        } 

        public async Task<IActionResult> ServiceDocumentNewAddModal(Guid serviceId)
        {
            var documentsReference = await _referencesService.GetAllDocumentsAsync();
            var documentsService = await _caseService.GetDocumentsByServiceIdAsync(serviceId);
            var docService = documentsService.First();
            documentsReference.RemoveAll(r => documentsService.Any(a => a.DocumentId == r.Id));
            ViewBag.Documents =new SelectList(documentsReference, "Id", "Name");
            var model = new ServiceDocumentsDto { CasesId= docService.CaseId, ServiceId = serviceId };
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.LARGE)
                .AddModalViewPath("Details/Modals/_ModalServiceDocumentAdd")
                .AddModalTitle("Добавление документа")
                .AddModel(model);
            return await Task.Run(() => ModalLayoutView(modelBuilder));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceDocumentNewSave(ServiceDocumentsDto request)
        {
            try
            {
                var empoyee = await _employeeManager.GetEmployeeAsync();
                request.SEmployeesId = empoyee.Id;
                request.EmployeesFioAdd = empoyee.Name;
                request.DateAdd = DateTime.Now;
                await _caseService.DocumentServiceAddSave(request);
                ShowSuccess("Документ добавлен");
            }
            catch
            {
                ShowError("Добавления документа невозможно");
            }
        }

        public async Task<IActionResult> ServiceDocumentNewNameAddModal(Guid documentId)
        {
            var document = await _caseService.GetServiceDocumentsIdAsync(documentId);
            var model = new ServiceDocumentNewNameDto { Id = documentId };
            if(document != null&& document.Commentt != null)
            {
                model.Commentt = document.Commentt;
            }
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.LARGE)
                .AddModalViewPath("Details/Modals/_ModalServiceDocumentNewNameAdd")
                .AddModalTitle("Редактирование документа")
                .AddModel(model);
            return await Task.Run(() => ModalLayoutView(modelBuilder));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceDocumentNewNameSave(ServiceDocumentNewNameDto request)
        {
            try
            {
                await _caseService.DocumentServiceAddNewNameSave(request);
                ShowSuccess("Описание добавлено");
            }
            catch
            {
                ShowError("Описание документа невозможно");
            }
        }

        #endregion

        #region DocumentResult

        public async Task<IActionResult> ServiceDocumentsResults(Guid id)
        {
            ViewBag.Id = id;
            var documents = await _caseService.GetDocumentsResultsByServiceIdAsync(id);
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Результат")
                .AddModel(documents);
            return PartialView("Details/Sidebar/_SidebarDocumentsResults", modelBuilder);
        }

        public async Task<IActionResult> ServiceDocumentResultAddModal(Guid id, Guid documentId, DocumentFileAddType fileAddType)
        {
            ViewBag.Id = id;
            var model = new CaseServicesDocumentResultsAddModalDto(id, documentId, fileAddType);
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.LARGE)
                .AddModalViewPath("Details/Modals/_ModalDocumentResultAdd")
                .AddModalTitle("Добавление результата")
                .HideSubmitButton()
                .AddModel(model);
            return await Task.Run(() => ModalLayoutView(modelBuilder));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ServiceFileResponseModel> ServiceDocumentResultSave(Guid documentId, DocumentFileAddType fileAddType, IFormFile file)
        {
            return await _caseService.UploadServicesFileResultAsync(documentId, fileAddType, file);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ServiceFileResponseModel> ServiceDocumentResultRemove(Guid id)
        {
            var response = await _caseService.RemoveServicesFileResultAsync(id);
            if (response.ResponseStatus.IsSuccess) ShowSuccess("Запись удалена");
            else ShowError("Ошибка");

            return response;
        }

        #endregion
    }
}
