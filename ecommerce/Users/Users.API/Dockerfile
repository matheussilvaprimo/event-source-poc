FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64540
EXPOSE 44390

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Users.API/Users.API.csproj Users.API/
RUN dotnet restore Users.API/Users.API.csproj
COPY . .
WORKDIR /src/Users.API
RUN dotnet build Users.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Users.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Users.API.dll"]
