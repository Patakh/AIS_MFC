﻿namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal
{
    /// <summary>
    /// ЗАЯВЛЕНИЕ О ПРЕКРАЩЕНИИ ОСУЩЕСТВЛЕНИЯ УХОДА НЕРАБОТАЮЩИМ ТРУДОСПОСОБНЫМ ЛИЦОМ ЗА НЕТРУДОСПОСОБНЫМ ГРАЖДАНИНОМ
    /// </summary>
    public sealed class _64_5_TerminationCareDisabledCitizensModel : AbstractAdditionalFormModel
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
        /// начало прекращения
        /// </summary>
        public string? CaringStartDate { get; set; }

        /// <summary>
        /// указывается фамилия, имя, отчество (при наличии) неработающего трудоспособного лица, осуществляющего уход
        /// </summary>
        public string? DisabledCitizenFullName { get; set; }

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