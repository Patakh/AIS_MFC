using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// соответствие  ключей с электронной очередью
    /// </summary>
    public partial class SQueueJoinOffice
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// МФЦ
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// старый id мфц, в электронной очереди
        /// </summary>
        public int SMfcId { get; set; }

        public virtual SOffice SOffices { get; set; }
    }
}
