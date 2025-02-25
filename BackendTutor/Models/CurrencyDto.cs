using BackendTutor.Utils;
using System.Text.Json.Serialization;

namespace BackendTutor.Models
{
    public class CurrencyDto
    {
        public string Id { get; set; }

        [JsonPropertyName("price_usd")]
        [JsonConverter(typeof(StringToDecimalJsonConverter))]
        public decimal Price_usd { get; set; }

        [JsonPropertyName("price_btc")]
        [JsonConverter(typeof(StringToDecimalJsonConverter))]
        public decimal Price_btc { get; set; }
    }
}
