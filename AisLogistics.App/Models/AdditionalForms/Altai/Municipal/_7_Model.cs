using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                        ЗАЯВЛЕНИЕ
    /// Прошу предоставить уведомление о наличии/отсутствии задолженности 
    ///            по арендной плате за земельный участок
    /// </summary> 
    public class _7_Model : AbstractAdditionalFormModel
    {
        public _7_Model()
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
        /// Заявитель
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// Наименование 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// место нахождения заявителя 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// ОГРН
        /// </summary>
        public string OGRN { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        /// Телефон  
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// адрес электронной почты 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// уведомление о
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// информировать 
        /// </summary>
        public string List { get; set; }

        /// <summary>
        /// площадь
        /// </summary>
        public string Arrea { get; set; }

        /// <summary>
        /// расположенный по адресу
        /// </summary>
        public string AdressFact { get; set; }

        /// <summary>
        /// категория земель
        /// </summary>
        public string CategoryPlot { get; set; }

        /// <summary>
        /// кадастровым номером
        /// </summary>
        public string KadastrNumber { get; set; }

        /// <summary>
        /// цель использования
        /// </summary>
        public string Mativ { get; set; }
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Приложение
            /// </summary>
            public string Name { get; set; }
        }
    }
}
