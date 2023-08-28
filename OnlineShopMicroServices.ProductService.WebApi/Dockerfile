#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OnlineShopMicroServices.ProductService.WebApi/OnlineShopMicroServices.ProductService.WebApi.csproj", "OnlineShopMicroServices.ProductService.WebApi/"]
RUN dotnet restore "OnlineShopMicroServices.ProductService.WebApi/OnlineShopMicroServices.ProductService.WebApi.csproj"
COPY . .
WORKDIR "/src/OnlineShopMicroServices.ProductService.WebApi"
RUN dotnet build "OnlineShopMicroServices.ProductService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineShopMicroServices.ProductService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineShopMicroServices.ProductService.WebApi.dll"]