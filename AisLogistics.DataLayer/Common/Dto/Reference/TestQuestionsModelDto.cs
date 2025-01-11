using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class TestQuestionsModelDto
    {
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

        public List<Guid> TestDirectionId { get; set; }
        public List<TestQuestionsAnswerModelDto> TestQuestionsAnswers { get; set; }
    }

    public class TestQuestionsAnswerModelDto
    {
        public Guid Id { get; set; }
        public string AnswerName { get; set; }
        public bool IsRight { get; set; }
    }
}
