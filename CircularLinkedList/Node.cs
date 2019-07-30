using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            this.Value = value;
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
