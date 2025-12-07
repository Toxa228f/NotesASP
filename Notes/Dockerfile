FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Notes/*.csproj Notes/
COPY Notes.Dal/*.csproj Notes.Dal/
COPY Notes.Service/*.csproj Notes.Service/
COPY Notes.Domain/*.csproj Notes.Domain/
RUN dotnet restore Notes/Notes.csproj
COPY . .
WORKDIR /src/Notes
RUN dotnet build Notes.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish Notes.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notes.dll"]