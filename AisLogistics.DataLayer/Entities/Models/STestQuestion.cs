using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class STestQuestion
    {
        public STestQuestion() 
        {
            STestAnswers = new HashSet<STestAnswer>();
            STestDirectionQuestions = new HashSet<STestDirectionQuestion>();
            DTestQuestionsEmployees = new HashSet<DTestQuestionsEmployee>();
        }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Тип вопроса
        /// </summary>
        public short QuestionType { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public string QuestionName { get; set; }
        /// <summary>
        /// Активность
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Дата и время внесения изменений
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }

        public virtual ICollection<STestAnswer> STestAnswers { get; set; }
        public virtual ICollection<STestDirectionQuestion> STestDirectionQuestions { get; set; }
        public virtual ICollection<DTestQuestionsEmployee> DTestQuestionsEmployees { get; set; }
    }
}
