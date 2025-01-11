using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Models.Enums;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FastReport.Export.OoXML;
using FastReport.Export.Pdf;
using FastReport.Utils;
using FastReport.Web;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Z.EntityFramework.Plus;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;

namespace AisLogistics.App.Service
{
    public partial class CaseService : ICaseService
    {
        private Dictionary<string, string>? GetBlankMarks(Guid id)
        {
            try
            {
                return _context.BlanksMarks
                    .FromSqlInterpolated($"select * from core.blank_info_select({id})")
                    .ToDictionary(keySelector: d => d.Name.Trim(new Char[] { '[', ']' }), elementSelector: d => d.Value);
            }
            catch(Exception ex)
            {
                return null;
            }

        }
        public byte[]? GetBlancDocxFileAsync(byte[] content, Guid serviceId)
        {
            Dictionary<string, string>? marks = GetBlankMarks(serviceId);
            if (marks == null) throw new ArgumentException("Ошибка при создание бланка");

            MemoryStream stream = new MemoryStream();
            stream.Write(content, 0, content.Length);
            stream.Seek(0, SeekOrigin.Begin);

            using (WordprocessingDocument document = WordprocessingDocument.Open(stream, true, new OpenSettings { AutoSave = true }))
            {
                Body documentBody = document.MainDocumentPart.Document.Body;
                List<Paragraph> paragraphsWithMarks = documentBody.Descendants<Paragraph>().Where(x => Regex.IsMatch(x.InnerText, @".*\[+\w+(\&?\d)?\].*")).ToList();
                foreach (Paragraph paragraph in paragraphsWithMarks)
                {
                    foreach (Match markMatch in Regex.Matches(paragraph.InnerText, @"\[+\w+(\&?\d)?\]", RegexOptions.Compiled))
                    {
                        string paragraphMarkValue = markMatch.Value.Trim(new[] { '[', ']' });
                        string markValueFromCollection;
                        var markMatchSplit = paragraphMarkValue.Split('&'); // разбиваем метку в бланке                            
                        if (markMatchSplit.Length < 2) // проверяем на наличие метки которую необходимо заполнить побуквенно
                        {
                            if (marks.TryGetValue(paragraphMarkValue, out markValueFromCollection))
                            {
                                string editedParagraphText = paragraph.InnerText.Replace(markMatch.Value, markValueFromCollection);
                                paragraph.RemoveAllChildren<Run>();
                                paragraph.AppendChild(new Run(new Text(editedParagraphText)));
                            }
                        }
                        else
                        {
                            if (marks.TryGetValue(markMatchSplit[0], out markValueFromCollection))
                            {
                                if (int.TryParse(markMatchSplit[1], out int apex))
                                {
                                    var markChar = markValueFromCollection?.Length >= int.Parse(markMatchSplit[1]) ? markValueFromCollection.ToCharArray()[(int.Parse(markMatchSplit[1]) - 1)].ToString() : "";
                                    string editedParagraphText = paragraph.InnerText.Replace(markMatch.Value, markChar);
                                    paragraph.RemoveAllChildren<Run>();
                                    paragraph.AppendChild(new Run(new Text(editedParagraphText)));
                                }

                            }
                        }
                    }
                }
            }

            stream.Position = 0;
            return stream.ToArray();
        }

        public async Task<List<CaseServiceBlank>?> GetServiceBlanksByCaseIdAsync(Guid id)
        {
            return await _context.DServices
                .AsNoTracking()
                .Where(f => f.Id == id)
                .Select(s => s.SServices.SServicesForms
                .Where(w => !w.IsRemove && (!w.SServicesProcedureId.HasValue || w.SServicesProcedureId == s.SServicesProcedureId))
                .Select(ss => new CaseServiceBlank
                {
                    Id = ss.Id,
                    ServiceId = s.Id,
                    Name = ss.FileName,
                    Expansion = ss.FileExpansion,
                    Comment = ss.Commentt
                }).ToList())
                .FirstOrDefaultAsync();
        }

        public async Task<CaseServiceBlankFile> GetServiceBlankByIdAsync(Guid id)
        {
            return await _context.SServicesForms
                .AsNoTracking()
                .Select(s=> new CaseServiceBlankFile
                {
                    Id = s.Id,
                    Name = s.FileName,
                    Expansion = s.FileExpansion,
                    Content = s.File,
                    Size = s.FileSize
                })
                .FirstOrDefaultAsync(f=>f.Id==id) ?? throw new ArgumentException("Бланк не найден");
        }

