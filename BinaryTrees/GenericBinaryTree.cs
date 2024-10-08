
using System;

namespace GenericBinaryTree
{
    public class GenericBinaryTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key;
        public TValue Value;
        public GenericBinaryTreeNode<TKey, TValue> LeftChild;
        public GenericBinaryTreeNode<TKey, TValue> RightChild;

        public GenericBinaryTreeNode(TKey key, TValue value)
        {
            //TODO #1: Initialize member variables/attributes
        }

        public override string ToString(int depth)
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

        public void Add(GenericBinaryTreeNode<TKey, TValue> node)
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

        public int Depth()
        {
            //TODO #4: Return the maximum depth of this tree

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

            return default(TValue);
        }



        public GenericBinaryTreeNode<TKey, TValue> Remove(TKey key)
        {
            //TODO #6: Remove the node that has this key. The parent may need to update one of its children, so this method returns the node with which this node needs to be replaced
            //          If this node isn't the one we are looking for, we will return this, so that the parent node can replace LeftChild/RightChild with the same node it had

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

    public class GenericBinaryTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public GenericBinaryTreeNode<TKey, TValue> RootNode;

        public override string ToString()
        {
            if (RootNode == null)
                return null;
            else return RootNode.ToString(0);
        }

        public int Count()
        {
            if (RootNode == null)
                return 0;
            return RootNode.Count();
        }

        public int Depth()
        {
            if (RootNode == null)
                return 0;
            return RootNode.Depth();
        }

        public TValue Get(TKey key)
        {
            if (RootNode == null)
                return default(TValue);
            else
            {
                return RootNode.Get(key);
            }
        }

        public void Add(TKey key, TValue value)
        {
            GenericBinaryTreeNode<TKey, TValue> newNode = new GenericBinaryTreeNode<TKey, TValue>(key, value);
            if (RootNode == null)
                RootNode = newNode;
            else
                RootNode.Add(newNode);
        }

        public void Remove(TKey key)
        {
            if (RootNode != null)
                RootNode = RootNode.Remove(key);
        }

        public TKey[] Keys()
        {
            if (RootNode == null)
                return null;
            int count = RootNode.Count();
            TKey[] keys = new TKey[count];
            RootNode.KeysToArray(keys, 0);
            return keys;
        }

        public TValue[] Values()
        {
            if (RootNode == null)
                return null;
            int count = RootNode.Count();
            TValue[] values = new TValue[count];
            RootNode.ValuesToArray(values, 0);
            return values;
        }

        private GenericBinaryTreeNode<TKey, TValue> AddBalanced(TKey[] keys, TValue[] values, int start, int end)
        {
            //TODO #7:  Given an array of keys and an array of values, this method must:
            //          - Create a new tree node with the key/values in the center of the [start,end] section of the arrays
            //          - Recursive call to AddBalanced with the elements on the left of center [start,center-1]. Add the result to the new node as LeftNode
            //          - Recursive call to AddBalanced with the elements on the right of center [center+1,end]. Add the result to the new node as RightNode

            return null;
        }

        public void Balance()
        {
            if (RootNode == null)
                return;
            TKey[] keys = Keys();
            TValue[] values = Values();

            RootNode = AddBalanced(keys, values, 0, keys.Length - 1);
        }
    }
}