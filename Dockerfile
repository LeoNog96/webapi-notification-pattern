FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY NotificationPattern.sln ./

COPY ./src/BarberTeam.EmailServices/*.csproj ./BarberTeam.EmailServices/