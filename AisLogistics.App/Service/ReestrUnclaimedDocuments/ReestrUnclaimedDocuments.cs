using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.ReestrUnclaimedDocuments;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.ViewModels.ReestrUnclaimedDocuments;
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
    public class ReestrUnclaimedDocuments : IReestrUnclaimedDocuments
    {
        private readonly AisLogisticsContext _context;
        public ReestrUnclaimedDocuments(AisLogisticsContext context)
        {
            _context = context;
        }
        public async Task<(List<ReestrUnclaimedDocumentsDto>, int, int)> GetReestrUnclaimedDocuments(IDataTablesRequest request, List<Guid> officeId)
        {
            try
            {
                var results = _context.DReestrUnclaimeds
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => officeId.Count==0 || officeId.Contains(w.SOfficesId));

                int totalCount = await results.CountAsync();

                var dataPage = await results
                .OrderByDescending(o => o.DateCreate)
                .ThenByDescending(t => t.ReestrNumber)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ReestrUnclaimedDocumentsDto()
                {
                    Id = x.Id,
                    ReestrNumber = x.ReestrNumber,
                    DateAdd = x.DateCreate.ToShortDateString(),
                    CountService = x.DReestrUnclaimedServices.Count,
                    ServiceName = x.SServices.ServiceName,
                    ProviderName = x.SServicesIdProviderNavigation.OfficeName,
                    DepartementName = x.SServicesIdProviderDepartamentNavigation.OfficeName,
                    EmployeesFioAdd = x.SEmployees.EmployeeName
                }).ToListAsync();

                return (dataPage, totalCount, totalCount);
            }
            catch
            {
                return (new List<ReestrUnclaimedDocumentsDto>(), 0, 0);
            }
        }

        public async Task<List<ReestrUnclaimedDocumentsDto>> GetReestrUnclaimedDocumentsV2(Guid? employeeId)
        {
            try
            {
                var results = _context.DReestrUnclaimeds
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => !employeeId.HasValue || (employeeId.Value == Guid.Empty || w.SOfficesId == employeeId));

                int totalCount = await results.CountAsync();

                var data = await results
                .OrderByDescending(o => o.DateCreate)
                .ThenByDescending(t => t.ReestrNumber)
                .Take(500)
                .Select(x => new ReestrUnclaimedDocumentsDto()
                {
                    Id = x.Id,
                    ReestrNumber = x.ReestrNumber,
                    DateAdd = x.DateCreate.ToShortDateString(),
                    CountService = x.DReestrUnclaimedServices.Count,
                    ServiceName = x.SServices.ServiceName,
                    ProviderName = x.SServicesIdProviderNavigation.OfficeName,
                    DepartementName = x.SServicesIdProviderDepartamentNavigation.OfficeName,
                    EmployeesFioAdd = x.SEmployees.EmployeeName
                }).ToListAsync();

                return data;
            }
            catch
            {
                return new List<ReestrUnclaimedDocumentsDto>();
            }
        }

        public async Task<(List<ReestrCasesUnclaimedDocumentsDTO>, int, int)> GetReestrUnclaimedDocument(IDataTablesRequest request, SearchCasesUnclaimedDocumentsRequestData search)
        {
            try
            {
                var results = _context.DReestrUnclaimedServices
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => w.DReestrId == search.UnclaimedId);

                int totalCount = results.Count();

                var dataPage = await results
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ReestrCasesUnclaimedDocumentsDTO()
                {
                    Id = x.Id,
                    DReestrId = x.DReestrId,
                    CasesNumber = x.DCasesId,
                    CustomerAddress = x.CustomerAddress,
                    CustomerName = x.CustomerName,
                    CustomerPhone1 = x.CustomerPhone1,
                    CustomerPhone2 = x.CustomerPhone2,
                    ServiceId = x.DServicesId
                }).ToListAsync();

                return (dataPage, totalCount, totalCount);
            }
            catch
            {
                return (new List<ReestrCasesUnclaimedDocumentsDTO>(), 0, 0);
            }
        }

        public async Task<ReestrUnclaimedDocumentsDto?> GetReestrUnclaimedDocuments(Guid? id)
        {
            var model = await _context.DReestrUnclaimeds.Select(x => new ReestrUnclaimedDocumentsDto
            {
                Id = x.Id,
                ReestrNumber = x.ReestrNumber,
            }).FirstOrDefaultAsync(f => f.Id == id);

            return model;
        }

        public async Task<bool> EditReestrUnclaimedDocuments(ReestrUnclaimedDocumentsDto request)
        {
            try
            {
                var model = await _context.DReestrUnclaimeds.FindAsync(request.Id);
                if (model is null) throw new InvalidOperationException(MessageDescription.ModelNotFound);
                model.ReestrNumber = (int)request.ReestrNumber;

                _context.DReestrUnclaimeds.Update(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<CasesUnclaimedDocumentDto>> GetCasesUnclaimedDocuments(Guid? employeeId, SearchUnclaimedDocumentsRequestData requestData)
        {
            try
            {
                var date = DateTime.Today;

                var result = await _context.DServices
                    .AsNoTracking()
                    .Where(w =>
                        w.SOfficesIdCurrent == employeeId && w.SRoutesStageIdCurrent == 6
                        && w.SOfficesIdProvider == requestData.ProvidersId
                        && (requestData.DepartamentId == null || w.SOfficesIdProviderDepartament == requestData.DepartamentId.Value)
                        && w.SServicesId == requestData.ServiceId &&
                        w.DServicesRoutesStages.Any(a => a.SRoutesStageId == 6 && !a.DateFact.HasValue && a.DateAdd.AddDays(a.DServices.SServices.TimeStorage).Date < DateTime.Now.Date)
                    /*                        (w.SServices.TimeStorage.HasValue&&w.DateAdd.AddDays(w.SServices.TimeStorage.Value).Date<DateTime.Now.Date)*/
                    )
                    .Select(s => new CasesUnclaimedDocumentDto
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
                return new List<CasesUnclaimedDocumentDto>();
            }
        }

        public async Task<(List<ReestrCasesUnclaimedDocumentsDTO>, int)> GetReestrUnclaimedDocument(Guid id)
        {
            try
            {
                var reestr = await _context.DReestrUnclaimeds.FirstOrDefaultAsync(f => f.Id == id);
                if (reestr is null) throw new InvalidOperationException("Данные не найдены");

                var result = await _context.DReestrUnclaimedServices
                    .AsNoTracking()
                    .Where(w => w.DReestrId == id)
                    .Select(s => new ReestrCasesUnclaimedDocumentsDTO
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
                return (new List<ReestrCasesUnclaimedDocumentsDTO>(), 0);
            }
        }


        public async Task<UnclaimedDocumentsSaveResponce?> CasesUnclaimedDocumentsSave(UnclaimedDocumentsSaveRequest request, EmployeeInfo employee)
        {
            try
            {
                if (request.DserviceId == null || request.DserviceId.Any() == false) throw new InvalidOperationException("Ошибка");

                var dReestr = Guid.NewGuid();
                List<DReestrUnclaimedService> dReestrServices = new List<DReestrUnclaimedService>();
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
                    dReestrServices.Add(new DReestrUnclaimedService
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

                var model = new DReestrUnclaimed
                {
                    Id = dReestr,
                    DateCreate = DateTime.Now,
                    SEmployeesId = employee.Id,
                    SServicesIdProviderId = request.providerId,
                    SOfficesId = employee.Office.Id,
                    SServicesId = request.ServiceId,
                    SServicesIdProviderDepartament = request.DepartamentId,
                    DReestrUnclaimedServices = dReestrServices
                };

                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return new UnclaimedDocumentsSaveResponce
                {
                    Id = model.Id,
                    Number = model.ReestrNumber
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> CasesUnclaimedDocumentsCommentsSave(UnclaimedDocumentsCommentsSaveRequest request, EmployeeInfo employee)
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

        public async Task<byte[]> CasesUnclaimedDocumentsPrint(byte[] content, Guid id, string connection, string employeeName, BlankActionType type)
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
