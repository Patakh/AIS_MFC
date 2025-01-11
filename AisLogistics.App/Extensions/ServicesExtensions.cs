using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.App.Service;
using AisLogistics.DataLayer.Core.IRepositories;
using AisLogistics.DataLayer.Core.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AisLogistics.App.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddIdentityServices<TIdentityDbContext, TUserDto, TUser, TRole, TKey>//, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken
            (this IServiceCollection services)
            where TIdentityDbContext : IdentityDbContext<TUser, TRole, TKey>
            where TUserDto : UserDto<TKey>
            where TUser : IdentityUser<TKey>
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
        {
            //Repositories
            services.AddTransient<IIdentityRepository<TUser, TRole, TKey>,
                IdentityRepository<TIdentityDbContext, TUser, TRole, TKey>>();

            //Services
            services.AddTransient<IIdentityService<TUserDto, TUser, TRole, TKey>,
                IdentityService<TUserDto, TUser, TRole, TKey>>();

            return services;
        }
    }
}
