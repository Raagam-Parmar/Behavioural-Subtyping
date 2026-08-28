using LiskovSubstitution;

namespace Test.LiskovSubstitutionTests
{
    public class IntMemoryDataStoreTests
    {
        /// <summary>
        /// Tests that the Read method returns the correct positive integer after saving a key-value pair in the IntMemoryDataStore.
        /// </summary>
        [Fact]
        public void ReadAfterSaveIsCorrectPositive()
        {
            IDataStore store = new IntMemoryDataStore();

            store.Save("payment_19102025", "10000");
            string? value = store.Read("payment_19102025");
            Assert.Equal("10000", value);
        }

        /// <summary>
        /// Tests that the Read method returns the correct negative integer after saving a key-value pair in the IntMemoryDataStore.
        /// </summary>
        [Fact]
        public void ReadAfterSaveIsCorrectNegative()
        {
            IDataStore store = new IntMemoryDataStore();

            store.Save("payment_19102025", "-10000");
            string? value = store.Read("payment_19102025");
            Assert.Equal("-10000", value);
        }

        /// <summary>
        /// Tests that the Read method returns empty string when attempting to read a key that has not been saved in the IntMemoryDataStore.
        /// </summary>
        [Fact]
        public void ReadBeforeSaveIsNull()
        {
            IDataStore store = new IntMemoryDataStore();

            string? value = store.Read("key_does_not_exist");
            Assert.Equal("", value);
        }

        /// <summary>
        /// Tests that the Save method throws an ArgumentException when attempting to save a non-integer value.
        /// </summary>
        [Fact]
        public void SaveNonIntThrows()
        {
            IDataStore store = new IntMemoryDataStore();

            Assert.Throws<ArgumentException>(() => store.Save("payment_19102025", "10000 Rupees"));
        }

        /// <summary>
        /// Tests that the IntMemoryDataStore can save and read multiple key-value pairs correctly, including sequences of keys.
        /// </summary>
        [Fact]
        public void SaveSequence()
        {
            IDataStore store = new IntMemoryDataStore();

            store.Save("payment_01", "100");
            store.Save("payment_02", "200");
            store.Save("payment_03", "300");

            Assert.Equal("100", store.Read("payment_01"));
            Assert.Equal("200", store.Read("payment_02"));
            Assert.Equal("300", store.Read("payment_03"));
        }
    }
}
