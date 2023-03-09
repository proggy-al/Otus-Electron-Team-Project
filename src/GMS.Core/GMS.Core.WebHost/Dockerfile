#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/GMS.Core/GMS.Core.WebHost/GMS.Core.WebHost.csproj", "src/GMS.Core/GMS.Core.WebHost/"]
COPY ["src/GMS.Core/GMS.Core.BusinessLogic/GMS.Core.BusinessLogic.csproj", "src/GMS.Core/GMS.Core.BusinessLogic/"]
COPY ["src/GMS.Core/GMS.Core.Core/GMS.Core.Core.csproj", "src/GMS.Core/GMS.Core.Core/"]
COPY ["src/GMS.Core/GMS.Core.DataAccess/GMS.Core.DataAccess.csproj", "src/GMS.Core/GMS.Core.DataAccess/"]
RUN dotnet restore "src/GMS.Core/GMS.Core.WebHost/GMS.Core.WebHost.csproj"
COPY . .
WORKDIR "/src/src/GMS.Core/GMS.Core.WebHost"
RUN dotnet build "GMS.Core.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMS.Core.WebHost.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMS.Core.WebHost.dll"]