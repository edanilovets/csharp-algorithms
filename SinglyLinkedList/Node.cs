using System;

namespace SinglyLinkedList
{
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Value = data;
        }

        public override bool Equals(object obj)
        {
            var node = obj as Node;
            return node != null &&
                   Value == node.Value;
        }

        public override int GetHashCode()
        {
            return -1584136870 + Value.GetHashCode();
        }

        public override String ToString()
        {
            return "{" + Value + "}";
        }

        

    }
}
