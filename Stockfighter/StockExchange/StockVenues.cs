using System.Collections.Generic;
using FallenTemple.Stockfighter.Common.Repositories;

namespace FallenTemple.Stockfighter.StockExchange
{
    public sealed class StockVenues : StockExchangeBase, ICachedRepository
    {
        private Dictionary<string, StockVenue> m_venues;

        internal StockVenues(string apiKey)
            : base(apiKey)
        {
            this.m_venues = new Dictionary<string, StockVenue>();
        }

        #region ICachedRepository

        public void ClearCache()
        {
            foreach (var venue in this.m_venues.Values)
            {
                venue.ClearCache();
            }
        }

        #endregion

        /// <summary>
        /// Gets a specific <see cref="StockVenue"/> repository.
        /// </summary>
        /// <param name="venue">Name of the venue to get.</param>
        /// <returns>Venue object.</returns>
        public StockVenue this[string venue]
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
    }
}
