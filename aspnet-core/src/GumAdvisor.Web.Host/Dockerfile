#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GumAdvisor.Web.Host/GumAdvisor.Web.Host.csproj", "src/GumAdvisor.Web.Host/"]
COPY ["src/GumAdvisor.Web.Core/GumAdvisor.Web.Core.csproj", "src/GumAdvisor.Web.Core/"]
COPY ["src/GumAdvisor.Application/GumAdvisor.Application.csproj", "src/GumAdvisor.Application/"]
COPY ["src/GumAdvisor.Application.Shared/GumAdvisor.Application.Shared.csproj", "src/GumAdvisor.Application.Shared/"]
COPY ["src/GumAdvisor.Core.Shared/GumAdvisor.Core.Shared.csproj", "src/GumAdvisor.Core.Shared/"]
COPY ["src/GumAdvisor.Core/GumAdvisor.Core.csproj", "src/GumAdvisor.Core/"]
COPY ["src/GumAdvisor.EntityFrameworkCore/GumAdvisor.EntityFrameworkCore.csproj", "src/GumAdvisor.EntityFrameworkCore/"]
COPY ["src/GumAdvisor.GraphQL/GumAdvisor.GraphQL.csproj", "src/GumAdvisor.GraphQL/"]
RUN dotnet restore "src/GumAdvisor.Web.Host/GumAdvisor.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/GumAdvisor.Web.Host"
RUN dotnet build "GumAdvisor.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GumAdvisor.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GumAdvisor.Web.Host.dll"]
