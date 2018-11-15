using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order
{
    public class Customer
    {
        public string Name
        {
            get;
            set;
        }
        public long Id
        {
            get;
            set;
        }
        
        public Customer(string newName,long newId)
        {
            Name = newName;
            Id = newId;
        }
        public Customer()
        {

        }
        public override string ToString()
        {
            return $"Customer Name:{Name}  Customer Id::{Id}";
        }
    }
}
