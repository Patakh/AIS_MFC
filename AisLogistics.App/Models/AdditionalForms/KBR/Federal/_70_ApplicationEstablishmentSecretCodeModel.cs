using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models
{
    public sealed class _70_ApplicationEstablishmentSecretCodeModel : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Секретный  код
        /// </summary>
        public string SecretCode { get; set; }
        /// <summary>
        /// Вариант Секретного коды
        /// </summary>
        public int SecretType { get; set; }
        /// <summary>
        /// Сектретный вопрос
        /// </summary>
        public int SecretAnswerType { get; set; }
        /// <summary>
        /// Сектретный ответ
        /// </summary>
        public string SecretAnswer { get; set;}
        /// <summary>
        /// телефон 1
        /// </summary>
        public string PhoneNumber1 { get; set; }
        /// <summary>
        /// телефон 2
        /// </summary>
        public string PhoneNumber2 { get; set; }
        /// <summary>
        /// телефон 3
        /// </summary>
        public string PhoneNumber3 { get; set;} 
    }
}
