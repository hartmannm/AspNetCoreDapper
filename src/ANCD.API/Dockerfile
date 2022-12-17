FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7286

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["./ANCD.Domain/ANCD.Domain.csproj", "ANCD.Domain/"]
COPY ["./ANCD.Infra/ANCD.Infra.csproj", "ANCD.Infra/"]
COPY ["./ANCD.Application/ANCD.Application.csproj", "ANCD.Application/"]
COPY ["./ANCD.IoC/ANCD.IoC.csproj", "ANCD.IoC/"]
COPY ["./ANCD.API/ANCD.API.csproj", "ANCD.API/"]

RUN dotnet restore "ANCD.API/ANCD.API.csproj"
COPY . .
WORKDIR "ANCD.API"
RUN dotnet build "ANCD.API.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "ANCD.API.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ANCD.API.dll"]
