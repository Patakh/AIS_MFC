using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник тарифов к подуслугам заявителей
    /// </summary>
    public partial class SServicesCustomerTariff
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь с получателем услуги
        /// </summary>
        public Guid SServicesCustomerId { get; set; }
        /// <summary>
        /// Связь с типом тарифа
        /// </summary>
        public int SServicesTariffTypeId { get; set; }
        /// <summary>
        /// Тип отсчета дней
        /// </summary>
        public int SServicesWeekId { get; set; }
        /// <summary>
        /// Количество дней на обработку
        /// </summary>
        public int CountDayProcessing { get; set; }
        /// <summary>
        /// Количество дней на исполнение в органе власти
        /// </summary>
        public int CountDayExecution { get; set; }
        /// <summary>
        /// Количество дней на возврат документов с органа власти
        /// </summary>
        public int CountDayReturn { get; set; }
        /// <summary>
        /// Тариф государственной пошлины
        /// </summary>
        public decimal Tariff { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Тариф для МФЦ
        /// </summary>
        public decimal TariffMfc { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Процедура
        /// </summary>
        public Guid SServicesProcedureId { get; set; }

        public virtual SServicesCustomer SServicesCustomer { get; set; }
        public virtual SServicesTariffType SServicesTariffType { get; set; }
        public virtual SServicesWeek SServicesWeek { get; set; }
        public virtual SServicesProcedure SServicesProcedure { get; set; }  
    }
}
