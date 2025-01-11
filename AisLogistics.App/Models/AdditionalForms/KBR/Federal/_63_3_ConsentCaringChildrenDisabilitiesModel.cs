namespace AisLogistics.App.Models
{
    /// <summary>
    /// ЗАЯВЛЕНИЕ О СОГЛАСИИ НА ОСУЩЕСТВЛЕНИЕ НЕРАБОТАЮЩИМ ТРУДОСПОСОБНЫМ ЛИЦОМ УХОДА ЗА РЕБЕНКОМ-ИНВАЛИДОМ В ВОЗРАСТЕ ДО 18 ЛЕТ ИЛИ ИНВАЛИДОМ С ДЕТСТВА I ГРУППЫ
    /// </summary>
    public sealed class _63_3_ConsentCaringChildrenDisabilitiesModel : AbstractAdditionalFormModel
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
        /// Тип нетрудоспособного гражданина
        /// 1 - ребенок-инвалид в возрасте до 18 лет
        /// 2 - инвалид с детства I группы,
        /// </summary>
        public int DisableTypeId { get; set; }
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
        /// фамилия, имя, отчество (при наличии) нетрудоспособного гражданина, за которым осуществляется уход
        /// </summary>
        public string? DisabledCitizenFullName { get; set; }

        #endregion

              
    }
}


