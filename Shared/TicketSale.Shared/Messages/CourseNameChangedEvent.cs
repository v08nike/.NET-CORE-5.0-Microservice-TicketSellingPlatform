using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSale.Shared.Messages
{
    public class TicketNameChangedEvent
    {
        public string TicketId { get; set; }
        public string UpdatedName { get; set; }
    }
}