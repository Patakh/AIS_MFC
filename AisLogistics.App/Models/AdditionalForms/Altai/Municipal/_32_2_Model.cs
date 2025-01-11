using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                       Заявление
    ///  об оформлении (переоформлении) свидетельств об осуществлении
    ///   перевозок по маршруту регулярных перевозок и карт маршрута
    ///                   регулярных перевозок
    /// </summary> 
    public class _32_2_Model : AbstractAdditionalFormModel
    {
        public _32_2_Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
        }
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Наименование (для юридических лиц)
        /// </summary>
        public string NameLegal { get; set; }
        
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public string PochtAddress { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// номер лицензии
        /// </summary>
        public string NumberAttorneyLicenses { get; set; }

        /// <summary>
        /// дата выдачи лицензии 
        /// </summary>
        public DateTime? IssueDateLicenses { get; set; }

        /// <summary>
        /// Срок действия лицензии  
        /// </summary>
        public DateTime? TermLicenses { get; set; }

        /// <summary>
        /// телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Регистрационный номер маршрута   
        /// </summary>
        public string RegisterNumberRoute { get; set; }

        /// <summary>
        /// порядковый номер маршрута 
        /// </summary>
        public string OrdinalNumberRoute { get; set; }

        /// <summary>
        /// наименование маршрута = начальный + конечный
        /// </summary>

        /// <summary>
        /// начальный 
        /// </summary>
        public string Elementary { get; set; }
        
        /// <summary>
        /// конечный
        /// </summary>
        public string FinalRoute { get; set; }

        /// <summary>
        /// количество
        /// </summary>
        public string NumberRoute { get; set; }

        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Ф.И.О. 
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// Место нахождения
            /// </summary>
            public string Location { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string Inn { get; set; }
        }
    }
}
