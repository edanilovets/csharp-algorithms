using System;
/**
 Doubly Linked List 
    Methods:
    GetSize, AddFirst, Add
    RemoveFirst, RemoveLast, Remove, Insert, Replace
    Sum, IndexOf, IsEmpty, PrintList
     */

namespace DoublyLinkedList
{
    class DoublyLinkedList
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }
        private int Size { get; set; }

        public DoublyLinkedList()
        {
            this.Head = null;
            this.Tail = null;
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
            if (IsEmpty())
            {
                Head = node;
                Tail = Head;
                Size++;
                return;
            }
            node.Next = Head;
            Head.Prev = node;
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
                Tail = Head;
                Size++;
                return;
            }
            node.Next = null;
            node.Prev = Tail;
            Tail.Next = node;
            Tail = node;
            Size++;
        }

        // remove first node(head) of the list
        public Node RemoveFirst()
        {
            if (IsEmpty()) return null;
            Node removedNode = Head;

            if (Head.Next == null)
            {
                Tail = null;
            }
            else
            {
                Head.Next.Prev = null;
            }
            Head = Head.Next;
            removedNode.Next = null;

            Size--;
            return removedNode;
        }

        // remove last node(tail) of the list
        public Node RemoveLast()
        {
            if (IsEmpty()) return null;
            Node removedNode = Tail;
            if (Tail.Prev == null)
            {
                Head = null;
            }
            else
            {
                Tail.Prev.Next = null;
            }
            Tail = Tail.Prev;
            Size--;

            return removedNode;

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
                    node.Prev = null;
                    Head.Prev = node;
                    Head = node;
                    Size++;
                }
                else
                {
                    for (int i = 1; i < position; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    if (position == Size)
                    {
                        Tail = node;
                    }
                    if (position == Size - 1)
                    {
                        Tail.Prev = node;
                    }
                    node.Next = currentNode.Next;
                    node.Prev = currentNode;
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

        // remove node by it's value
        public void Remove(int value)
        {

            if (Size == 0) return;

            Node prevNode = null;
            Node currentNode = Head;

            while (currentNode != null)
            {

                if (currentNode.Value == value)
                {
                    // remove last element in list
                    if (Head == Tail)
                    {
                        Head = Tail = null;
                        Size--;
                        break;
                    }
                    // remove head
                    if (prevNode == null)
                    {
                        Head = currentNode.Next;
                        Head.Prev = null;
                        Size--;
                        break;
                    }
                    else
                    {
                        prevNode.Next = currentNode.Next;
                        if (currentNode.Next == null)
                        {
                            Tail = prevNode;
                        }
                        else
                        {
                            currentNode.Next.Prev = prevNode;
                        }

                        Size--;
                        break;
                    }
                }
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }
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
                    Console.Write("<=>");
                current = current.Next;
            }
            Console.WriteLine();
            if (Size != 0)
            {
                Console.WriteLine("HEAD: " + Head + ", HEAD_NEXT: " + Head.Next);
                Console.WriteLine("TAIL: " + Tail + ", TAIL_PREV: " + Tail.Prev);
            }
            else
            {
                Console.WriteLine("List is empty");
                Console.WriteLine("HEAD: " + Head);
                Console.WriteLine("TAIL: " + Tail);
            }
        }
    }
}
