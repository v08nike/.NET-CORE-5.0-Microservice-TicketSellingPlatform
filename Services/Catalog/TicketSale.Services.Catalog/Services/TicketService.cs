using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSale.Services.Catalog.Models;
using MongoDB.Driver;
using AutoMapper;
using TicketSale.Services.Catalog.Settings;
using TicketSale.Shared.Dtos;
using TicketSale.Services.Catalog.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace TicketSale.Services.Catalog.Services
{
    public class TicketService:ITicketService
    {
        private readonly IMongoCollection<Ticket> _ticketCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public TicketService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _ticketCollection = database.GetCollection<Ticket>(databaseSettings.TicketCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<TicketDto>>> GetAllAsync()
        {
            var tickets = await _ticketCollection.Find(ticket => true).ToListAsync();

            if (tickets.Any())
            {
                foreach (var ticket in tickets)
                {
                    ticket.Category = await _categoryCollection.Find<Category>(x => x.Id == ticket.CategoryId).FirstAsync();
                }

            }

            else
            {
                tickets = new List<Ticket>();
            }

            return Response<List<TicketDto>>.Success(_mapper.Map<List<TicketDto>>(tickets), 200);

        }
        public async Task<Response<TicketDto>> GetByIdAsync(string id)
        {
            var ticket = await _ticketCollection.Find<Ticket>(x => x.Id == id).FirstOrDefaultAsync();

            if (ticket == null)
            {
                return Response<TicketDto>.Fail("ticket not found", 404);
            }
            ticket.Category = await _categoryCollection.Find<Category>(x => x.Id == ticket.CategoryId).FirstAsync();
            
            return Response<TicketDto>.Success(_mapper.Map<TicketDto>(ticket),200);
        }

        public async Task<Response<TicketDto>> GetAllByUserIdAsync(string userId)
        {
            var tickets = await _ticketCollection.Find<Ticket>(x => x.UserId== userId).ToListAsync();

            if (tickets.Any())
            {
                foreach (var ticket in tickets)
                {
                    ticket.Category = await _categoryCollection.Find<Category>(x => x.Id == ticket.CategoryId).FirstAsync();
                }
            }
            else
            {
                tickets = new List<Ticket>();
            }

            return Response<TicketDto>.Success(_mapper.Map<TicketDto>(tickets), 200);
        }
        public async Task<Response<TicketDto>> CreateAsync(TicketCreateDto ticketCreateDto)
        {
            var newTicket = _mapper.Map<Ticket>(ticketCreateDto);

            await _ticketCollection.InsertOneAsync(newTicket);

            return Response<TicketDto>.Success(_mapper.Map<TicketDto>(newTicket), 200);

        }

        public async Task<Response<NoContent>> UpdateAsync(TicketUpdateDto ticketUpdateDto)
        {
            var updateTicket = _mapper.Map<Ticket>(ticketUpdateDto);

            var result = await _ticketCollection.FindOneAndReplaceAsync(x=>x.Id == ticketUpdateDto.Id, updateTicket );

            if (result == null)
            {
                return Response<NoContent>.Fail("Ticket not found.",404);
            }

            return Response<NoContent>.Success(204);
        }
        public async Task<Response<NoContent>> DeleteAsync(string id)
        {

            var result = await _ticketCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Ticket not found.", 404);

        }


    }
}
