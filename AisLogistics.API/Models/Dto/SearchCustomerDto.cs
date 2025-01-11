namespace AisLogistics.API.Models.Dto
{
    public class SearchCustomerDto
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string customer_fio { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? document_birth_date { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public string customer_sex { get; set; }
        /// <summary>
        /// Адрес 
        /// </summary>
        public string customer_address { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string customer_email { get; set; }
        /// <summary>
        /// Снилс
        /// </summary>
        public string customer_snils { get; set; }
    }
}
