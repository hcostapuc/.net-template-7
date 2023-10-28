#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hdn.Core.Architecture.WebApi/Hdn.Core.Architecture.WebApi.csproj", "Hdn.Core.Architecture.WebApi/"]
RUN dotnet restore "Hdn.Core.Architecture.WebApi/Hdn.Core.Architecture.WebApi.csproj"
COPY . .
WORKDIR "/src/Hdn.Core.Architecture.WebApi"
RUN dotnet build "Hdn.Core.Architecture.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hdn.Core.Architecture.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hdn.Core.Architecture.WebApi.dll"]