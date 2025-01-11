using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                    ЗАЯВЛЕНИЕ
    /// О ПРЕКРАЩЕНИИ ДЕЙСТВИЯ ЛИЦЕНЗИИ НА РОЗНИЧНУЮ ПРОДАЖУ
    ///              АЛКОГОЛЬНОЙ ПРОДУКЦИИ
    /// </summary> 
    public class _35_3_Model : AbstractAdditionalFormModel
    {
        public _35_3_Model()
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
        /// организационно-правовая форма 
        /// </summary>
        public string OrganizationalLegalForm { get; set; }

        /// <summary>
        /// наименование организации
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// № алкогольной продукции 
        /// </summary>
        public string NuberaLcoholicBeverages { get; set; }

        /// <summary>
        /// от
        /// </summary>
        public string DateLcoholic { get; set; }

        /// <summary>
        /// причина  ,в связи с
        /// </summary>
        public string Reason { get; set; }

       
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
