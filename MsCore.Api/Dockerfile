#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MsCore.Api/MsCore.Api.csproj", "MsCore.Api/"]
COPY ["MsCore.Application/MsCore.Application.csproj", "MsCore.Application/"]
COPY ["MsCore.Domain/MsCore.Domain.csproj", "MsCore.Domain/"]
COPY ["MsCore.Infrastructure/MsCore.Infrastructure.csproj", "MsCore.Infrastructure/"]
RUN dotnet restore "MsCore.Api/MsCore.Api.csproj"
COPY . .
WORKDIR "/src/MsCore.Api"
RUN dotnet build "MsCore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MsCore.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MsCore.Api.dll"]