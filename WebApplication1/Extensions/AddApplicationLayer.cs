using Buisness.Abastraction;
using Buisness.Concrete;
using Core.Models;

namespace WebApplication1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region

           services.AddScoped<IUserService, UserService>();
           services.AddScoped<IVehicleService, VehicleService>();
           services.AddScoped(typeof(ApiResponse));
            return services;
            #endregion

        }

    }
}
