#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Assignment.API/Assignment.API.csproj", "Assignment.API/"]
RUN dotnet restore "Assignment.API/Assignment.API.csproj"
COPY . .
WORKDIR "/src/Assignment.API"
RUN dotnet build "Assignment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Assignment.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Assignment.API.dll"]