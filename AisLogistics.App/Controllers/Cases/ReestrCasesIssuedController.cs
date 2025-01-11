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
        [Breadcrumb("Реестр Выдачи", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> CasesIssued()
        {
            //var officesReceptionCustomer = await _filterManager.GetOfficesReceptionCustomerDataJson(true);
            var officeId = await _employeeManager.GetOfficeAsync();
            var employeeId = await _employeeManager.GetIdAsync();
            //ViewBag.CasesAllView = User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View);

            var model = new SearchCasesResponseData()
            {
                ReceptionOfficeId = officeId.GetValueOrDefault().ToString(),
                EmployeeId = employeeId
            };

            if (User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View))
            {
                model.OfficesReceptionCustomerList = new SelectList(await _filterManager.GetOfficesReceptionAllCustomerDataJson(true, true), "Id", "OfficeName");
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
                .SetElementName("cases-issued-datatable")
                .AddModel(model)
                .AddTableMethodAction(Url.Action(nameof(GetCasesIssuedDataJson)));
            return View(modelBuilder);
        }

        public async Task<IActionResult> GetCasesIssuedDataJson(IDataTablesRequest request, SearchCasesRequestData additionalRequest)
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

            (var responseData, int totalCount, int filteredCount) = await _caseService.GetIssueCases(request, additionalRequest);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }
    }
}
