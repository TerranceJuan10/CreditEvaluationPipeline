# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /srcFROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
 
WORKDIR /src
 
COPY ["Creditevaluation.csproj", "."]
 
RUN dotnet restore "Creditevaluation.csproj"
 
COPY . .
 
RUN dotnet publish "Creditevaluation.csproj" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
 
WORKDIR /app
 
COPY --from=build /app/publish .
# ? This is a Dockerfile instruction, not a terminal command
 
ENV ASPNETCORE_ENVIRONMENT=Development
 
ENV ASPNETCORE_URLS=http://+:88
EXPOSE 88
 
ENTRYPOINT ["dotnet", "Creditevaluation.dll"]

 
 
