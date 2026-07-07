FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["Product/Product.API/Product.API.csproj", "Product/Product.API/"]
COPY ["Product/Product.Application/Product.Application.csproj", "Product/Product.Application/"]
COPY ["Product/Product.Domain/Product.Domain.csproj", "Product/Product.Domain/"]
COPY ["Product/Product.Infrastructure/Product.Infrastructure.csproj", "Product/Product.Infrastructure/"]
COPY ["Microservice.Core/Microservice.Core.csproj", "Microservice.Core/"]
COPY ["Microservice.Contracts/Microservice.Contracts.csproj", "Microservice.Contracts/"]

RUN dotnet restore "Product/Product.API/Product.API.csproj"

COPY . .

WORKDIR /src/Product

RUN dotnet build "Product.API/Product.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish

RUN dotnet publish "Product.API/Product.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish  /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.API.dll"]
