using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Utils;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult> PrintProcessingPersonalData(string id)
        {
            var content = await _caseService.GetPrintProcessingPersonalData(id, BlankActionType.Pdf);
            return PdfLayoutView(content);
        }

        public async Task<IActionResult> DownloadProcessingPersonalData(string id)
        {
            try
            {
                var content = await _caseService.GetPrintProcessingPersonalData(id, BlankActionType.Word);
                return File(content, MimeTypeMap.GetMimeType(".docx"), "Согласие на ОПД.docx");
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
                return Problem();
            }
        }

        public async Task<IActionResult> PrintConsultationService(string id)
        {
            var content = await _caseService.GetPrintConsultationService(id, BlankActionType.Pdf);
            return PdfLayoutView(content);
        }

        public async Task<IActionResult> DownloadConsultationService(string id)
        {
            try
            {
                var content = await _caseService.GetPrintConsultationService(id, BlankActionType.Word);
                return File(content, MimeTypeMap.GetMimeType(".docx"), "Консультация.docx");
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
                return Problem();
            }
        }

        public async Task<IActionResult> ModalPrintAcceptDocuments(string id)
        {
            ViewBag.Id = id;
            var documents = await _caseService.GetDocumentsByServiceIdAsync(id);

            var modelBuilder = new ModalViewModelBuilder()
             .AddModalType(ModalType.EXTRA)
             .AddModalViewPath("Details/Modals/_ModalPrintAcceptDocuments")
             .AddModel(documents)
             .HideSubmitButton()
             .HideModalFooter()
             .AddModalTitle("Расписка о принятие документов");

            return ModalLayoutView(modelBuilder);
        }

        public async Task<string?> PrintAcceptDocuments(string id, List<DocumentsPrintDto> doc)
        {
            try
            {
                var content = await _caseService.GetPrintAcceptDocuments(id, BlankActionType.Pdf, doc);
                return Convert.ToBase64String(content);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return null;
            }
        }

        public async Task<IActionResult> DownloadAcceptDocuments(string id, List<DocumentsPrintDto> doc)
        {
            try
            {
                var content = await _caseService.GetPrintAcceptDocuments(id, BlankActionType.Word, doc);
                return File(content, MimeTypeMap.GetMimeType(".docx"), "Реестр о принятие документов.docx");
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
                return Problem();
            }
        }

        public async Task<IActionResult> ModalPrintIssuanceDocuments(string id)
        {
            ViewBag.Id = id;
            var documents = await _caseService.GetDocumentsIssuanceByServiceIdAsync(id);

            var modelBuilder = new ModalViewModelBuilder()
             .AddModalType(ModalType.EXTRA)
             .AddModalViewPath("Details/Modals/_ModalPrintIssuanceDocuments")
             .AddModel(documents)
             .HideSubmitButton()
             .HideModalFooter()
             .AddModalTitle("Расписка о выдаче документов");

            return ModalLayoutView(modelBuilder);
        }

        public async Task<string?> PrintIssuanceDocuments(string id, List<DocumentsPrintDto> doc)
        {
            try
            {
                var content = await _caseService.GetPrintIssuanceDocuments(id, BlankActionType.Pdf, doc);
                return Convert.ToBase64String(content);
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
                return null;
            }
        }

        public async Task<IActionResult> DownloadIssuanceDocuments(string id, List<DocumentsPrintDto> doc)
        {
            try
            {
                var content = await _caseService.GetPrintIssuanceDocuments(id, BlankActionType.Word, doc);
                return File(content, MimeTypeMap.GetMimeType(".docx"), "Реестр выдачи документов.docx");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return Problem();
            }
        }
    }
}
