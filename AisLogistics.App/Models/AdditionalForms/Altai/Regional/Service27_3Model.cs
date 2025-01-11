using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    ///Прошу назначить мне ежегодную денежную выплату (ЕДВ) по следующему основанию: Федеральный закон РФ от 20 июля 2012 г.
    ///№ 125-ФЗ "О донорстве крови и её компонентов" по категории:
    /// </summary>
    public class Service27_3Model : AbstractAdditionalFormModel
    {
       
       
        /// <summary>
        /// Получатель заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Адрес места регистрации
        /// </summary>
        public string RegistrationAddress { get; set; }
        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }
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
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Заявление поступило
        /// </summary>
        public string Request_path { get; set; }

        /// <summary>
        /// ДАТА ПРИНЯТИЯ ЗАЯВЛЕНИЯ
        /// </summary>
        public DateTime? Date_Request { get; set; }

        /// <summary>
        /// выдать        
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// наименование органа государственная регистрация рождения
        /// </summary>
        public string Name_Organ { get; set; }


        /// <summary>
        /// ФИО ребенка
        /// </summary>
        public string Fio_Child { get; set; }

        /// <summary>
        /// дата рождения ребенка
        /// </summary>
        public DateTime? BirthDate_Child { get; set; }

        /// <summary>
        /// место рождения ребенка
        /// </summary>
        public string ResidenceAddress_Child { get; set; }

        /// <summary>
        /// ФИО матери ребенка
        /// </summary>
        public string Fio_Mother { get; set; }

        /// <summary>
        /// ФИО отца ребенка
        /// </summary>
        public string Fio_Father { get; set; }

        
 
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient_End { get; set; }

        /// <summary>
        /// дата государственной регистрации
        /// </summary>
        public DateTime? Date_Register_Rip { get; set; }
        
       
        /// <summary>
        /// номер записи акта
        /// </summary>
        public string Nuber_Act { get; set; }


        /// <summary>
        ///  выдать в связи с
        /// </summary>
        public string Doc_Contact_Please { get; set; }
        /// <summary>
        /// указать следующие иные сведения
        /// </summary>
        public string Doc_Info_Please { get; set; }
        /// <summary>
        ///выслать в
        /// </summary>
        public string Recipient_Send { get; set; }
    }
}
