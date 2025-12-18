# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy only API project
COPY CinemaBookingAPI_SOA_CA2_JianfengHan/CinemaBookingAPI_SOA_CA2_JianfengHan.csproj ./CinemaBookingAPI/
RUN dotnet restore ./CinemaBookingAPI/CinemaBookingAPI_SOA_CA2_JianfengHan.csproj

# Copy rest of API source
COPY CinemaBookingAPI_SOA_CA2_JianfengHan/ ./CinemaBookingAPI/

RUN dotnet publish ./CinemaBookingAPI/CinemaBookingAPI_SOA_CA2_JianfengHan.csproj \
    -c Release -o /out

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CinemaBookingAPI_SOA_CA2_JianfengHan.dll"]

