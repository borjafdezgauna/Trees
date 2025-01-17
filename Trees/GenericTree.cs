
using System;
using System.Threading;

namespace GenericTree
{
    //TODO #1: Copy your GenericList<T> class from last project and add the file GenericList.cs to this project and delete the class below.
    public class GenericList<T> { public int Count() { return 0; } public T Get(int index) { return default(T); } }

    public class GenericTreeNode<T>
    {
        private T Value;

        private GenericList<GenericTreeNode<T>> Children;

        public GenericTreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
        }

        public string ToString(int depth)
        {
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                GenericTreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1);
            }
            return output;
        }

        public GenericTreeNode<T> Add(T value)
        {
            //TODO #3: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created

            return null;
        }

        public int Count()
        {
            //TODO #4: Return the total number of elements in this tree

            return 0;
        }

        public int Height()
        {
            //TODO #5: Return the height of this tree

            return 0;
        }



        public void Remove(T value)
        {
            //TODO #6: Remove the child node that has Value=value. Apply recursively

        }

        public GenericTreeNode<T> Find(T value)
        {
            //TODO #7: Return the node that contains this value (it might be this node or a child). Apply recursively
            return null;
        }

        public void Remove(GenericTreeNode<T> node)
        {
            //TODO #8: Same as #6, but this method is given the specific node to remove, not the value
        }
    }

    public class GenericTree<T>
    {
        public GenericTreeNode<T> RootNode = null;

        public override string ToString()
        {
            if (RootNode == null)
                return null;
            else return RootNode.ToString(0);
        }
    }
}