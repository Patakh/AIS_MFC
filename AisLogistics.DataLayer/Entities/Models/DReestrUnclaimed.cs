using System.Collections.Generic;
using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public class DReestrUnclaimed
    {
        public DReestrUnclaimed()
        {
            DReestrUnclaimedServices = new HashSet<DReestrUnclaimedService>();
        }
        /// <summary>
        /// Ключ
        /// </summary
        public Guid Id { get; set; }
        /// <summary>
        /// Номер
        /// </summary
        public int ReestrNumber { get; set; }
        /// <summary>
        /// Дата и время формирования
        /// </summary
        public DateTime DateCreate { get; set; }
        /// <summary>
        /// Сотрудник, добавивший заявителя
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Филиал сотрудника, добавившего заявителя
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с подуслугой
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Поставщик услуги
        /// </summary>
        public Guid SServicesIdProviderId { get; set; }
        /// <summary>
        /// Отдел поставщика
        /// </summary>
        public Guid? SServicesIdProviderDepartament { get; set; }

        public virtual SEmployee SEmployees { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual SOffice SServicesIdProviderNavigation { get; set; }
        public virtual SOffice SServicesIdProviderDepartamentNavigation { get; set; }
        public virtual SService SServices { get; set; }
        public virtual ICollection<DReestrUnclaimedService> DReestrUnclaimedServices { get; set; }
    }
}
