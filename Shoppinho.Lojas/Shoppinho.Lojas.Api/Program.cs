using Shoppinho.Lojas.Api.Configuracoes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigurarServices();

builder
.Build()
.ConfigureApp()
.Run();
