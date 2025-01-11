using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Core.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AisLogistics.App.Service
{
    public class IdentityService<TUserDto, TUser, TRole, TKey> : IIdentityService<TUserDto, TUser, TRole, TKey>
        where TUserDto : UserDto<TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        protected readonly IIdentityRepository<TUser, TRole, TKey> _identityRepository;
        protected readonly IMapper _mapper;

        public IdentityService(IIdentityRepository<TUser, TRole, TKey> identityRepository,
            IMapper mapper)
        {
            _identityRepository = identityRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Существует ли пользователь с указанным ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public Task<bool> ExistsUserAsync(TKey userId)
        {
            return _identityRepository.ExistsUserAsync(userId);
        }

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public async Task<TUserDto> GetUserAsync(TKey userId)
        {
            var identityUser = await _identityRepository.GetUserAsync(userId);
            if (identityUser == null)
                throw new InvalidOperationException("Пользователь не найден!");

            var result = _mapper.Map<TUserDto>(identityUser);

            return result;
        }

        /// <summary>
        /// Получить все роли в системе
        /// </summary>
        public async Task<List<IdentityRoleDto>> GetRolesAsync()
        {
            var roles = await _identityRepository.GetRolesAsync();
            var results = _mapper.Map<List<IdentityRoleDto>>(roles);

            return results;
        }

        /// <summary>
        /// Получить роли пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public async Task<List<TRole>> GetUserRolesAsync(TKey userId)
        {
            return await _identityRepository.GetUserRolesAsync(userId);
        }

        /// <summary>
        /// Изменить пароль пользователя
        /// </summary>
        /// <param name="userPassword">Данные о новом пароле</param>
        public async Task<IdentityResult> UserChangePasswordAsync(UserPasswordChangeDto<TKey> userPassword)
        {
            var userExists = await _identityRepository.ExistsUserAsync(userPassword.UserId);
            if (!userExists) throw
                    new InvalidOperationException("Пользователь не найден!");

            var identityResult = await _identityRepository.UserChangePasswordAsync(userPassword.UserId, userPassword.NewPassword);

            return HandleIdentityErrors(identityResult);

            //if (identityResult.Succeeded)
            //    return identityResult;

            //throw new InvalidOperationException(identityResult.Errors?.ToString());
        }

        /// <summary>
        /// Назначить пользователю роль
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="roleId">ID роли</param>
        public virtual async Task<IdentityResult> CreateUserRoleAsync(TKey userId, TKey roleId)
        {
            var identityResult = await _identityRepository.CreateUserRoleAsync(userId.ToString(), roleId.ToString());
            return identityResult;

            //if (identityResult.Succeeded)
            //    return identityResult;

            //throw new InvalidOperationException(identityResult.Errors?.ToString());
        }

        /// <summary>
        /// Удалить роль пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="roleId">ID роли</param>
        public async Task<IdentityResult> DeleteUserRoleAsync(TKey userId, TKey roleId)
        {
            var identityResult = await _identityRepository.DeleteUserRoleAsync(userId, roleId);
            return HandleIdentityErrors(identityResult);
            //if (identityResult.Succeeded)
            //    return identityResult;

            //throw new InvalidOperationException(identityResult.Errors?.ToString());
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        public async Task<(IdentityResult identityResult, TKey userId)> CreateUserAsync(TUserDto user)
        {
            var userIdentity = _mapper.Map<TUser>(user);
            var (identityResult, userId) = await _identityRepository.CreateUserAsync(userIdentity);

            return (identityResult, userId);
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public async Task<IdentityResult> DeleteUserAsync(TKey userId)
        {
            var identityResult = await _identityRepository.DeleteUserAsync(userId);

            return HandleIdentityErrors(identityResult);
        }

        private IdentityResult HandleIdentityErrors(IdentityResult identityResult)
        {
            if (!identityResult.Errors.Any())
                return identityResult;

            var errorMessages = string.Join(Environment.NewLine, identityResult.Errors.SelectMany(x => x.Description));

            throw new InvalidOperationException(errorMessages);
        }
    }
}
