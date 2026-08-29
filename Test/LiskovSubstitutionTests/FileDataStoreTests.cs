// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using LiskovSubstitution;

namespace Test.LiskovSubstitutionTests;

/// <summary>
/// Tests for the FileDataStore class.
/// </summary>
public class FileDataStoreTests : DataStoreContractTests<FileDataStore>
{
    protected override FileDataStore CreateStore()
    {
        return new FileDataStore();
    }

    /// <summary>
    /// Verifies two keys which contain invalid filepath characters at the same location, and are equal at
    /// all other indices, will collide in the FileDataStore. This is a known limitation of the FileDataStore implementation.
    /// </summary>
    [Fact]
    public void CollidingKeysInFileDataStore()
    {
        char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();

        FileDataStore store = CreateStore();

        foreach (char invalidChar in invalidChars)
        {
            string key1 = $"key{invalidChar}";
            store.Save(key1, "value1");
            Assert.Equal("value1", store.Read(key1));

            string key2 = $"key{invalidChar}";
            store.Save(key2, "value2");
            Assert.Equal("value2", store.Read(key2));

            // The two keys collide and return the same value
            Assert.Equal("value2", store.Read(key1));
        }
    }
}
