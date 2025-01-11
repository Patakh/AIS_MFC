namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                             Заявление
    /// Прошу Вас предоставить мне жилое помещение по договору социального найма 
    /// </summary>
    public class _36_Model : AbstractAdditionalFormModel
    {
        public _36_Model()
        {
            AppliedFamilyList = new[]
            {
            new Info_Family()
            };

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
        /// Адрес 
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// площадь
        /// </summary>
        public string Arrea { get; set; }

        /// <summary>
        /// по адресу
        /// </summary>
        public string Adress { get; set; }

        public Info_Family[] AppliedFamilyList { get; set; }
        public class Info_Family
        {
            /// <summary>
            /// ФИО членов семьи
            /// </summary>
            public string Fio_Family { get; set; }

            /// <summary>
            /// Степень родства
            /// </summary>
            public string Degree_Kinship { get; set; }
            
        }
    }
}
