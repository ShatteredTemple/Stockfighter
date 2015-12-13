using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ShatteredTemple.Stockfighter.Common.Models
{
    /// <summary>
    /// Model describing the status of a placed order.
    /// </summary>
    [DataContract]
    public sealed class StockOrderModel : StockOrderModelBase
    {
        /// <summary>
        /// Overload to support the separate name in the JSON for placing the initial order.
        /// </summary>
        [DataMember(Name = "type")]
        private StockOrderType TypeAlternate
        {
            get
            {
                return this.Type;
            }
            set
            {
                this.Type = value;
            }
        }

        [DataMember(Name = "id")]
        public int VenueOrderId { get; private set; }

        [DataMember(Name = "ts")]
        public DateTime Timestamp { get; private set; }

        [DataMember(Name = "fills")]
        public IEnumerable<StockOrderFillModel> Fills { get; private set; }

        [DataMember(Name = "totalFilled")]
        public int TotalFilled { get; private set; }

        [DataMember(Name = "open")]
        public bool IsOrderOpen { get; private set; }

    }
}
