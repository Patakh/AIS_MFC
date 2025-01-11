using AisLogistics.App.Hubs;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Alert;
using AisLogistics.App.Models.Queue;
using AisLogistics.App.Service;
using AisLogistics.App.Service.Queue;
using AisLogistics.App.ViewModels.ModelBuilder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using QueueReference;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using NUglify.Helpers;
using static System.Int32;
using log4net;

namespace AisLogistics.App.Controllers.Queue
{
    public class QueueController : AbstractController
    {
        private readonly IReferencesService _referencesService;
        private readonly IElectronicQueueServiceClient _queue;
        private readonly IElectronicQueueServiceRegistrationClient _registration;
        private readonly ILogger<QueueController> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IElectronicQueueServiceApiClient _queueApi;
        //private int debugMfcId = 11; // турочак
        //private string debugIp = "10.40.11.7"; //

        private int debugMfcId = 17; // ГАУ
        private string debugIp = "192.168.35.87"; //

        //private int debugMfcId = 12; // усть-кокса
        //private string debugIp = "10.40.8.2"; //

        //private int debugMfcId = 9; // улаган
        //private string debugIp = "10.40.9.11"; //

        public QueueController(IElectronicQueueServiceClient queue, IElectronicQueueServiceRegistrationClient registration, IReferencesService referencesService,
            IEmployeeManager employeeManager, ILogger<QueueController> logger, IHubContext<NotificationHub> hubContext, IElectronicQueueServiceApiClient queueApi) : base(employeeManager)
        {
            _queue = queue;
            _registration = registration;
            _referencesService = referencesService;
            _logger = logger;
            _hubContext = hubContext;
            _queueApi = queueApi;
        }

        /// <summary>
        /// Перенаправление клиента в другое окно
        /// </summary>
        /// <param name="window_id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonAbonRedirect(string windowIp, string num)
        {
            //var employeeId = await _employeeManager.GetIdAsync();

            //var model = await _queue.AbonRedirect(new RedirectAbonRequest
            //{
            //    num = num,
            //    window_id = windowId,
            //    type_data = "json",
            //    mfc = Debugger.IsAttached ? debugMfc : (int)await _employeeManager. GetOfficeQueueIdAsync(),
            //    operator_guid = employeeId.HasValue ? employeeId.Value.ToString() : string.Empty,
            //});

            var model = await _queueApi.TransferTicket(new TransferTicketRequestData
            {
                OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync(),
                TicketId = Parse(num),
                FromWindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                ToWindowIp = windowIp,
            });
            return Json(model);
            //if (model?.Result ?? false) ShowSuccess("Талон переадресован");
            //else ShowError(MessageDescription.Error);
        }

        /// <summary>
        /// Отложить абонента
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonDelayAbon(string num)
        {
            var employeeIp = await _employeeManager.GetIp();
            //var model = await _queue.DelayAbon(new DelayAbonRequest
            //{
            //    num = num,
            //    type_data = "json",
            //    time = DateTime.Now.AddMinutes(15).ToShortTimeString(),
            //    mfc = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
            //    operator_guid = employeeId.HasValue ? employeeId.Value.ToString() : string.Empty,
            //});

            var model = await _queueApi.PostponeTicket(new PostponeTicketRequestData
            {
                OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync(),
                TicketId = Parse(num),
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp()
            });

            return Json(model);
        }

        /// <summary>
        /// Список окон с их ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> jsonListWindow()
        {
            //var model = await _queue.ListWindow(new ListWindowRequest
            //{
            //    type_data = "json",
            //    mfc = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
            //});

            var model = await _queueApi.GetWindows(new GetWindowsRequestData
            {
                OfficeId = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync()
            });

            return Json(model);
        }

        /// <summary>
        /// Список отложенных абонентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> jsonListAbonRedirect()
        {
            //var model = await _queue.ListAbonRedirect(new ListAbonRedirectRequest
            //{
            //    type_data = "json",
            //    ip_operator = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
            //    mfc = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
            //});

            var model = await _queueApi.GetTransferedTickets(new GetTransferedTicketsRequestData
            {
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync()
            });

            return Json(model);
        }

        /// <summary>
        /// Список абонентов в очереди
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> jsonListAbonInQueue()
        {
            var model = await _queueApi.GetTicketsInQueue(new GetTicketsInQueueRequestData
            {
                OfficeId = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync()
            });

            return Json(model);
        }

