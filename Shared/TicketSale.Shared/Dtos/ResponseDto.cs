using System.Text.Json.Serialization;

namespace TicketSale.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSuccessful { get; set; }
    }
}
