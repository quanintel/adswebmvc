FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["1.AdsWeb.MVC/1.AdsWeb.MVC.csproj", "1.AdsWeb.MVC/"]
RUN dotnet restore "1.AdsWeb.MVC/1.AdsWeb.MVC.csproj"
COPY . .
WORKDIR "/src/1.AdsWeb.MVC"
RUN dotnet build "1.AdsWeb.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "1.AdsWeb.MVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "1.AdsWeb.MVC.dll"]
