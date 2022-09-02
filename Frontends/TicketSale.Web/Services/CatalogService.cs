using TicketSale.Shared.Dtos;
using TicketSale.Web.Helpers;
using TicketSale.Web.Models;
using TicketSale.Web.Models.Catalogs;
using TicketSale.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TicketSale.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;
        private readonly IPhotoStockService _photoStockService;
        private readonly PhotoHelper _photoHelper;

        public CatalogService(HttpClient client, IPhotoStockService photoStockService, PhotoHelper photoHelper)
        {
            _client = client;
            _photoStockService = photoStockService;
            _photoHelper = photoHelper;
        }

        public async Task<bool> CreateTicketAsync(TicketCreateInput TicketCreateInput)
        {
            var resultPhotoService = await _photoStockService.UploadPhoto(TicketCreateInput.PhotoFormFile);

            if (resultPhotoService != null)
            {
                TicketCreateInput.Picture = resultPhotoService.Url;
            }

            var response = await _client.PostAsJsonAsync<TicketCreateInput>("Tickets", TicketCreateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTicketAsync(string TicketId)
        {
            var response = await _client.DeleteAsync($"Tickets/{TicketId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var response = await _client.GetAsync("categories");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<List<TicketViewModel>> GetAllTicketAsync()
        {
            //http:localhost:5000/services/catalog/Tickets
            var response = await _client.GetAsync("Tickets");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<TicketViewModel>>>();
            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });
            return responseSuccess.Data;
        }

        public async Task<List<TicketViewModel>> GetAllTicketByUserIdAsync(string userId)
        {
            //[controller]/GetAllByUserId/{userId}

            var response = await _client.GetAsync($"Tickets/GetAllByUserId/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<TicketViewModel>>>();

            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });

            return responseSuccess.Data;
        }

        public async Task<TicketViewModel> GetByTicketId(string TicketId)
        {
            var response = await _client.GetAsync($"Tickets/{TicketId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<TicketViewModel>>();

            responseSuccess.Data.StockPictureUrl = _photoHelper.GetPhotoStockUrl(responseSuccess.Data.Picture);

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateTicketAsync(TicketUpdateInput TicketUpdateInput)
        {
            var resultPhotoService = await _photoStockService.UploadPhoto(TicketUpdateInput.PhotoFormFile);

            if (resultPhotoService != null)
            {
                await _photoStockService.DeletePhoto(TicketUpdateInput.Picture);
                TicketUpdateInput.Picture = resultPhotoService.Url;
            }

            var response = await _client.PutAsJsonAsync<TicketUpdateInput>("Tickets", TicketUpdateInput);

            return response.IsSuccessStatusCode;
        }
    }
}