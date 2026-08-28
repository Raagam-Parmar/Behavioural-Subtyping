namespace LiskovSubstitution;

public class MemoryDataStore : IDataStore
{
    /// <summary>
    /// A dictionary to hold the key-value pairs in memory.
    /// </summary>
    private readonly Dictionary<string, string> _data = [];

    /// <inheritdoc/>
    public virtual void Save(string key, string value)
    {
        _data[key] = value;
    }

    /// <inheritdoc/>
    public virtual string? Read(string key)
    {
        return _data.TryGetValue(key, out string? value) ? value : null;
    }
}
