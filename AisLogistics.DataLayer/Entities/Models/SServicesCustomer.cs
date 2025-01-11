using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник типов заявителей к подуслугам
    /// </summary>
    public partial class SServicesCustomer
    {
        public SServicesCustomer()
        {
            SServicesCustomerTariffs = new HashSet<SServicesCustomerTariff>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с подуслугой
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Связь с типом получателей
        /// </summary>
        public int SServicesCustomerTypeId { get; set; }
        /// <summary>
        /// Перечень представителей
        /// </summary>
        public string RepresentativeList { get; set; }
        /// <summary>
        /// Документ подтверждающий право представителя
        /// </summary>
        public string RepresentativeDocument { get; set; }
        /// <summary>
        /// Требование к документу права представителя
        /// </summary>
        public string RepresentativeSpecification { get; set; }
        /// <summary>
        /// Возможность подачи заявления представителем
        /// </summary>
        public bool Representative { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual SService SServices { get; set; }
        public virtual SServicesCustomerType SServicesCustomerType { get; set; }
        public virtual ICollection<SServicesCustomerTariff> SServicesCustomerTariffs { get; set; }
    }
}
