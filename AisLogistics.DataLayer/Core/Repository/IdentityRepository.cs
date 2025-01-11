using AisLogistics.DataLayer.Core.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Core.Repository
{
    public class IdentityRepository<TIdentityDbContext, TUser, TRole, TKey> :
        IIdentityRepository<TUser, TRole, TKey>
        where TIdentityDbContext : IdentityDbContext<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        protected readonly TIdentityDbContext _idbContext;
        protected readonly UserManager<TUser> _userManager;
        protected readonly RoleManager<TRole> _roleManager;

        public IdentityRepository(TIdentityDbContext idbContext, UserManager<TUser> userManager, RoleManager<TRole> roleManager)
        {
            _idbContext = idbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Существует ли пользователь с указанным ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public Task<bool> ExistsUserAsync(TKey userId)
        {
            return _userManager.Users.AnyAsync(x => x.Id.Equals(userId));

        }

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public async Task<TUser> GetUserAsync(TKey userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        /// <summary>
        /// Получить все роли в системе
        /// </summary>
        public Task<List<TRole>> GetRolesAsync()
        {
            return _roleManager.Roles.ToListAsync();
        }

        /// <summary>
        /// Получить роли пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public async Task<List<TRole>> GetUserRolesAsync(TKey userId)
        {
            //var user = await _idbContext.Set<TUser>()
            //    .FindAsync(userId);

            var roles = from r in _idbContext.Set<TRole>()
                        join ur in _idbContext.Set<IdentityUserRole<TKey>>() on r.Id equals ur.RoleId
                        where ur.UserId.Equals(userId)
                        select r;

            return await roles.ToListAsync();

            //var userRoles = _idbContext.Set<IdentityUserRole<TKey>>()
            //    .ToList();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Сменить пароль пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="password">Новый пароль</param>
        public async Task<IdentityResult> UserChangePasswordAsync(TKey userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return await _userManager.ResetPasswordAsync(user, token, password);
        }

        /// <summary>
        /// Назначить пользователю роль
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="roleId">ID роли</param>
        public virtual async Task<IdentityResult> CreateUserRoleAsync(string userId, string roleId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new InvalidOperationException("Пользователь не найден!");

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
                throw new InvalidOperationException("Роль не найдена!");

            if (await _userManager.IsInRoleAsync(user, role.Name))
                throw new InvalidOperationException("Пользователь уже в этой роли!");

            //await _idbContext.Set<IdentityUserRole<TKey>>()
            //    .AddAsync(new IdentityUserRole<TKey>() { RoleId = role.Id, UserId = user.Id });

            //await _idbContext.SaveChangesAsync();

            //try
            //{
            //    var result = await _userManager.UpdateAsync(user);
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

            //return await _userManager.UpdateAsync(user);

            return await _userManager.AddToRoleAsync(user, role.Name);
        }

        /// <summary>
        /// Удалить роль пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="roleId">ID роли</param>
        public async Task<IdentityResult> DeleteUserRoleAsync(TKey userId, TKey roleId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
                throw new InvalidOperationException("Пользователь не найден");

            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role is null)
                throw new InvalidOperationException("Роль не найдена!");

            //_idbContext.Set<IdentityUserRole<TKey>>()
            //    .Remove(new IdentityUserRole<TKey>() { RoleId = roleId, UserId = userId });

            //await _idbContext.SaveChangesAsync();

            //return await _userManager.UpdateAsync(user);

            return await _userManager.RemoveFromRoleAsync(user, role.Name);
        }

        /// <summary>
        /// Удалить роль пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="roleId">ID роли</param>
        public async Task<IdentityResult> DeleteUserRoleAsync(string userId, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            var user = await _userManager.FindByIdAsync(userId);

            return await _userManager.RemoveFromRoleAsync(user, role.Name);
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        public async Task<(IdentityResult identityResult, TKey userId)> CreateUserAsync(TUser user)
        {
            if (await _userManager.FindByNameAsync(user.UserName) == null)
            {
                var identityResult = await _userManager.CreateAsync(user);

                return (identityResult, user.Id);
            }

            throw new InvalidOperationException($"Пользователь с логином {user.UserName} уже существует!");

            //var identityResult = await _userManager.CreateAsync(user);

            //return (identityResult, user.Id);
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public async Task<IdentityResult> DeleteUserAsync(TKey userId)
        {
            var userIdentity = await _userManager.FindByIdAsync(userId.ToString());

            return await _userManager.DeleteAsync(userIdentity);
        }
    }
}
