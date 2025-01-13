# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# ENV ASPNETCORE_URLS=http://+:80

# FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ARG configuration=Release
# WORKDIR /
# COPY ["server/TodoApi.csproj", "server/"]

# RUN dotnet restore "server/TodoApi.csproj"
# COPY . .
# WORKDIR "/src/server"
# RUN dotnet build "TodoApi.csproj" -c $configuration -o /app/build

# FROM build AS publish
# ARG configuration=Release
# RUN dotnet publish "TodoApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "TodoApi.dll"]
# Base image for runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

# Build image with SDK
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release

WORKDIR /src

# Copy csproj file and restore dependencies
COPY server/TodoApi.csproj server/

# Restore dependencies
RUN dotnet restore "server/TodoApi.csproj"

# Copy the rest of the application
COPY . .

# Build the application
WORKDIR /src/server
RUN dotnet build "TodoApi.csproj" -c $configuration -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "TodoApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Final image with runtime dependencies
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApi.dll"]
