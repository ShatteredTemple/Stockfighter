using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ShatteredTemple.Stockfighter.Common;
using ShatteredTemple.Stockfighter.Common.Models;
using ShatteredTemple.Stockfighter.Common.Repositories;

namespace ShatteredTemple.Stockfighter.StockExchange
{
    /// <summary>
    /// Specific stock venue within the overall <see cref="StockExchange"/> API.
    /// </summary>
    public sealed class StockVenue : StockExchangeBase, IStockVenue, ICachedRepository
    {
        private string m_venue;
        private VenueStocksModel m_venueStocks = null;

        internal StockVenue(string apiKey, string venue)
            : base(apiKey)
        {
            if (!Regex.IsMatch(venue, "[a-zA-z]*"))
            {
                throw new ArgumentException("Invalid venue specification", venue);
            }

            this.m_venue = venue;
        }

        #region IStockVenue

        /// <summary>
        /// Cancels an outstanding order.
        /// </summary>
        /// <param name="order">Order to cancel</param>
        /// <returns>Status of the order (cancelled, or if it's been subsequently fulfilled before cancellation request was received).</returns>
        public async Task<StockOrderModel> CancelOrder(StockOrderModel order)
        {
            using (var client = this.GetHttpClient())
            {
                var response = await client.DeleteAsync(String.Format("venues/{0}/stocks/{1}/order/{2}", order.Venue, order.Symbol, order.VenueOrderId)).ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<StockOrderModel>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Investigates whether a specific venue is operating as intended.
        /// </summary>
        /// <param name="venue">Code of the venue to interrogate.</param>
        /// <returns>Model indicating either that the venue is up, or the failure message returned.</returns>
        public async Task<HeartbeatModel> GetHeartbeat()
        {
            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync(String.Format("venues/{0}/heartbeat", this.m_venue)).ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<HeartbeatModel>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the order book for a stock.
        /// </summary>
        /// <param name="symbol">Stock to get the order book for.</param>
        /// <returns>The order book.</returns>
        public async Task<StockOrderBookModel> GetOrderBook(string symbol)
        {
            if (!Regex.IsMatch(symbol, "[a-zA-z]*"))
            {
                throw new ArgumentException("Invalid stock symbol specification", symbol);
            }

            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync(String.Format("venues/{0}/stocks/{1}", this.m_venue, symbol)).ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<StockOrderBookModel>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the status of all orders by an account.
        /// </summary>
        /// <param name="account">Account to check the status of.</param>
        /// <returns>Non-cold orders for the account.</returns>
        public async Task<VenueOrdersModel> GetOrderStatuses(string account)
        {
            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync(String.Format("venues/{0}/accounts/{1}/orders", this.m_venue, account)).ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<VenueOrdersModel>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the status of all orders by an account for a specific stock.
        /// </summary>
        /// <param name="account">Account to check the status of.</param>
        /// <param name="symbol">Stock to check the status of.</param>
        /// <returns>Non-cold orders for the stock by the account.</returns>
        public async Task<VenueOrdersModel> GetOrderStatuses(string account, string symbol)
        {
            if (!Regex.IsMatch(symbol, "[a-zA-z]*"))
            {
                throw new ArgumentException("Invalid stock symbol specification", symbol);
            }

            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync(String.Format("venues/{0}/accounts/{1}/stocks/{2}/orders", this.m_venue, account, symbol)).ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<VenueOrdersModel>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the current status of a previously-placed order.
        /// </summary>
        /// <param name="order">Order to check the status of.</param>
        /// <returns>Updated order status.</returns>
        public async Task<StockOrderModel> GetOrderStatus(StockOrderModel order)
        {
            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync(String.Format("venues/{0}/stocks/{1}/order/{2}", order.Venue, order.Symbol, order.VenueOrderId)).ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<StockOrderModel>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Get a quote for a specific stock on this venu.
        /// </summary>
        /// <param name="symbol">Symbol of this stock.</param>
        /// <returns>Quote for the stock.</returns>
        public async Task<StockQuoteModel> GetStockQuote(string symbol)
        {
            if (!Regex.IsMatch(symbol, "[a-zA-z]*"))
            {
                throw new ArgumentException("Invalid stock symbol specification", symbol);
            }

            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync(String.Format("venues/{0}/stocks/{1}/quote", this.m_venue, symbol)).ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<StockQuoteModel>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Investigates whether a specific venue is operating as intended.
        /// </summary>
        /// <param name="venue">Code of the venue to interrogate.</param>
        /// <returns>Model indicating either that the venue is up, or the failure message returned.</returns>
        public async Task<VenueStocksModel> GetStocks()
        {
            if (this.m_venueStocks == null)
            {
                // A lock is not necessary here for thread safety; worst-case,
                // it gets set twice.
                using (var client = this.GetHttpClient())
                {
                    var response = await client.GetAsync(String.Format("venues/{0}/stocks", this.m_venue)).ConfigureAwait(false);
                    this.m_venueStocks = await StockExchangeUtility.GetResponseOrErrorModel<VenueStocksModel>(response).ConfigureAwait(false);
                }
            }
            return this.m_venueStocks;
        }

        /// <summary>
        /// Place a buy or sell order for a stock.
        /// </summary>
        /// <param name="account">Account to place the order for.</param>
        /// <param name="stock">Stock to place the order for.</param>
        /// <param name="price">Price to place the order at.</param>
        /// <param name="quantity">Amount to buy/sell.</param>
        /// <param name="direction">Whether to buy or sell.</param>
        /// <param name="type">Type of the order.</param>
        /// <returns></returns>
        public async Task<StockOrderModel> PlaceStockOrder(string account,
            string stock, decimal price, int quantity,
            StockOrderDirection direction, StockOrderType type)
        {
            if (!Regex.IsMatch(stock, "[a-zA-z]*"))
            {
                throw new ArgumentException("Invalid stock symbol specification", stock);
            }

            using (var client = this.GetHttpClient())
            {
                var order = new StockOrderRequestModel(account, this.m_venue,
                    stock, price, quantity, direction, type);

                var response = await client.PostAsJsonAsync(String.Format("venues/{0}/stocks/{1}/orders", this.m_venue, stock), order).ConfigureAwait(false);
                return await StockExchangeUtility.GetResponseOrErrorModel<StockOrderModel>(response).ConfigureAwait(false);
            }
        }

        #endregion

        #region ICachedRepository

        /// <summary>
        /// Clear the cache for this repository.
        /// </summary>
        public void ClearCache()
        {
            this.m_venueStocks = null;
        }

        #endregion
    }
}
