using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.ReestrTransferDocuments;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.ViewModels.ReestrTransferDocuments;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using Clave.Expressionify;
using DataTables.AspNet.Core;
using FastReport;
using FastReport.Export.OoXML;
using FastReport.Export.Pdf;
using FastReport.Utils;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    public class ReestrTransferDocuments : IReestrTransferDocuments
    {
        private readonly AisLogisticsContext _context;
        public ReestrTransferDocuments(AisLogisticsContext context)
        {
            _context = context;
        }
        public async Task<(List<ReestrTransferDocumentsDto>, int, int)> GetReestrTransferDocuments(IDataTablesRequest request, List<Guid> officeId)
        {
            try
            {
                //var MfcIdColumn = request?.Columns?.Where(w => w.Name == "officeFilterSelect").Select(s => s.Search.Value).FirstOrDefault();
                //if (MfcIdColumn != null) employeeId = new Guid(MfcIdColumn);

                var results = _context.DReestrs
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => officeId.Count==0||officeId.Contains(w.SOfficesId));

                int totalCount = await results.CountAsync();

                var dataPage = await results
                .OrderByDescending(o => o.DateCreate)
                .ThenByDescending(t => t.ReestrNumber)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ReestrTransferDocumentsDto()
                {
                    Id = x.Id,
                    ReestrNumber = x.ReestrNumber,
                    DateAdd = x.DateCreate.ToShortDateString(),
                    CountService = x.DReestrServices.Count,
                    ServiceName = x.SServices.ServiceName,
                    ProviderName = x.SServicesIdProviderNavigation.OfficeName,
                    DepartementName = x.SServicesIdProviderDepartamentNavigation.OfficeName,
                    EmployeesFioAdd = x.SEmployees.EmployeeName
                }).ToListAsync();

                return (dataPage, totalCount, totalCount);
            }
            catch
            {
                return (new List<ReestrTransferDocumentsDto>(), 0, 0);
            }
        }

        public async Task<List<ReestrTransferDocumentsDto>> GetReestrTransferDocumentsV2(Guid? employeeId)
        {
            try
            {
                var results = _context.DReestrs
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => !employeeId.HasValue || (employeeId.Value == Guid.Empty || w.SOfficesId == employeeId));

                int totalCount = await results.CountAsync();

                var data = await results
                .OrderByDescending(o => o.DateCreate)
                .ThenByDescending(t => t.ReestrNumber)
                .Take(500)
                .Select(x => new ReestrTransferDocumentsDto()
                {
                    Id = x.Id,
                    ReestrNumber = x.ReestrNumber,
                    DateAdd = x.DateCreate.ToShortDateString(),
                    CountService = x.DReestrServices.Count,
                    ServiceName = x.SServices.ServiceName,
                    ProviderName = x.SServicesIdProviderNavigation.OfficeName,
                    DepartementName = x.SServicesIdProviderDepartamentNavigation.OfficeName,
                    EmployeesFioAdd = x.SEmployees.EmployeeName
                }).ToListAsync();

                return data;
            }
            catch
            {
                return new List<ReestrTransferDocumentsDto>();
            }
        }

        public async Task<ReestrTransferDocumentsDto?> GetReestrTransferDocuments(Guid? id)
        {
            var model = await _context.DReestrs.Select(x => new ReestrTransferDocumentsDto
            {
                Id = x.Id,
                ReestrNumber = x.ReestrNumber,
            }).FirstOrDefaultAsync(f => f.Id == id);

            return model;
        }

        public async Task<bool> EditReestrTransferDocuments(ReestrTransferDocumentsDto request)
        {
            try
            {
                var model = await _context.DReestrs.FindAsync(request.Id);
                if (model is null) throw new InvalidOperationException(MessageDescription.ModelNotFound);
                model.ReestrNumber = (int)request.ReestrNumber;

                _context.DReestrs.Update(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<CasesTransferDocumentDto>> GetCasesTransferDocuments(Guid? officeId, SearchTransferDocumentsRequestData requestData)
        {
            try
            {
                var date = DateTime.Today;

                var result = await _context.DServices
                    .AsNoTracking()
                    .Where(w =>
                        w.SOfficesIdCurrent == officeId && w.SRoutesStageIdCurrent == 2
                        && w.SOfficesIdProvider == requestData.ProvidersId
                        && (requestData.DepartamentId == null || w.SOfficesIdProviderDepartament == requestData.DepartamentId.Value)
                        && w.SServicesId == requestData.ServiceId
                    )
                    .Select(s => new CasesTransferDocumentDto
                    {
                        CasesNumber = s.DCasesId,
                        ServiceId = s.Id,
                        Applicant = new ApplicantDto(s.CustomerName, s.CustomerAddress, s.CustomerPhone1, s.CustomerPhone2),
                        ServiceRourteStage = s.SRoutesStage.StageName,
                        CurrentEmployee = s.SEmployeesIdCurrentNavigation.EmployeeName
                    })
                    .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new List<CasesTransferDocumentDto>();
            }
        }

        public async Task<(List<ReestrCasesTransferDocumentsDTO>, int)> GetReestrTransferDocument(Guid id)
        {
            try
            {
                var reestr = await _context.DReestrs.FirstOrDefaultAsync(f => f.Id == id);
                if (reestr is null) throw new InvalidOperationException("Данные не найдены");

                var result = await _context.DReestrServices
                    .Where(w => w.DReestrId == id)
                    .Select(s => new ReestrCasesTransferDocumentsDTO
                    {
                        Id = s.Id,
                        DReestrId = s.DReestrId,
                        ServiceId = s.DServicesId,
                        CasesNumber = s.DCasesId,
                        CustomerName = s.CustomerName,
                        CustomerPhone1 = s.CustomerPhone1,
                        CustomerPhone2 = s.CustomerPhone2,
                        CustomerAddress = s.CustomerAddress,
                    })
                    .ToListAsync();
                return (result, reestr.ReestrNumber);
            }
            catch
            {
                return (new List<ReestrCasesTransferDocumentsDTO>(), 0);
            }
        }


        public async Task<TransferDocumentsSaveResponce?> CasesTransferDocumentsSave(TransferDocumentsSaveRequest request, EmployeeInfo employee)
        {
            try
            {
                if (request.DserviceId == null || request.DserviceId.Any() == false) throw new InvalidOperationException("Ошибка");

                var dReestr = Guid.NewGuid();
                List<DReestrService> dReestrServices = new List<DReestrService>();
                var result = await _context.DServices
                    .Where(w => request.DserviceId.Any(a => a == w.Id))
                    .Select(s => new
                    {
                        s.Id,
                        s.DCasesId,
                        Applicant = s.DCases.DServicesCustomersLegals.Count == 0 ? s.DCases.DServicesCustomers.Where(w => w.CustomerType == (int)CustomerType.Applicant).Select(ss => new ApplicantDto(ss.Fio(), ss.CustomerAddress, ss.CustomerPhone1)).First() :
                                                                               s.DCases.DServicesCustomersLegals.Select(ss => new ApplicantDto(ss.CustomerName, ss.CustomerAddress, ss.CustomerPhone1)).First(),

                    })
                    .ToListAsync();

                result.ForEach(f =>
                {
                    dReestrServices.Add(new DReestrService
                    {
                        DReestrId = dReestr,
                        DCasesId = f.DCasesId,
                        DServicesId = f.Id,
                        CustomerName = f.Applicant.Name,
                        CustomerAddress = f.Applicant.Address,
                        CustomerPhone1 = f.Applicant.Phone,
                        CustomerPhone2 = f.Applicant.Phone2
                    });
                });

                var model = new DReestr
                {
                    Id = dReestr,
                    DateCreate = DateTime.Now,
                    SEmployeesId = employee.Id,
                    SServicesIdProviderId = request.providerId,
                    SOfficesId = employee.Office.Id,
                    SServicesId = request.ServiceId,
                    SServicesIdProviderDepartament = request.DepartamentId,
                    DReestrServices = dReestrServices
                };

                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return new TransferDocumentsSaveResponce
                {
                    Id = model.Id,
                    Number = model.ReestrNumber,
                    EmployeeId = employee.Id,
                    OfficeId = employee.Office.Id
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> CasesTransferDocumentsCommentsSave(TransferDocumentsCommentsSaveRequest request, EmployeeInfo employee)
        {
            try
            {
                List<DServicesCommentt> model = new(request.CaseId.Count);

                request.CaseId.ForEach(f =>
                {
                    model.Add(new DServicesCommentt
                    {
                        DCasesId = f,
                        Commentt = request.Text,
                        SEmployeesId = employee.Id,
                        SEmployeesJobPositionId = employee.Job.Id,
                        SOfficesId = employee.Office.Id
                    });
                });

                await _context.AddRangeAsync(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<byte[]> CasesTransferDocumentsPrint(byte[] content, Guid id, string connection, string employeeName, BlankActionType type)
        {
            RegisteredObjects.AddConnection(typeof(FastReport.Data.PostgresDataConnection));
            var rep = new Report();
            rep.Load(new MemoryStream(content));
            rep.SetParameterValue("ServiceId", id.ToString());
            rep.SetParameterValue("EmployeeName", employeeName);
            if (rep.Dictionary.Connections.Count != 0)
            {
                rep.Dictionary.Connections[0].ConnectionString = connection;
            }

            var isPrepare = rep.Prepare();

            if (!isPrepare) throw new InvalidOperationException("Ошибка при создание бланка");

            var strm = new MemoryStream();

            switch (type)
            {
                case BlankActionType.Pdf:
                    var pdfExport = new PDFExport();
                    rep.Export(pdfExport, strm);
                    pdfExport.Dispose();
                    break;
                case BlankActionType.Word:
                    var wordExport = new Word2007Export();
                    rep.Export(wordExport, strm);
                    wordExport.Dispose();
                    break;
                default: break;
            }

            rep.Dispose();

            return strm.ToArray();
        }
    }
}
