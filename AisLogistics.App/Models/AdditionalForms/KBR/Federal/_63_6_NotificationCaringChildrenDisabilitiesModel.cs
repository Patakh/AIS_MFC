namespace AisLogistics.App.Models
{
    /// <summary>
    ///ИЗВЕЩЕНИЕ О НАСТУПЛЕНИИ ОБСТОЯТЕЛЬСТВ, ВЛЕКУЩИХ ПРЕКРАЩЕНИЕ ОСУЩЕСТВЛЕНИЯ КОМПЕНСАЦИОННОЙ ВЫПЛАТЫ НЕРАБОТАЮЩЕМУ ТРУДОСПОСОБНОМУ ЛИЦУ, ОСУЩЕСТВЛЯВШЕМУ УХОД ЗА НЕТРУДОСПОСОБНЫМ ГРАЖДАНИНОМ
    /// </summary>
    public sealed class _63_6_NotificationCaringChildrenDisabilitiesModel : AbstractAdditionalFormModel
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

        #region Блок4
        /// <summary>
        /// начало ухода
        /// </summary>
        public string? CaringStartDate { get; set; }

        /// <summary>
        /// фамилия, имя, отчество (при наличии) нетрудоспособного гражданина, за которым осуществляется уход
        /// </summary>
        public string? DisabledCitizenFullName { get; set; }

        /// <summary>
        /// прекращении ухода
        /// </summary>
        public bool TerminationCare { get; set; }

        /// <summary>
        /// назначении пенсии
        /// </summary>
        public bool AppointmentPension { get; set; }

        /// <summary>
        /// назначении пособия по безработице
        /// </summary>
        public bool BenefitsUnemployment { get; set; }

        /// <summary>
        /// выполнении оплачиваемой работы;
        /// </summary>
        public bool IsPrformingPaidWork { get; set; }

        /// <summary>
        /// истечении срока, на который ребенку-инвалиду в возрасте до 18 лет или инвалиду с детства I группы была установлена категория "ребенок-инвалид" либо I группа инвалидности с детства;
        /// </summary>
        public bool IsExpirationDate { get; set; }

        /// <summary>
        /// достижении ребенком-инвалидом возраста 18 лет, если ему по достижении этого возраста не установлена I группа инвалидности с детства;
        /// </summary>
        public bool IsAchievements { get; set; }

        /// <summary>
        /// помещении ребенка-инвалида или инвалида с детства I группы в организацию социального обслуживания, предоставляющую социальные услуги в стационарной форме;
        /// </summary>
        public bool PlacementInstitution { get; set; }

        /// <summary>
        /// другое
        /// </summary>
        public bool Other { get; set; }

        /// <summary>
        /// обазначение другого
        /// </summary>
        public string? OtherCare { get; set; }

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
            public bool NotificationTypeFree { get; set; }
            public string? EmailOne { get; set; }
            public int NotificationTransmitionMethod { get; set; }
            public string? EmailTwo { get; set; }
            public string? SubscriberNumber { get; set; }
        }

        #endregion
    }
}
