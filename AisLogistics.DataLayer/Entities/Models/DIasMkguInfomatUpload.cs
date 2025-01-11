using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Данный об отправке пакетов в ИАС МКГУ оценных через инфомат
    /// </summary>
    public partial class DIasMkguInfomatUpload
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с номером дела
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// фргу, id  органа власти
        /// </summary>
        public string FrguProviderId { get; set; }
        /// <summary>
        /// фргу, id услуги
        /// </summary>
        public string FrguServiceId { get; set; }
        /// <summary>
        /// фргу, id цели
        /// </summary>
        public string FrguTargetId { get; set; }
        /// <summary>
        /// Идентификатор процедуры ФРГУ
        /// </summary>
        public string FrguProcedureId { get; set; }
        /// <summary>
        /// Идентификатор запроса СМЭВ 3
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// id пакета с фргу
        /// </summary>
        public string PackedId { get; set; }
        /// <summary>
        /// vendor id филиала
        /// </summary>
        public int? OfficeVendorId { get; set; }
        /// <summary>
        /// окато Дагестана
        /// </summary>
        public string Okato { get; set; }
        /// <summary>
        /// Внутренний идетификатор пользователя ИАС МКГУ
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        public string UserMail { get; set; }
        /// <summary>
        /// Дата добавления записи
        /// </summary>
        public DateTime? DateAdd { get; set; }
        /// <summary>
        /// Дата фактического добавления записи
        /// </summary>
        public DateTime DateEnterFact { get; set; }
        /// <summary>
        /// Связь с офисом в котором принята услуга
        /// </summary>
        public Guid? SOfficesId { get; set; }
        /// <summary>
        /// Cвязь с сотрудником принявшем услугу
        /// </summary>
        public Guid? SEmployeesId { get; set; }
        /// <summary>
        /// Cвязь с должностью сотрудника принявшего услугу
        /// </summary>
        public int? SEmployeesJobPositionId { get; set; }
        /// <summary>
        /// Информация о сотруднике принявшем услугу
        /// </summary>
        public string EmployeesInfo { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SEmployeesJobPosition SEmployeesJobPosition { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
