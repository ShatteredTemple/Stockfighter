using System;
using System.Runtime.Serialization;

namespace ShatteredTemple.Stockfighter.Common.Models
{
    [DataContract]
    public sealed class StockQuoteModel : BaseModel
    {
        [DataMember(Name = "symbol")]
        public string Symbol { get; private set; }

        [DataMember(Name = "venue")]
        public string Venue { get; private set; }

        [DataMember(Name = "bid")]
        private int BidInCents
        {
            set
            {
                this.Bid = value / 100;
            }
        }

        public decimal Bid { get; private set; }

        [DataMember(Name = "ask")]
        private int AskInCents
        {
            set
            {
                this.Ask = value / 100;
            }
        }

        public decimal Ask { get; private set; }

        [DataMember(Name = "bidSize")]
        public int BidSize { get; private set; }

        [DataMember(Name = "askSize")]
        public int AskSize { get; private set; }

        [DataMember(Name = "bidDepth")]
        public int BidDepth { get; private set; }

        [DataMember(Name = "askDepth")]
        public int AskDepth { get; private set; }

        [DataMember(Name = "last")]
        private int LastTradeInCents
        {
            set
            {

            }
        }

        public decimal LastTrade { get; private set; }

        [DataMember(Name = "lastSize")]
        public int LastTradeSize { get; private set; }

        [DataMember(Name = "lastTrade")]
        public DateTime LastTradeTimestamp { get; private set; }

        [DataMember(Name = "quoteTime")]
        public DateTime Timestamp { get; private set; }
    }
}
