
using System;

class Program
{
    static void Main()
    {
        try
        {
            TestLinkedList();
            // TestDoublyLinkedList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void TestLinkedList()
    {
        Console.WriteLine("Testing Singly Linked List:");
        LinkedList list = new LinkedList();
        list.AddLast(3);
        list.AddLast(5);
        list.AddFirst(1);
        list.print();

        list.InsertAt(1, 2);
        list.print();

        list.Remove(3);
        list.print();

        try
        {
            list.Get(5);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        list.print();
        int value = list.Get(1);
        Console.WriteLine("Value at index 1: " + value);
        int index = list.IndexOf(5);
        Console.WriteLine("Index of 5: " + index);
        bool contains = list.Contains(5);
        Console.WriteLine("Contains 5: " + contains);
        list.RemoveFirst();
        list.print();
        list.RemoveLast();
        list.print();
    }

    public static void TestDoublyLinkedList()
    {
        Console.WriteLine("Testing Doubly Linked List:");
        Doubly_LinkedList list = new Doubly_LinkedList();

        list.AddLast(3);
        list.AddLast(5);
        list.AddFirst(1);
        list.print();

        list.InsertAt(1, 2);
        list.print();

        list.Remove(3);
        list.print();

        try
        {
            list.Get(5);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        list.print();
        list.printBackward();
    }
}