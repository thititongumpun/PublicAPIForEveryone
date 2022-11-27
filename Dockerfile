FROM mcr.microsoft.com/dotnet/sdk:6.0.402-bullseye-slim as build

WORKDIR /src
COPY *.sln .
COPY *.csproj .

RUN dotnet restore
COPY . .

WORKDIR "/src"
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0.10-bullseye-slim
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV TZ="Asia/Bangkok"

EXPOSE 8080

WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ToyShopAPI.dll"]