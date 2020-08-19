#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 1000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HydraBoot.Server/HydraBoot.Server.csproj", "HydraBoot.Server/"]
RUN dotnet restore "HydraBoot.Server/HydraBoot.Server.csproj"
COPY . .
WORKDIR "/src/HydraBoot.Server"
RUN dotnet build "HydraBoot.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HydraBoot.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HydraBoot.Server.dll"]