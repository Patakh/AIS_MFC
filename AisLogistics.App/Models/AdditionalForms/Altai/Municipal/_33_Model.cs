using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                               Заявление
    ///  "Предоставление права на въезд и передвижение грузового автотранспорта в зонах
    ///       ограничения его движения по автомобильным дорогам местного значения"
    /// </summary> 
    public class _33_Model : AbstractAdditionalFormModel
    { 
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Лицо(Физическое && Юридическое)
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        /// полное наименование юридического лица
        /// </summary>
        public string NameLegal { get; set; }

        /// <summary>
        /// ОПФ
        /// </summary>
        public string OPF_ { get; set; }

        /// <summary>
        /// ЕГРЮЛ
        /// </summary>
        public string USRLE { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string AddressLife { get; set; }

        /// <summary>
        /// телефон для связи
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Представитель или доверенное лицо заявителя
        /// ФИО 
        /// </summary>
        public string FioRepresentative { get; set; }

        /// <summary>
        /// серия
        /// </summary>
        public string SeriesRepresentative { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string NumberRepresentative { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuerRepresentative { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDateRepresentative { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string NumberAttorney { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDateAttorney { get; set; }


        /// <summary>
        /// срок действия
        /// </summary>
        public string ValidityPeriod { get; set; }
        
        /// <summary>
        /// количество пропусков
        /// </summary>
        public string NumberPasses { get; set; }

        /// <summary>
        /// Способ получения результата
        /// </summary>
        public string MethodResult { get; set; }


    }
}
