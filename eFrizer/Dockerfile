FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
COPY efrizer_cert.pfx .
EXPOSE 80 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "eFrizer" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD /eFrizer/Images images

ENTRYPOINT ["dotnet", "eFrizer.dll"]
