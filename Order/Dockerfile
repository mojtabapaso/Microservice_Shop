FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Order/Order.API/Order.API.csproj", "Order/Order.API/"]
COPY ["Order/Order.Application/Order.Application.csproj", "Order/Order.Application/"]
COPY ["Order/Order.Domain/Order.Domain.csproj", "Order/Order.Domain/"]
COPY ["Order/Order.Infrastructure/Order.Infrastructure.csproj", "Order/Order.Infrastructure/"]
COPY ["Microservice.Core/Microservice.Core.csproj", "Microservice.Core/"]
COPY ["Microservice.Contracts/Microservice.Contracts.csproj", "Microservice.Contracts/"]

RUN dotnet restore "Order/Order.API/Order.API.csproj"

COPY . .

WORKDIR /src/Order

RUN dotnet build "Order.API/Order.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish

RUN dotnet publish "Order.API/Order.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish  /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.API.dll"]
