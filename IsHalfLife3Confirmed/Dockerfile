#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IsHalfLife3Confirmed/IsHalfLife3Confirmed.csproj", "IsHalfLife3Confirmed/"]
RUN dotnet restore "IsHalfLife3Confirmed/IsHalfLife3Confirmed.csproj"
COPY . .
WORKDIR "/src/IsHalfLife3Confirmed"
RUN dotnet build "IsHalfLife3Confirmed.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IsHalfLife3Confirmed.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IsHalfLife3Confirmed.dll"]