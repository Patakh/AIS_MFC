using AisLogistics.App.Models.DTO.Cases;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev
{
    public partial class SmevBaseController
    {
        [HttpPost]
        public async Task<ActionResult> CasePaymentAddSberInit(ServicePaymentsRequestModelAddDto model)
        {
            model.SEmployeesId = (Guid)await _employeeManager.GetIdAsync();
            model.SOfficesId = (Guid)await _employeeManager.GetOfficeAsync();

            if (model.SRecipientPaymentId.HasValue)
            {
                var service = await _caseService.GetPaymentsInfoServiceIdAsync(model.DServicesId);

                if (service is null) return NotFound("Услуга не найдена");

                model.Summ = model.TypePaymet == 1 ? service.TariffState : service.TariffMfc;
            }

            var data_acquiring_id = await _caseService.AddServicePaymentAsync(model);

            if (data_acquiring_id == null) return Problem("Ошибка Сервера");

            var payResponce = _smevService.SberHybridInitiatePayment(new SberHybridInitiatePaymentRequestData { DataAcquiringId = data_acquiring_id.ToString() });

            if (payResponce.Fault != null) return Problem("Ошибка при инициализации платежв");

            return Ok(data_acquiring_id);
        }

        [HttpPost]
        public IActionResult CasePaymentAddSberPayment(Guid id)
        {
            bool isChecks = _caseService.IsCheckServicePaymentAsync(id);

            return isChecks ? Ok(id) : Problem("Ошибка при оплате");
        }

        public ActionResult<string> CasePaymentInvoiceSber(Guid id)
        {
            var payQuittance = _smevService.SberHybridGetQuittance(new SberHybridGetQuittanceRequestData { DataAcquiringId = id.ToString() });
            if (payQuittance.Fault != null) return Problem("Ошибка при формирование квитанции");

            return Convert.ToBase64String(payQuittance.QuittancePdf, 0, payQuittance.QuittancePdf.Length);
        }

    }
}
