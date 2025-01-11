using AisLogistics.App.Extensions;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Service.MDM;
using AisLogistics.App.Settings;
using AisLogistics.App.Utils;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.DataLayer.Common.Dto.Case;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using AisLogistics.DataLayer.Utils;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;
using System.Xml;

namespace AisLogistics.App.Service
{
    public partial class SmevService : ISmevService
    {
        private readonly IMdmService _mdmService;
        private readonly AisLogisticsContext _context;
        private readonly IEmployeeManager _employeeManager;

        public SmevService(AisLogisticsContext context, IEmployeeManager employeeManager, IMdmService mdmService, IOptions<SmevSettings> smevOptions)
        {
            _context = context;
            _employeeManager = employeeManager;
            _mdmService = mdmService;
            SmevClient.Init(smevOptions.Value.SmevConnection, smevOptions.Value.AuthCode);
        }


        private string SmevResponse<T>(T response) where T : SmevResponseData
        {
            if (response.ResponseReports is null || response.ResponseReports.Length == 0)
                throw new InvalidOperationException(response.Fault?.ErrorText);

            return response.ResponseReports
                .Where(w => w.ReportType == ResponseReportType.Full)
                .Select(s => "data:application/pdf;base64," + Convert.ToBase64String(s.PdfDocument))
                .First();
        }

        #region Details
        public string GetSmevFormById(int id)
        {
            var request = _context.SSmevRequests.Find(id);
            if (request is null || String.IsNullOrWhiteSpace(request.Path)) throw new ArgumentException(nameof(request));
            return request.SmevFormPath();
        }

        public CaseServiceSmevRequestDto GetSmevRequestById(Guid id)
        {
            return _context.DServicesSmevRequests
                .Select(s => new CaseServiceSmevRequestDto()
                {
                    Id = s.Id,
                    CountDayExecution = s.CountDayExecution,
                    DateAdd = s.DateAdd,
                    DateReg = s.DateReg,
                    DateRequest = s.DateFact,
                    Service = new ServiceDto(s.DServicesId, s.DServices.SServices.ServiceNameSmall,
                        s.DServices.SServices.SOffice.OfficeNameSmall, s.DServices.DateAdd),
                    Employee = new EmployeeDto(s.SEmployeesId, NameSplitter.GetInitials(s.EmployeesFioAdd),
                        s.SEmployeesJobPosition.JobPositionName)
                }).First(f => f.Id == id);
        }

        public CaseServiceSmevRequestDto GetArchiveSmevRequestById(Guid id)
        {
            return _context.AServicesSmevRequests
                .Select(s => new CaseServiceSmevRequestDto()
                {
                    Id = s.Id,
                    CountDayExecution = s.CountDayExecution,
                    DateAdd = s.DateAdd,
                    DateReg = s.DateReg.Value,
                    DateRequest = s.DateFact,
                    Service = new ServiceDto(s.AServicesId, s.AServices.SServices.ServiceNameSmall,
                        s.AServices.SServices.SOffice.OfficeNameSmall, s.AServices.DateAdd),
                    Employee = new EmployeeDto(s.SEmployeesId, NameSplitter.GetInitials(s.EmployeesFioAdd),
                        s.SEmployeesJobPosition.JobPositionName)
                }).First(f => f.Id == id);
        }

        public SmevDetailsResponseModel GetSmevResponse(Guid id)
        {
            var smevResponse = SmevClient.GetRequestResult(new SmevRequestData
            {
                DataServicesRequestSmevId = id.ToString()
            });
            var responseModel = new SmevDetailsResponseModel();

            if (smevResponse.ResponseReports is null) return responseModel.ResponseError(smevResponse.Fault?.ErrorText);

            var report = smevResponse.ResponseReports.First(s =>
                s.ReportType is ResponseReportType.Full || smevResponse.ResponseReports.Length < 2 &&
                s.ReportType is ResponseReportType.IntermediateResponse); // файл полного ответа

            responseModel.AddDocument(report.PdfDocument);
            responseModel.AddRequestInformation(GetSmevRequestById(id));

            var attachmentsReport = smevResponse.ExtractedResponseDocuments.FirstOrDefault();

            if (attachmentsReport is null) return responseModel;

            string attachments;
            if (attachmentsReport.MimeType == MimeTypeMap.GetMimeType("zip") ||
                attachmentsReport.MimeType == MimeTypeMap.GetMimeType("rar"))
            {
                Stream zipStream = new MemoryStream(attachmentsReport.FileContent) { Position = 0 };
                var pdfFromZip = ZipDecompress(zipStream).FirstOrDefault(f => f.Key.ToLower().Contains(".pdf")).Value;
                attachments = Convert.ToBase64String(pdfFromZip);
            }
            else
            {
                attachments = Convert.ToBase64String(attachmentsReport.FileContent);
            }

            return responseModel;
        }

