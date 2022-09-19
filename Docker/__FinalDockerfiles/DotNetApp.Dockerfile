FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY / ./

RUN dotnet restore

RUN dotnet publish -c Release --no-restore -o /app



FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "DotNetApp.dll"]

