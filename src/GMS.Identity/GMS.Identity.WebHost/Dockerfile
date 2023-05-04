#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/GMS.Identity/GMS.Identity.WebHost/GMS.Identity.WebHost.csproj", "src/GMS.Identity/GMS.Identity.WebHost/"]
COPY ["src/GMS.Common/GMS.Common/GMS.Common.csproj", "src/GMS.Common/GMS.Common/"]
COPY ["src/GMS.Identity/GMS.Identity.Client/GMS.Identity.Client/GMS.Identity.Client.csproj", "src/GMS.Identity/GMS.Identity.Client/GMS.Identity.Client/"]
COPY ["src/GMS.Identity/GMS.Identity.DataAccess/GMS.Identity.DataAccess.csproj", "src/GMS.Identity/GMS.Identity.DataAccess/"]
COPY ["src/GMS.Identity/GMS.Identity.Core/GMS.Identity.Core.csproj", "src/GMS.Identity/GMS.Identity.Core/"]
RUN dotnet restore "src/GMS.Identity/GMS.Identity.WebHost/GMS.Identity.WebHost.csproj"
COPY . .
WORKDIR "/src/src/GMS.Identity/GMS.Identity.WebHost"
RUN dotnet build "GMS.Identity.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMS.Identity.WebHost.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMS.Identity.WebHost.dll"]