using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;
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
        /// Список обращений на выдачу
        /// </summary>
        /// <param name="employeeId">id сотрудника</param>
        /// <returns></returns>
        public async Task<(List<CasesDto>, int, int)> GetIssueCases(IDataTablesRequest request, SearchCasesRequestData additionalRequest)
        {
            try
            {
                List<int> statusId = new() { 1, 5 };
                const int issueStage = 6;
                var date = DateTime.Today;

                var cases = _context.DServices
                        .AsNoTracking()
                        .AsSplitQuery()
                        .Expressionify()
                        .Where(w => (!additionalRequest.EmployeeId.HasValue || w.SEmployeesIdCurrent == additionalRequest.EmployeeId) &&
                                   (additionalRequest.ReceptionOfficesIdList.Count == 0 || additionalRequest.ReceptionOfficesIdList.Contains(w.SOfficesIdCurrent)) &&
                                   w.SRoutesStageIdCurrent == issueStage &&
                                   statusId.Contains(w.SServicesStatusId)
                        );

                int casesCount = await cases.CountAsync();

                var filteredResult = string.IsNullOrEmpty(request.Search.Value)
                                       ? cases
                                       : cases.Search(s => s.DCasesId.ToLower())
                                       .Containing(request.Search.Value.ToLower().Split(""));

                int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? casesCount : await filteredResult.CountAsync();

                var data = await filteredResult
                       .Select(s => new CasesDto
                       {
                           casesMainDto = new CasesMainDto
                           {
                               CaseId = s.DCasesId,
                               DateAdd = s.DCases.DateAdd.ToShortDateString(),
                               Applicant = new ApplicantDto(s.CustomerName, s.CustomerAddress, s.CustomerPhone1),
                           },
                           Service = new CaseServiceDto
                           {
                               Id = s.Id,
                               Name = s.SServices.ServiceNameSmall,
                               Office = s.SOfficesIdProviderNavigation.OfficeNameSmall,
                               EmployeeAdd = new EmployeeDto(s.SEmployeesIdAddNavigation.Id,
                                            NameSplitter.GetInitials(s.SEmployeesIdAddNavigation.EmployeeName),
                                            s.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                               Status = new StatusDto(s.SServicesStatusId, s.SServicesStatus.StatusName),
                               SerivesStage = new SerivesStageDto
                               {
                                   EmployeeCurrent = new EmployeeDto(s.SEmployeesIdCurrent, NameSplitter.GetInitials(s.SEmployeesIdCurrentNavigation.EmployeeName), s.SEmployeesJobPositionIdCurrentNavigation.JobPositionName),
                                   //Office = sss.SEmployees.SEmployeesOfficesJoins.Where(w => w.DateStart <= date && (w.DateStop == null || w.DateStop >= date) && !w.IsRemove).Select(s => s.SOffices.OfficeName).First(),
                                   Office = s.SOfficesIdCurrentNavigation.OfficeNameSmall,
                                   Stage = new StageDto((int)s.SRoutesStageIdCurrent, s.SRoutesStage.StageName),
                                   Days = s.RoutesStageDateRegCurrent.HasValue ? s.RoutesStageDateRegCurrent.Value.Subtract(date).Days : null
                               }
                           },
                           CaseApplicantPhoneDtos = s.DCases.DServicesCustomers.Select(s => new CaseApplicantPhoneDto
                           {
                               Id = s.Id,
                               ApplicantName = s.Fio(),
                               Phone1 = s.CustomerPhone1,
                               Phone2 = s.CustomerPhone2,
                               CustomerType = (CustomerType)s.CustomerType

                           }).ToList()
                       })
                       .ToListAsync();

                return (data, casesCount, filteredCount);
            }
            catch
            {
                return (new List<CasesDto>(), 0, 0);
            }
        }
    }
}
