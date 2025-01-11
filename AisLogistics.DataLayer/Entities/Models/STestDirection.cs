using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class STestDirection
    {
        public STestDirection() 
        {
            STestDirectionJobs = new HashSet<STestDirectionJob>();
            STestDirectionQuestions = new HashSet<STestDirectionQuestion>();
            DTestDirections = new HashSet<DTestDirection>();
        }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string DirectionName { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }  
        /// <summary>
        /// Дата и время внесения изменений
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        public virtual ICollection<STestDirectionJob> STestDirectionJobs { get; set; }
        public virtual ICollection<STestDirectionQuestion> STestDirectionQuestions { get; set; }
        public virtual ICollection<DTestDirection> DTestDirections { get; set; }
    }
}
