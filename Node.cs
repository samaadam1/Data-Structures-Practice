public abstract class Node<T> where T : Node<T> // using generics
{
    public int value { get; set; }
    public T? next { get; set; }


    protected Node(int value)  // only subclasses can call this constructor
    {
        this.value = value;
        this.next = null;

    }

}