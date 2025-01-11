using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class STestDirectionQuestion
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public Guid STestQuestionId { get; set; }
        /// <summary>
        /// Направление 
        /// </summary>
        public Guid STestDirectionId { get; set; }
        /// <summary>
        /// Дата и время внесения изменений
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        public virtual STestQuestion STestQuestion { get; set; }
        public virtual STestDirection STestDirection { get; set; }  
    }
}
