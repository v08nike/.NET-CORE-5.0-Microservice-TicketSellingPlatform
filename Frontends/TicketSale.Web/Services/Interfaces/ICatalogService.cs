using TicketSale.Web.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSale.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<TicketViewModel>> GetAllTicketAsync();

        Task<List<CategoryViewModel>> GetAllCategoryAsync();

        Task<List<TicketViewModel>> GetAllTicketByUserIdAsync(string userId);

        Task<TicketViewModel> GetByTicketId(string TicketId);

        Task<bool> CreateTicketAsync(TicketCreateInput TicketCreateInput);

        Task<bool> UpdateTicketAsync(TicketUpdateInput TicketUpdateInput);

        Task<bool> DeleteTicketAsync(string TicketId);
    }
}