using AisLogistics.App.Data;
using AisLogistics.App.Models;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Globalization;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly AisLogisticsContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeManager(AisLogisticsContext context,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        private async Task<ApplicationUser?> GetApplicationUser()
        {
            var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
            if (userName is null) return null;
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<string?> GetJobAsync(Guid id)
        {
            return await _context.SEmployeesJobPositions.AsNoTracking().Select(s => s.JobPositionName).FirstOrDefaultAsync();
        }

        public async Task AddSEmployeesAuthorizationLog(Guid Id, Guid OfficeId)
        {
            var model = new SEmployeesAuthorizationLog();
            model.SEmployeesId = await _context.SEmployees.AsNoTracking().Where(w => w.AspNetUserId == Id).Select(s => s.Id).SingleOrDefaultAsync();
            model.SOfficesId = OfficeId;
            model.LogInIp = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            model.LogInBrowserName = _httpContextAccessor?.HttpContext?.Request.Headers["User-Agent"].ToString();
            model.LogInDate = DateTime.Now;
            model.LogInProvider = "Логистика";

            await _context.AddAsync(model); ;
            await _context.SaveChangesAsync();
        }

        public async Task<Guid?> GetIdAsync()
        {
            var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
            if (userName is null) return null;

            var applicationUser = await _userManager.FindByNameAsync(userName);
            var employee = await _context.SEmployees.AsNoTracking().SingleOrDefaultAsync(s => s.AspNetUserId == applicationUser.Id);
            return employee?.Id;
        }

        public async Task<Guid?> GetIdAsync(ApplicationUser applicationUser)
        {
            var employee = await _context.SEmployees.AsNoTracking().SingleOrDefaultAsync(s => s.AspNetUserId == applicationUser.Id);
            return employee?.Id;
        }

        public async Task<string?> GetNameAsync()
        {
            var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
            if (userName is null) return null;

            var applicationUser = await _userManager.FindByNameAsync(userName);
            var employee = await _context.SEmployees.AsNoTracking().SingleOrDefaultAsync(s => s.AspNetUserId == applicationUser.Id);
            return employee?.EmployeeName;
        }

        public async Task<Guid?> GetOfficeAsync()
        {
            var applicationUser = await GetApplicationUser();
            if (applicationUser == null) return null;
            var claims = await _userManager.GetClaimsAsync(applicationUser);
            var claimOfficeId = claims.FirstOrDefault(f => f.Type == "OfficeId")?.Value;
            if (claimOfficeId is null) return null;

            return new Guid(claimOfficeId); ;
        }

        public async Task<Guid?> GetOfficeAsync(ApplicationUser applicationUser)
        {
            var date = DateTime.Today;
            var employee = await _context.SEmployees.AsNoTracking().Select(s => new
            {
                s.AspNetUserId,
                officeId = s.SEmployeesOfficesJoins.FirstOrDefault(w =>
                    w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop.Value.Date >= date.Date) && !w.IsRemove)!.SOfficesId
            }).SingleOrDefaultAsync(s => s.AspNetUserId == applicationUser.Id);
            return employee?.officeId;
        }

        public async Task<string?> GetOfficeNameAsync()
        {
            var applicationUser = await GetApplicationUser();
            if (applicationUser == null) return null;
            var claims = await _userManager.GetClaimsAsync(applicationUser);
            var claimOfficeId = claims.FirstOrDefault(f => f.Type == "OfficeId")?.Value;
            if (claimOfficeId is null) return null;

            var officeName = await _context.SOffices
               .AsNoTracking()
               .Where(w => w.Id == new Guid(claimOfficeId))
               .Select(s => s.OfficeName)
               .FirstOrDefaultAsync();

            return officeName;
        }

        public async Task<bool> GetOfficeActiveAsync(ApplicationUser applicationUser)
        {
            var date = DateTime.Today;

            return await _context.SEmployeesOfficesJoins
                 .AsNoTracking()
                 .AnyAsync(a => a.SEmployees.AspNetUserId == applicationUser.Id &&
                                !a.SEmployees.IsRemove &&
                                a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop.Value.Date >= date.Date) && !a.IsRemove);
        }

        public async Task<bool> GetOfficeActiveAsync(ApplicationUser applicationUser, Guid id)
        {
            var date = DateTime.Today;

            return await _context.SEmployeesOfficesJoins
                 .AsNoTracking()
                 .AnyAsync(a => a.SEmployees.AspNetUserId == applicationUser.Id &&
                                a.SOfficesId == id &&
                                a.DateStart.Date <= date.Date && (a.DateStop == null || a.DateStop.Value.Date >= date.Date) && !a.IsRemove);
        }

        public async Task<int> GetOfficeQueueIdAsync()
        {
            try
            {
                var applicationUser = await GetApplicationUser();
                if(applicationUser == null)  return 0; 
                var claims = await _userManager.GetClaimsAsync(applicationUser);
                var claimOfficeId = claims.FirstOrDefault(f => f.Type == "OfficeId")?.Value;
                if(claimOfficeId == null) return 0;
                var officeId = new Guid(claimOfficeId);

                var queueId = await _context.SOffices.AsNoTracking().Where(w => w.Id == officeId).Select(s => s.QueueId).SingleOrDefaultAsync();

                return queueId != null ? int.Parse(queueId, CultureInfo.InvariantCulture) : 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<EmployeeInfo> GetFullInfoAsync()
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
                if (userName is null) return new EmployeeInfo();

                var date = DateTime.Today;
                var applicationUser = await _userManager.FindByNameAsync(userName);
                var claims = await _userManager.GetClaimsAsync(applicationUser);
                var claimOfficeId = claims.FirstOrDefault(f => f.Type == "OfficeId")?.Value;
                if (claimOfficeId == null) return new EmployeeInfo();
                var officeId = new Guid(claimOfficeId);
                var employee = await _context.SEmployees
                    .AsNoTracking()
                    .Select(s => new
                    {
                        s.Id,
                        s.EmployeeName,
                        s.AspNetUserId,
                        Job = s.SEmployeesOfficesJoins.Where(w => !w.IsRemove&&w.DateStart.Date <= date.Date && (w.DateStop == null || w.DateStop.Value.Date >= date.Date)).Select(ss => new EmployeeJobInfo(ss.SEmployeesJobPositionId, ss.SEmployeesJobPosition.JobPositionName)).FirstOrDefault()
                    }).SingleOrDefaultAsync(s => s.AspNetUserId == applicationUser.Id);

                if (employee is null || employee.Job is null ) return new EmployeeInfo();

                var office = await _context.SOffices
                    .AsNoTracking()
                    .Where(w => w.Id == officeId)
                    .Select(s => new EmployeeOfficeInfo(s.Id, s.OfficeNameSmall, s.OfficeMnemo))
                    .FirstOrDefaultAsync();

                if (office is null) return new EmployeeInfo();

                //TODO что делать если нет офиса?
                return new EmployeeInfo
                {
                    Id = employee.Id,
                    Name = employee.EmployeeName,
                    Job = employee.Job,
                    Office = office
                };
            }
            catch
            {
                return new EmployeeInfo();
            }

        }

        public async Task<EmployeeInfo> GetEmployeeAsync()
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
                if (userName is null) return new EmployeeInfo();

                var applicationUser = await _userManager.FindByNameAsync(userName);
                var employee = await _context.SEmployees
                    .AsNoTracking()
                    .Select(s => new
                    {
                        s.Id,
                        s.EmployeeName,
                        s.AspNetUserId,
                    }).SingleOrDefaultAsync(s => s.AspNetUserId == applicationUser.Id);

                if (employee is null) return new EmployeeInfo();

                //TODO что делать если нет офиса?
                return new EmployeeInfo
                {
                    Id = employee.Id,
                    Name = employee.EmployeeName,
                };
            }
            catch
            {
                return new EmployeeInfo();
            }

        }

        public async Task<FtpSettingsModel?> GetFtpAsync()
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
                var applicationUser = await _userManager.FindByNameAsync(userName);
                var claims = await _userManager.GetClaimsAsync(applicationUser);
                var claimOfficeId = claims.FirstOrDefault(f => f.Type == "OfficeId")?.Value;
                if (claimOfficeId == null) return null;
                var officeId = new Guid(claimOfficeId);

                var ftp = await _context.SOffices.AsNoTracking().Where(w => w.Id == officeId).Select(s => new FtpSettingsModel
                {
                    Id = s.SFtp.Id,
                    Login = s.SFtp.FtpLogin,
                    Password = s.SFtp.FtpPassword,
                    Server = s.SFtp.FtpServer
                }).FirstOrDefaultAsync();

                return ftp;
            }
            catch
            {
                return null; 
            }
        }

        public async Task<string> GetIp()
        {
            return await Task.Run(()=>_httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? string.Empty);
        }

        public async Task<bool> GetIsActiveStatusEmployees(ApplicationUser applicationUser)
        {
            var date = DateTime.Today;
            const int employeeWorkStatus = 0;
            return await _context.SEmployeesStatusJoins
                .AsNoTracking()
                .AnyAsync(a => a.SEmployees.AspNetUserId == applicationUser.Id &&
                              !a.SEmployees.IsRemove && 
                               a.SEmployeesStatusId == employeeWorkStatus &&
                               a.DateStart.Date <= date.Date && 
                               (a.DateStop == null || a.DateStop.Value.Date >= date.Date) && 
                               !a.IsRemove);
        }

    }
}
