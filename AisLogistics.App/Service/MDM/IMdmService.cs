using AisLogistics.DataLayer.Entities.Models;

namespace AisLogistics.App.Service.MDM
{
    public interface IMdmService
    {
        // 5 8 25 11
        Task<List<DMdmObjectsUpload>?> MdmStartedDataServicesObjectsAsync(Guid dServiceId, Guid officeIdMdm, Guid sprServicesSubId, Guid dServiceRouteStageId, int? recivedWindowsCount);
        // 9
        Task<List<DMdmObjectsUpload>?> MdmСonsultationDataServicesObjectsAsync(Guid dServiceId, Guid officeIdMdm, Guid sprServicesSubId, Guid dServiceRouteStageId, int? recivedWindowsCount);
        // 17
        Task<List<DMdmObjectsUpload>?> MdmQueryObjectsAsync(Guid dServiceId, Guid officeIdMdm);
        // 18
        Task<List<DMdmObjectsUpload>?> MdmServiceProcessingHoldObjectsAsync(Guid dServiceId, Guid officeIdMdm);
        // 23
        Task<List<DMdmObjectsUpload>?> MdmServiceResultsReceivedObjectsAsync(Guid dServiceId, Guid officeIdMdm);
        // 22
        Task<List<DMdmObjectsUpload>?> MdmServiceProcessingEndedObjectsAsync(Guid dServiceId, Guid officeIdMdm, int value, bool isDeadLine, Guid dServiceRouteStageId);
    }
}
