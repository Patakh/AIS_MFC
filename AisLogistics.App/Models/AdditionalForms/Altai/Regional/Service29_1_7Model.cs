using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
   
    public class Service29_1_7Model : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Заявитель
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public string Date { get; set; }

        
        /// <summary>
        /// Адрес 
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// орган регистрации прав 
        /// </summary>
        public string Organ { get; set; }

        /// <summary>
        /// № 
        /// </summary>
        public string Number { get; set; }


        /// <summary>
        /// № 
        /// </summary>
        public string Number_Kadastr { get; set; }

        /// <summary>
        /// Принадлежность площади  
        /// </summary>
        public string Ownership { get; set; }
        /// <summary>
        ///Ф.И.О. руководителя юридического лица или иного лица, имеющего право действовать от имени этого юридического лица / (Ф.И.О. индивидуального предпринимателя)
        /// </summary>
        public string Fio_Manager { get; set; }

    }
}
