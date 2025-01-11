namespace AisLogistics.App.Models;

/// <summary>
/// Назначение ежемесячной денежной выплаты
/// Подача заявления о доставке социальных выплат (ежемесячной денежной выплаты)
/// </summary>
public class _41_7_PfrAppointMonthlyCashPaymentsModel : AbstractAdditionalFormModel
{
    public _41_7_PfrAppointMonthlyCashPaymentsModel()
    {
        Customer = new CustomerType();
        Representative = new RepresentativeType(); 
    }

    /// <summary>
    /// Заявитель
    /// </summary>
    public CustomerType Customer { get; set; }

    /// <summary>
    /// Представитель
    /// </summary>
    public RepresentativeType Representative { get; set; }

    /// <summary>
    /// вид выплаты
    /// </summary>
    public string TypePayCategory { get; set; }

    /// <summary>
    /// c кого (месяц, год)
    /// </summary>
    public string PayDate { get; set; }

    /// <summary>
    /// через организацию
    /// </summary>
    public string PayOrganizationType { get; set; }

    /// <summary>
    /// полное наименование организации
    /// </summary>
    public string OrganizationName { get; set; }

    /// <summary>
    ///  адрес организации
    /// </summary>
    public string OrganizationAdress{ get; set; }

    /// <summary>
    /// реквизиты
    /// </summary>
    public string OrganizationRekvisits{ get; set; }
     
    public class CustomerType
    {
        /// <summary>
        /// Адрес места пребывания
        /// </summary>
        public string StayAddress { get; set; }

        /// <summary>
        /// Адрес фактического проживания
        /// </summary>
        public string ActualResidenceAddress { get; set; }

        /// <summary>
        /// Фамилия, которая была при рождении
        /// </summary>
        public string LastNameBirth { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        public string Citizenship { get; set; }
    }
     
    public class RepresentativeType
    { 
        /// <summary>
        /// Место нахождения организации
        /// </summary>
        public string OrganizationLocation { get; set; }

        /// <summary>
        /// Адрес места пребывания да конечно
        /// </summary>
        public string StayAddress { get; set; }

        /// <summary>
        /// Адрес фактического проживания
        /// </summary>
        public string ActualResidenceAddress { get; set; }
    }
}