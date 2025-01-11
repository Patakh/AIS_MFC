namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Государственная услуга по выдаче, переоформлению, выдаче дубликата, разрешений 
    /// на право деятельности по перевозке пассажиров и багажа легковым такси 
    /// на территории Республики Алтай
    /// </summary>
    public class Service1Model : AbstractAdditionalFormModel
    {

        /// <summary>
        /// В Минсельхоз РА
        /// </summary>
        public string In { get; set; }

        /// <summary>
        /// Тип заявителя
        /// 1 - ЮЛ
        /// 2 - ИП
        /// </summary>
        public string CustomerType { get; set; }

        /// <summary>
        /// Организационно-правовая форма,
        /// </summary>
        public string UlForm { get; set; }

        /// <summary>
        /// ФИО руководителя
        /// </summary>
        public string UlHeadFio { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        public string UlName { get; set; }

        /// <summary>
        /// Сокращенное/Фирменное наименование
        /// </summary>
        public string UlShortName { get; set; }

        /// <summary>
        /// ФИО ИП
        /// </summary>
        public string IpFio { get; set; }

        /// <summary>
        /// Серия и номер паспорта ИП
        /// </summary>
        public string IpDocSeriesNumber { get; set; }
        
        /// <summary>
        /// Дата выдачи паспорта ИП
        /// </summary>
        public DateTime? IpDocIssueDate { get; set; }

        /// <summary>
        /// Кем выдан паспорт ИП
        /// </summary>
        public string IpDocIssuer { get; set; }

        /// <summary>
        /// ОГРН/ОГРНИП
        /// </summary>
        public string Ogrn { get; set; }

        /// <summary>
        /// адрес места нахождения органа, осуществившего государственную регистрацию
        /// </summary>
        public string AdressOgrn { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// Серия и номер свидетельства
        /// </summary>
        public string FnsRegCertSeriesNumber { get; set; }

        /// <summary>
        /// Дата постановки на учет в налоговом органе
        /// </summary>
        public string FnsRegDate { get; set; }

        /// <summary>
        /// Юридический адрес
        /// (почтовый индекс, для юридического лица - юридический адрес,
        /// для индивидуального предпринимателя - адрес прописки)
        /// </summary>
        public string LegalAddress { get; set; }

        /// <summary>
        /// Почтовый адрес
        /// (почтовый индекс, место фактического нахождения юридического лица
        /// (проживания индивидуального предпринимателя))
        /// </summary>
        public string MailingAddress { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Факс
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Цель заявления
        /// </summary>
        public string TargetCode { get; set; }

        /// <summary>
        /// Марка, модель ТС
        /// </summary>
        public string VehicleModel { get; set; }

        /// <summary>
        /// Государственный регистрационный знак (номер)
        /// </summary>
        public string VehicleRegSign { get; set; }
    }
}
