using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Документы
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        public async Task<(List<DocumentsDto>, int, int)> GetDocuments(IDataTablesRequest request)
        {
            try
            {
                var allData = _context.SDocuments.Where(w => !w.IsRemove);

                var allDataCount = await allData.CountAsync();

                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? allData
                    : allData.Where(w => !w.IsRemove && w.DocumentName.Contains(request.Search.Value));

                var filteredDataCount = String.IsNullOrWhiteSpace(request.Search.Value)
                   ? allDataCount
                   : await filteredData.CountAsync();

                var dataPage = await filteredData.OrderBy(o => o.DocumentName).Skip(request.Start).Take(request.Length)
                    .Select(s => new DocumentsDto
                    {
                        Id = s.Id,
                        Name = s.DocumentName,
                        Description = s.DocumentDescription
                    }).ToListAsync();

                return (dataPage, allDataCount, filteredDataCount);
            }
            catch
            {
                return (new List<DocumentsDto>(), 0, 0);
            }
        }


        public async Task<List<DocumentsDto>> GetAllDocumentsAsync()
        {
            var documents = _context.SDocuments
                .AsNoTracking()
                .Where(x => !x.IsRemove)
                .OrderBy(x => x.DocumentName);

            var result = await documents
                .Select(x => new DocumentsDto()
                {
                    Id = x.Id,
                    Name = x.DocumentName
                }).ToListAsync();

            return result;
        }

        public async Task<DocumentModelDto?> GetDocumentsDtoAsync(Guid? Id)
        {
            try
            {
                if (Id is null)
                    throw new ArgumentNullException(nameof(Id));

                var result = await _context.SDocuments.FindAsync(Id);

                return result is null ? throw new InvalidOperationException("Данные не найдены!") : _mapper.Map<DocumentModelDto>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task AddDocumentAsync(DocumentModelDto model)
        {
            var entity = _mapper.Map<SDocument>(model);

            await _context.SDocuments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDocumentAsync(DocumentModelDto model)
        {
            var entity = await _context.SDocuments.FindAsync(model.Id) ?? throw new InvalidOperationException("Данные не найдены!");
            _mapper.Map<DocumentModelDto, SDocument>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <param name="Id">ID записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveDocumentAsync(Guid Id, string comment)
        {
            var entity = await _context.SDocuments.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");
            entity.IsRemove = true;
            entity.Commentt = comment;

            await _context.SaveChangesAsync();
        }
    }
}
