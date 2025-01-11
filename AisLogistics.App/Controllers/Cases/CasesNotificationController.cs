using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult> DetailsNotification(string id)
        {
            ViewBag.Id = id;
            var notifications = await _caseService.GetNotificationsByCaseIdAsync(id);

            var modelBuilder = new ModalViewModelBuilder()
              .AddModalType(ModalType.EXTRA)
              .AddModalViewPath("Details/Notification")
              .AddModel(notifications)
              .HideSubmitButton()
              .AddModalTitle("Оповещение");

            return ModalLayoutView(modelBuilder);
        }

        public async Task<IActionResult> CasesSMSAddModal(CasesSMSAddDto model)
        {
            var modelBuilder = new ModalViewModelBuilder()
              .AddModalType(ModalType.SMALL)
                .AddModalViewPath("Details/Modals/_ModalSMSAdd")
                .AddModalTitle("Добавление СМС")
                .AddModel(new CasesSMSSaveDto
                {
                    CasesId = model.CasesId,
                    CustomerName = model.CustomerName,
                    CustomerPhone = model.CustomerPhone,
                });

            return await Task.Run(() => ModalLayoutView(modelBuilder));
        }

        public async Task<IActionResult> SMSCasesSave(CasesSMSSaveDto request)
        {
            var employee = await _employeeManager.GetFullInfoAsync();
            var response = await _caseService.SaveSMSCaseAsync(request, employee);
            if (response) ShowSuccess("СМС добавлен");
            else ShowError("При отправке СМС произошла ошибка");
            return await Details(request.CasesId);
        }

        [HttpGet]
        public async Task<string> CallPhoneV3(string caseid, Guid customerId, string phone)
        {
            var lineCALL = await _caseService.AddNotificationsByCaseIdAsync(caseid, customerId, phone);
            if (string.IsNullOrEmpty(lineCALL)) ShowError("Вызов не выполнен");
            return lineCALL;
        }
    }
}
