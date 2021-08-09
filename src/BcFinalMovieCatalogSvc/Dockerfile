#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/BcFinalMovieCatalogSvc/BcFinalMovieCatalogSvc.csproj", "src/BcFinalMovieCatalogSvc/"]
RUN dotnet restore "src/BcFinalMovieCatalogSvc/BcFinalMovieCatalogSvc.csproj"
COPY . .
WORKDIR "/src/src/BcFinalMovieCatalogSvc"
RUN dotnet build "BcFinalMovieCatalogSvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BcFinalMovieCatalogSvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BcFinalMovieCatalogSvc.dll"]
