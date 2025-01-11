using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                             УВЕДОМЛЕНИЕ
    ///  о приобретении прав на земельный участок/образовании земельного участка
    /// </summary> 
    public class _6_2_Model : AbstractAdditionalFormModel
    {
        public _6_2_Model()
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
        /// УВЕДОМЛЕНИЕ
        /// </summary>
        public string NOTIFICATION { get; set; }

        /// <summary>
        /// номер 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// дата выдачи
        /// </summary>
        public DateTime? DateIssue { get; set; }

        /// <summary>
        /// орган
        /// </summary>
        public string Ogan { get; set; }

        /// <summary>
        /// наименование объекта 
        /// </summary>
        public string NameObject { get; set; }

        /// <summary>
        /// наименование этапа 
        /// </summary>
        public string StageName { get; set; }

        /// <summary>
        /// площадь объекта
        /// </summary>
        public string AreaObject { get; set; }

        /// <summary>
        /// адресу 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// кадастровый номер 
        /// </summary>
        public string CadastralNumber { get; set; }

        /// <summary>
        /// сообщаю
        /// </summary>
        public string Informing { get; set; }

        /// <summary>
        /// договор 
        /// </summary>
        public string Contract { get; set; }

        /// <summary>
        /// соглашение к договору 
        /// </summary>
        public string Agreement { get; set; }

        /// <summary>
        /// свидетельство 
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// номер 
        /// </summary>
        public string Number_ { get; set; }

        /// <summary>
        /// дата составления
        /// </summary>
        public DateTime? DateComposing { get; set; }

        /// <summary>
        /// наименование
        /// </summary>
        public string Name_ { get; set; }

        /// <summary>
        /// номер 
        /// </summary>
        public string Number_2 { get; set; }

        /// <summary>
        /// дата составления
        /// </summary>
        public DateTime? DateComposing_2 { get; set; }

        /// <summary>
        /// орган 
        /// </summary>
        public string OrganGPZU { get; set; }

        /// <summary>
        /// номер 
        /// </summary>
        public string Number_GPZU { get; set; }

        /// <summary>
        /// дата 
        /// </summary>
        public DateTime? DateComposingGPZU { get; set; }

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
