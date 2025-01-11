using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Common.Dto.Systems
{
    public class TestModelDto
    {
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
         
        public Guid TestOfficesId { get; set; }
        public DateTime DateStartTest { get; set; }
        public TimeSpan TimeStartTest { get; set; }
        public List<Guid> TestDirectionId { get; set; }
        public List<int> TestEmployeeJobsId { get; set; }
        public List<Guid> TestEmployeesId { get; set; }

    }
}
