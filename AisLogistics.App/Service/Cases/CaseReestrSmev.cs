using AisLogistics.App.Extensions;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Settings;
using AisLogistics.App.Utils;
using AisLogistics.App.ViewModels.Cases;
using Clave.Expressionify;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public partial class CaseService : ICaseService
    {

        /// <summary>
        /// Список обращений
        /// </summary>
        /// <param name="employeeId">id сотрудника</param>
        /// <returns></returns>
        public async Task<(List<CasesReestrSmevDto>, int, int)> GetCasesReestrSmev(IDataTablesRequest request, SearchCasesRequestData additionalRequest)
        {
            try
            {
                var date = DateTime.Today;

                if (additionalRequest.PeriodId.HasValue)
                {
                    switch (additionalRequest.PeriodId)
                    {
                        case 1:
                            additionalRequest.DateStart = DateTime.Now;
                            additionalRequest.DateStop = DateTime.Now;
                            break;
                        case 2:
                            additionalRequest.DateStart = DateTime.Now.AddDays(-7);
                            additionalRequest.DateStop = DateTime.Now;
                            break;
                        case 3:
                            additionalRequest.DateStart = DateTime.Now.AddMonths(-1);
                            additionalRequest.DateStop = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }

                var cases = _context.DServicesSmevRequests
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => (!additionalRequest.EmployeeId.HasValue || w.SEmployeesId == additionalRequest.EmployeeId) &&
                                (additionalRequest.ReceptionOfficesIdList.Count == 0 || additionalRequest.ReceptionOfficesIdList.Contains(w.SOfficesId)) &&
                                (string.IsNullOrEmpty(additionalRequest.EmployeeAdd) || EF.Functions.Like(w.EmployeesFioAdd.ToLower(), $"%{additionalRequest.EmployeeAdd.ToLower()}%")) &&
                                (additionalRequest.SmevServices.Count == 0 || additionalRequest.SmevServices.Any(a=>a==Guid.Empty) || additionalRequest.SmevServices.Contains(w.SSmevRequest.SSmevId)) &&
                                (additionalRequest.SmevRequest.Count == 0 || additionalRequest.SmevRequest.Any(a => a == -1) || additionalRequest.SmevRequest.Contains(w.SSmevRequestId)) &&
                                (!additionalRequest.DateStart.HasValue || w.DateAdd >= additionalRequest.DateStart.Value) &&
                                (!additionalRequest.DateStop.HasValue || w.DateAdd <= additionalRequest.DateStop.Value)
                        );

                int casesCount = await cases.CountAsync();

                var filteredData = string.IsNullOrWhiteSpace(additionalRequest.Query)
                     ? cases
                     : cases.Search(
                            s => s.DCasesId,
                            s => s.DServices.CustomerName.ToLower(),
                            s => s.DServices.CustomerAddress.ToLower(),
                            s => s.DServices.CustomerPhone1.ToLower(),
                            s => s.DServices.CustomerPhone2.ToLower(),
                            s => s.Commentt.ToLower()
                        ).ContainingAll(additionalRequest.Query.ToLower().Split(""));

                var statusFilter = additionalRequest.SmevStatusId switch
                {
                    (int)SmevStatusType.Expired => filteredData.Where(w => w.DateFact == null && w.DateReg < DateTime.Now && w.RequestHtml != null),
                    (int)SmevStatusType.Sent => filteredData.Where(w => w.DateFact == null && w.DateReg >= DateTime.Now && w.RequestHtml != null),
                    (int)SmevStatusType.Error => filteredData.Where(w => (w.DateFact != null || w.DateFact == null) && w.RequestHtml == null),
                    (int)SmevStatusType.ResponseSuccess => filteredData.Where(w => w.DateFact != null),
                    _ => filteredData
                };

                int casesFilteredCount = await statusFilter.CountAsync();

                var data = await statusFilter
                       .OrderByDescending(o => o.DateRequest)
                       .ThenByDescending(t=>t.TimeRequest)
                       .Skip(request.Start).Take(request.Length)
                       .Select(s => new CasesReestrSmevDto
                       {
                           Applicant = new ApplicantDto(s.DServices.CustomerName, s.DServices.CustomerAddress, s.DServices.CustomerPhone1),
                           Id = s.Id,
                           Name = s.SSmevRequest.RequestName,
                           SmevService = s.SSmevRequest.SSmev.SmevName,
                           Provider = s.SSmevRequest.SSmev.SmevProvider,
                           DateCreate = s.DateRequest.Value.ToShortDateString() + " " + s.TimeRequest.Value.ToLongTimeString(),
                           DateResponseFact = s.DateFact.HasValue ? s.DateFact.Value.ToShortDateString() + " " + s.TimeFact.Value.ToLongTimeString() : "-",
                           DateResponseReg = s.DateReg.ToShortDateString(),
                           Status = s.SmevStatus(),
                           EmployeeAdd = new EmployeeDto(s.SEmployeesId, NameSplitter.GetInitials(s.EmployeesFioAdd),
                            s.SEmployeesJobPosition.JobPositionName),
                           Description = s.Commentt,
                           Service = new CaseServiceDto
                           {
                               Id = s.DServicesId,
                               Name = s.DServices.SServices.ServiceNameSmall,
                               Office = s.DServices.SOfficesIdProviderNavigation.OfficeNameSmall,
                               EmployeeAdd = new EmployeeDto(s.SEmployeesId,
                                    NameSplitter.GetInitials(s.DServices.SEmployeesIdAddNavigation.EmployeeName),
                                    s.DServices.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                               Status = new StatusDto(s.DServices.SServicesStatusId, s.DServices.SServicesStatus.StatusName),
                               SerivesStage = new SerivesStageDto
                               {
                                   EmployeeCurrent = new EmployeeDto(s.DServices.SEmployeesIdCurrent, NameSplitter.GetInitials(s.DServices.SEmployeesIdCurrentNavigation.EmployeeName), s.DServices.SEmployeesJobPositionIdCurrentNavigation.JobPositionName),
                                   Stage = new StageDto(s.DServices.SRoutesStageIdCurrent, s.DServices.SRoutesStage.StageName),
                                   Office = s.DServices.SOfficesIdCurrentNavigation.OfficeNameSmall,
                                   //Office = sss.SEmployees.SEmployeesOfficesJoins.Where(w => w.DateStart <= date && (w.DateStop == null || w.DateStop >= date) && !w.IsRemove).Select(s => s.SOffices.OfficeName).First(),
                                   Days = s.DServices.RoutesStageDateRegCurrent.HasValue ? s.DServices.RoutesStageDateRegCurrent.Value.Subtract(date).Days : null
                               }
                           },
                           CaseId = s.DCasesId,
                           Comment = s.Commentt
                       })
                       .ToListAsync();

                return (data, casesCount, casesFilteredCount);
            }
            catch (Exception e)
            {
                return (new List<CasesReestrSmevDto>(), 0, 0);
            }
        }
    }
}
