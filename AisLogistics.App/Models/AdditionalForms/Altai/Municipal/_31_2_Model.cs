using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                       Заявление
    ///  Прошу выдать разрешение на право вырубки зеленых насаждений
    /// </summary> 
    public class _31_2_Model : AbstractAdditionalFormModel
    {
        public _31_2_Model()
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
        /// наименование организации
        /// </summary>
        public string NameOrganization { get; set; }

        /// <summary>
        /// индекс, адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// телефон   
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// тел./факс
        /// </summary>
        public string TelephoneFaks { get; set; }

        /// <summary>
        /// E-mail   
        /// </summary>
        public string Email { get; set; }

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
