using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица параметров зарплаты к должностям
    /// </summary>
    public partial class SPremiumParametrsJobPositionJoin
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с должностью
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Связь с параметром к зарплате
        /// </summary>
        public int SPremiumParametrsId { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public decimal ParametrValue { get; set; }
        /// <summary>
        /// Дата начала действия параметра
        /// </summary>
        public DateTime ParametrDateStart { get; set; }
        /// <summary>
        /// Дата окончания действия параметра
        /// </summary>
        public DateTime? ParametrDateStop { get; set; }
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
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }

        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SPremiumParametr SPremiumParametrs { get; set; }
    }
}
