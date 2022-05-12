FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnitTestStressBallWeb/UnitTestStressBallWeb.csproj", "UnitTestStressBallWeb/"]
RUN dotnet restore "UnitTestStressBallWeb/UnitTestStressBallWeb.csproj"
COPY . .
WORKDIR "/src/UnitTestStressBallWeb"
RUN dotnet build "UnitTestStressBallWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTestStressBallWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitTestStressBallWeb.dll"]
