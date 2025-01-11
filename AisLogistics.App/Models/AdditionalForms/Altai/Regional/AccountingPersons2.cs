namespace AisLogistics.App.Models.AdditionalForms.Regional
{     
      /// <summary>
      /// Исключение гражданина Российской Федерации из списка по своей инициативе
      /// </summary>
    public class AccountingPersons2 : AbstractAdditionalFormModel
    {
        public class Person
        {
            /// <summary>
            /// Фамилия
            /// </summary>
            public string F { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string I { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            public string O { get; set; }
               
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
            /// Дата выдачи паспорта
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// Код подразделения паспорта
            /// </summary>
            public string DocDevision { get; set; }

            /// <summary>
            ///  1.5. Адрес места жительства (пребывания) в Российской Федерации
            /// </summary>
            public string Address { get; set; }

        }
         
        /// <summary>
        /// Заявитель
        /// </summary>
        public Person Applicant { get; set; }

    }
}
