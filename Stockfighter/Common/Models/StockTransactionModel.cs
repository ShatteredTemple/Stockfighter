using System.Runtime.Serialization;

namespace ShatteredTemple.Stockfighter.Common.Models
{
    [DataContract]
    public sealed class StockTransactionModel
    {
        [DataMember(Name = "price")]
        private int PriceInCents
        {
            set
            {
                this.Price = value / 100;
            }
        }

        public decimal Price { get; private set; }

        [DataMember(Name = "qty")]
        public int Quantity { get; private set; }

        [DataMember(Name = "isBuy")]
        public bool IsBuy { get; private set; }
    }
}
