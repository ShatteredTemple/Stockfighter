namespace ShatteredTemple.Stockfighter.Common.Repositories
{
    /// <summary>
    /// Interface to allow repositories that cache data be managed/cleared by
    /// clients.
    /// </summary>
    public interface ICachedRepository
    {
        /// <summary>
        /// Clear the cache for this repository.
        /// </summary>
        void ClearCache();
    }
}
