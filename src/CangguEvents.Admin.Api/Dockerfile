#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:5.0-buster AS build
WORKDIR /src
COPY ["../CangguEvents.Admin/src/CangguEvents.Admin.Api/CangguEvents.Admin.Api.csproj", "../CangguEvents.Admin/src/CangguEvents.Admin.Api/"]
COPY ["../CangguEvents.Admin/src/CangguEvents.Admin.Application/CangguEvents.Admin.Application.csproj", "../CangguEvents.Admin/src/CangguEvents.Admin.Application/"]
COPY ["../CangguEvents.Domain/src/CangguEvents.Domain/CangguEvents.Domain.csproj", "../CangguEvents.Domain/src/CangguEvents.Domain/"]
COPY ["../CangguEvents.MongoDb/src/CangguEvents.MongoDb/CangguEvents.MongoDb.csproj", "../CangguEvents.MongoDb/src/CangguEvents.MongoDb/"]
RUN dotnet restore "../CangguEvents.Admin/src/CangguEvents.Admin.Api/CangguEvents.Admin.Api.csproj"
COPY . .
WORKDIR "/src/../CangguEvents.Admin/src/CangguEvents.Admin.Api"
RUN dotnet build "CangguEvents.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CangguEvents.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CangguEvents.Admin.Api.dll"]