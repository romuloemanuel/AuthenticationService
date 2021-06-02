#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY /src/AuthenticationService/AuthenticationService.csproj  src/AuthenticationService/

COPY . .

RUN dotnet restore  src/AuthenticationService/AuthenticationService.csproj

WORKDIR src/AuthenticationService
RUN dotnet build  AuthenticationService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AuthenticationService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
EXPOSE 80

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "AuthenticationService.dll"]