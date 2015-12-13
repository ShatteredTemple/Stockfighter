using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ShatteredTemple.Stockfighter.Common.Models;
using ShatteredTemple.Stockfighter.Common.Repositories;

namespace ShatteredTemple.Stockfighter.StockExchange
{
    /// <summary>
    /// Repository to access the Stockfighter Stock Exchange JSON API.
    /// </summary>
    public sealed class StockExchange : StockExchangeBase, IStockExchange
    {
        static StockExchange()
        {
            // Configure JSON.NET (used by MVC Web API Client) to treat enums
            // as their string values.
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = { new StringEnumConverter() }
            };
        }

        /// <summary>
        /// Creates a new instance of the Stockfighter stock exchange.
        /// </summary>
        /// <param name="apiKey">API key of the current user.</param>
        public StockExchange(string apiKey)
            : base(apiKey)
        {
            this.Venues = new StockVenues(apiKey);
        }

        /// <summary>
        /// Investigates whether the exchange is operating as intended.
        /// </summary>
        /// <returns>Model indicating either that the exchange is up, or the failure message returned.</returns>
        public async Task<HeartbeatModel> GetHeartbeat()
        {
            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync("heartbeat").ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<HeartbeatModel>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Access the various venues the API offers.
        /// </summary>
        public IStockVenues Venues { get; private set; }
    }
}
