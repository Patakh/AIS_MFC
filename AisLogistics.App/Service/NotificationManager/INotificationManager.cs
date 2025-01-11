using AisLogistics.App.Models.DTO.Notifications;
using AisLogistics.App.Models.Enums;

namespace AisLogistics.App.Service
{
    public interface INotificationManager
    {
        Task<EmployeeNotificationDto> GetNotificationAsync(NotificationType? type = null);
        Task ReadNotificationAsync(Guid? id);
        Task RemoveNotificationAsync(Guid id);
        Task<bool> RemoveAllEmployeeNotificationAsync(Guid id);
    }
}
