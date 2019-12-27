FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["REALWorks.AssetServer/REALWorks.AssetServer.csproj", "REALWorks.AssetServer/"]
COPY ["REALWorks.InfrastructureServer/REALWorks.InfrastructureServer.csproj", "REALWorks.InfrastructureServer/"]
COPY ["REALWorks.AssetCore/REALWorks.AssetCore.csproj", "REALWorks.AssetCore/"]
COPY ["REALWorks.AssetData/REALWorks.AssetData.csproj", "REALWorks.AssetData/"]
COPY ["REALWorks.MessagingServer/REALWorks.MessagingServer.csproj", "REALWorks.MessagingServer/"]
COPY ["REALWoeks.AuthServer/REALWorks.AuthServer.csproj", "REALWoeks.AuthServer/"]
RUN dotnet restore "REALWorks.AssetServer/REALWorks.AssetServer.csproj"
COPY . .
WORKDIR "/src/REALWorks.AssetServer"
RUN dotnet build "REALWorks.AssetServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "REALWorks.AssetServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "REALWorks.AssetServer.dll"]