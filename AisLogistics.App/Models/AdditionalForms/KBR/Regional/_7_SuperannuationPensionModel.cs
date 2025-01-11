namespace AisLogistics.App.Models;

/// <summary>
/// Назначение и выплата пенсии за выслугу лет
/// </summary>
public class _7_SuperannuationPensionModel
{
    /// <summary>
    /// от
    /// </summary>
    public string FIOGen { get; set; }

    /// <summary>
    /// Страховую пенсию
    /// </summary>
    public string InsurancePension { get; set; }

    /// <summary>
    /// Отделении Пенсионного фонда (города, района)
    /// </summary>
    public string DepartmentPensionFund { get; set; }

    /// <summary>
    /// Способ выплаты
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// Номер банковской карты
    /// </summary>
    public string BankCardNumber { get; set; }

    /// <summary>
    /// Номер банковской карты
    /// </summary>
    public string NameCreditOrgan { get; set; }

    /// <summary>
    /// адрес почтового отделения
    /// </summary>
    public string PostOffice { get; set; }
      
    /// <summary>
    /// Результат рассмотрения заявления прошу
    /// </summary>
    public string Response { get; set; }
     
    /// <summary>
    /// Результат рассмотрения заявления прошу
    /// </summary>
    public string ResponseAddress1 { get; set; }
    public string ResponseAddress2 { get; set; }
    public string ResponseAddress3 { get; set; }
}
