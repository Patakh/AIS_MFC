using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Core.IConfiguration;
using AisLogistics.DataLayer.Core.IRepositories;
using AisLogistics.DataLayer.Core.Repository;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AisLogistics.DataLayer.Core.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AisLogisticsContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ISDocumentsRepository SDocuments { get; private set; }

        public UnitOfWork(IMapper mapper, AisLogisticsContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            _mapper = mapper;
            SDocuments = new SDocumentRepository(mapper, context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
