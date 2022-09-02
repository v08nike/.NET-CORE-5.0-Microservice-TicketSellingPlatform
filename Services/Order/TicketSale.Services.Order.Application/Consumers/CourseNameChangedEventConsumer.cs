using TicketSale.Services.Order.Infrastructure;
using TicketSale.Shared.Messages;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSale.Services.Order.Application.Consumers
{
    public class TicketNameChangedEventConsumer : IConsumer<TicketNameChangedEvent>
    {
        private readonly OrderDbContext _orderDbContext;

        public TicketNameChangedEventConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<TicketNameChangedEvent> context)
        {
            var orderItems = await _orderDbContext.OrderItems.Where(x => x.ProductId == context.Message.TicketId).ToListAsync();

            orderItems.ForEach(x =>
            {
                x.UpdateOrderItem(context.Message.UpdatedName, x.PictureUrl, x.Price);
            });

            await _orderDbContext.SaveChangesAsync();
        }
    }
}