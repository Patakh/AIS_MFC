using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Статусы заявления в ЕЛК(Единый личный кабинет)
    /// </summary>
    public partial class DElkStatusChange
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь с data_elk_order_id
        /// </summary>
        public Guid DElkOrderId { get; set; }
        /// <summary>
        /// Тип события:
        /// 
        /// 1 = Изменение статуса
        /// 
        /// 2 = Ожидает оплаты
        /// 
        /// 3 = Оплачено
        /// 
        /// 4 = Информационное сообщение
        /// 
        /// 5 = Текстовое сообщение
        /// 
        /// 6 = Приглашение на прием
        /// </summary>
        public int Mode { get; set; }
        /// <summary>
        /// Дата и время события. Если не указано, то на ЕПГУ будет выводиться системная дата получения события. (необязательно)
        /// </summary>
        public DateTime? Eventdate { get; set; }
        /// <summary>
        /// Комментарий к событию, выводится в заявлении в поле «Комментарий» вкладки «История рассмотрения заявления» (необязательно)
        /// </summary>
        public string Eventcomment { get; set; }
        /// <summary>
        /// Автор, Выводится в заявлении в поле «Автор» вкладки «История рассмотрения заявления» (необязательно)
        /// </summary>
        public string Eventauthor { get; set; }
        /// <summary>
        /// Код статуса заявления, используемый в ИС государственного органа (ведомства)
        /// </summary>
        public string Statusorgcode { get; set; }
        /// <summary>
        /// Технологический код статуса на ЕПГУ, перечень технологических кодов приведен в приложении
        /// </summary>
        public int? Statustechcode { get; set; }
        /// <summary>
        /// Возможность запроса Заявителем отмены заявления. По умолчанию cancelAllowed=false. Если cancelAllowed=true, то в карточке заявления отображается кнопка «Отменить заявление».
        /// </summary>
        public int? Cancelallowed { get; set; }
        /// <summary>
        /// Возможность посылки Заявителем текстовых сообщений в ИС государственного органа (ведомства). По умолчанию sendMessageAllowed=false.
        /// </summary>
        public int? Sendmessageallowed { get; set; }
        /// <summary>
        /// Источник начисления, для status=«W» должно быть хотя бы одно начисление, для ФК указывается значение «FK».
        /// </summary>
        public string Paymentsource { get; set; }
        /// <summary>
        /// Уникальный идентификатор начисления, для status=«W» должно быть хотя бы одно начисление.
        /// </summary>
        public string Paymentuin { get; set; }
        /// <summary>
        /// Назначение платежа, для status=«W» должно быть хотя бы одно начисление. Выводится в заявлении в поле «Наименования платежа» вкладки «Счета к оплате».
        /// </summary>
        public string Paymentdescription { get; set; }
        /// <summary>
        /// Код информационного сообщения
        /// </summary>
        public string Infocode { get; set; }
        /// <summary>
        /// Код приглашения в ИС ведомства, используется в дальнейшем для изменения или удаления приглашения
        /// </summary>
        public string Invitecode { get; set; }
        /// <summary>
        /// Действие: ADD - Добавление, UPDATE - Изменение, CANCEL - Отмена.
        /// </summary>
        public string InviteAction { get; set; }
        /// <summary>
        /// Наименование ОИВ. Обязательно, если «action» = «ADD» или «UPDATE». Наименование отделения, офиса.
        /// </summary>
        public string Orgname { get; set; }
        /// <summary>
        /// Адрес ОИВ. Обязательно, если «action» = «ADD» или «UPDATE». Включая офис, кабинет.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Дата и время начала. Обязательно, если «action» = «ADD» или «UPDATE».
        /// </summary>
        public DateTime? Invitestartdate { get; set; }
        /// <summary>
        /// Дата и время окончания (необязательно)
        /// </summary>
        public DateTime? Inviteenddate { get; set; }
        /// <summary>
        /// данные для изменения статуса уже созданной услуги в ЕЛК
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Дата и время создания записи
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Дата и время отправки на сервис
        /// </summary>
        public DateTime? DateSent { get; set; }
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
        /// Идентификатор сообщения СМЭВ 3
        /// </summary>
        public string MessageId { get; set; }

        public virtual DElkOrder DElkOrder { get; set; }
    }
}
