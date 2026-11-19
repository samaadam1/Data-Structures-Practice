public class Doubly_LinkedList
{
    private DoublyNode? head;
    private DoublyNode? tail;

    public Doubly_LinkedList()
    {
        this.head = null;
        this.tail = null;
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
            head = new DoublyNode(value);
            tail = head;
        }
        else
        {
            DoublyNode firstNode = new DoublyNode(value);
            head.prev = firstNode;
            firstNode.next = head;
            head = firstNode;
        }
    }

    public void AddLast(int value)
    {
        Console.WriteLine("AddLast " + value);
        DoublyNode lastNode = new DoublyNode(value);

        if (isEmpty())
        {
            head = lastNode;
            tail = head;
        }
        else
        { // current <--> lastNode(tail) <--> null
            DoublyNode current = tail;
            current.next = lastNode;
            lastNode.prev = current;
            lastNode.next = null;
            tail = lastNode;
        }

    }

    public void InsertAt(int index, int value)
    {
        Console.WriteLine("InsertAt (" + index + "," + value + ")");
        int count = Count();
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException("Index cannot be negative");
        }
        else if (index == 0)
        {
            AddFirst(value);
        }
        else if (index == count)
        {
            AddLast(value);
        }
        else if (index > count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range");
        }
        else
        {
            if (index < (count / 2))
            {
                DoublyNode current = head;
                for (int i = 0; i < index - 1; i++) // insert after current (index - 1)
                {
                    current = current.next;
                }
                // current <--> newNode <--> current.next
                DoublyNode newNode = new DoublyNode(value);
                newNode.next = current.next;
                newNode.prev = current;
                current.next = newNode;
                if (newNode.next != null)
                {
                    newNode.next.prev = newNode;
                }

            }
            else
            {
                DoublyNode current = tail;
                for (int i = count - 1; i > index; i--) // current i is > index, because we want to insert before it
                {
                    current = current.prev;
                }
                // current.prev <--> newNode <--> current
                DoublyNode newNode = new DoublyNode(value);
                newNode.prev = current.prev;
                newNode.next = current;
                current.prev = newNode;
                if (newNode.prev != null)
                {
                    newNode.prev.next = newNode;
                }
            }
        }

    }

    public void RemoveFirst()
    {
        Console.WriteLine("RemoveFirst");
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (head == tail) // list has only one node
        {
            Clear();
        }
        else
        {
            DoublyNode current = head;
            head = current.next;
            head.prev = null;
            current.next = null;
            Console.Write("true ");
        }
    }

    public void RemoveLast()
    {
        Console.WriteLine("RemoveLast");
        if (isEmpty()) // list is empty
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (head == tail) // list has only one node
        {
            Clear();
        }
        else
        {
            DoublyNode current = tail;
            tail = current.prev;
            tail.next = null;
            current.prev = null;
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
        else if (tail.value == value)
        {
            RemoveLast();
        }
        // else if (!Contains(value))
        // {
        //     throw new InvalidOperationException("Value not found in list");
        // }
        else
        {
            DoublyNode current = head;
            while (current.next != null)
            {
                if (current.next.value == value)
                {
                    // current <--> current.next (removed) 1 <--> current.next.next 2
                    // current <--> current.next.next 1 
                    current.next = current.next.next;
                    current.next.prev = current;
                    return;
                }
                current = current.next;
            }
            throw new InvalidOperationException("Value not found in list");
        }
    }

    public int Get(int index)
    {
        int count;
        Console.WriteLine("Get " + index);
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (index < 0)
        {
            throw new ArgumentOutOfRangeException("Index " + index + " cannot be negative");
        }
        else if (index == 0)
        {
            return head.value;

        }
        else if (index == (count = Count()) - 1)
        {
            return tail.value;
        }
        else if (index >= count)
        {
            throw new ArgumentOutOfRangeException("Index " + index + " is out of range");
        }
        else if (index < count / 2)
        {
            DoublyNode current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.value;
        }
        else
        {
            DoublyNode current = tail;
            for (int i = count - 1; i > index; i--)
            {
                current = current.prev;
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
        // else if (tail.value == value)  // in duplicates it will return the tail index, but we want the first index of the value
        // {
        //     return Count() - 1;
        // }
        // else if (!Contains(value))
        // {
        //     throw new InvalidOperationException("Value not found in list");
        // }
        else
        {
            int index = 0;
            DoublyNode current;
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
            DoublyNode current;
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
        int count = 0;
        DoublyNode current;
        for (current = head; current != null; current = current.next)
        {
            count++;
        }
        return count;
    }

    public void Clear()
    {
        head = null;
        tail = head;
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
            DoublyNode current;
            for (current = head; current != null; current = current.next)
            {
                if (current == tail)
                {
                    Console.Write(current.value);
                }
                else
                {
                    Console.Write(current.value + " <-> ");
                }
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }
    }

    public void printBackward()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        else
        {
            Console.Write("--> [");
            DoublyNode current;
            for (current = tail; current != null; current = current.prev)
            {
                if (current == tail)
                {
                    Console.Write(current.value);
                }
                else
                {
                    Console.Write(" <-> " + current.value);
                }
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }
    }
}
