using System;
using System.Diagnostics;
using EDA;

class MainClass
{
    public static void Main(string[] args)
    {
        bool success = BinaryTreeTests.TestBinaryTree(Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        Stopwatch stopwatch = Stopwatch.StartNew();
        success = BinaryTreeTests.MeasureBinaryTreeSpeed(Console.WriteLine, Console.WriteLine);
        if (!success)
        {
            Console.WriteLine("An error was detected during the speed measurement. Probably something wrong with Add/Get");
            return;
        }
        Console.WriteLine($"All tests passed. Time: {stopwatch.Elapsed.TotalSeconds}s");
    }
}