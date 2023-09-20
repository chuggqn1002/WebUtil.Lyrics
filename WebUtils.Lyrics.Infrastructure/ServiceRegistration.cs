using WebUtil.Lyrics.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;
using WebUtil.Lyrics.Infrastructure.Repositories;
using WebUtil.Lyrics.Infrastructure.Services;
using WebUtil.Lyrics.Infrastructure.Authentication;
using StackExchange.Redis;

namespace WebUtil.Lyrics.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IFileHandleService, FileHandleService>();
            services.AddScoped<IImageService, ImageService>();

            services.AddAuth(configuration);
            //Redis cache
            services.AddSingleton<ICacheManager, CacheManagerService>();
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var redisConfig = configuration.GetSection("RedisCacheConfig");

                string HOST_NAME = redisConfig.GetSection("HOST_NAME").Value;
                string PORT_NUMBER = redisConfig.GetSection("PORT_NUMBER").Value;
                string PASSWORD = redisConfig.GetSection("PASSWORD").Value;
                return ConnectionMultiplexer.Connect($"{HOST_NAME}:{PORT_NUMBER},password={PASSWORD}");

            });


        }


        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var JwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, JwtSettings);

            services.AddSingleton(Options.Create(JwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtSettings.Issuer,
                    ValidAudience = JwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(JwtSettings.Secret))
                });
            return services;
        }
    }
}
