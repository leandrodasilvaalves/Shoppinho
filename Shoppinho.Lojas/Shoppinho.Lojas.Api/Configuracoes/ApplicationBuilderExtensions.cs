using System.Reflection;

namespace Shoppinho.Lojas.Api.Configuracoes
{
    public static class ApplicationBuilderExtensions
    {

        public static WebApplicationBuilder ConfigInit(this WebApplicationBuilder builder)
        {
            var env = builder.Environment;

            builder.Configuration
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder
                    .Configuration
                    .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true, reloadOnChange: false);
            }
            return builder;
        }

        public static WebApplicationBuilder ConfigurarServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddContexts(builder.Configuration);
            builder.Services.ResolverInjecaoDependencias();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }

        public static WebApplication ConfigureApp(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}