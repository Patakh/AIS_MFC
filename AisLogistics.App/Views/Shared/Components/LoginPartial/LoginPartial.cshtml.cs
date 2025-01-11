using AisLogistics.App.Service;
using AisLogistics.App.Utils;
using Microsoft.AspNetCore.Authorization;

namespace AisLogistics.App.Views.Shared.Components.LoginPartial
{
    [Authorize]
    public class LoginPartial : ViewComponent
    {
        private readonly IEmployeeManager _employeeManager;
        
        public LoginPartial(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        public async Task<IViewComponentResult?> InvokeAsync()
        {
            if (User.Identity?.IsAuthenticated == false) return View("LoginPartial");
            var employee = await _employeeManager.GetFullInfoAsync();
            //var userInfo = new UserInfo(employee.Name ?? "Пользователь", employee?.Job?.Name, employee?.Office?.Name);
            return View("LoginPartial", employee);
        }
    }

    //public class UserInfo
    //{
    //    public UserInfo(string name)
    //    {
    //        Name = name;
    //    }
    //    public UserInfo(string name, string? job, string? office)
    //    {
    //        Name = name;
    //        Job = job;
    //        Office = office;
    //        Badge = NameSplitter.GetBadge(name);
    //    }
    //    public string Name { get; set; }
    //    public string? Job { get; set; }
    //    public char Badge { get; set; }
    //    public string? Office { get; set; }
    //}
}
