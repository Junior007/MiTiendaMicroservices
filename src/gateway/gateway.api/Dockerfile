#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/gateway/gateway.api/gateway.api.csproj", "src/gateway/gateway.api/"]
RUN dotnet restore "src/gateway/gateway.api/gateway.api.csproj"
COPY . .
WORKDIR "/src/src/gateway/gateway.api"
RUN dotnet build "gateway.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gateway.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gateway.api.dll"]