using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AisLogistics.DataLayer.Core.IRepositories;

namespace AisLogistics.DataLayer.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        //IDataServicesRepository DataServices { get; }
        ISDocumentsRepository SDocuments { get; }

        Task CompleteAsync();
    }
}
