# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier solution et restaurer
COPY *.sln ./
COPY romerogates_shopping_list/*.csproj ./romerogates_shopping_list/
RUN dotnet restore

# Copier tout le code
COPY romerogates_shopping_list/. ./romerogates_shopping_list/
WORKDIR /app/romerogates_shopping_list

# Build release
RUN dotnet publish -c Release -o /app/out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Port pour Render
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "romerogates_shopping_list.dll"]
