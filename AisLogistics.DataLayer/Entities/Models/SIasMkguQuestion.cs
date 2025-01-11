using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Вопросы ИАС МКГУ для терминала
    /// </summary>
    public partial class SIasMkguQuestion
    {
        public SIasMkguQuestion()
        {
            DIasMkguInfomatAnswers = new HashSet<DIasMkguInfomatAnswer>();
            SIasMkguQuestionAnswers = new HashSet<SIasMkguQuestionAnswer>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public string Question { get; set; }

        public virtual ICollection<DIasMkguInfomatAnswer> DIasMkguInfomatAnswers { get; set; }
        public virtual ICollection<SIasMkguQuestionAnswer> SIasMkguQuestionAnswers { get; set; }
    }
}
