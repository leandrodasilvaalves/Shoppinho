# Anotações básicas sobre a geração de pacotes Nuget


Criar um arquivo: **nuget.config** no mesmo diretório do ***.csproj** com o seguinte conteúdo:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="Shoppinho" value="https://leandroalves86.pkgs.visualstudio.com/Shoppinho/_packaging/Shoppinho/nuget/v3/index.json" />
  </packageSources>
</configuration>
```


Incluir as seguintes informações no ***.csproj**

```xml
<Project Sdk="Microsoft.NET.Sdk">
   ...
    <PropertyGroup>
        <PackageId>Shoppinho.Sdk.Core</PackageId>
        <Version>1.0.0-beta</Version>
        <Authors>Leandro Alves</Authors>
        <Company>leandroalves86</Company>
        <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
    </PropertyGroup>
</Project>
```

Executar o comando baixo para criar o pacote Nuget.
```sh
dotnet pack 
```
Com esta linha no arquivo ***.csproj**, o pacote pode ser gerado utilizando o comando de build,  como no exemplo abaixo:
```sh
dotnet build -c Release
```
Antes de ser publicado, o pacote deve ser assinado. No meu caso utilizei um certificado auto assinado e deu tudo certo.
Mais detalhes, aqui: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-nuget-sign
```sh
dotnet nuget sign ./bin/Release/Shoppinho.Sdk.Core.0.1.0.nupkg --certificate-path /home/leandro/workspace/net6/Shoppinho/certificados/localhost.pfx --certificate-password 123mudar
```

Para publicar o pacote execute o comando abaixo:
```sh
dotnet nuget push --source "Shoppinho"  --api-key $AZDEV_NUGET_APIKEY  ./bin/Release/Shoppinho.Sdk.Core.0.1.0.nupkg
```

Comando para incluir uma source ao arquivo **nuget.config**. 
```sh
 dotnet nuget add source https://leandroalves86.pkgs.visualstudio.com/Shoppinho/_packaging/Shoppinho/nuget/v3/index.json \
-n Shoppinho -u leandro_quarteto@hotmail.com -p $AZDEV_NUGET_APIKEY \
--store-password-in-clear-text
```