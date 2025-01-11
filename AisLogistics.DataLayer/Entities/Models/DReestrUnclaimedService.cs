using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class DReestrUnclaimedService
    {
        /// <summary>
        /// Ключ
        /// </summary
        public Guid Id { get; set; }
        /// <summary>
        /// Реестр
        /// </summary
        public Guid DReestrId { get; set; }
        /// <summary>
        /// Услуга
        /// </summary
        public Guid DServicesId { get; set; }
        /// <summary>
        /// Обращение
        /// </summary
        public string DCasesId { get; set; }
        /// <summary>
        /// Обращение
        /// </summary
        public string CustomerName { get; set; }
        /// <summary>
        /// Заявитель
        /// </summary
        public string? CustomerAddress { get; set; }
        /// <summary>
        /// Номер телефона 1
        /// </summary
        public string CustomerPhone1 { get; set; }
        /// <summary>
        /// Номер телефона 2
        /// </summary
        public string CustomerPhone2 { get; set; }
        public virtual DReestrUnclaimed DReestrUnclaimed { get; set; }
        public virtual DService DServices { get; set; }
        public virtual DCase DCases { get; set; }
    }
}
