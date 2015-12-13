using System.Runtime.Serialization;

namespace FallenTemple.Stockfighter.Common
{
    public enum StockOrderDirection
    {
        [EnumMember(Value = "buy")]
        Buy,
        [EnumMember(Value = "sell")]
        Sell
    }

    public enum StockOrderType
    {
        [EnumMember(Value = "limit")]
        Limit,
        [EnumMember(Value = "market")]
        Market,
        [EnumMember(Value = "fill-or-kill")]
        FillOrKill,
        [EnumMember(Value = "immediate-or-cancel")]
        ImmediateOrCancel
    }
}
