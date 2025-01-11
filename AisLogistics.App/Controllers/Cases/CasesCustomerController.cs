using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Identity.Applicant;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.App.ViewModels.ModelBuilder;
using AisLogistics.DataLayer.Common.Dto.Case;
using AisLogistics.DataLayer.Entities.Models;

namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task<IActionResult?> ServiceCustomerAddModal(Guid id, SubjectCustomerType subjectCustomerType, ActionType actionType)
        {
            ViewBag.Id = id;
            object? customer = subjectCustomerType == SubjectCustomerType.Physical ?
                await _caseService.GetCustomerByIdAsync(id) :
                await _caseService.GetCustomerLegalByIdAsync(id);

            if (customer == null)
            {
                ShowError("Данные не найдены");
                return null;
            }
            var modelBuilder = new ModalViewModelBuilder()
                .AddModalType(ModalType.LARGE)
                .AddModalViewPath(subjectCustomerType == SubjectCustomerType.Physical ?
                    "Details/Modals/_ModalCustomerAdd" :
                    "Details/Modals/_ModalCustomerLegalAdd")
                .AddModalTitle("Изменение заявителя")
                .AddModel(customer);
            return ModalLayoutView(modelBuilder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceCustomerSave(CustomerServiceModelDto customer, bool isGetCustomerSnils, bool isGetCustomerInn)
        {
            var response = await _caseService.UpdateCustomerAsync(customer);
            if (response.ResponseStatus.IsSuccess) 
            {
                var service = await _caseService.GetCasesServicesParentAsync(customer.DCasesId);
                if (isGetCustomerSnils && string.IsNullOrEmpty(customer.CustomerSnils))
                {
                    if(service is not null)
                        await _smevService.GetCustomerSnils(service.Id, customer);
                }
                if (isGetCustomerInn && string.IsNullOrEmpty(customer.CustomerInn))
                {
                    if (service is not null)
                        await _smevService.GetCustomerInn(service.Id, customer);
                }
                ShowSuccess(MessageDescription.EditSuccess); 
            }
            else ShowError(MessageDescription.Error);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task ServiceCustomerLegalSave(DServicesCustomersLegal customerLegal)
        {
            var response = await _caseService.UpdateCustomerLegalAsync(customerLegal);
            if (response.ResponseStatus.IsSuccess) ShowSuccess(MessageDescription.EditSuccess);
            else ShowError(MessageDescription.Error);
        }

        public Task<CustomerModelDto?> FindCustomerByDocumentDataJson(string serial, string number)
        {
            return _caseService.GetCustomerByDocumentSerialAndNumberAsync(serial, number);
        }
        public Task<LegalsDto?> FindLegalByInnDataJson(string inn)
        {
            return _caseService.GetLegalByInnAsync(inn);
        }
    }
}
