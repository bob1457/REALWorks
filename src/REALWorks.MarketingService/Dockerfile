FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["REALWorks.MarketingService/REALWorks.MarketingService.csproj", "REALWorks.MarketingService/"]
COPY ["REALWorks.MarketingData/REALWorks.MarketingData.csproj", "REALWorks.MarketingData/"]
COPY ["REALWorks.MarketingCore/REALWorks.MarketingCore.csproj", "REALWorks.MarketingCore/"]
COPY ["REALWorks.MessagingServer/REALWorks.MessagingServer.csproj", "REALWorks.MessagingServer/"]
COPY ["REALWorks.InfrastructureServer/REALWorks.InfrastructureServer.csproj", "REALWorks.InfrastructureServer/"]
RUN dotnet restore "REALWorks.MarketingService/REALWorks.MarketingService.csproj"
COPY . .
WORKDIR "/src/REALWorks.MarketingService"
RUN dotnet build "REALWorks.MarketingService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "REALWorks.MarketingService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "REALWorks.MarketingService.dll"]