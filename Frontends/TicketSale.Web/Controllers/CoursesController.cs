using TicketSale.Shared.Services;
using TicketSale.Web.Models.Catalogs;
using TicketSale.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSale.Web.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public TicketsController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _catalogService.GetAllTicketByUserIdAsync(_sharedIdentityService.GetUserId));
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _catalogService.GetAllCategoryAsync();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateInput TicketCreateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            TicketCreateInput.UserId = _sharedIdentityService.GetUserId;

            await _catalogService.CreateTicketAsync(TicketCreateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var Ticket = await _catalogService.GetByTicketId(id);
            var categories = await _catalogService.GetAllCategoryAsync();

            if (Ticket == null)
            {
                //mesaj göster
                RedirectToAction(nameof(Index));
            }
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", Ticket.Id);
            TicketUpdateInput TicketUpdateInput = new()
            {
                Id = Ticket.Id,
                Name = Ticket.Name,
                Description = Ticket.Description,
                Price = Ticket.Price,
                Feature = Ticket.Feature,
                CategoryId = Ticket.CategoryId,
                UserId = Ticket.UserId,
                Picture = Ticket.Picture
            };

            return View(TicketUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketUpdateInput TicketUpdateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", TicketUpdateInput.Id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _catalogService.UpdateTicketAsync(TicketUpdateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _catalogService.DeleteTicketAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}