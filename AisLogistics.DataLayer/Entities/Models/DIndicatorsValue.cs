using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Значения показателей для отчетов
    /// </summary>
    public partial class DIndicatorsValue
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Филиал/Организация
        /// </summary>
        public Guid? SOfficesId { get; set; }
        /// <summary>
        /// Удаленное рабочее место(ТОСП)
        /// </summary>
        public Guid? SOfficesRemoteWorkplaceId { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Guid? SEmployeesId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int? SEmplyeesJobPositionId { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        public Guid? SServicesId { get; set; }
        /// <summary>
        /// Запрос СМЭВ
        /// </summary>
        public int? SSmevRequestId { get; set; }
        /// <summary>
        /// Этап
        /// </summary>
        public int? SRoutesStageId { get; set; }
        /// <summary>
        /// Статус услуги
        /// </summary>
        public int? SServicesStatusId { get; set; }
        /// <summary>
        /// Месяц
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// Квартал
        /// </summary>
        public int Quarter { get; set; }
        /// <summary>
        /// Полугодие
        /// </summary>
        public int HalfYear { get; set; }
        /// <summary>
        /// Год
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Значение показателя
        /// </summary>
        public decimal IndicatorValue { get; set; }
        /// <summary>
        /// Дата значения показателя
        /// </summary>
        public DateTime IndicatorDate { get; set; }
        /// <summary>
        /// Показатель
        /// </summary>
        public int SIndicatorsId { get; set; }
        /// <summary>
        /// Поставщик услуги
        /// </summary>
        public Guid? SOfficesIdProvider { get; set; }
        /// <summary>
        /// Тип получателя
        /// </summary>
        public int? SServicesCustomerTypeId { get; set; }
        /// <summary>
        /// Сервис СМЭВ
        /// </summary>
        public Guid? SSmevId { get; set; }
        /// <summary>
        /// Процедура
        /// </summary>
        public Guid? SServicesProcedureId { get; set; }
        /// <summary>
        /// Тип услуги
        /// </summary>
        public int? SServicesTypeId { get; set; }
        /// <summary>
        /// Вид взаимодействия
        /// </summary>
        public int? SServicesInteractionId { get; set; }
        public virtual SIndicator SIndicators { get; set; }
    }
}
