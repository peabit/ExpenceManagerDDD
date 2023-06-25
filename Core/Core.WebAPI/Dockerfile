#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Core/Core.WebAPI/Core.WebAPI.csproj", "Core/Core.WebAPI/"]
COPY ["Core/Core.Application/Core.Application.csproj", "Core/Core.Application/"]
COPY ["Core/Core.Domain/Core.Domain.csproj", "Core/Core.Domain/"]
COPY ["Core/Core.Infrastructure/Core.Infrastructure.csproj", "Core/Core.Infrastructure/"]
RUN dotnet restore "Core/Core.WebAPI/Core.WebAPI.csproj"
COPY . .
WORKDIR "/src/Core/Core.WebAPI"
RUN dotnet build "Core.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Core.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Core.WebAPI.dll"]