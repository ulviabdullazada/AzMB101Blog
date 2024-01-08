using Microsoft.AspNetCore.Identity;
using Twitter.Core.Entities;
using Twitter.DAL.Contexts;

namespace Twitter.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<TwitterContext>();
            return services;
        }
    }
}
