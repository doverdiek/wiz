#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebshopProductService/WSProductService/WSInformationService.csproj", "WebshopProductService/WSProductService/"]
COPY ["WebshopAuth/WebshopAuth.csproj", "WebshopAuth/"]
COPY ["DataModels/DataModels/DataModels.csproj", "DataModels/DataModels/"]
COPY ["MongoDBCrudLibrary/MongoDBCrudLibrary.csproj", "MongoDBCrudLibrary/"]
RUN dotnet restore "WebshopProductService/WSProductService/WSInformationService.csproj"
COPY . .
WORKDIR "/src/WebshopProductService/WSProductService"
RUN dotnet build "WSInformationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WSInformationService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WSInformationService.dll"]