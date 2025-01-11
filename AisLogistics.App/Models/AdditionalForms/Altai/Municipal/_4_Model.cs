using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{

    /// <summary>
    ///                                             ЗАЯВЛЕНИЕ
    /// Прошу  предоставить муниципальную услугу "Признание садового дома жилым домом и  жилого дома  садовым домом"
    ///                         в  отношении  дома,   находящегося в собственности
    /// </summary>
    public class _4_Model : AbstractAdditionalFormModel
    {
        public _4_Model()
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
        /// адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// индивидуальный предприниматель, юридическое лицо - наименование
        /// </summary>
        public string LegalFace { get; set; }

        /// <summary>
        /// Контактные телефоны
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        /// расположенного по адресу
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// кадастровый номер 
        /// </summary>
        public string CadastrNumber { get; set; }

        /// <summary>
        /// общая площадь
        /// </summary>
        public string TotalArea { get; set; }

        /// <summary>
        /// Результат    предоставления    муниципальной   услуги
        /// </summary>
        public string Receipt { get; set; }

        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Приложение
            /// </summary>
            public string Fio { get; set; }
        }
    }
    }
    