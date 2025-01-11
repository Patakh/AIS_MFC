using AisLogistics.API.Models.Request.PersonalAccount;
using AisLogistics.API.Models.Responce;
using AisLogistics.DataLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.API.Service
{
    public class PersonalAccountServicesAPI : IPersonalAccountServicesAPI
    {
        private readonly AisLogisticsContext _context;
        public PersonalAccountServicesAPI(AisLogisticsContext context) 
        {
            _context = context;
        }

        public async Task<CasesInfoResponse?> GetCasesInfo(string caseId)
        {
            try
            {
                CasesInfoResponse? cases;

                cases = await _context.DServices
                   .Where(w => w.DCasesId == caseId)
                   .Select(s => new CasesInfoResponse
                   {
                       CaseId = s.DCasesId,
                       ServicesName = s.SServices.ServiceName,
                       ServicesProviderName = s.SOfficesIdProviderNavigation.OfficeName,
                       StatusId = s.SServicesStatusId,
                       StatusName = s.SServicesStatus.StatusName,
                       CustomerFio = s.CustomerName,
                       CustomerAddress = s.CustomerAddress,
                       MfcName = s.SOfficesIdAddNavigation.OfficeName,
                       EmployeesFioAdd = s.SEmployeesIdAddNavigation.EmployeeName,
                       EmployeesFioCurrent = s.SEmployeesIdCurrentNavigation.EmployeeName,
                       DateAdd = s.DateAdd,
                       DateFact = s.DateFact,
                       DateReglament = s.DateReg
                   }).FirstOrDefaultAsync();

                cases ??= await _context.ACases
                    .Where(w => w.Id == caseId)
                    .Select(s => new CasesInfoResponse
                    {
                        CaseId = s.Id,
                        ServicesName = s.ServiceName,
                        ServicesProviderName = s.OfficeNameProvider,
                        StatusId = s.SServicesStatusId,
                        StatusName = s.StatusName,
                        CustomerFio = s.CustomerName,
                        CustomerAddress = s.CustomerAddress,
                        MfcName = s.OfficeNameAdd,
                        EmployeesFioAdd = s.EmployeeNameAdd,
                        EmployeesFioCurrent = s.EmployeeNameExecution,
                        DateAdd = s.AServices.First(ss => ss.AServicesIdParent == Guid.Empty).DateAdd,
                        DateFact = s.AServices.First(ss => ss.AServicesIdParent == Guid.Empty).DateFact,
                        DateReglament = s.AServices.First(ss => ss.AServicesIdParent == Guid.Empty).DateReg,
                    }).FirstOrDefaultAsync();

                return cases;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<CasesExecutioninfoResponse>?> GetCasesExecutionInfo(CasesExecutionInfoRequest request)
        {
            try
            {
                return await _context.DServices
                    .AsNoTracking()
                    .Where(w => (w.CustomerPhone1 == request.InputMaskPhoneNumber() || w.CustomerPhone2 == request.InputMaskPhoneNumber())
                               && (w.SServicesStatusId == 0 || (w.SServicesStatusId != 0 && w.SRoutesStageIdCurrent != 7))
                               )
                    .Select(s => new CasesExecutioninfoResponse
                    {
                        CaseNumber = s.DCasesId,
                        ServiceName = s.SServices.ServiceName,
                        ProviderName = s.SOfficesIdProviderNavigation.OfficeName,
                        MfcName = s.SOfficesIdAddNavigation.OfficeName,
                        StatusName = s.SServicesStatus.StatusName,
                        DateAdd = s.DateAdd.ToShortDateString(),
                        DateReg = s.DateReg.ToShortDateString(),
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
