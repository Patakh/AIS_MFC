using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class DTestAnswerEmployee
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Ответы Справочника
        /// </summary>
        public Guid STestAnswersId { get; set; }
        /// <summary>
        /// Вопросы к сотруднику
        /// </summary>
        public Guid DTestQuestionsEmployeesId { get; set; }
        /// <summary>
        /// Наименование ответа
        /// </summary>
        public string AnswerName { get; set; }
        /// <summary>
        /// Правильность
        /// </summary>
        public bool IsTruth { get; set; }
        /// <summary>
        /// ответ сотрудника
        /// </summary>
        public bool IsResponseEmployees { get; set; }
        /// <summary>
        /// Дата и время ответа
        /// </summary>
        public DateTime DateTimeAnswer { get; set; }
        /// <summary>
        /// IP Адрес
        /// </summary>
        public string IpAddress { get; set; }

        public virtual STestAnswer STestAnswer { get;set;}
        public virtual DTestQuestionsEmployee DTestQuestionsEmployee { get; set; }
    }
}
