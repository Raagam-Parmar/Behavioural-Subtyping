namespace LiskovSubstitution
{
    public sealed class MemoryDataStore : IDataStore
    {
        private readonly Dictionary<string, string> _data = [];

        public void Save(string key, string value)
        {
            _data[key] = value;
        }

        public string? Read(string key)
        {
            return _data.TryGetValue(key, out var value) ? value : null;
        }
    }
}
