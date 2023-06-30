FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TekeGah.WebAPI/TekeGah.WebAPI.csproj", "TekeGah.WebAPI/"]
RUN dotnet restore "TekeGah.WebAPI/TekeGah.WebAPI.csproj"
COPY . .
WORKDIR "/src/TekeGah.WebAPI"
RUN dotnet build "TekeGah.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TekeGah.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TekeGah.WebAPI.dll"]
