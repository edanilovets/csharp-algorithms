using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
    class Node
    {
        public int[] key;
        public Node[] child;
        public int numKeys;

        public Node(int size)
        {
            numKeys = 0;
            key = new int[size];
            child = new Node[size];
        }
    }
}
