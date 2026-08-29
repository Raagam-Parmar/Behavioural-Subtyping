// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace LiskovSubstitution;

/// <summary>
/// A read-only in-memory data store that inherits from MemoryDataStore and implements the IDataStore interface.
/// It is a counterexample to the Liskov Substitution Principle. See README for more details.
/// </summary>
public class ReadOnlyMemoryDataStore : MemoryDataStore, IDataStore
{
    /// <summary>
    /// Initializes a new instance of the class with a few predefined key-value pairs.
    /// </summary>
    public ReadOnlyMemoryDataStore()
    {
        for (int i = 0; i < 10; i++)
        {
            base.Save($"RO_Key_{i}", $"RO_Value_{i}");
        }
    }

    /// <summary>
    /// Overrides the Save method to prevent saving data to the read-only data store.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public override void Save(DataStoreKey key, string value)
    {
        throw new InvalidOperationException("Cannot save data to a read-only data store.");
    }
}
