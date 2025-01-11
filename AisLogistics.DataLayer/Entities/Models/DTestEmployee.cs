using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class DTestEmployee
    {
        public DTestEmployee() 
        {
            DTestQuestionsEmployees = new HashSet<DTestQuestionsEmployee>();
        }  
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Тест
        /// </summary>
        public Guid DTestId { get; set; }
        /// <summary>
        /// Сотрудники
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Офис (МФЦ)
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string EmployeesName { get; set; }
        /// <summary>
        /// Наименование офиса
        /// </summary>
        public string OfficesName { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string JobPositionsName { get; set; }
        /// <summary>
        /// Дата начала теста
        /// </summary>
        public DateTime? DateStart { get; set; }
        /// <summary>
        /// Дата окончание теста
        /// </summary>
        public DateTime? DateStop { get; set; }
        /// <summary>
        /// Количество отвечаных вопров 
        /// </summary>
        public short? NumberQuestionsAnswered { get; set; }
        /// <summary>
        /// Количество правильных ответов
        /// </summary>
        public short? NumberCorrectQuestions { get; set; }
        /// <summary>
        /// Количествот не правильных вопросов
        /// </summary>
        public short? NumberIncorrectQuestions { get; set; }
        /// <summary>
        /// Процент результат
        /// </summary>
        public short? PercentResult { get; set; }
        /// <summary>
        /// Остаточное время
        /// </summary>
        public long TestTime { get; set; }

        public virtual DTest DTest { get; set; }
        public virtual SEmployee SEmployee { get; set; }
        public virtual SOffice SOffice { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }    
        public virtual ICollection<DTestQuestionsEmployee> DTestQuestionsEmployees { get; set; }
    }
}
