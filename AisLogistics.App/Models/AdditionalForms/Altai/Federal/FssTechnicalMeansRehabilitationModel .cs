namespace AisLogistics.App.Models.AdditionalForms
{
    public class FssTechnicalMeansRehabilitationModel : AbstractAdditionalFormModel
    {
        public FssTechnicalMeansRehabilitationModel()
        {
            Customer = new();
            Accompanying = new();
        }

        /// <summary>
        /// наименование территориального органа ФСС РФ
        /// </summary>
        public string FssDepartmentName { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Customer { get; set; }

        /// <summary>
        /// Вид обеспечения инвалида или ветерана
        /// </summary>
        public string ProvisionType { get; set; }

        /// <summary>
        /// Нуждаться в сопровождении
        /// </summary>
        public bool NeedAccompanied { get; set; }

        /// <summary>
        /// Сопровождающий
        /// </summary>
        public PersonType Accompanying { get; set; }

        /// <summary>
        /// Прилагаемые документы
        /// </summary>
        public string[] AppliedDocuments { get; set; }

        /// <summary>
        /// Метод информирования
        /// </summary>
        public string MethodInforming { get; set; }

        /// <summary>
        /// Иной способ информирования
        /// </summary>
        public string OtherMethoInforming { get; set; }

        /// <summary>
        /// Нуждаюсь в предоставлении услуг по переводу русского 
        /// жестового языка (сурдопереводу/тифлосурдопереводу)
        /// </summary>
        public bool NeedSigner { get; set; }

        /// <summary>
        /// Способ получения результата
        /// </summary>
        public string MethodResult { get; set; }

        /// <summary>
        /// Способ перечисления компенсации за самостоятельно приобретённое техническое средство (изделие)
        /// </summary>
        public string MethodListingCompensation { get; set; }

        /// <summary>
        /// № платежной карты, являющейся национальным платежным инструментом (при наличии)
        /// </summary>
        public string PaymentCardNumber { get; set; }

        /// <summary>
        /// Подтверждаю согласие на участие в СМС-опросе о качестве предоставления государственных услуг
        /// </summary>
        public bool ParticipateSMSQuestion { get; set; }

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
            /// Телефон домашний с указанием кода города
            /// </summary>
            public string HomePhone { get; set; }

            /// <summary>
            /// Мобильный телефон
            /// </summary>
            public string MobilePhone { get; set; }

            /// <summary>
            /// Адрес электронной почты
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string Snils { get; set; }
        }
    }
}
