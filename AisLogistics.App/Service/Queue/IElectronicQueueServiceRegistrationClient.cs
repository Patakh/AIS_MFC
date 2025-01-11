using AisLogistics.App.Models.Queue;

namespace AisLogistics.App.Service.Queue
{
    public interface IElectronicQueueServiceRegistrationClient
    {
        Task<List<GetDatePreRegistetionResponceData>?> GetDatePreRegistration(int id);
        Task<string?> AddPreRegistration(int id, PreRegistrationRequestModel model);
        Task<bool> AddCacelPreRegistration(int id, PreRegistrationCancelRequestModel model);
    }
}
