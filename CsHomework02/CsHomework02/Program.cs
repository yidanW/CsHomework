using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHomework02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an int:");
            String s = Console.ReadLine();
            int num = int.Parse(s);
            Console.WriteLine("The factors of " + num + " which are prime numbers are as followed:");
            for(int i=1;i<=num/2;i++)
                if(num%i==0)
                    if (PrimeNum(i) == true)
                        Console.WriteLine(i + "");
        }
        static bool PrimeNum(int x)
        {
            for(int i=2;i<=x/2;i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }
    }
}
