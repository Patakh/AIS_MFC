using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Сотрудники
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        public async Task<EmployeeModelDto> GetEmployeeDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SEmployees
                .AsNoTracking()
                .Where(w=>w.Id == Id)
                .Include(i=>i.AspNetUser)
                .Select(s=> _mapper.Map<EmployeeModelDto>(s))
                .FirstOrDefaultAsync();
            if (result == null)
                throw new ArgumentException("Данные не найдены!");

            return result;
        }

        public async Task<bool> GetEmployeeAnyAsync(Guid? Id)
        {
            try
            {
                if (Id is null)
                    throw new ArgumentNullException(nameof(Id));

                return await _context.SEmployees.AnyAsync(a => a.Id == Id && !a.IsRemove);
            }
            catch
            {
                return false;
            } 
          
        }

        public async Task<List<EmployeeModelDto>> GetEmployeesDtoAsync(List<Guid> Id)
        {
            return await _context.SEmployees
                .AsNoTracking()
                .Where(w => Id.Any(a => a == w.Id))
                .Select(s => new EmployeeModelDto { Id = s.Id, EmployeeName = s.EmployeeName })
                .ToListAsync();
        }

        public async Task<List<EmployeeModelDto>> GetEmployeesDtoAsync()
        {
            return await _context.SEmployees
                .AsNoTracking()
                .Where(w => w.AspNetUserId==null)
                .Select(s => _mapper.Map<EmployeeModelDto>(s))
                .ToListAsync();
        }

        public async Task<(List<EmployeesOfficesJoinDto>, int, int)> GetReferencesEmployees(IDataTablesRequest request, Guid officeId, string search)
        {
            try
            {
                var date = DateTime.Today;

                var results = _context.SEmployees
                   .AsNoTracking()
                   .AsSplitQuery()
                   .Where(x => !x.IsRemove && 
                   (officeId==Guid.Empty|| x.SEmployeesOfficesJoins.Any(a => !a.IsRemove && a.SOfficesId==officeId && a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop.Value.Date >= date.Date))));

                int totalCount = await results.CountAsync();

                var filteredResult = string.IsNullOrEmpty(search)
                    ? results
                    : results.Search(s => s.EmployeeName.ToLower()).Containing(search.ToLower());

                int filteredCount = string.IsNullOrEmpty(search) ? totalCount : await filteredResult.CountAsync();

                var dataPage = await filteredResult
                    .OrderBy(o => o.EmployeeName)
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(x => new EmployeesOfficesJoinDto
                    {
                        SEmployeesId = x.Id,
                        EmployeeName = x.EmployeeName,
                        EmployeeOfficeInfo = x.SEmployeesOfficesJoins.Where(w => !w.IsRemove && w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop.Value.Date >= date.Date)).Select(xx => new EmployeeOffice
                        {
                            SOfficesId = xx.SOfficesId,
                            OfficeName = xx.SOffices.OfficeNameSmall,
                            SEmployeesJobPositionId = xx.SEmployeesJobPositionId,
                            JobPositionName = xx.SEmployeesJobPosition.JobPositionName
                        }).FirstOrDefault(),
                        EmployeeStatusInfo = x.SEmployeesStatusJoins.Where(w => !w.IsRemove && w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop.Value.Date >= date.Date)).Select(xx => new EmployeeStatus
                        {
                            SEmployeesStatusId = xx.SEmployeesStatusId,
                            StatusName = xx.SEmployeesStatus.StatusName,
                        }).FirstOrDefault(),
                        IsExecution = x.SEmployeesExecutions.Any(xx => !xx.IsRemove && xx.DateStart.Date <= date.Date && (xx.DateStop == null || xx.DateStop.Value.Date >= date.Date)),
                        IsActive = x.SEmployeesActives.Any(xx => !xx.IsRemove && xx.DateStart.Date <= date.Date && (xx.DateStop == null || xx.DateStop.Value.Date >= date.Date))

                    })
                    .ToListAsync();

                return (dataPage, totalCount, filteredCount);
            }
            catch
            {
                return (new List<EmployeesOfficesJoinDto>(), 0, 0);
            }
        }

        public async Task<List<EmployeesOfficesJoinDto>> GetReferencesAllEmployees()
        {
            try
            {
                var date = DateTime.Today;

                return await _context.SEmployees
                   .AsNoTracking()
                   .Where(x => !x.IsRemove)
                   .Select(x => new EmployeesOfficesJoinDto
                   {
                       SEmployeesId = x.Id,
                       EmployeeName = x.EmployeeName,
                       EmployeeOfficeInfo = x.SEmployeesOfficesJoins.Where(w => !w.IsRemove && w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop.Value.Date > date.Date)).Select(xx => new EmployeeOffice
                       {
                           SOfficesId = xx.SOfficesId,
                           OfficeName = xx.SOffices.OfficeName,
                           SEmployeesJobPositionId = xx.SEmployeesJobPositionId,
                           JobPositionName = xx.SEmployeesJobPosition.JobPositionName
                       }).FirstOrDefault(),
                       EmployeeStatusInfo = x.SEmployeesStatusJoins.Where(w => !w.IsRemove && w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop.Value.Date > date.Date)).Select(xx => new EmployeeStatus
                       {
                           SEmployeesStatusId = xx.SEmployeesStatusId,
                           StatusName = xx.SEmployeesStatus.StatusName,
                       }).FirstOrDefault(),
                       IsExecution = x.SEmployeesExecutions.Any(xx => !xx.IsRemove && xx.DateStart.Date <= date.Date && (xx.DateStop == null || xx.DateStop.Value > date.Date)),
                       IsActive = x.SEmployeesActives.Any(xx => !xx.IsRemove && xx.DateStart.Date <= date.Date && (xx.DateStop == null || xx.DateStop.Value.Date > date))

                   }).ToListAsync();


            }
            catch
            {
                return new List<EmployeesOfficesJoinDto>();
            }
        }

        public async Task<List<EmployeesOfficesJoinDto>> GetReferencesActiveEmployees(List<Guid> officesId)
        {
            try
            {
                var date = DateTime.Now;
                var resuslt = await _context.SEmployees
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Where(w => w.SEmployeesOfficesJoins.Any(a => !a.IsRemove && a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop.Value.Date >= date.Date) && officesId.Contains(a.SOfficesId)) &&
                               w.SEmployeesActives.Any(a => !a.IsRemove && a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop.Value >= date.Date)))
                    .Select(x => new EmployeesOfficesJoinDto
                    {
                        SEmployeesId = x.Id,
                        EmployeeName = x.EmployeeName,
                        EmployeeOfficeInfo = x.SEmployeesOfficesJoins.Where(w => !w.IsRemove && w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop.Value.Date >= date)).Select(xx => new EmployeeOffice
                        {
                            SOfficesId = xx.SOfficesId,
                            OfficeName = xx.SOffices.OfficeNameSmall,
                            SEmployeesJobPositionId = xx.SEmployeesJobPositionId,
                            JobPositionName = xx.SEmployeesJobPosition.JobPositionName
                        }).FirstOrDefault(),
                        EmployeeStatusInfo = x.SEmployeesStatusJoins.Where(w => !w.IsRemove && w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop.Value.Date >= date)).Select(xx => new EmployeeStatus
                        {
                            SEmployeesStatusId = xx.SEmployeesStatusId,
                            StatusName = xx.SEmployeesStatus.StatusName,
                        }).FirstOrDefault(),
                        IsExecution = x.SEmployeesExecutions.Any(xx => !xx.IsRemove && xx.DateStart.Date <= date.Date && (xx.DateStop == null || xx.DateStop.Value.Date >= date)),
                        IsActive = x.SEmployeesActives.Any(xx => !xx.IsRemove && xx.DateStart.Date <= date.Date && (xx.DateStop == null || xx.DateStop.Value.Date >= date))
                    }).ToListAsync();

                return resuslt;


            }
            catch
            {
                return new List<EmployeesOfficesJoinDto>();
            }
        }

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        public async Task<Guid> AddEmployeeAsync(EmployeeModelDto model)
        {
            var entity = _mapper.Map<SEmployee>(model);

            await _context.SEmployees.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>
        /// Добавить пользователя и связанные с ним данные
        /// </summary>
        public async Task<Guid> AddEmployeeWithLinkedDataAsync(EmployeeAddModelDto model)
        {
            var newEmployeeId = default(Guid);

            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newEmployee = _mapper.Map<EmployeeModelDto>(model);
                    newEmployee.SEmployeesIdAdd = model.SEmployeesIdAdd;
                    newEmployee.EmployeesFioAdd = model.EmployeesFioAdd;
                    newEmployee.AspNetUserId = model.AspNetUserId;

                    newEmployeeId = await AddEmployeeAsync(newEmployee);

                    // добавить Роль исполнителя в таблицу s_employees_roles_executor
                    if (model.SRolesExecutorId != Guid.Empty)
                    {
                        await _context.SEmployeesRolesExecutors.AddAsync(new SEmployeesRolesExecutor()
                        {
                            SEmployeesId = newEmployeeId,
                            SRolesExecutorId = model.SRolesExecutorId,
                            EmployeesFioAdd = model.EmployeesFioAdd
                        });
                    }

                    await _context.SEmployeesOfficesJoins.AddAsync(new SEmployeesOfficesJoin()
                    {
                        SEmployeesId = newEmployeeId,
                        DateStart = model.DateStart,
                        EmployeeIntensity = model.EmployeeIntensity,
                        EmployeeRate = model.EmployeeRate,
                        SEmployeesJobPositionId = model.SEmployeesJobPositionId,
                        SOfficesId = model.SOfficesId,
                        EmployeesFioAdd = model.EmployeesFioAdd
                    });

                    await _context.SEmployeesStatusJoins.AddAsync(new SEmployeesStatusJoin()
                    {
                        SEmployeesId = newEmployeeId,
                        DateStart = model.DateStart,
                        SEmployeesStatusId = model.SEmployeesStatusId,
                        EmployeesFioAdd = model.EmployeesFioAdd
                    });

                    await _context.SOfficesAuthorizations.AddAsync(new SOfficesAuthorization()
                    {
                        SEmployeesId = newEmployeeId,
                        DateStart = model.DateStart,
                        SOfficesId = model.SOfficesId,
                        EmployeesFioAdd = model.EmployeesFioAdd
                    });

                    if (model.IsExecution)
                    {
                        await _context.SEmployeesExecutions.AddAsync(new SEmployeesExecution()
                        {
                            SEmployeesId = newEmployeeId,
                            DateStart = model.DateStart,
                            EmployeesFioAdd = model.EmployeesFioAdd
                        });
                    }

                    if (model.IsActive)
                    {
                        await _context.SEmployeesActives.AddAsync(new SEmployeesActive()
                        {
                            SEmployeesId = newEmployeeId,
                            DateStart = model.DateStart,
                            EmployeesFioAdd = model.EmployeesFioAdd
                        });
                    }

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException(ex.Message);
                }
            }

            return newEmployeeId;
        }

        /// <summary>
        /// Обновить основные данные пользователя
        /// </summary>
        public async Task UpdateEmployeeAsync(EmployeeModelDto model)
        {
            var entity = await _context.SEmployees.FindAsync(model.Id);
            if (entity == null)
                throw new ArgumentException("Данные не найдены!");

            _mapper.Map<EmployeeModelDto, SEmployee>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление сотрудника
        /// </summary>
        /// <param name="Id">Id сотрудника</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveEmployee(Guid Id, string comment)
        {
            var entity = await _context.SEmployees.FindAsync(Id);
            if (entity == null)
                throw new ArgumentException("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }


        public async Task<Guid?> GetEmployeeAspNetUserId(Guid Id)
        {
            return await _context.SEmployees.AsNoTracking().Where(w => w.Id == Id).Select(s => s.AspNetUserId).FirstOrDefaultAsync();
        }
    }
}

