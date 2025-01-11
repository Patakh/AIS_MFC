namespace AisLogistics.App.Models.AdditionalForms
{
    // Документ не заполняется, если указан ИНН
    public class PfrEightToSeventeenModel : AbstractAdditionalFormModel
    {
        public PfrEightToSeventeenModel()
        {
            Applicant = new ApplicantType
            {
                Address = new Address(),
                Child = new Child[]
                {
                    new()
                    {
                        fio = new Fio(),
                    }
                },
                DisabledChild = new DisabledChild[]
                {
                    new()
                    {
                        Fio = new Fio(),
                    }
                },
                fio = new Fio(),                
            };
            Payment = new PaymentType
            {
                Address = new Address(),
            };
            Spouse = new SpouseType
            {
                Address = new Address(),
                fio = new Fio(),
                DisabledChild = new DisabledChild[]
                {
                    new()
                    {
                        Fio = new Fio()
                    }
                }                
            };
            AdditionalFamilyInformation = new AdditionalFamilyInformationType();
        }

        public class ApplicantType
        {
            public Fio fio { get; set; }
            public string BirthDate { get; set; }
            public string BirthPlace { get; set; }
            public string Citizenship { get; set; }
            public string Snils { get; set; }
            public Address Address { get; set; }
            public string DocType { get; set; }
            public string Jail { get; set; }
            public string CityPunishServed { get; set; }
            public string Series { get; set; }
            public string Number { get; set; }
            public string IssuedDate { get; set; }
            public string IssuedBy { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string WorkedInPowerStructures { get; set; }
            public string WorkedInPowerStructuresInn { get; set; }
            public string MarriageStatus { get; set; }
            public string MarriageDivorcedForeignStatus { get; set; }
            public string MarriageRegNumber { get; set; }
            public string MarriageRegDate { get; set; }
            public string MarriageRegName { get; set; }
            public string MarriageDeadNumber { get; set; }
            public string MarriageDeadDateReg { get; set; }
            public string MarriageDeadName { get; set; }
            public string MarriageDeadLastName { get; set; }
            public string MarriageDeadFirstName { get; set; }
            public string MarriageDeadSecondName { get; set; }
            public string MarriageDeadDate { get; set; }
            public string AlimonySum { get; set; }
            public bool AlimonyStatus { get; set; }
            public bool DisabledChildStatus { get; set; }
            public bool WorkedInPowerStructuresStatus { get; set; }
            public bool Pregnancy { get; set; }
            public bool JailStatus { get; set; }
            public bool IsCityPunishServed { get; set; }
            public DisabledChild[] DisabledChild { get; set; }
            public Child[] Child { get; set; }
        }

        public ApplicantType Applicant { get; set; }
        public PaymentType Payment { get; set; }
        public SpouseType Spouse { get; set; }
        public string RegionCode { get; set; }
        public string DistrictRequest { get; set; }
        public AdditionalFamilyInformationType AdditionalFamilyInformation { get; set; }
        public string RegisterNumber { get; set; }
        public string DateApplication { get; set; }
        public string CaseId { get; set; }

        public class Fio
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
        }
        public class DisabledChild
        {
            public Fio Fio { get; set; }
            public string BirthDate { get; set; }
            public string Snils { get; set; }
        }

        public class Child
        {
            public Fio fio { get; set; }
            public string Snils { get; set; }
            public string Attitude { get; set; }
            public string ActBirthNumber { get; set; }
            public string ActBirthDate { get; set; }
            public string ActBirthName { get; set; }
            public string MarriageRegName { get; set; }
            public string MarriageRegDate { get; set; }
            public string MarriageRegNumber { get; set; }
            public string Citizenship { get; set; }
            public string DataBirth { get; set; }
            public string DocType { get; set; }
            public string Series { get; set; }
            public string Number { get; set; }
            public string IssuedDate { get; set; }
            public string IssuedBy { get; set; }
            public string BirthPlace { get; set; }
            public string IsEducation { get; set; }
            public string IsParent { get; set; }
            public string JailStatus { get; set; }
            public string IsCityPunishServed { get; set; }
            public string Jail { get; set; }
            public string CityPunishServed { get; set; }
        }

        public class PaymentType
        {
            public string Type { get; set; }
            public string BankName { get; set; }
            public string BankBik { get; set; }
            public string BankInn { get; set; }
            public string BankScore { get; set; }
            public string BankNumber { get; set; }
            public Address Address { get; set; }
            public string BankAddressMatches { get; set; }
        }

        public class Processing
        {
            public string FIO { get; set; }
            public string Snils { get; set; }
            public string Related { get; set; }
            public string IssueBody { get; set; }
            public string DataBirth { get; set; }
            public string Citizenship { get; set; }
            public string Adress { get; set; }
            public string DocInfo { get; set; }
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

        public class SpouseType
        {
            public Fio fio { get; set; }
            public string BirthDate { get; set; }
            public string BirthPlace { get; set; }
            public string Citizenship { get; set; }
            public string Snils { get; set; }
            public string DocType { get; set; }
            public string Series { get; set; }
            public string Number { get; set; }
            public string IssuedDate { get; set; }
            public string IssuedBy { get; set; }
            public string DeadDate { get; set; }
            public string AlimonySum { get; set; }
            public string WorkedInPowerStructures { get; set; }
            public string Jail { get; set; }
            public string CityPunishServed { get; set; }
            public bool Pregnancy { get; set; }
            public bool AlimonyStatus { get; set; }
            public bool WorkedInPowerStructuresStatus { get; set; }
            public bool JailStatus { get; set; }
            public bool IsCityPunishServed { get; set; }
            public string WorkedInPowerStructuresInn { get; set; }
            public bool DisabledChildStatus { get; set; }
            public DisabledChild[] DisabledChild { get; set; }
            public Address Address { get; set; }
        }

        public class AdditionalFamilyInformationType
        {
            public bool Served { get; set; }
            public bool Pgob { get; set; }
            public bool Str { get; set; }
            public bool Sat { get; set; }
            public bool Sd { get; set; }
            public bool Szy { get; set; }
            public bool Szp { get; set; }
            public bool Skv { get; set; }
            public bool Ja { get; set; }
            public bool Large { get; set; }
            public bool Dzpf { get; set; }
            public bool lechTwoM { get; set; }
            public bool GosConR { get; set; }
            public bool Szyn { get; set; }
            public bool SudV { get; set; }
            public bool Scholarship { get; set; }
            public bool Smc { get; set; }
            public bool Adms { get; set; }
            public bool Pums { get; set; }
            public bool AtTheCallPeriodThree { get; set; }
            public bool Pl { get; set; }
            public bool Obuch { get; set; }
            public bool Sue { get; set; }
            public bool Asnp { get; set; }
            public bool Suelw { get; set; }
            public bool Polsg { get; set; }

        }

        public class ChildUhod
        {
            public string FIO { get; set; }
        }

        public class getTestRequest
        {
            public ApplicantType Applicant { get; set; }
            public PaymentType Payment { get; set; }
            public SpouseType Spouse { get; set; }
            public string RegionCode { get; set; }
            public string DistrictRequest { get; set; }
            public AdditionalFamilyInformationType AdditionalFamilyInformation { get; set; }
            public string RegisterNumber { get; set; }
            public string DateApplication { get; set; }
            public string CaseId { get; set; }
        }

        public static string DicMarriageStatus(string key)
        {
            string reques;
            switch (key)
            {
                case "married":
                    reques = "Состою в браке";
                    break;
                case "divorced":
                    reques = "В разводе";
                    break;
                case "widower":
                    reques = "Вдовец (вдова)";
                    break;
                case "not":
                    reques = "В браке никогда не состоял(а)";
                    break;
                default:
                    reques = "Не заданно";
                    break;
            }
            return reques;
        }

        public static string DicWorkedInPowerStructures(string key)
        {
            string reques;
            switch (key)
            {
                case "ministryOfDefense":
                    reques = "Служба в Минобороны (включая ВС РФ, ГУ ГШ ВС РФ), Росгвардии, ФССП, ФТС, ГУСП РФ ";
                    break;
                case "other":
                    reques = "Служба в ФСИН, ФСБ, ФСО, МВД РФ";
                    break;
                default:
                    reques = "";
                    break;
            }
            return reques;
        }
    }
}
