namespace LiskovSubstitution
{
    public sealed class MemoryDataStoreHistory : IDataStoreHistory
    {
        /// <summary>
        /// A dictionary to hold the key-value pairs with history tracking in memory.
        /// </summary>
        private readonly Dictionary<string, Stack<string>> _data = [];
        
        /// <inheritdoc/>
        public void Save(string key, string value)
        {
            if (!_data.ContainsKey(key))
            {
                _data[key] = new Stack<string>();
            }
            _data[key].Push(value);
        }

        /// <inheritdoc/>
        public string? Read(string key)
        {
            return _data.TryGetValue(key, out var value) ? value.Peek() : null;
        }

        /// <inheritdoc/>
        public void Revert(string key)
        {
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
}
