using System;
using System.Runtime.Serialization;

namespace FallenTemple.Stockfighter.Common.Models
{
    [DataContract]
    public sealed class StockOrderFillModel
    {
        [DataMember(Name = "price")]
        public int PriceInCents { get; private set; }

        public decimal Price
        {
            get
            {
                return PriceInCents / 100;
            }
        }

        [DataMember(Name = "qty")]
        public int Quantity { get; private set; }

        [DataMember(Name = "ts")]
        public DateTime TimeStamp { get; private set; }
    }
}
