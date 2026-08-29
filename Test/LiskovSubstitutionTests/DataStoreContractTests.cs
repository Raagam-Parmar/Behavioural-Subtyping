// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using LiskovSubstitution;

/// <summary>
/// An abstract base class for contract tests of any IDataStore implementation.
/// </summary>
/// <typeparam name="TStore">The type of the data store to test.</typeparam>
public abstract class DataStoreContractTests<TStore> where TStore : IDataStore
{
    protected abstract TStore CreateStore();

    /// <summary>
    /// Tests that the Save method accepts any string value and retrieves it correctly using the Read method.
    /// </summary>
    [Fact]
    public void SaveAcceptsAnyStringAndRetrievesCorrectly()
    {
        IDataStore store = CreateStore();

        string arbitraryKey = "user_note";
        string arbitraryValue = "Hello, world! Non-integer string.";
        store.Save(arbitraryKey, arbitraryValue);
        Assert.Equal(arbitraryValue, store.Read(arbitraryKey));
    }

    /// <summary>
    /// Tests that the Save method does not throw an exception when saving an empty string or a string with special characters.
    /// </summary>
    [Fact]
    public void SaveEmptyOrSpecialCharactersDoesNotThrow()
    {
        IDataStore store = CreateStore();

        store.Save("symbols", "@#$%^&*()");
        Assert.Equal("@#$%^&*()", store.Read("symbols"));

        store.Save("empty", "");
        Assert.Equal("", store.Read("empty"));
    }

    /// <summary>
    /// Tests that the Read method returns null for a key that has not been saved yet.
    /// </summary>
    [Fact]
    public void ReadBeforeSaveIsNull()
    {
        IDataStore store = CreateStore();

        string? value = store.Read("key_does_not_exist");
        Assert.Null(value);
    }

    /// <summary>
    /// Tests that the Save method throws an ArgumentException when attempting to save a value with an empty key.
    /// </summary>
    [Fact]
    public void SavingEmptyKeyThrows()
    {
        IDataStore store = CreateStore();

        Assert.Throws<ArgumentException>(() => store.Save("", "value"));
    }

    /// <summary>
    /// Tests that the Read method throws an ArgumentException when attempting to read a value with an empty key.
    /// </summary>
    [Fact]
    public void ReadingEmptyKeyThrows()
    {
        IDataStore store = CreateStore();
        Assert.Throws<ArgumentException>(() => store.Read(""));
    }

    // Source - https://stackoverflow.com/a/1344242
    // Posted by dtb, modified by community. See post 'Timeline' for change history
    // Retrieved 2026-08-28, License - CC BY-SA 4.0
    private static readonly Random s_random = new();
    //
    public static string RandomString(int length)
    {
        // All printable ASCII characters from space (32) to tilde (126)
        string chars = new([.. Enumerable.Range(32, 126).Select(i => (char)i)]);

        return new string([.. Enumerable.Repeat(chars, length).Select(s => s[s_random.Next(s.Length)])]);
    }

    /// <summary>
    /// Performs randomized tests to ensure the classes implementing IDataStore can handle arbitrary ASCII strings as keys and values.
    /// </summary>
    [Fact]
    public void RandomizedTests()
    {
        IDataStore store = CreateStore();
        Random random = new Random();

        for (int i = 0; i < 100; i++)
        {
            string key = RandomString(random.Next(1, 100));
            string value = RandomString(random.Next(1, 100));

            store.Save(key, value);
            string? retrievedValue = store.Read(key);
            Assert.Equal(value, retrievedValue);
        }
    }

    /// <summary>
    /// Tests that saving the same key multiple times with different values retrieves the most recently saved value.
    /// </summary>
    [Fact]
    public void RepeatedSaves()
    {
        IDataStore store = CreateStore();

        string key = "repeated_key";

        for (int i = 0; i < 10; i++)
        {
            string value = $"value_{i}";
            store.Save(key, value);
            string? retrievedValue = store.Read(key);
            Assert.Equal(value, retrievedValue);
        }
    }
}
