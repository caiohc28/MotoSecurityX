
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["MotoSecurityX.csproj", "./"]
RUN dotnet restore "MotoSecurityX.csproj"

COPY . .
RUN dotnet build "MotoSecurityX.csproj" -c Release -o /app/build

RUN dotnet publish "MotoSecurityX.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

RUN groupadd -r appuser && useradd -r -g appuser appuser

WORKDIR /app

COPY --from=build /app/publish .

RUN chown -R appuser:appuser /app

USER appuser

EXPOSE 5024

# Variáveis de ambiente (podem ser sobrescritas no docker run)
ENV ASPNETCORE_URLS=http://+:5024
ENV ASPNETCORE_ENVIRONMENT=Production

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "MotoSecurityX.dll"]