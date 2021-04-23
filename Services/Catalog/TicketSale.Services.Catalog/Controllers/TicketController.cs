using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSale.Services.Catalog.Dtos;
using TicketSale.Services.Catalog.Services;
using TicketSale.Shared.ControllerBases;

namespace TicketSale.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : CustomBaseController
    {
        private readonly ITicketService _ticketService;

        internal TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<IActionResult> GetAll()
        {
            var response = await _ticketService.GetAllAsync();
            return CreatActionResultInstance(response);
        }

        [HttpGet( "{id}")]
        public async Task<IActionResult>GetById(string id)
        {
            var response = await _ticketService.GetByIdAsync(id);
            return CreatActionResultInstance(response);
        }

        [Route("Api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _ticketService.GetAllByUserIdAsync(userId);
            return CreatActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateDto courseCreateDto)
        {
            var response = await _ticketService.CreateAsync(courseCreateDto);
            return CreatActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TicketUpdateDto courseCreateDto)
        {
            var response = await _ticketService.UpdateAsync(courseCreateDto);
            return CreatActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _ticketService.DeleteAsync(id);
            return CreatActionResultInstance(response);
        }
    }
}
