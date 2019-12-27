FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["REALWorks.NotificationService/REALWorks.NotificationService.csproj", "REALWorks.NotificationService/"]
COPY ["REALWorks.MessagingServer/REALWorks.MessagingServer.csproj", "REALWorks.MessagingServer/"]
COPY ["REALWorks.InfrastructureServer/REALWorks.InfrastructureServer.csproj", "REALWorks.InfrastructureServer/"]
RUN dotnet restore "REALWorks.NotificationService/REALWorks.NotificationService.csproj"
COPY . .
WORKDIR "/src/REALWorks.NotificationService"
RUN dotnet build "REALWorks.NotificationService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "REALWorks.NotificationService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "REALWorks.NotificationService.dll"]