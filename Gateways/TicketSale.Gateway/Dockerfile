FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80

COPY  TicketSale.Gateway/*.csproj  TicketSale.Gateway/
RUN dotnet restore TicketSale.Gateway/*.csproj
COPY . .
RUN dotnet publish TicketSale.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","TicketSale.Gateway.dll" ]




