using System.Threading.Tasks;
using ShatteredTemple.Stockfighter.Common.Models;

namespace ShatteredTemple.Stockfighter.Common.Repositories
{
    public interface IStockExchange
    {
        /// <summary>
        /// Investigates whether the exchange is operating as intended.
        /// </summary>
        /// <returns>Model indicating either that the exchange is up, or the failure message returned.</returns>
        Task<HeartbeatModel> GetHeartbeat();

        /// <summary>
        /// Access the various venues the API offers.
        /// </summary>
        IStockVenues Venues { get; }
    }
}
