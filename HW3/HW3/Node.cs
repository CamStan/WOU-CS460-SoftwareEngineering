namespace HW3
{
    /// <summary>
    /// A simple singly linked node class.
    /// 
    /// This code is referenced from a similar Java class written by Scot Morse.
    /// </summary>
    class Node
    {
        object data; // Contents of this node
        Node nextNode; // Reference to next Node in the chain

        /// <summary>
        /// Constructor to create a new Node to be added to the stack chain.
        /// </summary>
        /// <param name="data">The contents to be held within this Node</param>
        /// <param name="nextNode">Node that this Node is being placed on top
        /// of in the chain.</param>
        public Node(object data, Node nextNode)
        {
            this.data = data;
            this.nextNode = nextNode;
        }
        
        /// <summary>
        /// Property to get and set the data contents of this Node.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Property to get and set the Node that this Node is being placed
        /// on top of in the chain.
        /// </summary>
        public Node NextNode { get; set; }
    }
}
