﻿namespace AisLogistics.App.Models;
/// <summary>
/// ЗАЯВЛЕНИЕ О НАЗНАЧЕНИИ ЕЖЕМЕСЯЧНОЙ ВЫПЛАТЫ НЕРАБОТАЮЩЕМУ ТРУДОСПОСОБНОМУ ЛИЦУ, ОСУЩЕСТВЛЯЮЩЕМУ УХОД ЗА РЕБЕНКОМ-ИНВАЛИДОМ В ВОЗРАСТЕ ДО 18 ЛЕТ ИЛИ ИНВАЛИДОМ С ДЕТСТВА I ГРУППЫ
/// </summary>
public sealed class _63_1_PaymentsCaringChildrenDisabilitiesModel : AbstractAdditionalFormModel
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
    /// начало ухода
    /// </summary>
    public string? CaringStartDate { get; set; }

    /// <summary>
    /// фамилия, имя, отчество (при наличии) нетрудоспособного гражданина, за которым осуществляется уход
    /// </summary>
    public string? DisabledCitizenFullName { get; set; }

    /// <summary>
    /// снилс ребенка-инвалида в возрасте до 18 лет, инвалида с детства I группы 
    /// </summary>
    public string? DisabledCitizenSnils { get; set; }

    /// <summary>
    /// Тип нетрудоспособного гражданина
    /// 1 - ребенок-инвалид в возрасте до 18 лет
    /// 2 - инвалид с детства I группы,
    /// </summary>
    public int DisableTypeId { get; set; }

    /// <summary>
    /// являюсь по отношению к ребенку-инвалиду в возрасте 18 лет или инвалиду с детства I группы
    /// 1 - родителем
    /// 2 - усыновителем
    /// 3 - опекуном
    /// 4 - попечителем
    /// 5 - другим лицом
    /// </summary>
    public int RelationshipTypeId { get; set; }

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

    /// <summary>
    /// получаю пособие по безработице в соответствии с Законом Российской Федерации от 19 апреля 1991 г. № 1032-1 
    /// «О занятости населения в Российской Федерации»
    /// </summary>
    public bool UnemploymentBenefit { get; set; }

    /// <summary>
    /// Обучаюсь по очной форме в образовательном учреждении
    /// </summary>
    public bool Studing { get; set; }

    /// <summary>
    /// Назначалась пенсия в соответствии с законодательством Российской Федерации
    /// </summary>
    public bool PensionAssigned { get; set; }

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

    #region Блок4
    /// <summary>
    /// Я предупрежден (иное)
    /// </summary>
    public string? AdditionalWarningText { get; set; }

    #endregion

    #region Блок5

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; } = Array.Empty<AppliedDocument>();
    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Количестов Экземпляров
        /// </summary>
        public int NumdberOriginals { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int NumdberCopies { get; set; }
    }

    #endregion

    #region Блок6

    /// <summary>
    /// Тип информирования
    /// </summary>
    public Notification TypeNotification { get; set; }

    public class Notification
    {
        public bool NotificationTypeOne { get; set; }
        public bool NotificationTypeTwo { get; set; }
        public string? EmailOne { get; set; }
        public int NotificationTransmitionMethod { get; set; }
        public string? EmailTwo { get; set; }
        public string? SubscriberNumber { get; set; }
    }

    #endregion

    #region Блок7

    /// <summary>
    /// Печатать согласие
    /// </summary>
    public bool IsReportConsent { get; set; }

    #endregion
}
