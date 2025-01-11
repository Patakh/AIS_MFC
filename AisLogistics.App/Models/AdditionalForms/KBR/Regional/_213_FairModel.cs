using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Выдача разрешений на участие в муниципальных ярмарках на территории городского округа Нальчик
/// </summary>
public class _213_FairModel : AbstractAdditionalFormModel
{
    public _213_FairModel()
    {
        AppliedDocumentList = new []
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    /// Первый заместитель Главы местной администрации городского округа Нальчик
    /// </summary>
    public string Vice { get; set; }

    /// <summary>
    /// Дата регистрации постоянного адреса
    /// </summary>
    public string DateRegistration { get; set; } 

    /// <summary>
    /// Серия и № свидетельства
    /// </summary>
    public string SeriesNumber { get; set; }

    /// <summary>
    /// Дата постановки на учет в ИФНС РФ
    /// </summary>
    public string DateRegistrationFNS { get; set; }  

    /// <summary>
    /// Адрес ярмарки
    /// </summary>
    public string AddressFair { get; set; }

    /// <summary>
    /// Дата участия
    /// </summary>
    public string DateFair { get; set; }

    /// <summary>
    /// с часов
    /// </summary>
    public string FairStartHour { get; set; }

    /// <summary>
    /// до часов
    /// </summary>
    public string FairStopHour { get; set; }

    /// <summary>
    /// Виды и наименования товаров (работ, услуг)
    /// </summary>
    public string TypesGoods { get; set; }

    /// <summary>
    /// Использование транспортного средства
    /// </summary>
    public string UseVehicle { get; set; }

    /// <summary>
    /// Способ предоставления ответа при личном обращении в местную администрацию
    /// </summary>
    public string ResponseType { get; set; }

    /// <summary>
    /// на адрес
    /// </summary>
    public string ResponseAdress { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }
    }
}
