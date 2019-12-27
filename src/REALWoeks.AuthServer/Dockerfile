FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["REALWoeks.AuthServer/REALWorks.AuthServer.csproj", "REALWoeks.AuthServer/"]
COPY ["REALWorks.MessagingServer/REALWorks.MessagingServer.csproj", "REALWorks.MessagingServer/"]
COPY ["REALWorks.InfrastructureServer/REALWorks.InfrastructureServer.csproj", "REALWorks.InfrastructureServer/"]
RUN dotnet restore "REALWoeks.AuthServer/REALWorks.AuthServer.csproj"
COPY . .
WORKDIR "/src/REALWoeks.AuthServer"
RUN dotnet build "REALWorks.AuthServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "REALWorks.AuthServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "REALWorks.AuthServer.dll"]