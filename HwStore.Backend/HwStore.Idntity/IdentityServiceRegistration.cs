using HwStore.Application.Contract.Identity;
using HwStore.Application.Models.Identity;
using HwStore.Identity.Services;
using HwStore.Idntity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HwStore.Idntity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<HwStoreIdentityDbContext>(opt => opt
            .UseSqlServer(configuration.GetConnectionString("HwStoreIdentityConnectionString"),
                migrateConf => migrateConf.MigrationsAssembly(typeof(HwStoreIdentityDbContext).Assembly.FullName)));

            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HwStoreIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            o.TokenValidationParameters=new TokenValidationParameters
            {
                ValidateIssuerSigningKey=true,
                ValidateIssuer=true,
                ValidateAudience=true,
                ValidateLifetime=true,
                ClockSkew=TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            }
            );
            return services;
        }
    }
}