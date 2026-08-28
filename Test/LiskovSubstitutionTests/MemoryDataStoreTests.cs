using LiskovSubstitution;

namespace Test.LiskovSubstitutionTests
{
    public class MemoryDataStoreTests : DataStoreContractTests<MemoryDataStore>
    {
        protected override MemoryDataStore CreateStore()
        {
            return new MemoryDataStore();
        }
    }
}
