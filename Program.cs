
using System;

class Program
{
    static void Main()
    {
        try
        {
            TestLinkedList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void TestLinkedList()
    {
        LinkedList list = new LinkedList();
        list.AddLast(3);
        list.AddLast(5);
        list.AddFirst(1);
        list.print();

        list.InsertAt(1, 2);
        list.print();

        list.Remove(3);
        list.print();

        list.Get(5);
        list.print();

    }
}