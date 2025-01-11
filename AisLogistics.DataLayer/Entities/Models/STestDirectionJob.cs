using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class STestDirectionJob
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public Guid STestDirectionId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Дата и время внесения изменений
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        public virtual STestDirection STestDirection { get; set; }    
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set;}
    }
}
