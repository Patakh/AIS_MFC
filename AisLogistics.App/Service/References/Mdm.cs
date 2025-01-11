using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить список "FTP"
        /// </summary>
        public async Task<(List<MdmDto>, int, int)> GetMdm(IDataTablesRequest request)
        {
            var results = _context.SServicesProcedures
                .AsNoTracking()
                .Where(x => !x.IsRemove);

            int totalCount = await results.CountAsync();

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? results
                : results.Search(s => s.ProcedureName.ToLower(), 
                                 s=>s.Id.ToString().ToLower(), 
                                 s=>s.FrguTargetId.ToLower())
                          .ContainingAll(request.Search.Value.ToLower());

            var filteredDataCount = String.IsNullOrWhiteSpace(request.Search.Value) ? totalCount : await filteredData.CountAsync();

            var dataPage = await filteredData
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new MdmDto()
                {
                    Id = x.Id,
                    ProcedureName = x.ProcedureName,
                    ServiceName = x.SServices.ServiceName,
                    FrguTargetId = x.FrguTargetId,
                    IsMdm = x.IsMdm,

                }).ToListAsync();

            return (dataPage, totalCount, filteredDataCount);
        }
       
        /// <summary>
        /// Модель для редактирования FTP
        /// </summary>
        public async Task<MdmModelDto?> GetMdmDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SServicesProcedures.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");

            return _mapper.Map<MdmModelDto>(result);
        }

        public async Task UpdateMdmAsync(MdmModelDto model)
        {
            var entity = await _context.SServicesProcedures.FindAsync(model.Id) ?? throw new InvalidOperationException("Данные не найдены!");
            _mapper.Map<MdmModelDto, SServicesProcedure>(model, entity);

            await _context.SaveChangesAsync();
        }
    }
}
