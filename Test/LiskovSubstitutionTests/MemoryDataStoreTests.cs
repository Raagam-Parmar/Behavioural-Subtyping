using LiskovSubstitution;

namespace Test.LiskovSubstitutionTests
{
    public class MemoryDataStoreTests
    {
        /// <summary>
        /// Tests that the Read method returns the correct value after saving a key-value pair in the MemoryDataStore.
        /// </summary>
        [Fact]
        public void ReadAfterSaveIsCorrect_01()
        {
            IDataStore store = new MemoryDataStore();

            store.Save("nat", "Type");

            string? value = store.Read("nat");

            Assert.Equal("Type", value);
        }

        /// <summary>
        /// Tests that the Read method returns null when attempting to read a key that has not been saved in the MemoryDataStore.
        /// </summary>
        [Fact]
        public void ReadBeforeSaveIsNull_01()
        {
            IDataStore store = new MemoryDataStore(); 

            string? value = store.Read("nat");

            Assert.Null(value);
        }

        /// <summary>
        /// Tests that the MemoryDataStore can save and read multiple key-value pairs correctly, including sequences of keys.
        /// </summary>
        [Fact]
        public void SaveSequence()
        {
            IDataStore store = new MemoryDataStore();

            store.Save("e1", "τ1");
            store.Save("e2", "τ1 -> τ2");
            store.Save("e2 e1", "τ2");

            Assert.Equal("τ1", store.Read("e1"));
            Assert.Equal("τ1 -> τ2", store.Read("e2"));
            Assert.Equal("τ2", store.Read("e2 e1"));
        }
    }
}
