using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnbalancedTree
{
    class TreeNode
    {
        public int Data;
        public TreeNode LeftChild;
        public TreeNode RightChild;

        public TreeNode(int data)
        {
            this.Data = data;
        }

        public TreeNode Get(int value)
        {
            if (value == Data)
            {
                return this;
            }

            if (value < Data)
            {
                if (LeftChild != null)
                {
                    return LeftChild.Get(value);
                }
            }
            else
            {
                if (RightChild != null)
                {
                    return RightChild.Get(value);
                }
            }
            return null;
        }

        public int Min()
        {
            if (LeftChild == null)
            {
                return Data;
            }
            else
            {
                return LeftChild.Min();
            }
        }

        public int Max()
        {
            if (RightChild == null)
            {
                return Data;
            }
            else
            {
                return RightChild.Max();
            }
        }

        public void Insert(int value)
        {
            if (value == Data)
            {
                return;
            }
            if (value < Data)
            {
                if (LeftChild == null)
                {
                    LeftChild = new TreeNode(value);
                }
                else
                {
                    LeftChild.Insert(value);
                }
            }
            else
            {
                if (RightChild == null)
                {
                    RightChild = new TreeNode(value);
                }
                else
                {
                    RightChild.Insert(value);
                }
            }
        }

        // In-Order traversal
        public void TraverseInOrder()
        {
            if (LeftChild != null)
            {
                LeftChild.TraverseInOrder();
            }
            Console.Write(Data + " ");
            if (RightChild != null)
            {
                RightChild.TraverseInOrder();
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
