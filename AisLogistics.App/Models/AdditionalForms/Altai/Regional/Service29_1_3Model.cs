using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
   
    public class Service29_1_3Model : AbstractAdditionalFormModel
    {
        public Service29_1_3Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
        }

        /// <summary>
        /// Наименование учреждения
        /// </summary>
        public string Name { get; set; }
     
        /// <summary>
        /// адрес места осуществления (отдельно по каждому адресу)
        /// </summary>
        public string RegistrationAddress { get; set; }

        /// <summary>
        /// адрес места нахождения
        /// </summary>
        public string ResidenceAddress { get; set; }

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
