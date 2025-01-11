using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                       Заявление
    ///  Прошу выдать разрешение на право вырубки зеленых насаждений
    /// </summary> 
    public class _31_1_Model : AbstractAdditionalFormModel
    {
        public _31_1_Model()
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
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// адрес регистрации
        /// </summary>
        public string RegisterAddress { get; set; }

        /// <summary>
        /// телефон   
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// адрес зеленых насаждений
        /// </summary>
        public string AdressgGreenSaces { get; set; }

        /// <summary>
        /// Прилагаемые документы
        /// </summary>
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
