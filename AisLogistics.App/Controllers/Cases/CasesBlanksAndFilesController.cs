using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Utils;
using System.Globalization;

namespace AisLogistics.App.Controllers.Cases;

public partial class CasesController
{
    public async Task<IActionResult> BlanksListModal(Guid id)
    {
        var blanks = await _caseService.GetServiceBlanksByCaseIdAsync(id) ?? new List<CaseServiceBlank>();

        var modelBuilder = new ViewModelBuilder()
               .AddViewTitle("Бланки")
               .AddModel(blanks);
        return PartialView("Details/Modals/_ModalBlanksList", modelBuilder);

    }

    public async Task<IActionResult> FilesListModal(Guid id)
    {
        var blanks = await _caseService.GetServiceFilesByCaseIdAsync(id) ?? new List<CaseServiceBlank>(); ;

        var modelBuilder = new ViewModelBuilder()
               .AddViewTitle("Файлы")
               .AddModel(blanks);
        return PartialView("Details/Modals/_ModalFilesList", modelBuilder);
    }

    //TODO полностью переделать, временно 
    public async Task<IActionResult> DownloadBlank(Guid id, Guid serviceId, BlankActionType typeDownloadBlank = BlankActionType.Pdf)
    {
        try
        {
            var file = await _caseService.GetServiceBlankByIdAsync(id);
            if (file is null) 
            {
                return NotFound(); 
            }

            if (file.Expansion.ToLower(CultureInfo.InvariantCulture) == ".frx")
            {
                try
                {
                    var content = _caseService.GetBlancFastReportFileAsync(file.Content, serviceId, typeDownloadBlank);
                    if (typeDownloadBlank == BlankActionType.Pdf)
                    {
                        return PdfLayoutView(content);
                    }
                    if (typeDownloadBlank == BlankActionType.Word)
                    {
                        return File(content, MimeTypeMap.GetMimeType("docx"), $"{file.Name}.{"docx"}");
                    }
                    else throw new InvalidOperationException("Неопределенный формат бланка");
                }
                catch(Exception ex)
                {
                    return Problem();
                }
            }
            else if (file.Expansion.ToLower(CultureInfo.InvariantCulture) == ".docx")
            {
                var content = _caseService.GetBlancDocxFileAsync(file.Content, serviceId);
                if (content is null) { ShowError(MessageDescription.Error); return NotFound(); }
                return File(content, MimeTypeMap.GetMimeType(file.Expansion), $"{file.Name}.docx");
            }
            else if (file.Expansion.ToLower(CultureInfo.InvariantCulture) == ".doc")
            {
                var content = _caseService.GetBlancDocxFileAsync(file.Content, serviceId);
                if (content is null) { ShowError(MessageDescription.Error); return NotFound(); }
                return File(content, MimeTypeMap.GetMimeType(file.Expansion), $"{file.Name}.doc");
            }
            else if (file.Expansion.ToLower(CultureInfo.InvariantCulture) == ".pdf")
            {
                return PdfLayoutView(file.Content);
            }
            else
            {
                return File(file.Content, MimeTypeMap.GetMimeType(file.Expansion), $"{file.Name}.{file.Expansion}");
            };
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    public async Task<IActionResult> DownloadFile(Guid id, Guid? serviceId)
    {
        try
        {
            var file = await _caseService.GetServiceFileByIdAsync(id);
            if (file is null)
            {
                ShowError("Файл не найден");
                return NotFound();
            }

            if (file.Expansion == ".pdf" && file.Size < 1500000)
            {
                return PdfLayoutView(file.Content);
            }
            else
            {
                return File(file.Content, MimeTypeMap.GetMimeType(file.Expansion), $"{file.Name}.{file.Expansion}");
            }
        }
        catch (Exception e)
        {
            ShowError(e.Message);
            return NotFound();
        }
    }
}