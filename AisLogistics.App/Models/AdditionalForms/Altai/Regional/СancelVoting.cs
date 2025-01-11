using DocumentFormat.OpenXml.Bibliography;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Заявление_об_аннулировании_включения_в_список_избирателей.doc
    /// </summary>
    public class СancelVoting : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Дата голосования
        /// </summary>
        public string DateVoting { get; set; } 
    }
}
