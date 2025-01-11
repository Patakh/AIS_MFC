using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class DTestDirection
    {
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Тест
        /// </summary>
        public Guid DTestId { get; set; }
        /// <summary>
        /// Направления
        /// </summary>
        public Guid STestDirectionId { get; set; }

        public virtual DTest DTest { get; set; }
        public virtual STestDirection STestDirection { get; set; }
    }
}
