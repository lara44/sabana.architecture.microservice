FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .

# Restore dependencies using the solution file
RUN dotnet restore sabana.architecture.microservice.sln

# Build and publish the WebApi project
WORKDIR /app/src/MicroProduct.WebApi
RUN dotnet publish -c Release -o /out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "MicroProduct.WebApi.dll"]