using AisLogistics.App.Models.Queue;
using QueueReference;

namespace AisLogistics.App.Service.Queue
{
    public interface IElectronicQueueServiceApiClient
    {
        /// <summary>
        /// Список отложенных талонов
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<GetDeferredTicketsResponseData?> GetDeferredTickets(GetDeferredTicketsRequestData requestData);

        /// <summary>
        /// Список талонов в очереди
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<GetTicketsInQueueResponseData?> GetTicketsInQueue(GetTicketsInQueueRequestData requestData);

        /// <summary>
        /// Список переадресованных талонов
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<GetTransferedTicketsResponseData?> GetTransferedTickets(GetTransferedTicketsRequestData requestData);

        /// <summary>
        /// Список окон
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<GetWindowsResponseData?> GetWindows(GetWindowsRequestData requestData);

        /// <summary>
        /// Перенаправление талона в другое окно
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<TransferTicketResponseData?> TransferTicket(TransferTicketRequestData requestData);

        /// <summary>
        /// Отложить талон
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<PostponeTicketResponseData?> PostponeTicket(PostponeTicketRequestData requestData);

        /// <summary>
        /// Вызов талона
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<CallTicketResponseData?> CallTicket(CallTicketRequestData requestData);

        /// <summary>
        /// Количество талонов в очереди у окна
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<WindowTicketsInQueueStatResponseData?> WindowTicketsInQueueStat(WindowTicketsInQueueStatRequestData requestData);

        /// <summary>
        /// Вызов следующего талона из очереди
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<CallNextTicketInQueueResponseData?> CallNextTicketInQueue(CallNextTicketInQueueRequestData requestData);

        /// <summary>
        /// Завершить талон
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<CompleteTicketResponseData?> CompleteTicket(CompleteTicketRequestData requestData);

        /// <summary>
        /// Не явился
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<ClientNotComeResponseData?> ClientNotCome(ClientNotComeRequestData requestData);

        /// <summary>
        /// Взять в работу талон
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<TakeTicketToWorkResponseData?> TakeTicketToWork(TakeTicketToWorkRequestData requestData);

        /// <summary>
        /// Получение списка офисов
        /// </summary>
        /// <returns></returns>
        Task<GetOfficesResponseData?> GetOffices();

        /// <summary>
        /// Получение списка времен для предварительной записи
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<GetTimesForPrerecordResponseData?> GetTimesForPrerecord(GetTimesForPrerecordRequestData requestData);

        /// <summary>
        /// Добавление предварительной записи
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<AddPrerecordResponseData?> AddPrerecord(AddPrerecordRequestData requestData);

        /// <summary>
        /// Отмена предварительной записи
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<CancelPrerecordResponseData?> CancelPrerecord(CancelPrerecordRequestData requestData);

        /// <summary>
        /// Текущее состояние окна
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<GetWindowStateResponseData?> GetWindowState(GetWindowStateRequestData requestData);
    }
}
