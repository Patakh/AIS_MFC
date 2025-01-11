
using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Рассмотрение заявления о распоряжении средствами (частью средств) материнского (семейного) капитала.
/// Рассмотрение заявления о распоряжении получения ежемесячной выплаты до достижения ребенком возраста трех лет
/// </summary>
public class _41_4_OrderMonthlyPaymentModel : AbstractAdditionalFormModel
{

    public _41_4_OrderMonthlyPaymentModel()
    {
        Applicant = new ApplicantType
        {
            Address = new Address(),
            Child = new Child[]
            {
                    new()
                    {
                        FIO = new Fio(),
                    }
            },
        };
        Payment = new PaymentType
        {
            Address = new Address(),
        };
        Spouse = new SpouseType
        {
            Address = new Address(),
            FIO = new Fio(),
        };
        AdditionalFamilyInformation = new AdditionalFamilyInformationType();
    }

    public class ApplicantType
    { 
        public string ForignActRip { get; set; }
        public string NumberActRip { get; set; }
        public string DateActRip { get; set; }
        public string OrgaActRip { get; set; }
        public string ForignActRegistration { get; set; }
        public Address Address { get; set; }     
        public string WorkedInPowerStructures { get; set; }
        public string WorkedInPowerStructuresInn { get; set; }
        public string MarriageStatus { get; set; } 
        public string MarriageRegNumber { get; set; }
        public string MarriageRegDate { get; set; }
        public string MarriageRegName { get; set; }  
        public Child[] Child { get; set; }
    }

    public ApplicantType Applicant { get; set; }
    public PaymentType Payment { get; set; }
    public SpouseType Spouse { get; set; }  
    public AdditionalFamilyInformationType AdditionalFamilyInformation { get; set; }
    public string RegisterNumber { get; set; }
    public string DateApplication { get; set; }
    public string TypeStipend { get; set; }
    public string CaseId { get; set; }

    public class Fio
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    } 

    public class Child
    {
        public Fio FIO { get; set; }
        public string Snils { get; set; } 
        public string ActBirthNumber { get; set; }
        public string ActBirthDate { get; set; }
        public string ActBirthName { get; set; } 
        public string Citizenship { get; set; }
        public string ActBirthForign { get; set; }
        public string GuardianshipForign { get; set; }
        public string ThisIsChild { get; set; }
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
        public Fio FIO { get; set; }
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
        public bool IsCityPunishServed { get; set; }
        public string WorkedInPowerStructuresInn { get; set; } 
        public Address Address { get; set; }
    }

    public class AdditionalFamilyInformationType
    {
        public bool Served { get; set; }
        public bool Pgob { get; set; } 
        public bool Dzpf { get; set; } 
        public bool GosConR { get; set; }
        public bool Szyn { get; set; } 
        public bool Scholarship { get; set; } 
        public bool Adms { get; set; }
        public bool Pums { get; set; } 
        public bool Pl { get; set; }
        public bool Obuch { get; set; } 
        public bool Polsg { get; set; }
        public bool SumAlim { get; set; } 
    }
}