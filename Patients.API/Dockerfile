
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["Patients.API/Patients.API.csproj", "Patients.API/"]
RUN dotnet restore "Patients.API/Patients.API.csproj"
COPY . .
WORKDIR "/src/Patients.API"
RUN dotnet build "Patients.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Patients.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Patients.API.dll"]