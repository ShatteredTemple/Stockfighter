using System.Runtime.Serialization;

namespace FallenTemple.Stockfighter.Common.Models
{
    /// <summary>
    /// Model for placing a stock order initially. The result, and all other
    /// order-based transations, use <see cref="StockOrderModel"/>.
    /// </summary>
    [DataContract]
    public sealed class StockOrderRequestModel : StockOrderModelBase
    {
        public StockOrderRequestModel(string account, string venue,
            string symbol, decimal price, int quantity,
            StockOrderDirection direction, StockOrderType type)
        {
            this.Account = account;
            this.Venue = venue;
            this.Symbol = symbol;
            this.Price = price;
            this.Quantity = quantity;
            this.Direction = direction;
            this.Type = type;
        }

        /// <summary>
        /// Overload to support the separate name in the JSON for placing the initial order.
        /// </summary>
        [DataMember(Name = "stock")]
        private string Stock
        {
            get
            {
                return this.Symbol;
            }
        }
    }
}
