namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    public class Service26Model : AbstractAdditionalFormModel
    {

        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// расторжения брака назначена на
        /// </summary>
        public DateTime? Date_Termination { get; set; }


        /// <summary>
        /// (наименование органа, осуществляющего государственную
        /// регистрацию актов гражданского состояния)

        /// </summary>
        public string Name_Organ { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }


        public class Person
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// после расторжения брака присвоить фамилии
            /// </summary>
            public string Fio_New { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// Адрес проживания
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Серия паспорта
            /// </summary>
            public string DocSeries { get; set; }

            /// <summary>
            /// Номер паспорта
            /// </summary>
            public string DocNumber { get; set; }

            /// <summary>
            /// Кем выдан паспорт
            /// </summary>
            public string DocIssuer { get; set; }
            /// <summary>
            /// Гражданство
            /// </summary>
            public string Citizenship { get; set; }

            /// <summary>
            /// Национальность
            /// </summary>
            public string Nationality { get; set; }

            /// <summary>
            /// Дата выдачи паспорта
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// Телефон
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// Образование Профессиональное
            /// </summary>
            public string Professional { get; set; }

            /// <summary>
            /// Общее
            /// </summary>
            public string General { get; set; }
        }

        /// <summary>
        /// Заявление поступило
        /// </summary>
        public string Request_Path { get; set; }

        /// <summary>
        /// (наименование органа, которым была произведена государственная регистрация)
        /// </summary>
        public string Name_Doc { get; set; }

        /// <summary>
        /// запись акта №
        /// </summary>
        public string Number_Doc { get; set; }

        /// <summary>
        /// от
        /// </summary>
        /// 
        public DateTime? Date_Doc { get; set; }
        /// <summary>
        /// Она
        /// </summary>
        
        public Person Husband { get; set; }

        /// <summary>
        /// Он
        /// </summary>
        public Person Wife { get; set; }
    }

}
