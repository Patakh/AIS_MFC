using System.Text.RegularExpressions;
using AisLogistics.DataLayer.Concrete;
using Cronos;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace AisLogistics.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceScopeFactory scopeFactory, ILogger<Worker> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        //TODO что то придумать с этим 
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    // Schedule the job every minute.
                    //await WaitForNextSchedule("0 0 * * *");
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(90000, stoppingToken);
                }
                //using var scope = _scopeFactory.CreateScope();
                //var dbContext = scope.ServiceProvider.GetRequiredService<AisLogisticsContext>();
                //await dbContext.CallMoveToArchiveAsync(stoppingToken);
                //await dbContext.CallCalcIndicator1Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator2Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator3Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator4Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator5Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator6Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator7Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator8Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator9Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator10Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator11Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator12Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator13Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator14Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator15Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator16Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator17Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator18Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator19Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator20Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator21Async(DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator22Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator23Async(DateTime.Today, DateTime.Today, stoppingToken);
                //await dbContext.CallCalcIndicator24Async(DateTime.Today, DateTime.Today, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private async Task WaitForNextSchedule(string cronExpression)
        {
            var parsedExp = CronExpression.Parse(cronExpression);
            var currentUtcTime = DateTimeOffset.UtcNow.UtcDateTime;
            var occurenceTime = parsedExp.GetNextOccurrence(currentUtcTime);

            var delay = occurenceTime.GetValueOrDefault() - currentUtcTime;
            _logger.LogInformation("The run is delayed for {delay}. Current time: {time}", delay, DateTimeOffset.Now);

            await Task.Delay(delay);
        }
    }
}