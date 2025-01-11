using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Сотрудники - Статус
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить статусы сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        public async Task<(List<EmployeeStatusDto>, int, int)> GetEmployeeStatuses(IDataTablesRequest request, Guid id)
        {
            var date = DateTime.Today;
            var currentEmployeeName = await _employeeManager.GetNameAsync();

            var results = _context.SEmployeesStatusJoins
                .AsNoTracking()
                .Where(x => x.SEmployeesId == id && !x.IsRemove);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderByDescending(x => x.DateStart)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new EmployeeStatusDto()
                {
                    Id = x.Id,
                    SEmployeesId = x.SEmployeesId,
                    IsStatus = x.DateStart.Date <= date.Date && (x.DateStop == null || x.DateStop.Value.Date >= date.Date),
                    StatusName = x.SEmployeesStatus.StatusName,
                    DateStart = x.DateStart.ToString("dd.MM.yyyy"),
                    DateStop = x.DateStop == null ? null : x.DateStop.Value.ToString("dd.MM.yyyy"),
                    Commentt = x.Commentt,
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    DateAdd = x.DateAdd.ToString("dd.MM.yyyy"),
                    IsRemoveActive = x.DateAdd.Date == date.Date && x.EmployeesFioAdd == currentEmployeeName,
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Получить последнюю запись о статусе сотрудника
        /// </summary>
        /// <param name="employeeId">Id сотрудника</param>
        public async Task<EmployeeStatusModelDto> GetLastEmployeeStatusDtoAsync(Guid employeeId)
        {
            var query = await _context.SEmployeesStatusJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SEmployeesId == employeeId)
                .OrderByDescending(x => x.DateStart)
                .FirstOrDefaultAsync();

            if (query is null)
            {
                return new EmployeeStatusModelDto()
                {
                    SEmployeesId = employeeId,
                    DateStart = DateTime.Today
                };
            }

            var result = _mapper.Map<EmployeeStatusModelDto>(query);
            result.Commentt = string.Empty;
            var isDateStartCompare = DateTime.Compare(query.DateStart.Date, DateTime.Today.Date);

            result.DateStart = isDateStartCompare switch
            {
                < 0 => DateTime.Today,
                0 => DateTime.Today.AddDays(1),
                _ => DateTime.Today
            };

            return result;
        }

        /// <summary>
        /// Пометить на удаление запись о статусе сотрудника
        /// </summary>
        /// <param name="Id">Id сотрудника</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveEmployeeStatusAsync(Guid id, bool isRemove, string comment)
        {
            var entity = await _context.SEmployeesStatusJoins.FindAsync(id);
            if (entity == null)
                throw new ArgumentException("Запись не найдена!");

            var date = DateTime.Now;

            if (entity.DateStart.Date < date.Date)
            {
                entity.DateStop = date.AddDays(-1);
            }
            else
            {
                entity.DateStop = entity.DateStart;
            }

            if (isRemove)
            {
                entity.IsRemove = true;
                entity.Commentt = comment;
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить запись об офисе и должности сотрудника
        /// </summary>
        public async Task AddEmployeeStatusAsync(EmployeeStatusModelDto model)
        {
            if (model.Id != Guid.Empty)
            {
                var lastEntity = _context.SEmployeesStatusJoins.Find(model.Id);
                if (lastEntity != null)
                {
                    if (lastEntity.DateStart >= model.DateStart)
                        throw new ArgumentOutOfRangeException(nameof(model.DateStart), "Дата начала превышает максимальное значение!");

                    // не нужно - срабатывает триггер
                    //lastEntity.DateStop = model.DateStart.AddDays(-1);
                    //*******************************
                }

                model.Id = Guid.Empty;
            }

            var entity = _mapper.Map<SEmployeesStatusJoin>(model);

            await _context.SEmployeesStatusJoins.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
