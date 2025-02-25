using BackendTutor.Models;
using System.Text.Json;

namespace BackendTutor.Services
{
    public class CoinloreService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        private static readonly string _url = "https://api.coinlore.net/api/ticker/?id=";

        private async Task<CurrencyDto[]> GetCurrencyPrices(int id1, int id2)
        {
            var response = await _httpClient.GetStringAsync(_url + string.Join(',', id1, id2));

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<CurrencyDto[]>(response, options);
        }

        public async Task<ConvertedCurrencyVm> ConvertCurrencies(decimal amount, int id1, int id2)
        {
            var currencies = await GetCurrencyPrices(id1, id2);

            var c1 = currencies[0];
            var c2 = currencies[1];

            var price = c1.Price_btc * amount / c2.Price_btc;

            var response = new ConvertedCurrencyVm
            {
                Price = price,
                Price_usd = price * c2.Price_usd
            };

            return response;
        }
    }
}
