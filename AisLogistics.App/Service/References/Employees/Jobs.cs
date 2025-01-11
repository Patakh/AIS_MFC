using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Сотрудники - Должность
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить должности и офисы сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        public async Task<(List<EmployeeJobDto>, int, int)> GetEmployeeJobs(IDataTablesRequest request, Guid id)
        {
            var date = DateTime.Today;
            var currentEmployeeName = await _employeeManager.GetNameAsync();

            var results = _context.SEmployeesOfficesJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SEmployeesId == id);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                 .OrderByDescending(x => x.DateStart)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new EmployeeJobDto()
                {
                    Id = x.Id,
                    IsJobActive = x.DateStart.Date <= date.Date && (x.DateStop == null || x.DateStop >= date.Date),
                    SEmployeesId = x.SEmployeesId,
                    OfficeName = x.SOffices.OfficeNameSmall,
                    JobPositionName = x.SEmployeesJobPosition.JobPositionName,
                    EmployeeIntensity = x.EmployeeIntensity,
                    EmployeeRate = x.EmployeeRate,
                    DateStart = x.DateStart.ToString("dd.MM.yyyy"),
                    DateStop = x.DateStop == null ? null : x.DateStop.Value.ToString("dd.MM.yyyy"),
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    DateAdd = x.DateAdd.ToString("dd.MM.yyyy"),
                    IsRemoveActive = x.DateAdd.Date == date.Date && x.EmployeesFioAdd == currentEmployeeName,
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Модель для редактирования должности и офиса сотрудника
        /// </summary>
        public async Task<EmployeeJobModelDto> GetEmployeeJobDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SEmployeesOfficesJoins.FindAsync(Id);
            if (result == null)
                throw new ArgumentException("Данные не найдены!");

            return _mapper.Map<EmployeeJobModelDto>(result);
        }

        /// <summary>
        /// Получить последнюю запись об офисе и должности сотрудника
        /// </summary>
        /// <param name="employeeId">Id сотрудника</param>
        public async Task<EmployeeJobModelDto> GetLastEmployeesJobDtoAsync(Guid employeeId)
        {
            var query = await _context.SEmployeesOfficesJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SEmployeesId == employeeId)
                .OrderByDescending(x => x.DateStart)
                .FirstOrDefaultAsync();

            if (query is null)
            {
                return new EmployeeJobModelDto()
                {
                    SEmployeesId = employeeId,
                    EmployeeRate = 1.00M,
                    DateStart = DateTime.Today,
                };
            }

            var result = _mapper.Map<EmployeeJobModelDto>(query);
            var isDateStartCompare = DateTime.Compare(query.DateStart.Date, DateTime.Today.Date);

            result.DateStart = isDateStartCompare switch {
                < 0 => DateTime.Today,
                0 => DateTime.Today.AddDays(1),
                _ => DateTime.Today
            };

            return result;
        }

        /// <summary>
        /// Пометить на удаление запись об офисе и должности сотрудника
        /// </summary>
        /// <param name="Id">Id сотрудника</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveEmployeeJobAsync(Guid id, bool isRemove, string comment)
        {
            var entity = await _context.SEmployeesOfficesJoins.FindAsync(id);
            if (entity == null)
                throw new ArgumentException("Запись не найдена!");

            entity.IsRemove = true;
            entity.DateStop = DateTime.Now;

            if (isRemove)
            {
                entity.IsRemove = true;
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить запись об офисе и должности сотрудника
        /// </summary>
        public async Task AddEmployeeJobAsync(EmployeeJobModelDto model)
        {
            if (model.Id != Guid.Empty)
            {

                var lastEntity = _context.SEmployeesOfficesJoins.Find(model.Id);
                if (lastEntity != null)
                {
                    // не нужно - срабатывает триггер
                    //lastEntity.DateStop = model.DateStart.AddDays(-1);
                    //*******************************

                    if (lastEntity.DateStart >= model.DateStart)
                        throw new ArgumentOutOfRangeException(nameof(model.DateStart), "Дата начала превышает максимальное значение!");
                }


                model.Id = Guid.Empty;
            }

            var entity = _mapper.Map<SEmployeesOfficesJoin>(model);

            await _context.SEmployeesOfficesJoins.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
