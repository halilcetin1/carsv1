using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Extensions
{
    public static class PersistenExtensions
    {

        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services,IConfiguration configuration) {


            services.AddDbContext<ApplicationDbContext>(options =>

            {
                var version = new MySqlServerVersion(new Version(8, 0, 33));
                options.UseMySql(configuration.GetConnectionString("mysql"), version);

            });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
           return services;

        }
    }


}
