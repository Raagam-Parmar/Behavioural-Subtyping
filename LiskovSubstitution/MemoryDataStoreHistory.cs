namespace LiskovSubstitution;

public sealed class MemoryDataStoreHistory : IDataStoreHistory
{
    /// <summary>
    /// A dictionary to hold the key-value pairs with history tracking in memory.
    /// </summary>
    private readonly Dictionary<string, Stack<string>> _data = [];

    /// <inheritdoc/>
    public void Save(string key, string value)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        if (!_data.ContainsKey(key))
        {
            _data[key] = new Stack<string>();
        }
        _data[key].Push(value);
    }

    /// <inheritdoc/>
    public string? Read(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        return _data.TryGetValue(key, out Stack<string>? value) ? value.Peek() : null;
    }

    /// <inheritdoc/>
    public void Revert(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        if (_data.ContainsKey(key) && _data[key].Count > 1)
        {
            _data[key].Pop();
        }
        else if (_data.ContainsKey(key) && _data[key].Count == 1)
        {
            _data.Remove(key);
        }
    }
}
