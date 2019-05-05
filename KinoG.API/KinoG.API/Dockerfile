FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["KinoG.API/KinoG.API.csproj", "KinoG.API/"]
COPY ["KinoG.BL/KinoG.BL.csproj", "KinoG.BL/"]
COPY ["KinoG.DAL/KinoG.DAL.csproj", "KinoG.DAL/"]
RUN dotnet restore "KinoG.API/KinoG.API.csproj"
COPY . .
WORKDIR "/src/KinoG.API"
RUN dotnet build "KinoG.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KinoG.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KinoG.API.dll"]