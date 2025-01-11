using AisLogistics.App.Models.Queue;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AisLogistics.App.Service.Queue
{
    public class ElectronicQueueServiceApiClient : IElectronicQueueServiceApiClient
    {
        private readonly string ServiceUrl;

        public ElectronicQueueServiceApiClient(IOptions<QueueSettings> queueOptions)
        {
            ServiceUrl = queueOptions.Value.QueueApiConnection;
        }


        public async Task<GetDeferredTicketsResponseData?> GetDeferredTickets(GetDeferredTicketsRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "get_deferred_tickets",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            window_ip = requestData.WindowIp
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetDeferredTicketsResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<GetTicketsInQueueResponseData?> GetTicketsInQueue(GetTicketsInQueueRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "get_tickets_in_queue",
                        Params = new
                        {
                            office_id = requestData.OfficeId
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetTicketsInQueueResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<GetTransferedTicketsResponseData?> GetTransferedTickets(GetTransferedTicketsRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "get_transfered_tickets",
                        Params = new
                        {
                            window_ip = requestData.WindowIp,
                            office_id = requestData.OfficeId,
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetTransferedTicketsResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<GetWindowsResponseData?> GetWindows(GetWindowsRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "get_windows",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetWindowsResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<TransferTicketResponseData?> TransferTicket(TransferTicketRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "transfer_ticket",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            from_window_ip = requestData.FromWindowIp,
                            to_window_ip = requestData.ToWindowIp,
                            ticket_id = requestData.TicketId,
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TransferTicketResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<PostponeTicketResponseData?> PostponeTicket(PostponeTicketRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "postpone_ticket",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            ticket_id = requestData.TicketId,
                            window_ip = requestData.WindowIp,
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<PostponeTicketResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<CallTicketResponseData?> CallTicket(CallTicketRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "call_ticket",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            ticket_id = requestData.TicketId,
                            window_ip = requestData.WindowIp,
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<CallTicketResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<WindowTicketsInQueueStatResponseData?> WindowTicketsInQueueStat(WindowTicketsInQueueStatRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "window_tickets_in_queue_stat",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            window_ip = requestData.WindowIp,
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<WindowTicketsInQueueStatResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<CallNextTicketInQueueResponseData?> CallNextTicketInQueue(CallNextTicketInQueueRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "call_next_ticket_in_queue",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            window_ip = requestData.WindowIp,
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<CallNextTicketInQueueResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<CompleteTicketResponseData?> CompleteTicket(CompleteTicketRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "complete_ticket",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            ticket_id = requestData.TicketId,
                            window_ip = requestData.WindowIp
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<CompleteTicketResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<ClientNotComeResponseData?> ClientNotCome(ClientNotComeRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "client_not_come",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            ticket_id = requestData.TicketId,
                            window_ip = requestData.WindowIp
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ClientNotComeResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<TakeTicketToWorkResponseData?> TakeTicketToWork(TakeTicketToWorkRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "take_ticket_to_work",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            ticket_id = requestData.TicketId,
                            window_ip = requestData.WindowIp
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TakeTicketToWorkResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<GetOfficesResponseData?> GetOffices()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "get_offices",
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetOfficesResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<GetTimesForPrerecordResponseData?> GetTimesForPrerecord(GetTimesForPrerecordRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "get_times_for_prerecord",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            date = requestData.Date.ToString("yyyy-MM-dd")
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetTimesForPrerecordResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<AddPrerecordResponseData?> AddPrerecord(AddPrerecordRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "add_prerecord",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            date = requestData.Date.ToString("yyyy-MM-dd"),
                            start_time = requestData.StartTime.ToString("HH:mm"),
                            stop_time = requestData.StopTime.ToString("HH:mm"),
                            full_name = requestData.FullName,
                            phone_number = requestData.PhoneNumber
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<AddPrerecordResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<CancelPrerecordResponseData?> CancelPrerecord(CancelPrerecordRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "cancel_prerecord",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            code_prerecord = requestData.CodePrerecord,
                            date = requestData.Date.ToString("yyyy-MM-dd"),
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<CancelPrerecordResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<GetWindowStateResponseData?> GetWindowState(GetWindowStateRequestData requestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(ServiceUrl, new RequestData
                    {
                        Method = "get_window_state",
                        Params = new
                        {
                            office_id = requestData.OfficeId,
                            window_ip = requestData.WindowIp
                        }
                    });

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetWindowStateResponseData>(jsonResponse);
                    }

                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
