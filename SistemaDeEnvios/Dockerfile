# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS Build
WORKDIR /source
COPY . .
RUN dotnet restore "./SistemaDeEnvios/SistemaDeEnvios.csproj" --disable-parallel
RUN dotnet publish "./SistemaDeEnvios/SistemaDeEnvios.csproj" -c debug -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS Stage
WORKDIR /app
COPY --from=Build /app ./
COPY https.pfx ./https/https.pfx

ENV ASPNETCORE_Kestrel__Certificates__Default__Path=./https/https.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=projetoSD123456
ENV ASPNETCORE_URLS=http://+;https://+
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "SistemaDeEnvios.dll"]