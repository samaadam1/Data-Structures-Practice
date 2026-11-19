public class DoublyNode : Node<DoublyNode>
{
    public DoublyNode? prev { get; set; }
    public DoublyNode(int value) : base(value)
    {
        this.prev = null;
    }

}