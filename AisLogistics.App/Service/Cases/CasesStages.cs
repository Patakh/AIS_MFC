using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Utils;
using AisLogistics.DataLayer.Entities.Models;
using AisLogistics.DataLayer.Utils;
using Clave.Expressionify;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public partial class CaseService : ICaseService
    {
        public async Task<List<CaseServiceStageDto>> GetStagesByServiceIdAsync(Guid id)
        {
            return await _context.DServicesRoutesStages
                .AsNoTracking()
                .Where(w => w.DServicesId == id)
                .Select(s => new CaseServiceStageDto
                {
                    Id = s.Id,
                    Name = s.SRoutesStage.StageName,
                    Days = s.DateReg.HasValue
                        ? (s.DateFact.HasValue
                            ? s.DateReg.Value.Subtract(s.DateFact.Value).Days
                            : s.DateReg.Value.Subtract(DateTime.Now).Days)
                        : null,
                    DateAdd = s.DateAdd,
                    EmployeeCurrent = new EmployeeDto(s.SEmployeesId, NameSplitter.GetInitials(s.SEmployees.EmployeeName),
                        s.SEmployeesJobPosition.JobPositionName),
                    EmployeeAdd = new EmployeeDto(s.SEmployeesIdAdd, NameSplitter.GetInitials(s.EmployeesFioAdd),
                        s.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                    DateReg = s.DateReg,
                    DateFact = s.DateFact,
                    IsAutomaticallyTransferred = s.PassAutomatically
                })
                .OrderByDescending(o => o.DateAdd)
                .ToListAsync();
        }
        public async Task<List<StageDto>> GetStagesNextAllAsync(List<Guid> id)
        {
            try
            {
                return await _context.DServices
                    .AsNoTracking()
                    .Where(w => id.Contains(w.Id))
                    .Select(s => s.SServices.SServicesRoutesStages
                                .Where(w => !w.IsRemove && w.ParentId == Guid.Empty)
                                .Select(ss => new StageDto(ss.SRoutesStage.Id, ss.SRoutesStage.StageName, ss.SRoutesStage.DayExcution, ss.SRoutesStage.Commentt)).ToList()
                            ).FirstAsync();

            }
            catch (Exception e)
            {
                var a = e.Message;
                return new List<StageDto>();
            }
        }

        public async Task<List<StageDto>> GetStagesNextByServiceIdAsync(List<Guid> id)
        {
            try
            {
                var services = await _context.DServices.Where(w => id.Contains(w.Id))
                    .AsNoTracking()
                    .Expressionify()
                    .Select(s => new
                    {
                        CurrentstageId = s.DServicesRoutesStages.OrderByDescending(o => o.DateAdd).Select(s => s.SRoutesStageId).First(),
                        ServiceId = s.SServicesId,
                        Stages = s.SServices.SServicesRoutesStages.Where(w => !w.IsRemove).Select(ss => new { routeStages = ss, stage = ss.SRoutesStage }).ToList()
                    }).ToListAsync();

                if (services is null or { Count: 0 }) throw new ArgumentException(ErrorDescription.ServiceNotFound);

                List<StageDto> stages = new();
                Guid stageParentId;

                foreach (var ser in services)
                {
                    stageParentId = ser.Stages.Where(w => w.routeStages.SRoutesStageId == ser.CurrentstageId && w.routeStages.ParentId == Guid.Empty).Select(s => s.routeStages.Id).First();
                    ser.Stages?.RemoveAll(a => a.routeStages.ParentId != stageParentId);
                    if (ser.Stages is not null) stages.AddRange(ser.Stages.Select(s => new StageDto(s.stage.Id, s.stage.StageName, s.stage.DayExcution, s.stage.Commentt)).ToList());
                }

                if (stages.Count == 0) return new List<StageDto>();

                return stages.GroupBy(gb => gb.Id, (_, g) => g.First()).ToList();
            }
            catch (Exception e)
            {
                var a = e.Message;
                return new List<StageDto>();
            }
        }

        public async Task<List<EmployeesDtO>?> GetStagesNextEmployessByServiceIdAsync(ServiceStageNextEmployessDto request)
        {
            try
            {
                var date = DateTime.Today.Date;
                const int statusActive = 0;
                //const int statusSick = 4;

                var services = await _context.DServices
                    .AsNoTracking()
                    .Where(w => request.serviceId.Contains(w.Id))
                    .Select(s => new
                    {
                        roles = s.SServices.SServicesRoutesStages.Where(w => w.SRoutesStageId == request.stageId && w.ParentId == Guid.Empty).Select(ss => ss.SServicesRoutesStageRoles.Select(s => s.SRolesExecutorId).ToList()).First()
                    }).ToListAsync();
                if (services is null or { Count: 0 }) throw new ArgumentException(ErrorDescription.ServiceNotFound);

                List<Guid> roles = new();

                foreach (var ser in services)
                {
                    roles.AddRange(ser.roles);
                }

                roles = roles.Distinct().ToList();

                var employees = await _context.SEmployees
                    .AsNoTracking()
                    .Where(w => !w.IsRemove
                        && w.SEmployeesStatusJoins.Any(a => !a.IsRemove && a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop >= date.Date) && a.SEmployeesStatusId == statusActive)
                        && w.SEmployeesExecutions.Any(a => !a.IsRemove && a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop >= date.Date))
                        && w.SOfficesAuthorizations.Any(a => !a.IsRemove && a.SOfficesId == request.officeId && a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop >= date.Date))
                        && (roles.Count == 0 || w.SEmployeesRolesExecutors.Any(a => roles.Contains(a.SRolesExecutorId)))
                    )
                    .Select(s => new EmployeesDtO { Id = s.Id, Name = s.EmployeeName })
                    .ToListAsync();

                if (employees is null or { Count: 0 }) throw new ArgumentException(ErrorDescription.EmployeeNotFound);

                //employees.Add(new EmployeesDtO { Id = Guid.Empty, Name = "Автоматически" });

                return employees.OrderBy(o => o.Id).ToList();
            }
            catch (Exception e)
            {
                var a = e.Message;
                return null;
            }
        }

        public async Task<bool> AddServiceStageAsync(ServiceStageSaveDto request)
        {
            try
            {
                const int statusActive = 0;
                const int statusSick = 4;
                const int stageProcessing = 2;
                const int stageOiv = 4;
                const int workDays = 1;
                var date = DateTime.Today;

                var employee = await _employeeManager.GetFullInfoAsync();

                var services = await _context.DServices
                    .AsSplitQuery()
                    .Where(w => request.serviceId.Contains(w.Id))
                    .Select(s => new
                    {
                        service = s,
                        s.SServicesProcedure.IsMdm,
                        receivedStage = s.DServicesRoutesStages.Where(w => w.SRoutesStageId == 1).Select(s => s.Id).First(),
                        stage = s.DServicesRoutesStages.OrderByDescending(m => m.DateAdd).First(),
                        nextStage = s.SServices.SServicesRoutesStages.Where(w => w.SRoutesStageId == request.stageId && w.ParentId == Guid.Empty).Select(ss => new { stage = ss, roles = ss.SServicesRoutesStageRoles.Select(s => s.SRolesExecutorId).ToList() }).First()
                    }).ToListAsync();

                if (services is null or { Count: 0 }) throw new ArgumentException(ErrorDescription.ServiceNotFound);

                var office = await _context.SOffices.Where(w => w.Id == employee.Office.Id).Select(s => new { s.SendMdm, s.MdmUid }).FirstAsync();

                List<Guid> roles = new();
                List<Guid> employeesId = new();

                foreach (var fe in services)
                {
                    roles.AddRange(fe.nextStage.roles);
                    employeesId.Add(fe.stage.SEmployeesId);
                }

                roles = roles.Distinct().ToList();
                employeesId = employeesId.Distinct().ToList();

                int jobPositionalId;

                if (request.employeeId == Guid.Empty)
                {
                    var employeeFirst = await _context.SEmployees
                        .AsSplitQuery()
                        .AsNoTracking()
                        .OrderBy(o => o.DServicesRoutesStageSEmployees.Count(w =>
                            w.DateAdd.Date.CompareTo(DateTime.Now.Date) == 0 && w.DateFact == null))
                        .Where(w => employeesId.Contains(w.Id)
                                    && w.SEmployeesStatusJoins.Any(a => a.DateStart.CompareTo(DateTime.Today) <= 0 &&
                                                                        (a.DateStop == null ||
                                                                         a.DateStop.Value.CompareTo(DateTime.Today) >= 0) &&
                                                                        (a.SEmployeesStatusId == statusActive ||
                                                                         a.SEmployeesStatusId == statusSick))
                                    && w.SEmployeesExecutions.Any(a =>
                                        !a.IsRemove && a.DateStart.CompareTo(DateTime.Today) <= 0 &&
                                        (a.DateStop == null || a.DateStop.Value.CompareTo(DateTime.Today) >= 0))
                                    && (!roles.Any() ||
                                        w.SEmployeesRolesExecutors.Any(a => roles.Contains(a.SRolesExecutorId)))
                                    && w.SEmployeesOfficesJoins.Any(a =>
                                        !a.IsRemove && a.DateStart.CompareTo(DateTime.Today) <= 0 && (a.DateStop == null ||
                                            a.DateStop.Value.CompareTo(DateTime.Today) >=
                                            0) && a.SOfficesId == request.officeId)
                        )
                        .Select(s => new
                        {
                            s.Id,
                            s.SEmployeesOfficesJoins.FirstOrDefault(fd =>
                                    !fd.IsRemove && fd.DateStart.CompareTo(DateTime.Today) <= 0 &&
                                    (fd.DateStop == null || fd.DateStop.Value.CompareTo(DateTime.Today) >= 0))
                                .SEmployeesJobPositionId,
                            CurrentStage = s.DServicesRoutesStageSEmployees.Count(w => w.DateFact == null)
                        })
                        .FirstOrDefaultAsync();

                    if (employeeFirst is null)
                    {
                        var employeeSecond = await _context.SEmployeesOfficesJoins
                            .AsSplitQuery()
                            .AsNoTracking()
                            .OrderBy(o => o.SEmployees.DServicesRoutesStageSEmployees.Count(w =>
                                w.DateAdd.Date.CompareTo(DateTime.Now.Date) == 0 && w.DateFact == null))
                            .Where(w => w.SOfficesId == request.officeId && !w.IsRemove
                                && w.SEmployees.SEmployeesStatusJoins.Any(a => a.DateStart.CompareTo(DateTime.Today) <= 0 &&
                                                                               (a.DateStop == null ||
                                                                                a.DateStop.Value
                                                                                    .CompareTo(DateTime.Today) >= 0) &&
                                                                               (a.SEmployeesStatusId == statusActive ||
                                                                                a.SEmployeesStatusId == statusSick))
                                && w.SEmployees.SEmployeesExecutions.Any(a =>
                                    !a.IsRemove && a.DateStart.CompareTo(DateTime.Today) <= 0 &&
                                    (a.DateStop == null || a.DateStop.Value.CompareTo(DateTime.Today) >= 0))
                                && w.DateStart.CompareTo(DateTime.Today) <= 0
                                && (w.DateStop == null || w.DateStop.Value.CompareTo(DateTime.Today) >= 0)
                                && (!roles.Any() ||
                                    w.SEmployees.SEmployeesRolesExecutors.Any(a => roles.Contains(a.SRolesExecutorId)))
                            )
                            .Select(s => new { s.SEmployeesId, s.SEmployeesJobPositionId })
                            .FirstOrDefaultAsync();

                        if (employeeSecond is null) //return NotFound(ErrorDescription.EmployeeNotFound);
                        {
                            var currentEmployee = await _employeeManager.GetFullInfoAsync();
                            request.employeeId = currentEmployee.Id;
                            jobPositionalId = currentEmployee.Job.Id;
                        }
                        else
                        {
                            request.employeeId = employeeSecond.SEmployeesId;
                            jobPositionalId = employeeSecond.SEmployeesJobPositionId;
                        }

                    }
                    else
                    {
                        request.employeeId = employeeFirst.Id;
                        jobPositionalId = employeeFirst.SEmployeesJobPositionId;
                    }
                }

                else
                {
                    jobPositionalId = await _context.SEmployeesOfficesJoins
                        .Where(w => w.SEmployeesId == request.employeeId && !w.IsRemove &&
                                    w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop >= date.Date))
                        .Select(s => s.SEmployeesJobPositionId)
                        .FirstOrDefaultAsync();
                }

                var serviceRouteNext = await _context.SRoutesStages.Select(s => new
                {
                    StageId = s.Id,
                    Name = s.StageName,
                    Comment = s.Commentt,
                    Days = s.DayExcution,
                    StatusId = s.SServicesStatusId,
                    IsDateFact = s.SServicesStatusId.HasValue ? s.SServicesStatus.IsDatefact : false
                }).FirstAsync(f => f.StageId == request.stageId);

                foreach (var ser in services)
                {
                    ser.stage.DateFact = DateTime.Now;
                    ser.stage.TimeFact = TimeOnly.FromDateTime(DateTime.Now);
                    ser.stage.CountDayFact = DateTime.Now.Subtract(ser.stage.DateAdd).Days;

                    var countDay = serviceRouteNext.StageId switch
                    {
                        stageProcessing => await _context.SCalendars
                            .Where(w => w.DateType == 1 && w.Date >= DateTime.Now)
                            .Skip(ser.service.CountDayProcessing)
                            .Select(s => s.Date.Subtract(DateTime.Now).Days)
                            .FirstOrDefaultAsync(),
                        stageOiv when ser.service.SServicesWeekId == workDays => await _context.SCalendars
                            .Where(w => w.DateType == 1 && w.Date >= DateTime.Now)
                            .Skip(ser.service.CountDayExecution + ser.service.CountDayReturn)
                            .Select(s => s.Date.Subtract(DateTime.Now).Days)
                            .FirstOrDefaultAsync(),
                        stageOiv => ser.service.CountDayExecution + ser.service.CountDayReturn,
                        _ => serviceRouteNext.Days
                    };

                    _context.Update(ser.stage);

                    await _context.AddAsync(new DServicesRoutesStage
                    {
                        Id = Guid.NewGuid(),
                        DServicesIdParent = ser.service.DServicesIdParent,
                        DServicesId = ser.service.Id,
                        DCasesId = ser.service.DCasesId,
                        DateAdd = DateTime.Now,
                        CountDayExecution = countDay,
                        DateReg = countDay != 0 ? DateTime.Now.AddDays(countDay) : null,
                        SEmployeesId = request.employeeId,
                        SEmployeesJobPositionId = jobPositionalId,
                        SOfficesId = request.officeId,
                        PassAutomatically = request.employeeId == Guid.Empty,
                        SRoutesStageId = serviceRouteNext.StageId,
                        SEmployeesIdAdd = employee.Id,
                        EmployeesFioAdd = employee.Name,
                        SEmployeesJobPositionIdAdd = employee.Job.Id
                    });

                    ser.service.SRoutesStageIdCurrent = serviceRouteNext.StageId;
                    ser.service.RoutesStageDateRegCurrent = countDay != 0 ? DateTime.Now.AddDays(countDay) : null;
                    ser.service.SEmployeesIdCurrent = request.employeeId;
                    ser.service.SEmployeesJobPositionIdCurrent = jobPositionalId;
                    ser.service.SOfficesIdCurrent = request.officeId;

                    if (serviceRouteNext.StatusId.HasValue && ser.service.SServicesStatusId != serviceRouteNext.StatusId)
                    {
                        ser.service.SServicesStatusId = serviceRouteNext.StatusId.Value;
                        if (serviceRouteNext.IsDateFact)
                        {
                            ser.service.DateFact = DateTime.Now;
                            ser.service.SEmployeesIdExecution = employee.Id;
                            ser.service.SEmployeesJobPositionIdExecution = employee.Job.Id;
                            ser.service.SOfficesIdExecution = employee.Office.Id;
                        }
                    }
                    _context.Update(ser.service);

                    if (ser.IsMdm is true && office.SendMdm is true && office.MdmUid is not null)
                    {
                        if (serviceRouteNext.StageId == 7)
                        {
                            var mdm = await _mdmService.MdmServiceResultsReceivedObjectsAsync(ser.service.Id, (Guid)office.MdmUid);
                            if (mdm is not null) await _context.AddRangeAsync(mdm);
                        }
                        if (serviceRouteNext.StageId == 8)
                        {
                            var isDeadLine = ser.service.DateFact.HasValue ? ser.service.DateReg < ser.service.DateFact : ser.service.DateReg < DateTime.Now;
                            var mdm = await _mdmService.MdmServiceProcessingEndedObjectsAsync(ser.service.Id, (Guid)office.MdmUid, 0, isDeadLine, ser.receivedStage);
                            if (mdm is not null) await _context.AddRangeAsync(mdm);
                        }
                        if (serviceRouteNext.StageId == 9)
                        {
                            var isDeadLine = ser.service.DateFact.HasValue ? ser.service.DateReg < ser.service.DateFact : ser.service.DateReg < DateTime.Now;
                            var mdm = await _mdmService.MdmServiceProcessingEndedObjectsAsync(ser.service.Id, (Guid)office.MdmUid, 4, isDeadLine, ser.receivedStage);
                            if (mdm is not null) await _context.AddRangeAsync(mdm);
                        }
                        if (serviceRouteNext.StageId == 11)
                        {
                            var isDeadLine = ser.service.DateFact.HasValue ? ser.service.DateReg < ser.service.DateFact : ser.service.DateReg < DateTime.Now;
                            var mdm = await _mdmService.MdmServiceProcessingEndedObjectsAsync(ser.service.Id, (Guid)office.MdmUid, 1, isDeadLine, ser.receivedStage);
                            if (mdm is not null) await _context.AddRangeAsync(mdm);
                        }
                        if (serviceRouteNext.StageId == 14)
                        {
                            var mdm = await _mdmService.MdmServiceProcessingHoldObjectsAsync(ser.service.Id, (Guid)office.MdmUid);
                            if (mdm is not null) await _context.AddRangeAsync(mdm);
                        }
                        if (serviceRouteNext.StageId == 17)
                        {
                            var isDeadLine = ser.service.DateFact.HasValue ? ser.service.DateReg < ser.service.DateFact : ser.service.DateReg < DateTime.Now;
                            var mdm = await _mdmService.MdmServiceProcessingEndedObjectsAsync(ser.service.Id, (Guid)office.MdmUid, 5, isDeadLine, ser.receivedStage);
                            if (mdm is not null) await _context.AddRangeAsync(mdm);
                        }
                        if (serviceRouteNext.StageId == 34)
                        {
                            var isDeadLine = ser.service.DateFact.HasValue ? ser.service.DateReg < ser.service.DateFact : ser.service.DateReg < DateTime.Now;
                            var mdm = await _mdmService.MdmServiceProcessingEndedObjectsAsync(ser.service.Id, (Guid)office.MdmUid, 0, isDeadLine, ser.receivedStage);
                            if (mdm is not null) await _context.AddRangeAsync(mdm);
                        }
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<(bool, int)> AddServiceStageUnclaimedAsync(ServiceStageSaveDto request)
        {
            const int stageToIssue = 6;
            var count = 0;
            try
            {
                var employee = await _employeeManager.GetFullInfoAsync();

                var services = await _context.DServices
                    .AsSplitQuery()
                    .Where(w => request.serviceId.Contains(w.Id))
                    .Select(s => new
                    {
                        service = s,
                        stage = s.DServicesRoutesStages.OrderByDescending(m => m.DateAdd).FirstOrDefault(),

                    })
                    .ToListAsync();

                var serviceRouteNext = await _context.SRoutesStages.Select(s => new
                {
                    StageId = s.Id,
                    Name = s.StageName,
                    Comment = s.Commentt,
                    Days = s.DayExcution,
                    StatusId = s.SServicesStatusId,
                    IsDateFact = s.SServicesStatusId.HasValue ? s.SServicesStatus.IsDatefact : false
                }).FirstAsync(f => f.StageId == request.stageId);

                var jobPositionalId = await _context.SEmployeesOfficesJoins
                        .Where(w => w.SEmployeesId == request.employeeId && w.SOfficesId == request.officeId && !w.IsRemove
                                                                 && w.DateStart.CompareTo(DateTime.Today) <= 0
                                                                 && (w.DateStop == null ||
                                                                     w.DateStop.Value.CompareTo(DateTime.Today) >= 0))
                        .Select(s => s.SEmployeesJobPositionId)
                        .FirstOrDefaultAsync();

                foreach (var ser in services)
                {
                    if (ser.stage != null && ser.stage.SRoutesStageId == stageToIssue)
                    {
                        ser.stage.DateFact = DateTime.Now;
                        ser.stage.TimeFact = TimeOnly.FromDateTime(DateTime.Now);
                        ser.stage.CountDayFact = DateTime.Now.Subtract(ser.stage.DateAdd).Days;

                        var countDay = serviceRouteNext.Days;

                        _context.Update(ser.stage);

                        await _context.AddAsync(new DServicesRoutesStage
                        {
                            Id = Guid.NewGuid(),
                            DServicesIdParent = ser.service.DServicesIdParent,
                            DServicesId = ser.service.Id,
                            DCasesId = ser.service.DCasesId,
                            DateAdd = DateTime.Now,
                            CountDayExecution = countDay,
                            DateReg = countDay != 0 ? DateTime.Now.AddDays(countDay) : null,
                            SEmployeesId = request.employeeId,
                            SEmployeesJobPositionId = jobPositionalId,
                            SOfficesId = request.officeId,
                            PassAutomatically = request.employeeId == Guid.Empty,
                            SRoutesStageId = serviceRouteNext.StageId,
                            SEmployeesIdAdd = employee.Id,
                            EmployeesFioAdd = employee.Name,
                            SEmployeesJobPositionIdAdd = employee.Job.Id
                        });

                        ser.service.SRoutesStageIdCurrent = serviceRouteNext.StageId;
                        ser.service.RoutesStageDateRegCurrent = countDay != 0 ? DateTime.Now.AddDays(countDay) : null;
                        ser.service.SEmployeesIdCurrent = request.employeeId;
                        ser.service.SEmployeesJobPositionIdCurrent = jobPositionalId;
                        ser.service.SOfficesIdCurrent = request.officeId;

                        if (serviceRouteNext.StatusId.HasValue && ser.service.SServicesStatusId != serviceRouteNext.StatusId)
                        {
                            ser.service.SServicesStatusId = serviceRouteNext.StatusId.Value;
                            if (serviceRouteNext.IsDateFact)
                            {
                                ser.service.DateFact = DateTime.Now;
                                ser.service.SEmployeesIdExecution = employee.Id;
                                ser.service.SEmployeesJobPositionIdExecution = employee.Job.Id;
                                ser.service.SOfficesIdExecution = employee.Office.Id;
                            }

                        }
                        _context.Update(ser.service);

                        count++;
                    }
                }

                await _context.SaveChangesAsync();
                return (true, count);
            }
            catch (Exception e)
            {
                return (false, count);
            }
        }
    }
}
