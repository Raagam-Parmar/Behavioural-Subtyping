namespace LiskovSubstitution;

public class IntMemoryDataStore : MemoryDataStore, IDataStore
{
    /// <summary>
    /// Sanitizes the input data to ensure it is an integer.
    /// </summary>
    /// <param name="data">The input data to sanitize.</param>
    /// <returns>The sanitized integer as a string.</returns>
    /// <exception cref="ArgumentException">Thrown when the input data is not a valid integer.</exception>
    private string Sanitize(string data)
    {
        bool parseSuccess = int.TryParse(data, out int value);

        if (!parseSuccess)
        {
            throw new ArgumentException("Value must be an integer.", nameof(data));
        }

        return value.ToString();
    }

    /// <summary>
    /// Saves the key-value pair to the data store after sanitizing the value to ensure it is an integer.
    /// </summary>
    /// <param name="key">The key for the data store.</param>
    /// <param name="value">The value to save, which will be sanitized to an integer.</param>
    public override void Save(string key, string value)
    {
        string sanitizedValue = Sanitize(value);
        base.Save(key, sanitizedValue);
    }

    public override string Read(string key)
    {
        string? value = base.Read(key);

        if (value == null)
        {
            return "";
        }
        else
        {
            return value;
        }
    }
}
