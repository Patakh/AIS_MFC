using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.App.Models.DTO.References;
using Microsoft.AspNetCore.Identity;

namespace AisLogistics.App.Service
{
    public interface IIdentityService<TUserDto, TUser, TRole, TKey>
        where TUserDto : UserDto<TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<(IdentityResult identityResult, TKey userId)> CreateUserAsync(TUserDto user);

        /// <summary>
        /// Назначить пользователю роль
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="roleId">ID роли</param
        Task<IdentityResult> CreateUserRoleAsync(TKey userId, TKey roleId);

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
        Task<IdentityResult> DeleteUserRoleAsync(TKey userId, TKey roleId);
        //Task DeleteUserRoleAsync(TKey userId, TKey roleId);

        /// <summary>
        /// Существует ли пользователь с указанным ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        Task<bool> ExistsUserAsync(TKey userId);

        /// <summary>
        /// Получить все роли в системе
        /// </summary>
        Task<List<IdentityRoleDto>> GetRolesAsync();

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        Task<TUserDto> GetUserAsync(TKey userId);

        /// <summary>
        /// Получить роли пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        Task<List<TRole>> GetUserRolesAsync(TKey userId);

        /// <summary>
        /// Изменить пароль пользователя
        /// </summary>
        /// <param name="userPassword">Данные о новом пароле</param>
        Task<IdentityResult> UserChangePasswordAsync(UserPasswordChangeDto<TKey> userPassword);
    }
}
