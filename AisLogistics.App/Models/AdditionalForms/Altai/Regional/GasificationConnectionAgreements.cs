using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// ЗАЯВКА
    /// о заключении договора о подключении в рамках догазификации
    /// </summary>
    public class GasificationConnectionAgreementsModel : AbstractAdditionalFormModel
    {
        public GasificationConnectionAgreementsModel()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
        }
        /// <summary>
        /// наименование единого оператора газификации или
        /// регионального оператора газификации
        /// </summary>
        public string nameGasificationOperator { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string secondName { get; set; }

        /// <summary>
        /// Реквизит документа, удостоверяющего личность: вид
        /// </summary>
        public string typeDoc { get; set; }

        /// <summary>
        /// Реквизит документа, удостоверяющего личность: серия
        /// </summary>
        public string series { get; set; }

        /// <summary>
        /// Реквизит документа, удостоверяющего личность: номер
        /// </summary>
        public string number { get; set; }

        /// <summary>
        /// Реквизит документа, удостоверяющего личность: дата выдачи
        /// </summary>
        public string whenIssued { get; set; }

        /// <summary>
        /// Реквизит документа, удостоверяющего личность: орган выдачи
        /// </summary>
        public string issueDwhom { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string inn { get; set; }

        /// <summary>
        /// СНИЛС
        /// </summary>
        public string snils { get; set; }

        /// <summary>
        /// Место нахождения домовладения, планируемого к газификации
        /// </summary>
        public string placeHouseholds { get; set; }

        /// <summary>
        /// Кадастровый номер земельного участка
        /// </summary>
        public string kadastrNumber { get; set; }

        /// <summary>
        /// Адрес для корреспонденции
        /// </summary>
        public string addressForCorrespondence { get; set; }

        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string emaill { get; set; }

        /// <summary>
        /// Планируемая величина максимального часового расхода газа
        /// </summary>
        public string countMaxGasConsumption { get; set; }

        /// <summary>
        /// Необходимость выполнения   исполнителем   дополнительно следующих мероприятий
        /// по подключению (технологическому  присоединению)   в пределах границ его земельного участка 
        /// </summary>
        public string Necessity1 { get; set; }

        /// <summary>
        /// по установке газоиспользующего оборудования 
        /// </summary>
        public string Necessity2 { get; set; }

        /// <summary>
        /// по проектированию сети газопотребления 
        /// </summary>
        public string Necessity3 { get; set; }

        /// <summary>
        /// по строительству либо реконструкции внутреннего газопровода объекта капитального строительства  
        /// </summary>
        public string Necessity4 { get; set; }

        /// <summary>
        /// по поставке газоиспользующего оборудования
        /// </summary>
        public string Necessity5 { get; set; }

        /// <summary>
        ///  по установке прибора учета газа
        /// </summary>
        public string Necessity6 { get; set; }

        /// <summary>
        /// по поставке прибора учета газа
        /// </summary>
        public string Necessity7 { get; set; }
        /// <summary>
        /// Приложенные документы
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Наименование документа
            /// </summary>
            public string Name { get; set; }
        }
    }
}