        /// <summary>
        /// Список отложенных абонентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> jsonListAbonDelay()
        {
            var model = await _queueApi.GetDeferredTickets(new GetDeferredTicketsRequestData
            {
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync()
            });

            return Json(model);
        }

        /// <summary>
        /// Номер окна и текущий талон
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult?> jsonGetWindowInfo()
         {
            try
            {
                string windowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp();

                var windows = await _queueApi.GetWindows(new GetWindowsRequestData
                {
                    OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync()
                });

                var currentTicket = await _queueApi.GetWindowState(new GetWindowStateRequestData
                {
                    WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                    OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync()
                });

                var model = windows is null
                    ? null
                    : new
                    {
                        error = windows.Error,
                        window = windows.Result?.FirstOrDefault(i => i.WindowIp == windowIp),
                        ticket = currentTicket?.Result
                    };

                return Json(model);
            }
            catch
            {
                ShowError("Ошибка получения данных Окна ЭО");
                return null;
            }
        }

        /// <summary>
        /// Количество клииентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> jsonCountAbon()
        {
            var model = await _queueApi.WindowTicketsInQueueStat(new WindowTicketsInQueueStatRequestData
            {
                OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync(),
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
            });

            return Json(model);
        }

        /// <summary>
        /// Следующий клиент из очереди
        /// </summary>
        /// <param name="windowIp"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonNextAbon()
        {
            var model = await _queueApi.CallNextTicketInQueue(new CallNextTicketInQueueRequestData
            {
                OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync(),
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp()
            });

            return Json(model);
        }

        /// <summary>
        /// Вызов талона
        /// </summary>
        /// <param name="ticketId">Номер талона</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonCallAbon(int ticketId)
        {
            var model = await _queueApi.CallTicket(new CallTicketRequestData
            {
                OfficeId = Debugger.IsAttached ? debugMfcId : await _employeeManager.GetOfficeQueueIdAsync(),
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                TicketId = ticketId
            });

            return Json(model);
        }

        /// <summary>
        /// Вызов перенаправленого клиента по номеру или по  порядку
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonNextAbonRedirect(string num)
        {
            var employeeId = await _employeeManager.GetIdAsync();
            var model = await _queue.NextAbonRedirect(new NextAbonRedirectRequest
            {
                num = num,
                type_data = "json",
                ip_operator = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                mfc = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
                operator_guid = employeeId.HasValue ? employeeId.Value.ToString() : string.Empty
            });
            return Json(model);
        }

        /// <summary>
        /// Вызов отложенного абонента
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonNextAbonDelay(string Num)
        {
            var employeeId = await _employeeManager.GetIdAsync();
            var model = await _queue.NextAbonDelay(new NextAbonDelayRequest
            {
                type_data = "json",
                ip_operator = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                mfc = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
                num = Num,
                operator_guid = employeeId.HasValue ? employeeId.Value.ToString() : string.Empty
            });
            return Json(model);
        }

        /// <summary>
        /// Взять в работу талон
        /// </summary>
        /// <param name="ticketId">Номер талона</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonClientNotCome(int ticketId)
        {
            var model = await _queueApi.ClientNotCome(new ClientNotComeRequestData
            {
                OfficeId = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                TicketId = ticketId
            });
            return Json(model);
        }

        /// <summary>
        /// Не явился
        /// </summary>
        /// <param name="ticketId">Номер талона</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonTakeTicketToWork(int ticketId)
        {
            var model = await _queueApi.TakeTicketToWork(new TakeTicketToWorkRequestData
            {
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                OfficeId = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
                TicketId = ticketId
            });
            return Json(model);
        }

        /// <summary>
        /// Завершить талон
        /// </summary>
        /// <param name="ticketId">Номер талона</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonCompleteTicket(int ticketId)
        {
            var model = await _queueApi.CompleteTicket(new CompleteTicketRequestData
            {
                WindowIp = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                OfficeId = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
                TicketId = ticketId
            });
            return Json(model);
        }

