// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace LiskovSubstitution;

/// <summary>
/// A simple in-memory data store that implements the IDataStoreHistory interface.
/// </summary>
public sealed class MemoryDataStoreHistory : IDataStoreHistory
{
    /// <summary>
    /// A dictionary to hold the key-value pairs with history tracking in memory.
    /// </summary>
    private readonly Dictionary<string, Stack<string>> _data = [];

    /// <inheritdoc/>
    public void Save(DataStoreKey key, string value)
    {
        if (!_data.TryGetValue(key, out Stack<string>? value1))
        {
            value1 = new Stack<string>();
            _data[key] = value1;
        }

        value1.Push(value);
    }

    /// <inheritdoc/>
    public string? Read(DataStoreKey key)
    {
        return _data.TryGetValue(key, out Stack<string>? value) ? value.Peek() : null;
    }

    /// <inheritdoc/>
    public void Revert(DataStoreKey key)
    {
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
