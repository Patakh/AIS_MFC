using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Оплата по услугам
    /// </summary>
    public partial class DServicesPayment
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь с услугой
        /// </summary>
        public Guid DServicesId { get; set; }
        /// <summary>
        /// Связь с офисом
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Связь с сотрудником
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Связь с обращением
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь с заявителем
        /// </summary>
        public Guid DServicesCustomerId { get; set; }
        /// <summary>
        /// Фамилия плательщика
        /// </summary>
        public string CustomerLastName { get; set; }
        /// <summary>
        /// Имя плательщика
        /// </summary>
        public string CustomerFirstName { get; set; }
        /// <summary>
        /// Отчество плательщика
        /// </summary>
        public string CustomerMiddleName { get; set; }
        /// <summary>
        /// Телефон в плательщика
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// СНИЛС плательщика
        /// </summary>
        public string CustomerSnils { get; set; }
        /// <summary>
        /// ИНН плательщика
        /// </summary>
        public string CustomerInn { get; set; }
        /// <summary>
        /// код документа плательщика,
        /// 
        /// «01» – паспорт гражданина РФ;
        /// 
        /// «02» – свидетельство органов ЗАГС о рождении гражданина;
        /// 
        /// «03» – паспорт моряка;
        /// 
        /// «04» – удостоверение личности военнослужащего;
        /// 
        /// «05» – военный билет военнослужащего;
        /// 
        /// «06» – временное удостоверение личности гражданина РФ;
        /// 
        /// «07» – справка об освобождении из мест лишения свободы;
        /// 
        /// «08» – паспорт иностранного гражданина;
        /// 
        /// «09» – вид на жительство;
        /// 
        /// «10» – разрешение на временное проживание;
        /// 
        /// «11» – удостоверение беженца;
        /// 
        /// «12» – миграционная карта;
        /// </summary>
        public string DocumentCode { get; set; }
        /// <summary>
        /// Cерия паспорта плательщика
        /// </summary>
        public string DocumentSerial { get; set; }
        /// <summary>
        /// Номер паспорта плательщика
        /// </summary>
        public string DocumentNumber { get; set; }
        /// <summary>
        /// Номер платежа
        /// </summary>
        public int? PaymentNumber { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime? PaymentDateAdd { get; set; }
        /// <summary>
        /// Дата оплаты по платежу
        /// </summary>
        public DateTime? PaymentDate { get; set; }
        /// <summary>
        /// КБК
        /// </summary>
        public string PaymentKbk { get; set; }
        /// <summary>
        /// ОКТМО
        /// </summary>
        public string PaymentOktmo { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        public string PaymentInn { get; set; }
        /// <summary>
        /// КПП
        /// </summary>
        public string PaymentKpp { get; set; }
        /// <summary>
        /// Назначение платежа (Название услуги)
        /// </summary>
        public string PaymentPurpose { get; set; }
        /// <summary>
        /// Получатель платежа (Название органа исполнительной власти)
        /// </summary>
        public string PaymentCustomer { get; set; }
        /// <summary>
        /// Сумма платежа
        /// </summary>
        public decimal? PaymentValue { get; set; }
        /// <summary>
        /// Идентификатор платежа
        /// </summary>
        public string PaymentOsmpId { get; set; }
        /// <summary>
        /// Идентификатор платежа
        /// </summary>
        public int? PaymentPrvTxn { get; set; }
        /// <summary>
        /// Платежный агент (1 - Чекастер, 2 -  Сотас)
        /// </summary>
        public short PaymentAgent { get; set; }
        /// <summary>
        /// Признак оплаты
        /// </summary>
        public bool? PaymentSign { get; set; }
        /// <summary>
        /// Адрес плательщика
        /// </summary>
        public string PaymentAddress { get; set; }
        /// <summary>
        /// БИК
        /// </summary>
        public string PaymentBik { get; set; }
        /// <summary>
        /// Расчетный счет
        /// </summary>
        public string PaymentRs { get; set; }
        /// <summary>
        /// Наименование банка
        /// </summary>
        public string PaymentBankName { get; set; }
        /// <summary>
        /// Кореспондентский счет
        /// </summary>
        public string PaymentKs { get; set; }
        /// <summary>
        /// Код документа серия и номер???(Серия и номер паспорта есть выше)
        /// </summary>
        public string DocumentInfo { get; set; }
        /// <summary>
        /// id услуги в  териминале
        /// </summary>
        public string TerminalId { get; set; }
        /// <summary>
        /// УИН
        /// </summary>
        public string Uin { get; set; }
        /// <summary>
        /// Наименование заявителя
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Лицевой счет
        /// </summary>
        public string PersonalAccount { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual DService DServices { get; set; }
        public virtual DServicesCustomer DServicesCustomer { get; set; }
        public virtual SEmployee SEmployees { get; set; }
        public virtual SOffice SOffices { get; set; }
    }
}
