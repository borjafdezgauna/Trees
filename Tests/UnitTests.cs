namespace UnitTests;
using System;
using EDA;
public class UnitTests
{
    [Fact]
    public void GenericTrees()
    {
        TimeoutHandler.Test(TreeTests.TestGenericTree, 1, Console.WriteLine, Assert.Fail);
    }

    [Fact]
    public void BinaryTrees()
    {
        TimeoutHandler.Test(EDA.BinaryTreeTests.TestBinaryTree, 1, Console.WriteLine, Assert.Fail);
    }

    [Fact]
    public void BinaryTreesPerformance()
    {
        TimeoutHandler.Test(EDA.BinaryTreeTests.MeasureBinaryTreeSpeed, 2, Console.WriteLine, Assert.Fail);
    }
}