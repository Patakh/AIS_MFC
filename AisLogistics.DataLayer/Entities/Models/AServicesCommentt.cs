using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Список комментариев к архивным услугам
    /// </summary>
    public partial class AServicesCommentt
    {
        public AServicesCommentt()
        {
            AServicesCommenttEmployees = new HashSet<AServicesCommenttEmployee>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с обращением
        /// </summary>
        public string ACasesId { get; set; }
        /// <summary>
        /// Дата добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Публичность примечания
        /// </summary>
        public bool IsPublicCommentt { get; set; }
        /// <summary>
        /// Наличие получателя
        /// </summary>
        public bool IsUnicast { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Филиал сотрудника добавившего запись
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Должность сотрудника добавившего запись
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual ACase ACases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual ICollection<AServicesCommenttEmployee> AServicesCommenttEmployees { get; set; }
    }
}
