FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64568
EXPOSE 44380

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Shipment.API/Shipment.API.csproj Shipment.API/
RUN dotnet restore Shipment.API/Shipment.API.csproj
COPY . .
WORKDIR /src/Shipment.API
RUN dotnet build Shipment.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Shipment.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shipment.API.dll"]
