﻿namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal
{
    /// <summary>
    /// ЗАЯВЛЕНИЕ О ВЫДАЧЕ СПРАВКИ О СУММАХ КОМПЕНСАЦИОННОЙ ВЫПЛАТЫ, НЕ ПОЛУЧЕННЫХ ПРИ ЖИЗНИ НЕРАБОТАВШИМ ТРУДОСПОСОБНЫМ ЛИЦОМ, ОСУЩЕСТВЛЯВШИМ УХОД ЗА НЕТРУДОСПОСОБНЫМ ГРАЖДАНИНОМ
    /// </summary>
    public sealed class _64_4_CertificateCareDisabledCitizensModel : AbstractAdditionalFormModel
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

        /// <summary>
        /// Указывается на русском и иностранном языках
        /// </summary> 
        public string? AddressResidenceAnotherState { get; set; }

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
        /// фамилия, имя, отчество умершего неработавшего трудоспособного лица, осуществлявшего уход за нетрудоспособным гражданином
        /// </summary>
        public string? DisabledCitizenFullName { get; set; }
        /// <summary>
        /// дата смерти
        /// </summary>
        public DateTime? DateDeath { get; set; }
        /// <summary>
        /// наименование документа о смерти
        /// </summary>
        public string? NameDocumentDeath { get; set; }
        /// <summary>
        /// номер документа о смерти
        /// </summary>
        public string? NumberDocumentDeath { get; set; }
        /// <summary>
        /// Запрос нотариуса N
        /// </summary>
        public string? NumberRequestProcuration { get; set; }
        /// <summary>
        /// от
        /// </summary>
        public DateTime? DateRequestProcuration { get; set; }

        #endregion

        #region Блок4

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
    }
}