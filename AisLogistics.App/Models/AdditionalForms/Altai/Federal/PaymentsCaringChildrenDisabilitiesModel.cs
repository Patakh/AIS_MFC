namespace AisLogistics.App.Models
{
    public class PaymentsCaringChildrenDisabilitiesModel
    {
        public PaymentsCaringChildrenDisabilitiesModel()
        {
            Fio = new Fio();
            AddressResidence = new Address();
            AddressStay = new Address();
            AddressActual = new Address();
            PersonelDocument = new PersonelDocument();
            FioDisabledChild = new Fio();
            Representative = new Representative
            {
                AddressResidence = new Address(),
                AddressStay = new Address(),
                AddressActual = new Address(),
                PersonelDocument = new PersonelDocument(),
                DocumentConfirmingOfRepresentative = new PersonelDocument()
            };
            AppliedDocumentList = new[]
            {
            new AppliedDocument()
        };
        }
        public Fio Fio { get; set; }
        public string Snils { get; set; }
        public Address AddressResidence { get; set; }
        public Address AddressStay { get; set; }
        public Address AddressActual { get; set; }
        public string Phone { get; set; }
        public PersonelDocument PersonelDocument { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? StartDateOfCare { get; set; }
        public Fio FioDisabledChild { get; set; }
        public int AnAdult { get; set; }
        public int InRelationDisabledChild { get; set; }
        public bool IsWorking { get; set; }
        public bool IsReceivePaymentsForDisabledChild { get; set; }
        public bool IsReceivePension { get; set; }
        public bool IsReceiveUnemploymentBenefits { get; set; }
        public bool IsStudying { get; set; }
        public Representative Representative { get; set; }
        public string IWarned { get; set; }
        public AppliedDocument[] AppliedDocumentList { get; set; }
        public bool SendNotification { get; set; }
        public string EmailForNotification { get; set; }
        public bool CarryOutInformation { get; set; }
        public bool OnEmail { get; set; }
        public string EmailForInformation { get; set; }
        public bool OnPhone { get; set; }
        public string PhoneForInformation { get; set; }
    }

    public class Fio
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
    public class Address
    {
        public string FiasHouseCode { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Building { get; set; }
        public string Apartmen { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
    }

    public class Representative
    {
        public Fio Fio { get; set; }
        public Address AddressResidence { get; set; }
        public Address AddressStay { get; set; }
        public Address AddressActual { get; set; }
        public string Phone { get; set; }
        public PersonelDocument PersonelDocument { get; set; }
        public PersonelDocument DocumentConfirmingOfRepresentative { get; set; }

    }

    public class PersonelDocument
    {
        public string DocType { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string IssuedBy { get; set; }
    }
    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }
    }
}

