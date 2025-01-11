using System;
using System.Collections;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class STestAnswer
    {
        public STestAnswer() 
        {
            DTestAnswerEmployees = new HashSet<DTestAnswerEmployee>();
        }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public Guid STestQuestionId { get; set; }
        /// <summary>
        /// Ответ
        /// </summary>
        public string AnswerName { get; set; }
        /// <summary>
        /// Правильность
        /// </summary>
        public bool IsRight { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Дата и время внесения изменений
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        public virtual STestQuestion STestQuestion { get; set; }
        public virtual ICollection<DTestAnswerEmployee> DTestAnswerEmployees { get; set; }
    }
}
