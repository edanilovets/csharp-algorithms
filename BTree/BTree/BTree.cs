using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
    BTree of Integers:
    Insert, Delete, Search, PrintTree, TraverseInOrder
*/
namespace BTree
{
    class BTree
    {
        private static readonly int M = 3;
        private static readonly int MAX = M - 1;
        private static readonly int MIN = (int)Math.Ceiling((double)M/2) - 1;

        private Node root;

        public BTree()
        {
            root = null;
        }

        public bool Search(int x)
        {
            if (Search(x, root) == null)
            {
                return false;
            }
            return true;
        }

        private Node Search(int x, Node p)
        {
            if (p == null)
            { // key x is not present in the tree
                return null;
            }

            int n = 0;
            if (SearchNode(x, p, ref n) == true) // key x found in node p
                return p;

            return Search(x, p.child[n]);
        }

        private bool SearchNode(int x, Node p, ref int n)
        {
            if (x < p.key[1])
            { // key x is less than leftmost key
                n = 0;
                return false;
            }
            n = p.numKeys;
            while ((x < p.key[n]) && n > 1)
            {
                n--;
            }
            return x == p.key[n];
        }

        public void Insert(int x)
        {

            int iKey = 0;
            Node iKeyRChild = null;

            // method will return true if root node has to be split
            bool taller = Insert(x, root, ref iKey, ref iKeyRChild);

            if (taller)
            { // height increased by one, new node has to be created
                Node temp = new Node(M);
                temp.child[0] = root;
                root = temp;

                root.numKeys = 1;
                root.key[1] = iKey;
                root.child[1] = iKeyRChild;
            }
        }

        private bool Insert(int x, Node p, ref int iKey, ref Node iKeyRChild)
        {
            if (p == null) // First Base: key not found
            {
                iKey = x;
                iKeyRChild = null;
                return true;
            }
            int n = 0;
            if (SearchNode(x, p, ref n) == true) // Second Base: key found
            {
                Console.WriteLine("Key already present in the tree");
                return false; // No need to insert the key
            }
            bool flag = Insert(x, p.child[n], ref iKey, ref iKeyRChild);

            if (flag == true)
            {
                if (p.numKeys < MAX)
                {
                    InsertByShift(p, n, iKey, iKeyRChild);
                    return false; // Insertion over
                }
                else
                {
                    Split(p, n, ref iKey, ref iKeyRChild);
                    return true; // Insertion not over: Median key yet to be inserted
                }
            }
            return false;
        }

        private void InsertByShift(Node p, int n, int iKey, Node iKeyRChild)
        {
            for (int i = p.numKeys; i > n; i--)
            {
                p.key[i + 1] = p.key[i];
                p.child[i + 1] = p.child[i];
            }
            p.key[n + 1] = iKey;
            p.child[n + 1] = iKeyRChild;
            p.numKeys++;
        }

        private void Split(Node p, int n, ref int iKey, ref Node iKeyRChild)
        {
            int i, j;
            int lastKey;
            Node lastChild;

            if (n == MAX)
            {
                lastKey = iKey;
                lastChild = iKeyRChild;
            }
            else
            {
                lastKey = p.key[MAX];
                lastChild = p.child[MAX];
                for (i = p.numKeys - 1; i > n; i--)
                {
                    p.key[i + 1] = p.key[i];
                    p.child[i + 1] = p.child[i];
                }
                p.key[n + 1] = iKey;
                p.child[n + 1] = iKeyRChild;
            }
            int d = (M + 1) / 2;
            int medianKey = p.key[d];
            Node newNode = new Node(M);
            newNode.numKeys = M - d;
            newNode.child[0] = p.child[d];
            for (i = 1, j = d + 1; j <= MAX; i++, j++) {
                newNode.key[i] = p.key[j];
                newNode.child[i] = p.child[j];
            }
            newNode.key[i] = lastKey;
            newNode.child[i] = lastChild;
            p.numKeys = d - 1;
            iKey = medianKey;
            iKeyRChild = newNode;
        }

        public void Delete(int x)
        {
            if (root == null)
            {
                return; // Tree is empty
            }
            Delete(x, root);
            if (root != null && root.numKeys == 0) // Height of tree decreases by 1
            {
                root = root.child[0];
            }
        }

        private void Delete(int x, Node p)
        {
            int n = 0;
            if (SearchNode(x, p, ref n) == true) // Key x found in Node p
            {
                if (p.child[n] == null) // Node p is a leaf node
                {
                    DeleteByShift(p, n);
                    return;
                }
                else // Node p is not a leaf node
                {
                    Node s = p.child[n];
                    while (s.child[0] != null)
                    {
                        s = s.child[0];
                    }
                    p.key[n] = s.key[1];
                    Delete(s.key[1], p.child[n]);
                }
            }
            // Key x is not found in node p
            else
            {
                if (p.child[n] == null) // p is a leaf node
                {
                    // value x not present in the tree
                    return;
                }
                else // p is not a leaf node
                {
                    Delete(x, p.child[n]);
                }
            }

            if (p.child[n].numKeys < MIN)
            {
                Restore(p, n);
            }
        }

