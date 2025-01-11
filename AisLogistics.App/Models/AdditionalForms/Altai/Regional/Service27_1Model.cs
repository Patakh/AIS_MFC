using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
   
    public class Service27_1Model : AbstractAdditionalFormModel
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
        /// наименование органа государственная расторжения брака     
        /// </summary>
        public string Name_Organ_Rip { get; set; }

        /// <summary>
        /// наименование органа государственная регистрация заключения брака 
        /// </summary>
        public string Name_Organ { get; set; }


        /// <summary>
        /// ФИО он
        /// </summary>
        public string Fio_Hi { get; set; }

        /// <summary>
        /// ФИО она
        /// </summary>
        public string Fio_She { get; set; }

        /// <summary>
        /// Дата принятия заявления
        /// </summary>
        public DateTime? Date_Rip { get; set; }
 
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient_End { get; set; }

        /// <summary>
        /// дата государственной регистрации
        /// </summary>
        public DateTime? Date_Register_Rip { get; set; }
        /// <summary>
       
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
