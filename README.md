# TICKET SELLING PLATFORM BASED ON .NET CORE 5.0 AND MICROSERVICES ARCHITECTURE.

# .NET CORE 5.0 İLE MİCKOSERVİSLER TABANLI BİLET SATIŞ WEBSİTESİ.

A- TicketSale.Services.Catalog WEB API. 
:point_right: Services -> Catalog -> TicketSale.Services.Catalog

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

5) Servislerin sınıfları ve arayüzleri Oluşturmak. 
:point_right: Services/Catalog/TicketSale.Services.Catalog/Services/
- CategoryService.cs
- ICategoryService.cs
- ITicketService.cs
- TicketService.cs

6) Controller sınıfları Oluşturmak.
- CategoriesController.cs
- TicketsController.cs

7) Portainer Ayarlamak.

8) MongoDB’i container olarak ayağa kaldırma.

9) Uygulamayı Test Etmek.


B- TicketSale.Shared WEB API.
:point_right: Shared/TicketSale.Shared/

1) Shared class Library oluşturma.

2) Dto Nesneleri Oluşturmak.

3) Controller Bases Oluşturmak.
