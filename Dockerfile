# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj
COPY CinemaBookingAPI_SOA_CA2_JianfengHan/*.csproj ./api/
RUN dotnet restore ./api/CinemaBookingAPI_SOA_CA2_JianfengHan.csproj

# Copy rest of source
COPY CinemaBookingAPI_SOA_CA2_JianfengHan/ ./api/

RUN dotnet publish ./api/CinemaBookingAPI_SOA_CA2_JianfengHan.csproj \
    -c Release -o /out

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /out .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CinemaBookingAPI_SOA_CA2_JianfengHan.dll"]


