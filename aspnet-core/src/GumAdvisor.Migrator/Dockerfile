#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GumAdvisor.Migrator/GumAdvisor.Migrator.csproj", "src/GumAdvisor.Migrator/"]
COPY ["src/GumAdvisor.EntityFrameworkCore/GumAdvisor.EntityFrameworkCore.csproj", "src/GumAdvisor.EntityFrameworkCore/"]
COPY ["src/GumAdvisor.Core/GumAdvisor.Core.csproj", "src/GumAdvisor.Core/"]
COPY ["src/GumAdvisor.Core.Shared/GumAdvisor.Core.Shared.csproj", "src/GumAdvisor.Core.Shared/"]
RUN dotnet restore "src/GumAdvisor.Migrator/GumAdvisor.Migrator.csproj"
COPY . .
WORKDIR "/src/src/GumAdvisor.Migrator"
RUN dotnet build "GumAdvisor.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GumAdvisor.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GumAdvisor.Migrator.dll", "-s"]
