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

    /// <inheritdoc/>
    public virtual void Save(DataStoreKey key, string value)
    {
        _data[key] = value;
    }

    /// <inheritdoc/>
    public virtual string? Read(DataStoreKey key)
    {
        return _data.TryGetValue(key, out string? value) ? value : null;
    }
}
