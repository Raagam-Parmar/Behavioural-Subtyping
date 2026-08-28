namespace LiskovSubstitution;

/// <summary>
/// A contract for data storage providers which support history tracking.
/// </summary>
public interface IDataStoreHistory : IDataStore
{
    /// <summary>
    /// Reverts the value associated with the specified key to its previous state.
    /// If the key is not found, it does nothing.
    /// If there is only one value in the history for the key, it removes the key from the data store.
    /// </summary>
    /// <param name="key">The key for the data to revert.</param>
    void Revert(string key);
}
