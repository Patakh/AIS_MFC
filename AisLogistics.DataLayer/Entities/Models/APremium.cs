using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Зарплата сотрудников
    /// </summary>
    public partial class APremium
    {
        public APremium()
        {
            APremiumFines = new HashSet<APremiumFine>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Cвязь с должностью
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Cвязь с филиалом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// День
        /// </summary>
        public DateTime PeriodDate { get; set; }
        /// <summary>
        /// Месяц
        /// </summary>
        public int PeriodMonth { get; set; }
        /// <summary>
        /// Год
        /// </summary>
        public int PeriodYear { get; set; }
        /// <summary>
        /// Количество рабочих дней в периоде
        /// </summary>
        public int? PeriodCountDay { get; set; }
        /// <summary>
        /// Оклад сотрудника за день
        /// </summary>
        public decimal EmployeesSalary { get; set; }
        /// <summary>
        /// Ставка сотрудника
        /// </summary>
        public decimal EmployeesStake { get; set; }
        /// <summary>
        /// Установленная надбавка
        /// </summary>
        public decimal DefaultPremium { get; set; }
        /// <summary>
        /// Премия за собственные действия
        /// </summary>
        public decimal StepPremium { get; set; }
        /// <summary>
        /// Премия за чужие действия
        /// </summary>
        public decimal StepPremiumOther { get; set; }
        /// <summary>
        /// Премия за среднее время ожидания в минутах
        /// </summary>
        public decimal AvgTimeQueuePremium { get; set; }
        /// <summary>
        /// Итоговая зарплата без штрафов
        /// </summary>
        public decimal EmployeesPremium { get; set; }
        /// <summary>
        /// Итоговая зарплата с учетом штрафов
        /// </summary>
        public decimal EmployeesPremiumTotal { get; set; }
        /// <summary>
        /// Сумма штрафа
        /// </summary>
        public decimal FineSum { get; set; }
        /// <summary>
        /// Количество просроченных дней
        /// </summary>
        public int FineCountDays { get; set; }
        /// <summary>
        /// Дата и время добавления данных
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Тип работы. 1 - Основная работа, 2 - Совмещение
        /// </summary>
        public int? JobType { get; set; }
        /// <summary>
        /// Интенсивность за ИАС МКГУ с сайта
        /// </summary>
        public decimal? EmployeesPremiumIasMkgu { get; set; }
        /// <summary>
        /// Интенсивность за ИАС МКГУ наш
        /// </summary>
        public decimal? EmployeesPremiumIasMkguOur { get; set; }
        /// <summary>
        /// Интенсивность за электронную очередь
        /// </summary>
        public decimal? EmployeesPremiumQueue { get; set; }

        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual ICollection<APremiumFine> APremiumFines { get; set; }
    }
}
