using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainedHashTable
{
    class ChainedHashTable
    {
        private LinkedList<StoredEmployee>[] hashTable;

        public ChainedHashTable()
        {
            hashTable = new LinkedList<StoredEmployee>[8];
            for (int i = 0; i < hashTable.Length; i++)
            {
                hashTable[i] = new LinkedList<StoredEmployee>();
            }
        }
        
        public void Put(String key, Employee employee)
        {
            int hashedKey = HashKey(key);
            hashTable[hashedKey].AddLast(new StoredEmployee(key, employee));
        }

        public Employee Get(String key)
        {
            int hashedKey = HashKey(key);
            foreach (StoredEmployee e in hashTable[hashedKey])
            {
                if (e.key.Equals(key))
                {
                    return e.employee;
                }
            }
            return null;
        }

        public Employee Remove(String key)
        {
            int hashedKey = HashKey(key);
            StoredEmployee employee = null;
            foreach (StoredEmployee e in hashTable[hashedKey])
            {
                employee = e;
                if (employee.key.Equals(key))
                {
                    break;
                }
            }
            if (employee == null)
            {
                return null;
            }
            else
            {
                hashTable[hashedKey].Remove(employee);
                return employee.employee;
            }

        }

        public void Print()
        {
            Console.WriteLine("-----Hash Table-----");
            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] == null)
                {
                    Console.Write("Position " + i + ": empty");
                }
                else
                {
                    Console.Write("Position " + i + ": ");
                    foreach (StoredEmployee e in hashTable[i])
                    {
                        Console.Write(e.employee + "->");
                    }
                    Console.Write("null");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------");
        }

        private int HashKey(String key)
        {
            return key.Length % hashTable.Length;
        }
    }
}
