FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app
COPY . .

# Restore dependencies
RUN dotnet restore src/Seed.Console

# Publish project
RUN dotnet publish src/Seed.Console -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Seed.Console.dll"]