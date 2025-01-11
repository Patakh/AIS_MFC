using System;

namespace AisLogistics.DataLayer.Entities;

/// <summary>
/// Информация об авторизованном пользователе
/// </summary>
public class UserClaims
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// ФИО
    /// </summary>
    public string Fio { get; set; }
        
}


public class AuthenticatedUserInfo : UserClaims
{
    /// <summary>
    /// Информация об офисе
    /// </summary>
    public OfficeInfo Office { get; set; }

    /// <summary>
    /// Идентификатор роли сотрудника
    /// </summary>
    public Guid RoleId { get; set; }

    public class OfficeInfo
    {
        /// <summary>
        /// Идентификатор филиала в котором работает сотрудник
        /// </summary>
        public Guid OfficeId { get; set; }
        /// <summary>
        /// Идентификатор должности сотрудника
        /// </summary>
        public int JobPositionId { get; set; }
        /// <summary>
        /// Мнемоника МФЦ
        /// </summary>
        public string OfficeMnemo { get; set; }
    }
}