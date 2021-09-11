#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Forum/Forum.API/Forum.API.csproj", "Services/Forum/Forum.API/"]
COPY ["BuildingBlocks/BuildingBlocks.API/BuildingBlocks.API.csproj", "BuildingBlocks/BuildingBlocks.API/"]
COPY ["BuildingBlocks/BuildingBlocks.Application/BuildingBlocks.Application.csproj", "BuildingBlocks/BuildingBlocks.Application/"]
COPY ["BuildingBlocks/BuildingBlocks.Domain/BuildingBlocks.Domain.csproj", "BuildingBlocks/BuildingBlocks.Domain/"]
COPY ["Services/Forum/Forum.Application/Forum.Application.csproj", "Services/Forum/Forum.Application/"]
COPY ["Services/Forum/Forum.Domain/Forum.Domain.csproj", "Services/Forum/Forum.Domain/"]
COPY ["Services/Forum/Forum.Infrastructure/Forum.Infrastructure.csproj", "Services/Forum/Forum.Infrastructure/"]
COPY ["BuildingBlocks/BuildingBlocks.Infrastructure/BuildingBlocks.Infrastructure.csproj", "BuildingBlocks/BuildingBlocks.Infrastructure/"]
RUN dotnet restore "Services/Forum/Forum.API/Forum.API.csproj"
COPY . .
WORKDIR "/src/Services/Forum/Forum.API"
RUN dotnet build "Forum.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Forum.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Forum.API.dll"]
