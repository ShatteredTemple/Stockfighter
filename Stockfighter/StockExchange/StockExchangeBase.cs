using System;
using System.Net.Http;

namespace ShatteredTemple.Stockfighter.StockExchange
{
    /// <summary>
    /// Base class containing common Stock Exchange functionality.
    /// </summary>
    public abstract class StockExchangeBase
    {
        // TODO: This needs to come from configuration somehow?
        private static readonly Uri s_stockfighterApiUri = new Uri("https://api.stockfighter.io/ob/api/");
        protected const string s_stockfighterWebSocketUri = "wss://www.stockfighter.io/ob/api/ws/";

        /// <summary>
        /// API Key for the current user to access the Stock Exchange API.
        /// </summary>
        protected string ApiKey { get; set; }

        protected StockExchangeBase(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// Create a new <see cref="HttpClient"/> instance with headers for the
        /// currently-configured <see cref="ApiKey"/>.
        /// </summary>
        /// <returns></returns>
        protected HttpClient GetHttpClient()
        {
            var result = new HttpClient()
            {
                BaseAddress = s_stockfighterApiUri,
            };
            result.DefaultRequestHeaders.Add("X-Starfighter-Authorization", this.ApiKey);
            return result;
        }
    }
}
