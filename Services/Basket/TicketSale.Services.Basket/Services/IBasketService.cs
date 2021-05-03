using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSale.Services.Basket.Dtos;
using TicketSale.Shared.Dtos;

namespace TicketSale.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

        Task<Response<bool>> Delete(string userId);
    }
}
