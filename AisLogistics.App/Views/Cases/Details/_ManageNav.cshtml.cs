using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Views.Cases.Details
{
    public static class ManageNav
    {
        public static string Index => "Details";
        public static string Comments => "DetailsComments";
        public static string Notification => "DetailsNotification";
        public static string Audit => "DetailsAudit";
        
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string CommentsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Comments);
        public static string NotificationNavClass(ViewContext viewContext) => PageNavClass(viewContext, Notification);
        public static string AuditNavClass(ViewContext viewContext) => PageNavClass(viewContext, Audit);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                             ?? Path.GetFileNameWithoutExtension(viewContext.RouteData.Values["Action"].ToString());
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
