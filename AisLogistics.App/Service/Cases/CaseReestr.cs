using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.ReestrTransferDocuments;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Utils;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ReestrTransferDocuments;
using AisLogistics.DataLayer.Entities.Models;
using AisLogistics.DataLayer.Utils;
using Clave.Expressionify;
using DataTables.AspNet.Core;
using FluentFTP;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NinjaNye.SearchExtensions;
using NuGet.Packaging;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public partial class CaseService : ICaseService
    {

        /// <summary>
        /// Список обращений
        /// </summary>
        /// <param name="employeeId">id сотрудника</param>
        /// <returns></returns>
        public async Task<(List<CasesDto>, int, int)> GetCases(IDataTablesRequest request, SearchCasesRequestData additionalRequest)
        {
            try
            {
                var date = DateTime.Today;

                if (additionalRequest.PeriodId.HasValue)
                {
                    switch (additionalRequest.PeriodId)
                    {
                        case 1:
                            additionalRequest.DateStart = DateTime.Now;
                            additionalRequest.DateStop = DateTime.Now;
                            break;
                        case 2:
                            additionalRequest.DateStart = DateTime.Now.AddDays(-7);
                            additionalRequest.DateStop = DateTime.Now;
                            break;
                        case 3:
                            additionalRequest.DateStart = DateTime.Now.AddMonths(-1);
                            additionalRequest.DateStop = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }

                var cases = _context.DServices
                      .AsNoTracking()
                      .AsSplitQuery()
                      .Expressionify()
                      .Where(w => (!additionalRequest.EmployeeId.HasValue || w.SEmployeesIdCurrent == additionalRequest.EmployeeId) &&
                                 (additionalRequest.ReceptionOfficesIdList.Count==0 || additionalRequest.ReceptionOfficesIdList.Contains(w.SOfficesIdCurrent)) &&
                                 (string.IsNullOrEmpty(additionalRequest.EmployeeCurrent) || EF.Functions.Like(w.SEmployeesIdCurrentNavigation.EmployeeName.ToLower(), $"%{additionalRequest.EmployeeCurrent.ToLower()}%")) &&
                                 (string.IsNullOrEmpty(additionalRequest.EmployeeAdd) || EF.Functions.Like(w.SEmployeesIdAddNavigation.EmployeeName.ToLower(), $"%{additionalRequest.EmployeeAdd.ToLower()}%")) &&
                                 (additionalRequest.OfficeId.Count==0 || additionalRequest.OfficeId.Any(a => a == Guid.Empty) || additionalRequest.OfficeId.Contains(w.SOfficesIdProvider)) &&
                                 (additionalRequest.ServiceId.Count == 0 || additionalRequest.ServiceId.Any(a => a == Guid.Empty) || additionalRequest.ServiceId.Contains(w.SServicesId)) &&
                                 (additionalRequest.Stages.Count == 0 || additionalRequest.Stages.Any(a => a == -1) || additionalRequest.Stages.Contains(w.SRoutesStageIdCurrent)) &&
                                 (additionalRequest.Status.Count==0 || additionalRequest.Status.Any(a => a == -1) || additionalRequest.Status.Contains(w.SServicesStatusId)) &&
                                 (!additionalRequest.DateStart.HasValue || w.DateAdd.Date >= additionalRequest.DateStart.Value.Date) &&
                                 (!additionalRequest.DateStop.HasValue || w.DateAdd.Date <= additionalRequest.DateStop.Value.Date)
                      );

                int casesCount = await cases.CountAsync();

                var filteredData = string.IsNullOrEmpty(additionalRequest.Query)
                     ? cases
                     : cases.Search(
                            s => s.DCasesId.ToLower(),
                            s => s.ExtraInfo.ToLower(),
                            s => s.CustomerName.ToLower(),
                            s => s.CustomerAddress.ToLower(),
                            s => s.CustomerPhone1.ToLower(),
                            s => s.CustomerPhone2.ToLower()
                        ).ContainingAll(additionalRequest.Query.ToLower().Split(""));

                int casesFilteredCount = string.IsNullOrEmpty(additionalRequest.Query) ? casesCount : await filteredData.CountAsync();

                var dataPage = await filteredData.OrderByDescending(o => o.DateAdd).Select(s => new CasesDto
                {
                    casesMainDto = new CasesMainDto
                    {
                        CaseId = s.DCasesId,
                        DateAdd = s.DateAdd.ToShortDateString(),
                        Applicant = new ApplicantDto(s.CustomerName, s.CustomerAddress, s.CustomerPhone1),
                        NumberPKPVD = string.IsNullOrEmpty(s.ExtraInfo) ? null : (string?)JObject.Parse(s.ExtraInfo).SelectToken("NumberPKPVD"),
                        SearchString = s.SearchString
                    },
                    Service = new CaseServiceDto
                    {
                        Id = s.Id,
                        Name = s.SServices.ServiceNameSmall,
                        ProcedureName = s.SServicesProcedure.ProcedureName,
                        Office = s.SOfficesIdProviderNavigation.OfficeNameSmall,
                        EmployeeAdd = new EmployeeDto(s.SEmployeesIdAddNavigation.Id,
                                    NameSplitter.GetInitials(s.SEmployeesIdAddNavigation.EmployeeName),
                                    s.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                        Status = new StatusDto(s.SServicesStatusId, s.SServicesStatus.StatusName),
                        SerivesStage = new SerivesStageDto
                        {
                            EmployeeCurrent = new EmployeeDto(s.SEmployeesIdCurrent, NameSplitter.GetInitials(s.SEmployeesIdCurrentNavigation.EmployeeName), s.SEmployeesJobPositionIdCurrentNavigation.JobPositionName),
                            Stage = new StageDto(s.SRoutesStageIdCurrent, s.SRoutesStage.StageName),
                            Office = s.SOfficesIdCurrentNavigation.OfficeNameSmall,
                            //Office = sss.SEmployees.SEmployeesOfficesJoins.Where(w => w.DateStart <= date && (w.DateStop == null || w.DateStop >= date) && !w.IsRemove).Select(s => s.SOffices.OfficeName).First(),
                            Days = s.RoutesStageDateRegCurrent.HasValue ? s.RoutesStageDateRegCurrent.Value.Subtract(date).Days : null
                        }
                    }
                }).Skip(request.Start).Take(request.Length).ToListAsync();



                return (dataPage, casesCount, casesFilteredCount);
            }
            catch (Exception ex)
            {
                return (new List<CasesDto>(), 0, 0);
            }
        }

        public async Task<CasesServiceCopyDto?> CasesServiceCopy(Guid Id)
        {
            var data = await _context.DServices.Where(w => w.Id == Id).Select(s => new CasesServiceCopyDto
            {
                Id = s.Id,
                ProcedureId = s.SServicesProcedureId,
                CustomerType = s.SServicesCustomerTypeId,
                ServiceId = s.SServicesId,
                ServiceName = s.SServices.ServiceNameSmall,
                ProviderName = s.SOfficesIdProviderNavigation.OfficeNameSmall,
                CustomerName = s.CustomerName
            }).FirstOrDefaultAsync();

            if (data is null) throw new ArgumentException("услуга не найдена");

            var officeId = await _employeeManager.GetOfficeAsync();
            var date = DateTime.Now;

            var isActive = await _context.SServicesActives.AnyAsync(a => !a.IsRemove && a.SOfficesId == officeId && a.SServicesId == data.ServiceId && a.DateStart.Date <= date.Date && (!a.DateStop.HasValue || a.DateStop.Value.Date >= date.Date) && !a.SServices.IsRemove);

            if (isActive == false) throw new ArgumentException("услуга не активна");

            var isRemoveProcedure = await _context.SServicesProcedures.AnyAsync(a => a.SServicesId == data.ServiceId && a.Id == data.ProcedureId && !a.IsRemove);

            if (isRemoveProcedure == false) throw new ArgumentException("процедура не найдена");

            return data;
        }

        public async Task<CasesServiceCopyDto?> CasesServiceCopy(string Id)
        {
            var data = await _context.DServices.Where(w => w.DCasesId == Id && w.DServicesIdParent == Guid.Empty).Select(s => new CasesServiceCopyDto
            {
                Id = s.Id,
                ProcedureId = s.SServicesProcedureId,
                CustomerType = s.SServicesCustomerTypeId,
                ServiceId = s.SServicesId,
                ServiceName = s.SServices.ServiceNameSmall,
                ProviderName = s.SOfficesIdProviderNavigation.OfficeNameSmall,
                CustomerName = s.CustomerName
            }).FirstOrDefaultAsync();

            if (data is null) throw new ArgumentException("услуга не найдена");

            var officeId = await _employeeManager.GetOfficeAsync();
            var date = DateTime.Now;

            var isActive = await _context.SServicesActives.AnyAsync(a => !a.IsRemove && a.SOfficesId == officeId && a.SServicesId == data.ServiceId && a.DateStart.Date <= date.Date && (!a.DateStop.HasValue || a.DateStop.Value.Date >= date.Date) && !a.SServices.IsRemove);

            if (isActive == false) throw new ArgumentException("услуга не активна");

            var isRemoveProcedure = await _context.SServicesProcedures.AnyAsync(a => a.SServicesId == data.ServiceId && a.Id == data.ProcedureId && !a.IsRemove);

            if (isRemoveProcedure == false) throw new ArgumentException("процедура не найдена");

            return data;
        }



        public async Task<string?> CasesServiceCopySave(CasesServiceCopySaveDto request)
        {
            var data = await _context.DServices.AsNoTracking()
                .Where(w => w.Id == request.DserviceId)
                .Select(s => new
                {
                    DService = s,
                    Customers = s.DCases.DServicesCustomers.ToList(),
                    CustomerLegals = s.DCases.DServicesCustomersLegals.ToList(),
                })
                .FirstOrDefaultAsync();

            if (data is null) throw new ArgumentException("услуга не найдена");

            const int serviceProcessStatusId = 0;
            const int workDays = 1;
            var date = DateTime.Today;
            var currentEmployee = await _employeeManager.GetFullInfoAsync();

            var employeesFtp = await _employeeManager.GetFtpAsync();

            if (employeesFtp is null)
                throw new ArgumentException("ФТП сервер не настроен");

            var serviceCustomerTariff = await _context.SServicesCustomerTariffs
                    .AsNoTracking()
                    .Select(s => new
                    {
                        s.Id,
                        s.SServicesCustomerId,
                        s.CountDayExecution,
                        s.CountDayReturn,
                        s.CountDayProcessing,
                        s.SServicesWeekId,
                        s.SServicesCustomer.SServicesCustomerTypeId,
                        s.SServicesTariffTypeId,
                        s.Tariff,
                        s.TariffMfc
                    }).SingleOrDefaultAsync(sd => sd.Id == request.TarrifId);

            if (serviceCustomerTariff is null)
                throw new ArgumentException("Тариф не найден."); //TODO добавить

            var newCaseId = await GenerateCaseId(currentEmployee.Office.Mnemo ?? "-");

            if (string.IsNullOrEmpty(newCaseId))
                throw new ArgumentException("Номер обращения не сформирован");

            var newServiceId = Guid.NewGuid();
            var newDServiceRouteStageId = Guid.NewGuid();

            var service = await _context.SServices
                .AsNoTracking()
                .Select(s => new
                {
                    s.Id,
                    s.ServiceNameSmall,
                    s.IsTariffEdit,
                    s.IsReportSelect,
                    //s.IsMdm,
                    s.IsPlan,
                    s.SOfficesId,
                    s.FrguServiceId,
                    s.IasMkgu,
                    s.FrguName,
                    s.SOffice.OfficeFrguProviderId,
                    s.SServicesTypeId,
                    s.SServicesInteractionId,
                    s.IsIssueAuthority,
                    Procedure = s.SServicesProcedures.Where(w => w.Id == data.DService.SServicesProcedureId).Select(s => new { s.FrguTargetId, s.IsMdm }).FirstOrDefault()
                }).SingleOrDefaultAsync(sd => sd.Id == data.DService.SServicesId);

            if (service is null) throw new ArgumentException(ErrorDescription.ServiceNotFound);

            var countDay = serviceCustomerTariff.CountDayExecution +
                           serviceCustomerTariff.CountDayReturn +
                           serviceCustomerTariff.CountDayProcessing;

            var dataReg = date.AddDays(countDay);

            if (serviceCustomerTariff.SServicesWeekId == workDays)
            {
                DateTime? calendar = await _context.SCalendars.AsNoTracking().Where(w => w.DateType == 1 && w.Date >= date)
                    .Select(s => s.Date).Skip(countDay).FirstOrDefaultAsync();
                dataReg = calendar.Value;
            }

            var routeStage = await _context.SServicesRoutesStages
                .AsNoTracking()
                .Where(w => w.SServicesId == data.DService.SServicesId && w.SRoutesStageId == request.StageId && w.IsRemove == false)
                .Select(s => new
                {
                    s.Id,
                    s.ParentId,
                    StageId = s.SRoutesStageId,
                    Name = s.SRoutesStage.StageName,
                    Days = s.SRoutesStage.DayExcution,
                    Comment = s.SRoutesStage.Commentt,
                    StatusId = s.SRoutesStage.SServicesStatusId,
                    IsDateFact = s.SRoutesStage.SServicesStatus.IsDatefact,
                    RolePosition = s.SServicesRoutesStageRoles.Select(ss => new
                    {
                        Id = ss.SRolesExecutorId,
                        Name = ss.SRolesExecutor.RoleName
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (routeStage is null) throw new ArgumentException("Пользователь не может добавить обращение");

            DService dService = new()
            {
                Id = newServiceId,
                DCasesId = newCaseId,
                DServicesIdParent = Guid.Empty,
                DServicesDocumentIdParent = Guid.Empty,
                SServicesCustomerTypeId = serviceCustomerTariff.SServicesCustomerTypeId,
                SServicesId = data.DService.SServicesId,
                SServicesProcedureId = data.DService.SServicesProcedureId,
                DateFact = routeStage.IsDateFact ? DateTime.Now : null,
                DateReg = dataReg,
                CountDayProcessing = serviceCustomerTariff.CountDayProcessing,
                CountDayReturn = serviceCustomerTariff.CountDayReturn,
                CountDayExecution = serviceCustomerTariff.CountDayExecution,
                SServicesTariffTypeId = serviceCustomerTariff.SServicesTariffTypeId,
                TariffState = serviceCustomerTariff.Tariff,
                TariffEdit = service.IsTariffEdit,
                IsReportSelect = service.IsReportSelect,
                SEmployeesIdAdd = currentEmployee.Id,
                SOfficesIdAdd = currentEmployee.Office.Id,
                SEmployeesJobPositionIdAdd = currentEmployee.Job.Id,
                SServicesStatusId = routeStage.StatusId ?? serviceProcessStatusId,
                TariffMfc = serviceCustomerTariff.TariffMfc,
                SServicesWeekId = serviceCustomerTariff.SServicesWeekId,
                ExtraInfo = data.DService.ExtraInfo,
                SOfficesIdProvider = service.SOfficesId,
                FrguProviderId = service.OfficeFrguProviderId,
                FrguName = service.FrguName,
                FrguServiceId = service.FrguServiceId,
                FrguTargetId = service.Procedure?.FrguTargetId,
                IasMkgu = service.IasMkgu,
                IsPlan = service.IsPlan,
                SServicesTypeId = service.SServicesTypeId,
                SServicesInteractionId = service.SServicesInteractionId,
                IsIssueAuthority = service.IsIssueAuthority,
                SEmployeesIdExecution = routeStage.IsDateFact ? currentEmployee.Id : null,
                SOfficesIdExecution = routeStage.IsDateFact ? currentEmployee.Office.Id : null,
                SEmployeesJobPositionIdExecution = routeStage.IsDateFact ? currentEmployee.Job.Id : null,
                SRoutesStageIdCurrent = routeStage.StageId,
                SEmployeesIdCurrent = currentEmployee.Id,
                SEmployeesJobPositionIdCurrent = currentEmployee.Job.Id,
                SOfficesIdCurrent = currentEmployee.Office.Id,
                RoutesStageDateRegCurrent = routeStage.Days != 0 ? date.AddDays(routeStage.Days) : null,
                CustomerName = data.DService.CustomerName,
                CustomerPhone1 = data.DService.CustomerPhone1,
                CustomerPhone2 = data.DService.CustomerPhone2,
                CustomerAddress = data.DService.CustomerAddress,
            };

            var newCase = new DCase
            {
                Id = newCaseId,
                DateAdd = date,
                DServicesRoutesStages = new List<DServicesRoutesStage>
                {
                    new()
                    {
                        Id = newDServiceRouteStageId,
                        DCasesId = newCaseId,
                        DServicesId = newServiceId,
                        DServicesIdParent = Guid.Empty,
                        SRoutesStageId = routeStage.StageId,
                        DateAdd = date,
                        CountDayExecution = routeStage.Days,
                        DateReg = routeStage.Days != 0 ? date.AddDays(routeStage.Days) : null,
                        SEmployeesId = currentEmployee.Id,
                        SOfficesId = currentEmployee.Office.Id,
                        SEmployeesJobPositionId = currentEmployee.Job.Id,
                        EmployeesFioAdd = currentEmployee.Name,
                        SEmployeesIdAdd = currentEmployee.Id,
                        SEmployeesJobPositionIdAdd = currentEmployee.Job.Id,
                        PassAutomatically = true
                    }
                },
                DServicesDocumentsResults = await _context.SServicesDocumentsResults.AsNoTracking()
                        .Where(w => !w.IsRemove && w.SServicesId == data.DService.SServicesId &&
                        (!w.SServicesProcedureId.HasValue || w.SServicesProcedureId.Value == data.DService.SServicesProcedureId))
                        .Select(s => new DServicesDocumentsResult
                        {
                            DCasesId = newCaseId,
                            DServicesId = newServiceId,
                            SDocumentsId = s.SDocumentsId,
                            DocumentResult = s.DocumentResult,
                            DocumentMethod = s.DocumentMethod,
                            DocumentPeriodMfc = s.DocumentPeriodMfc,
                            DocumentPeriodProvider = s.DocumentPeriodProvider
                        }).ToListAsync()
            };

            if (data.Customers.Count > 0)
            {
                data.Customers.ForEach(f =>
                {
                    f.Id = Guid.NewGuid();
                    f.DCasesId = newCaseId;
                    f.SEmployeesId = currentEmployee.Id;
                    f.SOfficesId = currentEmployee.Office.Id;
                    f.SEmployeesJobPositionId = currentEmployee.Job.Id;
                    f.DateAdd = date;
                    newCase.DServicesCustomers.Add(f);
                });
            }

            if (data.CustomerLegals.Count > 0)
            {
                data.CustomerLegals.ForEach(f =>
                {
                    f.Id = Guid.NewGuid();
                    f.DCasesId = newCaseId;
                    f.SEmployeesId = currentEmployee.Id;
                    f.SOfficesId = currentEmployee.Office.Id;
                    f.SEmployeesJobPositionId = currentEmployee.Job.Id;
                    f.DateAdd = date;
                    newCase.DServicesCustomersLegals.Add(f);
                });
            }

            var documents = await _context.SServicesDocuments.AsNoTracking().Where(w =>
                           w.IsRemove == false && w.SServicesId == data.DService.SServicesId &&
                           (!w.SServicesProcedureId.HasValue || w.SServicesProcedureId.Value == data.DService.SServicesProcedureId))
                       .Select(s => new DServicesDocument
                       {
                           DCasesId = newCaseId,
                           DServicesId = newServiceId,
                           SDocumentsId = s.SDocumentsId,
                           DocumentCount = s.DocumentCount,
                           DocumentType = s.DocumentType,
                           DocumentNeeds = s.DocumentNeeds,
                           IsCheck = false
                       }).ToListAsync();

            var documentsId = documents.Select(s => s.SDocumentsId).ToList();

            var documentsFiles = await _context.DServicesFiles.AsNoTracking()
                .Where(w => w.DCasesId == data.DService.DCasesId && documentsId.Contains(w.DServicesDocuments.SDocumentsId))
                .GroupBy(g => g.DServicesDocuments.SDocumentsId)
                .Select(s => new { documentsId = s.Key, files = s.Select(ss => new { DFile = ss, ss.SFtp }).ToList() })
                .ToListAsync();

            documents.ForEach(f =>
            {
                f.Id = Guid.NewGuid();

                var files = documentsFiles.Where(w => w.documentsId == f.SDocumentsId).Select(s => s.files).FirstOrDefault();

                files?.ForEach(file =>
                {
                    var ftp = new FtpSettingsModel
                    {
                        Server = file.SFtp.FtpServer,
                        Login = file.SFtp.FtpLogin,
                        Password = file.SFtp.FtpPassword
                    };


                    var bytes = _ftpService.DownloadFileAsync(
                        $"{file.DFile.DCasesId}/{file.DFile.Id}{file.DFile.FileExtention}", ftp).Result;

                    if (bytes != null)
                    {

                        var newFile = new DServicesFile
                        {
                            Id = Guid.NewGuid(),
                            DCasesId = newCaseId,
                            FileFlag = file.DFile.FileFlag,
                            FileSize = file.DFile.FileSize,
                            FileExtention = file.DFile.FileExtention,
                            FileName = file.DFile.FileName,
                            TypeAddFile = file.DFile.TypeAddFile,
                            IsPaid = file.DFile.IsPaid,
                            DateAdd = DateTime.Now,
                            SEmployeesId = currentEmployee.Id,
                            EmployeesFioAdd = currentEmployee.Name,
                            SOfficesId = currentEmployee.Office.Id,
                            SEmployeesJobPositionId = currentEmployee.Job.Id,
                            SFtpId = employeesFtp.Id
                        };

                        var uploadPath = $"{newCaseId}/{newFile.Id}{Path.GetExtension(newFile.FileName)}";

                        if (_ftpService.UploadFileAsync(bytes,
                            $"{newCaseId}/{newFile.Id}{Path.GetExtension(newFile.FileName)}", employeesFtp).Result == FtpStatus.Success)
                        {
                            f.DServicesFiles.Add(newFile);
                        }
                    }
                });
            });

            newCase.DServices.Add(dService);
            newCase.DServicesDocuments.AddRange(documents);

            await _context.AddAsync(newCase);
            await _context.SaveChangesAsync();

            return newCaseId;
        }

        public async Task<List<CasesIncomingDocumentDto>> GetCasesIncomingDocuments(Guid? officeId, SearchIncomingDocumentsRequestData requestData)
        {
            try
            {
                var date = DateTime.Today;

                var result = await _context.DServices
                    .AsNoTracking()
                    .Where(w =>
                        w.SOfficesIdCurrent == officeId && w.SRoutesStageIdCurrent == 4
                        && w.SOfficesIdProvider == requestData.ProvidersId
                        && (requestData.DepartamentId == null || w.SOfficesIdProviderDepartament == requestData.DepartamentId.Value)
                        && w.SServicesId == requestData.ServiceId
                    )
                    .Select(s => new CasesIncomingDocumentDto
                    {
                        CasesNumber = s.DCasesId,
                        ServiceId = s.Id,
                        Applicant = new ApplicantDto(s.CustomerName, s.CustomerAddress, s.CustomerPhone1, s.CustomerPhone2),
                    })
                    .ToListAsync();

                Guid? stages = await _context.SServicesRoutesStages.Where(w=>w.SRoutesStageId==4&&w.SServicesId==requestData.ServiceId&&!w.IsRemove&&w.ParentId==Guid.Empty).Select(s=>s.Id).FirstOrDefaultAsync();
                if(stages is not null)
                {
                    var stagesNext = await _context.SServicesRoutesStages.Where(w=>w.ParentId==stages.Value&&!w.IsRemove).Select(s=> new StageNext {Id = s.SRoutesStageId, Name = s.SRoutesStage.StageName }).OrderBy(o=>o.Id).ToListAsync();
                    result.ForEach(f => { f.StagesNext = stagesNext; });
                }

                return result;
            }
            catch (Exception ex)
            {
                return new List<CasesIncomingDocumentDto>();
            }
        }
    }
}
