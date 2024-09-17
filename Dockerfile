FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY login-isaias.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app


# runs it using aspnet runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "login-isaias.dll"]