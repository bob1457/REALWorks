FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["REALWorks.APIGateway/REALWorks.APIGateway.csproj", "REALWorks.APIGateway/"]
RUN dotnet restore "REALWorks.APIGateway/REALWorks.APIGateway.csproj"
COPY . .
WORKDIR "/src/REALWorks.APIGateway"
RUN dotnet build "REALWorks.APIGateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "REALWorks.APIGateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "REALWorks.APIGateway.dll"]