using AisLogistics.App.Models.DTO.ApplicantPersonalAccount;
using AisLogistics.App.Utils;
using AisLogistics.App.ViewModels.ApplicantPersonalAccount;
using AisLogistics.DataLayer.Common.Dto.Case;
using AisLogistics.DataLayer.Concrete;
using AutoMapper;
using Clave.Expressionify;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service.ApplicantPersonalAccount
{
    public class ApplicantPersonalAccount : IApplicantPersonalAccount
    {
        private readonly AisLogisticsContext _context;
        private readonly IMapper _mapper;
        public ApplicantPersonalAccount(AisLogisticsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<(List<ReestrApplicantDto>, int, int)> GetReestrApplicants(IDataTablesRequest request, SearchApplicantsRequestData search)
        {
            try
            {
                var results = _context.DCustomers
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify();

                int totalCount = await results.CountAsync();

                var filteredResult = string.IsNullOrEmpty(search.Search)
                    ? results
                    : results.Search(s => s.LastName.ToLower(),
                    s => s.FirstName.ToLower(),
                    s => s.SecondName.ToLower(),
                    s => s.CustomerAddress.ToLower(),
                    s => s.CustomerSnils.ToLower()).ContainingAll(search.Search.ToLower());

                int filteredCount = string.IsNullOrEmpty(search.Search) ? totalCount : await filteredResult.CountAsync();

                var dataPage = await filteredResult
                .OrderBy(o => o.LastName)
                .ThenBy(t => t.FirstName)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ReestrApplicantDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SecondName = x.SecondName,
                    DocumentBirthDate = x.DocumentBirthDate,
                    CustomerAddress = x.CustomerAddress,
                    CustomerSnils = x.CustomerSnils
                }).ToListAsync();

                return (dataPage, totalCount, filteredCount);
            }
            catch(Exception ex)
            {
                return (new List<ReestrApplicantDto>(), 0, 0);
            }
        }

        public async Task<(List<ReestrApplicantCasesDto>, int, int)> GetApplicantCases(IDataTablesRequest request, SearchApplicantCasesRequestData search)
        {
            try
            {
                var customerSnils = await _context.DCustomers.Where(w => w.Id == search.Id).Select(s => s.CustomerSnils).FirstOrDefaultAsync();
                if (customerSnils == null) throw new InvalidOperationException("Данные не найдены");

                var date = DateTime.Now;

                var results = _context.DServices
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => w.DCases.DServicesCustomers.Any(a => a.CustomerSnils == customerSnils));

                int totalCount = await results.CountAsync();

                var filteredResult = string.IsNullOrEmpty(search.Search)
                    ? results
                    : results;

                int filteredCount = string.IsNullOrEmpty(search.Search) ? totalCount : await filteredResult.CountAsync();

                var dataPage = await filteredResult
                .OrderByDescending(o => o.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ReestrApplicantCasesDto()
                {
                    Id = x.Id,
                    CaseId = x.DCasesId,
                    DateAdd = x.DateAdd,
                    StageId = x.SRoutesStageIdCurrent,
                    StageName = x.SRoutesStage.StageName,
                    CurrentEmployeeName = NameSplitter.GetInitials(x.SEmployeesIdCurrentNavigation.EmployeeName),
                    CurrentOfficeName = x.SOfficesIdCurrentNavigation.OfficeName,
                    CurrentJobName = x.SEmployeesJobPositionIdCurrentNavigation.JobPositionName,
                    Days = x.RoutesStageDateRegCurrent.HasValue ? x.RoutesStageDateRegCurrent.Value.Subtract(date).Days : null,
                    StatusId = x.SServicesStatusId,
                    StatusName = x.SServicesStatus.StatusName,
                    ProviderId = x.SOfficesIdProvider,
                    ProviderName = x.SOfficesIdProviderNavigation.OfficeNameSmall,
                    DepartamentId = x.SOfficesIdProviderDepartament,
                    DepartamentName = x.SOfficesIdProviderDepartamentNavigation.OfficeNameSmall,
                    ProcedureName = x.SServicesProcedure.ProcedureName,
                }).ToListAsync();

                return (dataPage, totalCount, totalCount);
            }
            catch
            {
                return (new List<ReestrApplicantCasesDto>(), 0, 0);
            }
        }

        public async Task<(List<ReestrApplicantCasesArchiveDto>, int, int)> GetApplicantCasesArchive(IDataTablesRequest request, SearchApplicantCasesArchiveRequestData search)
        {
            try
            {
                var customerSnils = await _context.DCustomers.Where(w => w.Id == search.Id).Select(s => s.CustomerSnils).FirstOrDefaultAsync();
                if (customerSnils == null) throw new InvalidOperationException("Данные не найдены");

                var date = DateTime.Now;

                var results = _context.ACases
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => w.CustomerSnils == customerSnils);

                int totalCount = await results.CountAsync();

                var filteredResult = string.IsNullOrEmpty(search.Search)
                    ? results
                    : results;

                int filteredCount = string.IsNullOrEmpty(search.Search) ? totalCount : await filteredResult.CountAsync();

                var dataPage = await filteredResult
                .OrderByDescending(o => o.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ReestrApplicantCasesArchiveDto()
                {
                    CaseId = x.Id,
                    DateAdd = x.DateAdd,
                    StageId = 10,
                    StageName = "Архив",
                    CurrentEmployeeName = NameSplitter.GetInitials(x.EmployeeNameExecution),
                    //CurrentOfficeName = x.SOfficesIdCurrentNavigation.OfficeName,
                    //CurrentJobName = x.SEmployeesJobPositionIdCurrentNavigation.JobPositionName,
                    //Days = x.RoutesStageDateRegCurrent.HasValue ? x.RoutesStageDateRegCurrent.Value.Subtract(date).Days : null,
                    StatusId = x.SServicesStatusId,
                    StatusName = x.StatusName,
                    ProviderName = x.OfficeNameProvider,
                    //DepartamentId = x.SOfficesIdProviderDepartament,
                    //DepartamentName = x.SOfficesIdProviderDepartamentNavigation.OfficeNameSmall,
                    ProcedureName = x.ServiceName,
                }).ToListAsync();

                return (dataPage, totalCount, totalCount);
            }
            catch
            {
                return (new List<ReestrApplicantCasesArchiveDto>(), 0, 0);
            }
        }

        public async Task<(List<ReestrApplicantCasesHistoryDto>, int, int)> GetApplicantCasesHistory(IDataTablesRequest request, SearchApplicantCasesHistoryRequestData search)
        {
            try
            {
                var results = _context.DCustomerHistories
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => w.DCustomersId == search.Id);

                int totalCount = await results.CountAsync();

                var filteredResult = string.IsNullOrEmpty(search.Search)
                                   ? results
                                   : results;

                int filteredCount = string.IsNullOrEmpty(search.Search) ? totalCount : await filteredResult.CountAsync();

                var dataPage = await filteredResult
                .OrderByDescending(o => o.DateReception)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new ReestrApplicantCasesHistoryDto()
                {
                    CaseId = x.CaseNumber,
                    DateAdd = x.DateReception,
                    //StageId = x.SRoutesStageIdCurrent,
                    StageName = x.StageName,
                    //CurrentEmployeeName = NameSplitter.GetInitials(x.SEmployeesIdCurrentNavigation.EmployeeName),
                    //CurrentOfficeName = x.SOfficesIdCurrentNavigation.OfficeName,
                    //CurrentJobName = x.SEmployeesJobPositionIdCurrentNavigation.JobPositionName,
                    //Days = x.RoutesStageDateRegCurrent.HasValue ? x.RoutesStageDateRegCurrent.Value.Subtract(date).Days : null,
                    StatusName = x.StatusName,
                    ProviderName = x.ProviderName,
                    //DepartamentId = x.SOfficesIdProviderDepartament,
                    DepartamentName = x.DepartmentName,
                    ProcedureName = x.ServiceName,
                }).ToListAsync();

                return (dataPage, totalCount, totalCount);
            }
            catch
            {
                return (new List<ReestrApplicantCasesHistoryDto>(), 0, 0);
            }
        }

        public async Task<CustomerModelDto?> GetApplicantModelDto(Guid Id)
        {
            try
            {
                var model = await _context.DCustomers.AsNoTracking().Where(w => w.Id == Id)
                    .Select(s => new CustomerModelDto
                    {
                        Id = s.Id,
                        SDocumentsIdentityId = s.SDocumentsIdentityId,
                        CustomerGender = s.CustomerGender,
                        DocumentNumber = s.DocumentNumber,
                        DocumentSerial = s.DocumentSerial,
                        DocumentBirthDate = s.DocumentBirthDate,
                        DocumentBirthPlace = s.DocumentBirthPlace,
                        DocumentIssueDate = s.DocumentIssueDate,
                        DocumentIssueBody = s.DocumentIssueBody,
                        DocumentCode = s.DocumentCode,
                        CustomerInn = s.CustomerInn,
                        CustomerPhone1 = s.CustomerPhone1,
                        CustomerEmail = s.CustomerEmail,
                        CustomerAddress = s.CustomerAddress,
                        CustomerOkato = s.CustomerOkato,
                        CustomerOktmo = s.CustomerOktmo,
                        CustomerCodeRegion = s.CustomerCodeRegion,
                        CustomerSnils = s.CustomerSnils,
                        CustomerAddressDetail = s.CustomerAddressDetail,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        SecondName = s.SecondName,  
                        CustomerAddressResidence = s.CustomerAddressResidence,
                        DateTempRegistration = s.DateTempRegistration,
                        CustomerAddressTemp = s.CustomerAddressTemp,
                        EmployeesFioAdd = s.EmployeesFioAdd,
                        DateAdd = s.DateAdd,    
                        CustomerPhone2 = s.CustomerPhone2
                    }).FirstOrDefaultAsync();
                if (model is null) throw new InvalidOperationException("Данные не найдены");
                model.AddressDetails = string.IsNullOrEmpty(model.CustomerAddressDetail) ? null : JsonConvert.DeserializeObject<AddressDetails>(model.CustomerAddressDetail);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
