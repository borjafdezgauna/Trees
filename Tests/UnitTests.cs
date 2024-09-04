namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void GenericTrees()
        {
            Assert.True(GenericTree.Tests.TestGenericTree());
        }

        [Fact]
        public void BinaryTrees()
        {
            Assert.True(GenericBinaryTree.Tests.TestBinaryTree());
        }
    }
}