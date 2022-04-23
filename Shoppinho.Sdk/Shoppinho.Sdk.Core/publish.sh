#!/bin/bash

# Autor: Leandro Alves
# Data: 23/04/2022
# solução temporária para publicar novos pacotes.
# posteriormente separar esse pacote um repositÓrio 
# próprio e implementar uma esteira de CI/CD

ls -l

NOME_PACOTE=Shoppinho.Sdk.Core
NOME_PROJETO="$NOME_PACOTE.csproj"
VERSAO_ATUAL="$(cat $NOME_PROJETO | grep -Eo "[0-9].[0-9]*.[0-9]")"
echo So pra voce saber, a versao atual e: $VERSAO_ATUAL

echo
echo Qual sera proxima versao?
read NOVA_VERSAO

sed -i "s/$VERSAO_ATUAL/$NOVA_VERSAO/" $NOME_PROJETO

echo o arquivo "$NOME_PROJETO" foi atualizado para a versao $NOVA_VERSAO.

rm -rf ./bin/Release/$NOME_PACOTE*.nupkg

dotnet build -c Release

dotnet nuget push --source "Shoppinho"  --api-key $AZDEV_NUGET_APIKEY  ./bin/Release/$NOME_PACOTE.$NOVA_VERSAO.nupkg  --skip-duplicate

echo "O pacote [$NOME_PACOTE.$NOVA_VERSAO] foi publicado no feed [Azure Devops/Artifacts]"