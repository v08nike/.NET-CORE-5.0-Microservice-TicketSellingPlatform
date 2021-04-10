namespace TicketSale.Services.Catalog.Dtos
{
    public class TicketCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }
        public FeatureDto Feature { get; set; }

        public string CategoryId { get; set; }
    }
}
