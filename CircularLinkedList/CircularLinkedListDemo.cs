using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    class CircularLinkedListDemo
    {
        private static void Delay()
        {
            Console.WriteLine("\nPress any key...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            CircularLinkedList list = new CircularLinkedList();
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Demo: Circular Linked List of Integer");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1 - Add node");
                Console.WriteLine("2 - Remove node");
                Console.WriteLine("3 - Insert node in position");
                Console.WriteLine("4 - Replace node in position");
                Console.WriteLine("5 - Sum of all nodes");
                Console.WriteLine("6 - Index Of node");
                Console.WriteLine("7 - Print list");
                Console.WriteLine("8 - Exit");
                Console.WriteLine("--------------------------------");
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    // Add Node
                    case ConsoleKey.D1:
                        Console.WriteLine("Enter node to add:");
                        string insertInput = Console.ReadLine();
                        if (Int32.TryParse(insertInput, out int insertNode))
                        {
                            list.Add(insertNode);
                            Console.WriteLine("Node " + insertNode + " has been added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter integer number");
                        }
                        Delay();
                        break;
                    // Remove Node
                    case ConsoleKey.D2:
                        Console.WriteLine("Enter node to remove:");
                        string removeInput = Console.ReadLine();
                        if (Int32.TryParse(removeInput, out int removeNode))
                        {
                            if (list.IndexOf(removeNode).Equals(-1))
                            {
                                Console.WriteLine("No such node in the list");
                            }
                            else
                            {
                                list.Remove(removeNode);
                                Console.WriteLine("Node " + removeNode + " has been removed from list.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter integer number");
                        }
                        Delay();
                        break;
                    // Insert Node in Position
                    case ConsoleKey.D3:
                        int value = 0, position = 0;
                        while (true)
                        {
                            Console.WriteLine("Enter node to insert:");
                            string getInsert = Console.ReadLine();

                            if (Int32.TryParse(getInsert, out int getNode))
                            {
                                value = getNode;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Enter integer number");
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Enter position:");
                            string getPosition = Console.ReadLine();
                            if (Int32.TryParse(getPosition, out int getPos))
                            {
                                position = getPos;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Enter integer number");
                            }
                        }

                        if (position <= list.GetSize())
                        {
                            list.Insert(value, position);
                            Console.WriteLine("Node has been inserted.");
                        }
                        else
                        {
                            Console.WriteLine("Position is out of range.");
                        }

                        Delay();
                        break;
                        


                    // Replace node in position
                    case ConsoleKey.D4:
                        int replaceValue = 0, replacePosition = 0;
                        while (true)
                        {
                            Console.WriteLine("Enter new node:");
                            string getInsert = Console.ReadLine();

                            if (Int32.TryParse(getInsert, out int getNode))
                            {
                                replaceValue = getNode;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Enter integer number");
                            }
                        }

                        while (true)
                        {
                            Console.WriteLine("Enter position:");
                            string getPosition = Console.ReadLine();
                            if (Int32.TryParse(getPosition, out int getPos))
                            {
                                replacePosition = getPos;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Enter integer number");
                            }
                        }

                        if (replacePosition <= list.GetSize())
                        {
                            list.Replace(replaceValue, replacePosition);
                            Console.WriteLine("Item has been replaced.");
                        }
                        else
                        {
                            Console.WriteLine("Position is out of range.");
                        }

                        Delay();
                        break;

                    // Sum of all nodes
                    case ConsoleKey.D5:
                        list.PrintList();
                        Console.WriteLine("The Sum of nodes: " + list.Sum());
                        Delay();
                        break;
                    
                    // Index of node
                    case ConsoleKey.D6:
                        list.PrintList();
                        Console.WriteLine("Enter node:");
                        string nodeInput = Console.ReadLine();
                        if (Int32.TryParse(nodeInput, out int indexNode))
                        {
                            Console.WriteLine("Index of node " + indexNode + ": " + list.IndexOf(indexNode));
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter integer number");
                        }
                        Delay();
                        break;
                    case ConsoleKey.D7:
                        list.PrintList();
                        Console.WriteLine("\nPress any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D8:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid menu item, enter numbers 1-4");
                        Delay();
                        break;

                }
            }
        }
    }
}
