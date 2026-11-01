FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["EmployeeService/EmployeeService.Api/EmployeeService.Api.csproj", "EmployeeService/EmployeeService.Api/"]
COPY ["EmployeeService/EmployeeService.Application/EmployeeService.Application.csproj", "EmployeeService/EmployeeService.Application/"]
COPY ["EmployeeService/EmployeeService.Core/EmployeeService.Core.csproj", "EmployeeService/EmployeeService.Core/"]
COPY ["EmployeeService/EmployeeService.Infrastructure/EmployeeService.Infrastructure.csproj", "EmployeeService/EmployeeService.Infrastructure/"]
COPY ["Shared/Shared/Shared.csproj", "Shared/Shared/"]

RUN dotnet restore "EmployeeService/EmployeeService.Api/EmployeeService.Api.csproj"

COPY . .

WORKDIR "/src/EmployeeService/EmployeeService.Api"

RUN dotnet publish "EmployeeService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "EmployeeService.Api.dll"]