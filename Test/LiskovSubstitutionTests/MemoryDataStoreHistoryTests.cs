using LiskovSubstitution;

namespace Test.LiskovSubstitutionTests
{
    public class MemoryDataStoreHistoryTests : DataStoreContractTests<MemoryDataStoreHistory>
    {
        protected override MemoryDataStoreHistory CreateStore()
        {
            return new MemoryDataStoreHistory();
        }


        /// <summary>
        /// Tests that the Revert method throws an ArgumentException when called with an empty key.
        /// </summary>
        [Fact]
        public void RevertEmptyKeyThrows()
        {
            MemoryDataStoreHistory store = CreateStore();
            Assert.Throws<ArgumentException>(() => store.Revert(""));
        }

        /// <summary>
        /// Tests the Revert method of the MemoryDataStoreHistory class.
        /// </summary>
        [Fact]
        public void RevertTest()
        {
            var store = CreateStore();

            // Assuming that the data store is being used for type-checking
            store.Save("x", "int");
            store.Save("x", "string");
            store.Save("x", "float");

            Assert.Equal("float", store.Read("x"));

            store.Revert("x");
            Assert.Equal("string", store.Read("x"));

            store.Revert("x");
            Assert.Equal("int", store.Read("x"));

            store.Revert("x");
            Assert.Null(store.Read("x"));
        }
    }
}
