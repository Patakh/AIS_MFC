using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник запросов к сервисам СМЭВ (Систе́ма межве́домственного электро́нного взаимоде́йствия)
    /// </summary>
    public partial class SSmevRequest
    {
        public SSmevRequest()
        {
            AServicesSmevRequests = new HashSet<AServicesSmevRequest>();
            DServicesSmevRequests = new HashSet<DServicesSmevRequest>();
            SDocumentsSmevRequestJoins = new HashSet<SDocumentsSmevRequestJoin>();
            SServicesSmevRequestJoins = new HashSet<SServicesSmevRequestJoin>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Связь с типом запроса СМЭВ
        /// </summary>
        public int SSmevTypeRequestId { get; set; }
        /// <summary>
        /// Наименование запроса
        /// </summary>
        public string RequestName { get; set; }
        /// <summary>
        /// Количество дней на выполнение запроса
        /// </summary>
        public int CountDayExecution { get; set; }
        /// <summary>
        /// Активность запроса
        /// </summary>
        public bool? IsRequestActive { get; set; }
        /// <summary>
        /// Путь к сервису
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Реестровый номер услуги. При наличии  - цель оказания государственной услуги. Из справочника Услуги ЕПГУ / ФРГУ. Заполняется в блоке атрибутов бизнес процесса СМЭВ 3.
        /// </summary>
        public string ServiceOrFunctionCode { get; set; }
        /// <summary>
        /// Сервис СМЭВ
        /// </summary>
        public Guid SSmevId { get; set; }
        /// <summary>
        /// Тип отсчета дней
        /// </summary>
        public int SServicesWeekId { get; set; }
        /// <summary>
        /// Путь к методу
        /// </summary>
        public string ActionPath { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual SServicesWeek SServicesWeek { get; set; }
        public virtual SSmev SSmev { get; set; }
        public virtual SSmevTypeRequest SSmevTypeRequest { get; set; }
        public virtual ICollection<AServicesSmevRequest> AServicesSmevRequests { get; set; }
        public virtual ICollection<DServicesSmevRequest> DServicesSmevRequests { get; set; }
        public virtual ICollection<SDocumentsSmevRequestJoin> SDocumentsSmevRequestJoins { get; set; }
        public virtual ICollection<SServicesSmevRequestJoin> SServicesSmevRequestJoins { get; set; }
    }
}
