using System;
using GenericTree;

class MainClass
{
    public static void Main(string[] args)
    {
        bool success = Tests.TestGenericTree();

        if (success)
            Console.WriteLine("All tests passed");
    }
}