        public async Task<List<CaseServiceBlank>?> GetServiceFilesByCaseIdAsync(Guid id)
        {
            return await _context.DServices
              .AsNoTracking()
              .Where(f => f.Id == id)
              .Select(s => s.SServices.SServicesFiles
                              .Where(w => !w.IsRemove && (!w.SServicesProcedureId.HasValue || w.SServicesProcedureId == s.SServicesProcedureId))
                              .Select(ss => new CaseServiceBlank
                              {
                                  Id = ss.Id,
                                  ServiceId = s.Id,
                                  Name = ss.FileName,
                                  Expansion = ss.FileExpansion,
                                  Comment = ss.Commentt
                              }).ToList()
               )
              .FirstOrDefaultAsync();
        }

        public async Task<CaseServiceBlankFile> GetServiceFileByIdAsync(Guid id)
        {
            return await _context.SServicesFiles
                .AsNoTracking()
                .Select(s=> new CaseServiceBlankFile
                {
                    Id = s.Id,
                    Name = s.FileName,
                    Expansion = s.FileExpansion,
                    Content = s.File,
                    Size = s.FileSize
                }).FirstOrDefaultAsync(f=>f.Id==id) ?? throw new InvalidOperationException("Файл не найден");
        }

        public byte[] GetBlancFastReportFileAsync(byte[] content, Guid serviceId, BlankActionType blankActionType)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");

            RegisteredObjects.AddConnection(typeof(FastReport.Data.PostgresDataConnection));

            var rep = new WebReport();
            rep.Report.Load(new MemoryStream(content));
            rep.Report.SetParameterValue("ServiceId", serviceId.ToString());
            if (rep.Report.Dictionary.Connections.Count != 0)
            {
                rep.Report.Dictionary.Connections[0].ConnectionString = connection;
            }

            var isPrepare = rep.Report.Prepare();

            if (!isPrepare) throw new ArgumentException("Ошибка при создание бланка");

            var strm = new MemoryStream();

            switch (blankActionType)
            {
                case BlankActionType.Pdf:
                    var pdfExport = new PDFExport();
                    rep.Report.Export(pdfExport, strm);
                    pdfExport.Dispose();
                    break;
                case BlankActionType.Word:
                    var wordExport = new Word2007Export();
                    rep.Report.Export(wordExport, strm);
                    wordExport.Dispose();
                    break;
                default: break;
            }

            rep.Report.Dispose();

            return strm.ToArray();
        }

        public async Task<byte[]> GetPrintProcessingPersonalData(string caseId, BlankActionType type)
        {
            var service = await _context.DServices
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.DCasesId == caseId && f.DServicesIdParent == Guid.Empty);

            if (service is null) throw new ArgumentException("Услуга не найдена");

            var form = await _context.SForms.AsNoTracking().FirstOrDefaultAsync(f=>f.Id==2);

            if (form is null) throw new ArgumentException("Бланк не найден");

            var content = form.File;

            var connection = _configuration.GetConnectionString("DefaultConnection");

            RegisteredObjects.AddConnection(typeof(FastReport.Data.PostgresDataConnection));

            var rep = new WebReport();
            rep.Report.Load(new MemoryStream(content));
            rep.Report.SetParameterValue("ServiceId", service.Id.ToString());
            if (rep.Report.Dictionary.Connections.Count != 0)
            {
                rep.Report.Dictionary.Connections[0].ConnectionString = connection;
            }

            var isPrepare = rep.Report.Prepare();

            if (!isPrepare) throw new ArgumentException("Ошибка при создание бланка");

            var strm = new MemoryStream();

            switch (type)
            {
                case BlankActionType.Pdf:
                    var pdfExport = new PDFExport();
                    rep.Report.Export(pdfExport, strm);
                    pdfExport.Dispose();
                    break;
                case BlankActionType.Word:
                    var wordExport = new Word2007Export();
                    rep.Report.Export(wordExport, strm);
                    wordExport.Dispose();
                    break;
                default: break;
            }

            rep.Report.Dispose();

