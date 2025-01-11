using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Этапы по архивным услугам
    /// </summary>
    public partial class AServicesRoutesStage
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с головной услугой
        /// </summary>
        public Guid AServicesIdParent { get; set; }
        /// <summary>
        /// Связь с услугой
        /// </summary>
        public Guid AServicesId { get; set; }
        /// <summary>
        /// Номер дела
        /// </summary>
        public string ACasesId { get; set; }
        /// <summary>
        /// Дата начала этапа
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Количество дней на исполнение этапа
        /// </summary>
        public int? CountDayExecution { get; set; }
        /// <summary>
        /// Фактическое затраченное время на исполнение этапа
        /// </summary>
        public int? CountDayFact { get; set; }
        /// <summary>
        /// Регламентная дата окончания этапа
        /// </summary>
        public DateTime? DateReg { get; set; }
        /// <summary>
        /// Фактическая дата окончания этапа
        /// </summary>
        public DateTime? DateFact { get; set; }
        /// <summary>
        /// Фактическое время окончания этапа
        /// </summary>
        public TimeOnly? TimeFact { get; set; }
        /// <summary>
        /// Сотрудник на которого перевели этап
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с филиалом сотрудника добавившего этап
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника получившего этап
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Сотрудник который перевел этап
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Передача сотруднику была автоматически или в ручную
        /// </summary>
        public bool PassAutomatically { get; set; }
        /*/// <summary>
        /// Связь со справочником этапов к услуге
        /// </summary>
        public Guid SServicesRoutesStageId { get; set; }*/
        /// <summary>
        /// Этап
        /// </summary>
        public int SRoutesStageId { get; set; }
        /// <summary>
        /// Связь с сотрудником передавшим этап
        /// </summary>
        public Guid SEmployeesIdAdd { get; set; }
        /// <summary>
        /// Связь с должностью сотрудника добавившего этап
        /// </summary>
        public int SEmployeesJobPositionIdAdd { get; set; }

        public virtual ACase ACases { get; set; }
        public virtual AService AServices { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployee SEmployeesIdAddNavigation { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPositionIdAddNavigation { get; set; }
        public virtual SOffice SOffices { get; set; }
        public virtual SRoutesStage SRoutesStage { get; set; }
        public virtual SServicesRoutesStage SServicesRoutesStage { get; set; }
    }
}
