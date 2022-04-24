# Anotações básicas sobre o projeto

Incluir uma migration
```sh
    dotnet ef migrations add <migration-name> -v 
```

Criar o diretorio `Migrations/Sql`, caso nao exista e por fim gerar o script através do dotnet ef
```sh
    mkdir -p Migrations/Sql
    dotnet ef migrations script --idempotent > ./Migrations/Sql/IniciarBanco.sql
```

Executar o script IniciarBanco.sql para gerar as tabelas.

Por fim, repetir os passos para cada nova migration.

