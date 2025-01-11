using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        [Breadcrumb("Реестр СМЭВ", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> CasesReestrSmev()
        {
            var officesProviderServices = await _filterManager.GetProvidersDataJson();
            var smev = await _filterManager.GetSmevServicesDataJson();
            var smevRequest = await _filterManager.GetRequestForSmevServicesDataJson(new List<Guid>());
            var officeId = await _employeeManager.GetOfficeAsync();

            //ViewBag.CasesAllView = User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View);

            var model = new SearchCasesResponseData()
            {
                ReceptionOfficeId = officeId.GetValueOrDefault().ToString(),
                OfficesProviderServicesList = new SelectList(officesProviderServices, "Id", "OfficeName"),
                SmevServicesList = new SelectList(smev, "Id", "SmevName"),
                SmevRequestList = new SelectList(smevRequest, "Id", "RequestName"),
            };

            if (User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View))
            {
                model.OfficesReceptionCustomerList = new SelectList(await _filterManager.GetOfficesReceptionAllCustomerDataJson(true,true), "Id", "OfficeName");
            }
            else if (User.HasClaim(AccessKeyNames.DataCaseOffice, AccessKeyValues.View))
            {
                model.OfficesReceptionCustomerList = new SelectList(await _filterManager.GetOfficesReceptionDepartamentCustomerDataJson(true), "Id", "OfficeName");
            }
            else
            {
                model.OfficesReceptionCustomerList = new SelectList(await _filterManager.GetOfficesReceptionEmployeeCustomerDataJson(true), "Id", "OfficeName");
            }

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Реестр услуг на выдачу")
                .SetElementName("cases-reestr-datatable")
                .AddModel(model)
                .AddTableMethodAction(Url.Action(nameof(GetCasesReestrSmevDataJson)));
            return View(modelBuilder);
        }

        public async Task<IActionResult> GetCasesReestrSmevDataJson(IDataTablesRequest request, SearchCasesRequestData additionalRequest)
        {
            additionalRequest.EmployeeId = User.HasClaim(AccessKeyNames.FilterEmployeesAll, AccessKeyValues.View) ? null : await _employeeManager.GetIdAsync();

            if (User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View))
            {
                var receptionOfficeData = await _filterManager.GetOfficesAllIdForReceptionCustomer(new List<string> { additionalRequest.ReceptionOfficeId }, false, false);
                additionalRequest.ReceptionOfficesIdList = receptionOfficeData.OfficesId;
            }
            else if (User.HasClaim(AccessKeyNames.DataCaseOffice, AccessKeyValues.View))
            {
                var receptionOfficeData = await _filterManager.GetOfficesDepartamentIdForReceptionCustomer(new List<string> { additionalRequest.ReceptionOfficeId }, false, false);
                additionalRequest.ReceptionOfficesIdList = receptionOfficeData.OfficesId;
            }
            else
            {
                var receptionOfficeData = await _filterManager.GetOfficesEmployeeIdForReceptionCustomer(new List<string> { additionalRequest.ReceptionOfficeId }, false, false);
                additionalRequest.ReceptionOfficesIdList = receptionOfficeData.OfficesId;
            }

            (var responseData, int totalCount, int filteredCount) = await _caseService.GetCasesReestrSmev(request, additionalRequest);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }
    }
}
