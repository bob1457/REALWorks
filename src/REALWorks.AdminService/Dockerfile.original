FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["REALWorks.AdminService/REALWorks.AdminService.csproj", "REALWorks.AdminService/"]
RUN dotnet restore "REALWorks.AdminService/REALWorks.AdminService.csproj"
COPY . .
WORKDIR "/src/REALWorks.AdminService"
RUN dotnet build "REALWorks.AdminService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "REALWorks.AdminService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "REALWorks.AdminService.dll"]