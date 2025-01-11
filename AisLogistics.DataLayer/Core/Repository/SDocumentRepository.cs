using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Core.IRepositories;
using AisLogistics.DataLayer.Entities.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Core.Repository
{
    public class SDocumentRepository : GenericRepository<DocumentModelDto>, ISDocumentsRepository
    {
        public SDocumentRepository(IMapper mapper, AisLogisticsContext context, ILogger logger) : base(context, logger)
        { 
            
        }

        public override async Task<IQueryable<DocumentModelDto>> All()
        {
            return null; //_mapper.Map<IQueryable<DocumentDto>>(DbSet);
            //try
            // {
            //return DbSet;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "{Repo} All function error", typeof(SDocumentRepository));

            //    //return new EntityQueryable<SDocument>(null, null);
            //}
        }

        public override async Task<bool> Upsert(DocumentModelDto entity)
        {
            try
            {
                var existingUser = await DbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                //existingUser.DocumentName = entity.DocumentName;
               // existingUser.DocumentDescription = entity.DocumentDescription;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(SDocumentRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (exist == null) return false;

                DbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(SDocumentRepository));
                return false;
            }
        }
    }
}