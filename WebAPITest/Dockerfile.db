#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAPITest/WebAPITest.csproj", "WebAPITest/"]
COPY ["BusinessApplication/BusinessApplication.csproj", "BusinessApplication/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "WebAPITest/WebAPITest.csproj"
COPY . .
WORKDIR "/src/WebAPITest"
RUN dotnet build "WebAPITest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPITest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPITest.dll"]