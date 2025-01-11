using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                      ЗАЯВЛЕНИЕ
    /// о бесплатном предоставлении земельного участка в собственность
    /// </summary> 

    public class _12_Model : AbstractAdditionalFormModel
    {
        public _12_Model()
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
        /// адрес
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// телефон
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// в целях
        /// </summary>
        public string Goals { get; set; }

        /// <summary>
        /// категория 
        /// </summary>
        public string Categories { get; set; }
      
        /// <summary>
        /// Приложение
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }
        public class AppliedDocument
        {
            /// <summary>
            /// Приложение
            /// </summary>
            public string Applications { get; set; }
        }
    }
}
