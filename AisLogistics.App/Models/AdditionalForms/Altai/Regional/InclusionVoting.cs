namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Заявление_о_включении_в_список_избирателей_на_выборах_Президента
    /// </summary>
    public class InclusionVoting : AbstractAdditionalFormModel
    {

        /// <summary>
        /// Дата голосования
        /// </summary>
        public string DateVoting { get; set; }

        /// <summary> 
        /// № избирательного участка
        /// </summary>
        public string PollingStationNumber { get; set; }

        /// <summary> 
        /// Адрес избирательного участка
        /// </summary>
        public string AdressVoting { get; set; }
         
        /// <summary>
        /// субъекта Российской Федерации по месту нахождения
        /// </summary>
        public string RegionCodeByLocation { get; set; } 
    }
}
