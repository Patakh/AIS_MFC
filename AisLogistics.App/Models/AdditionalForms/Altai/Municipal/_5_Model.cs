using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                     Заявление
    ///  о выдаче градостроительного плана земельного участка
    /// </summary> 
    public class _5_Model : AbstractAdditionalFormModel
    {
        public _5_Model()
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
        /// Дата заполнения 
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Адрес местоположения земельного участка
        /// </summary>
        public string LandPlotAddress { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }


        /// <summary>
        /// Кадастровый номер земельного участка (при наличии): 
        /// </summary>
        public string Number_Kadastr { get; set; }

        /// <summary>
        /// контактный телефон   
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// индивидуальный предприниматель
        /// </summary>
        public string Fio_Manager { get; set; }

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
