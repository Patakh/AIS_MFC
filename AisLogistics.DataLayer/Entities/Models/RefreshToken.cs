using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    public partial class RefreshToken
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Токен обновления
        /// </summary>
        public string RefreshToken1 { get; set; }
        /// <summary>
        /// Дата и время до которой действителен токен обновления
        /// </summary>
        public DateTime ExpireTime { get; set; }
        /// <summary>
        /// Статус токена: использован или нет
        /// </summary>
        public bool Used { get; set; }

        public virtual SEmployee SEmployees { get; set; }
    }
}
