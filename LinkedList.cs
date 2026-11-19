public class LinkedList
{
    private SinglyNode? head;

    public LinkedList()
    {
        head = null;
    }

    public bool isEmpty()
    {
        return head == null; // if head is null, the list is empty
    }

    public void AddFirst(int value)
    {
        Console.WriteLine("AddFirst " + value);
        if (isEmpty())
        {
            head = new SinglyNode(value);
            head.next = null;
        }
        else
        {
            SinglyNode firstNode = new SinglyNode(value);
            firstNode.next = head;
            head = firstNode;
        }
    }

    public void AddLast(int value)
    {
        Console.WriteLine("AddLast " + value);
        SinglyNode lastNode = new SinglyNode(value);
        if (isEmpty())
        {
            head = lastNode;
            lastNode.next = null;
        }
        else
        {
            SinglyNode current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = lastNode;
            lastNode.next = null;
        }

    }

    public void InsertAt(int index, int value)
    {
        Console.WriteLine("InsertAt (" + index + "," + value + ")");
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException("Index cannot be negative");
        }
        else if (index == 0)
        {
            AddFirst(value);
        }
        else
        {
            SinglyNode current = head;
            for (int i = 0; i < index - 1; i++)
            {
                if (current.next == null && i < index - 1)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
                current = current.next;

            }
            // at index - 1 , current is the node before the index where we want to insert
            SinglyNode newNode = new SinglyNode(value);

            // current -> newNode -> current.next
            newNode.next = current.next;
            current.next = newNode;
        }
    }

    public void RemoveFirst()
    {
        Console.WriteLine("RemoveFirst");
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (head.next == null) // list has only one node
        {
            Clear();
        }
        else
        {
            // we dont need to worry about deleting the node, because C# has garbage collection
            head = head.next;
        }
    }

    public void RemoveLast()
    {
        Console.WriteLine("RemoveLast");
        if (isEmpty()) // list is empty
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (head.next == null) // list has only one node
        {
            Clear();
        }
        else
        {
            SinglyNode current = head;
            while (current.next.next != null) // point to the second last node
            {
                current = current.next;
            }
            current.next = null;
        }
    }

    public void Remove(int value)
    {
        Console.WriteLine("Remove " + value);
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (head.value == value)
        {
            RemoveFirst();
        }
        // else if (!Contains(value))
        // {
        //     throw new InvalidOperationException("Value not found in list");
        // }
        else
        {
            SinglyNode current = head;
            while (current.next != null)
            {
                if (current.next.value == value)
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
            throw new InvalidOperationException("Value not found in list");
        }
    }

    public int Get(int index)
    {
        Console.WriteLine("Get " + index);
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (index < 0)
        {
            throw new ArgumentOutOfRangeException("Index " + index + " cannot be negative");
        }
        else
        {
            SinglyNode current = head;
            for (int i = 0; i < index; i++)
            {
                if (current.next == null && i < index - 1)
                {
                    throw new ArgumentOutOfRangeException("Index " + index + " is out of range");
                }
                current = current.next;
            }
            return current.value;

        }
    }

    public int IndexOf(int value)
    {
        Console.WriteLine("Index of " + value);
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (head.value == value)
        {
            return 0;
        }
        // else if (!Contains(value))
        // {
        //     throw new InvalidOperationException("Value not found in list");
        // }
        else
        {
            int index = 0;
            SinglyNode current;
            for (current = head; current != null; current = current.next)
            {
                if (current.value == value)
                {
                    return index;
                }
                index++;
            }
            throw new InvalidOperationException("Value not found in list");

        }
    }


    public bool Contains(int value)
    {
        Console.WriteLine("Contains " + value);
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else
        {
            SinglyNode current;
            for (current = head; current != null; current = current.next)
            {
                if (current.value == value)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public int Count()
    {
        Console.WriteLine("Count ");
        int count = 0;
        SinglyNode current;
        for (current = head; current != null; current = current.next)
        {
            count++;
        }
        return count;
    }

    public void Clear()
    {
        head = null;
    }

    public void print()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else
        {
            Console.Write("--> [");
            SinglyNode current;
            for (current = head; current != null; current = current.next)
            {
                if (current.next == null)
                {
                    Console.Write(current.value);
                }
                else
                {
                    Console.Write(current.value + " -> ");
                }
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }
    }


}


