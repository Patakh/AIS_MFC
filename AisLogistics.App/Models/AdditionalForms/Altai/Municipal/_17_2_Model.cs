using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                                   ЗАЯВЛЕНИЕ
    ///    о выдаче акта освидетельствования проведения работ по реконструкции объекта
    ///   индивидуального жилищного строительства, осуществляемой с привлечением средств
    ///     материнского(семейного) капитала, в результате которой общая площадь жилого
    ///       помещения(жилых помещений) реконструируемого объекта увеличивается не
    ///               менее, чем на учетную норму площади жилого помещения, 
    ///                    устанавливаемую в соответствии с жилищным 
    ///                     законодательством  Российской Федерации
    /// </summary> 

    public class _17_2_Model : AbstractAdditionalFormModel
    {
        public _17_2_Model()
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
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        /// контактный телефон   
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// наименование объекта
        /// </summary>
        public string NameObject { get; set; }

        /// <summary>
        ///  субъект Российской Федерации
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Наименование муниципального района, городского, муниципального округа или внутригородской территории
        /// </summary>
        public string Territories { get; set; }

        /// <summary>
        /// Наименование поселения
        /// </summary>
        public string Settlements { get; set; }

        /// <summary>
        /// улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// дом
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Общая площадь реконструируемого объекта
        /// </summary>
        public string ArreaObject { get; set; }

        /// <summary>
        /// Площадь после реконструкции объекта
        /// </summary>
        public string ArreaObjectEnd { get; set; }

        /// <summary>
        /// Результат предоставления муниципальной услуги прошу (нужное подчеркнуть
        /// </summary>
        public string ResultProviding { get; set; }

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
