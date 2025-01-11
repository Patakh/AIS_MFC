using AisLogistics.App.Models;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult> ServicePaymentsCompleted(Guid id)
        {
            ViewBag.Id = id;
            var smevСompleted = await _caseService.GetPaymentsСompletedByServiceIdAsync(id);
            var modelBuilder = new ViewModelBuilder()
                .AddViewTitle("Оплата")
                .AddModel(smevСompleted);
            return PartialView("Details/Sidebar/_SidebarPaymentsCompleted", modelBuilder);
        }

        public async Task<IActionResult> ServicePaymentsCreate(Guid id)
        {
            var officeId = await _employeeManager.GetOfficeAsync();
            var service = await _caseService.GetPaymentsInfoServiceIdAsync(id);
            var customers = await _caseService.GetCustomersByCaseNumberAsync(service.DCaseId);
            var acquirings = await _referencesService.GetTerminalsByOffice(officeId);
            var benificiary = await _referencesService.GetRecipientPaymentByProviders(service.SOfficesIdProvider, officeId);

            var model = new PaymentsCreateResponseModel()
            {
                DCaseId = service.DCaseId,
                DServicesId = service.DServicesId,
                SOfficesIdProvider = service.SOfficesIdProvider,
                ServiceName = service.ServiceName,
                TariffState = service.TariffState,
                TariffMfc = service.TariffMfc,
                CustomerPayments = new SelectList(customers, "Id", "Name"),
                DAcquirings = new SelectList(acquirings, "Id", "Name"),
                PaymentBeneficiaries = new SelectList(benificiary, "Id", "Name")
            };

            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.SMALL)
                .AddModalTitle("Добавление платежа")
                .AddModalViewPath("Details/Modals/_ModalPaymentsCreate")
                .AddModel(model);
            return ModalLayoutView(modelBuilder);
        }
    }
}
