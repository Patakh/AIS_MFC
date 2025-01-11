using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    
    public class Service29_1Model : AbstractAdditionalFormModel
    {
       

        /// <summary>
        /// Поступ. в банк плат.
        /// </summary>
        public string Received { get; set; }

        /// <summary>
        /// Списано со сч. плат.
        /// </summary>
        public string Written_Off { get; set; }

        /// <summary>
        /// Дата платежа
        /// </summary>
        public DateTime? Date_Payment { get; set; }

        /// <summary>
        /// Дата Назначение платежа
        /// </summary>
        public DateTime? DatePayment { get; set; }

        /// <summary>
        /// Вид платежа
        /// </summary>
        public string Type_Payment { get; set; }

        /// <summary>
        /// ПЛАТЕЖНОЕ ПОРУЧЕНИЕ №  
        /// </summary>
        public string ASSIGNMENT { get; set; }

        /// <summary>
        /// Плательщик
        /// </summary>
        public Bank_Info Payer { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        public Bank_Info Recipient { get; set; }

        public class Bank_Info
        {

            /// <summary>
            /// ИНН
            /// </summary>
            public string Inn { get; set; }

            /// <summary>
            ///БИК кредитной организации
            /// </summary>
            public string BIK { get; set; }

            /// <summary>
            /// КПП кредитной организации
            /// </summary>
            public string KPP { get; set; }

            /// <summary>
            /// Банк
            /// </summary>
            public string Bank { get; set; }

            /// <summary>
            /// Сумма
            /// </summary>
            public string Amount { get; set; }

            /// <summary>
            ///Сч. №
            /// </summary>
            public string Number_1 { get; set; }
            /// <summary>
            ///Сч. №
            /// </summary>
            public string Number_2 { get; set; }

            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }
        }

        /// <summary>
        /// Вид оплаты
        /// </summary>
        public string Type_of_payment { get; set; }

        /// <summary>
        /// Название платежа
        /// </summary>
        public string Name_of_payment { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public string Code_of_payment { get; set; }

        /// <summary>
        /// Срок платежа       
        /// </summary>
        public string Term_of_payment { get; set; }

        /// <summary>
        /// Очередь платежа     
        /// </summary>
        public string Queue_of_payment { get; set; }

        /// <summary>
        /// Резевное Поле
        /// </summary>
        public string Backup_Field { get; set; }
        
    }
}
