@echo off
title Publicando Automacao C#...
echo ----------------------------------------------------
echo [1/2] Limpando arquivos antigos...
echo ----------------------------------------------------
dotnet clean -c Release

echo.
echo ----------------------------------------------------
echo [2/2] Compilando e gerando o novo executavel (.exe)...
echo ----------------------------------------------------
dotnet publish -c Release -r win-x64 --self-contained false /p:PublishSingleFile=true

echo.
echo ====================================================
echo  SUCESSO! O seu executavel foi atualizado.
echo ====================================================
echo.
echo Pressione qualquer tecla para abrir a pasta do executavel...
pause > nul

:: Abre a pasta onde o .exe foi gerado automaticamente para facilitar
start "" "bin\Release\net8.0\win-x64\publish\"