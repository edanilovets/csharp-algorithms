using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
    Unbalanced Tree
    Min, Max, Insert, Delete, Get, PrintTree, TraverseInOrder
*/
namespace UnbalancedTree
{
    class UnbalancedTree
    {
        private TreeNode Root;

        public TreeNode Get(int value)
        {
            if (Root != null)
            {
                return Root.Get(value);
            }
            return null;
        }

        public int Min()
        {
            if (Root == null)
            {
                return Int32.MinValue;
            }
            else
            {
                return Root.Min();
            }
        }

        public int Max()
        {
            if (Root == null)
            {
                return Int32.MaxValue;
            }
            else
            {
                return Root.Max();
            }
        }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
            }
            else
            {
                Root.Insert(value);
            }
        }

        public void Delete(int value)
        {
            Root = Delete(Root, value);
        }

        private TreeNode Delete(TreeNode subtreeRoot, int value)
        {
            if (subtreeRoot == null)
            {
                return null;
            }
            if (value < subtreeRoot.Data)
            {
                subtreeRoot.LeftChild = Delete(subtreeRoot.LeftChild, value);
            }
            else if (value > subtreeRoot.Data)
            {
                subtreeRoot.RightChild = Delete(subtreeRoot.RightChild, value);
            }
            else
            {
                // cases 1 and 2: node to delete has 0 or 1 child(ren)
                if (subtreeRoot.LeftChild == null)
                {
                    return subtreeRoot.RightChild;
                }
                else if (subtreeRoot.RightChild == null)
                {
                    return subtreeRoot.LeftChild;
                }

                //case 3: node to delete has 2 children

                // replace the value in subtreeRoot node with the smallest value from the right subtree
                subtreeRoot.Data = subtreeRoot.RightChild.Min();
                // delete the node that has the smallest value in the right subtree
                subtreeRoot.RightChild = Delete(subtreeRoot.RightChild, subtreeRoot.Data);
            }
            return subtreeRoot;
        }

        public void PrintTree()
        {
            PrintTree(Root, 0);
            Console.WriteLine();
        }

        private void PrintTree(TreeNode p, int level)
        {
            int i;
            if (p == null)
            {
                return;
            }
            PrintTree(p.RightChild, level + 1);
            Console.WriteLine();
            for (i = 0; i < level; i++)
            {
                Console.Write("   ");
            }
            Console.Write(p.Data);
            PrintTree(p.LeftChild, level + 1);
        }

        public void TraverseInOrder()
        {
            if (Root != null)
            {
                Root.TraverseInOrder();
            }
            else
            {
                Console.WriteLine("The tree is empty");
            }
        }
    }
}
