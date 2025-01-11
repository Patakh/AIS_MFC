namespace AisLogistics.App.Models;

/// <summary>
/// Прием заявления о прекращении исчисления транспортного налога в связи с принудительным изъятием транспортного средства.
/// </summary>
public sealed class _24_FnsKnd1150122Model : AbstractAdditionalFormModel
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
    /// Сведения об объекте налогообложения, в отношении которого представляется заявление
    /// </summary>
    public VehicleType Vehicle { get; set; }
}

public class VehicleType
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

    /// <summary>
    /// Дата гибели или уничтожения ТС
    /// </summary>
    public string DestructionDate { get; set; }

    /// <summary>
    /// Полное наименование документа
    /// </summary>
    public string DestructionConfirmDocName { get; set; }

    /// <summary>
    /// Полное наименование органа (организвцииб лица), выдавшего документ
    /// </summary>
    public string DestructionConfirmDocIssuer { get; set; }

    /// <summary> 
    /// Дата составления документа
    /// </summary>
    public string DestructionConfirmDocDate { get; set; }

    /// <summary>
    /// Номер документа
    /// </summary>
    public string DestructionConfirmDocNumber { get; set; }
}
