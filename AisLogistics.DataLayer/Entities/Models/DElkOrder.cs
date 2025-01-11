using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Данные заявления для отправки в ЕЛК(Единый личный кабинет).
    /// </summary>
    public partial class DElkOrder
    {
        public DElkOrder()
        {
            DElkStatusChanges = new HashSet<DElkStatusChange>();
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
        /// Идентификатор, который передается в CaseNumber, генерируется из триггера.
        /// </summary>
        public int? AisOrderId { get; set; }
        /// <summary>
        /// Идентификатор интерактивной формы на ЕПГУ
        /// </summary>
        public string Eservicecode { get; set; }
        /// <summary>
        /// Идентификатор цели обращения услуги в ФРГУ
        /// </summary>
        public string Servicetargetcode { get; set; }
        /// <summary>
        /// Тип пользователя:
        /// 
        /// PERSON – физическое лицо, 
        /// 
        /// LEGAL – юридическое лицо,
        /// 
        /// SOLE_PROPRIETOR – индивидуальный предприниматель,
        /// 
        /// FOREIGNER – иностранный гражданин
        /// </summary>
        public string Usertype { get; set; }
        /// <summary>
        /// СНИЛС заявителя (сотрудника юридического лица) или логин заявителя
        /// </summary>
        public string Snils { get; set; }
        /// <summary>
        /// Фамилия заявителя (сотрудника юридического лица)
        /// </summary>
        public string CustomerLastName { get; set; }
        /// <summary>
        /// Имя заявителя (сотрудника юридического лица)
        /// </summary>
        public string CustomerFirstName { get; set; }
        /// <summary>
        /// Отчество заявителя (сотрудника юридического лица) - необязательно
        /// </summary>
        public string CustomerMiddleName { get; set; }
        /// <summary>
        /// ОГРН юридического лица или ОГРНИП индивидуального предпринимателя - обязательно для для UserType = LEGAL или SOLE_PROPRIETOR
        /// </summary>
        public string Ogrn { get; set; }
        /// <summary>
        /// Местоположение заявителя по ОКАТО
        /// </summary>
        public string ServiceOkato { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// данные для регистрации услуги в ЕЛК для клиента
        /// </summary>
        public string OrderComment { get; set; }
        /// <summary>
        /// Дата и время создания записи
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Дата и время отправки на сервис
        /// </summary>
        public DateTime? DateSent { get; set; }
        /// <summary>
        /// Уникальный идентификатор заявления на ЕПГУ
        /// </summary>
        public long? Orderid { get; set; }
        /// <summary>
        /// Код результата выполнения
        /// </summary>
        public string Responsecode { get; set; }
        /// <summary>
        /// Описание кода результата выполнения
        /// </summary>
        public string ResponsecodeDescription { get; set; }
        /// <summary>
        /// XML запроса
        /// </summary>
        public byte[] RequestXml { get; set; }
        /// <summary>
        /// XML ответа
        /// </summary>
        public byte[] ResponseXml { get; set; }
        /// <summary>
        /// Идентификатор цепочки сообщений, полученный от СМЭВ.
        /// </summary>
        public string RequestIdRef { get; set; }
        /// <summary>
        /// Идентификатор сообщения СМЭВ 3
        /// </summary>
        public string MessageId { get; set; }

        public virtual DService DServices { get; set; }
        public virtual ICollection<DElkStatusChange> DElkStatusChanges { get; set; }
    }
}
