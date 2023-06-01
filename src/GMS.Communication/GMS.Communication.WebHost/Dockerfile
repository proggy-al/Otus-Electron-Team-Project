#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/GMS.Communication/GMS.Communication.WebHost/GMS.Communication.WebHost.csproj", "src/GMS.Communication/GMS.Communication.WebHost/"]
COPY ["src/GMS.Common/GMS.Common/GMS.Common.csproj", "src/GMS.Common/GMS.Common/"]
COPY ["src/GMS.Communication/GMS.Communication.Core/GMS.Communication.Core.csproj", "src/GMS.Communication/GMS.Communication.Core/"]
COPY ["src/GMS.Communication/GMS.Communication.DataAccess.Sqlite/GMS.Communication.DataAccess.Sqlite.csproj", "src/GMS.Communication/GMS.Communication.DataAccess.Sqlite/"]
COPY ["src/GMS.Core/GMS.Core.DataAccess/GMS.Core.DataAccess.csproj", "src/GMS.Core/GMS.Core.DataAccess/"]
COPY ["src/GMS.Core/GMS.Core.Core/GMS.Core.Core.csproj", "src/GMS.Core/GMS.Core.Core/"]
COPY ["src/GMS.Communication/GMS.Communication.DataAccess/GMS.Communication.DataAccess.csproj", "src/GMS.Communication/GMS.Communication.DataAccess/"]
RUN dotnet restore "src/GMS.Communication/GMS.Communication.WebHost/GMS.Communication.WebHost.csproj"
COPY . .
WORKDIR "/src/src/GMS.Communication/GMS.Communication.WebHost"
RUN dotnet build "GMS.Communication.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMS.Communication.WebHost.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMS.Communication.WebHost.dll"]