        public SmevDetailsResponseModel GetArchiveSmevResponse(Guid id)
        {
            var smevResponse = SmevClient.GetRequestResult(new SmevRequestData
            {

                DataServicesRequestSmevId = id.ToString()
            });
            var responseModel = new SmevDetailsResponseModel();

            if (smevResponse.ResponseReports is null) return responseModel.ResponseError(smevResponse.Fault?.ErrorText);

            var report = smevResponse.ResponseReports.First(s =>
                s.ReportType is ResponseReportType.Full || smevResponse.ResponseReports.Length < 2 &&
                s.ReportType is ResponseReportType.IntermediateResponse); // файл полного ответа

            responseModel.AddDocument(report.PdfDocument);
            responseModel.AddRequestInformation(GetArchiveSmevRequestById(id));

            var attachmentsReport = smevResponse.ExtractedResponseDocuments.FirstOrDefault();

            if (attachmentsReport is null) return responseModel;

            string attachments;
            if (attachmentsReport.MimeType == MimeTypeMap.GetMimeType("zip") ||
                attachmentsReport.MimeType == MimeTypeMap.GetMimeType("rar"))
            {
                Stream zipStream = new MemoryStream(attachmentsReport.FileContent) { Position = 0 };
                var pdfFromZip = ZipDecompress(zipStream).FirstOrDefault(f => f.Key.ToLower().Contains(".pdf")).Value;
                attachments = Convert.ToBase64String(pdfFromZip);
            }
            else
            {
                attachments = Convert.ToBase64String(attachmentsReport.FileContent);
            }

            return responseModel;
        }

        public async Task<string> CreateNewSmevRequestAsync(Guid servicesId, int smevId, string comment, string idRef = null)
        {
            const int workDays = 1;
            var date = DateTime.Today;
            var currentEmployee = await _employeeManager.GetFullInfoAsync();

            //var service = await _context.FindAsync<DService>(servicesId);

            var service = await _context.DServices.Select(s => new { s.Id, s.DCasesId, s.SServicesProcedure.IsMdm }).FirstOrDefaultAsync(f => f.Id == servicesId);
            if (service is null) throw new ArgumentException(nameof(service));

            var smev = await _context.FindAsync<SSmevRequest>(smevId);
            if (smev is null) throw new ArgumentException(nameof(smev));

            var office = await _context.SOffices.Where(w => w.Id == currentEmployee.Office.Id).Select(s => new { s.SendMdm, s.MdmUid }).FirstAsync();

            //var dataReg =  DateTime.Now.AddDays(smev.CountDayExecution);
            var dataReg = date.AddDays(smev.CountDayExecution);

            if (smev.SServicesWeekId == workDays)
            {
                var calendar = await _context.SCalendars.Where(w => w.DateType == 1 && w.Date >= date).Select(s => new { s.Date })
                    .Skip(smev.CountDayExecution).FirstOrDefaultAsync();
                if (calendar is null) throw new ArgumentException(nameof(calendar));

                dataReg = calendar.Date;
            }

            var model = new DServicesSmevRequest
            {
                DServicesId = service.Id,
                DCasesId = service.DCasesId,
                SEmployeesId = currentEmployee.Id,
                SOfficesId = currentEmployee.Office.Id,
                EmployeesFioAdd = currentEmployee.Name,
                SEmployeesJobPositionId = currentEmployee.Job.Id,
                Commentt = comment,
                SServicesWeekId = smev.SServicesWeekId,
                SSmevRequestId = smev.Id,
                CountDayExecution = smev.CountDayExecution,
                DateReg = dataReg,
                RequestIdRef = idRef
            };

            if (service.IsMdm is true && office.SendMdm is true && office.MdmUid is not null)
            {
                var mdm = await _mdmService.MdmQueryObjectsAsync(service.Id, (Guid)office.MdmUid);
                if (mdm is not null) await _context.AddRangeAsync(mdm);
            }

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id.ToString();
        }
        #endregion

