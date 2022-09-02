FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/TicketSale.Shared/*.csproj Shared/TicketSale.Shared/
COPY Frontends/TicketSale.Web/*.csproj Frontends/TicketSale.Web/
RUN dotnet restore Frontends/TicketSale.Web/*.csproj
COPY . .
RUN dotnet publish Frontends/TicketSale.Web/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","TicketSale.Web.dll" ]




