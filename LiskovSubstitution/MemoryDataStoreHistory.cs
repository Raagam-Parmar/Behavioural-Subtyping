// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace LiskovSubstitution;

public sealed class MemoryDataStoreHistory : IDataStoreHistory
{
    /// <summary>
    /// A dictionary to hold the key-value pairs with history tracking in memory.
    /// </summary>
    private readonly Dictionary<string, Stack<string>> _data = [];

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
    public void Save(string key, string value)
    {
        ValidateKey(key);
        if (!_data.TryGetValue(key, out Stack<string>? value1))
        {
            value1 = new Stack<string>();
            _data[key] = value1;
        }

        value1.Push(value);
    }

    /// <inheritdoc/>
    public string? Read(string key)
    {
        ValidateKey(key);
        return _data.TryGetValue(key, out Stack<string>? value) ? value.Peek() : null;
    }

    /// <inheritdoc/>
    public void Revert(string key)
    {
        ValidateKey(key);
        if (_data.TryGetValue(key, out Stack<string>? value) && value.Count > 1)
        {
            value.Pop();
        }
        else if (_data.TryGetValue(key, out Stack<string>? value1) && value1.Count == 1)
        {
            _data.Remove(key);
        }
    }
}
