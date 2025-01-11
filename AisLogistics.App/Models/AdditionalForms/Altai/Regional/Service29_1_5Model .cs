using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
   
    public class Service29_1_5Model : AbstractAdditionalFormModel
    {
        public Service29_1_5Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
        }
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        ///Ф.И.О. руководителя юридического лица или иного лица, имеющего право действовать от имени этого юридического лица / (Ф.И.О. индивидуального предпринимателя)
        /// </summary>
        public string Fio_Manager { get; set; }

        /// <summary>
        /// от
        /// </summary>
        public DateTime? From { get; set; }
        
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Наименование оборудования и инструментов

            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Количество
            /// </summary>
            public int CopyCount { get; set; }
        }
    }
}
