using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Варианты ответов на вопросы ИАС МКГУ для терминалов
    /// </summary>
    public partial class SIasMkguQuestionAnswer
    {
        public SIasMkguQuestionAnswer()
        {
            DIasMkguInfomatAnswers = new HashSet<DIasMkguInfomatAnswer>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Связь со справочником вопросов
        /// </summary>
        public int SIasMkguQuestionId { get; set; }
        /// <summary>
        /// Короткий ответ
        /// </summary>
        public string AnswerSmall { get; set; }
        /// <summary>
        /// Полный ответ
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// Оценка по 5-ти бальной шкале
        /// </summary>
        public int? AnswerRating { get; set; }

        public virtual SIasMkguQuestion SIasMkguQuestion { get; set; }
        public virtual ICollection<DIasMkguInfomatAnswer> DIasMkguInfomatAnswers { get; set; }
    }
}
