using System;
/***
    AVL Tree:
    Insert, Delete, Search, PrintTree, TraverseInOrder
 */
namespace AVLTree
{
    class AVLTree
    {
        private Node root;
        static bool taller;
        static bool shorter;

        public AVLTree()
        {
            root = null;
        }

        private bool IsEmpty()
        {
            return root == null;
        }

        public Node Search(int value)
        {
            if (root != null)
            {
                return root.Search(value);
            }
            return null;
        }

        public void Insert(int x)
        {
            root = Insert(root, x);
        }

        private Node Insert(Node p, int x)
        {

            // if root/leftChild/rightChild equals null - we found place for insertion
            if (p == null)
            {
                p = new Node(x);
                taller = true;
            }
            else if (x < p.data)
            {
                p.leftChild = Insert(p.leftChild, x);
                if (taller)
                {
                    p = InsertionLeftSubtreeCheck(p);
                }
            }
            else if (x > p.data)
            {
                p.rightChild = Insert(p.rightChild, x);
                if (taller)
                {
                    p = InsertionRightSubtreeCheck(p);
                }
            }
            else
            {
                //key already resent in the tree
                taller = false;
            }
            return p;
        }

        private Node InsertionLeftSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0: // Case L_1: was balanced
                    p.balance = 1;
                    break;
                case -1: // Case L_2: was right heavy
                    p.balance = 0; //now balanced
                    taller = false;
                    break;
                case 1: // Case L_3: was left heavy
                    p = InsertionLeftBalance(p); // left balancing
                    taller = false;
                    break;
            }
            return p;
        }

        private Node InsertionRightSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0: // Case R_1: was balanced
                    p.balance = -1; //now right heavy
                    break;
                case 1: // Case R_2: was left heavy
                    p.balance = 0; //now balanced
                    taller = false;
                    break;
                case -1: // Case R_3: right heavy
                    p = InsertionRightBalance(p); // right balancing
                    taller = false;
                    break;
            }
            return p;
        }

        private Node InsertionLeftBalance(Node p)
        {
            Node a, b;
            a = p.leftChild;
            if (a.balance == 1)
            { // Case L_3A: insertion in AL
                p.balance = 0;
                a.balance = 0;
                p = RotateRight(p);
            }
            else
            { // Case L_3B: insertion in AR
                b = a.rightChild;
                switch (b.balance)
                {
                    case 1: // Case L_3B2: insertion in BL
                        p.balance = -1;
                        a.balance = 0;
                        break;
                    case -1: // Case L_3B2: insertion in BR
                        p.balance = 0;
                        a.balance = 1;
                        break;
                    case 0: // Case L_3B2: B is newly inserted node
                        p.balance = 0;
                        a.balance = 0;
                        break;
                }
                b.balance = 0;
                p.leftChild = RotateLeft(a);
                p = RotateRight(p);
            }
            return p;
        }

        private Node InsertionRightBalance(Node p)
        {
            Node a, b;
            a = p.rightChild;
            if (a.balance == -1)
            { // Case R_3A: insertion in AR
                p.balance = 0;
                a.balance = 0;
                p = RotateLeft(p);
            }
            else
            { // Case R_3B: insertion in AL
                b = a.leftChild;
                switch (b.balance)
                {
                    case -1: // Case R_3B2: Insertion in BR
                        p.balance = 1;
                        a.balance = 0;
                        break;
                    case 1: // Case R_3B2: Insertion in BL
                        p.balance = 0;
                        a.balance = -1;
                        break;
                    case 0: // Case R_3B2: B is newly inserted node
                        p.balance = 0;
                        a.balance = 0;
                        break;

                }
                b.balance = 0;
                p.rightChild = RotateRight(a);
                p = RotateLeft(p);
            }
            return p;
        }

        public void Delete(int x)
        {
            root = Delete(root, x);
        }

        private Node Delete(Node p, int x)
        {
            Node ch, s;
            if (p == null)
            {
                // Value x is not found in the tree
                shorter = false;
                return p;
            }
            // delete from left subtree
            if (x < p.data)
            {
                p.leftChild = Delete(p.leftChild, x);
                if (shorter)
                {
                    p = DeletionLeftSubtreeCheck(p);
                }
            }
            // delete from right subtree
            else if (x > p.data)
            {
                p.rightChild = Delete(p.rightChild, x);
                if (shorter)
                {
                    p = DeletionRightSubtreeCheck(p);
                }
            }
            else
            {
                // key to be deleted is found
                if (p.leftChild != null && p.rightChild != null)
                { // 2 children
                    s = p.rightChild;
                    while (s.leftChild != null)
                        s = s.leftChild;
                    p.data = s.data;
                    p.rightChild = Delete(p.rightChild, p.data);
                    if (shorter)
                    {
                        p = DeletionRightSubtreeCheck(p);
                    }
                }
                else
                { // 1 child or no children
                    if (p.leftChild != null)
                    {
                        ch = p.leftChild;
                    }
                    else
                    {
                        ch = p.rightChild;
                    }
                    p = ch;
                    shorter = true;
                }
            }
            return p;
        }

        private Node DeletionLeftSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0: // Case L_1: was balanced
                    p.balance = -1; // now right heavy
                    shorter = false;
                    break;
                case 1: // Case L_2: was left heavy
                    p.balance = 0; // now balanced
                    break;
                case -1: // Case L_3: was right heavy
                    p = DeletionRightBalance(p); // Right Balancing
                    break;
            }
            return p;
        }

        private Node DeletionRightSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0: // Case R_1: was balanced
                    p.balance = 1; // now left heavy
                    shorter = false;
                    break;
                case -1: // Case R_2: was right heavy
                    p.balance = 0; // now balanced
                    break;
                case 1: // Case R_3: was left heavy
                    p = DeletionLeftBalance(p); // Left Balancing
                    break;
            }
            return p;
        }

        private Node DeletionRightBalance(Node p)
        {
            Node a, b;
            a = p.rightChild;
            if (a.balance == 0)
            { // Case L_3A
                a.balance = 1;
                shorter = false;
                p = RotateLeft(p);
            }
            else if (a.balance == -1)
            { // Case L_3B
                p.balance = 0;
                a.balance = 0;
                p = RotateLeft(p);
            }
            else
            { // Case L_3C
                b = a.leftChild;
                switch (b.balance)
                {
                    case 0: // Case L_3C1
                        p.balance = 0;
                        a.balance = 0;
                        break;
                    case 1: // Case L_3C2
                        p.balance = 0;
                        a.balance = -1;
                        break;
                    case -1: // Case L_3C3
                        p.balance = 1;
                        a.balance = 0;
                        break;
                }
                b.balance = 0;
                p.rightChild = RotateRight(a);
                p = RotateLeft(p);
            }
            return p;
        }

        private Node DeletionLeftBalance(Node p)
        {
            Node a, b;
            a = p.leftChild;
            if (a.balance == 0)
            { // Case R_3A
                a.balance = -1;
                shorter = false;
                p = RotateRight(p);
            }
            else if (a.balance == 1)
            { // Case R_3B
                p.balance = 0;
                a.balance = 0;
                p = RotateRight(p);
            }
            else
            { // Case R_3C
                b = a.rightChild;
                switch (b.balance)
                {
                    case 0: // Case R_3C1
                        p.balance = 0;
                        a.balance = 0;
                        break;
                    case -1: // Case R_3C2
                        p.balance = 0;
                        a.balance = 1;
                        break;
                    case 1: // Case R_3C3
                        p.balance = -1;
                        a.balance = 0;
                        break;
                }
                b.balance = 0;
                p.leftChild = RotateLeft(a);
                p = RotateRight(p);
            }
            return p;
        }

        private Node RotateRight(Node p)
        {
            Node a = p.leftChild;
            p.leftChild = a.rightChild;
            a.rightChild = p;
            return a;
        }

        private Node RotateLeft(Node p)
        {
            Node a = p.rightChild;
            p.rightChild = a.leftChild;
            a.leftChild = p;
            return a;
        }


        public void PrintTree()
        {
            PrintTree(root, 0);
            Console.WriteLine();
        }

        private void PrintTree(Node p, int level)
        {
            int i;
            if (p == null)
            {
                return;
            }
            PrintTree(p.rightChild, level + 1);
            Console.WriteLine();
            for (i = 0; i < level; i++)
            {
                Console.Write("   ");
            }
            Console.Write(p.data);
            PrintTree(p.leftChild, level + 1);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(root);
            Console.WriteLine();
        }

        private void TraverseInOrder(Node p)
        {
            if (p == null)
            {
                return;
            }
            TraverseInOrder(p.leftChild);
            Console.Write(p.data + " ");
            TraverseInOrder(p.rightChild);
        }
    }
}
