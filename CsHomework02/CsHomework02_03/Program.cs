using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHomework02_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[100];
            for (int i = 0; i < 100; i++)
                a[i] = 1 + i;
            for(int i=2;i<50;i++)
            {
                for(int j=3;j<100;j++)
                {
                    if (a[j] != 0 &&a[j]%i==0&&a[j]!=i)
                        a[j] = 0;
                }
            }
            for (int i = 0; i < 100; i++)
                if (a[i] != 0)
                    Console.WriteLine(a[i] + "");
        }
    }
}
