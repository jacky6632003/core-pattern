#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["core-pattern/core-pattern.csproj", "core-pattern/"]
RUN dotnet restore "core-pattern/core-pattern.csproj"
COPY . .
WORKDIR "/src/core-pattern"
RUN dotnet build "core-pattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "core-pattern.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "core-pattern.dll"]