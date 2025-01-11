namespace AisLogistics.App.Models;

/// <summary> 
/// Установление ежемесячной денежной выплаты отдельным категориям граждан в Российской Федерации
///  
/// </summary>
public class _41_2_PfrAppointMonthlyCashPaymentsModel
{
    /// <summary>
    /// с 1 января 20__ года
    /// </summary>
    public string DateStart { get; set; }

    /// <summary>
    /// за счет 
    /// </summary>
    public string Cost { get; set; }

    /// <summary>
    /// набор социальных услуг, предусмотренных частью 1 статьи 6.2 Федерального закона
    /// от 17 июля 1999 г. № 178-ФЗ «О государственной социальной помощи»
    /// </summary>
    public bool Service1 { get; set; }

    /// <summary> 
    /// социальную услугу, предусмотренную пунктом 1 части 1 статьи 6.2 Федерального закона
    ///  от 17 июля 1999 г. № 178-ФЗ
    /// </summary>
    public bool Service2 { get; set; }

    /// <summary>
    /// социальную услугу, предусмотренную пунктом 1.1 части 1 статьи 6.2 Федерального закона
    /// от 17 июля 1999 г. № 178-ФЗ
    /// </summary>
    public bool Service3 { get; set; }

    /// <summary>
    /// социальную услугу, предусмотренную пунктом 2 части 1 статьи 6.2 Федерального закона
    /// от 17 июля 1999 г. № 178-ФЗ
    /// </summary>
    public bool Service4 { get; set; } 
}