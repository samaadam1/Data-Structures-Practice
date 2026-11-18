public class DoublyNode: Node<DoublyNode> 
{    public DoublyNode? previous { get; set; }
    public DoublyNode(int value) : base(value)
    {
        this.previous = null;
    }

}