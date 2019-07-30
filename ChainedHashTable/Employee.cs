using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainedHashTable
{
    class Employee
    {
        private String firstname { get; set; }
        private String lastname { get; set; }
        private int id { get; set; }

        public Employee(String firstname, String lastname, int id)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.id = id;
        }

        public override string ToString()
        {
            return "{" + firstname + ", " + lastname + ", " + id + "}";
        }
    }
}
