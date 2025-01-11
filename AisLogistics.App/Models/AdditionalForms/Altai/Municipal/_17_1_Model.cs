using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                                           Заявление
    /// о выдаче акта освидетельствования проведения основных работ по строительству объекта индивидуального
    ///          жилищного строительства(монтаж фундамента, возведение стен и кровли), осуществляемому
    ///                      с привлечением средств материнского(семейного) капитала
    /// </summary> 
    public class _17_1_Model : AbstractAdditionalFormModel
    {
        public _17_1_Model()
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
        /// тип конструкции фундамента 
        /// </summary>
        public string TypeConstructionFoundation { get; set; }

        /// <summary>
        /// тип конструкции стен 
        /// </summary>
        public string TypeConstructionWalls { get; set; }

        /// <summary>
        /// тип конструкции кровли 
        /// </summary>
        public string TypeConstructionRoofs { get; set; }

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
