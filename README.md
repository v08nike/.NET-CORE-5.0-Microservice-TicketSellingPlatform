# TICKET SELLING PLATFORM BASED ON .NET CORE 5.0 AND MICROSERVICES ARCHITECTURE.

# .NET CORE 5.0 İLE MİCKOSERVİSLER TABANLI BİLET SATIŞ WEBSİTESİ .

A- Services -> Catalog -> TicketSale.Services.Catalog

1) MongoDB.Driver ile class'ların oluşturulması.
:point_right: Services/Catalog/TicketSale.Services.Catalog/Models/
- Veritaban : MongoDB
- Models Oluşturması.
  - Category.cs
  - Feature.cs
  - Ticket.cs
   
2) Dto Nesneleri Oluşturması.
:point_right: Services/Catalog/TicketSale.Services.Catalog/Dtos/
  - CategoryDto.cs
  - FeatureDto.cs
  - TicketCreateDto.cs
  - TicketDto.cs
  - TicketUpdateDto.cs
  
3) AutoMapper Kütüphanenin eklenmesi.
:point_right: Services/Catalog/TicketSale.Services.Catalog/Mapping/

4) Appsetting.json Dosyasında 
:point_right: Services/Catalog/TicketSale.Services.Catalog/appsettings.json
- Dosyada veritaban yolunu, ismi ve Collection ismi ayarlayacağız.
- Gerekli ayarlar için interface ve class oluşturulması :point_right: Services/Catalog/TicketSale.Services.Catalog/Settings/


B- Shared/TicketSale.Shared/
1) Shared class Library oluşturma.
2) Dto -> response oluşturma.
3) 
