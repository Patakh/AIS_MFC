using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Услуги - Активность
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить активности услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public async Task<(List<ServiceActivityDto>, int, int)> GetServiceActivitiesAsync(IDataTablesRequest request, Guid serviceId, Guid officeId)
        {
            try
            {
                var date = DateTime.Today;
                var currentEmployeeName = await _employeeManager.GetNameAsync();

                var result = _context.SServicesActives
                    .AsNoTracking()
                    .Where(x => x.SServices.Id == serviceId && x.SOfficesId == officeId && !x.IsRemove);

                int totalCount = await result.CountAsync();

                var dataPage = await result
                    .OrderByDescending(x => x.DateStart)
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(x => new ServiceActivityDto()
                    {
                        Id = x.Id,
                        SServicesId = serviceId,
                        IsServicesActive = x.DateStart.Date <= date.Date && (!x.DateStop.HasValue || x.DateStop.Value.Date >= date.Date),
                        OfficeName = x.SOffices.OfficeName,
                        Commentt = x.Commentt,
                        DateStart = x.DateStart.ToString("dd.MM.yyyy"),
                        DateStop = x.DateStop == null ? null : x.DateStop.Value.ToString("dd.MM.yyyy"),
                        EmployeesFioAdd = x.EmployeesFioAdd,
                        DateAdd = x.DateAdd.ToString("dd.MM.yyyy"),
                        IsRemoveActive = x.DateAdd.Date == date.Date && x.EmployeesFioAdd == currentEmployeeName,
                    }).ToListAsync();

                return (dataPage, totalCount, totalCount);
            }
            catch
            {
                return (new List<ServiceActivityDto>(), 0, 0);
            }
        }

        /// <summary>
        /// Поучить активности услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        /// <param name="start">Брать начиная с</param>
        /// <param name="length">Кол-во элементов</param>
        public async Task<(List<ServiceActivityOfficeDto>, int, int)> GetServiceActivitiesOfficesAsync(IDataTablesRequest request, Guid serviceId)
        {
            try
            {
                var date = DateTime.Today;

                bool? isActive = null;
                var isActiveColumn = request?.Columns?.Where(w => w.Name == "active").Select(s => s.Search.Value).FirstOrDefault();
                if (isActiveColumn != null) isActive = bool.Parse(isActiveColumn);

                var results = _context.SServicesActives
                    .AsNoTracking()
                    .Where(x => x.SServices.Id == serviceId && !x.IsRemove)
                    .GroupBy(g => new { g.SOfficesId, g.SOffices.OfficeNameSmall, g.SOffices.SOfficesTypeId })
                    .Select(s => new ServiceActivityOfficeDto
                    {
                        Id = s.Key.SOfficesId,
                        Name = s.Key.OfficeNameSmall,
                        OfficeTypeId = s.Key.SOfficesTypeId,
                        IsActive = s.Any(a => !a.IsRemove && a.DateStart.Date <= date.Date && (!a.DateStop.HasValue || a.DateStop.Value.Date >= date.Date))
                    });

                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                  ? results
                  : results.Search(s => s.Name.ToLower()).Containing(request.Search.Value.ToLower());

                var dataPage = await filteredData.Where(w => !isActive.HasValue || w.IsActive == isActive).OrderBy(o => o.OfficeTypeId).ThenBy(t=>t.Name).ToListAsync();

                return (dataPage, dataPage.Count, dataPage.Count);
            }
            catch
            {
                return (new List<ServiceActivityOfficeDto>(), 0, 0);
            }
        }


        /// <summary>
        /// Получить последнюю запись об активности услуги
        /// </summary>
        /// <param name="serviceId">Id услуги</param>
        public async Task<ServiceActivityModelDto> GetLastServiceActivityDtoAsync(Guid serviceId)
        {
            var query = await _context.SServicesActives
                .AsNoTracking()
                .Where(x => /*!x.IsRemove &&*/ x.SServicesId == serviceId)
                .OrderByDescending(x => x.DateStart)
                .FirstOrDefaultAsync();

            if (query is null)
            {
                return new ServiceActivityModelDto()
                {
                    SServicesId = serviceId,
                    DateStart = new DateTime(2000, 1, 1)
                };
            }

            var result = _mapper.Map<ServiceActivityModelDto>(query);
            result.Commentt = string.Empty;
            result.DateStart = DateTime.Compare(query.DateStart, query.DateStop ??= default(DateTime)) > 0 ? query.DateStart : (DateTime)query.DateStop;

            return result;
        }

        /// <summary>
        /// Пометить на удаление запись об активности услуги
        /// </summary>
        /// <param name="Id">Id сотрудника</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceActivityAsync(Guid id, bool isRemove, string comment)
        {
            var date = DateTime.Now;
            var entity = await _context.SServicesActives.FindAsync(id);
            if (entity == null)
                throw new ArgumentException("Запись не найдена!");

            if(entity.DateStart.Date < date.Date)
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
        /// Пометить на удаление запись об активности услуги
        /// </summary>
        /// <param name="Id">Id сотрудника</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveServiceActivityAsync(Guid serviceId, List<Guid> officesId, string comment)
        {
            var date = DateTime.Today;

            var entity = await _context.SServicesActives
                                .Where(w=> w.SServicesId==serviceId&&
                                            officesId.Contains(w.SOfficesId)&& 
                                            w.DateStart <= date && (!w.DateStop.HasValue || w.DateStop.Value >= date))                    
                                .ToListAsync();

            if (entity == null || entity.Count ==0)
                throw new ArgumentException("Запись не найдена!");

            entity.ForEach(f =>
            {
                if (f.DateStart.Date < date.Date)
                {
                    f.DateStop = date.AddDays(-1);
                }
                else
                {
                    f.DateStop = f.DateStart;
                }
                f.Commentt = comment;
            });
            //entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Добавить запись об активности услуги
        /// </summary>
        public async Task AddServiceActivityAsync(ServiceActivityModelDto model)
        {

            if (model.Id != Guid.Empty)
            {
                var lastEntity = _context.SServicesActives.Find(model.Id);
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

            List<SServicesActive> sServicesActives = new();

            var offices = await _filterManager.GetOfficesIdForReceptionCustomer(model.OffisesId, true, false);

            offices.OfficesId.ForEach(s =>
            {
                var entity = _mapper.Map<SServicesActive>(model);
                entity.SOfficesId = s;
                sServicesActives.Add(entity);
            });


            //if (!model.OffisesId.Any() || model.OffisesId.First() == Guid.Empty)
            //{
            //    var offices = await GetAllOfficesTypeMfcAndTospAsync();

                

            //}
            //else
            //{
            //    model.OffisesId.ForEach(s =>
            //    {
            //        var entity = _mapper.Map<SServicesActive>(model);
            //        entity.SOfficesId = s;
            //        sServicesActives.Add(entity);
            //    });
            //}

            await _context.SServicesActives.AddRangeAsync(sServicesActives);
            await _context.SaveChangesAsync();
        }
    }
}
