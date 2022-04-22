namespace src.Configuracoes
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigurarServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}