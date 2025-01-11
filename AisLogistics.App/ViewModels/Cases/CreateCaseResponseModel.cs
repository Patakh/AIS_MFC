using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;
using Newtonsoft.Json;

namespace AisLogistics.App.ViewModels.Cases
{
    public class CreateCaseResponseModel
    {
        public CreateCaseResponseModel CreatedSuccess()
        {
            CreateCaseStatus = new CreateCaseStatus(true);
            return this;
        }
        public CreateCaseResponseModel SetCaseId(string caseId)
        {
            CaseId = caseId;
            return this;
        }
        public CreateCaseResponseModel SetDserviceId(Guid id)
        {
            DserviceId = id;
            return this;
        }

        public CreateCaseResponseModel SetService(string service)
        {
            Service = service;
            return this;
        }

        public CreateCaseResponseModel SetProcedure(string procedure)
        {
            Procedure = procedure;
            return this;
        }

        public CreateCaseResponseModel SetOfficeIdAdd(Guid id)
        {
            SOfficeIdAdd = id;
            return this;
        }

        public CreateCaseResponseModel SetOfficeId(Guid id)
        {
            SOfficeId = id;
            return this;
        }

        public CreateCaseResponseModel SetOffice(string office)
        {
            Office = office;
            return this;
        }
        public CreateCaseResponseModel SetTariff(decimal tariff)
        {
            Tariff = tariff;
            return this;
        }
        public CreateCaseResponseModel SetCustomerType(SubjectCustomerType customerType)
        {
            CustomerType = customerType;
            return this;
        }
        public CreateCaseResponseModel SetCustomerId(Guid customerId)
        {
            CustomerId = customerId;
            return this;
        }
        public CreateCaseResponseModel SetCustomer(string customer)
        {
            Customer = customer;
            return this;
        }
        public CreateCaseResponseModel SetRecipientId(Guid recipientId)
        {
            RecipientId = recipientId;
            return this;
        }
        public CreateCaseResponseModel SetRecipient(string recipient)
        {
            Recipient = recipient;
            return this;
        }
        public CreateCaseResponseModel SetEmployee(string employee)
        {
            Employee = employee;
            return this;
        }
        public CreateCaseResponseModel SetEmployeeId(Guid employeeId)
        {
            EmployeeId = employeeId;
            return this;
        }
        public CreateCaseResponseModel SetDataReg(DateTime dataReg)
        {
            DataReg = dataReg;
            return this;
        }
        public CreateCaseResponseModel CreatedError(string? message)
        {
            CreateCaseStatus = new CreateCaseStatus(false, message);
            return this;
        }


        public CreateCaseResponseModel Debug()
        {
            CreateCaseStatus = new CreateCaseStatus(true);
            CaseId = "00000000000001";
            Customer = "Магомедов Магомед Магомедович";
            Employee = "Магомедов Магомед Магомедович";
            Service = "Тестовая услуга МФЦ РД";
            Tariff = 35000;
            DataReg = DateTime.Now;
            return this;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(new
            {
                CreateCaseStatus,
                CaseId,
                DserviceId,
                Service,
                Tariff,
                Customer,
                Employee,
                DataReg
            }, Formatting.Indented);
        }

        public string CaseId { get; set; }
        public Guid DserviceId { get; set; }
        public Guid SOfficeIdAdd { get; set; }
        public Guid SOfficeId { get; set; }
        public string Service { get; set; }
        public string Procedure { get; set; }
        public string Office { get; set; }
        public decimal Tariff { get; set; }
        public SubjectCustomerType CustomerType { get; set; }
        public Guid CustomerId { get; set; }
        public string Customer { get; set; }
        public Guid RecipientId { get; set; }
        public string Recipient { get; set; }
        public Guid EmployeeId { get; set; }
        public string Employee { get; set; }
        public DateTime? DataReg { get; set; }
        public CreateCaseStatus CreateCaseStatus { get; set; }
        public List<StageDto> CreateCaseStagesNext { get; set; } = new List<StageDto>();
    }

    public class CreateCaseStatus
    {
        public CreateCaseStatus(bool isCreated, string? message = null)
        {
            IsCreated = isCreated;
            Message = message;
        }
        public bool IsCreated { get; set; }
        public string? Message { get; set; }
    }
}
