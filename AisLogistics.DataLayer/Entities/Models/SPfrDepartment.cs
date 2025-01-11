using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Мнемоники территориальных подразделений Пенсионного фонда 
    /// </summary>
    public partial class SPfrDepartment
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Мнемоника отделения
        /// </summary>
        public string PfrMnemo { get; set; }
        /// <summary>
        /// Наименование отделения
        /// </summary>
        public string PfrName { get; set; }
        /// <summary>
        /// Номер пачки для интеграции с ПФР
        /// </summary>
        public int DckNumber { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime? DateAdd { get; set; }
        /// <summary>
        /// ФИО сотрудника добавившего запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// комментарий
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// ОКАТО
        /// </summary>
        public string Okato { get; set; }
        /// <summary>
        /// ОКТМО
        /// </summary>
        public string Oktmo { get; set; }
    }
}
