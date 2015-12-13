using System.Runtime.Serialization;

namespace ShatteredTemple.Stockfighter.Common.Models
{
    /// <summary>
    /// Base model for both placing and getting the status of a stock order.
    /// </summary>
    [DataContract]
    public abstract class StockOrderModelBase : BaseModel
    {
        internal StockOrderModelBase()
        {
            // Do nothing, but keep outsiders from inheriting from this class.
        }

        [DataMember(Name = "account")]
        public string Account { get; protected set; }

        [DataMember(Name = "venue")]
        public string Venue { get; protected set; }

        [DataMember(Name = "symbol")]
        public string Symbol { get; protected set; }

        [DataMember(Name = "price")]
        private int PriceInCents
        {
            get
            {
                return (int)(this.Price * 100);
            }
        }

        public decimal Price { get; protected set; }

        [DataMember(Name = "qty")]
        public int Quantity { get; protected set; }

        [DataMember(Name = "direction")]
        public StockOrderDirection Direction { get; protected set; }

        [DataMember(Name = "orderType")]
        public StockOrderType Type { get; protected set; }
    }
}
