using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - Сотрудники - Активность

    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить активности сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        public async Task<(List<EmployeeActivityDto>, int, int)> GetEmployeeActivities(IDataTablesRequest request, Guid id)
        {
            var date = DateTime.Today;
            var currentEmployeeName = await _employeeManager.GetNameAsync();

            var results = _context.SEmployeesActives
                .AsNoTracking()
                .Where(x =>x.SEmployeesId == id && !x.IsRemove);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderByDescending(x => x.DateStart)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new EmployeeActivityDto()
                {
                    Id = x.Id,
                    SEmployeesId = x.SEmployeesId,
                    IsActive = x.DateStart <= date && (x.DateStop == null || x.DateStop.Value.Date >= date),
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
        /// Получить последнюю запись об активности сотрудника
        /// </summary>
        /// <param name="employeeId">Id сотрудника</param>
        public async Task<EmployeeActivityModelDto> GetLastEmployeeActivityDtoAsync(Guid employeeId)
        {
            var query = await _context.SEmployeesActives
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SEmployeesId == employeeId)
                .OrderByDescending(x => x.DateStart)
                .FirstOrDefaultAsync();

            if (query is null)
            {
                return new EmployeeActivityModelDto()
                {
                    SEmployeesId = employeeId,
                    DateStart = new DateTime(2000, 1, 1)
                };
            }

            var result = _mapper.Map<EmployeeActivityModelDto>(query);
            result.Commentt = string.Empty;
            result.DateStart = DateTime.Compare(query.DateStart, query.DateStop ??= default(DateTime)) > 0 ? query.DateStart : (DateTime)query.DateStop;

            return result;
        }

        /// <summary>
        /// Получить последнюю запись об активности сотрудника
        /// </summary>
        /// <param name="employeeId">Id сотрудника</param>
        public async Task<EmployeeActivityModelDto> GetEmployeeActivityDtoAsync(Guid id)
        {
            var query = await _context.SEmployeesActives.FindAsync(id);

            var result = _mapper.Map<EmployeeActivityModelDto>(query);

            return result;
        }

        public async Task<bool> GetIsEmployeeActivityAsync(Guid employeeId)
        {
            var date = DateTime.Today;
            return await _context.SEmployeesActives.AnyAsync(a => !a.IsRemove && a.SEmployeesId == employeeId && a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop.Value.Date >= date.Date));
        }

        /// <summary>
        /// Пометить на удаление запись об активности сотрудника
        /// </summary>
        /// <param name="Id">Id сотрудника</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveEmployeeActivityAsync(Guid id, bool isRemove, string comment)
        {
            var entity = await _context.SEmployeesActives.FindAsync(id);
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

            if(isRemove)
            {
                entity.IsRemove = true;
                entity.Commentt = comment;
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить запись об активности сотрудника
        /// </summary>
        public async Task AddEmployeeActivityAsync(EmployeeActivityModelDto model)
        {
            if (model.Id != Guid.Empty)
            {
                var lastEntity = await _context.SEmployeesActives.OrderByDescending(o => o.DateAdd).FirstOrDefaultAsync(f => f.SEmployeesId == model.SEmployeesId);
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

            var entity = _mapper.Map<SEmployeesActive>(model);

            await _context.SEmployeesActives.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
