using System;
/**
 Singly Linked List 
    Methods:
    GetSize, AddFirst, Add
    RemoveFirst, Remove, Insert, Replace
    Sum, IndexOf, IsEmpty, PrintList
     */

namespace SinglyLinkedList
{
    class SinglyLinkedList
    {
        private Node Head { get; set; }
        private int Size { get; set; }

        public SinglyLinkedList()
        {
            this.Head = null;
            this.Size = 0;
        }

        public int GetSize()
        {
            return Size;
        }

        // add node in the beginning of the list
        public void AddFirst(int value)
        {
            Node node = new Node(value);
            node.Next = Head;
            Head = node;
            Size++;
        }

        // add node at the end of the list
        public void Add(int value)
        {
            Node node = new Node(value);
            if (IsEmpty())
            {
                Head = node;
                Size++;
                return;
            }
            Node currentNode = Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = node;
            node.Next = null;
            Size++;
        }

        // remove first node(head) of the list
        public Node RemoveFirst()
        {
            if (IsEmpty())
            {
                return null;
            }
            Node removedNode = Head;
            Head = Head.Next;
            Size--;
            return removedNode;
        }

        // remove node by it's value
        public void Remove(int value)
        {

            if (Size == 0)
            {
                Console.WriteLine("Nothing to remove, list is empty.");
                return;
            }

            Node prevNode = null;
            Node currentNode = Head;

            while (currentNode != null)
            {

                if (currentNode.Value == value)
                {
                    if (prevNode == null)
                    {
                        Head = currentNode.Next;
                        Size--;
                        break;
                    }
                    else
                    {
                        prevNode.Next = currentNode.Next;
                        Size--;
                        break;
                    }
                }
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        //insert item in list in position
        public void Insert(int position, int value)
        {
            Node node = new Node(value);
            Node currentNode = Head;

            if ((Head != null) && (position <= Size))
            {
                if (position == 0)
                {
                    node.Next = Head;
                    Head = node;
                    Size++;
                }
                else
                {
                    for (int i = 1; i < position; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    node.Next = currentNode.Next;
                    currentNode.Next = node;
                    Size++;
                }

            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        // replace node value in position
        public void Replace(int position, int value)
        {
            Node node = new Node(value);
            Node currentNode = Head;

            if ((Head != null) && (position < Size))
            {
                if (position == 0)
                {
                    node.Next = Head.Next;
                    Head = node;
                }
                else
                {
                    for (int i = 0; i < position; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    currentNode.Value = node.Value;
                }

            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        // sum of list elements
        public int Sum()
        {
            Node currentNode = Head;
            int sum = 0;
            while (currentNode != null)
            {
                sum += currentNode.Value;
                currentNode = currentNode.Next;
            }
            return sum;
        }

        // indexOf by value (first)
        public int IndexOf(int value)
        {
            Node currentNode = Head;
            for (int i = 0; i < Size; i++)
            {
                if (currentNode.Value == value)
                {
                    return i;
                }
                currentNode = currentNode.Next;
            }
            return -1;
        }

        private bool IsEmpty()
        {
            return Head == null;
        }

        public void PrintList()
        {
            Node current = Head;
            while (current != null)
            {
                Console.Write(current);
                if (current.Next != null)
                    Console.Write("->");
                current = current.Next;
            }
            Console.WriteLine();
            if (Size != 0)
            {
                Console.WriteLine("HEAD: " + Head + ", HEAD_NEXT: " + Head.Next);
            }
            else
            {
                Console.WriteLine("List is empty");
                Console.WriteLine("HEAD: " + Head);
            }

        }
    }
}
