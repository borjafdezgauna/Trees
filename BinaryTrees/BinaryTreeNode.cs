
using System;
namespace GenericBinaryTree
{
    public class BinaryTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key;
        public TValue Value;
        public BinaryTreeNode<TKey, TValue> LeftChild;
        public BinaryTreeNode<TKey, TValue> RightChild;

        public BinaryTreeNode(TKey key, TValue value)
        {
            //TODO #1: Initialize member variables/attributes
            
        }

        public string ToString(int depth)
        {
            string output = null;

            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            if (Value != null)
                output += $"{leftSpace}[{Key.ToString()}-{Value.ToString()}]\n";

            if (LeftChild != null)
                output += $"{LeftChild?.ToString(depth + 1)}";

            if (RightChild != null)
                output += $"{RightChild?.ToString(depth + 1)}";

            return output;
        }

        public void Add(BinaryTreeNode<TKey, TValue> node)
        {
            //TODO #2: Add the new node following the order:
            //          -If the current node (this) has a higher key that the new node (use CompareTo()), the new node should be on this node's left.
            //              a) If the left child is null, the added node should be this node's left node side
            //              b) Else, we should ask the LeftChild to add it recursively
            //          -If the current node has a lower key that the new node (use CompareTo()), the new node should be on this node's right side.
            //          -If the current node and the new node have the same key, just update this node's value with the new node's value
            
        }

        public int Count()
        {
            //TODO #3: Return the total number of elements in this tree
            
            return 0;
            
        }

        public int Height()
        {
            //TODO #4: Return the height of this tree
            
            return 0;
            
        }

        public TValue Get(TKey key)
        {
            //TODO #5: Find the node that has this key:
            //          -If the current node (this) has a higher key that the new node (use CompareTo()), the key we are searching for should be on this node's left side.
            //              a) If the left child is null, return null. We haven't found it
            //              b) Else, we should ask the LeftChild to find the node recursively. It must be below LeftChild
            //          -If the current node has a lower key that the new node (use CompareTo()), the key should be on this node's right side.
            //          -If the current node and the new node have the same key, just return this node's value. We found it
            
            return default;
            
        }

        

        public BinaryTreeNode<TKey, TValue> Remove(TKey key)
        {
            //TODO #6: Remove the node that has this key. The parent may need to update one of its children,
            //so this method returns the node with which this node needs to be replaced. If this node isn't the
            //one we are looking for, we will return this, so that the parent node can replace LeftChild/RightChild
            //with the same node it had.
            
            return null;
            
        }

        public int KeysToArray(TKey[] keys, int index)
        {
            if (LeftChild != null)
                index = LeftChild.KeysToArray(keys, index);
            keys[index] = Key;
            index++;
            if (RightChild != null)
                index = RightChild.KeysToArray(keys, index);
            return index;
        }

        public int ValuesToArray(TValue[] values, int index)
        {
            if (LeftChild != null)
                index = LeftChild.ValuesToArray(values, index);
            values[index] = Value;
            index++;
            if (RightChild != null)
                index = RightChild.ValuesToArray(values, index);
            return index;
        }
    }
}