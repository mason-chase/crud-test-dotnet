# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/client
COPY . .
RUN dotnet publish -c Release -o /src/client/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /src/client/
COPY --from=build /src/client/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.WebApp.dll"]
