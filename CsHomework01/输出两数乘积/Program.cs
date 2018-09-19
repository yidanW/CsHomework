using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 两数乘积
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.WriteLine("Please input 2 int:");
            s = Console.ReadLine();
            int x = Int32.Parse(s);
            s = Console.ReadLine();
            int y = Int32.Parse(s);
            Console.WriteLine("The product is " + x * y);
        }
    }
}
