#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StackOverflowTagApp.Api/StackOverflowTagApp.Api.csproj", "StackOverflowTagApp.Api/"]
COPY ["StackOverflowTagApp.Core.Application/StackOverflowTagApp.Core.Application.csproj", "StackOverflowTagApp.Core.Application/"]
COPY ["StackOverflowTagApp.Core.Domain/StackOverflowTagApp.Core.Domain.csproj", "StackOverflowTagApp.Core.Domain/"]
COPY ["StackOverflowTagApp.Core.Infrastucture/StackOverflowTagApp.Core.Infrastructure.csproj", "StackOverflowTagApp.Core.Infrastucture/"]
COPY ["StackOverflowTagApp.Core.SQL/StackOverflowTagApp.Core.SQL.csproj", "StackOverflowTagApp.Core.SQL/"]
RUN dotnet restore "./StackOverflowTagApp.Api/StackOverflowTagApp.Api.csproj"
COPY . .
WORKDIR "/src/StackOverflowTagApp.Api"
RUN dotnet build "./StackOverflowTagApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StackOverflowTagApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StackOverflowTagApp.Api.dll"]