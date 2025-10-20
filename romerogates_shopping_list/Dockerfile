# Étape 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier le fichier .csproj depuis le sous-dossier et restaurer les dépendances
COPY romerogates_shopping_list/*.csproj ./
RUN dotnet restore

# Copier tout le code depuis le sous-dossier
COPY romerogates_shopping_list/. ./
RUN dotnet publish -c Release -o out

# Étape 2 : Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copier les fichiers buildés
COPY --from=build /app/out .

# Exposer le port
EXPOSE 8080

# Lancer l’application
ENTRYPOINT ["dotnet", "romerogates_shopping_list.dll"]
