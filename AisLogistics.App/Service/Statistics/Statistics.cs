using AisLogistics.App.Models.DTO.Statistics;
using AisLogistics.App.Models.Statistics;
using AisLogistics.App.ViewModels.Statistics;
using AisLogistics.DataLayer.Concrete;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AisLogistics.App.Service
{
    public class Statistics : IStatistics
    {
        private readonly AisLogisticsContext _context;
        public Statistics(AisLogisticsContext context)
        {
            _context = context;
        }
       
        public async Task<StatisticsResponse> GetAnaliticsAsync()
        {
            var statistics = new StatisticsResponse();
            try
            {
                statistics.InfoForTotay = await StatisticsDataForToday();
                return statistics;
            }
            catch (Exception ex)
            {
                return statistics;
            }

        }

        public async Task<StatisticsGeneralInfo?> StatisticsDataForToday()
        {
            try
            {
                var dateIndicators = DateTime.UtcNow.AddDays(-1);
                List<int> indicators = new List<int>() { 1, 25, 29 };
                var response = new StatisticsGeneralInfo();

                response.ReceivedCount = await _context.DServices.CountAsync(c => c.DateAdd.Date == DateTime.Now.Date); ;
                response.IssuedCount = await _context.DServicesRoutesStages.CountAsync(c => c.DateAdd.Date == DateTime.Now.Date && c.SRoutesStageId == 7);
                response.ConsultationCount = await _context.DServices.CountAsync(c => c.DateFact.HasValue && c.DateFact.Value.Date == DateTime.Now.Date && c.SServicesStatusId == 6);
                response.ExecutionCount = await _context.DServices.CountAsync(c => !c.DateFact.HasValue && c.SServicesStatusId == 0);
                response.ExpiredCount = await _context.DServices.CountAsync(c => !c.DateFact.HasValue && c.DateReg.Date < DateTime.Now.Date);
                response.SmevRequestCount = await _context.DServicesSmevRequests.CountAsync(c => c.DateAdd.Date == DateTime.Now.Date);
                response.SmevResponseCount = await _context.DServicesSmevRequests.CountAsync(c => c.DateFact.HasValue && c.DateFact.Value.Date == DateTime.Now.Date);

                var stateTask = await _context.DIndicatorsValues.Where(w => w.IndicatorDate.Date <= dateIndicators.Date && w.Year == dateIndicators.Year && (w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32)).SumAsync(s => s.IndicatorValue);
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == dateIndicators.Year).Select(s => s.CountService).FirstOrDefaultAsync();
                if(stateTaskYear!=0)
                response.ServiceStateTaskCount = Math.Round(stateTask / stateTaskYear * 100, 2);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<StatisticsGeneralResponse?> StatisticsGeneral()
        {
            try
            {
                var dateIndicators = DateTime.UtcNow.AddDays(-1);
                List<int> indicators = new List<int>() { 1, 25, 29 };
                var response = new StatisticsGeneralResponse();

                response.Info.ReceivedCount = await _context.DServices.CountAsync(c => c.DateAdd.Date == DateTime.Now.Date); ;
                response.Info.IssuedCount = await _context.DServicesRoutesStages.CountAsync(c => c.DateAdd.Date == DateTime.Now.Date && c.SRoutesStageId == 7);
                response.Info.ConsultationCount = await _context.DServices.CountAsync(c => c.DateFact.HasValue && c.DateFact.Value.Date == DateTime.Now.Date && c.SServicesStatusId == 6);
                response.Info.ExecutionCount = await _context.DServices.CountAsync(c => !c.DateFact.HasValue && c.SServicesStatusId == 0);
                response.Info.ExpiredCount = await _context.DServices.CountAsync(c => !c.DateFact.HasValue && c.DateReg.Date < DateTime.Now.Date);
                response.Info.SmevRequestCount = await _context.DServicesSmevRequests.CountAsync(c => c.DateAdd.Date == DateTime.Now.Date);
                response.Info.SmevResponseCount = await _context.DServicesSmevRequests.CountAsync(c => c.DateFact.HasValue && c.DateFact.Value.Date == DateTime.Now.Date);

                var stateTask = await _context.DIndicatorsValues.Where(w => w.IndicatorDate.Date <= dateIndicators.Date && w.Year == dateIndicators.Year && (w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32)).SumAsync(s => s.IndicatorValue);
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == dateIndicators.Year).Select(s => s.CountService).FirstOrDefaultAsync();
                response.Info.ServiceStateTaskCount = Math.Round(stateTask / stateTaskYear * 100, 2);

                response.Top.OfficesList = await _context.DIndicatorsValues
                    .AsNoTracking()
                     .Where(w => w.Month == dateIndicators.Month &&
                              w.Year == dateIndicators.Year &&
                              indicators.Contains(w.SIndicatorsId))
                    .Join(_context.SOffices, c => c.SOfficesId, d => d.Id, (c, d) => new { c.SOfficesId, c.IndicatorValue, d.OfficeName })
                    .Select(s => new { s.OfficeName, s.SOfficesId, s.IndicatorValue })
                    .GroupBy(g => g.SOfficesId)
                    .Select(s => new { Name = s.First().OfficeName, Point = (int)s.Sum(s => s.IndicatorValue) })
                    .OrderByDescending(o => o.Point)
                    .Take(3)
                    .Select(s => s.Name)
                    .ToListAsync();

                response.Top.ProvidersList = await _context.DIndicatorsValues
                     .AsNoTracking()
                     .Where(w => w.Month == dateIndicators.Month &&
                              w.Year == dateIndicators.Year &&
                              w.SIndicatorsId == 1)
                    .Join(_context.SOffices, c => c.SOfficesIdProvider, d => d.Id, (c, d) => new { c.SOfficesIdProvider, c.IndicatorValue, d.OfficeName })
                    .Select(s => new { s.OfficeName, s.SOfficesIdProvider, s.IndicatorValue })
                    .GroupBy(g => g.SOfficesIdProvider)
                    .Select(s => new { Name = s.First().OfficeName, Point = (int)s.Sum(s => s.IndicatorValue) })
                    .OrderByDescending(o => o.Point)
                    .Take(3)
                    .Select(s => s.Name)
                    .ToListAsync();

                response.Top.ServicesList = await _context.DIndicatorsValues
                     .AsNoTracking()
                     .Where(w => w.Month == dateIndicators.Month &&
                              w.Year == dateIndicators.Year &&
                              w.SIndicatorsId == 1)
                    .Join(_context.SServices, c => c.SServicesId, d => d.Id, (c, d) => new { c.SServicesId, c.IndicatorValue, d.ServiceName })
                    .Select(s => new { s.ServiceName, s.SServicesId, s.IndicatorValue })
                    .GroupBy(g => g.SServicesId)
                    .Select(s => new { Name = s.First().ServiceName, Point = (int)s.Sum(s => s.IndicatorValue) })
                    .OrderByDescending(o => o.Point)
                    .Take(3)
                    .Select(s => s.Name)
                    .ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<List<StatisticsGeneralGraphic>?> StatisticsGeneralGraphicTypeDay(StatisticsViewRequestModel requestModel)
        {
            try
            {
                var date = DateTime.Today.AddDays(-1);
                var stage = requestModel.StageId.HasValue ? new List<int>() { requestModel.StageId.Value } : new List<int>() { 1, 29, 25 };
                var data = await _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => stage.Contains(w.SIndicatorsId) && w.IndicatorDate >= date.AddMonths(-1) &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.ProviderId.HasValue || requestModel.ProviderId == Guid.Empty || w.SOfficesIdProvider == requestModel.ProviderId) &&
                                (!requestModel.ServiceId.HasValue || requestModel.ServiceId == Guid.Empty || w.SServicesId == requestModel.ServiceId) &&
                                (!requestModel.CustomerTypeId.HasValue || requestModel.CustomerTypeId == -1 || w.SServicesCustomerTypeId == requestModel.CustomerTypeId) &&
                                (!requestModel.ServiceTypeId.HasValue || requestModel.ServiceTypeId == -1 || w.SServicesTypeId == requestModel.ServiceTypeId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == -1 || w.SServicesInteractionId == requestModel.InteractionTypeId)
                         )
                    .GroupBy(g => g.IndicatorDate)
                    .OrderBy(o => o.Key)
                    .Select(s => new StatisticsGeneralGraphic { Name = s.Key.ToShortDateString(), Value = (int)s.Sum(s => s.IndicatorValue) })
                    .ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<StatisticsGeneralGraphic>?> StatisticsGeneralGraphicTypeYear(StatisticsViewRequestModel requestModel)
        {
            try
            {
                var stage = requestModel.StageId.HasValue ? new List<int>() { requestModel.StageId.Value } : new List<int>() { 1, 29, 25 };
                var data = await _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => stage.Contains(w.SIndicatorsId) && w.Year == requestModel.YearId &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.ProviderId.HasValue || requestModel.ProviderId == Guid.Empty || w.SOfficesIdProvider == requestModel.ProviderId) &&
                                (!requestModel.ServiceId.HasValue || requestModel.ServiceId == Guid.Empty || w.SServicesId == requestModel.ServiceId) &&
                                (!requestModel.CustomerTypeId.HasValue || requestModel.CustomerTypeId == -1 || w.SServicesCustomerTypeId == requestModel.CustomerTypeId) &&
                                (!requestModel.ServiceTypeId.HasValue || requestModel.ServiceTypeId == -1 || w.SServicesTypeId == requestModel.ServiceTypeId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == -1 || w.SServicesInteractionId == requestModel.InteractionTypeId)
                         )
                    .GroupBy(g => new { g.Month, g.Year })
                    .OrderBy(o => o.Key.Year)
                    .ThenBy(o => o.Key.Month)
                    .Select(s => new StatisticsGeneralGraphic { Name = DateTime.Parse($"01.{s.Key.Month}.{s.Key.Year}").ToString("Y"), Value = (int)s.Sum(s => s.IndicatorValue) })
                    .ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsMfcData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == requestModel.YearId).Select(s => s.CountService).FirstOrDefaultAsync();
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => (!requestModel.YearId.HasValue || w.Year == requestModel.YearId) &&
                                (!requestModel.MonthId.HasValue || requestModel.MonthId == 0 || w.Month == requestModel.MonthId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == 0 || w.SServicesInteractionId == requestModel.InteractionTypeId) &&
                                (!requestModel.ProviderId.HasValue || requestModel.ProviderId == Guid.Empty || w.SOfficesIdProvider == requestModel.ProviderId) &&
                                (!requestModel.ServiceId.HasValue || requestModel.ServiceId == Guid.Empty || w.SServicesId == requestModel.ServiceId) &&
                                (!requestModel.CustomerTypeId.HasValue || requestModel.CustomerTypeId == -1 || w.SServicesCustomerTypeId == requestModel.CustomerTypeId) &&
                                (!requestModel.ServiceTypeId.HasValue || requestModel.ServiceTypeId == -1 || w.SServicesTypeId == requestModel.ServiceTypeId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == -1 || w.SServicesInteractionId == requestModel.InteractionTypeId)
                           )
                     .Join(_context.SOffices, c => c.SOfficesId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.OfficeName })
                    .GroupBy(g => g.OfficeName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsMfcDataResponse
                    {
                        Name = s.Key,
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 1).Sum(s => s.IndicatorValue),
                        ReceivedStateSum = s.Where(w => w.SIndicatorsId == 2).Sum(s => s.IndicatorValue),
                        IssuedCount = (int)s.Where(w => w.SIndicatorsId == 29).Sum(s => s.IndicatorValue),
                        ConsultationCount = (int)s.Where(w => w.SIndicatorsId == 25).Sum(s => s.IndicatorValue),
                        RefusalCount = (int)s.Where(w => w.SIndicatorsId == 26).Sum(s => s.IndicatorValue),
                        ExpiredCount = (int)s.Where(w => w.SIndicatorsId == 5).Sum(s => s.IndicatorValue),
                        ExecutionCount = (int)s.Where(w => w.SIndicatorsId == 4).Sum(s => s.IndicatorValue),
                        ServiceStateTaskCount = (int)s.Where(w => w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32).Sum(s => s.IndicatorValue),
                        StateTaskYear = stateTaskYear
                    })
                    .OrderByDescending(o => o.ReceivedCount + o.IssuedCount + o.ConsultationCount)
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsMfcDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsEmployeeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == requestModel.YearId).Select(s => s.CountService).FirstOrDefaultAsync();
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => (!requestModel.YearId.HasValue || w.Year == requestModel.YearId) &&
                                (!requestModel.MonthId.HasValue || requestModel.MonthId == 0 || w.Month == requestModel.MonthId) &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.ProviderId.HasValue || requestModel.ProviderId == Guid.Empty || w.SOfficesIdProvider == requestModel.ProviderId) &&
                                (!requestModel.ServiceId.HasValue || requestModel.ServiceId == Guid.Empty || w.SServicesId == requestModel.ServiceId) &&
                                (!requestModel.CustomerTypeId.HasValue || requestModel.CustomerTypeId == -1 || w.SServicesCustomerTypeId == requestModel.CustomerTypeId) &&
                                (!requestModel.ServiceTypeId.HasValue || requestModel.ServiceTypeId == -1 || w.SServicesTypeId == requestModel.ServiceTypeId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == -1 || w.SServicesInteractionId == requestModel.InteractionTypeId)
                           )
                     .Join(_context.SEmployees, c => c.SEmployeesId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.EmployeeName })
                    .GroupBy(g => g.EmployeeName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsMfcDataResponse
                    {
                        Name = s.Key,
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 1).Sum(s => s.IndicatorValue),
                        ReceivedStateSum = s.Where(w => w.SIndicatorsId == 2).Sum(s => s.IndicatorValue),
                        IssuedCount = (int)s.Where(w => w.SIndicatorsId == 29).Sum(s => s.IndicatorValue),
                        ConsultationCount = (int)s.Where(w => w.SIndicatorsId == 25).Sum(s => s.IndicatorValue),
                        RefusalCount = (int)s.Where(w => w.SIndicatorsId == 26).Sum(s => s.IndicatorValue),
                        ExpiredCount = (int)s.Where(w => w.SIndicatorsId == 5).Sum(s => s.IndicatorValue),
                        ExecutionCount = (int)s.Where(w => w.SIndicatorsId == 4).Sum(s => s.IndicatorValue),
                        ServiceStateTaskCount = (int)s.Where(w => w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32).Sum(s => s.IndicatorValue),
                        StateTaskYear = stateTaskYear
                    })
                    .OrderByDescending(o => o.ReceivedCount + o.IssuedCount + o.ConsultationCount)
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsMfcDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsProviderData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == requestModel.YearId).Select(s => s.CountService).FirstOrDefaultAsync();
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => (!requestModel.YearId.HasValue || w.Year == requestModel.YearId) &&
                                (!requestModel.MonthId.HasValue || requestModel.MonthId == 0 || w.Month == requestModel.MonthId) &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.CustomerTypeId.HasValue || requestModel.CustomerTypeId == -1 || w.SServicesCustomerTypeId == requestModel.CustomerTypeId) &&
                                (!requestModel.ServiceTypeId.HasValue || requestModel.ServiceTypeId == -1 || w.SServicesTypeId == requestModel.ServiceTypeId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == -1 || w.SServicesInteractionId == requestModel.InteractionTypeId)
                           )
                     .Join(_context.SOffices, c => c.SOfficesIdProvider, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.OfficeName })
                    .GroupBy(g => g.OfficeName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsMfcDataResponse
                    {
                        Name = s.Key,
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 1).Sum(s => s.IndicatorValue),
                        ReceivedStateSum = s.Where(w => w.SIndicatorsId == 2).Sum(s => s.IndicatorValue),
                        IssuedCount = (int)s.Where(w => w.SIndicatorsId == 29).Sum(s => s.IndicatorValue),
                        ConsultationCount = (int)s.Where(w => w.SIndicatorsId == 25).Sum(s => s.IndicatorValue),
                        RefusalCount = (int)s.Where(w => w.SIndicatorsId == 26).Sum(s => s.IndicatorValue),
                        ExpiredCount = (int)s.Where(w => w.SIndicatorsId == 5).Sum(s => s.IndicatorValue),
                        ExecutionCount = (int)s.Where(w => w.SIndicatorsId == 4).Sum(s => s.IndicatorValue),
                        ServiceStateTaskCount = (int)s.Where(w => w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32).Sum(s => s.IndicatorValue),
                        StateTaskYear = stateTaskYear
                    })
                    .OrderByDescending(o => o.ReceivedCount + o.IssuedCount + o.ConsultationCount)
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsMfcDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsServiceData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == requestModel.YearId).Select(s => s.CountService).FirstOrDefaultAsync();
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => (!requestModel.YearId.HasValue || w.Year == requestModel.YearId) &&
                                (!requestModel.MonthId.HasValue || requestModel.MonthId == 0 || w.Month == requestModel.MonthId) &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.ProviderId.HasValue || requestModel.ProviderId == Guid.Empty || w.SOfficesIdProvider == requestModel.ProviderId) &&
                                (!requestModel.CustomerTypeId.HasValue || requestModel.CustomerTypeId == -1 || w.SServicesCustomerTypeId == requestModel.CustomerTypeId) &&
                                (!requestModel.ServiceTypeId.HasValue || requestModel.ServiceTypeId == -1 || w.SServicesTypeId == requestModel.ServiceTypeId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == -1 || w.SServicesInteractionId == requestModel.InteractionTypeId)
                           )
                     .Join(_context.SServices, c => c.SServicesId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.ServiceName })
                    .GroupBy(g => g.ServiceName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsMfcDataResponse
                    {
                        Name = s.Key,
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 1).Sum(s => s.IndicatorValue),
                        ReceivedStateSum = s.Where(w => w.SIndicatorsId == 2).Sum(s => s.IndicatorValue),
                        IssuedCount = (int)s.Where(w => w.SIndicatorsId == 29).Sum(s => s.IndicatorValue),
                        ConsultationCount = (int)s.Where(w => w.SIndicatorsId == 25).Sum(s => s.IndicatorValue),
                        RefusalCount = (int)s.Where(w => w.SIndicatorsId == 26).Sum(s => s.IndicatorValue),
                        ExpiredCount = (int)s.Where(w => w.SIndicatorsId == 5).Sum(s => s.IndicatorValue),
                        ExecutionCount = (int)s.Where(w => w.SIndicatorsId == 4).Sum(s => s.IndicatorValue),
                        ServiceStateTaskCount = (int)s.Where(w => w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32).Sum(s => s.IndicatorValue),
                        StateTaskYear = stateTaskYear
                    })
                    .OrderByDescending(o => o.ReceivedCount + o.IssuedCount + o.ConsultationCount)
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsMfcDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsCustomerTypeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == requestModel.YearId).Select(s => s.CountService).FirstOrDefaultAsync();
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => (!requestModel.YearId.HasValue || w.Year == requestModel.YearId) &&
                                (!requestModel.MonthId.HasValue || requestModel.MonthId == 0 || w.Month == requestModel.MonthId) &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.ProviderId.HasValue || requestModel.ProviderId == Guid.Empty || w.SOfficesIdProvider == requestModel.ProviderId) &&
                                (!requestModel.ServiceId.HasValue || requestModel.ServiceId == Guid.Empty || w.SServicesId == requestModel.ServiceId) &&
                                (!requestModel.ServiceTypeId.HasValue || requestModel.ServiceTypeId == -1 || w.SServicesTypeId == requestModel.ServiceTypeId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == -1 || w.SServicesInteractionId == requestModel.InteractionTypeId)
                           )
                     .Join(_context.SServicesCustomerTypes, c => c.SServicesCustomerTypeId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.TypeName })
                    .GroupBy(g => g.TypeName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsMfcDataResponse
                    {
                        Name = s.Key,
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 1).Sum(s => s.IndicatorValue),
                        ReceivedStateSum = s.Where(w => w.SIndicatorsId == 2).Sum(s => s.IndicatorValue),
                        IssuedCount = (int)s.Where(w => w.SIndicatorsId == 29).Sum(s => s.IndicatorValue),
                        ConsultationCount = (int)s.Where(w => w.SIndicatorsId == 25).Sum(s => s.IndicatorValue),
                        RefusalCount = (int)s.Where(w => w.SIndicatorsId == 26).Sum(s => s.IndicatorValue),
                        ExpiredCount = (int)s.Where(w => w.SIndicatorsId == 5).Sum(s => s.IndicatorValue),
                        ExecutionCount = (int)s.Where(w => w.SIndicatorsId == 4).Sum(s => s.IndicatorValue),
                        ServiceStateTaskCount = (int)s.Where(w => w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32).Sum(s => s.IndicatorValue),
                        StateTaskYear = stateTaskYear
                    })
                    .OrderBy(o =>o.Name)
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsMfcDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsServiceTypeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == requestModel.YearId).Select(s => s.CountService).FirstOrDefaultAsync();
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => (!requestModel.YearId.HasValue || w.Year == requestModel.YearId) &&
                                (!requestModel.MonthId.HasValue || requestModel.MonthId == 0 || w.Month == requestModel.MonthId) &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.ProviderId.HasValue || requestModel.ProviderId == Guid.Empty || w.SOfficesIdProvider == requestModel.ProviderId) &&
                                (!requestModel.ServiceId.HasValue || requestModel.ServiceId == Guid.Empty || w.SServicesId == requestModel.ServiceId) &&
                                (!requestModel.CustomerTypeId.HasValue || requestModel.CustomerTypeId == -1 || w.SServicesCustomerTypeId == requestModel.CustomerTypeId) &&
                                (!requestModel.InteractionTypeId.HasValue || requestModel.InteractionTypeId == -1 || w.SServicesInteractionId == requestModel.InteractionTypeId)
                           )
                    .Join(_context.SServicesTypes, c => c.SServicesTypeId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.TypeName })
                    .GroupBy(g => g.TypeName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsMfcDataResponse
                    {
                        Name = s.Key,
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 1).Sum(s => s.IndicatorValue),
                        ReceivedStateSum = s.Where(w => w.SIndicatorsId == 2).Sum(s => s.IndicatorValue),
                        IssuedCount = (int)s.Where(w => w.SIndicatorsId == 29).Sum(s => s.IndicatorValue),
                        ConsultationCount = (int)s.Where(w => w.SIndicatorsId == 25).Sum(s => s.IndicatorValue),
                        RefusalCount = (int)s.Where(w => w.SIndicatorsId == 26).Sum(s => s.IndicatorValue),
                        ExpiredCount = (int)s.Where(w => w.SIndicatorsId == 5).Sum(s => s.IndicatorValue),
                        ExecutionCount = (int)s.Where(w => w.SIndicatorsId == 4).Sum(s => s.IndicatorValue),
                        ServiceStateTaskCount = (int)s.Where(w => w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32).Sum(s => s.IndicatorValue),
                        StateTaskYear = stateTaskYear
                    })
                    .OrderBy(o => o.Name)
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsMfcDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsMfcDataResponse>?, int)> StatisticsInteractionTypeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == requestModel.YearId).Select(s => s.CountService).FirstOrDefaultAsync();
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => (!requestModel.YearId.HasValue || w.Year == requestModel.YearId) &&
                                (!requestModel.MonthId.HasValue || requestModel.MonthId == 0 || w.Month == requestModel.MonthId) &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.ProviderId.HasValue || requestModel.ProviderId == Guid.Empty || w.SOfficesIdProvider == requestModel.ProviderId) &&
                                (!requestModel.ServiceId.HasValue || requestModel.ServiceId == Guid.Empty || w.SServicesId == requestModel.ServiceId) &&
                                (!requestModel.CustomerTypeId.HasValue || requestModel.CustomerTypeId == -1 || w.SServicesCustomerTypeId == requestModel.CustomerTypeId) &&
                                (!requestModel.ServiceTypeId.HasValue || requestModel.ServiceTypeId == -1 || w.SServicesTypeId == requestModel.ServiceTypeId)
                           )
                     .Join(_context.SServicesInteractions, c => c.SServicesInteractionId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.InteractionName })
                    .GroupBy(g => g.InteractionName);

                var count = await data.CountAsync();

                var dataPage = await data 
                    .Select(s => new StatisticsMfcDataResponse
                    {
                        Name = s.Key,
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 1).Sum(s => s.IndicatorValue),
                        ReceivedStateSum = s.Where(w => w.SIndicatorsId == 2).Sum(s => s.IndicatorValue),
                        IssuedCount = (int)s.Where(w => w.SIndicatorsId == 29).Sum(s => s.IndicatorValue),
                        ConsultationCount = (int)s.Where(w => w.SIndicatorsId == 25).Sum(s => s.IndicatorValue),
                        RefusalCount = (int)s.Where(w => w.SIndicatorsId == 26).Sum(s => s.IndicatorValue),
                        ExpiredCount = (int)s.Where(w => w.SIndicatorsId == 5).Sum(s => s.IndicatorValue),
                        ExecutionCount = (int)s.Where(w => w.SIndicatorsId == 4).Sum(s => s.IndicatorValue),
                        ServiceStateTaskCount = (int)s.Where(w => w.SIndicatorsId == 30 || w.SIndicatorsId == 31 || w.SIndicatorsId == 32).Sum(s => s.IndicatorValue),
                        StateTaskYear = stateTaskYear
                    })
                    .OrderBy(o =>o.Name)
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsMfcDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsSmevDataResponse>?, int)> StatisticsSmevData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var dateStart = DateTime.Parse(requestModel.DateStart);
                var dateStop = DateTime.Parse(requestModel.DateStop);
                //var stateTaskYear = await _context.SStateTasks.Where(w => w.YearTask == requestModel.YearId).Select(s => s.CountService).FirstOrDefaultAsync();
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => w.IndicatorDate >= dateStart && w.IndicatorDate <= dateStop &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.SmevId.HasValue || requestModel.SmevId == Guid.Empty || w.SSmevId == requestModel.SmevId)
                           )
                    .Join(_context.SSmevRequests, c => c.SSmevRequestId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.RequestName })
                    .GroupBy(g => g.RequestName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsSmevDataResponse
                    {
                      Name = s.Key,
                      SentCount = (int)s.Where(w => w.SIndicatorsId == 18).Sum(s => s.IndicatorValue),
                      ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 22).Sum(s => s.IndicatorValue),
                    }).OrderByDescending(o => o.SentCount)
                    .Skip(request.Start).Take(request.Length)
                    .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsSmevDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsSmevDataResponse>?, int)> StatisticsSmevMfcData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var dateStart = DateTime.Parse(requestModel.DateStart);
                var dateStop = DateTime.Parse(requestModel.DateStop);
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => w.IndicatorDate >= dateStart && w.IndicatorDate <= dateStop &&
                                (!requestModel.SmevId.HasValue || requestModel.SmevId == Guid.Empty || w.SSmevId == requestModel.SmevId) &&
                                (!requestModel.SmevRequestId.HasValue || requestModel.SmevRequestId == -1 || w.SSmevRequestId == requestModel.SmevRequestId)
                           )
                    .Join(_context.SOffices, c => c.SOfficesId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.OfficeName })
                    .GroupBy(g => g.OfficeName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsSmevDataResponse
                    {
                        Name = s.Key,
                        SentCount = (int)s.Where(w => w.SIndicatorsId == 18).Sum(s => s.IndicatorValue),
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 22).Sum(s => s.IndicatorValue),
                    }).OrderByDescending(o => o.SentCount)
                   .Skip(request.Start).Take(request.Length)
                   .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsSmevDataResponse>(), 0);
            }
        }

        public async Task<(List<StatisticsSmevDataResponse>?, int)> StatisticsSmevEmployeeData(IDataTablesRequest request, StatisticsViewRequestModel requestModel)
        {
            try
            {
                var dateStart = DateTime.Parse(requestModel.DateStart);
                var dateStop = DateTime.Parse(requestModel.DateStop);
                var data = _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => w.IndicatorDate >= dateStart && w.IndicatorDate <= dateStop &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.SmevId.HasValue || requestModel.SmevId == Guid.Empty || w.SSmevId == requestModel.SmevId) &&
                                (!requestModel.SmevRequestId.HasValue || requestModel.SmevRequestId == -1 || w.SSmevRequestId == requestModel.SmevRequestId)
                           )
                    .Join(_context.SEmployees, c => c.SEmployeesId, d => d.Id, (c, d) => new { c.SIndicatorsId, c.IndicatorValue, d.EmployeeName })
                    .GroupBy(g => g.EmployeeName);

                var count = await data.CountAsync();

                var dataPage = await data
                    .Select(s => new StatisticsSmevDataResponse
                    {
                        Name = s.Key,
                        SentCount = (int)s.Where(w => w.SIndicatorsId == 18).Sum(s => s.IndicatorValue),
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 22).Sum(s => s.IndicatorValue),
                    }).OrderByDescending(o => o.SentCount)
                   .Skip(request.Start).Take(request.Length)
                   .ToListAsync();

                return new(dataPage, count);
            }
            catch (Exception ex)
            {
                return new(new List<StatisticsSmevDataResponse>(), 0);
            }
        }


        public async Task<StatisticsServiceGeneralResponse?> StatisticsServicesGeneral()
        {
            try
            {
                var date = DateTime.Now.AddDays(-1);
                var quarterId = (int)Math.Ceiling((decimal)date.Month / 3);
                List<int> indicators = new List<int>() { 1, 25, 29 };
                var day = await _context.DServices.CountAsync(c => c.DateAdd.Date == DateTime.Now.Date);
                var year = (int)await _context.DIndicatorsValues.Where(c => indicators.Any(a => a == c.SIndicatorsId) && c.Year == date.Year).SumAsync(s => s.IndicatorValue);
                var quarter = (int)await _context.DIndicatorsValues.Where(c => indicators.Any(a => a == c.SIndicatorsId) && c.Year == date.Year && c.Quarter == quarterId).SumAsync(s => s.IndicatorValue); ;
                var month = (int)await _context.DIndicatorsValues.Where(c => indicators.Any(a => a == c.SIndicatorsId) && c.Year == date.Year && c.Month == date.Month).SumAsync(s => s.IndicatorValue);
                var execution = await _context.DServices.CountAsync(c => !c.DateFact.HasValue && c.SServicesStatusId == 0);
                var expired = await _context.DServices.CountAsync(c => !c.DateFact.HasValue && c.DateReg.Date < DateTime.Now.Date);

                var response = new StatisticsServiceGeneralResponse();
                response.Info.CountDay = day;
                response.Info.CountMonth = month + day;
                response.Info.CountQuarter = quarter + day;
                response.Info.CountYear = year + day;
                response.Info.CountExecution = execution;
                response.Info.CountExpired = expired;

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Dictionary<string, int>> StatisticsServicesGeneralServiceType()
        {
            return await _context.DIndicatorsValues
                .AsNoTracking()
                .Where(w => w.Year == DateTime.Now.AddDays(-1).Year)
                .Join(_context.SServicesTypes, c => c.SServicesTypeId, d => d.Id, (c, d) => new { d.TypeName, c.IndicatorValue })
                .GroupBy(g => g.TypeName)
                .Select(s => new StatisticsServicesGeneralPie { Name = s.Key, Count = (int)s.Sum(s => s.IndicatorValue) })
                .ToDictionaryAsync(x => x.Name, y => y.Count);
        }
        public async Task<Dictionary<string, int>> StatisticsServicesGeneralCustomerType()
        {
            return await _context.DIndicatorsValues
                .AsNoTracking()
                .Where(w => w.Year == DateTime.Now.AddDays(-1).Year)
                .Join(_context.SServicesCustomerTypes, c => c.SServicesCustomerTypeId, d => d.Id, (c, d) => new { d.TypeName, c.IndicatorValue })
                .GroupBy(g => g.TypeName)
                .Select(s => new StatisticsServicesGeneralPie { Name = s.Key, Count = (int)s.Sum(s => s.IndicatorValue) })
                .ToDictionaryAsync(x => x.Name, y => y.Count);
        }
        public async Task<Dictionary<string, int>> StatisticsServicesGeneralInteractionType()
        {
            return await _context.DIndicatorsValues
                .AsNoTracking()
                .Where(w => w.Year == DateTime.Now.AddDays(-1).Year)
                .Join(_context.SServicesInteractions, c => c.SServicesInteractionId, d => d.Id, (c, d) => new { d.InteractionName, c.IndicatorValue })
                .GroupBy(g => g.InteractionName)
                .Select(s => new StatisticsServicesGeneralPie { Name = s.Key, Count = (int)s.Sum(s => s.IndicatorValue) })
                .ToDictionaryAsync(x => x.Name, y => y.Count);
        }

        public async Task<Dictionary<string, List<string>>?> StatisticsServicesGeneralGraphicTypeDay(StatisticsViewRequestModel requestModel)
        {
            try
            {
                var response = new Dictionary<string, List<string>>();

                var data = _context.DServices.Where(w => w.DateAdd.Date >= DateTime.Now.AddMonths(-1).Date);

                if (requestModel.ServiceTypeId == 1)
                {
                    var group = await data
                            .AsNoTracking()
                            .GroupBy(g => new { g.SServicesType.TypeName, g.DateAdd.Date })
                            .OrderBy(o => o.Key.Date)
                            .Select(s => new
                            {
                                Name = s.Key.TypeName,
                                Date = s.Key.Date.ToShortDateString(),
                                Value = s.Count()
                            })

                            .ToListAsync();

                    response = group.GroupBy(g => g.Name).ToDictionary(x => x.Key, y => y.Select(s => s.Value.ToString()).ToList());

                    var date = group.GroupBy(g => g.Date).Select(s => s.Key).ToList();

                    response.Add("date", date);
                }
                else if (requestModel.ServiceTypeId == 2)
                {
                    var group = await data
                            .AsNoTracking()
                            .GroupBy(g => new { g.SServicesCustomerType.TypeName, g.DateAdd.Date })
                            .OrderBy(o => o.Key.Date)
                            .Select(s => new
                            {
                                Name = s.Key.TypeName,
                                Date = s.Key.Date.ToShortDateString(),
                                Value = s.Count()
                            })

                            .ToListAsync();

                    response = group.GroupBy(g => g.Name).ToDictionary(x => x.Key, y => y.Select(s => s.Value.ToString()).ToList());

                    var date = group.GroupBy(g => g.Date).Select(s => s.Key).ToList();

                    response.Add("date", date);
                }
                else if (requestModel.ServiceTypeId == 3)
                {
                    var group = await data
                            .AsNoTracking()
                            .GroupBy(g => new { g.SServicesInteraction.InteractionName, g.DateAdd.Date })
                            .OrderBy(o => o.Key.Date)
                            .Select(s => new
                            {
                                Name = s.Key.InteractionName,
                                Date = s.Key.Date.ToShortDateString(),
                                Value = s.Count()
                            })

                            .ToListAsync();

                    response = group.GroupBy(g => g.Name).ToDictionary(x => x.Key, y => y.Select(s => s.Value.ToString()).ToList());

                    var date = group.GroupBy(g => g.Date).Select(s => s.Key).ToList();

                    response.Add("date", date);
                }
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<Dictionary<string, List<string>>?> StatisticsServicesGeneralGraphicTypeYear(StatisticsViewRequestModel requestModel)
        {
            try
            {
                var response = new Dictionary<string, List<string>>();

                var data = _context.DIndicatorsValues.Where(w => w.Year == requestModel.YearId);

                if (requestModel.ServiceTypeId == 1)
                {
                    var group = await data
                            .AsNoTracking()
                            .Join(_context.SServicesTypes, c => c.SServicesTypeId, d => d.Id, (c, d) => new { d.TypeName, c.IndicatorValue, c.Month })
                            .GroupBy(g => new { g.TypeName, g.Month })
                            .OrderBy(o => o.Key.Month)
                            .Select(s => new
                            {
                                Name = s.Key.TypeName,
                                Date = DateTime.Parse($"01.{s.Key.Month}.{requestModel.YearId}").ToString("Y"),
                                Value = (int)s.Sum(s => s.IndicatorValue)
                            })
                            .ToListAsync();

                    response = group.GroupBy(g => g.Name).ToDictionary(x => x.Key, y => y.Select(s => s.Value.ToString()).ToList());

                    var date = group.GroupBy(g => g.Date).Select(s => s.Key).ToList();

                    response.Add("date", date);
                }
                else if (requestModel.ServiceTypeId == 2)
                {
                    var group = await data
                            .AsNoTracking()
                            .Join(_context.SServicesCustomerTypes, c => c.SServicesCustomerTypeId, d => d.Id, (c, d) => new { d.TypeName, c.IndicatorValue, c.Month })
                            .GroupBy(g => new { g.TypeName, g.Month })
                            .OrderBy(o => o.Key.Month)
                            .Select(s => new
                            {
                                Name = s.Key.TypeName,
                                Date = DateTime.Parse($"01.{s.Key.Month}.{requestModel.YearId}").ToString("Y"),
                                Value = (int)s.Sum(s => s.IndicatorValue)
                            })
                            .ToListAsync();

                    response = group.GroupBy(g => g.Name).ToDictionary(x => x.Key, y => y.Select(s => s.Value.ToString()).ToList());

                    var date = group.GroupBy(g => g.Date).Select(s => s.Key).ToList();

                    response.Add("date", date);
                }
                else if (requestModel.ServiceTypeId == 3)
                {
                    var group = await data
                            .AsNoTracking()
                            .Join(_context.SServicesInteractions, c => c.SServicesInteractionId, d => d.Id, (c, d) => new { d.InteractionName, c.IndicatorValue, c.Month })
                            .GroupBy(g => new { g.InteractionName, g.Month })
                            .OrderBy(o => o.Key.Month)
                            .Select(s => new
                            {
                                Name = s.Key.InteractionName,
                                Date = DateTime.Parse($"01.{s.Key.Month}.{requestModel.YearId}").ToString("Y"),
                                Value = (int)s.Sum(s => s.IndicatorValue)
                            })
                            .ToListAsync();

                    response = group.GroupBy(g => g.Name).ToDictionary(x => x.Key, y => y.Select(s => s.Value.ToString()).ToList());

                    var date = group.GroupBy(g => g.Date).Select(s => s.Key).ToList();

                    response.Add("date", date);
                }
                return response;
            }
            catch
            {
                return null;
            }

        }

        public async Task<Dictionary<string, List<string>>?> StatisticsSmevGraphicTypeDay(StatisticsViewRequestModel requestModel)
        {
            try
            {
                var response = new Dictionary<string, List<string>>();
                var date = DateTime.Today.AddDays(-1);
                var indicators = new Dictionary<int, string>
                {
                    { 18, "Отправленные" },
                    { 22, "Полученные" }
                };

                var group = await _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => indicators.Select(s => s.Key).Contains(w.SIndicatorsId) && w.IndicatorDate >= date.AddMonths(-1) &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.SmevId.HasValue || requestModel.SmevId == Guid.Empty || w.SSmevId == requestModel.SmevId) &&
                                (!requestModel.SmevRequestId.HasValue || requestModel.SmevRequestId == -1 || w.SSmevRequestId == requestModel.SmevRequestId)
                         )
                    .GroupBy(g => new { g.IndicatorDate, g.SIndicatorsId })
                    .OrderBy(o => o.Key.IndicatorDate)
                    .Select(s => new
                    {
                        Name = indicators[s.Key.SIndicatorsId],
                        Date = s.Key.IndicatorDate.ToShortDateString(),
                        Value = s.Count()
                    })
                    .ToListAsync();


                response = group.GroupBy(g => g.Name).ToDictionary(x => x.Key, y => y.Select(s => s.Value.ToString()).ToList());

                var dateList = group.GroupBy(g => g.Date).Select(s => s.Key).ToList();

                response.Add("date", dateList);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<Dictionary<string, List<string>>?> StatisticsSmevGraphicTypeYear(StatisticsViewRequestModel requestModel)
        {
            try
            {
                var response = new Dictionary<string, List<string>>();


                var indicators = new Dictionary<int, string>
                {
                    { 18, "Отправленные" },
                    { 22, "Полученные" }
                };

                var group = await _context.DIndicatorsValues
                    .AsNoTracking()
                    .Where(w => indicators.Select(s => s.Key).Contains(w.SIndicatorsId) && w.Year == requestModel.YearId &&
                                (!requestModel.MfcId.HasValue || requestModel.MfcId == Guid.Empty || w.SOfficesId == requestModel.MfcId) &&
                                (!requestModel.EmployeeId.HasValue || requestModel.EmployeeId == Guid.Empty || w.SEmployeesId == requestModel.EmployeeId) &&
                                (!requestModel.SmevId.HasValue || requestModel.SmevId == Guid.Empty || w.SSmevId == requestModel.SmevId) &&
                                (!requestModel.SmevRequestId.HasValue || requestModel.SmevRequestId == -1 || w.SSmevRequestId == requestModel.SmevRequestId)
                         )
                    .GroupBy(g => new { g.Month, g.SIndicatorsId })
                    .OrderBy(o => o.Key.Month)
                    .Select(s => new
                    {
                        Name = indicators[s.Key.SIndicatorsId],
                        Date = DateTime.Parse($"01.{s.Key.Month}.{requestModel.YearId}").ToString("Y"),
                        Value = s.Count()
                    })
                    .ToListAsync();

                response = group.GroupBy(g => g.Name).ToDictionary(x => x.Key, y => y.Select(s => s.Value.ToString()).ToList());

                var date = group.GroupBy(g => g.Date).Select(s => s.Key).ToList();

                response.Add("date", date);

                return response;
            }
            catch
            {
                return null;
            }

        }
    }
}
