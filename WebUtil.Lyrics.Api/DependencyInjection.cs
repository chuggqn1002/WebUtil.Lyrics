using Dapper;
using WebUtil.Lyrics.Common;
using WebUtil.Lyrics.Service;

namespace WebUtil.Lyrics
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMappings();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<JwtService>();
            AddServices();
            return services;
        }


        public static void AddServices()
        {
            SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());
            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));
        }

     
    }
}