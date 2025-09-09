using ATV_Formativa.Web.API.Interfaces.NovaPasta;
using ATV_Formativa.Web.API.Interfaces;
using ATV_Formativa.Web.API.Models.Users;
using ATV_Formativa.Web.API.Business.Users;

namespace ATV_Formativa.Web.API.Utils
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersBO>();

            return services;
        }
    }
}
