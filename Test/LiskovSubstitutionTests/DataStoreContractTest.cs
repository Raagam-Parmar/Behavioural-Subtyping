using LiskovSubstitution;

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

    // TODO Add randomized tests
}
