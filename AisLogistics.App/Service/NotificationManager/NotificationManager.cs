using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Notifications;
using AisLogistics.App.Models.Enums;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public class NotificationManager : INotificationManager
    {
        private readonly AisLogisticsContext _context;
        private readonly IEmployeeManager _employeeManager;

        public NotificationManager(AisLogisticsContext context, IEmployeeManager employeeManager)
        {
            _context = context;
            _employeeManager = employeeManager;
        }

        public async Task<EmployeeNotificationDto> GetNotificationAsync(NotificationType? type = null)
        {
            EmployeeNotificationDto alertsEmployees = new();
            var userId = await _employeeManager.GetIdAsync();
            var notifications = await _context.DAlertEmployees.AsNoTracking()
                .Where(w => w.SEmployeesId == userId && (!type.HasValue || w.SAlertEmployeeId == (int)type))
                .OrderByDescending(o => o.DateAdd)
                .Select(s => new
                {
                    Id = s.Id,
                    SAlertEmployeeId = s.SAlertEmployeeId,
                    DCasesId = s.DCasesId,
                    DServicesId = s.DServicesId,
                    ApplicantFio = s.DCases.DServicesCustomersLegals.Count != 0 ? s.DCases.DServicesCustomersLegals.First().CustomerName : s.DCases.DServicesCustomers.First(w => w.CustomerType == (int)CustomerType.Applicant).Fio(),
                    ServiceName = s.DServicesId.HasValue ? s.DServices.SServices.ServiceName : "",
                    ServiceEmployeeFioAdd = s.DServicesId.HasValue ? s.DServices.DservicesStageCurrent().EmployeesFioAdd : "",
                    TextComment = s.DServicesCommenttId.HasValue ? s.DServicesCommentt.Commentt : "",
                    CommentEmployeeNameAdd = s.DServicesCommenttId.HasValue ? s.DServicesCommentt.SEmployees.EmployeeName : "",
                    SmevName = s.DServicesSmevRequestId.HasValue ? s.DServicesSmevRequest.SSmevRequest.RequestName : "",
                    CommenttDateAdd = s.DServicesCommenttId.HasValue ? s.DServicesCommentt.DateAdd : (DateTime?)null,
                    SmevDateFact = s.DServicesSmevRequestId.HasValue ? s.DServicesSmevRequest.DateFact : (DateTime?)null,
                    ServiceDateAdd = s.DServicesId.HasValue ? s.DServices.DservicesStageCurrent().DateAdd : (DateTime?)null
                }).ToListAsync();

            foreach (var alert in notifications)
            {
                switch (alert.SAlertEmployeeId)
                {
                    case (int)NotificationType.NewComment:
                        alertsEmployees.CommentsAlert.Add(new EmployeeNotificationDto.CommentInfo
                        {

                            Id = alert.Id,
                            ApplicantName = alert.ApplicantFio,
                            ServicesId = alert.DServicesId,
                            CaseId = alert.DCasesId,
                            EmployeeNameAdd = alert.CommentEmployeeNameAdd,
                            TextComment = alert.TextComment,
                            DateAddComment = alert.CommenttDateAdd,
                            TypeAlerts = alert.SAlertEmployeeId
                        });
                        break;
                    case (int)NotificationType.NewCase:
                        alertsEmployees.NewServicesAlert.Add(new EmployeeNotificationDto.NewServicesInfo
                        {

                            Id = alert.Id,
                            ApplicantName = alert.ApplicantFio,
                            ServicesId = alert.DServicesId,
                            CaseId = alert.DCasesId,
                            EmployeeNameAdd = alert.ServiceEmployeeFioAdd,
                            ServicesName = alert.ServiceName,
                            DateAddStage = alert.ServiceDateAdd,
                            TypeAlerts = alert.SAlertEmployeeId
                        });
                        break;
                    case (int)NotificationType.SmevRequest:
                        alertsEmployees.SmevResponseAlert.Add(new EmployeeNotificationDto.SmevResponseInfo
                        {
                            Id = alert.Id,
                            ApplicantName = alert.ApplicantFio,
                            ServicesId = alert.DServicesId,
                            CaseId = alert.DCasesId,
                            SmevName = alert.SmevName,
                            DateSmevResponse = alert.SmevDateFact,
                            TypeAlerts = alert.SAlertEmployeeId
                        });
                        break;
                }
            }

            return alertsEmployees;
        }

        public async Task ReadNotificationAsync(Guid? id)
        {
            var userId = await _employeeManager.GetIdAsync();
            await _context.DAlertEmployees.AsNoTracking().Where(w => id.HasValue ? w.Id == id : w.SEmployeesId == userId)
                .UpdateFromQueryAsync(u => new DAlertEmployee { IsRead = true });
        }
        public async Task RemoveNotificationAsync(Guid id)
        {
            await _context.DAlertEmployees.Where(f => f.Id == id).DeleteAsync();
        }

        public async Task<bool> RemoveAllEmployeeNotificationAsync(Guid id)
        {
            try
            {
                await _context.DAlertEmployees.Where(f => f.SEmployeesId == id).DeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
