#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IronPython.Web/IronPython.Web.csproj", "IronPython.Web/"]
COPY ["Modules/Authorization/IronPython.Authorization/IronPython.Authorization.csproj", "Modules/Authorization/IronPython.Authorization/"]
COPY ["Modules/TelegramBots/IronPython.TelegramBots/IronPython.TelegramBots.csproj", "Modules/TelegramBots/IronPython.TelegramBots/"]
RUN dotnet restore "IronPython.Web/IronPython.Web.csproj"
COPY . .
WORKDIR "/src/IronPython.Web"
RUN dotnet build "IronPython.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IronPython.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IronPython.Web.dll"]
