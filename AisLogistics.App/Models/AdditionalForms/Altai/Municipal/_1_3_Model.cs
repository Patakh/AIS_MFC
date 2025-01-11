using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///        ЗАЯВЛЕНИЕ 
    /// Прошу учесть моего ребенка
    /// </summary>
    public class _1_3_Model : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Фактический адрес проживания
        /// </summary>
        public string FactAddress { get; set; }

        /// <summary>
        /// Контактные телефоны
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  Ф.И.О. моего ребенка 
        /// </summary>
        public string FioChild { get; set; }

        /// <summary>
        /// число, месяц и год рождения
        /// </summary>
        public DateTime? DateChild { get; set; }

        /// <summary>
        /// так как от выделенного места в детском саду №
        /// </summary>
        public string NumberKindergarten { get; set; }

        /// <summary>
        /// при распределении в 
        /// </summary>
        public DateOnly? Date_Age { get; set; }

        /// <summary>
        /// отказываемся, в связи с тем, что (указать причину)
        /// </summary>
        public string SpecifyReason { get; set; }
    }
    }
    