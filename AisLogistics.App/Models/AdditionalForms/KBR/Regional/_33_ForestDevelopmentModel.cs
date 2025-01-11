namespace AisLogistics.App.Models;

/// <summary>
/// Проведение государственной экспертизы проектов освоения лесов
/// </summary>
public class _33_ForestDevelopmentModel
{
    /// <summary>
    /// Председатель ФИО
    /// </summary>
    public string FIOChairman { get; set; }

    /// <summary>
    /// договора  аренды  или  права  постоянного  (бессрочного) пользования лесным участком
    /// Дата регистрации  договора
    /// </summary>
    public string DateRegistrationAgreement { get; set; }

    /// <summary>
    /// номер регистрации  договора
    /// </summary>
    public string NumberRegistrationAgreement { get; set; }

    /// <summary>
    /// Местоположение
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// площадь лесного участка
    /// </summary>
    public string AreaForestPlot { get; set; }

    /// <summary>
    /// вид
    /// </summary>
    public string Type {  get; set; }

    /// <summary>
    /// срок использования
    /// </summary>
    public string PeriodUse {  get; set; }

    /// <summary>
    /// полное наименование банка
    /// </summary>
    public string NameBank {  get; set; }

    /// <summary>
    /// номер расчетного счета
    /// </summary>
    public string AccountNumber {  get; set; }

    /// <summary>
    /// номер корреспондентского счета
    /// </summary>
    public string CorrespondentNumber {  get; set; }

    /// <summary>
    /// БИК
    /// </summary>
    public string BIK {  get; set; }

    /// <summary>
    /// юридический адрес
    /// </summary>
    public string LegalAdress {  get; set; }

    /// <summary>
    /// фактический адрес
    /// </summary>
    public string FaktAdress {  get; set; }

    /// <summary>
    /// тип заявителя
    /// </summary>
    public string TypeAppliccant {  get; set; } 
}