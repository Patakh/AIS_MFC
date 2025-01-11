using AisLogistics.App.Models.DTO.Systems;
using AisLogistics.DataLayer.Common.Dto.Systems;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service.Systems
{
    public partial class SystemsService
    {
        public async Task<(List<TerminalDto>, int, int)> GetTerminal(IDataTablesRequest request)
        {
            var allData = _context.SOfficesAcquirings;
            var allDataCount = await allData.CountAsync();

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? allData
                : allData.Where(w => EF.Functions.Like(w.AcquiringName.ToLower(), $"%{request.Search.Value.ToLower()}%"));

            var filteredDataCount = String.IsNullOrWhiteSpace(request.Search.Value) ? allDataCount : await filteredData.CountAsync();

            var dataPage = await filteredData.OrderByDescending(o => o.AcquiringName).Skip(request.Start).Take(request.Length)
                .Select(s => new TerminalDto
                {
                    Id = s.Id,
                    AcquiringName = s.AcquiringName,
                    IpAddress = s.IpAddress,
                    OfficeName = s.SOffices.OfficeName
                }).ToListAsync();

            return (dataPage, allDataCount, filteredDataCount);
        }

        public async Task<TerminalModelDto?> GetTerminalDtoAsync(Guid? Id)
        {
            try
            {
                if (Id is null) throw new ArgumentNullException(nameof(Id));

                var result = await _context.SOfficesAcquirings.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");

                return result is null ? throw new InvalidOperationException("Данные не найдены!") : _mapper.Map<TerminalModelDto>(result);
            }

            catch
            {
                return null;
            }
        }

        public async Task AddTerminalAsync(TerminalModelDto model)
        {
            var entity = _mapper.Map<SOfficesAcquiring>(model);

            await _context.SOfficesAcquirings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTerminalAsync(TerminalModelDto model)
        {
            var entity = await _context.SOfficesAcquirings.FindAsync(model.Id) ?? throw new InvalidOperationException("Данные не найдены!");
            _mapper.Map<TerminalModelDto, SOfficesAcquiring>(model, entity);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveTerminalAsync(Guid Id, string comment)
        {
            var entity = await _context.SOfficesAcquirings.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");
            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }
    }
}
