using AisLogistics.API.Models.Request;
using AisLogistics.API.Models.Request.Queue;
using AisLogistics.API.Models.Responce;


namespace AisLogistics.API.Service
{
    public interface IElectronicQueueServiceClientAPI
    {
        Task<QueueInfoResponse?> GetQueueInfo(QueueInfoRequest request);
        Task<List<QueueOfficeInfoResponse>?> GetQueueOfficeInfo(QueueOfficeInfoRequest request);
        Task<List<OfficeQueueResponse>?> GetOffices();
        Task<List<TimePrerecordResponse>?> GetTimesForPrerecord(TimePrerecordRequest request);
        Task<AddPrerecordResponse?> AddPrerecord(AddPrerecordRequest request);
        Task<CanselPrerecordResponse?> CanselPrerecord(CanselPrerecordRequest request);
    }
}
