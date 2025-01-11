namespace AisLogistics.App.Models.AdditionalForms
{
    /// <summary>
    /// Прием документов, служащих основанием для исчисления и уплаты (перечисления) 
    /// страховых взносов, а также документов, подтверждающих правильность исчисления 
    /// и своевременность уплаты (перечисления) страховых взносов
    /// </summary>
    public class FssReceptionDocumentsModel : AbstractAdditionalFormModel
    {
        public FssReceptionDocumentsModel()
        {
            Representative = new();
        }

        /// <summary>
        /// Должность руководителя (заместителя руководителя) органа контроля
        /// за уплатой страховых взносов
        /// </summary>
        public string HeadPosition { get; set; }

        /// <summary>
        /// ФИО руководителя
        /// </summary>
        public string HeadFio { get; set; }

        /// <summary>
        /// Полное наименование организации (обособленного подразделения), фамилия, имя, отчество (при наличии)
        /// ИП, ФЛ
        /// </summary>
        public string InsurerName { get; set; }

        /// <summary>
        /// Должность руководителя организации
        /// </summary>
        public string InsurerHeadPosition { get; set; }

        /// <summary>
        /// ФИО руководителя организации
        /// </summary>
        public string InsurerHeadFio { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string InsurerHeadPhone { get; set; }

        /// <summary>
        /// регистрационный номер в органе контроля за уплатой
        /// </summary>
        public string RegNumber { get; set; }

        /// <summary>
        /// Код подчиненности
        /// </summary>
        public string SubordinationCode { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        public string Kpp { get; set; }

        /// <summary>
        /// Адрес места нахождения организации (обособленного подразделения)/
        /// адрес постоянного места жительства ИП, ФЛ
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public RepresentativeType Representative { get; set; }

        public class RepresentativeType
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// Наименование ДУЛ
            /// </summary>
            public string DocName { get; set; }

            /// <summary>
            /// Серия ДУЛ
            /// </summary>
            public string DocSeries { get; set; }

            /// <summary>
            /// Номер ДУЛ
            /// </summary>
            public string DocNumber { get; set; }

            /// <summary>
            /// Кем выдан ДУЛ
            /// </summary>
            public string DocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи ДУЛ
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// Наименование документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocName { get; set; }

            /// <summary>
            /// Серия документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocSeries{ get; set; }

            /// <summary>
            /// Номер документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocNumber { get; set; }

            /// <summary>
            /// Дата выдачи документа, подтверждабщего полномочия представителя
            /// </summary>
            public DateTime? AuthorityDocIssueDate { get; set; }

            /// <summary>
            /// Кем выдан документ, подтверждающий полномочия представителя
            /// </summary>
            public string AuthorityDocIssuer { get; set; }
        }
    }
}
