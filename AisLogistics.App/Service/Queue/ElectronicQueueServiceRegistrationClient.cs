using AisLogistics.App.Models.Queue;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace AisLogistics.App.Service.Queue
{
    public class ElectronicQueueServiceRegistrationClient : IElectronicQueueServiceRegistrationClient
    {
        private readonly string ServiceUrl;
        public ElectronicQueueServiceRegistrationClient(IOptions<QueueSettings> queueOptions)
        {
            ServiceUrl = queueOptions.Value.RegistrationConnection;
        }

        public async Task<List<GetDatePreRegistetionResponceData>?> GetDatePreRegistration(int id)
        {
            HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{ServiceUrl}/servers/{id}/prerecord/");

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<List<GetDatePreRegistetionResponceData>>();
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }
        public async Task<string?> AddPreRegistration(int id, PreRegistrationRequestModel model)
        {
            HttpClient client = new();
            try
            {
                var url = $"{ServiceUrl}/servers/{id}/prerecord/";

                var data = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, data);

                if (!response.IsSuccessStatusCode) return null;

                var message = await response.Content.ReadAsStringAsync();

                var modelResponce = JsonConvert.DeserializeObject<AddPreRegistrationResponceModel>(message);

                if (modelResponce== null || string.IsNullOrEmpty(modelResponce.code)) return null;
                else return modelResponce.code;

            }
            catch
            {
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }

        public async Task<bool> AddCacelPreRegistration(int id, PreRegistrationCancelRequestModel model)
        {
            HttpClient client = new();
            try
            {
                var url = $"{ServiceUrl}/servers/{id}/prerecord/";

                HttpRequestMessage httpRequest = new HttpRequestMessage
                {

                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"),
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url)
                };

                var response = await client.SendAsync(httpRequest);

                var message = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode) return false;

                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
