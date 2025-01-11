using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - СМЭВ Запросы
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {

        /// <summary>
        /// Поучить список запросов СМЭВ
        /// </summary>
        /// <param name="request">Запрос</param>
        public async Task<(List<SmevRequestDto>, int, int)> GetSmevRequests(IDataTablesRequest request)
        {
            var results = _context.SSmevRequests
                .AsNoTracking()
                .Where(x => !x.IsRemove);


            int totalCount = await results.CountAsync();

            var filterResult = string.IsNullOrWhiteSpace(request.Search.Value) ?
                results :
                results.Search(x => x.RequestName.ToLower()).Containing(request.Search.Value.ToLower().Trim());

            var filterCount = string.IsNullOrWhiteSpace(request.Search.Value) ? totalCount : await filterResult.CountAsync();

            var dataPage = await filterResult
                .OrderBy(x => x.RequestName)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new SmevRequestDto()
                {
                    Id = x.Id,
                    SSmevId = x.SSmevId,
                    SmevName = x.SSmev.SmevName,
                    RequestName = x.RequestName,
                    RequestTypeName = x.SSmevTypeRequest.TypeName,
                    CountDayExecution = x.CountDayExecution,
                    WeekDayName = x.SServicesWeek.TypeName,
                    Path = x.Path,
                    ServiceOrFunctionCode = x.SServicesSmevRequestJoins.Count(c => !c.IsRemove).ToString(),
                }).ToListAsync();

            return (dataPage, totalCount, filterCount);
        }

        /// <summary>
        /// Модель для добавления / редактирования запроса СМЭВ
        /// </summary>
        public async Task<SmevRequestModelDto> GetSmevRequestModelDtoAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SSmevRequests.FindAsync(Id);
            if (result == null)
                throw new Exception("Данные не найдены!");

            return _mapper.Map<SmevRequestModelDto>(result);
        }

        /// <summary>
        /// Поучить список всех запросов СМЭВ
        /// </summary>
        public async Task<List<SmevRequestDto>> GetAllSmevRequestAsync(List<int> id)
        {
            var results = await _context.SSmevRequests
                .AsNoTracking()
                .Where(w => !w.IsRemove && id.Any(a => a == w.Id))
                .OrderBy(x => x.RequestName)
                .Select(x => new SmevRequestDto()
                {
                    Id = x.Id,
                    RequestName = x.RequestName,
                }).ToListAsync();

            return results;
        }

        /// <summary>
        /// Пометить на удаление (удалить?) сервис СМЭВ
        /// </summary>
        /// <param name="Id">ID записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveSmevRequestAsync(int Id, string comment)
        {
            var entity = await _context.SSmevRequests.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }

        public async Task AddSmevRequestAsync(SmevRequestModelDto model)
        {
            if (_context.SSmevRequests.Any(x => x.Id == model.Id))
                throw new Exception($"Запись с Id={model.Id} уже существует!");

            var entity = _mapper.Map<SSmevRequest>(model);

            try
            {
                await _context.SSmevRequests.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task UpdateSmevRequestAsync(SmevRequestModelDto model)
        {
            var entity = await _context.SSmevRequests.FindAsync(model.OldId);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            // если изменили Код
            if (model.Id != model.OldId)
            {
                // если измененный код существует
                if (_context.SSmevRequests.Any(x => x.Id == model.Id))
                {
                    throw new Exception($"Запись с Id={model.Id} уже существует!");
                }
            }

            _mapper.Map<SmevRequestModelDto, SSmevRequest>(model, entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SmevReferenceServiceDto>> GetServicesForSmevAsync(int id)
        {
            var services = await _context.SServicesSmevRequestJoins.Where(w => !w.IsRemove && w.SSmevRequestId == id)
                .Select(s => new SmevReferenceServiceDto
                {
                    Id = s.Id,
                    SSmevRequestId = s.SSmevRequestId,
                    ServiceId = s.SServicesId,
                    ServiceName = s.SServices.ServiceName
                }).ToListAsync();

            return services;
        }

        public async Task<bool> AddServicesForSmevAsync(AddSmevReferenceServiceDto request)
        {
            try
            {
                var model = new List<SServicesSmevRequestJoin>();

                request.ServiceId.ForEach(f =>
                {

                    model.Add(new SServicesSmevRequestJoin
                    {
                        SServicesId = f,
                        SSmevRequestId = request.SmevId,
                        EmployeesFioAdd = request.EmployeesFioAdd,
                        DateAdd = DateTime.Today,
                    });
                });

                await _context.SServicesSmevRequestJoins.AddRangeAsync(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteServicesForSmevAsync(Guid id)
        {
            try
            {
                var entity = await _context.SServicesSmevRequestJoins.FindAsync(id);
                if (entity == null) return false;

                entity.IsRemove = true;

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
