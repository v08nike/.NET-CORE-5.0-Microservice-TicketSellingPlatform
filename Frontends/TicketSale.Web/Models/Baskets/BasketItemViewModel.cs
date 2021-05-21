using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSale.Web.Models.Baskets
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; } = 1;

        public string TicketId { get; set; }
        public string TicketName { get; set; }

        public decimal Price { get; set; }

        private decimal? DiscountAppliedPrice;

        public decimal GetCurrentPrice
        {
            get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price;
        }

        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountAppliedPrice = discountPrice;
        }
    }
}