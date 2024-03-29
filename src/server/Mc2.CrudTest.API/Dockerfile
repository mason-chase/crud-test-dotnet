
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/server/Mc2.CrudTest.API/Mc2.CrudTest.API.csproj", "src/server/Mc2.CrudTest.API/"]
COPY ["src/server/Mc2.CrudTest.Application/Mc2.CrudTest.Application.csproj", "src/server/Mc2.CrudTest.Application/"]
COPY ["src/shared/Mc2.CrudTest.Common/Mc2.CrudTest.Common.csproj", "src/shared/Mc2.CrudTest.Common/"]
COPY ["src/shared/Mc2.CrudTest.Contracts/Mc2.CrudTest.Contracts.csproj", "src/shared/Mc2.CrudTest.Contracts/"]
COPY ["src/server/Mc2.CrudTest.Domain/Mc2.CrudTest.Domain.csproj", "src/server/Mc2.CrudTest.Domain/"]
COPY ["src/server/Mc2.CrudTest.Infra/Mc2.CrudTest.Infra.csproj", "src/server/Mc2.CrudTest.Infra/"]
RUN dotnet restore "./src/server/Mc2.CrudTest.API/Mc2.CrudTest.API.csproj"
COPY . .
WORKDIR "/src/src/server/Mc2.CrudTest.API"
RUN dotnet build "./Mc2.CrudTest.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Mc2.CrudTest.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.API.dll"]