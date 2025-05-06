# docker build --no-cache -t dating-api-gateway-service:latest -f dating-api-gateway.dockerfile .
# docker run -d -p 1001:8080 --name dating-api-gateway-service dating-api-gateway-service:latest


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Dating.APIGateway/Dating.APIGateway.csproj", "Dating.APIGateway/"]

RUN dotnet restore "./Dating.APIGateway/Dating.APIGateway.csproj"

COPY . .

WORKDIR "/src/Dating.APIGateway"
RUN dotnet build "./Dating.APIGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./Dating.APIGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dating.APIGateway.dll"]