        /// <summary>
        /// Вызов заявителя пришедшего за справкой
        /// </summary>
        /// <param name="EndCall"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonNextAbonVIP(int EndCall, string Num)
        {
            var employeeId = await _employeeManager.GetIdAsync();
            var model = await _queue.NextAbonVIP(new NextAbonVIPRequest
            {
                type_data = "json",
                ip_operator = Debugger.IsAttached ? debugIp : await _employeeManager.GetIp(),
                mfc = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
                num = Num,
                operator_guid = employeeId.HasValue ? employeeId.Value.ToString() : string.Empty,
                end_call = EndCall
            });
            return Json(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start_date"></param>
        /// <param name="stop_date"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> jsonFgisMdm(string startDate, string stopDate)
        {
            var model = await _queue.FgisMdm(new FGIS_MDMRequest
            {
                type_data = "json",
                mfc = Debugger.IsAttached ? debugMfcId : (int)await _employeeManager.GetOfficeQueueIdAsync(),
                start_date = startDate,
                stop_date = stopDate,
            });
            return Json(model);
        }

        public async Task<IActionResult?> AddPreRegistrationModal()
        {
            try
            {
                var mfc = _queueApi.GetOffices().Result.Result;
                int indexMfc = mfc[0].Pk;

                List<PreRegistratonList> date = new List<PreRegistratonList>();
                List<PreRegistratonList> startTime = new List<PreRegistratonList>();
                List<PreRegistratonList> stopTime = new List<PreRegistratonList>();

                var queueId = Debugger.IsAttached ? 1 : (int)await _employeeManager.GetOfficeQueueIdAsync();

                if (mfc is null) throw new ArgumentNullException();

                var times = await _queueApi.GetTimesForPrerecord(new GetTimesForPrerecordRequestData
                {
                    OfficeId = indexMfc,
                    Date = DateTime.Today,
                });

                int indexDate = 0;
                if (times.Result?.Any() ?? false)
                {
                    times.Result.ForEach(t =>
                    {
                        if (!date.Any() || date.Last().value != t.Date.ToString("yyyy-MM-dd"))
                        {
                            date.Add(new PreRegistratonList { idx = indexDate, key = $"{t.Date.ToShortDateString()} {t.DayName}", value = t.Date.ToString("yyyy-MM-dd") });
                            indexDate++;
                        }

                        startTime.Add(new PreRegistratonList
                        {
                            idx = date.Last().idx,
                            value = t.StartTime.ToString("HH:mm"),
                            key = t.StartTime.ToString("HH:mm")
                        });
                        stopTime.Add(new PreRegistratonList
                        {
                            idx = date.Last().idx,
                            value = t.StopTime.ToString("HH:mm"),
                            key = t.StopTime.ToString("HH:mm")
                        });
                    });
                }

                var model = new GetDatePreRegistrationModelDto
                {
                    MFC = new SelectList(mfc, "Pk", "OfficeName", queueId).ToList(),
                    Date = date,
                    StartTime = startTime.OrderBy(t => t.idx).ThenBy(t => t.value).ToList(),
                    StopTime = stopTime.OrderBy(t => t.idx).ThenBy(t => t.value).ToList(),
                };

                var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalTitle("Предварительная запись")
                .AddModalViewPath("../Shared/Components/QueuePartial/_ModalPreRegistrationsAdd")
                .AddModel(model);

                return ModalLayoutView(modelBuilder);
            }
            catch (Exception ex)
            {
                ShowError(MessageDescription.Error);
                return null;
            }
        }

        public async Task<ActionResult> GetTimesForPrerecord(int officeId)
        {
            try
            {
                List<PreRegistratonList> date = new List<PreRegistratonList>();
                List<PreRegistratonList> startTime = new List<PreRegistratonList>();
                List<PreRegistratonList> stopTime = new List<PreRegistratonList>();

                var times = await _queueApi.GetTimesForPrerecord(new GetTimesForPrerecordRequestData
                {
                    OfficeId = officeId,
                    Date = DateTime.Today
                });

                int indexDate = 0;
                if (times.Result?.Any() ?? false)
                {
                    times.Result.ForEach(t =>
                    {
                        if (!date.Any() || date.Last().value != t.Date.ToString("yyyy-MM-dd"))
                        {
                            date.Add(new PreRegistratonList { idx = indexDate, key = $"{t.Date.ToShortDateString()} {t.DayName}", value = t.Date.ToString("yyyy-MM-dd") });
                            indexDate++;
                        }

                        startTime.Add(new PreRegistratonList
                        {
                            idx = date.Last().idx,
                            value = t.StartTime.ToString("HH:mm"),
                            key = t.StartTime.ToString("HH:mm")
                        });
                        stopTime.Add(new PreRegistratonList
                        {
                            idx = date.Last().idx,
                            value = t.StopTime.ToString("HH:mm"),
                            key = t.StopTime.ToString("HH:mm")
                        });
                    });
                }

                var model = new GetDatePreRegistrationModelDto
                {
                    Date = date,
                    StartTime = startTime.OrderBy(t => t.idx).ThenBy(t => t.value).ToList(),
                    StopTime = stopTime.OrderBy(t => t.idx).ThenBy(t => t.value).ToList(),
                };

                return Json(model);
            }
            catch
            {
                return Json(null);
            }
        }

        public async Task<IActionResult> AddCancelPreRegistrationModal()
        {
            try
            {
                var mfc = _queueApi.GetOffices().Result.Result;

                var queueId = Debugger.IsAttached ? 1 : (int)await _employeeManager.GetOfficeQueueIdAsync(); ;

                var model = new RegistrationModelDto
                {
                    MFC = new SelectList(mfc, "Pk", "OfficeName", queueId).ToList(),
                };

                var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalTitle("Предварительная запись")
                .AddModalViewPath("../Shared/Components/QueuePartial/_ModalCancelPreRegistrationsAdd")
                .AddModel(model);

                return ModalLayoutView(modelBuilder);
            }
            catch (Exception e)
            {
                ShowError(MessageDescription.Error);
                return null;
            }
        }


        [HttpPost]
        public async Task<ActionResult> PreRegistrationModelSave(AddPreRegistrationRequestModel model)
        {
            var responce = await _queueApi.AddPrerecord(new AddPrerecordRequestData
            {
                OfficeId = model.queue_id,
                Date = model.date,
                StartTime = model.start_time,
                StopTime = model.stop_time,
                FullName = model.full_name,
                PhoneNumber = model.phone_number
            });

            return Json(responce);
        }

        [HttpPost]
        public async Task CancelPreRegistrationModelSave(AddCancelPreRegistrationRequestModel model)
        {
            var response = await _queueApi.CancelPrerecord(new CancelPrerecordRequestData
            {
                OfficeId = Debugger.IsAttached ? 1 : (int)await _employeeManager.GetOfficeQueueIdAsync(),
                CodePrerecord = model.code,
                Date = model.date
            });

            if (response?.Result ?? false) ShowSuccess(MessageDescription.RemoveSuccess);
            else ShowError(MessageDescription.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetDatePreRegistration(int id)
        {
            //var responce = await apiion.GetDatePreRegistration(id);

            //List<PreRegistratonList> date = new List<PreRegistratonList>();
            //List<PreRegistratonList> startTime = new List<PreRegistratonList>();
            //List<PreRegistratonList> stopTime = new List<PreRegistratonList>();

            //int idx = 0;

            //responce?.ForEach(f =>
            //{
            //    date.Add(new PreRegistratonList { key = f.date_format, value = f.date, idx = idx });
            //    startTime.Add(new PreRegistratonList
            //    {
            //        idx = m.Pk,
            //        value = t.StartTime.ToShortTimeString(),
            //        key = t.StartTime.ToShortTimeString()
            //    });
            //    stopTime.Add(new PreRegistratonList
            //    {
            //        idx = m.Pk,
            //        value = t.StopTime.ToShortTimeString(),
            //        key = t.StopTime.ToShortTimeString()
            //    });
            //});

            //var model = new GetDatePreRegistrationModelDto
            //{
            //    Date = date,
            //    StartTime = startTime,
            //    StopTime = stopTime
            //};

            var model = new GetDatePreRegistrationModelDto();

            return Json(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task NewAbon([FromBody]NewTicketQueueDto request)
        {
            try
            {
                var mfc_id = await _referencesService.GetOfficeForQueueAsync(request.OfficeId);
                if (mfc_id != null)
                {
                    var employees = await _referencesService.GetEmployeesForQueueAsync(mfc_id.Id);
                    if (employees is not null and { Count: > 0 })
                    {
                        var users = employees.Select(s => s.Id.ToString()).ToList();
                        await _hubContext.Clients.Users(users).SendAsync("Queue", request.TiketId);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
