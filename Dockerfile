FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /build

COPY NotificationPattern.sln ./

COPY src/NotificationPattern.Domain/*.csproj ./src/NotificationPattern.Domain/
COPY src/NotificationPattern.Data/*.csproj ./src/NotificationPattern.Data/
COPY src/NotificationPattern.Cache/*.csproj ./src/NotificationPattern.Cache/
COPY src/NotificationPattern.Application/*.csproj ./src/NotificationPattern.Application/
COPY src/NotificationPattern.WebApi/*.csproj ./src/NotificationPattern.WebApi/

RUN dotnet restore

COPY . .

WORKDIR /build/src/NotificationPattern.Domain
RUN dotnet build -c Release -o /app

WORKDIR /build/src/NotificationPattern.Data
RUN dotnet build -c Release -o /app

WORKDIR /build/src/NotificationPattern.Application
RUN dotnet build -c Release -o /app

WORKDIR /build/src/NotificationPattern.WebApi
RUN dotnet build -c Release -o /app

WORKDIR /build
FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final

ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "NotificationPattern.WebApi.dll"] 