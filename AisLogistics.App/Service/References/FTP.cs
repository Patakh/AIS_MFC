using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;
using System.Globalization;

namespace AisLogistics.App.Service
{
    /// Справочники - FTP
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить список "FTP"
        /// </summary>
        public async Task<(List<FTPDto>, int, int)> GetFTP(IDataTablesRequest request)
        {
            var results = _context.SFtps
                .AsNoTracking()
                .Where(x => !x.IsRemove);

            int totalCount = await results.CountAsync();

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? results
                : results.Search(s => s.FtpFolder.ToLower()).Containing(request.Search.Value.ToLower());

            var filteredDataCount = String.IsNullOrWhiteSpace(request.Search.Value) ? totalCount : await filteredData.CountAsync();

            var dataPage = await filteredData
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new FTPDto()
                {
                    Id = x.Id,
                    FtpServer = x.FtpServer,
                    FtpFolder = x.FtpFolder,
                    FtpLogin = x.FtpLogin,

                }).ToListAsync();

            return (dataPage, totalCount, filteredDataCount);
        }
        /// <summary>
        /// Получить список "FTP"
        /// </summary>
        public async Task<List<FtpModelDto>> GetFTPAllAsync()
        {
            return await _context.SFtps
                .AsNoTracking()
                .Where(x => !x.IsRemove)
                .Select(s => new FtpModelDto
                {
                    Id = s.Id,
                    FtpServer = s.FtpServer,
                    FtpFolder = s.FtpFolder,
                    FtpLogin = s.FtpLogin
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для редактирования FTP
        /// </summary>
        public async Task<FtpModelDto?> GetFTPDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SFtps.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");

            return _mapper.Map<FtpModelDto>(result);
        }

        public async Task AddFTPAsync(FtpModelDto model)
        {
            var entity = _mapper.Map<SFtp>(model);

            await _context.SFtps.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFTPAsync(FtpModelDto model)
        {
            var entity = await _context.SFtps.FindAsync(model.Id) ?? throw new InvalidOperationException("Данные не найдены!");
            _mapper.Map<FtpModelDto, SFtp>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление (удалить?) FTP
        /// </summary>
        /// <param name="Id">ID записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveFTPAsync(Guid Id, string comment)
        {
            var entity = await _context.SFtps.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");
            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }
    }
}
