#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#WORKDIR /src
#COPY ["REALWoeks.AuthServer/REALWorks.AuthServer.csproj", "REALWoeks.AuthServer/"]
#COPY ["REALWorks.MessagingServer/REALWorks.MessagingServer.csproj", "REALWorks.MessagingServer/"]
#COPY ["REALWorks.InfrastructureServer/REALWorks.InfrastructureServer.csproj", "REALWorks.InfrastructureServer/"]
#RUN dotnet restore "REALWoeks.AuthServer/REALWorks.AuthServer.csproj"
#COPY . .
#WORKDIR "/src/REALWoeks.AuthServer"
#RUN dotnet build "REALWorks.AuthServer.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "REALWorks.AuthServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY  bin/Release/netcoreapp2.2/publish/ .
ENTRYPOINT ["dotnet", "REALWorks.AuthServer.dll"]