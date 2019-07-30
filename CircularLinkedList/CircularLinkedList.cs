using System;
/**
 Circular Linked List 
    Methods:
    GetSize, AddFirst, Add
    RemoveFirst, Remove, Insert, Replace
    Sum, IndexOf, IsEmpty, PrintList
     */
namespace CircularLinkedList
{
    class CircularLinkedList
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }
        private int Size { get; set; }

        public CircularLinkedList()
        {
            this.Head = null;
            this.Tail = null;
            this.Size = 0;
        }

        public int GetSize()
        {
            return Size;
        }

        // Add node in the beginning of the list
        public void AddFirst(int value)
        {
            Node node = new Node(value);
            if (IsEmpty())
            {
                Head = node;
                Head.Next = node;
                Tail = Head;
                Size++;
                return;
            }
            Tail.Next = node;
            node.Next = Head;
            Head = node;
            Size++;
        }

        // Add node at the end of the list
        public void Add(int value)
        {
            Node node = new Node(value);
            if (IsEmpty())
            {
                Head = node;
                Head.Next = node;
                Tail = Head;
                Size++;
                return;
            }
            node.Next = Head;
            Tail.Next = node;
            Tail = node;
            Size++;
        }

        // Remove first node(head) of the list
        public Node RemoveFirst()
        {
            if (IsEmpty()) return null;
            Node removedNode = Head;

            if (Head == Tail)
            {
                Head = Tail = null;
                Size--;
                return removedNode;
            }
            Head = Head.Next;
            Tail.Next = Head;
            removedNode.Next = null;
            Size--;
            return removedNode;
        }

        // Remove node by it's value
        public void Remove(int value)
        {

            if (Size == 0) return;

            Node prevNode = Tail;
            Node currentNode = Head;

            for (int i = 0; i < Size; i++)
            {
                if (currentNode.Value == value)
                {
                    if (prevNode == Tail)
                    {
                        Head = currentNode.Next;
                        Tail.Next = Head;
                        Size--;
                        break;
                    }
                    else
                    {
                        prevNode.Next = currentNode.Next;
                        if (currentNode == Tail)
                        {
                            Tail = prevNode;
                        }
                        Size--;
                        break;
                    }
                }
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        // Insert item in list in position
        public void Insert(int value, int position)
        {
            Node node = new Node(value);
            Node currentNode = Head;

            if ((Head != null) && (position <= Size))
            {
                if (position == 0)
                {
                    node.Next = Head;
                    Head = node;
                    Tail.Next = Head;
                    Size++;
                }
                else if (position == Size)
                {
                    node.Next = Head;
                    Tail.Next = node;
                    Tail = node;
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

        // Replace node value in position
        public void Replace(int value, int position)
        {
            Node node = new Node(value);
            Node currentNode = Head;

            if ((Head != null) && (position < Size))
            {
                if (position == 0 && Size == 1)
                {
                    Head = node;
                    Head.Next = node;
                    Tail = Head;
                }
                else if (position == 0)
                {
                    node.Next = Head.Next;
                    Head = node;
                    Tail.Next = Head;
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

        // Sum of list elements
        public long Sum()
        {
            Node currentNode = Head;
            long sum = 0;
            for (int i = 0; i < Size; i++)
            {
                sum += currentNode.Value;
                currentNode = currentNode.Next;
            }
            return sum;
        }

        // Index by value (first equals from the list)
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

            for (int i = 0; i < Size; i++)
            {
                Console.Write(current);
                current = current.Next;
                if (current != Head)
                    Console.Write("<=>");
            }

            Console.WriteLine();
            if (Size != 0)
            {
                Console.WriteLine("HEAD: " + Head + ", HEAD_NEXT: " + Head.Next);
                Console.WriteLine("TAIL: " + Tail + ", TAIL_NEXT: " + Tail.Next);
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
