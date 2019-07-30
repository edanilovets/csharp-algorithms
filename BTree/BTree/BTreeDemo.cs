using System;

namespace BTree
{
    class BTreeDemo
    {
        static void Main(string[] args)
        {
            BTree Btree = new BTree();
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Demo: BTree of Integer");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1 - Insert node");
                Console.WriteLine("2 - Delete node");
                Console.WriteLine("3 - Search node");
                Console.WriteLine("4 - Traverse Tree In-Order");
                Console.WriteLine("5 - Display Tree");
                Console.WriteLine("6 - Exit");
                Console.WriteLine("--------------------------------");
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Enter node to insert:");
                        string insertInput = Console.ReadLine();
                        if (Int32.TryParse(insertInput, out int insertNode))
                        {
                            Btree.Insert(insertNode);
                            Console.WriteLine("Node " + insertNode + " has been inserted.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter integer number");
                        }
                        Console.WriteLine("\nPress any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Enter node to delete:");
                        string deleteInput = Console.ReadLine();
                        if (Int32.TryParse(deleteInput, out int deleteNode))
                        {
                            if (Btree.Search(deleteNode) == false)
                            {
                                Console.WriteLine("No such node in the tree");
                            }
                            else
                            {
                                Btree.Delete(deleteNode);
                                Console.WriteLine("Node " + deleteNode + " has been deleted.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter integer number");
                        }
                        Console.WriteLine("\nPress any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D3:
                        Btree.PrintTree();
                        Console.WriteLine("Enter node to search:");
                        string getInput = Console.ReadLine();
                        if (Int32.TryParse(getInput, out int getNode))
                        {
                            if (Btree.Search(getNode) == true)
                            {
                                Console.WriteLine("Node " + getNode + " is present in the tree");
                            }
                            else
                            {
                                Console.WriteLine("No such node in the tree");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter integer number");
                        }
                        Console.WriteLine("\nPress any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Current tree In-Order traverse:");
                        Btree.TraverseInOrder();
                        Console.WriteLine("\nPress any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Current tree(from left to right):");
                        Btree.PrintTree();
                        Console.WriteLine("\nPress any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D6:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid menu item, enter numbers 1-4");
                        Console.WriteLine("\nPress any key...");
                        Console.ReadLine();
                        break;

                }
            }
        }
    }
}