        #region Utils

        private static Dictionary<string, byte[]> ZipDecompress(Stream stream) => new ZipFile(stream)
            .Cast<ZipEntry>().ToDictionary(zEntry => zEntry.Name, zEntry => zEntry.ExtraData);

        #endregion

        #region Dictonary 
        public DictionaryResponseData SmevGetDictionary(DictionaryType type)
        {
            return SmevClient.GetDictionary(type);
        }
        #endregion

        #region Поиск адресов в КЛАДР 
        public KladrSearchResponse KladrSearchAddress(string request)
        {
            return SmevClient.SearchKladr(request);
        }
        #endregion

        #region Attachments
        public async Task<byte[]> SmevSaveXml(Guid id)
        {
            SmevRequestData request = new() { DataServicesRequestSmevId = Convert.ToString(id) };
            var logTypes = SmevClient.GetXmlLogType(request);
            MemoryStream ms = new();
            ZipOutputStream zipStream = new(ms) { UseZip64 = UseZip64.Off };
            zipStream.SetLevel(9);
            logTypes.ForEach(fe =>
            {
                ZipEntry newEntry = new($"{fe}.xml") { DateTime = DateTime.Now, IsUnicodeText = true };
                zipStream.PutNextEntry(newEntry);
                XmlDocument xml = new();
                xml.LoadXml(SmevClient.GetXml(request, fe));
                Stream stream = new MemoryStream();
                xml.Save(stream);
                stream.Position = 0;
                StreamUtils.Copy(stream, zipStream, new byte[4096]);
                stream.Dispose();
                zipStream.CloseEntry();
                zipStream.IsStreamOwner = false;
            });

            await zipStream.DisposeAsync();

            return ms.ToArray();
        }

        public async Task<byte[]> SmevSaveRequestAttachments(Guid id)
        {
            SmevRequestData request = new() { DataServicesRequestSmevId = Convert.ToString(id) }; // запрос
            var documents = SmevClient.GetRequestAttachments(request);
            List<string> name = new();
            MemoryStream ms = new();
            ZipOutputStream zipStream = new(ms) { UseZip64 = UseZip64.Off };
            zipStream.SetLevel(9);
            documents.ForEach(fe =>
            {
                var filename = fe.FileName;
                if (name.Contains(filename)) filename = $"copy_{filename}";
                ZipEntry newEntry = new($"{filename}") { DateTime = DateTime.Now, IsUnicodeText = true };
                zipStream.PutNextEntry(newEntry);
                Stream stream = new MemoryStream(fe.FileContent);
                StreamUtils.Copy(stream, zipStream, new byte[4096]);
                stream.Dispose();
                zipStream.CloseEntry();
                zipStream.IsStreamOwner = false;
                name.Add(filename);
            });

            await zipStream.DisposeAsync();

            return ms.ToArray();
        }

