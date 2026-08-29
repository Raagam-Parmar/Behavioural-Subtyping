// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;

namespace LiskovSubstitution;

/// <summary>
/// Represents a key for the data store, ensuring that it is not null or empty.
/// Provides implicit conversions to and from string for ease of use.
/// </summary>
public readonly struct DataStoreKey
{
    public string Key { get; }

    public DataStoreKey(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        Key = key;
    }

    public static implicit operator string(DataStoreKey dataStoreKey)
    {
        return dataStoreKey.Key;
    }

    public static implicit operator DataStoreKey(string key)
    {
        return new(key);
    }
}

/// <summary>
/// A contract for data storage providers, defining methods for saving and reading key-value pairs.
/// </summary>
public interface IDataStore
{
    /// <summary>
    /// Saves a key-value pair to the data store. If the key already exists, it remembers the new value.
    /// Throws an exception if the key is the empty string.
    /// </summary>
    /// <param name="key">The key for the data to save.</param>
    /// <param name="value">The value for the data to save.</param>
    void Save(DataStoreKey key, string value);

    /// <summary>
    /// Reads the value associated with the specified key from the data store. If the key does not exist, it returns null.
    /// Throws an exception if the key is the empty string.
    /// </summary>
    /// <param name="key">The key for the data to read.</param>
    /// <returns>The value associated with the key, or null if the key does not exist.</returns>
    string? Read(DataStoreKey key);
}
