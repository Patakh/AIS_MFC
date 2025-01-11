using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица запросов  СМЭВ
    /// </summary>
    public partial class DServicesSmevRequest
    {
        public DServicesSmevRequest()
        {
            DAisOpvAnketStatuses = new HashSet<DAisOpvAnketStatus>();
            DAisOpvChats = new HashSet<DAisOpvChat>();
            DAlertEmployees = new HashSet<DAlertEmployee>();
            DServicesSmevRequestStatuses = new HashSet<DServicesSmevRequestStatus>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с услугой
        /// </summary>
        public Guid DServicesId { get; set; }
        /// <summary>
        /// Связь с номером дела
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с запросом СМЭВ
        /// </summary>
        public int SSmevRequestId { get; set; }
        /// <summary>
        /// Связь с сотрудником отправившим запрос
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// ID сообщения
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// ID органа исполнительной власти
        /// </summary>
        public string MessageIdProvider { get; set; }
        /// <summary>
        /// ID запроса для повторного запроса сведений
        /// </summary>
        public string RequestIdRef { get; set; }
        /// <summary>
        /// Дата запроса
        /// </summary>
        public DateTime? DateRequest { get; set; }
        /// <summary>
        /// Время запроса
        /// </summary>
        public TimeOnly? TimeRequest { get; set; }
        /// <summary>
        /// Кол-во дней на исполнение запроса
        /// </summary>
        public int? CountDayExecution { get; set; }
        /// <summary>
        /// Тип отсчета дней для запроса
        /// </summary>
        public int? SServicesWeekId { get; set; }
        /// <summary>
        /// Дата ответа - фактическая
        /// </summary>
        public DateTime? DateFact { get; set; }
        /// <summary>
        /// Дата ответа - регламентная
        /// </summary>
        public DateTime DateReg { get; set; }
        /// <summary>
        /// Время ответа - фактическое
        /// </summary>
        public TimeOnly? TimeFact { get; set; }
        /// <summary>
        /// Наименование файла хранящего ответ
        /// </summary>
        public string ResponseFileName { get; set; }
        /// <summary>
        /// Является ли запрос повторным?
        /// </summary>
        public bool Repeat { get; set; }
        /// <summary>
        /// Сериализованный XML, описывающий HTML отчет для запроса.
        /// </summary>
        public byte[] RequestHtml { get; set; }
        /// <summary>
        /// Сериализованный XML, описывающий HTML отчет для окончательного ответа.
        /// </summary>
        public byte[] ResponseHtml { get; set; }
        /// <summary>
        /// Сериализованный XML, описывающий HTML отчет для промежуточного ответа, полученного после выполнения первой фазы асинхронного запроса.
        /// </summary>
        public byte[] ResponseHtmlInt { get; set; }
        /// <summary>
        /// Связь с филиалом сотрудника
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// ФИО сотрудника добавившего запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Сотрудник прочитавший
        /// </summary>
        public string EmployeeFioRead { get; set; }
 

        public virtual DCase DCases { get; set; }
        public virtual DService DServices { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual SServicesWeek SServicesWeek { get; set; }
        public virtual SSmevRequest SSmevRequest { get; set; }
        public virtual ICollection<DAisOpvAnketStatus> DAisOpvAnketStatuses { get; set; }
        public virtual ICollection<DAisOpvChat> DAisOpvChats { get; set; }
        public virtual ICollection<DAlertEmployee> DAlertEmployees { get; set; }
        public virtual ICollection<DServicesSmevRequestStatus> DServicesSmevRequestStatuses { get; set; }
    }
}
