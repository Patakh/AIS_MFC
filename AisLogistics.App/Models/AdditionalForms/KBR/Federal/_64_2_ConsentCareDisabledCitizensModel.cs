namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// ЗАЯВЛЕНИЕ О СОГЛАСИИ НЕТРУДОСПОСОБНОГО ГРАЖДАНИНА НА ОСУЩЕСТВЛЕНИЕ ЗА НИМ УХОДА НЕРАБОТАЮЩИМ ТРУДОСПОСОБНЫМ ЛИЦОМ
/// </summary>
public sealed class _64_2_ConsentCareDisabledCitizensModel : AbstractAdditionalFormModel
{
    #region Блок1

    /// <summary>
    /// Гражданство
    /// </summary>
    public string Citizenship { get; set; } = null!;

    /// <summary>
    /// Срок действия документа удостоверяющего личность
    /// </summary> 
    public string? ValidityPeriodDocument { get; set; }

    #region Осуществляю уход за нетрудоспособным гражданином

    /// <summary>
    /// Тип нетрудоспособного гражданина
    /// 1 - инвалидом I группы (за исключением инвалида с детства I группы)
    /// 2 - престарелым, нуждающимся по заключению медицинской организации в постоянном постороннем уходе
    /// 3 - престарелым, достигшим возраста 80 лет
    /// </summary>
    public int DisableTypeId { get; set; }

    #endregion

    /// <summary>
    /// В настоящее время:
    /// - работаю (true)
    /// - не работаю (false)
    /// </summary>
    public bool Employed { get; set; }

    /// <summary>
    /// являюсь получателем ежемесячной компенсационной выплаты в связи с осуществлением ухода за указанным нетрудоспособным гражданином в органе, 
    /// осуществляющем пенсионное обеспечение в соответствии с Законом Российской Федерации от 12 февраля 1993 г. № 4468-1 
    /// «О пенсионном обеспечении лиц, проходивших военную службу, службу в органах внутренних дел, Государственной противопожарной службе, 
    /// органах по контролю за оборотом наркотических средств и психотропных веществ, учреждениях и органах уголовно-исполнительной системы, 
    /// войсках национальной гвардии Российской Федерации, и их семей»
    /// </summary>
    public bool MonthlyCompensated { get; set; }

    #endregion

    #region Блок2

    /// <summary>
    /// Представитель 
    /// </summary> 
    public string Representative { get; set; } = null!;

    /// <summary>
    /// Наименование организации, на которую возложено исполнение обязанностей опекуна или попечителя
    /// </summary>
    public string GuardianOrganizationName { get; set; } = null!;

    /// <summary>
    /// Адрес места нахождения организации
    /// </summary>
    public string GuardianOrganizationAddress { get; set; } = null!;

    #endregion

    #region Блок3
    /// <summary>
    /// (указывается фамилия, имя, отчество (при наличии) неработающего трудоспособного лица, осуществляющего уход)
    /// </summary>
    public string? DisabledCitizenFullName { get; set; }

    #endregion
}
