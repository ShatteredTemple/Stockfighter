namespace ShatteredTemple.Stockfighter.Common.Repositories
{
    /// <summary>
    /// Parent class wrapping <see cref="IStockVenue"/>s offered by an <see cref="IStockExchange"/>.
    /// </summary>
    public interface IStockVenues
    {
        /// <summary>
        /// Gets a specific <see cref="IStockVenue"/> repository.
        /// </summary>
        /// <param name="venue">Name of the venue to get.</param>
        /// <returns>Venue object.</returns>
        IStockVenue this[string venue] { get; }
    }
}
