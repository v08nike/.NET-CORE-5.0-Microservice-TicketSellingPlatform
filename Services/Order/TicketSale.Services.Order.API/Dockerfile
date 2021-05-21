FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/TicketSale.Shared/*.csproj Shared/TicketSale.Shared/

COPY Services/Order/TicketSale.Services.Order.Application/*.csproj Services/Order/TicketSale.Services.Order.Application/

COPY Services/Order/TicketSale.Services.Order.Domain/*.csproj Services/Order/TicketSale.Services.Order.Domain/

COPY Services/Order/TicketSale.Services.Order.Domain.Core/*.csproj Services/Order/TicketSale.Services.Order.Domain.Core/

COPY Services/Order/TicketSale.Services.Order.Infrastructure/*.csproj Services/Order/TicketSale.Services.Order.Infrastructure/


COPY Services/Order/TicketSale.Services.Order.API/*.csproj Services/Order/TicketSale.Services.Order.API/
RUN dotnet restore Services/Order/TicketSale.Services.Order.API/*.csproj
COPY . .
RUN dotnet publish Services/Order/TicketSale.Services.Order.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","TicketSale.Services.Order.API.dll" ]




