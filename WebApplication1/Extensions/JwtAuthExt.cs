using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication1.Extensions
{
    public static class JwtAuthExt
    {
       public static IServiceCollection AddJwtAuth(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(
    x => {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidIssuer = "halilcetin.online",
        ValidateAudience = false,
        ValidAudience = "",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Secretkey:jwt").Value ?? "")),
        ValidateLifetime = true
    };
});
            return services;
        }

    }
}
