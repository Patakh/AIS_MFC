using Newtonsoft.Json;
using System.ComponentModel;

using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Прием сообщения о наличии объектов недвижимого имущества и (или) транспортных средств,
/// признаваемых объектами налогообложения по соответствующим налогам, уплачиваемым физическими лицами.
/// </summary>
public class _20_AvailabilityObjectsModel : AbstractAdditionalFormModel
{
    public _20_AvailabilityObjectsModel()
    {
        RealEstateList = new[] {
            new RealEstateType()
        };
        VehicleList = new[]{
            new VehicleType()
        }; CustomerFio = new();
        RepresentativeFio = new();
    }

    /// <summary>
    /// Тип заявителя
    /// </summary>
    public string CustomerType { get; set; }

    /// <summary>
    /// ФИО заявителя
    /// </summary>
    public FioType CustomerFio { get; set; }

    /// <summary>
    /// ФИО представителя
    /// </summary>
    public FioType RepresentativeFio { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string Inn { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public string BirthPlace { get; set; }

    /// <summary>
    /// Код вида документа
    /// </summary>
    public string DocCode { get; set; }

    /// <summary>
    /// Серия и номер документа
    /// </summary>
    public string DocSeriesNumber { get; set; }

    /// <summary>
    /// Дата выдачи документа
    /// </summary>        
    public DateTime? DocIssueDate { get; set; }

    /// <summary>
    /// Кем выдан документ
    /// </summary>
    public string DocIssuer { get; set; }

    /// <summary>
    /// Номер контактного телефона
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Объекты недвижимости
    /// </summary> 
    public RealEstateType[] RealEstateList { get; set; }

    /// <summary>
    /// Транспортные средства
    /// </summary>
    public VehicleType[] VehicleList { get; set; }
      
    public class RealEstateType
    {
        /// <summary>
        /// Тип объекта недвижимости
        /// </summary>            
        public string Type { get; set; }

        /// <summary>
        /// Тип номера (1- кадастровый, 2 - условный, 3 - инвентарный)
        /// </summary>            
        public string NumberType { get; set; }

        /// <summary>
        /// Номер ОН
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Вид правоустанавливающего (правоудостоверяющего) документа
        /// </summary>
        public string RightDocType { get; set; }

        /// <summary>
        /// Иной вид правоустанавливающего документа
        /// </summary>
        public string RightDocOther { get; set; }

        /// <summary>
        /// Орган, выдавший правоустанавливающий (правоудостоверяющий) документ
        /// </summary>
        public string RightDocIssuer { get; set; }

        /// <summary>
        /// Дата регистрации (возникновения) права
        /// </summary>
        public string RightRegDate { get; set; }

        /// <summary>
        /// Дата прекращения права
        /// </summary>
        public string RightStopDate { get; set; }
    }

    public class VehicleType
    {
        /// <summary>
        /// Тип транспортного средства
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Иной вид транспортного средства
        /// </summary>
        public string TypeOther { get; set; }

        /// <summary>
        /// Реквизиты ТС (серия и номер)
        /// </summary>
        public string SeriesNumber { get; set; }

        /// <summary>
        /// Реквизиты ТС (дата выдачи)
        /// </summary>
        public string IssueDate { get; set; }

        /// <summary>
        /// Идентификационный номер TC
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Марка (модель) ТС
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Регистрационный знак ТС
        /// </summary>
        public string RegSign { get; set; }

        /// <summary>
        /// Дата регистрации ТС
        /// </summary>
        public string RegDate { get; set; }

        /// <summary>
        /// Дата снятия с учета ТС
        /// </summary>
        public string RegRemoveDate { get; set; }

        /// <summary>
        /// Серия и номер документа, подтверждающего регистрацию ТС
        /// </summary>
        public string RegDocSeriesNumber { get; set; }

        /// <summary>
        /// Дата выдачи документа, подтверждающего регистрацию ТС
        /// </summary>
        public string RegDocIssueDate { get; set; }
    }
}
