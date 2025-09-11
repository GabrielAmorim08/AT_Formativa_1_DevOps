#Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solution e csproj
COPY ATV_Formativa.WebAPI/ATV_Formativa.WebAPI.sln ./ 
COPY ATV_Formativa.WebAPI/ATV_Formativa.Web.Services/*.csproj ATV_Formativa.Web.Services/
# Restaurar dependências
RUN dotnet restore ATV_Formativa.WebAPI.sln

COPY . .

#Publish
WORKDIR /src/ATV_Formativa.WebAPI/ATV_Formativa.Web.Services
RUN dotnet publish -c Release -o /app/publish

#Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

#porta
EXPOSE 8080

ENTRYPOINT ["dotnet", "ATV_Formativa.Web.API.dll","--port","80"]
