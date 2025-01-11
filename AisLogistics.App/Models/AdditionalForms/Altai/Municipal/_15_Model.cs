using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                   Заявление 
    /// о выдаче разрешения на ввод объекта в эксплуатацию
    /// </summary>
    public class _15_Model : AbstractAdditionalFormModel
    {
        public _15_Model()
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
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        ///  юридическое лицо - наименование
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        /// контактный телефон 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Сведения о
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        /// Наименование объекта
        /// </summary>
        public string NameObjekt { get; set; }

        /// <summary>
        /// Площадь объекта
        /// </summary>
        public string ArreaObjekt { get; set; }

        /// <summary>
        /// Материал стен
        /// </summary>
        public string WallMaterial { get; set; }

        /// <summary>
        /// Этажность объекта
        /// </summary>
        public string NumberFloors { get; set; }

        /// <summary>
        /// На земельном участке по адресу
        /// </summary>
        public string AdressPlot { get; set; }

        /// <summary>
        /// Кадастровый номер земельного участка
        /// </summary>
        public string Kadastr { get; set; }

        /// <summary>
        /// Результат предоставления муниципальной услуги
        /// </summary>
        public string ResultProviding { get; set; }

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
    