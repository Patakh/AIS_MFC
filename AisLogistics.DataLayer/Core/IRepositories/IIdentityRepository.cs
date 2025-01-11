using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Core.IRepositories
{
    public interface IIdentityRepository<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        Task<(IdentityResult identityResult, TKey userId)> CreateUserAsync(TUser user);

        /// <summary>
        /// Назначить пользователю роль
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="roleId">ID роли</param>
        Task<IdentityResult> CreateUserRoleAsync(string userId, string roleId);

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        Task<IdentityResult> DeleteUserAsync(TKey userId);

        /// <summary>
        /// Удалить роль пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="roleId">ID роли</param>
        Task<IdentityResult> DeleteUserRoleAsync(string userId, string roleId);
        Task<IdentityResult> DeleteUserRoleAsync(TKey userId, TKey roleId);

        /// <summary>
        /// Существует ли пользователь с указанным ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        Task<bool> ExistsUserAsync(TKey userId);

        /// <summary>
        /// Получить все роли в системе
        /// </summary>
        Task<List<TRole>> GetRolesAsync();

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns></returns>
        Task<TUser> GetUserAsync(TKey userId);

        /// <summary>
        /// Получить роли пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        Task<List<TRole>> GetUserRolesAsync(TKey userId);

        /// <summary>
        /// Сменить пароль пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="password">Новый пароль</param>
        Task<IdentityResult> UserChangePasswordAsync(TKey userId, string password);
    }
}
