// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using LiskovSubstitution;

namespace Test.LiskovSubstitutionTests;

/// <summary>
/// Tests for the ReadOnlyMemoryDataStore class.
/// </summary>

public class ReadOnlyMemoryDataStoreTests
{
    /// <summary>
    /// Tests that the Save method of ReadOnlyMemoryDataStore throws an InvalidOperationException when called.
    /// </summary>
    [Fact]
    public void SaveThrowsInvalidOperationException()
    {
        ReadOnlyMemoryDataStore store = new ReadOnlyMemoryDataStore();

        Assert.Throws<InvalidOperationException>(() => store.Save("NewKey", "NewValue"));
    }

    /// <summary>
    /// Tests that the Read method of ReadOnlyMemoryDataStore does not throw an exception and returns the expected value for existing keys.
    /// </summary>
    [Fact]
    public void ReadDoesNotThrow()
    {
        ReadOnlyMemoryDataStore store = new ReadOnlyMemoryDataStore();

        for (int i = 0; i < 10; i++)
        {
            string? value = store.Read($"RO_Key_{i}");

            Assert.Equal($"RO_Value_{i}", value);
        }
    }
}
