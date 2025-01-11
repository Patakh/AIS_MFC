namespace AisLogistics.App.Models.AdditionalForms
{
    public class FssSpaTreatmentModel : AbstractAdditionalFormModel
    {
        public FssSpaTreatmentModel()
        {
            Customer = new();
            Representative = new();
        }

        /// <summary>
        /// наименование территориального органа ФСС РФ
        /// </summary>
        public string FssDepartmentName { get; set; }

        /// <summary>
        /// Цель заявления
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Customer { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public RepresentativeType Representative { get; set; }

        /// <summary>
        /// Способ получения результата
        /// </summary>
        public string MethodResult { get; set; }

        /// <summary>
        /// Дата Справки на получение путевки по форме № 070/у
        /// </summary>
        public DateTime? CertDate { get; set; }

        /// <summary>
        /// Номер Справки на получение путевки по форме № 070/у 
        /// </summary>
        public string CertNumber { get; set; }

        /// <summary>
        /// Дата Направления к месту лечения
        /// </summary>
        public DateTime? DirectionPlaceTreatmentDate { get; set; }

        /// <summary>
        /// Номер Направления к месту лечения
        /// </summary>
        public string DirectionPlaceTreatmentNumber { get; set; }

        /// <summary>
        /// Наименование учреждения, в которое направляется на лечение
        /// </summary>
        public string TreatmentPlaceName { get; set; }

        /// <summary>
        /// Дата госпитализации
        /// </summary>
        public DateTime? HospitalizationDate { get; set; }

        /// <summary>
        /// Маршрут следования
        /// </summary>
        public string Itinerary { get; set; }

        public class PersonType
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// Адрес проживания
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// Место рождения
            /// </summary>
            public string BirthPlace { get; set; }

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
            /// Телефон
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string Snils { get; set; }
        }

        public class RepresentativeType : PersonType
        {
            /// <summary>
            /// Наименование документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocName { get; set; }

            /// <summary>
            /// Серия документа, подтверждающего полномочия представителя
            /// </summary>
            public string AuthorityDocSeries { get; set; }

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