        public async Task<byte[]> SmevSaveResponseAttachments(Guid id)
        {
            SmevRequestData request = new() { DataServicesRequestSmevId = Convert.ToString(id) }; // запрос
            var documents = SmevClient.GetResponseAttachments(request);
            List<string> name = new();
            MemoryStream ms = new();
            ZipOutputStream zipStream = new(ms) { UseZip64 = UseZip64.Off };
            zipStream.SetLevel(9);
            documents.ForEach(fe =>
            {
                var filename = fe.FileName;
                if (name.Contains(filename)) filename = $"copy_{filename}";
                ZipEntry newEntry = new($"{filename}") { DateTime = DateTime.Now, IsUnicodeText = true };
                zipStream.PutNextEntry(newEntry);
                Stream stream = new MemoryStream(fe.FileContent);
                StreamUtils.Copy(stream, zipStream, new byte[4096]);
                stream.Dispose();
                zipStream.CloseEntry();
                zipStream.IsStreamOwner = false;
                name.Add(filename);
            });

            var documentsAdditioanlForms = SmevClient.GetAdditioanlForms(request);

            documentsAdditioanlForms.ForEach(fe =>
            {
                var filename = fe.Name;
                if (name.Contains(filename)) filename = $"copy_{filename}";
                ZipEntry newEntry = new($"{filename}.pdf") { DateTime = DateTime.Now, IsUnicodeText = true };
                zipStream.PutNextEntry(newEntry);
                Stream stream = new MemoryStream(fe.PdfDocument);
                StreamUtils.Copy(stream, zipStream, new byte[4096]);
                stream.Dispose();
                zipStream.CloseEntry();
                zipStream.IsStreamOwner = false;
                name.Add(filename);
            });

            await zipStream.DisposeAsync();

            return ms.ToArray();
        }

        public async Task<byte[]> SmevSaveResponseAttachmentsForms(Guid id)
        {
            SmevRequestData request = new() { DataServicesRequestSmevId = Convert.ToString(id) }; // запрос
            var documents = SmevClient.GetAdditioanlForms(request);
            List<string> name = new();
            MemoryStream ms = new();
            ZipOutputStream zipStream = new(ms) { UseZip64 = UseZip64.Off };
            zipStream.SetLevel(9);
            documents.ForEach(fe =>
            {
                var filename = fe.Name;
                if (name.Contains(filename)) filename = $"copy_{filename}";
                ZipEntry newEntry = new($"{filename}.pdf") { DateTime = DateTime.Now, IsUnicodeText = true };
                zipStream.PutNextEntry(newEntry);
                Stream stream = new MemoryStream(fe.PdfDocument);
                StreamUtils.Copy(stream, zipStream, new byte[4096]);
                stream.Dispose();
                zipStream.CloseEntry();
                zipStream.IsStreamOwner = false;
                name.Add(filename);
            });

            await zipStream.DisposeAsync();

            return ms.ToArray();
        }

        #endregion

        #region Customer
        public async Task GetCustomerSnils(Guid dServiceId, CustomerModelDto customer)
        {
            var smevRequestId = await CreateNewSmevRequestAsync(dServiceId, 51, $"{customer.LastName} {customer.FirstName} {customer.SecondName}");

            var requestSmev = new GetFindSnilsRequestData
            {
                DataServicesRequestSmevId = smevRequestId,
                Fio = new FioType
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    SecondName = customer.SecondName,
                },
                BirthDate = customer.DocumentBirthDate.Value,
                Gender = (GenderType)(customer.CustomerGender - 1),
                Document = new PfrShortIdentityDocument
                {
                    Series = customer.DocumentSerial,
                    Number = customer.DocumentNumber
                }
            };

            SmevClient.RequestPfrFindSnils(requestSmev);
        }

        public async Task GetCustomerInn(Guid dServiceId, CustomerModelDto customer)
        {
            var smevRequestId = await CreateNewSmevRequestAsync(dServiceId, 319, $"{customer.LastName} {customer.FirstName} {customer.SecondName}");

            var requestSmev = new GetInnSingularRequestData
            {
                DataServicesRequestSmevId = smevRequestId,
                Fio = new FioType
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    SecondName = customer.SecondName,
                },
                BirthDate = customer.DocumentBirthDate.Value,
                BirthPlace = customer.DocumentBirthPlace,
                DocumentType = string.Format("{0:d2}", customer.SDocumentsIdentityId),
                DocumentSeriesNumber = $"{customer.DocumentSerial} {customer.DocumentNumber}",
                DocumentIssuerCode = customer.DocumentCode,
                DocumentIssuer = customer.DocumentIssueBody,
                DocumentDate = customer.DocumentIssueDate.Value
            };

            SmevClient.RequestInnSingular(requestSmev);
        }
        #endregion
    }
}
