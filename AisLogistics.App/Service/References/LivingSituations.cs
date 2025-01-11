using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - жизненныt ситуации

    /// <summary>
    /// Получить список "жизненныt ситуации"
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        public async Task<(List<LivingSituationsDto>, int, int)> GetLivingSituation(IDataTablesRequest request)
        {
            var results = _context.SServicesLivingSituations
                .AsNoTracking()
                .Where(x => !x.IsRemove);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new LivingSituationsDto()
                {
                    Id = x.Id,
                    SituationName = x.SituationName,
                    EmployeesFioAdd = x.EmployeesFioAdd,
                    DateAdd = x.DateAdd,
                    Commentt = x.Commentt,
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Модель для редактирования "жизненныt ситуации"
        /// </summary>
        public async Task<LivingSituationModelDto> GetLivingSituationDtoAsync(Guid? Id)
        {
            try
            {
                if (Id is null)
                    throw new ArgumentNullException(nameof(Id));

                var result = await _context.SServicesLivingSituations.FindAsync(Id);
                if (result == null)
                    throw new InvalidOperationException("Данные не найдены!");

                return _mapper.Map<LivingSituationModelDto>(result);
            }

            catch (Exception ex)
            {
                var a = ex;

                return null;
            }
        }

        public async Task AddLivingSituationAsync(LivingSituationModelDto model)
        {
            var entity = _mapper.Map<SServicesLivingSituation>(model);

            await _context.SServicesLivingSituations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLivingSituationAsync(LivingSituationModelDto model)
        {
            var entity = await _context.SServicesLivingSituations.FindAsync(model.Id);
            if (entity == null)
                throw new Exception("Данные не найдены!");

            _mapper.Map<LivingSituationModelDto, SServicesLivingSituation>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление (удалить?) "жизненныt ситуации"
        /// </summary>
        /// <param name="Id">ID записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveLivingSituationAsync(Guid Id, string comment)
        {
            var entity = await _context.SServicesLivingSituations.FindAsync(Id);
            if (entity == null)
                throw new Exception("Запись не найдена!");

            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }
    }
}
