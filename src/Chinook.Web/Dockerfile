#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Chinook.Web/Chinook.Web.csproj", "Chinook.Web/"]
COPY ["Chinook.Core/Chinook.Core.csproj", "Chinook.Core/"]
COPY ["Chinook.Infrastructure/Chinook.Infrastructure.csproj", "Chinook.Infrastructure/"]
RUN dotnet restore "Chinook.Web/Chinook.Web.csproj"
COPY . .
WORKDIR "/src/Chinook.Web"
RUN dotnet build "Chinook.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chinook.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chinook.Web.dll"]