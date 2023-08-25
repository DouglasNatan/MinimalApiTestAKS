FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["MinimalApiTestAKS/MinimalApiTestAKS.csproj", "MinimalApiTestAKS/"]
RUN dotnet restore "MinimalApiTestAKS\MinimalApiTestAKS.csproj"
COPY . .
WORKDIR "/src/MinimalApiTestAKS"
RUN dotnet build "MinimalApiTestAKS.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "MinimalApiTestAKS.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinimalApiTestAKS.dll"]
