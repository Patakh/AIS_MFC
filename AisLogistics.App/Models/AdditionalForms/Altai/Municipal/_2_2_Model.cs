using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                        Заявление 
    /// о принятии на учет в качестве нуждающегося в предоставлении 
    ///       жилого помещения по договору социального найма
    /// </summary>
    public class _2_2_Model : AbstractAdditionalFormModel
    {
        public _2_2_Model()
        {
            
            AppliedFamilyList = new[]
            {
               new Info_Family()
            };
            
            AppliedDocumentList = new[]
            {
               new AppliedDocument()
            };

        }

        /// <summary>
        /// наименование администрации муниципального образования 
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// фамилия и инициалы главы администрации  муниципального образования
        /// </summary>
        public string RecipientFio { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// с каго года 
        /// </summary>
        public string Agelife { get; set; }

        /// <summary>
        /// причины отсутствия жилой площади или необходимости замены ее
        /// </summary>
        public string Reasons { get; set; }

        /// <summary>
        /// характеристика жилого помещения и занимаемой площади
        /// </summary>
        public string Characteristic { get; set; }

        /// <summary>
        /// наименование места работы
        /// </summary>
        public string PlacesWork { get; set; }

        /// <summary>
        /// с каго года 
        /// </summary>
        public string AgeWork { get; set; }

        /// <summary>
        /// должность
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// с каго года 
        /// </summary>
        public string AgePost { get; set; }


        public Info_Family[] AppliedFamilyList { get; set; }
        public class Info_Family
        {
            /// <summary>
            /// Степень родства
            /// </summary>
            public string Degree_Kinship { get; set; }

            /// <summary>
            /// с каго года времени  проживает совместно
            /// </summary>
            public string AgeLife { get; set; }

            /// <summary>
            /// дату   рождения   
            /// </summary>
            public DateTime? DateB  { get; set; }
        }
        /// <summary>
        /// Приложения
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Наименование документа
            /// </summary>
            public string Name { get; set; }
        }
        /// <summary>
        /// количество человек
        /// </summary>
        public int Count_Family { get; set; }
    }
}
    