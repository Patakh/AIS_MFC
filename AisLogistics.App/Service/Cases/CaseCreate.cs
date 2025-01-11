using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.DataLayer.Entities.Models;
using AisLogistics.DataLayer.Utils;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NinjaNye.SearchExtensions;
using System.Text.RegularExpressions;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public partial class CaseService : ICaseService
    {
        private async Task<string> GenerateCaseId(string officeMnemo)
        {
            try
            {
                var newNumber = await _context.GenerateCaseNumber.FromSqlRaw("SELECT NEXTVAL('core.cases_number_id_seq')").SingleAsync();
                return $"{officeMnemo}{newNumber.Number:D8}";
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string AdditionalDataFix(string data)
        {
            while (Regex.IsMatch(data, "{\"\\d+\":\\s*.+?}}"))
            {
                string array = Regex.Match(data, "{\"\\d+\":\\s*.+?}}").Value;
                array = Regex.Replace(array, "\"\\d+\":\\s*", "");
                array = Regex.Replace(array, "{{", "[{");
                array = Regex.Replace(array, "}}", "}]");
                data = data.Replace(Regex.Match(data, "{\"\\d+\":\\s*.+?}}").Value, array);
            }

            return data;
        }

        public async Task<(List<ActiveServicesDto>, int, int)> GetActiveServices(SearchCasesRequestData searchData, int start, int length)
        {
            var date = DateTime.Today;
            var employeeId = await _employeeManager.GetIdAsync();
            var officeId = await _employeeManager.GetOfficeAsync();
            var roles = await _context.SEmployeesRolesExecutors.AsNoTracking().Where(w => w.SEmployeesId == employeeId)
                .Select(s => s.SRolesExecutorId).ToListAsync();

            var services = _context.SServices
                .AsNoTracking()
                .Where(w => !w.IsRemove
                            && w.SServicesActives.Any(a => a.IsRemove == false &&
                                                           a.SOfficesId == officeId &&
                                                           a.DateStart.Date <= date.Date &&
                                                           (a.DateStop == null || a.DateStop.Value.Date >= date.Date)) &&
                          (!searchData.OfficeId.Any() || searchData.OfficeId.Contains(w.SOfficesId)) &&
                          (!searchData.LivingSituationId.Any() || !w.SServicesLivingSituationJoins.Any() || w.SServicesLivingSituationJoins.Any(a => searchData.LivingSituationId.Contains(a.Id))) &&
                          w.SServicesRoutesStages.Any(f => f.IsRemove == false && f.SRoutesStageId == 1 && f.SServicesRoutesStageRoles.Any(a => roles.Contains(a.SRolesExecutorId))) &&
                        w.SServicesCustomers.Any(a => a.SServicesCustomerTypeId == searchData.CustomresType));

            var servicesCount = await services.CountAsync();

            var filteredData = String.IsNullOrWhiteSpace(searchData.Query)
                ? searchData.OfficeId.Any() ? services : services.Where(w => w.DEmployeesServicesFavorites.Any(a => a.SEmployeesId == employeeId))
                : services.Search(s => s.ServiceName.ToLower(),
                    s => s.ServiceNameSmall.ToLower(),
                    s => s.ServiceMnemo.ToLower(),
                    s => s.Hashtag.ToLower()
                ).ContainingAll(searchData.Query.ToLower());

            var servicesFilteredCount = await filteredData.CountAsync();

            var dataPage = await filteredData.Skip(start).Take(length)
                .Select(s => new ActiveServicesDto
                {
                    Id = s.Id,
                    Name = s.ServiceName,
                    NameSmall = s.ServiceNameSmall,
                    ProviderName = s.SOffice.OfficeName,
                    isFavorite = s.DEmployeesServicesFavorites.Any(a => a.SEmployeesId == employeeId)
                }).ToListAsync();

            return (dataPage, servicesCount, servicesFilteredCount);
        }

        /// <summary>
        /// Процедуры услуги
        /// </summary>
        /// <param name="serviceId">id услуги</param>
        /// <returns></returns>
        public async Task<List<ActiveServiceProcedureDto>> GetServiceProcedures(Guid serviceId)
        {
            if (_context.SServices.Any(a => a.Id == serviceId && !a.IsRemove) == false)
                return new List<ActiveServiceProcedureDto>();

            return await _context.SServicesProcedures
                .AsNoTracking()
                .Where(w => !w.IsRemove && w.SServicesId == serviceId && w.ProcedureActive)
                .Select(s => new ActiveServiceProcedureDto
                {
                    Id = s.Id,
                    Name = s.ProcedureName,
                    AdditionalFormPath = s.ExtraFormPath
                })
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Тарифы услуги
        /// </summary>
        /// <param name="procedureId">id процедуры</param>
        /// <returns></returns>
        public async Task<List<ActiveServiceTariffDto>> GetServiceTariff(Guid procedureId, int? type)
        {
            if (_context.SServicesProcedures.Any(a => a.Id == procedureId && !a.IsRemove && a.ProcedureActive) == false)
                return new List<ActiveServiceTariffDto>();

            return await _context.SServicesCustomerTariffs
                .AsNoTracking()
                .Where(w => !w.IsRemove && w.SServicesProcedureId == procedureId && w.SServicesCustomer.SServicesCustomerTypeId == type)
                .Select(tariff => new ActiveServiceTariffDto
                {
                    Id = tariff.Id,
                    ServiceCustomerId = tariff.SServicesCustomerId,
                    CustomerTypeId = tariff.SServicesCustomer.SServicesCustomerType.Id,
                    CustomerTypeName = tariff.SServicesCustomer.SServicesCustomerType.TypeName,
                    TariffTypeName = tariff.SServicesTariffType.TariffTypeName,
                    WeekTypeId = tariff.SServicesWeekId,
                    WeekTypeName = tariff.SServicesWeek.TypeName,
                    CountDayProcessing = tariff.CountDayProcessing,
                    CountDayExecuting = tariff.CountDayExecution,
                    CountDayReturn = tariff.CountDayReturn,
                    TariffMfc = tariff.TariffMfc,
                    TariffOiv = tariff.Tariff,
                    Comment = tariff.Commentt,
                })
                .ToListAsync();
        }



        /// <summary>
        /// Создание услуги
        /// </summary>
        /// <param name="requestModel">Модель услуги</param>
        /// <returns></returns>
        public async Task<CreateCaseResponseModel> CreateCaseAsync(CreateCaseRequestModel requestModel)
        {
            try
            {
                const int serviceProcessStatusId = 0;
                const int workDays = 1;
                var date = DateTime.Now;
                var currentEmployee = await _employeeManager.GetFullInfoAsync();
                var responseModel = new CreateCaseResponseModel();

                if (currentEmployee is null) return responseModel.CreatedError(ErrorDescription.EmployeeNotFound);
                if (currentEmployee.Office is null) return responseModel.CreatedError(ErrorDescription.OfficeNotFound);

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
                    }).SingleOrDefaultAsync(sd => sd.Id == requestModel.TariffId);

                if (serviceCustomerTariff is null)
                    return responseModel.CreatedError("Тариф не найден."); //TODO добавить

                var newCaseId = await GenerateCaseId(currentEmployee.Office.Mnemo ?? "-");

                if (string.IsNullOrEmpty(newCaseId))
                    return responseModel.CreatedError("Номер обращения не сформирован");

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
                        s.SOffice.OfficeNameSmall,
                        s.FrguServiceId,
                        s.IasMkgu,
                        s.FrguName,
                        s.SOffice.OfficeFrguProviderId,
                        s.SServicesTypeId,
                        s.SServicesInteractionId,
                        s.IsIssueAuthority,
                        Procedure = s.SServicesProcedures.Where(w => w.Id == requestModel.ProcedureId).Select(s => new { s.FrguTargetId, s.IsMdm, s.ProcedureName }).FirstOrDefault()
                    }).SingleOrDefaultAsync(sd => sd.Id == requestModel.ServiceId);

                if (service is null) return responseModel.CreatedError(ErrorDescription.ServiceNotFound);
                if (service.Procedure is null) return responseModel.CreatedError(ErrorDescription.ProcedureNotFound);

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
                    .Where(w => w.SServicesId == requestModel.ServiceId && w.SRoutesStageId == requestModel.StageId && w.IsRemove == false)
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

                if (routeStage is null) return responseModel.CreatedError("Пользователь не может добавить обращение");

                string additionalData = AdditionalDataFix(requestModel.AdditionalData);

                DService dService = new()
                {
                    Id = newServiceId,
                    DCasesId = newCaseId,
                    DServicesIdParent = Guid.Empty,
                    DServicesDocumentIdParent = Guid.Empty,
                    SServicesCustomerTypeId = serviceCustomerTariff.SServicesCustomerTypeId,
                    SServicesId = requestModel.ServiceId,
                    SServicesProcedureId = requestModel.ProcedureId,
                    DateFact = routeStage.IsDateFact ? date : null,
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
                    ExtraInfo = additionalData,
                    SOfficesIdProvider = service.SOfficesId,
                    FrguProviderId = service.OfficeFrguProviderId,
                    FrguName = service.FrguName,
                    FrguServiceId = service.FrguServiceId,
                    FrguTargetId = service.Procedure.FrguTargetId,
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
                };

                var newCase = new DCase
                {
                    Id = newCaseId,
                    DateAdd = date,
                    TicketQueue = requestModel.Tiket,
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

                    DServicesDocuments = await _context.SServicesDocuments.AsNoTracking().Where(w =>
                            w.IsRemove == false && w.SServicesId == requestModel.ServiceId &&
                            (!w.SServicesProcedureId.HasValue || w.SServicesProcedureId.Value == requestModel.ProcedureId))
                        .Select(s => new DServicesDocument
                        {
                            DCasesId = newCaseId,
                            DServicesId = newServiceId,
                            SDocumentsId = s.SDocumentsId,
                            DocumentCount = s.DocumentCount,
                            DocumentType = s.DocumentType,
                            DocumentNeeds = s.DocumentNeeds,
                            IsCheck = false,
                            DateAdd = date
                        }).ToListAsync(),
                    DServicesDocumentsResults = await _context.SServicesDocumentsResults.AsNoTracking()
                        .Where(w => !w.IsRemove && w.SServicesId == requestModel.ServiceId &&
                        (!w.SServicesProcedureId.HasValue || w.SServicesProcedureId.Value == requestModel.ProcedureId))
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

                if (requestModel.Customer is not null)
                {
                    var customer = _mapper.Map<DServicesCustomer>(requestModel.Customer);
                    customer.Id = Guid.NewGuid();
                    customer.DCasesId = newCaseId;
                    customer.CustomerType = (int)CustomerType.Applicant;
                    customer.SEmployeesId = currentEmployee.Id;
                    customer.SOfficesId = currentEmployee.Office.Id;
                    customer.SEmployeesJobPositionId = currentEmployee.Job.Id;
                    customer.DateAdd = date;
                    customer.CustomerAddressDetail = JsonConvert.SerializeObject(requestModel.Customer.AddressDetails);
                    newCase.DServicesCustomers.Add(customer);

                    dService.CustomerName = requestModel.Customer.Fio();
                    dService.CustomerPhone1 = requestModel.Customer.CustomerPhone1;
                    dService.CustomerPhone2 = requestModel.Customer.CustomerPhone2;
                    dService.CustomerAddress = requestModel.Customer.CustomerAddress;
                    responseModel.SetCustomerId(customer.Id);
                    responseModel.SetCustomer(customer.Fio());
                    responseModel.SetCustomerType(SubjectCustomerType.Physical);
                }

                if (requestModel.Representative is not null)
                {
                    var representative = _mapper.Map<DServicesCustomer>(requestModel.Representative);
                    representative.Id = Guid.NewGuid();
                    representative.DCasesId = newCaseId;
                    representative.CustomerType = (int)CustomerType.Representative;
                    representative.SEmployeesId = currentEmployee.Id;
                    representative.SOfficesId = currentEmployee.Office.Id;
                    representative.SEmployeesJobPositionId = currentEmployee.Job.Id;
                    representative.DateAdd = date;
                    representative.CustomerAddressDetail = JsonConvert.SerializeObject(requestModel.Representative.AddressDetails);
                    newCase.DServicesCustomers.Add(representative);
                    responseModel.SetRecipientId(representative.Id);
                    responseModel.SetRecipient(representative.Fio());
                }

                if (requestModel.CustomerLegal is not null)
                {
                    requestModel.CustomerLegal.Id = Guid.NewGuid();
                    requestModel.CustomerLegal.DCasesId = newCaseId;
                    requestModel.CustomerLegal.SEmployeesId = currentEmployee.Id;
                    requestModel.CustomerLegal.SOfficesId = currentEmployee.Office.Id;
                    requestModel.CustomerLegal.SEmployeesJobPositionId = currentEmployee.Job.Id;
                    requestModel.CustomerLegal.DateAdd = date;
                    newCase.DServicesCustomersLegals.Add(requestModel.CustomerLegal);

                    dService.CustomerName = requestModel.CustomerLegal.CustomerName;
                    dService.CustomerPhone1 = requestModel.CustomerLegal.CustomerPhone1;
                    dService.CustomerPhone2 = requestModel.CustomerLegal.CustomerPhone2;
                    dService.CustomerAddress = requestModel.CustomerLegal.CustomerAddress;
                    responseModel.SetCustomerId(requestModel.CustomerLegal.Id);
                    responseModel.SetCustomer(requestModel.CustomerLegal.CustomerName);
                    responseModel.SetCustomerType(SubjectCustomerType.Legal);
                }

                newCase.DServices.Add(dService);

                var office = await _context.SOffices.AsNoTracking().Where(w => w.Id == currentEmployee.Office.Id).Select(s => new { s.SendMdm, s.MdmUid, s.ReceiveWindowsCount }).FirstAsync();

                await _context.AddAsync(newCase);

                if ((int)date.DayOfWeek < 7 && date.Hour >= 8 && date.Hour < 20 && service.Procedure.IsMdm is true && office.SendMdm is true && office.MdmUid is not null)
                { 
                    if(requestModel.StageId == 34)
                    {
                        var mdm = await _mdmService.MdmСonsultationDataServicesObjectsAsync(newServiceId, (Guid)office.MdmUid, requestModel.ProcedureId, newDServiceRouteStageId, office.ReceiveWindowsCount);
                        if (mdm is not null) await _context.AddRangeAsync(mdm);
                    }
                    else
                    {
                        var mdm = await _mdmService.MdmStartedDataServicesObjectsAsync(newServiceId, (Guid)office.MdmUid, requestModel.ProcedureId, newDServiceRouteStageId, office.ReceiveWindowsCount);
                        if (mdm is not null) await _context.AddRangeAsync(mdm);
                    }
                }

                await _context.SaveChangesAsync();

                responseModel.SetEmployee(currentEmployee.Name)
                    .SetEmployeeId(currentEmployee.Id)
                    .SetCaseId(newCase.Id)
                    .SetDserviceId(newServiceId)
                    .SetOfficeIdAdd(currentEmployee.Office.Id)
                    .SetService(service.ServiceNameSmall)
                    .SetProcedure(service.Procedure.ProcedureName)
                    .SetOfficeId(service.SOfficesId)
                    .SetOffice(service.OfficeNameSmall)
                    .SetDataReg(dataReg)
                    .SetTariff(serviceCustomerTariff.Tariff + serviceCustomerTariff.TariffMfc)
                    .CreatedSuccess();

                return responseModel;
            }
            catch (Exception e)
            {
                return new CreateCaseResponseModel().CreatedError(e.Message); //TODO изменить
            }
        }
    }
}
