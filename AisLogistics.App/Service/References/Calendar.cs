using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Календарь
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить выходные дни и праздники
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Конец периода</param>
        public async Task<IEnumerable<FullCalendarDateEventDto>> GetHolidaysAsync(DateTime dateStart, DateTime dateEnd)
        {
            var holidays = await _context.SCalendars
                .AsNoTracking()
                .Where(d => d.DateType != (int)CalendarDateType.Working &&
                            d.Date >= dateStart && d.Date <= dateEnd.AddDays(1))
                .Select(x => new FullCalendarDateEventDto
                {
                    Id = x.Id,
                    Title = ((CalendarDateType)x.DateType).GetDisplayName(),
                    DateType = x.DateType,
                    Start = x.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                })
                .ToListAsync();

            return holidays;
        }

        /// <summary>
        /// Получить календарные дни по типу
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Конец периода</param>\
        public async Task<IEnumerable<FullCalendarDateEventDto>> GetCalendarDatesAsync(DateTime dateStart, DateTime dateEnd)
        {
            var calendarDays = await _context.SCalendars
                .AsNoTracking()
                .Where(d => d.Date >= dateStart && d.Date <= dateEnd)
                .Select(x => new FullCalendarDateEventDto
                {
                    Id = x.Id,
                    Title = ((CalendarDateType)x.DateType).GetDisplayName(),
                    DateType = x.DateType,
                    Start = x.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                })
                .ToListAsync();

            return calendarDays;
        }

        /// <summary>
        /// Получить информацию о дате
        /// </summary>
        /// <param name="date">Дата</param>
        public async Task<CalendarDateModelDto> GetCalendarDateAsync(DateTime dateCalendar)
        {
            return await _context.SCalendars
                .AsNoTracking()
                .Where(d => d.Date >= dateCalendar && d.Date < dateCalendar.AddDays(1))
                .Select(s=> new CalendarDateModelDto
                {
                    Id = s.Id,
                    Start = s.Date,
                    DateType = s.DateType
                })
                .FirstOrDefaultAsync() ?? throw new ArgumentException("Дата не найдена!");
        }

        /// <summary>
        /// Обновить тип календарной даты
        /// </summary>
        public async Task UpdateCalendarDateAsync(CalendarDateModelDto model)
        {
            var entity = await _context.SCalendars.FindAsync(model.Id);
            if (entity == null)
                throw new ArgumentException("Данные не найдены!");

            // обновить, если только поменялся тип даты
            if (model.DateType != entity.DateType)
            {
                // если до этого никто не менял тип даты
                if (string.IsNullOrWhiteSpace(entity.EmployeesFioAdd))
                {
                    model.DateAdd = DateTime.Now;
                }
                else
                {
                    model.DateAdd = entity.DateAdd;
                    model.EmployeesFioAdd = entity.EmployeesFioAdd;
                }

                _mapper.Map<CalendarDateModelDto, SCalendar>(model, entity);

                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Сменить тип даты календаря на рабояий день
        /// </summary>
        /// <param name="id">Id даты календаря</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveCalendarDateAsync(int id, string comment)
        {
            var entity = await _context.SCalendars.FindAsync(id);
            if (entity == null)
                throw new ArgumentException("Запись не найдена!");

            entity.DateType = (int)CalendarDateType.Working;
            //если в Бд внесут изменения
            //calendarDate.Comment = comment;

            await _context.SaveChangesAsync();
        }
    }
}