        private void DeleteByShift(Node p, int n)
        {
            for (int i=n+1;i<=p.numKeys;i++)
            {
                p.key[i - 1] = p.key[i];
                p.child[i - 1] = p.child[i];
            }
            p.numKeys--;
        }

        // Called when p.child[n] becomes underflow
        private void Restore(Node p, int n)
        {
            if (n!=0 && p.child[n-1].numKeys > MIN)
            {
                BorrowLeft(p, n);
            }
            else if (n!=p.numKeys && p.child[n+1].numKeys > MIN)
            {
                BorrowRight(p, n);
            }
            else
            {
                if (n!=0) // if there is a left siebling
                {
                    Combine(p, n); // combine with left siebling
                }
                else
                {
                    Combine(p, n + 1); // combine with right siebling
                }
            }
        }

        private void BorrowLeft(Node p, int n)
        {
            Node underflowNode = p.child[n];
            Node leftSiebling = p.child[n - 1];
            underflowNode.numKeys++;
            
            // Shift all the keys and children in underflowNode one position right
            for (int i = underflowNode.numKeys; i > 0; i--)
            {
                underflowNode.key[i + 1] = underflowNode.key[i];
                underflowNode.child[i + 1] = underflowNode.child[i];
            }
            
            underflowNode.child[1] = underflowNode.child[0];
            // Move the separator key from parent node p to underflow node
            underflowNode.key[1] = p.key[n];
            // Move the rightmost key of node leftSiebing to the parent node p
            p.key[n] = leftSiebling.key[leftSiebling.numKeys];
            // Rightmost child of leftSiebling becomes leftmost child of underflow node
            underflowNode.child[0] = leftSiebling.child[leftSiebling.numKeys];
            leftSiebling.numKeys--;
        }

        private void BorrowRight(Node p, int n)
        {
            Node underflowNode = p.child[n];
            Node rightSiebling = p.child[n + 1];
            // Move separator key from parent node p to underflow node
            underflowNode.numKeys++;
            underflowNode.key[underflowNode.numKeys] = p.key[n + 1];
            // Leftmostchild of right siebling becomes the rightmost child of underflow node
            underflowNode.child[underflowNode.numKeys] = rightSiebling.child[0];
            rightSiebling.numKeys--;
            // Move the leftmost key from right siebling to parent node p
            p.key[n + 1] = rightSiebling.key[1];

            // Shift all the keys and children of right siebling on position left
            rightSiebling.child[0] = rightSiebling.child[1];
            for (int i = 1; i <= rightSiebling.numKeys; i++)
            {
                rightSiebling.key[i] = rightSiebling.key[i + 1];
                rightSiebling.child[i] = rightSiebling.child[i + 1];
            }
        }

        private void Combine(Node p, int m)
        {
            Node nodeA = p.child[m - 1];
            Node nodeB = p.child[m];
            nodeA.numKeys++;
            // Move the separator key from the parent node p to nodeA
            nodeA.key[nodeA.numKeys] = p.key[m];
            // Shift the keys and children that are after separator key in node p one position left
            int i;
            for (i=m; i < p.numKeys; i++)
            {
                p.key[i] = p.key[i + 1];
                p.child[i] = p.child[i + 1];
            }
            p.numKeys--;
            nodeA.child[nodeA.numKeys] = nodeB.child[0];
            for (i=1; i<=nodeB.numKeys;i++)
            {
                nodeA.numKeys++;
                nodeA.key[nodeA.numKeys] = nodeB.key[i];
                nodeA.child[nodeA.numKeys] = nodeB.child[i];
            }
        }


        public void TraverseInOrder()
        {
            TraverseInOrder(root);
        }

        private void TraverseInOrder(Node p)
        {
            if (p == null) return;
            int i;
            for (i = 0; i < p.numKeys; i++)
            {
                TraverseInOrder(p.child[i]);
                Console.Write(p.key[i + 1] + " ");
            }
            TraverseInOrder(p.child[i]);
        }

        public void PrintTree()
        {
            PrintTree(root, 0);
        }

        private void PrintTree(Node p, int blanks)
        {
            if (p != null)
            {
                int i;
                for (i = 1; i <= blanks; i++)
                    Console.Write(" ");
                for (i = 1; i <= p.numKeys; i++)
                    Console.Write(p.key[i] + " ");
                Console.Write("\n");
                for (i = 0; i <= p.numKeys; i++)
                {
                    PrintTree(p.child[i], blanks + 10);
                }
            }
        }
    }
}
