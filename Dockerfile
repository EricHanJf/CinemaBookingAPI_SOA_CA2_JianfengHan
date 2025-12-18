# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy solution and project files
COPY CinemaBookingAPI_SOA_CA2_JianfengHan.sln .
COPY CinemaBookingAPI_SOA_CA2_JianfengHan/*.csproj ./CinemaBookingAPI_SOA_CA2_JianfengHan/

# restore
RUN dotnet restore

# copy everything else
COPY . .

# publish
RUN dotnet publish CinemaBookingAPI_SOA_CA2_JianfengHan/CinemaBookingAPI_SOA_CA2_JianfengHan.csproj \
    -c Release -o /app/publish

# ---------- RUNTIME STAGE ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CinemaBookingAPI_SOA_CA2_JianfengHan.dll"]



