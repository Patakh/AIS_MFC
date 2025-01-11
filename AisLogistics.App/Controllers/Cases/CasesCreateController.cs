using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {

        [Breadcrumb("Новая услуга", FromAction = nameof(Index), FromController = typeof(CasesController))]
        [Route("[controller]/Create")]
        public async Task<IActionResult> Create()
        {
            var providers = await _filterManager.GetProvidersDataJson();
            var customerTypes = await _filterManager.GetServiceCustomerTypeDataJson(false);
            var hashtag = await _filterManager.GetServiceHashtagDataJson();

            ViewBag.Providers = new SelectList(providers, nameof(ActiveServiceProviderDto.Id), nameof(ActiveServiceProviderDto.OfficeName));
            ViewBag.CustomerTypes = new SelectList(customerTypes, "Id", "TypeName");
            ViewBag.Hashtag = new SelectList(hashtag, "Name", "Name"); ;

            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Новая услуга")
                .AddModel(new CreateCaseRequestModel());
            return View("Create/Index", modelBuilder);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSave(CreateCaseRequestModel requestModel)
        {
            if (ModelState.IsValid == false)
            {
                ShowError("Неверные данные");
                return Problem("Неверные данные");
            }

            if(requestModel.Customer is null && requestModel.CustomerLegal is null)
            {
                ShowError("Неверные данные о заявителе");
                return Problem("Неверные данные о заявителе");
            }

            try
            {
                var responseModel = await _caseService.CreateCaseAsync(requestModel);

                if (responseModel.CreateCaseStatus.IsCreated == true)
                {
                    ShowSuccess("Обращение создано");

                    if (requestModel.Customer is not null)
                    {
                        if (requestModel.IsGetCustomerSnils && string.IsNullOrEmpty(requestModel.Customer.CustomerSnils))
                        {
                            await _smevService.GetCustomerSnils(responseModel.DserviceId, requestModel.Customer);
                        }
                        if (requestModel.IsGetCustomerInn && string.IsNullOrEmpty(requestModel.Customer.CustomerInn))
                        {
                            await _smevService.GetCustomerInn(responseModel.DserviceId, requestModel.Customer);
                        }
                    }
                    if (requestModel.Representative is not null)
                    {
                        if (requestModel.IsGetRepresentativeSnils && string.IsNullOrEmpty(requestModel.Representative.CustomerSnils))
                        {
                            await _smevService.GetCustomerSnils(responseModel.DserviceId, requestModel.Representative);
                        }

                        if (requestModel.IsGetRepresentativeInn && string.IsNullOrEmpty(requestModel.Representative.CustomerInn))
                        {
                            await _smevService.GetCustomerInn(responseModel.DserviceId, requestModel.Representative);
                        }
                    }

                    responseModel.CreateCaseStagesNext.AddRange(User.HasClaim(AccessKeyNames.DataCaseServiceAllStage, AccessKeyValues.View)
                    ? await _caseService.GetStagesNextAllAsync(new List<Guid>() { responseModel.DserviceId })
                    : await _caseService.GetStagesNextByServiceIdAsync(new List<Guid>() { responseModel.DserviceId }));
                }

                if (responseModel.CreateCaseStatus.IsCreated == false)
                {
                    ShowError(responseModel.CreateCaseStatus.Message ?? "Ошибка сервера");
                    return Problem(responseModel.CreateCaseStatus.Message);
                };

                return PartialView("Create/Final", responseModel);
            }
            catch
            {
                ShowError("Ошибка сервера");
                return Problem("Ошибка сервера");
            }
        }

        public async Task<IActionResult> GetServicesDataJson(IDataTablesRequest request, SearchCasesRequestData additionalRequest)
        {
            var services = await _caseService.GetActiveServices(additionalRequest, request.Start, request.Length);

            var response = DataTablesResponse.Create(request, services.Item2, services.Item3, services.Item1);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> GetServiceProceduresDataJson(IDataTablesRequest request, Guid serviceId)
        {
            var procedure = await _caseService.GetServiceProcedures(serviceId);

            var response = DataTablesResponse.Create(request, procedure.Count, procedure.Count, procedure);

            return new DataTablesJsonResult(response, true);
        }

        public async Task<IActionResult> GetServiceTariffDataJson(IDataTablesRequest request, Guid procedureId, int? type)
        {
            var tariff = await _caseService.GetServiceTariff(procedureId, type);

            var response = DataTablesResponse.Create(request, tariff.Count, tariff.Count, tariff);

            return new DataTablesJsonResult(response, true);
        }

    }
}
