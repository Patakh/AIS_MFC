namespace AisLogistics.App.Models
{
    /// <summary>
    /// ЗАЯВЛЕНИЕ О ПЕРЕРАСЧЕТЕ РАЗМЕРА ЕЖЕМЕСЯЧНОЙ ВЫПЛАТЫ НЕРАБОТАЮЩЕМУ ТРУДОСПОСОБНОМУ ЛИЦУ, ОСУЩЕСТВЛЯЮЩЕМУ УХОД ЗА РЕБЕНКОМ-ИНВАЛИДОМ В ВОЗРАСТЕ ДО 18 ЛЕТ ИЛИ ИНВАЛИДОМ С ДЕТСТВА I ГРУППЫ
    /// </summary>
    public sealed class _63_5_RecalculationCaringChildrenDisabilitiesModel : AbstractAdditionalFormModel
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
        /// являюсь по отношению к ребенку-инвалиду в возрасте 18 лет или инвалиду с детства I группы
        /// 1 - родителем
        /// 2 - усыновителем
        /// 3 - опекуном
        /// 4 - попечителем
        /// </summary>
        public int RelationshipTypeId { get; set; }

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
        /// Тип нетрудоспособного гражданина
        /// 1 - ребенок-инвалид в возрасте до 18 лет
        /// 2 - инвалид с детства I группы,
        /// </summary>
        public int DisableTypeId { get; set; }

        /// <summary>
        /// фамилия, имя, отчество (при наличии) нетрудоспособного гражданина, за которым осуществляется уход
        /// </summary>
        public string? DisabledCitizenFullName { get; set; }

        /// <summary>
        /// снилс ребенка-инвалида в возрасте до 18 лет, инвалида с детства I группы 
        /// </summary>
        public string? DisabledCitizenSnils { get; set; }

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
}
