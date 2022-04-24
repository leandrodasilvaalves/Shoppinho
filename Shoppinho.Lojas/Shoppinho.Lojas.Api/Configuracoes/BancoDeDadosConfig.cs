using Microsoft.EntityFrameworkCore;
using Shoppinho.Lojas.Api.Infra.Contexts;

namespace Shoppinho.Lojas.Api.Configuracoes
{
    public static class BancoDeDadosConfig
    {
        public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration config)
        {   
            services.AddDbContext<LojaContext>(options =>
                options.UseSqlServer(config.GetConnectionString("SqlServer")));

            return services;
        }
    }
}