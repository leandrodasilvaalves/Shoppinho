using Shoppinho.Lojas.Api.Dominio.Interfaces;
using Shoppinho.Lojas.Api.Infra.Repositorios;

namespace Shoppinho.Lojas.Api.Configuracoes
{
    public static class InjecaoDependenciaConfig
    {
        public static IServiceCollection ResolverInjecaoDependencias(this IServiceCollection services)
        {   
            services.AddScoped<ILojaRepositorio, LojaRepositorio>();
            return services;
        }
    }
}