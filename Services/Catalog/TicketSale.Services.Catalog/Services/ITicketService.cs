using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSale.Services.Catalog.Dtos;
using TicketSale.Shared.Dtos;

namespace TicketSale.Services.Catalog.Services
{
    public interface ITicketService
    {
        Task<Response<List<TicketDto>>> GetAllAsync();
        Task<Response<TicketDto>> GetByIdAsync(string id);
       Task<Response<TicketDto>> GetAllByUserIdAsync(string userId);
       Task<Response<TicketDto>> CreateAsync(TicketCreateDto ticketCreateDto);
       Task<Response<NoContent>> UpdateAsync(TicketUpdateDto ticketUpdateDto);
       Task<Response<NoContent>> DeleteAsync(string id);

    }
}
