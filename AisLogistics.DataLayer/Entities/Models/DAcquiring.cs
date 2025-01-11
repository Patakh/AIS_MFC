using System;

namespace AisLogistics.DataLayer.Entities.Models
{
    public class DAcquiring
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с обращением
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с услугой
        /// </summary>
        public Guid DServicesId { get; set; }
        /// <summary>
        /// Ссылка на заявителя
        /// </summary>
        public Guid DServicesCustomersId { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Дата внесения услуги
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Сумма к оплате, в рублях
        /// </summary>
        public Decimal? Summ { get; set; }
        /// <summary>
        /// Карта МИР и все остальные
        /// </summary>
        public bool IsMirCard { get; set; }
        /// <summary>
        /// Этап выполнения метода, где: 0 - Новая запись 1 - PreparationV2 2 - Verification 3 - PrecheckV2 4 - Execution 5 - VerificationV2 6 - Check 7 - Validation
        /// </summary>
        public int Stage { get; set; }
        /// <summary>
        /// Текущий статус: IN_WORK AWAIT SUCCESS FAILED UNKNOWN
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Описание статуса
        /// </summary>
        public string StatusDescription { get; set; }
        /// <summary>
        /// ip адрес окна откуда пришел запрос
        /// </summary>
        public string IpWindow { get; set; }
        /// <summary>
        /// Связь с офисом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// УИН ГИСГМП
        /// </summary>
        public string Uin { get; set; }
        /// <summary>
        /// Ссылка на получателя платежа ЕСЛИ ССЫЛКА ПУСТАЯ ЗНАЧИТ РЕКВИЗИТЫ ПОЛУЧАТЕЛЯ ПОЛУЧИЛИ ЧЕРЕЗ УИН
        /// </summary>
        public Guid? SRecipientPaymentId { get; set; }
        /// <summary>
        /// Тип платежа: 1 - Госпошлина 2 - Часть платы МФЦ
        /// </summary>
        public int TypePaymet { get; set; }
    }
}
