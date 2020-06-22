FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY ["WebApi/WebApi.csproj", "src/WebApi/"]
COPY ["Business/Business.csproj", "src/Business/"]
COPY ["Mapeamento/Mapeamento.csproj", "src/Mapeamento/"]

RUN dotnet restore "src/WebApi/WebApi.csproj"
RUN dotnet restore "src/Business/Business.csproj"
RUN dotnet restore "src/Mapeamento/Mapeamento.csproj"

COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app

COPY --from=publish /app .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApi.dll