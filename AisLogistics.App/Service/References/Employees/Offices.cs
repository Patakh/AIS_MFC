using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Сотрудники - Офисы
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        public async Task<(List<EmployeeOfficeDto>, int, int)> GetEmployeeOffices(IDataTablesRequest request, Guid id)
        {
            var date = DateTime.Today;
            var currentEmployeeName = await _employeeManager.GetNameAsync();

            var results = _context.SOfficesAuthorizations
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SEmployeesId == id);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                 .OrderByDescending(x => x.DateStart)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new EmployeeOfficeDto()
                {
                    Id = x.Id,
                    SEmployeesId = x.SEmployeesId,
                    SOfficeId = x.SOfficesId,
                    OfficeName = x.SOffices.OfficeNameSmall,
                    IsOfficesActive = x.DateStart.Date <= date.Date && (!x.DateStop.HasValue || x.DateStop.Value.Date >= date.Date),
                    DateStart = x.DateStart.ToString("dd.MM.yyyy"),
                    DateStop = x.DateStop == null ? null : x.DateStop.Value.ToString("dd.MM.yyyy"),
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    DateAdd = x.DateAdd.ToString("dd.MM.yyyy"),
                   IsRemoveActive = x.DateAdd.Date == date.Date && x.EmployeesFioAdd == currentEmployeeName,
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        public async Task RemoveEmployeeOfficeAsync(Guid id, bool isRemove, string comment)
        {
            var entity = await _context.SOfficesAuthorizations.FindAsync(id);
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
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить запись об офисе и должности сотрудника
        /// </summary>
        public async Task AddEmployeeOfficesAsync(EmployeeOfficeModelDto model)
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

            List<SOfficesAuthorization> sOfficesAuthorization = new();

            var offices = await _filterManager.GetOfficesIdForReceptionCustomer(model.OfficesId, true,false);

            offices.OfficesId.ForEach(s =>
            {
                var entity = _mapper.Map<SOfficesAuthorization>(model);
                entity.SOfficesId = s;
                sOfficesAuthorization.Add(entity);
            });

            //if (!model.OfficesId.Any() || model.OfficesId.First() == Guid.Empty)
            //{
            //    var offices = await GetAllOfficesTypeMfcAndTospAsync();

            //    offices.ForEach(s =>
            //    {
            //        var entity = _mapper.Map<SOfficesAuthorization>(model);
            //        entity.SOfficesId = s.Id;
            //        sOfficesAuthorization.Add(entity);
            //    });

            //}
            //else
            //{
            //    model.OfficesId.ForEach(s =>
            //    {
            //        var entity = _mapper.Map<SOfficesAuthorization>(model);
            //        entity.SOfficesId = s;
            //        sOfficesAuthorization.Add(entity);
            //    });
            //}

            await _context.SOfficesAuthorizations.AddRangeAsync(sOfficesAuthorization);
            await _context.SaveChangesAsync();
        }
    }
}
