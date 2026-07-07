FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Notification/Notification.API/Notification.API.csproj", "Notification/Notification.API/"]
COPY ["Notification/Notification.Application/Notification.Application.csproj", "Notification/Notification.Application/"]
COPY ["Notification/Notification.Domain/Notification.Domain.csproj", "Notification/Notification.Domain/"]
COPY ["Notification/Notification.Infrastructure/Notification.Infrastructure.csproj", "Notification/Notification.Infrastructure/"]
COPY ["Microservice.Core/Microservice.Core.csproj", "Microservice.Core/"]
COPY ["Microservice.Contracts/Microservice.Contracts.csproj", "Microservice.Contracts/"]

RUN dotnet restore "Notification/Notification.API/Notification.API.csproj"

COPY . .

WORKDIR /src/Notification

RUN dotnet build "Notification.API/Notification.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish

RUN dotnet publish "Notification.API/Notification.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish  /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification.API.dll"]
