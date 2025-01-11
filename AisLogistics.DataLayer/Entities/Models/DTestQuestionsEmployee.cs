using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class DTestQuestionsEmployee
    {
        public DTestQuestionsEmployee() 
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
        /// Вопросы к сотруднику
        /// </summary>
        public Guid DTestEmployeesId { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public string QuestionName { get; set; }
        public virtual STestQuestion STestQuestion { get; set; }
        public virtual DTestEmployee DTestEmployee { get; set; }
        public virtual ICollection<DTestAnswerEmployee> DTestAnswerEmployees { get; set; }
    }
}
