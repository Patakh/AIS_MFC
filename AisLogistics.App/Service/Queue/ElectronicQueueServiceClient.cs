using AisLogistics.App.Models.Queue;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QueueReference;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace AisLogistics.App.Service.Queue
{
    public class ElectronicQueueServiceClient : IElectronicQueueServiceClient
    {
        private readonly string UserName;
        private readonly string AuthCode;
        private readonly string ServiceUrl;
        private WebQueueClient client;

        public ElectronicQueueServiceClient(IOptions<QueueSettings> queueOptions)
        {
            ServiceUrl = queueOptions.Value.QueueConnection;
            UserName = queueOptions.Value.AuthName;
            AuthCode = queueOptions.Value.AuthCode;
            client = CreateClient();
        }

        private static Binding CreateBinding()
        {
            const int ServiceTimeOut = 120;
            return new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                SendTimeout = TimeSpan.FromSeconds(ServiceTimeOut),
                ReceiveTimeout = TimeSpan.FromSeconds(ServiceTimeOut),
                OpenTimeout = TimeSpan.FromSeconds(ServiceTimeOut),
                MaxReceivedMessageSize = 100000000,
                MaxBufferSize = 100000000,
                MaxBufferPoolSize = 100000000,
                ReaderQuotas =
                {
                    MaxArrayLength = 100000000,
                    MaxStringContentLength = 100000000
                }
            };
        }

        private WebQueueClient CreateClient()
        {
            return new WebQueueClient(CreateBinding(), new EndpointAddress(ServiceUrl));
        }

        /// <summary>
        /// Список отложенных абонентов
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<ListAbonDelayResponseClient> ListAbonDelay(ListAbonDelayRequest requestData)
        {
            try
            {
                var queryResult = await client.ListAbonDelayAsync(UserName, AuthCode, requestData.type_data, requestData.ip_operator, requestData.mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return JsonConvert.DeserializeObject<ListAbonDelayResponseClient>(queryResult.@return);
            }
            catch (Exception e)
            {
                return new ListAbonDelayResponseClient
                {
                    ErrorCode = 500,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Список абонентов в очереди
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<ListAbonInQueueResponseClient> ListAbonInQueue(ListAbonInQueueRequest requestData)
        {
            try
            {
                var queryResult = await client.ListAbonInQueueAsync(UserName, AuthCode, requestData.type_data, requestData.mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return JsonConvert.DeserializeObject<ListAbonInQueueResponseClient>(queryResult.@return);
            }
            catch (Exception e)
            {
                return new ListAbonInQueueResponseClient
                {
                    ErrorCode = 500,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Список отложенных абонентов
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<ListAbonRedirectResponseClient> ListAbonRedirect(ListAbonRedirectRequest requestData)
        {
            try
            {
                var queryResult = await client.ListAbonRedirectAsync(UserName, AuthCode, requestData.type_data, requestData.ip_operator, requestData.mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return JsonConvert.DeserializeObject<ListAbonRedirectResponseClient>(queryResult.@return);
            }
            catch (Exception e)
            {
                return new ListAbonRedirectResponseClient
                {
                    ErrorCode = 500,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Список окон с их ID
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<ListWindowResponseClient> ListWindow(ListWindowRequest requestData)
        {
            try
            {
                var queryResult = await client.ListWindowAsync(UserName, AuthCode, requestData.type_data, requestData.mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return JsonConvert.DeserializeObject<ListWindowResponseClient>(queryResult.@return);
            }
            catch (Exception e)
            {
                return new ListWindowResponseClient
                {
                    ErrorCode = 500,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Перенаправление клиента в другое окно
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<RedirectAbonResponse> AbonRedirect(RedirectAbonRequest requestData)
        {
            try
            {
                var queryResult = await client.RedirectAbonAsync(UserName, AuthCode, requestData.type_data, requestData.num, requestData.operator_guid, requestData.mfc, requestData.window_id);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return queryResult;
            }
            catch (Exception e)
            {
                return new RedirectAbonResponse
                {
                    @return = e.Message
                };
            }
        }

        /// <summary>
        /// Отложить абонента
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<DelayAbonResponse> DelayAbon(DelayAbonRequest requestData)
        {
            try
            {
                var queryResult = await client.DelayAbonAsync(UserName, AuthCode, requestData.type_data, requestData.num, requestData.time, requestData.operator_guid, requestData.mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return queryResult;
            }
            catch (Exception e)
            {
                return new DelayAbonResponse
                {
                    @return = e.Message
                };
            }
        }

        /// <summary>
        /// Вызов перенаправленого клиента по номеру или по  порядку
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<NextAbonRedirectResponse> NextAbonRedirect(NextAbonRedirectRequest requestData)
        {
            try
            {
                var queryResult = await client.NextAbonRedirectAsync(UserName, AuthCode, requestData.type_data, requestData.ip_operator, requestData.operator_guid, requestData.num, requestData.mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return queryResult;
            }
            catch (Exception e)
            {
                return new NextAbonRedirectResponse
                {
                    @return = e.Message
                };
            }
        }

        /// <summary>
        /// Номер талона для сотрудника
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<NumAbonOnWindowResponseClient> NumAbonOnWindow(CountAbonRequestClient requestData)
        {
            try
            {
                var queryResult = await client.NumAbonOnWindowAsync(UserName, AuthCode, requestData.Type_data, requestData.Ip_operator, requestData.Mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return JsonConvert.DeserializeObject<NumAbonOnWindowResponseClient>(queryResult.@return);
            }
            catch (Exception e)
            {
                return new NumAbonOnWindowResponseClient
                {
                    ErrorCode = 500,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Количество клииентов
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<CountAbonResponseClient> CountAbon(CountAbonRequestClient requestData)
        {
            try
            {
                var queryResult = await client.CountAbonAsync(UserName, AuthCode, requestData.Type_data, requestData.Ip_operator, requestData.Mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return JsonConvert.DeserializeObject<CountAbonResponseClient>(queryResult.@return);
            }
            catch (Exception e)
            {
                return new CountAbonResponseClient
                {
                    ErrorCode = 500,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Следующий клиент из очереди
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<NextAbonResponse> NextAbon(NextAbonRequest requestData)
        {
            try
            {
                var queryResult = await client.NextAbonAsync(UserName, AuthCode, requestData.type_data, requestData.ip_operator, requestData.operator_guid, requestData.num, requestData.mfc, requestData.end_call);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return queryResult;
            }
            catch (Exception e)
            {
                return new NextAbonResponse
                {
                    @return = e.Message
                };
            }
        }

        /// <summary>
        /// Следующий клиент(вип) из очереди
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<NextAbonResponseClient> NextAbonVIP(NextAbonVIPRequest requestData)
        {
            try
            {
                var queryResult = await client.NextAbonVIPAsync(UserName, AuthCode, requestData.type_data, requestData.ip_operator, requestData.operator_guid, requestData.num, requestData.mfc, requestData.end_call);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return JsonConvert.DeserializeObject<NextAbonResponseClient>(queryResult.@return);
            }
            catch (Exception e)
            {
                return new NextAbonResponseClient
                {
                    ErrorCode = 500,
                    ErrorMessage = e.Message
                };
            }
        }

        /// <summary>
        /// Вызов отложенного абонента
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<NextAbonDelayResponse> NextAbonDelay(NextAbonDelayRequest requestData)
        {
            try
            {
                var queryResult = await client.NextAbonDelayAsync(UserName, AuthCode, requestData.type_data, requestData.ip_operator, requestData.operator_guid, requestData.num, requestData.mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return queryResult;
            }
            catch (Exception e)
            {
                return new NextAbonDelayResponse
                {
                    @return = e.Message
                };
            }
        }

        public async Task<FGIS_MDMResponse> FgisMdm(FGIS_MDMRequest requestData)
        {
            try
            {
                var queryResult = await client.FGIS_MDMAsync(UserName, AuthCode, requestData.type_data, requestData.start_date, requestData.stop_date, requestData.mfc);
                if (queryResult is null || string.IsNullOrEmpty(queryResult.@return)) throw new InvalidOperationException();
                return queryResult;
            }
            catch (Exception ex)
            {
                return new FGIS_MDMResponse
                {
                    @return = ex.Message
                };
            }
        }



    }
}
