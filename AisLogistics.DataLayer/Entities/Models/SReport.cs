using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class SReport
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование отчета
        /// </summary>
        public string ReportName { get; set; }
        /// <summary>
        /// Связь с отчетом группы
        /// </summary>
        public Guid SReportGroupId { get; set; }
        /// <summary>
        /// Шаблон (FastReport)
        /// </summary>
        public byte[] ReportFile { get; set; }
        /// <summary>
        /// Путь к файлу в АИС
        /// </summary>
        public string ReportPath { get; set; }
        /// <summary>
        /// Сортировка по важности
        /// </summary>
        public int ReportOrder { get; set; }
        /// <summary>
        /// Функция
        /// </summary>
        public string ReportFunction { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Активность отчета
        /// </summary>
        public bool IsActive { get; set; }
        public virtual SReportGroup SReportGroups { get; set; }
    }
}
