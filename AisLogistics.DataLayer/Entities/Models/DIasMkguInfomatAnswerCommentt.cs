using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Комментарии к ответам ИАС мкгу через инфомат
    /// </summary>
    public partial class DIasMkguInfomatAnswerCommentt
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
        /// Комментарий
        /// </summary>
        public string CommenttAnswer { get; set; }

        public virtual DCase DCases { get; set; }
    }
}
