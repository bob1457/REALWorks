FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["REALWork.LeaseManagementService/REALWork.LeaseManagementService.csproj", "REALWork.LeaseManagementService/"]
COPY ["REALWorks.InfrastructureServer/REALWorks.InfrastructureServer.csproj", "REALWorks.InfrastructureServer/"]
COPY ["REALWork.LeaseManagementData/REALWork.LeaseManagementData.csproj", "REALWork.LeaseManagementData/"]
COPY ["REALWork.LeaseManagementCore/REALWork.LeaseManagementCore.csproj", "REALWork.LeaseManagementCore/"]
COPY ["REALWorks.MessagingServer/REALWorks.MessagingServer.csproj", "REALWorks.MessagingServer/"]
RUN dotnet restore "REALWork.LeaseManagementService/REALWork.LeaseManagementService.csproj"
COPY . .
WORKDIR "/src/REALWork.LeaseManagementService"
RUN dotnet build "REALWork.LeaseManagementService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "REALWork.LeaseManagementService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "REALWork.LeaseManagementService.dll"]