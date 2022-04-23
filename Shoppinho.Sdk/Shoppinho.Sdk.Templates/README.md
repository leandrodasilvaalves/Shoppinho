# dotnet new (Modelos Personalizados)

## Repositorio do mecanismo de modelo
https://github.com/dotnet/templating/


O modelo é composto pelas seguintes partes:
 - Arquivos e pastas de origem. 
    - Os arquivos e pastas de origem incluem os arquivos e pastas que você desejar que o mecanismo de modelo use
 - Um arquivo de configuração (template.json).
     O arquivo fornece informações de configuração para o mecanismo de modelo.
     - https://docs.microsoft.com/pt-br/dotnet/core/tools/custom-templates#templatejson


É possível criar rapidamente um modelo com base em um projeto existente simplesmente adicionando um arquivo de configuração ./.template.config/template.json ao projeto.

É possível criar rapidamente um modelo com base em um projeto existente simplesmente adicionando um arquivo de configuração ./.template.config/template.json ao projeto.

Um pacote de modelo é um ou mais modelos empacotados em um NuGet pacote. Quando você instala ou desinstala um pacote de modelo, todos os modelos contidos no pacote são adicionados ou removidos, respectivamente. 



## Rerferências:

https://docs.microsoft.com/pt-br/dotnet/core/tools/custom-templates
https://docs.microsoft.com/pt-br/dotnet/core/tutorials/cli-templates-create-item-template
http://json.schemastore.org/template
https://docs.microsoft.com/pt-br/dotnet/core/tutorials/cli-templates-create-project-template
https://docs.microsoft.com/pt-br/dotnet/core/tutorials/cli-templates-create-template-package

