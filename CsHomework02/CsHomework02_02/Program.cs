using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHomework02_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            int[] A = new int[100];
            Console.WriteLine("Please input the length :");
            s = Console.ReadLine();
            int len = int.Parse(s);
            Console.WriteLine("Please input " +len+" elements :");
            for (int i=0;i<len;i++)
            {
                s = Console.ReadLine();
                A[i] = int.Parse(s);
            }
            int max = A[0], min = A[0], sum = 0;
            for(int i=0;i<len;i++)
            {
                sum += A[i];
                if (A[i] < min)
                    min = A[i];
                if (A[i] > max)
                    max = A[i];
            }
            float aver = sum / (float)len;
            Console.WriteLine("max=" + max + "\nmin=" + min + "\nsum=" + sum + "\naverage=" + aver);
        }
    }
}
