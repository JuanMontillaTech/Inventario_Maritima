@echo off
echo
set/p nDll= ¿DLL name?
@echo FROM mcr.microsoft.com/dotnet/core/aspnet:3.1> Dockerfile
@echo WORKDIR /app>> Dockerfile
@echo COPY . .>> Dockerfile
@echo CMD ASPNETCORE_URLS=http://*:$PORT dotnet %nDll%.dll>> Dockerfile