using System;

namespace ChainedHashTable
{
    class ChainedHashTableDemo
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Jane", "Jones", 123);
            Employee employee2 = new Employee("John", "Doe", 4567);
            Employee employee3 = new Employee("Mary", "Smith", 22);
            Employee employee4 = new Employee("Mike", "Wilson", 3245);

            ChainedHashTable ht = new ChainedHashTable();
            ht.Put("Jones", employee1);
            ht.Put("Doe", employee2);
            ht.Put("Smith", employee3);
            ht.Put("Wilson", employee4);

            ht.Print();
            Console.WriteLine("Get: " + ht.Get("Smith"));
            Console.WriteLine("Get: " + ht.Get("Wilson"));

            Console.WriteLine("Remove {Mike, Wilson, 3245}");
            ht.Remove("Wilson");
            Console.WriteLine("Remove {Jane, Jones, 123}");
            ht.Remove("Jones");

            ht.Print();
            Console.WriteLine("Get: " + ht.Get("Smith"));
            Console.WriteLine("Get: " + ht.Get("Wilson"));
            Console.ReadLine();
        }
    }
}
