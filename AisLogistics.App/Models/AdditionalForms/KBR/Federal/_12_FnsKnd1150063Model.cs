using DocumentFormat.OpenXml.Drawing.Charts;

namespace AisLogistics.App.Models;

/// <summary>
/// Прием заявления физического лица о предоставлении налоговой льготы по транспортному налогу,
/// земельному налогу, налогу на имущество физических лиц
/// </summary>
public sealed class _12_FnsKnd1150063Model : AbstractAdditionalFormModel
{
    /// <summary>
    /// Код налогового органа
    /// </summary>
    public string CodeFNS { get; set; }

    /// <summary>       
    /// Способ информирования
    /// </summary>
    public string MethodInforming { get; set; }
    /// <summary>
    /// Транспортные средства
    /// </summary>
    public TransportTax[] TransportTaxList { get; set; }

    /// <summary>
    /// Объекты недвижимости
    /// </summary>
    public RealEstateTax[] RealEstateTaxList { get; set; }

    /// <summary>
    /// Земельные участки
    /// </summary>
    public LandTax[] LandTaxList { get; set; }
}
 
public class Tax
{
    /// <summary>
    /// срочность 1 - бессрочно; 2 - срок ограничен
    /// </summary>            
    public string BenefitPeriodUrgency { get; set; }

    /// <summary>
    /// с
    /// </summary>            
    public string BenefitPeriodBeginDate { get; set; }

    /// <summary>
    /// по
    /// </summary>            
    public string BenefitPeriodEndDate { get; set; }

    /// <summary>
    /// наименование документа
    /// </summary>            
    public string DocumentName { get; set; }

    /// <summary>
    /// наименование органа (организации), выдавшего документ
    /// </summary>            
    public string DocumentIssuer { get; set; }

    /// <summary>
    /// Дата выдачи документа
    /// </summary>            
    public string DocumentIssuerDate { get; set; }

    /// <summary>
    /// Серия и номер документа 
    /// </summary>            
    public string DocumentSeriesNumber { get; set; }

    /// <summary>
    /// срочность 1 - бессрочно; 2 - срок ограничен
    /// </summary>            
    public string DocumentPeriodUrgency { get; set; }

    /// <summary>
    /// с
    /// </summary>            
    public string DocumentPeriodBeginDate { get; set; }

    /// <summary>
    /// по
    /// </summary>            
    public string DocumentPeriodEndDate { get; set; }
}

public class LandTax : Tax
{
    /// <summary>
    /// Кадастровый номер земельного участка
    /// </summary>            
    public string CadastralNumber { get; set; }
}

public class TransportTax : Tax
{
    /// <summary>
    /// Вид транспортного средства
    /// </summary>            
    public string Type { get; set; }

    /// <summary>
    /// Марка (модель)
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Государственный регистрационный знак (номер)
    /// </summary>
    public string RegSign { get; set; }
}

public class RealEstateTax : Tax
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
}
