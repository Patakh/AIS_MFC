using AisLogistics.API.Models.Request;
using AisLogistics.API.Models.Request.Queue;
using AisLogistics.API.Models.Responce;
using AisLogistics.API.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AisLogistics.API.Service
{
    public class ElectronicQueueServiceClientAPI : IElectronicQueueServiceClientAPI
    {
        private readonly string ServiceUrl;

        public ElectronicQueueServiceClientAPI(IOptions<QueueSettings> queueOptions)
        {
            ServiceUrl = queueOptions.Value.QueueConnection;
        }

        public async Task<QueueInfoResponse?> GetQueueInfo(QueueInfoRequest request)
        {
            HttpClient? client = null;
            try
            {
                client = new HttpClient();
                var response = await client.PostAsJsonAsync(ServiceUrl, new QueueRequest("panel_head_info")
                {
                    Params = new
                    {
                        date = request.Date
                    }
                });

                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<QueueInfoObject>(str);
                    if (model is null or { Error: not null }) throw new InvalidOperationException();
                    return model.Result;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                client?.Dispose();
            }
        }

        public async Task<List<QueueOfficeInfoResponse>?> GetQueueOfficeInfo(QueueOfficeInfoRequest request)
        {
            HttpClient? client = null;
            try
            {
                client = new HttpClient();
                var response = await client.PostAsJsonAsync(ServiceUrl, new QueueRequest("panel_head_info_office")
                {
                    Params = new
                    {
                        office_id = request.OfficeId,
                        date = request.Date
                    }
                });

                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<QueueOfficeInfoObject>(str);
                    if (model is null or { Error: not null }) throw new InvalidOperationException();
                    return model.Result;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                client?.Dispose();
            }
        }

        public async Task<List<OfficeQueueResponse>?> GetOffices()
        {
            HttpClient? client = null;
            try
            {
                client = new HttpClient();
                var response = await client.PostAsJsonAsync(ServiceUrl, new QueueRequest("get_offices"));

                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<OfficeQueueObject>(str);
                    if (model is null or { Error: not null }) throw new InvalidOperationException();
                    return model.Result;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                client?.Dispose();
            }
        }

        public async Task<List<TimePrerecordResponse>?> GetTimesForPrerecord(TimePrerecordRequest request)
        {
            HttpClient? client = null;
            try
            {
                client = new HttpClient();
                var response = await client.PostAsJsonAsync(ServiceUrl, new QueueRequest("get_times_for_prerecord")
                {
                    Params = new
                    {
                        office_id = request.OfficeId,
                        date = request.Date,
                    }
                });

                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<TimePrerecordObject>(str);
                    if (model is null or { Error: not null }) throw new InvalidOperationException();
                    return model.Result;
                }

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                client?.Dispose();
            }
        }

        public async Task<AddPrerecordResponse?> AddPrerecord(AddPrerecordRequest request)
        {
            HttpClient? client = null;
            try
            {
                client = new HttpClient();
                var response = await client.PostAsJsonAsync(ServiceUrl, new QueueRequest("add_prerecord")
                {
                    Params = new
                    {
                        office_id = request.OfficeId,
                        date = request.Date,
                        start_time = request.StartTime,
                        stop_time = request.StopTime,
                        full_name = request.FullName,
                        phone_number = request.PhoneNumber,
                    }
                });

                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<AddPrerecordObject>(str);
                    if (model is null or { Error: not null, Result: null }) throw new InvalidOperationException();
                    return new AddPrerecordResponse { Code = long.Parse(model.Result) };
                }

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                client?.Dispose();
            }
        }
        public async Task<CanselPrerecordResponse?> CanselPrerecord(CanselPrerecordRequest request)
        {
            HttpClient? client = null;
            try
            {
                client = new HttpClient();

                var response = await client.PostAsJsonAsync(ServiceUrl, new QueueRequest("cancel_prerecord")
                {
                    Params = new
                    {
                        office_id = request.OfficeId,
                        date = request.Date,
                        code_prerecord = request.Code,
                    }
                });

                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<CanselPrerecordObject>(str);
                    if (model is null or { Error: not null, Result: null }) throw new InvalidOperationException();
                    return new CanselPrerecordResponse { Succses = bool.Parse(model.Result) };
                }

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                client?.Dispose();
            }
        }

    }
}
