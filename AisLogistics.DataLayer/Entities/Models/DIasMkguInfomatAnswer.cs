using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Ответы на вопросы  ИАС МКГУ через теминал
    /// </summary>
    public partial class DIasMkguInfomatAnswer
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь с номером дела
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с вопросом
        /// </summary>
        public int SIasMkguQuestionId { get; set; }
        /// <summary>
        /// Связь с ответом
        /// </summary>
        public int SIasMkguQuestionAnswerId { get; set; }
        /// <summary>
        /// Дата и время ответа
        /// </summary>
        public DateTime DateAnswer { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SIasMkguQuestion SIasMkguQuestion { get; set; }
        public virtual SIasMkguQuestionAnswer SIasMkguQuestionAnswer { get; set; }
    }
}
