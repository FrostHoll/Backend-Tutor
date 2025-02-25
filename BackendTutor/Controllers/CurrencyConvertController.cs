using BackendTutor.Models;
using BackendTutor.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackendTutor.Controllers
{
    [ApiController]
    [Route("api/currency")]
    public class CurrencyConvertController(CoinloreService coinloreService) : ControllerBase
    {
        private readonly CoinloreService _coinloreService = coinloreService;

        private static readonly Currency[] _currencies = [
            new Currency { Id = 90, Name = "Bitcoin" },
            new Currency { Id = 80, Name = "Ethereum" },
            new Currency { Id = 518, Name = "Tether(USDT)" },
            new Currency { Id = 2, Name = "DOGE Coin" },
            new Currency { Id = 54683, Name = "TON Coin" },
        ];

        [HttpPost]
        public async Task<IActionResult> ConvertCurrencies([FromBody] ConvertCurrencyRequestDto request)
        {
            var cryptoData = await _coinloreService.ConvertCurrencies(request.Amount, request.Id1, request.Id2);
            return Ok(cryptoData);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_currencies);
        }
    }
}
