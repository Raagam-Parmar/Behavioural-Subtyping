// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace LiskovSubstitution;

public class IntMemoryDataStore : MemoryDataStore, IDataStore
{
    /// <summary>
    /// Sanitizes the input data to ensure it is an integer.
    /// </summary>
    /// <param name="data">The input data to sanitize.</param>
    /// <returns>The sanitized integer as a string.</returns>
    /// <exception cref="ArgumentException">Thrown when the input data is not a valid integer.</exception>
    private static string Sanitize(string data)
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
    public override void Save(DataStoreKey key, string value)
    {
        string sanitizedValue = Sanitize(value);
        base.Save(key, sanitizedValue);
    }

    public override string Read(DataStoreKey key)
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
