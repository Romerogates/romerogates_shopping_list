# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier tout le dossier du projet
COPY romerogates_shopping_list/. ./romerogates_shopping_list/

# Définir le répertoire de travail sur le projet avant restore
WORKDIR /src/romerogates_shopping_list

# Restaurer les dépendances
RUN dotnet restore

# Build release
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "romerogates_shopping_list.dll"]
