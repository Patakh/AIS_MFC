using AisLogistics.App.Service;
using Microsoft.AspNetCore.Authorization;

namespace AisLogistics.App.Controllers
{
    [Authorize]
    public class NotificationController : AbstractController
    {
        private readonly INotificationManager _notificationManager;
        public NotificationController(INotificationManager notificationManager, IEmployeeManager employeeManager) : base(employeeManager)
        {
            _notificationManager = notificationManager;
        }

        public async Task Read(Guid? id)
        {
            await _notificationManager.ReadNotificationAsync(id);
        }

        public async Task Remove(Guid id)
        {
            await _notificationManager.RemoveNotificationAsync(id);
        }

        public async Task<bool> RemoveAll()
        {
            var employeeId = await _employeeManager.GetIdAsync();
            return await _notificationManager.RemoveAllEmployeeNotificationAsync((Guid)employeeId);
        }
    }
}