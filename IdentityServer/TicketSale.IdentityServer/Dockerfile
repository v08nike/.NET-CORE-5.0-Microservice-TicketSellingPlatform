FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/TicketSale.Shared/*.csproj Shared/TicketSale.Shared/
COPY IdentityServer/TicketSale.IdentityServer/*.csproj IdentityServer/TicketSale.IdentityServer/ 
RUN dotnet restore  IdentityServer/TicketSale.IdentityServer/*.csproj
COPY . .
RUN dotnet publish IdentityServer/TicketSale.IdentityServer/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","TicketSale.IdentityServer.dll" ]