            return strm.ToArray();
        }

        public async Task<byte[]> GetPrintConsultationService(string caseId, BlankActionType type)
        {
            var service = await _context.DServices
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.DCasesId == caseId && f.DServicesIdParent == Guid.Empty);

            if (service is null) throw new ArgumentException("Услуга не найдена");

            var mfcName = await _employeeManager.GetOfficeNameAsync();

            var form = await _context.SForms.AsNoTracking().FirstOrDefaultAsync(f=>f.Id==6);

            if (form is null) throw new ArgumentException("Бланк не найден");

            var content = form.File;

            var connection = _configuration.GetConnectionString("DefaultConnection");

            RegisteredObjects.AddConnection(typeof(FastReport.Data.PostgresDataConnection));

            var rep = new WebReport();
            rep.Report.Load(new MemoryStream(content));
            rep.Report.SetParameterValue("ServiceId", service.SServicesId.ToString());
            rep.Report.SetParameterValue("MfcName", mfcName);
            if (rep.Report.Dictionary.Connections.Count != 0)
            {
                rep.Report.Dictionary.Connections[0].ConnectionString = connection;
            }

            var isPrepare = rep.Report.Prepare();

            if (!isPrepare) throw new ArgumentException("Ошибка при создание бланка");

            var strm = new MemoryStream();

            switch (type)
            {
                case BlankActionType.Pdf:
                    var pdfExport = new PDFExport();
                    rep.Report.Export(pdfExport, strm);
                    pdfExport.Dispose();
                    break;
                case BlankActionType.Word:
                    var wordExport = new Word2007Export();
                    rep.Report.Export(wordExport, strm);
                    wordExport.Dispose();
                    break;
                default: break;
            }

            rep.Report.Dispose();

            return strm.ToArray();
        }

        public async Task<byte[]> GetPrintAcceptDocuments(string caseId, BlankActionType type, List<DocumentsPrintDto> doc)
        {
            var documentsIsCheck = await UploadServicesDocumentsIsCheckAsync(doc);

            if (!documentsIsCheck) throw new InvalidOperationException("Ошибка при обработке документа");
          
            var form = await _context.SForms.AsNoTracking().FirstOrDefaultAsync(f => f.Id == 3);

            if (form is null) throw new ArgumentException("Бланк не найден");

            var content = form.File;

            var employee = await _employeeManager.GetFullInfoAsync();

            var connection = _configuration.GetConnectionString("DefaultConnection");

            RegisteredObjects.AddConnection(typeof(FastReport.Data.PostgresDataConnection));

            var rep = new WebReport();
            rep.Report.Load(new MemoryStream(content));
            rep.Report.SetParameterValue("ServiceId", caseId);
            rep.Report.SetParameterValue("EmployeeName", employee.Name);
            rep.Report.SetParameterValue("OfficeName", employee.Office.Name);
            rep.Report.SetParameterValue("JobPositionName", employee.Job.Name);
            if (rep.Report.Dictionary.Connections.Count != 0)
            {
                rep.Report.Dictionary.Connections[0].ConnectionString = connection;
            }

            var isPrepare = rep.Report.Prepare();

            if (!isPrepare) throw new ArgumentException("Ошибка при создание бланка");

            var strm = new MemoryStream();

            switch (type)
            {
                case BlankActionType.Pdf:
                    var pdfExport = new PDFExport();
                    rep.Report.Export(pdfExport, strm);
                    pdfExport.Dispose();
                    break;
                case BlankActionType.Word:
                    var wordExport = new Word2007Export();
                    rep.Report.Export(wordExport, strm);
                    wordExport.Dispose();
                    break;
                default: break;
            }

            rep.Report.Dispose();

            return strm.ToArray();
        }
        public async Task<byte[]> GetPrintIssuanceDocuments(string caseId, BlankActionType type, List<DocumentsPrintDto> doc)
        {
            var documentsIsCheck = await UploadServicesDocumentsIssuanceIsCheckAsync(doc);

            if (!documentsIsCheck) throw new InvalidOperationException("Ошибка при обработке документа");

            var form = await _context.SForms.AsNoTracking().FirstOrDefaultAsync(f => f.Id == 4);

            if (form is null) throw new ArgumentException("Бланк не найден");

            var content = form.File;

            var employeeName = await _employeeManager.GetNameAsync();

            var connection = _configuration.GetConnectionString("DefaultConnection");

            RegisteredObjects.AddConnection(typeof(FastReport.Data.PostgresDataConnection));

            var rep = new WebReport();
            rep.Report.Load(new MemoryStream(content));
            rep.Report.SetParameterValue("ServiceId", caseId);
            rep.Report.SetParameterValue("EmployeeFio", employeeName);
            if (rep.Report.Dictionary.Connections.Count != 0)
            {
                rep.Report.Dictionary.Connections[0].ConnectionString = connection;
            }

            var isPrepare = rep.Report.Prepare();

            if (!isPrepare) throw new ArgumentException("Ошибка при создание бланка");

            var strm = new MemoryStream();

            switch (type)
            {
                case BlankActionType.Pdf:
                    var pdfExport = new PDFExport();
                    rep.Report.Export(pdfExport, strm);
                    pdfExport.Dispose();
                    break;
                case BlankActionType.Word:
                    var wordExport = new Word2007Export();
                    rep.Report.Export(wordExport, strm);
                    wordExport.Dispose();
                    break;
                default: break;
            }

            rep.Report.Dispose();

            return strm.ToArray();
        }
    }
}
