using AisLogistics.App.Models.DTO.Reporpts;
using AisLogistics.App.Models.Enums;
using AisLogistics.App.Settings;
using AisLogistics.App.ViewModels.Reports;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using FastReport;
using FastReport.Export.OoXML;
using FastReport.Export.Pdf;
using FastReport.Utils;
using FastReport.Web;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace AisLogistics.App.Service
{
    public class Reports : IReports
    {
        private readonly AisLogisticsContext _context;
        private readonly IReferencesService _referencesService;
        private readonly SpsSettings _spsSettings;
        private readonly IFilterManager _filterManager;
        public Reports(AisLogisticsContext context, IReferencesService referenceService,
            IOptions<SpsSettings> spsOptions, IFilterManager filterManager)
        {
            _context = context;
            _referencesService = referenceService;
            _spsSettings = spsOptions.Value;
            _filterManager = filterManager;
        }

        public async Task<List<ReportsDto>> GetReportsAsync()
        {
            return await _context.SReports
                .AsNoTracking()
                .Where(w => Debugger.IsAttached || w.IsActive)
                .Select(s => new ReportsDto
                {
                    Id = s.Id,
                    Name = s.ReportName,
                    SReportGroupId = s.SReportGroupId,
                    SReportGroupName = s.SReportGroups.GroupName,
                    Order = s.ReportOrder,
                    Path = s.ReportPath
                })
                .OrderBy(o => o.Order)
                .ToListAsync();
        }

        public async Task<ReportsDto?> GetReportAsync(Guid Id)
        {
            return await _context.SReports
                .Where(w => w.Id == Id)
                .Select(s => new ReportsDto
                {
                    Id = s.Id,
                    Name = s.ReportName,
                    SReportGroupId = s.SReportGroupId,
                    SReportGroupName = s.SReportGroups.GroupName,
                    Order = s.ReportOrder,
                    Path = s.ReportPath,
                    Function = s.ReportFunction,
                    File = s.ReportFile
                }).FirstOrDefaultAsync();
        }

        public async Task<SForm?> GetReportsFileAsync(int id)
        {
            return await _context.SForms.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<byte[]> GetReportsFileAsync(Guid id)
        {
            return await _context.SReports.Where(w => w.Id == id).Select(s => s.ReportFile).FirstAsync();
        }

        public async Task<IList?> GetDataReport(ReportViewRequestModel requestModel, string connection)
        {
            IList? data = null;
            try
            {
                switch (requestModel.Method)
                {
                    case ReportsType.Function:
                        data = await GetDataFunctionReport(requestModel, connection, Type.GetType(requestModel.ModelType));
                        break;
                    case ReportsType.Sps:
                        data = await GetDataSpsReport(requestModel, connection, Type.GetType(requestModel.ModelType));
                        break;
                }
                return data;
            }
            catch (Exception e)
            {
                return data;
            }
        }


        private async Task<IList?> GetDataSpsReport(ReportViewRequestModel requestModel, string connection, Type type)
        {
            HttpClient client = new();
            try
            {
                var url = $"{_spsSettings.SpsConnection}report/services-counts";

                var query = new Dictionary<string, string>()
                {
                    ["date_from"] = DateTime.Parse(requestModel.DateStart).ToString("yyyy-MM-dd"),
                    ["date_to"] = DateTime.Parse(requestModel.DateStop).ToString("yyyy-MM-dd"),
                };

                if (requestModel.SpsId.HasValue && requestModel.SpsId != 0)
                {
                    query.Add("office_id", requestModel.SpsId.ToString());
                }

                var uri = QueryHelpers.AddQueryString(Debugger.IsAttached ? url : connection, query);

                var response = await client.GetAsync(uri);

                if (!response.IsSuccessStatusCode) return null;

                var data = (IList)await response.Content.ReadFromJsonAsync(typeof(List<>).MakeGenericType(type));
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }

        public async Task<byte[]?> ReportDataPrepare(byte[] reportFile, IList data, ReportViewRequestModel requestModel, BlankActionType type, string connection, string employeeName)
        {
            try
            {
                RegisteredObjects.AddConnection(typeof(FastReport.Data.PostgresDataConnection));

                var rep = new WebReport();

                rep.Report.Load(new MemoryStream(reportFile));

                await GetParametrs(rep, requestModel, employeeName, connection);

                rep.Report.RegisterData(data, "Reports");
                rep.Report.GetDataSource("Reports").Enabled = true;
                ((DataBand)rep.Report.FindObject("Data1")).DataSource = rep.Report.GetDataSource("Reports");

                var isPrepare = rep.Report.Prepare();

                if (!isPrepare) return null;

                var strm = new MemoryStream();

                switch (type)
                {
                    case BlankActionType.Pdf:
                        var export = new PDFExport();
                        rep.Report.Export(export, strm);
                        export.Dispose();
                        break;
                    case BlankActionType.Exel:
                        var Excelexport = new Excel2007Export();
                        rep.Report.Export(Excelexport, strm);
                        Excelexport.Dispose();
                        break;
                }

                return strm.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task GetParametrs(WebReport rep, ReportViewRequestModel requestModel, string? employeeFio, string connection)
        {
            if (!string.IsNullOrEmpty(employeeFio))
            {
                rep.Report.SetParameterValue("EmployeeFio", employeeFio);
            }
            if (!string.IsNullOrEmpty(requestModel.DateStart))
            {
                rep.Report.SetParameterValue("DateStart", DateTime.Parse(requestModel.DateStart));
            }
            if (!string.IsNullOrEmpty(requestModel.DateStop))
            {
                rep.Report.SetParameterValue("DateStop", DateTime.Parse(requestModel.DateStop));
            }
            if (requestModel.MfcId.HasValue)
            {
                if (requestModel.MfcId == Guid.Empty)
                {
                    rep.Report.SetParameterValue("Office", "Все");
                }
                else
                {
                    var Name = await _referencesService.GetOfficeDtoAsync(requestModel.MfcId.Value);
                    rep.Report.SetParameterValue("Office", Name?.OfficeName ?? string.Empty);
                }
            }
            if (requestModel.SpsId.HasValue)
            {
                if (requestModel.SpsId == 0)
                {
                    rep.Report.SetParameterValue("Office", "Все");
                }
                else
                {
                    var Name = await _referencesService.GetSpsOfficeDtoAsync(requestModel.SpsId.Value);
                    rep.Report.SetParameterValue("Office", Name?.OfficeName ?? string.Empty);
                }
            }
            if (requestModel.MfcIdList != null)
            {
                var data = await _filterManager.GetOfficesIdForReceptionCustomer(requestModel.MfcIdList, false, true);
                string Name = string.Join(", ", data.OfficesName);

                rep.Report.SetParameterValue("Office", Name);
            }
            if (requestModel.EmployeeId.HasValue)
            {
                var Name = await _referencesService.GetEmployeeDtoAsync(requestModel.EmployeeId.Value);
                rep.Report.SetParameterValue("Employee", Name?.EmployeeName ?? string.Empty);
            }
            if (requestModel.EmployeeIdList != null)
            {
                string Name = string.Empty;
                if (requestModel.EmployeeIdList.Any(a => a == Guid.Empty))
                {
                    Name = "Все";
                }
                else
                {
                    var List = await _referencesService.GetEmployeesDtoAsync(requestModel.EmployeeIdList);
                    Name = string.Join(", ", List.Select(s => s.EmployeeName).ToList());

                }
                rep.Report.SetParameterValue("Employee", Name);
            }

            if (requestModel.ProviderId.HasValue)
            {
                var Name = await _referencesService.GetOfficeDtoAsync(requestModel.ProviderId.Value);
                rep.Report.SetParameterValue("Provider", Name?.OfficeName ?? string.Empty);
            }
            if (requestModel.ProviderIdList != null)
            {
                string Name = string.Empty;
                if (requestModel.ProviderIdList.Any(a => a == Guid.Empty))
                {
                    Name = "Все";
                }
                else
                {
                    var List = await _referencesService.GetOfficesProvidersAll(requestModel.ProviderIdList);
                    Name = string.Join(", ", List.Select(s => s.OfficeName).ToList());

                }
                rep.Report.SetParameterValue("Provider", Name);
            }

            if (requestModel.ServiceId.HasValue)
            {
                var Name = await _referencesService.GetServiceDtoAsync(requestModel.ServiceId.Value);
                rep.Report.SetParameterValue("Services", Name?.ServiceName ?? string.Empty);
            }
            if (requestModel.ServiceIdList != null)
            {
                string Name = string.Empty;
                if (requestModel.ServiceIdList.Any(a => a == Guid.Empty))
                {
                    Name = "Все";
                }
                else
                {
                    var List = await _referencesService.GetServicesAll(requestModel.ServiceIdList);
                    Name = string.Join(", ", List.Select(s => s.ServiceName).ToList());
                }
                rep.Report.SetParameterValue("Services", Name);
            }
            if (requestModel.SmevId.HasValue)
            {
                var Name = await _referencesService.GetSmevServiceModelDtoAsync(requestModel.SmevId.Value);
                rep.Report.SetParameterValue("SmevServices", Name?.SmevName ?? string.Empty);
            }
            if (requestModel.SmevIdList != null)
            {
                string Name = string.Empty;
                if (requestModel.SmevIdList.Any(a => a == Guid.Empty))
                {
                    Name = "Все";
                }
                else
                {
                    var List = await _referencesService.GetAllSmevServicesAsync(requestModel.SmevIdList);
                    Name = string.Join(", ", List.Select(s => s.SmevName).ToList());
                }
                rep.Report.SetParameterValue("SmevServices", Name);
            }
            if (requestModel.SmevRequestId.HasValue)
            {
                var Name = await _referencesService.GetSmevRequestModelDtoAsync(requestModel.SmevRequestId.Value);
                rep.Report.SetParameterValue("SmevRequest", Name?.RequestName ?? string.Empty);
            }
            if (requestModel.SmevRequestIdList != null)
            {
                string Name = string.Empty;
                if (requestModel.SmevRequestIdList.Any(a => a == -1))
                {
                    Name = "Все";
                }
                else
                {
                    var List = await _referencesService.GetAllSmevRequestAsync(requestModel.SmevRequestIdList);
                    Name = string.Join(", ", List.Select(s => s.RequestName).ToList());
                }
                rep.Report.SetParameterValue("SmevRequest", Name);
            }
            if (rep.Report.Dictionary.Connections.Count != 0)
                rep.Report.Dictionary.Connections[0].ConnectionString = connection;
        }

        private async Task<IList?> GetDataFunctionReport(ReportViewRequestModel requestModel, string connection, Type type)
        {
            DbCommand? cmd = null;
            DbDataReader? reader = null;
            try
            {
                cmd = _context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = connection;

                int dateDelta = (DateTime.Parse(requestModel.DateStop).Date - DateTime.Parse(requestModel.DateStart).Date).Days;

                cmd.CommandTimeout = 3600;

                var parameters = await GetParametrs(cmd, requestModel);
                cmd.Parameters.AddRange(parameters);
                await cmd.Connection.OpenAsync();
                reader = await cmd.ExecuteReaderAsync();

                var response = await GetListAsync(reader, type);

                if (response is null) throw new InvalidOperationException(nameof(response));

                return response;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    await reader.CloseAsync();
                    await reader.DisposeAsync();
                }
                if (cmd != null)
                {
                    await cmd.Connection.CloseAsync();
                }
            }
        }

        private async Task<Array> GetParametrs(DbCommand dbcommand, ReportViewRequestModel requestModel)
        {
            List<DbParameter> response = new List<DbParameter>();

            if (!string.IsNullOrEmpty(requestModel.DateStart))
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_date_start";
                parametr.Value = DateTime.Parse(requestModel.DateStart);
                parametr.DbType = DbType.Date;
                response.Add(parametr);
            }
            if (!string.IsNullOrEmpty(requestModel.DateStop))
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_date_stop";
                parametr.Value = DateTime.Parse(requestModel.DateStop);
                parametr.DbType = DbType.Date;
                response.Add(parametr);
            }
            if (requestModel.MfcId.HasValue)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_offices_id";
                parametr.Value = requestModel.MfcId;
                parametr.DbType = DbType.Guid;
                response.Add(parametr);
            }
            if (requestModel.MfcIdList != null)
            {
                var data = await _filterManager.GetOfficesIdForReceptionCustomer(requestModel.MfcIdList, false, false);
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_offices_id";
                parametr.Value = data.OfficesId.Count==0 ? DBNull.Value : data.OfficesId.ToArray();
                response.Add(parametr);
            }
            if (requestModel.EmployeeId.HasValue)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_employees_id";
                parametr.Value = requestModel.EmployeeId;
                parametr.DbType = DbType.Guid;
                response.Add(parametr);
            }
            if (requestModel.EmployeeIdList != null)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_employees_id";
                parametr.Value = requestModel.EmployeeIdList.Any(a => a == Guid.Empty) ? DBNull.Value : requestModel.EmployeeIdList.ToArray();
                response.Add(parametr);
            }
            if (requestModel.ProviderId.HasValue)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_offices_id_provider";
                parametr.Value = requestModel.ProviderId;
                parametr.DbType = DbType.Guid;
                response.Add(parametr);
            }
            if (requestModel.ProviderIdList != null)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_offices_id_provider";
                parametr.Value = requestModel.ProviderIdList.Any(a => a == Guid.Empty) ? DBNull.Value : requestModel.ProviderIdList.ToArray();
                response.Add(parametr);
            }
            if (requestModel.ServiceId.HasValue)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_services_id";
                parametr.Value = requestModel.ServiceId;
                parametr.DbType = DbType.Guid;
                response.Add(parametr);
            }
            if (requestModel.ServiceIdList != null)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_services_id";
                parametr.Value = requestModel.ServiceIdList.Any(a => a == Guid.Empty) ? DBNull.Value : requestModel.ServiceIdList.ToArray();
                response.Add(parametr);
            }
            if (requestModel.SmevId.HasValue)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_smev_id";
                parametr.Value = requestModel.SmevId;
                parametr.DbType = DbType.Guid;
                response.Add(parametr);
            }
            if (requestModel.SmevIdList != null)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_smev_id";
                parametr.Value = requestModel.SmevIdList.Any(a => a == Guid.Empty) ? DBNull.Value : requestModel.SmevIdList.ToArray();
                response.Add(parametr);
            }
            if (requestModel.SmevRequestId.HasValue)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_smev_request_id";
                parametr.Value = requestModel.SmevRequestId;
                parametr.DbType = DbType.Int32;
                response.Add(parametr);
            }
            if (requestModel.SmevRequestIdList != null)
            {
                var parametr = dbcommand.CreateParameter();
                parametr.ParameterName = "in_s_smev_request_id";
                parametr.Value = requestModel.SmevRequestIdList.Any(a => a == -1) ? DBNull.Value : requestModel.SmevRequestIdList.ToArray();
                response.Add(parametr);
            }

            return response.ToArray();
        }

        private static async Task<IList?> GetListAsync(DbDataReader reader, Type type)
        {
            try
            {
                var list = new List<object>();
                while (await reader.ReadAsync())
                {
                    //var type = typeof(T);
                    var obj = Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties())
                    {
                        var value = reader[prop.Name].ToString();
                        if (string.IsNullOrEmpty(value))
                        {
                            prop.SetValue(obj, null);
                        }
                        else
                        {
                            prop.SetValue(obj, reader[prop.Name]);
                        }

                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
