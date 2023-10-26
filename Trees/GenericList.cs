public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;
    public ListNode<T> Prev = null;

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class GenericList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int numElements = 0;

    public string AsString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        return numElements;
    }

    public void Add(T value)
    {
        ListNode<T> newNode = new ListNode<T>(value);
        ListNode<T> node = Last;

        if (node != null)
        {
            newNode.Prev = Last;
            Last.Next = newNode;
            Last = newNode;
        }
        else
        {
            Last = newNode;
            First = newNode;
            newNode.Prev = null;
        }
        numElements++;
    }

    public ListNode<T> FindNode(int index)
    {
        int i = 0;

        if (index == numElements - 1)
            return Last;

        if (index == 0)
            return First;

        ListNode<T> node = First;

        while (node != null && i < index)
        {
            i++;
            node = node.Next;
        }

        return node;
    }

    public T Get(int index)
    {
        ListNode<T> node = FindNode(index);

        if (node != null)
        {
            return node.Value;
        }
        return default(T);
    }

    public T Remove(int index)
    {
        ListNode<T> node = FindNode(index);

        if (node != null)
        {
            if (node.Prev != null)
                node.Prev.Next = node.Next;

            if (Last == node)
                Last = node.Prev;

            if (First == node)
                First = node.Next;
            numElements--;

            return node.Value;
        }

        return default(T);

    }

    public void Clear()
    {
        First = null;
        Last = null;
        numElements = 0;
    }
}