using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models
{
    public sealed class _InformingClassificationPreRetirementAgeModel : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Отправить уведомление
        /// </summary>
        public bool IsNotificationEmail { get; set; }
        /// <summary>
        /// Почта(Email)
        /// </summary>
        public string NotificationEmail { get; set; }
        /// <summary>
        /// Федеральную налоговую службу;
        /// </summary>
        public bool IsFNS { get; set; }
        /// <summary>
        /// органы государственной власти  субъектов  Российской Федерации в области содействия занятости населения;
        /// </summary>
        public bool IsUSZN { get; set; }
        /// <summary>
        /// работодателю
        /// </summary>
        public bool IsEmployer {  get; set; }
        /// <summary>
        /// иные органы;
        /// </summary>
        public bool IsOtherBodies {  get; set; }
    }
}
