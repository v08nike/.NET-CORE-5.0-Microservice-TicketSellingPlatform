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

namespace TicketSale.Services.Catalog.Services
{
    public class CategoryServices
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        internal CategoryServices(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);

        }

        public async Task<Response<CategoryDto>> CreateAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category );

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);

        }

    }
}
