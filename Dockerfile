FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-stage
WORKDIR /src
COPY . .