# Cinema Booking API

## SOA Continuous Assessment 2

**Jianfeng Han （D0025825）**
- Module: Service-Oriented Architecture (SOA)

## Project Overview

This project is a RESTful Cinema Booking API developed using ASP.NET Core (.NET 8) following Service-Oriented Architecture (SOA) principles.
The API allows users to:
- Register and authenticate
- View movies and screenings
- Book seats for movie screenings
- Manage bookings securely using API Key authentication

The system is designed with:
- Clear separation of concerns (Controllers, Services, Repositories)
- Persistent data storage using SQLite
- API documentation using Swagger
- Cloud deployment using Docker and Railway

## Technology Stack
-ASP.NET Core (.NET 8)
- Entity Framework Core
- SQLite
- Swagger (OpenAPI 3.0)
- Docker
- Railway (Cloud Deployment)
-Postman (API Testing)

## Running the Application Locally

1. Prerequisites
- .NET 8 SDK
- SQLite
- IDE (Rider / Visual Studio)

2. Clone the Repository

`git clone https://github.com/EricHanJf/CinemaBookingAPI_SOA_CA2_JianfengHan.git`

`cd CinemaBookingAPI_SOA_CA2_JianfengHan`

3. Run the API
   
`dotnet run`

4. Access Swagger UI

## Cloud Deployment (Railway)
The API is deployed using Railway with Docker support.

**Deployment Features**
- Docker-based deployment
- Automatic build and restart
- Public HTTPS domain
- Persistent runtime environment

## API URL

`https://cinemabookingapisoaca2jianfenghan-production.up.railway.app/swagger/index.html`

## Authentication
The API uses API Key authentication.
- API Key is generated during user registration
- API Key must be included in request headers:
  `X-API-KEY: {your_api_key}`
- Swagger UI includes an Authorize button to simplify authenticated testing.














