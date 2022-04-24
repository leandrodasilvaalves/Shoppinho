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
        <Version>0.1.0</Version>
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
Com esta linha `<GeneratePackageOnBuild>true</GeneratePackageOnBuild>` no arquivo ***.csproj**, o pacote pode ser gerado utilizando o comando de build,  como no exemplo abaixo:
```sh
dotnet build -c Release
```

Antes de ser publicado, o pacote deve ser assinado. No meu caso utilizei um certificado auto assinado e deu tudo certo.
Mais detalhes, aqui: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-nuget-sign
```sh
dotnet nuget sign ./bin/Release/Shoppinho.Sdk.Core.0.1.0.nupkg --certificate-path /home/leandro/workspace/net6/Shoppinho/certificados/localhost.pfx --certificate-password 123mudar --timestamper http://timestamp.digicert.com
```
List of [free rfc3161](https://gist.github.com/Manouchehri/fd754e402d98430243455713efada710) servers.

---

Remover a source manualmente do arquivo `nuget.config` e incluir novamente por linha de comando como nos exemplos abaixo:
```xml
<add key="Shoppinho" value="https://leandroalves86.pkgs.visualstudio.com/Shoppinho/_packaging/Shoppinho/nuget/v3/index.json" />
```
```sh
dotnet nuget add source https://leandroalves86.pkgs.visualstudio.com/Shoppinho/_packaging/Shoppinho/nuget/v3/index.json --name Shoppinho --username leandro_quarteto@hotmail.com --password $AZDEV_NUGET_APIKEY --store-password-in-clear-text
```
Referência do comando acima [aqui](https://stackoverflow.com/questions/54621893/push-nuget-package-to-azure-devops#answer-64295537).

---

Para publicar o pacote execute o comando abaixo:
```sh
dotnet nuget push --source "Shoppinho"  --api-key $AZDEV_NUGET_APIKEY  ./bin/Release/Shoppinho.Sdk.Core.0.1.0.nupkg
```

---

### Não precisa utilizar (Só para conhecimento)
Incluir autor confiável:
```#
dotnet nuget trust author leandroalves86 ./bin/Release/Shoppinho.Sdk.Core.0.1.0.nupkg --allow-untrusted-root --configfile ./nuget.config --verbosity normal
```

## Limpar Cache do Nuget
```sh 
# Clear the 3.x+ cache (use either command)
dotnet nuget locals http-cache --clear
nuget locals http-cache -clear

# Clear the 2.x cache (NuGet CLI 3.5 and earlier only)
nuget locals packages-cache -clear

# Clear the global packages folder (use either command)
dotnet nuget locals global-packages --clear
nuget locals global-packages -clear

# Clear the temporary cache (use either command)
dotnet nuget locals temp --clear
nuget locals temp -clear

# Clear the plugins cache (use either command)
dotnet nuget locals plugins-cache --clear
nuget locals plugins-cache -clear

# Clear all caches (use either command)
dotnet nuget locals all --clear
nuget locals all -clear
```
Mais informações [Aqui](https://docs.microsoft.com/pt-br/nuget/consume-packages/managing-the-global-packages-and-cache-folders#clearing-local-folders)


## Referências
 - https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-nuget-trust
 - https://stackoverflow.com/questions/54621893/push-nuget-package-to-azure-devops#answer-64295537
 - https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-nuget-push
 - https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-nuget-push#examples
 - https://docs.microsoft.com/pt-br/nuget/consume-packages/managing-the-global-packages-and-cache-folders