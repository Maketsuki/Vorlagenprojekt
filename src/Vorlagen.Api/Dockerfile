# build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Vorlagen.Api/Vorlagen.Api.csproj", "Vorlagen.Api/"]
COPY ["Vorlagen.Application/Vorlagen.Application.csproj", "Vorlagen.Application/"]
COPY ["Vorlagen.Domain/Vorlagen.Domain.csproj", "Vorlagen.Domain/"]
COPY ["Vorlagen.Infrastructure/Vorlagen.Infrastructure.csproj", "Vorlagen.Infrastructure/"]

RUN dotnet restore "Vorlagen.Api/Vorlagen.Api.csproj"

COPY . .
WORKDIR "/src/Vorlagen.Api"
RUN dotnet publish "Vorlagen.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Vorlagen.Api.dll"]
