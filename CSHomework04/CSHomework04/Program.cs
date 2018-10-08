using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace program
{
    public delegate void TimeoutHander(object sender, DateTime date);   //声明委托类型
    public class MyClock
    {
        public event TimeoutHander TimeOut;                             //声明事件
        public void Timeout(DateTime date)
        {
            TimeOut(this, date);
        }
    }

    class Program

    {

        static void Main(string[] args)
        {
            int year, month, day, hour, minute, second;
            string year1, month1, day1, hour1, minute1, second1;
            Console.WriteLine("Please input an exact time:");
            Console.Write("Year:");
            year1 = Console.ReadLine();
            Console.Write("Month：");
            month1 = Console.ReadLine();
            Console.Write("Day：");
            day1 = Console.ReadLine();
            Console.Write("Hour：");
            hour1 = Console.ReadLine();
            Console.Write("Minute：");
            minute1 = Console.ReadLine();
            Console.Write("Second：");
            second1 = Console.ReadLine();
            try
            {
                year = int.Parse(year1);
                month = int.Parse(month1);
                day = int.Parse(day1);
                hour = int.Parse(hour1);
                minute = int.Parse(minute1);
                second = int.Parse(second1);
            }
            catch
            {
                Console.WriteLine("Error!");
                return;
            }
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime(year, month, day, hour, minute, second);
            TimeSpan timespan = date2 - date1;
            MyClock clock = new MyClock();
            clock.TimeOut += new TimeoutHander(timeOut1);
            Thread.Sleep(timespan);
            clock.Timeout(date2);
        }

        static void timeOut1(object sender, DateTime date)
        {
            Console.WriteLine("Time Arrive!");
        }
    }
}