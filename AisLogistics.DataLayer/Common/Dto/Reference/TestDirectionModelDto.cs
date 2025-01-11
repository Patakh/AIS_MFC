using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class TestDirectionModelDto
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string DirectionName { get; set; }
        /// <summary>
        /// Дата и время внесения изменений
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        public List<int> STestDirectionJobsId { get; set; }
    }
}
