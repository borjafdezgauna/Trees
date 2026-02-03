
using System;
using EDA;

class MainClass
{
    public static void Main(string[] args)
    {
        bool success = TreeTests.TestGenericTree(Console.WriteLine, Console.WriteLine);

        if (success)
            Console.WriteLine("All tests passed");
    }
}