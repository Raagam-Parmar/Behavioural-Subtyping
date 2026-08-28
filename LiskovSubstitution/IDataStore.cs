using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution;

/// <summary>
/// A contract for data storage providers, defining methods for saving and reading key-value pairs.
/// </summary>
public interface IDataStore
{
    /// <summary>
    /// Saves a key-value pair to the data store. If the key already exists, it remembers the new value.
    /// </summary>
    /// <param name="key">The key for the data to save.</param>
    /// <param name="value">The value for the data to save.</param>
    void Save(string key, string value);

    /// <summary>
    /// Reads the value associated with the specified key from the data store. If the key does not exist, it returns null.
    /// </summary>
    /// <param name="key">The key for the data to read.</param>
    /// <returns>The value associated with the key, or null if the key does not exist.</returns>
    string? Read(string key);
}
