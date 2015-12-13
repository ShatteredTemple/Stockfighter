namespace ShatteredTemple.Stockfighter.Common
{
    /// <summary>
    /// Well-defined exchanges (generally for test purposes).
    /// </summary>
    public static class Exchanges
    {
        /// <summary>
        /// Test stock exchange.
        /// </summary>
        public static class TestExchange
        {
            /// <summary>
            /// Venue code for this exchange.
            /// </summary>
            public const string ExchangeCode = "TESTEX";

            /// <summary>
            /// Public accounts on this exchange.
            /// </summary>
            public static class Accounts
            {
                /// <summary>
                /// Test public account.
                /// </summary>
                public const string TestAccount = "EXB123456";
            }

            /// <summary>
            /// Stocks guaranteed to be available on this exchange.
            /// </summary>
            public static class Stocks
            {
                /// <summary>
                /// Test stock.
                /// </summary>
                public const string TestStock = "FOOBAR";
            }
        }
    }
}
