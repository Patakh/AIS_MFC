using AisLogistics.App.Service;
using AisLogistics.App.Utils;
using Microsoft.AspNetCore.Authorization;

namespace AisLogistics.App.Views.Shared.Components.NotificationPartial
{
    [Authorize]
    public class NotificationPartial : ViewComponent
    {
        private readonly INotificationManager _notificationManager;
        
        public NotificationPartial(INotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public async Task<IViewComponentResult?> InvokeAsync()
        {
            if (User.Identity?.IsAuthenticated == false) return View("NotificationPartial");
            var notification = await _notificationManager.GetNotificationAsync();
            return View("NotificationPartial", notification);
        }
    }
}
