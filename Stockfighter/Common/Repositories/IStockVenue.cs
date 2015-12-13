using System.Threading.Tasks;
using ShatteredTemple.Stockfighter.Common.Models;

namespace ShatteredTemple.Stockfighter.Common.Repositories
{
    /// <summary>
    /// Specific stock venue within the overall <see cref="StockExchange"/> API.
    /// </summary>
    public interface IStockVenue
    {
        /// <summary>
        /// Cancels an outstanding order.
        /// </summary>
        /// <param name="order">Order to cancel</param>
        /// <returns>Status of the order (cancelled, or if it's been subsequently fulfilled before cancellation request was received).</returns>
        Task<StockOrderModel> CancelOrder(StockOrderModel order);

        /// <summary>
        /// Investigates whether a specific venue is operating as intended.
        /// </summary>
        /// <param name="venue">Code of the venue to interrogate.</param>
        /// <returns>Model indicating either that the venue is up, or the failure message returned.</returns>
        Task<HeartbeatModel> GetHeartbeat();

        /// <summary>
        /// Gets the order book for a stock.
        /// </summary>
        /// <param name="symbol">Stock to get the order book for.</param>
        /// <returns>The order book.</returns>
        Task<StockOrderBookModel> GetOrderBook(string symbol);

        /// <summary>
        /// Gets the status of all orders by an account.
        /// </summary>
        /// <param name="account">Account to check the status of.</param>
        /// <returns>Non-cold orders for the account.</returns>
        Task<VenueOrdersModel> GetOrderStatuses(string account);

        /// <summary>
        /// Gets the status of all orders by an account for a specific stock.
        /// </summary>
        /// <param name="account">Account to check the status of.</param>
        /// <param name="symbol">Stock to check the status of.</param>
        /// <returns>Non-cold orders for the stock by the account.</returns>
        Task<VenueOrdersModel> GetOrderStatuses(string account, string symbol);

        /// <summary>
        /// Gets the current status of a previously-placed order.
        /// </summary>
        /// <param name="order">Order to check the status of.</param>
        /// <returns>Updated order status.</returns>
        Task<StockOrderModel> GetOrderStatus(StockOrderModel order);

        /// <summary>
        /// Get a quote for a specific stock on this venu.
        /// </summary>
        /// <param name="symbol">Symbol of this stock.</param>
        /// <returns>Quote for the stock.</returns>
        Task<StockQuoteModel> GetStockQuote(string symbol);

        /// <summary>
        /// Investigates whether a specific venue is operating as intended.
        /// </summary>
        /// <param name="venue">Code of the venue to interrogate.</param>
        /// <returns>Model indicating either that the venue is up, or the failure message returned.</returns>
        Task<VenueStocksModel> GetStocks();

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
        Task<StockOrderModel> PlaceStockOrder(string account,
            string stock, decimal price, int quantity,
            StockOrderDirection direction, StockOrderType type);
    }
}
