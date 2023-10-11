using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StockFusion_Finance.Models;
using System.IO;

namespace StockFusion_Finance.API
{
    public interface IYahooApi
    {
        Task<YahooApiModel.Root> GetStockInfo(string stockSymbol);
    }

    public class YahooApi : IYahooApi
    {
        public async Task<YahooApiModel.Root> GetStockInfo(string stockSymbol)
        {
            // IConfiguration to serialize JSON into an object --> Set the base directory path --> Select json file --> Build
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://yfinance-stock-market-data.p.rapidapi.com/stock-info"),
                Headers = {
                    { "X-RapidAPI-Key", "1c0346c35dmsh0c8a91ca4424defp18ef89jsn185384dc2155" },
                    { "X-RapidAPI-Host", "yfinance-stock-market-data.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "symbol", stockSymbol.ToUpper() },
                }),
            };

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<YahooApiModel.Root>(body);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return a default response
                // You can replace this with proper error handling
                throw ex;
            }
        }
    }
}
