using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSale.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }

        public string TicketId { get; set; }
        public string TicketName { get; set; }

        public decimal Price { get; set; }
    }
}