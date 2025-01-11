using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class DTest
    {
        public DTest() 
        {
            DTestEmployees = new HashSet<DTestEmployee>();
            DTestDirections = new HashSet<DTestDirection>();
        }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string TestName { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public int TestNumber { get; set; }
        /// <summary>
        /// Время на тест(в минутах)
        /// </summary>
        public short TestTime { get; set; }
        /// <summary>
        /// Количество вопросов
        /// </summary>
        public short CountQuestions { get; set; }
        /// <summary>
        /// Активность
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Дата и время начала теста
        /// </summary>
        public DateTime DateStartTest { get; set; }
        /// <summary>
        /// Дата и время внесения изменений
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        public virtual ICollection<DTestEmployee> DTestEmployees { get; set; }
        public virtual ICollection<DTestDirection> DTestDirections { get; set; }
    }
}
