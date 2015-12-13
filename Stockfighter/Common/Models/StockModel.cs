using System.Runtime.Serialization;

namespace FallenTemple.Stockfighter.Common.Models
{
    [DataContract]
    public sealed class StockModel
    {
        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [DataMember(Name = "symbol")]
        public string Symbol { get; private set; }
    }
}
