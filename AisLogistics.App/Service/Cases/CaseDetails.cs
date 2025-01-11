using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Utils;
using AisLogistics.DataLayer.Entities.Models;
using Clave.Expressionify;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
namespace AisLogistics.App.Service
{
    public partial class CaseService : ICaseService
    {
        /// <summary>
        /// Услуги по id обращения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CasesDto?> GetServicesByCaseIdAsync(string id)
        {
            try
            {
                var userId = await _employeeManager.GetIdAsync();
                var services = await _context.DCases
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Expressionify()
                    .Where(w => w.Id == id)
                    .Select(x => new CasesDto
                    {
                        casesMainDto = new CasesMainDto
                        {
                            CaseId = x.Id,
                            DateAdd = x.DateAdd.ToShortDateString(),
                            Applicant = x.DServicesCustomersLegals.Count == 0 ? x.DServicesCustomers.Where(w => w.CustomerType == (int)CustomerType.Applicant).Select(ss => new ApplicantDto(ss.Id, ss.Fio(), ss.CustomerAddress, ss.CustomerPhone1)).First() :
                                                                                   x.DServicesCustomersLegals.Select(ss => new ApplicantDto(ss.Id, ss.CustomerName, ss.CustomerAddress, ss.CustomerPhone1)).First(),
                            CustomerType = x.DServicesCustomersLegals.Count == 0 ? 0 : 1,
                            Recipient = x.DServicesCustomers.Where(w => w.CustomerType == (int)CustomerType.Representative)
                                .Select(ss => new ApplicantDto(ss.Id, ss.Fio(), ss.CustomerAddress, ss.CustomerPhone1)).FirstOrDefault(),
                            CommentsCount = x.DServicesCommentts.Count,
                            NotificationsCount = x.DServicesCustomersCalls.Count + x.DServicesCustomersMessages.Count,
                            AuditCounts = x.DCasesViews.Count,
                            Tiket = x.TicketQueue
                        },
                        Services = x.DServices.Select(s => new CaseServiceDto
                        {
                            Id = s.Id,
                            IsRoot = s.DServicesIdParent == Guid.Empty,
                            Name = s.SServices.ServiceName,
                            InteractionName = s.SServices.SServicesInteraction.InteractionName,
                            ProcedureName = s.SServicesProcedure.ProcedureName,
                            OfficeId = s.SOfficesIdProvider,
                            Office = s.SServices.SOffice.OfficeNameSmall,
                            DepartamentId = s.SOfficesIdProviderDepartament,
                            DepartamentName = s.SOfficesIdProviderDepartamentNavigation.OfficeName,
                            Status = new StatusDto(s.SServicesStatusId, s.SServicesStatus.StatusName),
                            IsFavorite = x.DCasesFavorites.Any(a => a.SEmployeesId == userId),
                            EmployeeAdd = new EmployeeDto(s.SEmployeesIdAdd, NameSplitter.GetInitials(s.SEmployeesIdAddNavigation.EmployeeName), s.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                            SerivesStage = new SerivesStageDto
                            {
                                EmployeeCurrent = new EmployeeDto(s.SEmployeesIdCurrent, NameSplitter.GetInitials(s.SEmployeesIdCurrentNavigation.EmployeeName), s.SEmployeesJobPositionIdCurrentNavigation.JobPositionName),
                                Stage = new StageDto((int)s.SRoutesStageIdCurrent, s.SRoutesStage.StageName),

                            },
                            Days = s.DateFact.HasValue
                                    ? s.DateReg.Subtract(s.DateFact.Value).Days
                                    : s.DateReg.Subtract(DateTime.Today).Days,
                        }).ToList()

                    }).FirstAsync();

                services.casesMainDto.Notes.AddRange(await _context.DNotes.Where(w => w.DCasesId == id && w.SEmployeesId == userId)
                    .Select(s =>
                    new NotesDto
                    {
                        Id = s.Id,
                        NotesText = s.NoteText,
                        DateReminder = s.DateReminder
                    }).ToListAsync());

                return services;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CaseServiceDto?> GetCasesServicesAsync(Guid id)
        {
            try
            {
                var userId = await _employeeManager.GetIdAsync();
                var services = await _context.DServices
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Expressionify()
                    .Where(w => w.Id == id)
                    .Select(s => new CaseServiceDto
                    {
                        Id = s.Id,
                        CaseId = s.DCasesId,
                        IsRoot = s.DServicesIdParent == Guid.Empty,
                        ServiceId = s.SServices.Id,
                        Name = s.SServices.ServiceName,
                        InteractionName = s.SServices.SServicesInteraction.InteractionName,
                        ProcedureId = s.SServicesProcedureId,
                        ProcedureName = s.SServicesProcedure.ProcedureName,
                        OfficeId = s.SOfficesIdProvider,
                        Office = s.SServices.SOffice.OfficeNameSmall,
                        DepartamentId = s.SOfficesIdProviderDepartament,
                        DepartamentName = s.SOfficesIdProviderDepartamentNavigation.OfficeName,
                        Status = new StatusDto(s.SServicesStatusId, s.SServicesStatus.StatusName),
                        EmployeeAdd = new EmployeeDto(s.SEmployeesIdAdd, NameSplitter.GetInitials(s.SEmployeesIdAddNavigation.EmployeeName), s.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                        SerivesStage = new SerivesStageDto
                        {
                            EmployeeCurrent = new EmployeeDto(s.SEmployeesIdCurrent, NameSplitter.GetInitials(s.SEmployeesIdCurrentNavigation.EmployeeName), s.SEmployeesJobPositionIdCurrentNavigation.JobPositionName),
                            Stage = new StageDto((int)s.SRoutesStageIdCurrent, s.SRoutesStage.StageName),

                        },
                        Days = s.DateFact.HasValue
                                ? s.DateReg.Subtract(s.DateFact.Value).Days
                                : s.DateReg.Subtract(DateTime.Today).Days,
                    }).FirstAsync();


                return services;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CaseServiceDto?> GetCasesServicesParentAsync(string id)
        {
            try
            {
                var userId = await _employeeManager.GetIdAsync();
                var services = await _context.DServices
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Expressionify()
                    .Where(w => w.DCasesId == id&&w.DServicesIdParent==Guid.Empty)
                    .Select(s => new CaseServiceDto
                    {
                        Id = s.Id,
                        CaseId = s.DCasesId,
                        IsRoot = s.DServicesIdParent == Guid.Empty,
                        ServiceId = s.SServices.Id,
                        Name = s.SServices.ServiceName,
                        InteractionName = s.SServices.SServicesInteraction.InteractionName,
                        ProcedureId = s.SServicesProcedureId,
                        ProcedureName = s.SServicesProcedure.ProcedureName,
                        OfficeId = s.SOfficesIdProvider,
                        Office = s.SServices.SOffice.OfficeNameSmall,
                        DepartamentId = s.SOfficesIdProviderDepartament,
                        DepartamentName = s.SOfficesIdProviderDepartamentNavigation.OfficeName,
                        Status = new StatusDto(s.SServicesStatusId, s.SServicesStatus.StatusName),
                        EmployeeAdd = new EmployeeDto(s.SEmployeesIdAdd, NameSplitter.GetInitials(s.SEmployeesIdAddNavigation.EmployeeName), s.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                        SerivesStage = new SerivesStageDto
                        {
                            EmployeeCurrent = new EmployeeDto(s.SEmployeesIdCurrent, NameSplitter.GetInitials(s.SEmployeesIdCurrentNavigation.EmployeeName), s.SEmployeesJobPositionIdCurrentNavigation.JobPositionName),
                            Stage = new StageDto((int)s.SRoutesStageIdCurrent, s.SRoutesStage.StageName),

                        },
                        Days = s.DateFact.HasValue
                                ? s.DateReg.Subtract(s.DateFact.Value).Days
                                : s.DateReg.Subtract(DateTime.Today).Days,
                    }).FirstAsync();


                return services;
            }
            catch
            {
                return null;
            }
        }


        public async Task ViewCaseAsync(string id)
        {
            var employee = await _employeeManager.GetFullInfoAsync();
            await _context.DCasesViews.AddAsync(new DCasesView
            {
                DCasesId = id,
                EmployeesName = employee.Name,
                JobPositionName = employee.Job.Name,
                OfficeName = employee?.Office?.Name,
                SEmployeesId = employee.Id
            });
            await _context.SaveChangesAsync();
        }
    }
}
