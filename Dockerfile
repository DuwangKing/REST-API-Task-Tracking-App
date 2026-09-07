FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY TodoApp/TodoApp.csproj ./TodoApp/
RUN dotnet restore ./TodoApp/TodoApp.csproj
COPY . .
RUN dotnet publish ./TodoApp/TodoApp.csproj -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "TodoApp.dll"]
