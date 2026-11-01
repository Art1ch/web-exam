FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["AuthService/AuthService.Api/AuthService.Api.csproj", "AuthService/AuthService.Api/"]
COPY ["AuthService/AuthService.Application/AuthService.Application.csproj", "AuthService/AuthService.Application/"]
COPY ["AuthService/AuthService.Core/AuthService.Core.csproj", "AuthService/AuthService.Core/"]
COPY ["AuthService/AuthService.Infrastructure/AuthService.Infrastructure.csproj", "AuthService/AuthService.Infrastructure/"]
COPY ["Shared/Shared/Shared.csproj", "Shared/Shared/"]

RUN dotnet restore "AuthService/AuthService.Api/AuthService.Api.csproj"

COPY . .

WORKDIR "/src/AuthService/AuthService.Api"

RUN dotnet publish "AuthService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AuthService.Api.dll"]