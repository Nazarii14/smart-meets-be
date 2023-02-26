FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY "SmartMeets.csproj" .
RUN dotnet restore "SmartMeets.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "SmartMeets.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartMeets.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartMeets.dll"]