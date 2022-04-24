using Shoppinho.Lojas.Api.Configuracoes;

WebApplication
    .CreateBuilder(args)
    .ConfigInit()
    .ConfigurarServices()
    .Build()
    .ConfigureApp()
    .Run();
