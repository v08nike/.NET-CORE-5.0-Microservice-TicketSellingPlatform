FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/TicketSale.Shared/*.csproj Shared/TicketSale.Shared/
COPY Services/Basket/TicketSale.Services.Basket/*.csproj Services/Basket/TicketSale.Services.Basket/
RUN dotnet restore Services/Basket/TicketSale.Services.Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/TicketSale.Services.Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","TicketSale.Services.Basket.dll" ]




