# docker build --no-cache -t dating-authentication-service:latest -f dating-authentication-api.dockerfile .
# docker run -d -p 1001:8080 --name dating-authentication-service dating-authentication-service:latest


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Dating.Authentication.API/Dating.Authentication.API.csproj", "Dating.Authentication.API/"]
COPY ["Dating.Authentication.Application/Dating.Authentication.Application.csproj", "Dating.Authentication.Application/"]
COPY ["Dating.Authentication.Domain/Dating.Authentication.Domain.csproj", "Dating.Authentication.Domain/"]
COPY ["Dating.Shared/Dating.Shared.csproj", "Dating.Shared/"]
COPY ["Dating.Authentication.Infrastructure/Dating.Authentication.Infrastructure.csproj", "Dating.Authentication.Infrastructure/"]

RUN dotnet restore "./Dating.Authentication.API/Dating.Authentication.API.csproj"

COPY . .

WORKDIR "/src/Dating.Authentication.API"
RUN dotnet build "./Dating.Authentication.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./Dating.Authentication.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dating.Authentication.API.dll"]