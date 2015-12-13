using System.Collections.Generic;
using ShatteredTemple.Stockfighter.Common.Repositories;

namespace ShatteredTemple.Stockfighter.StockExchange
{
    /// <summary>
    /// Parent class wrapping <see cref="IStockVenue"/>s offered by an <see cref="IStockExchange"/>.
    /// </summary>
    public sealed class StockVenues : StockExchangeBase, IStockVenues, ICachedRepository
    {
        private Dictionary<string, StockVenue> m_venues;

        internal StockVenues(string apiKey)
            : base(apiKey)
        {
            this.m_venues = new Dictionary<string, StockVenue>();
        }

        #region IStockVenues

        /// <summary>
        /// Gets a specific <see cref="StockVenue"/> repository.
        /// </summary>
        /// <param name="venue">Name of the venue to get.</param>
        /// <returns>Venue object.</returns>
        public IStockVenue this[string venue]
        {
            get
            {
                // This must be locked, to prevent "key already added to the
                // dictionary" issues if multiple threads are accessing.
                lock (this.m_venues)
                {
                    if (!this.m_venues.ContainsKey(venue))
                    {
                        this.m_venues.Add(venue, new StockVenue(this.ApiKey, venue));
                    }
                }
                return this.m_venues[venue];
            }
        }

        #endregion

        #region ICachedRepository

        /// <summary>
        /// Clear the cache for this repository.
        /// </summary>
        public void ClearCache()
        {
            foreach (var venue in this.m_venues.Values)
            {
                venue.ClearCache();
            }
        }

        #endregion


    }
}
