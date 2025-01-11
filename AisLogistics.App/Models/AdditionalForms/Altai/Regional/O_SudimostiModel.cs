using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Выдача справки о наличии (отсутствии) судимости и (или) 
    /// факта уголовного преследования либо прекращении уголовного преследования
    /// </summary>
    public class O_SudimostiModel : AbstractAdditionalFormModel
    {
        public O_SudimostiModel()
        {
            Region = new List<string>();
        }

        /// <summary>
        /// Получатель заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }
        
        /// <summary>
        /// проверяемого
        /// </summary>
        public string FioP { get; set; }
        
        /// <summary>
        /// ФИО
        /// </summary>
        public string FioPI { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }    

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }
        
        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddressP { get; set; }

        /// <summary>
        /// место рождения
        /// </summary>
        public string BirthAddress { get; set; }

        /// <summary>
        /// Серия  
        /// </summary>
        public string DocSeries { get; set; }
 
        /// <summary>
        /// Тип  
        /// </summary>
        public string DocType { 
            get; set; 
        }

        /// <summary>
        /// Номер
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// Кем выдан
        /// </summary>
        public string DocIssuer { get; set; }
        
        /// <summary>
        /// Кем
        /// </summary>
        public string Doc { get; set; }
        
        /// <summary>
        /// реквизиты
        /// </summary>
        public string DocRecvizit { get; set; }

        /// <summary>
        /// Дата выдачи  
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// справку получить в       
        /// </summary>
        public string Rezult { get; set; }

        /// <summary>
        ///  регионы Российской Федерации, в которых проживал(а) или пребывал(а) ранее, в том числe вступал(а) в брак
        /// </summary>
        public List<string> Region {

            set;
            get;
        }
        
        /// <summary>
        /// дата подачи      
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }
    }
}
