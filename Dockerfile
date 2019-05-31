FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build

WORKDIR /app

COPY . ./

RUN dotnet restore 
RUN dotnet publish ./Compose.Web.csproj --configuration Release --output out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Compose.Web.dll"]