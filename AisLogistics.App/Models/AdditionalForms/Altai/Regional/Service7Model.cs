namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// о предоставлении единовременной либо ежемесячной компенсации расходов
    /// гражданина по оплате топлива и транспортных услуг по его доставке
    /// </summary>
    public class Service7Model : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Получатель заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Ф
        /// </summary>
        public string F { get; set; }

        /// <summary>
        /// И
        /// </summary>
        public string I { get; set; }

        /// <summary>
        /// О
        /// </summary>
        public string O { get; set; }

        /// <summary>
        /// Представитель
        /// Ф 
        /// </summary>
        public string FRecipient { get; set; }

        /// <summary>
        /// И
        /// </summary>
        public string IRecipient { get; set; }

        /// <summary>
        /// О
        /// </summary>
        public string ORecipient { get; set; }

        /// <summary>
        /// место регистрации
        /// </summary>
        public string AdressRecipient { get; set; }


        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public string DocType { get; set; }

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
        /// Серия паспорта
        /// </summary>
        public string DocSeriesRecipient { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string DocNumberRecipient { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string DocIssuerRecipient { get; set; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public string DocIssueDateRecipient { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string DocIssuerRecipien { get; set; }

        /// <summary>
        ///  на основании
        /// </summary>
        public string Osnova { get; set; }

        /// <summary>
        /// от
        /// </summary>
        public string OsnovaNumber { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string OsnovaDate { get; set; }


        /// <summary>
        /// типа документа 
        /// </summary>
        public string Support { get; set; }

        /// <summary>
        /// Серия 
        /// </summary>
        public string SupportSeries { get; set; }

        /// <summary>
        /// Номер 
        /// </summary>
        public string SupportNumber { get; set; }


        /// <summary>
        /// СНИЛС
        /// </summary>
        public string AppSNILS { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// электронная почта
        /// </summary>
        public string Emaill { get; set; }

        /// <summary>
        /// Категория гражданина
        /// </summary>
        public string PersonCategory { get; set; }

        /// <summary>
        /// Способ выплаты средств       
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Лицевой счет        
        /// </summary>

        public string PersonalAccount { get; set; }
        /// <summary>
        /// почтовое отделение 
        /// </summary>
        public string Post_Office { get; set; }
        /// <summary>
        /// Выплата компенсации 
        /// </summary>
        /// 
        public string MethodResult { get; set; }

        /// <summary>
        /// Метод информирования
        /// </summary>
        public string MethodInforming { get; set; }
        /// <summary>
        /// твердое топливо 
        /// </summary>
        public string Methodresurse { get; set; }

        /// <summary>
        /// за год расходов
        /// </summary>
        public string DateYear { get; set; }
    }
}
