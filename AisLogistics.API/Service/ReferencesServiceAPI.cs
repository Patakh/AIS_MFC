using AisLogistics.API.Models.Dto;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Models.Responce.References;
using AisLogistics.DataLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace AisLogistics.API.Service
{
    public class ReferencesServiceAPI : IReferencesServiceAPI
    {
        private readonly AisLogisticsContext _context;

        public ReferencesServiceAPI(AisLogisticsContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceInfoResponse>?> GetServiceInfo()
        {
            try
            {
               
                var data = await _context.GetServiceInfoForPanelHead();
                if (data is null) throw new InvalidOperationException("Данные не найдены");
                return data.Select(s=> new ServiceInfoResponse
                {
                    Name = s.Name,
                    ConsultationCount = s.ConsultationCount,
                    IssuedCount = s.IssuedCount,
                    ReceivedCount = s.ReceivedCount,
                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ServiceOfficeInfoResponse>?> GetServiceOfficeInfo([FromQuery] int periodId)
        {
            try
            {
                var data = await _context.GetServiceOfficeInfoForPanelHead(periodId);
                if (data is null) throw new InvalidOperationException("Данные не найдены");
                return data.Select(s => new ServiceOfficeInfoResponse
                {
                    Name = s.Name,
                    ConsultationCount = s.ConsultationCount ?? 0,
                    IssuedCount = s.IssuedCount ?? 0,
                    ReceivedCount = s.ReceivedCount ?? 0,
                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ServiceStaticDataMfcResponse>?> GetServiceStaticDataMfc()
        {
            try
            {
                var data = await _context.GetServiceStaticDataMfcInfoForPanelHead();
                if (data is null) throw new InvalidOperationException("Данные не найдены");
                return data.Select(s => new ServiceStaticDataMfcResponse
                {
                    Name = s.Name,
                    Value = s.Value,
                }).ToList();
            }
            catch 
            { 
                return null; 
            }
        }

        public async Task<List<ServiceStateTaskInfoResponse>?> GetServiceStateTaskInfo()
        {
            try
            {
                var response = new List<ServiceStateTaskInfoResponse>();
                var data = await _context.GetServiceStateTaskInfoForPanelHead();
                if (data is null) throw new InvalidOperationException("Данные не найдены");
                return data.Select(s => new ServiceStateTaskInfoResponse
                {
                    StateTaskCount = s.StateTaskCount,
                    ExecutedCount = s.ExecutedCount,
                    ExecutedPercent = s.ExecutedPercent,
                    Forecastcount = s.Forecastcount,
                    Forecastpercent = s.Forecastpercent,
                }).ToList();
            }
            catch 
            { 
                return null; 
            }
        }

        public async Task<List<MfcListInfoResponse>?> GetMfcListInfo()
        {
            try
            {
                var date = DateTime.UtcNow;
                return await _context.SOffices
                    .AsNoTracking()
                    .Where(w => w.SOfficesTypeId == 1).Select(s => new MfcListInfoResponse
                    {
                        Id = s.Id,
                        Name = s.OfficeName,
                        Address = s.OfficeAdress,
                        CountWindows = s.ReceiveWindowsCount,
                        Website = s.OfficeWebsite,
                        Skype = s.OfficeSkype,
                        Email = s.OfficeEmail,
                        Latitude = s.OfficeLatitude,
                        Longitude = s.OfficeLongitude,
                        Inn = s.OfficeInn,
                        Ogrn = s.OfficeOgrn,
                        PhoneNumber = s.OfficePhoneNumber,
                        QueueId = s.QueueId,
                        OfficeSquare = s.OfficeSquare,
                        OfficeImage = s.OfficeImage,
                        DirectorName = s.SEmployeesOfficesJoins.Where(w => w.SEmployeesJobPositionId == 64 && w.DateStart <= date.Date && (w.DateStop == null || w.DateStop >= date.Date) && !w.IsRemove).Select(ss => ss.SEmployees.EmployeeName).FirstOrDefault()
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<MfcShedulesInfoResponse>?> GetMfcShedulesInfo(Guid Id)
        {
            try
            {
                return await _context.SOfficesShedules
                    .AsNoTracking()
                    .Where(w => w.SOfficesId == Id)
                    .OrderBy(o => o.SDaysWeekId)
                    .Select(s => new MfcShedulesInfoResponse
                    {
                        Id = s.Id,
                        DayType = s.DayType,
                        DaysWeekId = s.SDaysWeekId,
                        DaysWeekName = s.SDaysWeek.DayName,
                        DaysWeekSmall = s.SDaysWeek.DaySmallName,
                        DinnerStart = s.DinnerStart.HasValue ? s.DinnerStart.ToString() : null,
                        DinnerStop = s.DinnerStop.HasValue ? s.DinnerStop.ToString() : null,
                        WorkStart = s.WorkStart.HasValue ? s.WorkStart.ToString() : null,
                        WorkStop = s.WorkStop.HasValue ? s.WorkStop.ToString() : null,
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<MfcServicesCountResponse>?> GetMfcServicesCountInfo(Guid Id)
        {
            try
            {
                var date = DateTime.Now;
                return await _context.SServices
                    .AsNoTracking()
                    .Where(w=> w.SServicesActives.Any(a => a.DateStart <= date && (!a.DateStop.HasValue || a.DateStop >= date) && a.SOfficesId==Id && !a.IsRemove))
                    .GroupBy(g=> new { g.SServicesTypeId, g.SServicesType.TypeName })
                    .Select(s => new MfcServicesCountResponse
                    {
                        Id = s.Key.SServicesTypeId,
                        Name = s.Key.TypeName,
                        Count = s.Count()
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ProvidersInfoResponse>?> GetProvidersListInfo()
        {
            try
            {
                return await _context.SOffices
                    .AsNoTracking()
                    .Where(w => w.IsProviderService).Select(s => new ProvidersInfoResponse
                    {
                        Id = s.Id,
                        Name = s.OfficeName,
                        TypeId = s.SOfficesTypeId,
                        TypeName = s.SOfficesType.TypeName
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesRecipientsInfoResponse>?> GetRecipientsListInfo()
        {
            try
            {
                return await _context.SServicesCustomerTypes
                    .AsNoTracking()
                    .Where(x => x.IdParent == 0)
                    .Select(s => new ServicesRecipientsInfoResponse
                    {
                        Id = s.Id,
                        Name = s.TypeName,
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<LivingSituationInfoResponse>?> GetLivingSituationsListInfo()
        {
            try
            {
                return await _context.SServicesLivingSituations
                    .AsNoTracking()
                    .Where(x => !x.IsRemove)
                    .Select(s => new LivingSituationInfoResponse
                    {
                        Id = s.Id,
                        Name = s.SituationName,
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesTypeInfoResponse>?> GetServicesTypeListInfo()
        {
            try
            {
                return await _context.SServicesTypes
                     .AsNoTracking()
                     .Select(s => new ServicesTypeInfoResponse
                     {
                         Id = s.Id,
                         Name = s.TypeName
                     }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesListInfoResponse>?> GetServicesListInfo()
        {
            try
            {
                var date = DateTime.Now;
                return await _context.SServices
                     .AsNoTracking()
                     .Where(w => !w.IsRemove && w.IsUploadingSite && w.SServicesActives.Any(a=> a.DateStart<date&&(!a.DateStop.HasValue||a.DateStop>date)))
                     .Select(s => new ServicesListInfoResponse
                     {
                         Id = s.Id,
                         Name = s.ServiceName,
                         NameSmall = s.ServiceNameSmall,
                         NameSite = s.ServiceNameSite,
                         Description = s.ServiceDescription,
                         ProviderName = s.SOffice.OfficeName,
                         ProviderId = s.SOfficesId,
                         LegalAct = s.LegalAct,
                         TypeName = s.SServicesType.TypeName,
                         TypeId = s.SServicesTypeId,
                     }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesPopularInfoResponse>?> GetServicesPopularListInfo()
        {
            try
            {
                var date = DateTime.Now.AddDays(-7);
                return await _context.SServices
                     .AsNoTracking()
                     .Where(w => !w.IsRemove && w.IsUploadingSite).Select(s => new ServicesPopularInfoResponse
                     {
                         Id = s.Id,
                         Name = s.ServiceName,
                         NameSmall = s.ServiceNameSmall,
                         NameSite = s.ServiceNameSite,
                         Description = s.ServiceDescription,
                         ProviderName = s.SOffice.OfficeName,
                         ProviderId = s.SOfficesId,
                         LegalAct = s.LegalAct,
                         TypeName = s.SServicesType.TypeName,
                         TypeId = s.SServicesTypeId,
                         CountServices = s.DServices.Count(c=>c.DateAdd>=date),
                     })
                     .OrderByDescending(o => o.CountServices)
                     .Take(10)
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ServicesInfoResponse?> GetServicesInfo(Guid Id)
        {
            try
            {
                var services = await _context.SServices
                    .AsNoTracking()
                    .Where(w => w.Id == Id)
                    .Select(s => new ServicesInfoResponse
                    {
                        Id = s.Id,
                        Name = s.ServiceName,
                        NameSmall = s.ServiceNameSmall,
                        NameSite = s.ServiceNameSite,
                        Description = s.ServiceDescription,
                        ProviderName = s.SOffice.OfficeName,
                        ProviderId = s.SOfficesId,
                        LegalAct = s.LegalAct,
                        TypeName = s.SServicesType.TypeName,
                        TypeId = s.SServicesTypeId,
                    }).FirstOrDefaultAsync();

                if (services is null) throw new InvalidOperationException("Данные не найдены");

                services.LivingSituationInfoResponses = await GetServicesLivingSituationsInfo(Id);
                services.ServicesRecipientsInfoResponses = await GetServicesRecipientsInfo(Id);
                services.ServicesDocumentsInfoResponses = await GetServicesDocumentsInfo(Id);
                services.ServicesDocumentResultsInfoResponses = await GetServicesDocumentResultsInfo(Id);
                services.ServicesTariffsInfoResponses = await GetServicesTariffsInfo(Id);
                services.ServicesWaysGetsInfoResponses = await GetServicesWaysGetsInfo(Id);
                services.ServicesReasonsInfoResponses = await GetServicesReasonsInfo(Id);
                services.servicesFilesInfoResponses = await GetServicesFilesInfo(Id);

                return services;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<LivingSituationInfoResponse>?> GetServicesLivingSituationsInfo(Guid Id)
        {
            try
            {
                return await _context.SServicesLivingSituationJoins
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && x.SServicesId == Id)
                    .Select(s => new LivingSituationInfoResponse
                    {
                        Id = s.SServicesLivingSituationsId,
                        Name = s.SServicesLivingSituations.SituationName,
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesRecipientsInfoResponse>?> GetServicesRecipientsInfo(Guid Id)
        {
            try
            {
                return await _context.SServicesCustomers
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && x.SServices.Id == Id)
                    .Select(s => new ServicesRecipientsInfoResponse
                    {
                        Id = s.SServicesCustomerTypeId,
                        Name = s.SServicesCustomerType.TypeName,
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesDocumentsInfoResponse>?> GetServicesDocumentsInfo(Guid Id)
        {
            try
            {
                return await _context.SServicesDocuments
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && x.SServices.Id == Id && x.IsUploadingSite)
                    .Select(s => new ServicesDocumentsInfoResponse
                    {
                        Id = s.Id,
                        Name = s.SDocuments.DocumentName,
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesDocumentResultsInfoResponse>?> GetServicesDocumentResultsInfo(Guid Id)
        {
            try
            {
                return await _context.SServicesDocumentsResults
                   .AsNoTracking()
                   .Where(x => !x.IsRemove && x.SServices.Id == Id)
                   .Select(s => new ServicesDocumentResultsInfoResponse
                   {
                       Id = s.Id,
                       Name = s.SDocuments.DocumentName,
                   }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesTariffsInfoResponse>?> GetServicesTariffsInfo(Guid Id)
        {
            try
            {
                return await _context.SServicesCustomerTariffs
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServicesCustomer.SServicesId == Id)
                .Select(s => new ServicesTariffsInfoResponse
                {
                    Id = s.Id,
                    Name = s.SServicesTariffType.TariffTypeName,
                    CustomerName = s.SServicesCustomer.SServicesCustomerType.TypeName,
                    Tariff = s.Tariff,
                    TariffMfc = s.TariffMfc
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesReasonsInfoResponse>?> GetServicesReasonsInfo(Guid Id)
        {
            try
            {
                return await _context.SServicesReasons
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServicesId == Id)
                .Select(s => new ServicesReasonsInfoResponse
                {
                    Id = s.Id,
                    ReasonText = s.ReasonText,
                    LegalAct = s.LegalAct
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesWaysGetsInfoResponse>?> GetServicesWaysGetsInfo(Guid Id)
        {
            try
            {
                return await _context.SServicesWayGetJoins
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.SServicesId == Id)
                .Select(s => new ServicesWaysGetsInfoResponse
                {
                    Id = s.Id,
                    Name = s.SServicesWayGet.NameWay,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesFilesInfoResponse>?> GetServicesFilesInfo(Guid Id)
        {
            try
            {
                return await _context.SServicesFiles
                .AsNoTracking()
                .Where(x => x.SServicesId == Id && !x.IsRemove && !x.IsDownload)
                .Select(s => new ServicesFilesInfoResponse
                {
                    Id = s.Id,
                    Name = s.FileName,
                    Size = s.FileSize,
                    Extensions = s.FileExpansion
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<FileDownLoanDto?> GetServicesFileDownLoad(Guid Id)
        {
            try
            {
                return await _context.SServicesFiles
                .AsNoTracking()
                .Select(s => new FileDownLoanDto
                {
                    Id = s.Id,
                    Name = s.FileName,
                    Extensions = s.FileExpansion,
                    Content = s.File,
                }).FirstOrDefaultAsync(f => f.Id == Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
