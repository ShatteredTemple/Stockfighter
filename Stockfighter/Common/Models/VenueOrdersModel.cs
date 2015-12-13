using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ShatteredTemple.Stockfighter.Common.Models
{
    [DataContract]
    public sealed class VenueOrdersModel : BaseModel
    {
        [DataMember(Name = "string")]
        public string Venue { get; private set; }

        [DataMember(Name = "orders")]
        public IEnumerable<StockOrderModel> Orders { get; private set; }
    }
}
