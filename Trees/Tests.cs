
using System;
namespace GenericTree
{
    public static class Tests
    {
        public static bool TestGenericTree()
        {
            GenericTree<int> tree = new GenericTree<int>();

            tree.RootNode = new GenericTreeNode<int>(1);

            Console.Write("Testing Add()...");

            GenericTreeNode<int> child1 = tree.RootNode.Add(2);
            GenericTreeNode<int> child2 = tree.RootNode.Add(3);
            GenericTreeNode<int> child11 = child1.Add(4);
            GenericTreeNode<int> child12 = child1.Add(5);
            GenericTreeNode<int> child13 = child1.Add(6);
            GenericTreeNode<int> child21 = child2.Add(7);
            GenericTreeNode<int> child22 = child2.Add(8);
            child11.Add(9);
            child12.Add(10);
            child12.Add(11);
            child13.Add(12);
            child21.Add(13);
            child22.Add(14);
            child22.Add(15);

            string asString = tree.ToString();
            for (int i = 1; i < 16; i++)
            {
                if (!asString.Contains($"[{i}]"))
                {
                    Console.WriteLine($"Error. Value {i} wasn't added to the tree:");
                    Console.WriteLine(asString);
                    return false;
                }
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Count()...");
            int count = tree.RootNode.Count();
            if (count != 15)
            {
                Console.WriteLine($"Error. Count() returned {count} instead of 15");
                return false;
            }

            Console.WriteLine("Ok");

            Console.Write("Testing Height()...");
            int height = tree.RootNode.Height();
            if (height != 4)
            {
                Console.WriteLine($"Error. Height() returned {height} instead of 4");
                return false;
            }

            Console.WriteLine("Ok");

            Console.Write("Testing Remove()...");
            tree.RootNode.Remove(15);
            count = tree.RootNode.Count();
            if (count != 14)
            {
                Console.WriteLine($"Error. Count() returned {count} instead of 14 after Remove(15)");
                return false;
            }
            tree.RootNode.Remove(3);
            count = tree.RootNode.Count();
            if (count != 9)
            {
                Console.WriteLine($"Error. Count() returned {count} instead of 9 after Remove(3)");
                return false;
            }

            GenericTreeNode<int> found = tree.RootNode.Find(12);
            if (found == null)
            {
                Console.WriteLine($"Error. Find(12) returned null");
                return false;
            }
            found = tree.RootNode.Find(9);
            if (found == null)
            {
                Console.WriteLine($"Error. Find(9) returned null");
                return false;
            }
            found = tree.RootNode.Find(1);
            if (found == null)
            {
                Console.WriteLine($"Error. Find(1) returned null");
                return false;
            }

            found = tree.RootNode.Find(12);
            tree.RootNode.Remove(found);
            found = tree.RootNode.Find(12);
            if (found != null)
            {
                Console.WriteLine($"Error. Remove(GenericTreeNode<T>) failed to delete item with value 12");
                return false;
            }

            found = tree.RootNode.Find(9);
            tree.RootNode.Remove(found);
            found = tree.RootNode.Find(9);
            if (found != null)
            {
                Console.WriteLine($"Error. Remove(GenericTreeNode<T>) failed to delete item with value 9");
                return false;
            }

            Console.WriteLine("Ok");

            return true;
        }
    }
}