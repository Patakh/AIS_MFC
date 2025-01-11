using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Статусы анкет по приему заявлений о выдаче заграничного паспорта, содержащего электронный носитель информации
    /// </summary>
    public partial class DAisOpvAnketStatus
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор запроса, посредством которого отправлена анкета в СМЭВ
        /// </summary>
        public Guid DServicesSmevRequestId { get; set; }
        /// <summary>
        /// Двадцатипятизначный регистрационный номер анкеты
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Фамилия заявителя
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Имя заявителя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество заявителя
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Серия документа заявителя
        /// </summary>
        public string DocumentSeries { get; set; }
        /// <summary>
        /// Номер документа заявителя
        /// </summary>
        public string DocumentNumber { get; set; }
        /// <summary>
        /// Код статуса анкеты:
        /// 1 - Подана
        /// 2 - Оправлена в МВД
        /// 3 - Принята
        /// 4 - Возврат
        /// 5 - Не допущена
        /// 6 - Документ изготовлен
        /// 7 - Документ доставлен
        /// 8 - В процессе отзыва
        /// 9 - Отозвано
        /// 10 - Выдача в МВД
        /// 11 - Документ выдан
        /// 12 - Анкета удалена
        /// 13 - Госпошлина не оплачена
        /// 14 - Нет биометрии
        /// </summary>
        public int AnketStatus { get; set; }
        /// <summary>
        /// Дата и время статуса анкеты
        /// </summary>
        public DateTime AnketStatusDatetime { get; set; }
        /// <summary>
        /// Текcт статуса анкеты
        /// </summary>
        public string AnketStatusName { get; set; }
        /// <summary>
        /// Комментарий к статусу анкеты
        /// </summary>
        public string AnketStatusComment { get; set; }
        /// <summary>
        /// Тип анкеты:
        /// 1 - Взрослая
        /// 2 - Детская
        /// </summary>
        public int AnketType { get; set; }

        public virtual DServicesSmevRequest DServicesSmevRequest { get; set; }
    }
}
