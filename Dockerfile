# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia apenas o .csproj para restaurar dependências
COPY ["src/services/PetGuardian/PetGuadian.API/PetGuadian.API.csproj", "src/services/PetGuardian/PetGuadian.API/"]
RUN dotnet restore "src/services/PetGuardian/PetGuadian.API/PetGuadian.API.csproj"

# Copia o restante do código
COPY . .

WORKDIR "/src/src/services/PetGuardian/PetGuadian.API"
RUN dotnet build "PetGuadian.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PetGuadian.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetGuadian.API.dll"]
