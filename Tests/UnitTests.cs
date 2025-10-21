namespace UnitTests;
using System;
public class Tests
{
    [Fact]
    public void GenericTrees()
    {
        TimeoutHandler.Test(GenericTree.Tests.TestGenericTree, 1, Console.WriteLine, Assert.Fail);
    }

    [Fact]
    public void BinaryTrees()
    {
        TimeoutHandler.Test(GenericBinaryTree.Tests.TestBinaryTree, 1, Console.WriteLine, Assert.Fail);
    }

    [Fact]
    public void BinaryTreesPerformance()
    {
        TimeoutHandler.Test(GenericBinaryTree.Tests.MeasureBinaryTreeSpeed, 2, Console.WriteLine, Assert.Fail);
    }
}