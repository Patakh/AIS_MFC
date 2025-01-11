using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using AisLogistics.DataLayer.Entities.FunctionsModel;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace AisLogistics.DataLayer.Concrete
{
    public partial class AisLogisticsContext
    {
        public virtual DbSet<BlanksMarks> BlanksMarks { get; set; }
        public virtual DbSet<GenerateCaseNumber> GenerateCaseNumber { get; set; }
        public virtual DbSet<ServiceInfoForPanelHead> ServiceInfoForPanelHead { get; set; }
        public virtual DbSet<ServiceOfficeInfoForPanelHead> ServiceOfficeInfoForPanelHead { get; set; }
        public virtual DbSet<ServiceStateTaskInfoForPanelHead> ServiceStateTaskInfoForPanelHead { get; set; }
        public virtual DbSet<ServiceStaticDataMfcInfoForPanelHead> ServiceStaticDataMfcInfoForPanelHead { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlanksMarks>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<GenerateCaseNumber>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<ServiceInfoForPanelHead>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<ServiceOfficeInfoForPanelHead>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<ServiceStateTaskInfoForPanelHead>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<ServiceStaticDataMfcInfoForPanelHead>(entity => { entity.HasNoKey(); });
        }

        public async Task<List<ServiceInfoForPanelHead>> GetServiceInfoForPanelHead()
        {
            try
            {
                return await ServiceInfoForPanelHead.FromSqlRaw("SELECT * from reports.panel_head_service()").AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ServiceOfficeInfoForPanelHead>> GetServiceOfficeInfoForPanelHead(int periodId)
        {
            try
            {
                return await ServiceOfficeInfoForPanelHead.FromSqlInterpolated($"SELECT * from reports.panel_head_service_office({periodId})").AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ServiceStateTaskInfoForPanelHead>> GetServiceStateTaskInfoForPanelHead()
        {
            try
            {
                return await ServiceStateTaskInfoForPanelHead.FromSqlRaw("SELECT * from reports.panel_head_service_state_task()").AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ServiceStaticDataMfcInfoForPanelHead>> GetServiceStaticDataMfcInfoForPanelHead()
        {
            try
            {
                return await ServiceStaticDataMfcInfoForPanelHead.FromSqlRaw("SELECT * from reports.panel_head_info()").AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task CallMoveToArchiveAsync(CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_4 (@p0)", stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator1Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_1 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator2Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_2 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator3Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_3 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator4Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_4 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator5Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_5 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator6Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_6 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator7Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_7 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator8Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_8 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator9Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_9 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator10Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_10 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator11Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_11 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator12Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_12 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator13Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_13 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator14Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_14 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator15Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_15 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator16Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_16 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator17Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_17 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator18Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_18 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator19Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_19 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator20Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_20 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator21Async(DateTime value, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_21 (@p0)",
                    parameters: new object[]
                        { new NpgsqlParameter { Value = value, NpgsqlDbType = NpgsqlDbType.Date } }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator22Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_22 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator23Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_23 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public async Task CallCalcIndicator24Async(DateTime start, DateTime end, CancellationToken stoppingToken)
        {
            try
            {
                await this.Database.ExecuteSqlRawAsync("CALL reports.calc_indicator_24 (@p0, @p1)",
                    parameters: new object[]
                    {
                        new NpgsqlParameter { Value = start, NpgsqlDbType = NpgsqlDbType.Date },
                        new NpgsqlParameter { Value = end, NpgsqlDbType = NpgsqlDbType.Date }
                    }, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
