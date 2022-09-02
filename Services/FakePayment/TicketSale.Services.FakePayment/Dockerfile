FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/TicketSale.Shared/*.csproj Shared/TicketSale.Shared/
COPY Services/FakePayment/TicketSale.Services.FakePayment/*.csproj Services/FakePayment/TicketSale.Services.FakePayment/
RUN dotnet restore Services/FakePayment/TicketSale.Services.FakePayment/*.csproj
COPY . .
RUN dotnet publish Services/FakePayment/TicketSale.Services.FakePayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","TicketSale.Services.FakePayment.dll" ]




