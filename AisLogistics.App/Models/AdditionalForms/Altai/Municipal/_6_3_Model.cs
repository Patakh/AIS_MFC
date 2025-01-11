using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                  ЗАЯВЛЕНИЕ
    /// о выдаче разрешения на строительство (реконструкцию)
    /// </summary> 
    public class _6_3_Model : AbstractAdditionalFormModel
    {
        public _6_3_Model()
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
        /// телефон 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// разрешение на
        /// </summary>
        public string List { get; set; }
        
        /// <summary>
        /// наименование объекта 
        /// </summary>
        public string NameObject { get; set; }

        /// <summary>
        /// площадь объекта 
        /// </summary>
        public string Area{ get; set; }

        /// <summary>
        /// материал стен 
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// габариты объекта 
        /// </summary>
        public string Dimensions { get; set; }

        /// <summary>
        /// этажность объекта
        /// </summary>
        public string Floors { get; set; }

        /// <summary>
        /// адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// кадастровый номер
        /// </summary>
        public string Cadastral { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime? DateOrder { get; set; }


        /// <summary>
        /// Номер Распоряжение  
        /// </summary>
        public string NumberOrder { get; set; }

        /// <summary>
        /// Дата Распоряжение  
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// орган, его утвердивший
        /// </summary>
        public string Organ { get; set; }

        /// <summary>
        /// Номер Право   
        /// </summary>
        public string NumberOrderRight { get; set; }

        /// <summary>
        /// Дата Право   
        /// </summary>
        public DateTime? DateRight { get; set; }

        /// <summary>
        /// наименование документа  Право   
        /// </summary>
        public string NameRight { get; set; }

        /// <summary>
        /// Проектная документация  шифр
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// дата составления
        /// </summary>
        public DateTime? DateIssue { get; set; }

        /// <summary>
        /// Схема планировочной организации/ шифр
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// дата составления
        /// </summary>
        public DateTime? DateIssueCode { get; set; }

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
