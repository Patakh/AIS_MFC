using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Данный об отправке пакетов в ИАС МКГУ на СМС опрос
    /// </summary>
    public partial class DIasMkguSmsUpload
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
        /// ФРГУ, id  органа власти
        /// </summary>
        public string FrguProviderId { get; set; }
        /// <summary>
        /// ФРГУ, id услуги
        /// </summary>
        public string FrguServiceId { get; set; }
        /// <summary>
        /// ФРГУ, id цели
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
        /// Номер телефона заявителя
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// Эл. почта заявителя
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// Окато Дагестана
        /// </summary>
        public string Okato { get; set; }
        /// <summary>
        /// Дата оказания услуги
        /// </summary>
        public DateTime? ServicesDateFinish { get; set; }
        /// <summary>
        /// vendor id филиала
        /// </summary>
        public int? OfficeVendorId { get; set; }
        /// <summary>
        /// ID пакета с фргу
        /// </summary>
        public string PackedId { get; set; }
        /// <summary>
        /// Дата фактического добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Cвязь с филиалом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
