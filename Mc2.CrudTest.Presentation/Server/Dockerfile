#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Mc2.CrudTest.Presentation/Server/Mc2.CrudTest.Presentation.Server.csproj", "Mc2.CrudTest.Presentation/Server/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Mc2.CrudTest.Presentation/Shared/Mc2.CrudTest.Presentation.Shared.csproj", "Mc2.CrudTest.Presentation/Shared/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Mc2.CrudTest.Presentation/Client/Mc2.CrudTest.Presentation.Client.csproj", "Mc2.CrudTest.Presentation/Client/"]
RUN dotnet restore "./Mc2.CrudTest.Presentation/Server/./Mc2.CrudTest.Presentation.Server.csproj"
COPY . .
WORKDIR "/src/Mc2.CrudTest.Presentation/Server"
RUN dotnet build "./Mc2.CrudTest.Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Mc2.CrudTest.Presentation.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./Mc2.CrudTest.Presentation/Server/appsettings.json ./

ENTRYPOINT ["dotnet", "Mc2.CrudTest.Presentation.Server.dll"]