using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                    ЗАЯВЛЕНИЕ 
    /// о внесении изменений в разрешение на строительство 
    ///  (в том числе в связи с необходимостью продления 
    ///   срока действия разрешения на строительство)
    /// </summary> 
    public class _6_1_Model : AbstractAdditionalFormModel
    {
        public _6_1_Model()
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
        /// индивидуальный предприниматель,юридическое лицо - наименование
        /// </summary>
        public string FioLegal { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        /// продления  срока от
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// наименование объекта
        /// </summary>
        public string NameObject { get; set; }

        /// <summary>
        /// Адрес местоположения земельного участка
        /// </summary>
        public string LandPlotAddress { get; set; }

        /// <summary>
        /// Номер  земельного участка
        /// </summary>
        public string NumberPlot { get; set; }

        /// <summary>
        /// Дата начала строительства
        /// </summary>
        public DateTime? DateBuild { get; set; }

        /// <summary>
        /// наименование документа 
        /// </summary>
        public string DocName { get; set; }

        /// <summary>
        /// Номер 
        /// </summary>
        public string NumberDoc { get; set; }

        /// <summary>
        /// Дата 
        /// </summary>
        public DateTime? DateDoc { get; set; }

        /// <summary>
        /// шифр
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// дата составления
        /// </summary>
        public DateTime? DateComposing { get; set; }

        /// <summary>
        /// контактный телефон   
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Результат предоставления  
        /// </summary>
        public string TargetCode { get; set; }

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
