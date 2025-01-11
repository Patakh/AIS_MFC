using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.App.ViewModels.ReestrTransferDocuments;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        [Breadcrumb("Услуги", FromAction = nameof(Index), FromController = typeof(HomeController))]
        public async Task<IActionResult> Index()
        {
            var officesProviderServices = await _filterManager.GetProvidersDataJson();
            var stages = await _filterManager.GetServiceRouteStagesDataJson();
            var services = await _filterManager.GetServicesForProviderDataJson(new List<Guid>());
            var status = await _filterManager.GetServiceStatusDataJson();
            
            var officeId = await _employeeManager.GetOfficeAsync();

            //ViewBag.CasesAllView = User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View);

            var model = new SearchCasesResponseData()
            {
                ReceptionOfficeId = officeId.GetValueOrDefault().ToString(),
                OfficesProviderServicesList = new SelectList(officesProviderServices, "Id", "OfficeName",Guid.Empty),
                ServicesList = new SelectList(services, "Id", "ServiceName"),
                StatusList = new SelectList(status, "Id", "Name"),
                StagesList = new SelectList(stages, "Id", "Name")
            };

            if (User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View)) 
            {
                model.OfficesReceptionCustomerList = new SelectList(await _filterManager.GetOfficesReceptionAllCustomerDataJson(true, true), "Id", "OfficeName");
            }
            else if (User.HasClaim(AccessKeyNames.DataCaseOffice, AccessKeyValues.View)) 
            {
                model.OfficesReceptionCustomerList = new SelectList(await _filterManager.GetOfficesReceptionDepartamentCustomerDataJson(true), "Id", "OfficeName");
            }
            else {
                model.OfficesReceptionCustomerList = new SelectList(await _filterManager.GetOfficesReceptionEmployeeCustomerDataJson(true), "Id", "OfficeName");
            }    

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Реестр услуг")
                .SetElementName("cases-datatable")
                .AddModel(model)
                .AddTableMethodAction(Url.Action(nameof(GetEmployeeCasesDataJson)));
            return View(modelBuilder);
        }

        public async Task<IActionResult> GetEmployeeCasesDataJson(IDataTablesRequest request, SearchCasesRequestData additionalRequest)
        {
            additionalRequest.EmployeeId = User.HasClaim(AccessKeyNames.DataCaseAll, AccessKeyValues.View) 
                || User.HasClaim(AccessKeyNames.DataCaseOffice, AccessKeyValues.View) ? null : await _employeeManager.GetIdAsync();

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

            (var responseData, int totalCount, int filteredCount) = await _caseService.GetCases(request, additionalRequest);

            var response = DataTablesResponse.Create(request, totalCount, filteredCount, responseData);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> CasesServiceСopyModal(Guid Id)
        {
            try
            {
                var response = await _caseService.CasesServiceCopy(Id);
                var model = new ModalViewModelBuilder()
                    .AddModel(response)
                    .AddModalTitle("Копирование услуги")
                    .AddModalViewPath("~/Views/Cases/_ModalCasesServiceCopy.cshtml")
                    .AddModalType(ModalType.LARGE);

                return ModalLayoutView(model);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return Problem();
            }
        }

        public async Task<IActionResult> CasesСopyModal(string Id)
        {
            try
            {
                var response = await _caseService.CasesServiceCopy(Id);
                var model = new ModalViewModelBuilder()
                    .AddModel(response)
                    .AddModalTitle("Копирование услуги")
                    .AddModalViewPath("~/Views/Cases/Details/Modals/_ModalCasesCopy.cshtml")
                    .AddModalType(ModalType.LARGE);

                return ModalLayoutView(model);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return Problem();
            }
        }

        public async Task<IActionResult> CasesServiceСopySaveAsync(CasesServiceCopySaveDto request)
        {
            if (ModelState.IsValid == false)
            {
                ShowError("Неверные данные");
                return Problem("Неверные данные");
            }
            try
            {
                var response = await _caseService.CasesServiceCopySave(request);
                ShowSuccess("Услуга скопирована");
                return Ok(response);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return Problem();
            }
        }

        public async Task<IActionResult> IncomingDocumentsChangeModalAdd()
        {
            var employee = await _employeeManager.GetFullInfoAsync();
            var providers = await _referencesService.GetOfficesProvidersAll();
            ViewBag.Providers = new SelectList(providers, nameof(OfficeDto.Id), nameof(OfficeDto.OfficeName));

            var model = new ModalViewModelBuilder()
                .AddModalTitle(employee.Office.Name)
                .AddModalViewPath("~/Views/Cases/_ModalServiceIncomingDocuments.cshtml")
                .AddModalType(ModalType.EXTRA);

            return ModalLayoutView(model);
        }

        public async Task<IActionResult> IncomingDocumentsTable(Guid providerId, Guid? departamentId, Guid serviceId)
        {
            var id = await _employeeManager.GetIdAsync();
            var officeId = await _employeeManager.GetOfficeAsync();

            var request = new SearchIncomingDocumentsRequestData
            {
                ServiceId = serviceId,
                ProvidersId = providerId,
                DepartamentId = departamentId
            };
            var model = await _caseService.GetCasesIncomingDocuments(officeId, request);

            return PartialView("_TableAddIncomingDocument", model);
        }
    }
}
