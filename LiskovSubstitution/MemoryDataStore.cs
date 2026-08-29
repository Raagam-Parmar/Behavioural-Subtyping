// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace LiskovSubstitution;

public class MemoryDataStore : IDataStore
{
    /// <summary>
    /// A dictionary to hold the key-value pairs in memory.
    /// </summary>
    private readonly Dictionary<string, string> _data = [];

    /// <summary>
    /// Validates that the provided key is not null or empty. Throws an ArgumentException if the key is invalid.
    /// </summary>
    /// <param name="key">The key to validate.</param>
    /// <exception cref="ArgumentException">If the key is null or empty.</exception>
    private static void ValidateKey(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }
    }

    /// <inheritdoc/>
    public virtual void Save(string key, string value)
    {
        ValidateKey(key);
        _data[key] = value;
    }

    /// <inheritdoc/>
    public virtual string? Read(string key)
    {
        ValidateKey(key);
        return _data.TryGetValue(key, out string? value) ? value : null;
    }
}
