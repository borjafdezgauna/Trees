using System;
using GenericBinaryTree;

class MainClass
{
    public static void Main(string[] args)
    {
        bool success = Tests.TestBinaryTree();
        if (!success)
            return;

        SpeedMeasure speedMeasure = Tests.MeasureSpeed();
        if (!speedMeasure.Success)
        {
            Console.WriteLine("An error was detected during the speed measurement. Probably something wrong with Add/Get");
            return;
        }
        Console.WriteLine($"All tests passed. Time: {speedMeasure.Time}s");
    }
}