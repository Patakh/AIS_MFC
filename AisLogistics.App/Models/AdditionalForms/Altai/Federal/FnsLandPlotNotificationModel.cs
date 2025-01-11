using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    // Документ не заполняется, если указан ИНН
    public sealed class FnsLandPlotNotificationModel : AbstractAdditionalFormModel
    {
        public FnsLandPlotNotificationModel()
        {
            CustomerFio = new();
            RepresentativeFio = new();
        }

        /// <summary>
        /// Тип заявителя
        /// </summary>
        public string CustomerType { get; set; }

        /// <summary>
        /// ФИО заявителя
        /// </summary>
        public FioType CustomerFio { get; set; }

        /// <summary>
        /// ФИО представителя
        /// </summary>
        public FioType RepresentativeFio { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Код вида документа
        /// </summary>
        public string DocCode { get; set; }

        /// <summary>
        /// Серия и номер документа
        /// </summary>
        public string DocSeriesNumber { get; set; }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// Кем выдан документ
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Номер контактного телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Кадастровый номер
        /// </summary>
        public string CadastralNumber { get; set; }

        public class FioType
        {
            /// <summary>
            /// Фамилия
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            public string SecondName { get; set; }
        }        
    }
}
