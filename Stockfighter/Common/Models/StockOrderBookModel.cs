using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ShatteredTemple.Stockfighter.Common.Models
{
    [DataContract]
    public sealed class StockOrderBookModel : BaseModel
    {
        [DataMember(Name = "venue")]
        public string Venue { get; private set; }

        [DataMember(Name = "symbol")]
        public string Symbol { get; private set; }

        [DataMember(Name = "bids")]
        public IEnumerable<StockTransactionModel> Bids { get; private set; }

        [DataMember(Name = "asks")]
        public IEnumerable<StockTransactionModel> Asks { get; private set; }

        [DataMember(Name = "ts")]
        public DateTime Timestamp { get; private set; }
    }
}
