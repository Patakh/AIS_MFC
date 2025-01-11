using AisLogistics.App.Data;
using AisLogistics.App.Models;

namespace AisLogistics.App.Service
{
    public interface IEmployeeManager
    {
        Task<string?> GetJobAsync(Guid id);
        Task AddSEmployeesAuthorizationLog(Guid Id, Guid OfficeId);
        Task<Guid?> GetIdAsync();
        Task<Guid?> GetIdAsync(ApplicationUser applicationUser);
        Task<string?> GetNameAsync();
        Task<Guid?> GetOfficeAsync();
        Task<string?> GetOfficeNameAsync();
        Task<Guid?> GetOfficeAsync(ApplicationUser applicationUser);
        Task<bool> GetOfficeActiveAsync(ApplicationUser applicationUser);
        Task<bool> GetOfficeActiveAsync(ApplicationUser applicationUser, Guid id);
        Task<int> GetOfficeQueueIdAsync();
        Task<EmployeeInfo> GetFullInfoAsync();
        Task<EmployeeInfo> GetEmployeeAsync();
        Task<FtpSettingsModel?> GetFtpAsync();
        Task<string> GetIp();
        Task<bool> GetIsActiveStatusEmployees(ApplicationUser applicationUser);
    }
}
