using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GenericBinaryTree
{
    public class SpeedMeasure
    {
        public bool Success { get; set; }
        public double Time { get; set; }
    }
    public static class Tests
    {
        public static bool TestBinaryTree()
        {
            GenericBinaryTree<int, string> tree = new GenericBinaryTree<int, string>();

            Console.Write("Testing Add()...");
            tree.Add(3, "hiru");
            tree.Add(7, "zazpi");
            tree.Add(11, "hamaika");
            tree.Add(2, "bi");
            tree.Add(1, "bat");
            tree.Add(4, "lau");
            tree.Add(15, "hamabost");
            tree.Add(5, "bost");
            tree.Add(13, "hamairu");
            tree.Add(6, "sei");
            tree.Add(8, "zortzi");
            tree.Add(9, "bereratzi");
            tree.Add(10, "hamar");
            tree.Add(12, "hamabi");
            tree.Add(14, "hamalau");

            string asString = tree.ToString();
            for (int i = 1; i < 16; i++)
            {
                if (asString == null || !asString.Contains($"[{i}-"))
                {
                    Console.WriteLine($"Error. Value {i} wasn't added to the tree");
                    Console.WriteLine(asString);
                    return false;
                }
            }
            Console.WriteLine("Ok");

            Console.WriteLine($"Initial tree:\n{tree.ToString()}");

            Console.Write("Testing Count()...");
            int count = tree.Count();
            if (count != 15)
            {
                Console.WriteLine($"Error. Count() returned {count} instead of 15");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Depth()...");
            int depth = tree.Depth();
            if (depth != 6)
            {
                Console.WriteLine($"Error. Depth() returned {depth} instead of 6");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Get()...");
            string value = tree.Get(12);
            if (value != "hamabi")
            {
                Console.WriteLine($"Error. Get(12) returned {value} instead of \"hamabi\"");
                return false;
            }
            value = tree.Get(14);
            if (value != "hamalau")
            {
                Console.WriteLine($"Error. Get(14) returned {value} instead of \"hamalau\"");
                return false;
            }
            value = tree.Get(4);
            if (value != "lau")
            {
                Console.WriteLine($"Error. Get(4) returned {value} instead of \"lau\"");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Add() with duplicated key...");
            tree.Add(6, "six");
            count = tree.Count();
            if (count != 15 || tree.Get(6) != "six")
            {
                Console.WriteLine($"Error. Get(6) after Add(6,\"six\") returned \"{tree.Get(6)}\" instead of \"six\"");
                return false;
            }
            Console.WriteLine("Ok");


            Console.Write("Testing Remove() with leaf nodes...");
            tree.Remove(6);
            int newCount = tree.Count();
            if (count != newCount + 1)
            {
                Console.WriteLine($"Error. Remove failed to remove leaf node");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Remove() with non-existing node...");
            tree.Remove(6);
            newCount = tree.Count();
            int expectedNodeCount = count - 1;
            if (expectedNodeCount != newCount)
            {
                Console.WriteLine($"Error. {newCount} instead of {expectedNodeCount} nodes");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Remove() with interior node with only left child...");
            tree.Remove(15);
            newCount = tree.Count();
            expectedNodeCount = count - 2;
            if (expectedNodeCount != newCount)
            {
                Console.WriteLine($"Error. {newCount} instead of {expectedNodeCount} nodes");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Remove() with interior node with only right child...");
            tree.Remove(8);
            newCount = tree.Count();
            expectedNodeCount = count - 3;
            if (expectedNodeCount != newCount)
            {
                Console.WriteLine($"Error. {newCount} instead of {expectedNodeCount} nodes");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Remove() with interior node with both left and right children...");
            tree.Remove(7);
            newCount = tree.Count();
            expectedNodeCount = count - 4;
            if (expectedNodeCount != newCount)
            {
                Console.WriteLine($"Error. {newCount} instead of {expectedNodeCount} nodes");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Remove() with root node...");
            tree.Remove(3);
            newCount = tree.Count();
            expectedNodeCount = count - 5;
            if (expectedNodeCount != newCount)
            {
                Console.WriteLine($"Error. {newCount} instead of {expectedNodeCount} nodes");
                return false;
            }
            Console.WriteLine("Ok");

            Console.WriteLine("Testing Keys()...");
            int[] keys = tree.Keys();
            foreach (int key in keys)
                Console.WriteLine(key);
            Console.WriteLine();

            Console.WriteLine("Testing Values()...");
            string[] values = tree.Values();
            foreach (string val in values)
                Console.WriteLine(val);
            Console.WriteLine();

            Console.WriteLine("Testing Balance()...");
            int oldDepth = tree.Depth();
            int oldCount = tree.Count();
            tree.Balance();
            int newDepth = tree.Depth();
            newCount = tree.Count();
            if (oldDepth <= newDepth || oldCount != newCount)
            {
                Console.WriteLine($"Balance() didn't work. Depth before is {oldDepth} and after is {newDepth}. Count is {newCount} instead of {oldCount}");
                return false;
            }
            Console.WriteLine("Ok");

            Console.WriteLine("Tree after balancing:");
            Console.WriteLine(tree.ToString());


            return true;
        }

        public static SpeedMeasure MeasureSpeed()
        {
            Console.WriteLine("Measuring speed");

            int numSamples = 1000000;
            Random randomGenerator = new Random();
            Dictionary<int, int> solutions = new Dictionary<int, int>();
            GenericBinaryTree<int, int> tree = new GenericBinaryTree<int, int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numSamples; i++)
            {
                int number = randomGenerator.Next(0, 10000);
                tree.Add(number, number * number);
                solutions[number] = number * number;
            }

            foreach (int number in solutions.Keys)
            {
                if (tree.Get(number) != solutions[number])
                    return new SpeedMeasure() { Success = false };

                tree.Remove(number);
            }

            return new SpeedMeasure() { Success = true, Time = stopwatch.Elapsed.TotalSeconds };
        }
    }
}