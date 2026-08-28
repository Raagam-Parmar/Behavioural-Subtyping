using LiskovSubstitution;

namespace Test.LiskovSubstitutionTests;

public class FileDataStoreTests : DataStoreContractTests<FileDataStore>
{
    protected override FileDataStore CreateStore()
    {
        return new FileDataStore();
    }
}
