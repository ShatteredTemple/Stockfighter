using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ShatteredTemple.Stockfighter.Common.Models
{
    [DataContract]
    public sealed class VenueStocksModel : BaseModel
    {
        [DataMember(Name = "symbols")]
        public IEnumerable<StockModel> Symbols { get; private set; }
    }
}
